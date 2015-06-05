using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ScreenAppWinForms
{
    /// <summary>
    /// klasa zawiera metodę GetContext() która tworzy ContextMenuStrip oraz event handlery obsługujące Click event elementów ContextMenuStrip
    /// </summary>
    static class ContextMenuStripHelper
    {
        public static ContextMenuStrip GetContext()
        {
            ContextMenuStrip CMS = new ContextMenuStrip();

            Image imgScreenOfUserSelection = Image.FromFile(@"Images\rectScreen2.ico");
            Image imgFullScreenScreenshot = Image.FromFile(@"Images\fullscreen2.ico");
            Image imgExit = Image.FromFile(@"Images\exit2.ico");
            Image imgScreenshotEditor = Image.FromFile(@"Images\screenshotEditor2.ico");
            Image imgUploadFullScreenScreenshot = Image.FromFile(@"Images\imgur.ico");

            CMS.Items.Add("Screenshot of entire screen", imgFullScreenScreenshot, ScreenshotOfEntireScreen_Click);
            CMS.Items.Add("Upload Screenshot of entire screen to Imgur", imgUploadFullScreenScreenshot, UploadScreenshotOfEntireScreen_Click);
            CMS.Items.Add("Screenshot of user selection", imgScreenOfUserSelection, ScreenshotOfUserSelection_Click);
            CMS.Items.Add("Screenshot Editor", imgScreenshotEditor, ScreenshotEditor_Click);
            CMS.Items.Add("Upload image to Imgur", imgUploadFullScreenScreenshot, UploadImage_Click);
            CMS.Items.Add("Exit", imgExit, Exit_Click);

            return CMS;
        }

        

        
        #region event handlery ContextMenuStrip
        private static void UploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "JPEG|*.jpg|Bitmapa|*.bmp|Gif|*.gif|PNG|*.png";
            ofd.Title = "Upload image";
            DialogResult result =  ofd.ShowDialog();
            if(result == DialogResult.OK)
            {
                UploadToImgurHelper.UploadImageWithoutDeleting(ofd.FileName);
            }
        }

        private static void UploadScreenshotOfEntireScreen_Click(object sender, EventArgs e)
        {
            //odczytuje ścieżke do wykonywanego exe
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            //aby zuploadować screena do imgur trzeba go najpierw zapisać na dysku 
            Bitmap screenShotFullScreen;
            screenShotFullScreen = (Bitmap)ScreenshotHelper.TakeScreenshotOfEntireScreen(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            screenShotFullScreen.Save( directory+@"\\1.png", System.Drawing.Imaging.ImageFormat.Png);
            UploadToImgurHelper.UploadScreenshot(directory + @"\\1.png");
        }

        private static void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private static void ScreenshotEditor_Click(object sender, EventArgs e)
        {
            ScreenshotEditor screenManager = new ScreenshotEditor();
            screenManager.Width = Screen.PrimaryScreen.Bounds.Width;
            screenManager.Height = Screen.PrimaryScreen.Bounds.Height - 40;
            screenManager.StartPosition = FormStartPosition.CenterScreen;
            screenManager.Show();
        }

        private static void ScreenshotOfUserSelection_Click(object sender, EventArgs e)
        {
            Background newBackground = new Background();
            System.Threading.Thread.Sleep(270);
            newBackground.BackgroundImage = ScreenshotHelper.TakeScreenshotOfEntireScreen(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            newBackground.TopMost = true;
            newBackground.Show();
        }

        private static void ScreenshotOfEntireScreen_Click(object sender, EventArgs e)
        {
            Bitmap screenShotFullScreen;

            screenShotFullScreen = (Bitmap)ScreenshotHelper.TakeScreenshotOfEntireScreen(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            ScreenshotHelper.SaveScreenshot(screenShotFullScreen);

            if (InfoAboutScreenshot.DidUserSavedScreenshot)
            {
                NotifyIconHelper.ShowBallonTip();
            }
        }
        
        #endregion
    }
}
