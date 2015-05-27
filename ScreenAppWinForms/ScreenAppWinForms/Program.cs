using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenAppWinForms
{
    static class Program
    {
        //http://stackoverflow.com/questions/2450373/set-global-hotkeys-using-c-sharp
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            NotifyIcon notifyIcon = new NotifyIcon();
            notifyIcon.ContextMenuStrip = GetContext();
            notifyIcon.Icon = new Icon(@"Images\screenShoot3.ico");
            notifyIcon.Visible = true;
            
            Application.Run();
        }

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

        

        private static void Wyjscie_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

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

            System.Threading.Thread.Sleep(270);

            screenShotFullScreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            Graphics g = Graphics.FromImage(screenShotFullScreen as Image);

            g.CopyFromScreen(0, 0, 0, 0, screenShotFullScreen.Size);

            

            screenshotObject.ZapiszScreena(screenShotFullScreen,null);
        }
    }
}
