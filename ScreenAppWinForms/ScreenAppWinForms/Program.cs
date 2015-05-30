using registerHotkey;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenAppWinForms
{
    static class Program
    {
        private static NotifyIcon notifyIcon;
        // klasa Program też ma z tego korzystać
        public static NotifyIcon NotifyIconObject
        {
            get
            {
                return notifyIcon;
            }
            private set
            {
                notifyIcon = value;
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            //tworzenie nowego notify icon 
            Program.notifyIcon = new NotifyIcon();
            Program.notifyIcon.ContextMenuStrip = GetContext();
            Program.notifyIcon.Icon = new Icon(@"Images\screenShoot3.ico");
            Program.notifyIcon.Visible = true;

            Application.Run(new HiddenFormcs());

           

        }

        //contextMenuStrip wyświetlane gdy user kliknie prawym przyciskiem myszy na notify icon
        private static ContextMenuStrip GetContext()
        {
            ContextMenuStrip CMS = new ContextMenuStrip();

            Image imgScreenZaznaczenia = Image.FromFile(@"Images\rectScreen2.ico");
            Image imgScreenCalegoEkranu = Image.FromFile(@"Images\fullscreen2.ico");
            Image imgWyjscie = Image.FromFile(@"Images\exit2.ico");
            Image imgPrzeglądanieScreenów = Image.FromFile(@"Images\browse.ico");

            CMS.Items.Add("Screen całego ekranu", imgScreenCalegoEkranu, ScreenCalegoEkranu_Click);
            CMS.Items.Add("Screen zaznaczenia", imgScreenZaznaczenia, ScreenZaznaczenia_Click);
            CMS.Items.Add("Przeglądanie screenów", imgPrzeglądanieScreenów, PrzeglądanieScreenów_Click);
            CMS.Items.Add("Wyjście", imgWyjscie, Wyjscie_Click);
            
            return CMS;
        }


        #region event handlery ContextMenuStrip
        private static void Wyjscie_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //nowa funkcja jeszce nie dodana
        private static void PrzeglądanieScreenów_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void ScreenZaznaczenia_Click(object sender, EventArgs e)
        {
            Screenshot screenshotObject = new Screenshot();
            Tło noweTło = new Tło();
            System.Threading.Thread.Sleep(270);
            noweTło.BackgroundImage = screenshotObject.ZróbScreenaCałegoEkranu(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            noweTło.TopMost = true;
            noweTło.Show();
        }

        private static void ScreenCalegoEkranu_Click(object sender, EventArgs e)
        {
            Screenshot screenshotObject = new Screenshot();
            Bitmap screenShotFullScreen;

            screenShotFullScreen = (Bitmap)screenshotObject.ZróbScreenaCałegoEkranu(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            screenshotObject.ZapiszScreena(screenShotFullScreen);

            if (InfoAboutScreenshot.CzyUserZapisalScreena)
            {
                Program.notifyIcon.BalloonTipText = "Nowy screen zapisano jako " + InfoAboutScreenshot.FileName + " Kliknij aby otworzyć folder zapisu";
                Program.notifyIcon.BalloonTipTitle = "Screen App";
                Program.notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
                Program.notifyIcon.BalloonTipClicked += notifyIcon_BalloonTipClicked;
                Program.notifyIcon.ShowBalloonTip(2000);
            }
        }
        #endregion

        static void notifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            if (File.Exists(InfoAboutScreenshot.FolderPath))
            {
                 string argument = @"/select, " + InfoAboutScreenshot.FolderPath;
                 System.Diagnostics.Process.Start("explorer.exe", argument);
            }
        }

        
    }
}
