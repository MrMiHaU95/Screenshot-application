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
    /// <summary>
    /// klasa pomocnicza tworzy obiekt NotifyIcon oraz wywołuje BallonTip
    /// </summary>
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
        /// <summary>
        /// Przypisuje wartości do pól obiektu klasy NotifyIcon 
        /// </summary>
        public static void CreateNotifyIconEnglish()
        {
            if (NotifyIconObject != null)
            {
                NotifyIconObject.Visible = false;
                NotifyIconObject.Dispose();
            }
            try
            {
                NotifyIconObject = new NotifyIcon();
                NotifyIconObject.ContextMenuStrip = ContextMenuStripHelper.GetContextEnglish();
                NotifyIconObject.Icon = new Icon(@"Images\screenShoot3.ico");
                NotifyIconObject.Visible = true;
                SettingsHelper.CurrentLanguage = "en";
            }
            catch(FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void CreateNotifyIconPolish()
        {
            if (NotifyIconObject != null)
            {
                NotifyIconObject.Visible = false;
                NotifyIconObject.Dispose();
            }
            try
            {
                NotifyIconObject = new NotifyIcon();
                NotifyIconObject.ContextMenuStrip = ContextMenuStripHelper.GetContextPolish();
                NotifyIconObject.Icon = new Icon(@"Images\screenShoot3.ico");
                NotifyIconObject.Visible = true;
                SettingsHelper.CurrentLanguage = "pl";
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// pokazuje BallonTip wykorzystuje statyczną klasę InfoAboutScreenshot
        /// </summary>
        public static void ShowBallonTip()
        {
            if (SettingsHelper.CurrentLanguage == "pl")
            {
                NotifyIconObject.BalloonTipText = "Nowy screen zapisano jako " + InfoAboutScreenshot.FileName + " Kliknij aby otworzyć folder zapisu";
            }
            else
            {
                NotifyIconObject.BalloonTipText = "New screenshot saved as " + InfoAboutScreenshot.FileName + " Click to open save folder";
            }
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
