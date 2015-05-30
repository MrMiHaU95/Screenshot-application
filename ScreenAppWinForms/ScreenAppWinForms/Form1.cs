using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenAppWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap screenShotFullScreen;
        Screenshot screenshotObject = new Screenshot();

        //screen całego ekranu
        private void btnFullScreenShoot_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

            System.Threading.Thread.Sleep(270);

            screenShotFullScreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            Graphics g = Graphics.FromImage(screenShotFullScreen as Image);

            g.CopyFromScreen(0, 0, 0, 0, screenShotFullScreen.Size);

            this.WindowState = FormWindowState.Normal;

            screenshotObject.ZapiszScreena(screenShotFullScreen);
        }

        private void buttonCaptureArea_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

            Tło noweTło = new Tło();
            noweTło.BackgroundImage = screenshotObject.ZróbScreenaCałegoEkranu(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            noweTło.TopMost = true;
            noweTło.Show();

            
            
        }

        

    }
}
