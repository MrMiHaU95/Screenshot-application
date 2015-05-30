using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenAppWinForms
{
    static class NotifyIconHelper
    {
        private static NotifyIcon notifyIcon;
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

        public static void CreateNotifyIcon()
        {
            NotifyIconObject = new NotifyIcon();
            NotifyIconObject.ContextMenuStrip = ContextMenuStripHelper.GetContext();
            NotifyIconObject.Icon = new Icon(@"Images\screenShoot3.ico");
            NotifyIconObject.Visible = true;
        }

        public static void ShowBallonTip()
        {
            NotifyIconObject.BalloonTipText = "Nowy screen zapisano jako " + InfoAboutScreenshot.FileName + " Kliknij aby otworzyć folder zapisu";
            NotifyIconObject.BalloonTipTitle = "Screen App";
            NotifyIconObject.BalloonTipIcon = ToolTipIcon.Info;
            NotifyIconObject.BalloonTipClicked += notifyIcon_BalloonTipClicked;
            NotifyIconObject.ShowBalloonTip(2000);
        }

        //event handler obsługujący Click event na elemencie ContextMenuStrip
        static void notifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            if (File.Exists(InfoAboutScreenshot.FolderPath))
            {
                //otwarcie nowego eksploratora windowsa i ustawienie ścieżki na folder zapisu screena
                string argument = @"/select, " + InfoAboutScreenshot.FolderPath;
                System.Diagnostics.Process.Start("explorer.exe", argument);
            }
        }
    }
}
