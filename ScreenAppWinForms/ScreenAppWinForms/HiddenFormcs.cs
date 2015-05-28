using registerHotkey;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenAppWinForms
{
    public partial class HiddenFormcs : Form
    {
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(String sClassName, string sAppName);

        private IntPtr thisWindow;
        private Hotkey hotKey;

        public HiddenFormcs()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }

        private void HiddenFormcs_Load(object sender, EventArgs e)
        {
            thisWindow = FindWindow(null, "HiddenFormcs");
            hotKey = new Hotkey(thisWindow);
            hotKey.RegisterHotKeys();
        }

        private void HiddenFormcs_FormClosed(object sender, FormClosedEventArgs e)
        {
            hotKey.UnregisterHotKeys();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312)
            {
                //id hotkey
                int id = m.WParam.ToInt32();

                if (id == 1)
                {

                    Bitmap screenShotFullScreen;
                    Screenshot screenshotObject = new Screenshot();

                    screenShotFullScreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

                    Graphics g = Graphics.FromImage(screenShotFullScreen as Image);

                    g.CopyFromScreen(0, 0, 0, 0, screenShotFullScreen.Size);

                    screenshotObject.ZapiszScreena(screenShotFullScreen, this);

                    this.WindowState = FormWindowState.Minimized;
                    this.ShowInTaskbar = false;
                }
                else if(id == 2)
                {
                    Tło noweTło = new Tło();
                    Screenshot screenshotObject = new Screenshot();
                    noweTło.BackgroundImage = screenshotObject.ZróbScreenaCałegoEkranu(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                    noweTło.TopMost = true;
                    noweTło.Show();
                }

            }
            base.WndProc(ref m);
        }
    }
}
