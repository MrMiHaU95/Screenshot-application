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
            UkryjOkno();
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
                    ZróbScreenaCałegoEkranu();
                    PokażBalloonTip();
                    UkryjOkno();
                }
                    //screen zanaczenia
                else if(id == 2)
                {
                    WczytajEkranDoRysowaniaZaznaczenia();
                    //czemu tak długo!?
                    PokażBalloonTip();
                }
            }
            base.WndProc(ref m);
        }

        private void ZróbScreenaCałegoEkranu()
        {
            Bitmap screenCałegoEkranu;
            Screenshot screenshotObject = new Screenshot();

            screenCałegoEkranu = screenshotObject.ZróbScreenaCałegoEkranu(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height) as Bitmap;
            screenshotObject.ZapiszScreena(screenCałegoEkranu);
        }

        private  void WczytajEkranDoRysowaniaZaznaczenia()
        {
            Tło noweTło = new Tło();
            Screenshot screenshotObject = new Screenshot();
            noweTło.BackgroundImage = screenshotObject.ZróbScreenaCałegoEkranu(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            noweTło.TopMost = true;
            noweTło.Show();
        }

        private  void PokażBalloonTip()
        {
            Program.NotifyIconObject.BalloonTipText = "Nowy screen zapisano jako " + InfoAboutScreenshot.FileName + " Kliknij aby otworzyć folder zapisu";
            Program.NotifyIconObject.BalloonTipTitle = "Screen App";
            Program.NotifyIconObject.BalloonTipIcon = ToolTipIcon.Info;
            Program.NotifyIconObject.BalloonTipClicked += notifyIcon_BalloonTipClicked;
            Program.NotifyIconObject.ShowBalloonTip(2000);
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

        public void UkryjOkno()
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }
    }
}
