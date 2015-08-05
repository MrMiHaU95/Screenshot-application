using registerHotkey;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenAppWinForms
{
    /// <summary>
    /// okienko którego w trakcie działania appki cały czas jest ukryte służy jedynie do rejestracji i obsługi skrótów klawiszowych
    /// </summary>
    public partial class HiddenFormcs : Form
    {
#region windows API
        /// <summary>
        /// metoda wyszukująca uchwyt do okna które spełnia warunki podane w parametrach, jeden z parametrów może być null
        /// </summary>
        /// <param name="sClassName">nazwa klasy np"Form1.cs" może być null</param>
        /// <param name="sAppName">nazwa aplikacji może być null</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(String sClassName, string sAppName);
#endregion

        /// <summary>
        /// window handle dla tego okna
        /// </summary>
        private IntPtr thisWindow;

        private Hotkey hotKey;

        public HiddenFormcs()
        {
            InitializeComponent();

            //2 poniższe linijki minimalizują okno oraz usuwają ikonkę z paska zadań
            HideWindow();
        }
        
        //przy wczytywaniu okna od razu rejestrowane są nowe skróty oraz wyszukiwany jest uchwyt okna
        private void HiddenFormcs_Load(object sender, EventArgs e)
        {
            thisWindow = FindWindow(null, "HiddenFormcs");
            hotKey = new Hotkey(thisWindow);
            hotKey.RegisterHotKeys();
        }

        //przy zamknięciu okna czyli zakończeniu działania appki skróty muszą zostać wyrejestrowane
        private void HiddenFormcs_FormClosed(object sender, FormClosedEventArgs e)
        {
            hotKey.UnregisterHotKeys();
        }

        /// <summary>
        /// metoda przetwarzająca wiadomości systemu windows
        /// </summary>
        /// <param name="m">wiadomości systemu windows dla procesu</param>
        protected override void WndProc(ref Message m)
        {
            //stała zawierająca wartość message gdy zarejestrowany skrót został wciśnięty przez usera  
            const int WM_HOTKEY = 0x0312;

            if (m.Msg == WM_HOTKEY)
            {
                //id hotkey po id odróżnia się skróty od siebie
                int id = m.WParam.ToInt32();
                
                //screen całego ekranu
                if (id == 1)
                {
                    TakeScreenshotOfEntireScreen();
                    if(InfoAboutScreenshot.DidUserSavedScreenshot)
                    {
                        ShowBallonTip();
                    }
                    HideWindow();
                }
                    //screen zanaczenia
                else if(id == 2)
                {
                    LoadBackground();
                }
                //upload screena całego ekranu na imgur
                else if(id == 3)
                {
                    try
                    {


                        //odczytuje ścieżkę do wykonywanego exe
                        string directory = AppDomain.CurrentDomain.BaseDirectory;
                        //aby zuploadować screena do imgur trzeba go najpierw zapisać na dysku 
                        Bitmap screenShotFullScreen;
                        screenShotFullScreen = (Bitmap)ScreenshotHelper.TakeScreenshotOfEntireScreen(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                        screenShotFullScreen.Save(directory + @"\\1.png", System.Drawing.Imaging.ImageFormat.Png);
                        UploadToImgurHelper.UploadScreenshot(directory + @"\\1.png");
                    }
                    catch(FileNotFoundException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            base.WndProc(ref m);
        }

        private void TakeScreenshotOfEntireScreen()
        {
            Bitmap fullScreenScreenshot;

            fullScreenScreenshot = ScreenshotHelper.TakeScreenshotOfEntireScreen(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height) as Bitmap;
            ScreenshotHelper.SaveScreenshot(fullScreenScreenshot);
            
        }

        private  void LoadBackground()
        {
            Background background = new Background();
            background.BackgroundImage = ScreenshotHelper.TakeScreenshotOfEntireScreen(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            background.TopMost = true;
            background.Show();
        }

        private  void ShowBallonTip()
        {
            NotifyIconHelper.ShowBallonTip();
        }

        //event handler ballon tip
        static void notifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            if (File.Exists(InfoAboutScreenshot.FolderPath))
            {
                string argument = @"/select, " + InfoAboutScreenshot.FolderPath;
                System.Diagnostics.Process.Start("explorer.exe", argument);
            }
        }

        public void HideWindow()
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }
    }
}
