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
    /// klasa zawiera metodę GetContext() która tworzy ContextMenuStrip oraz event handlery obsługujące Click event elementów ContextMenuStrip
    /// </summary>
    static class ContextMenuStripHelper
    {
        public static ContextMenuStrip GetContext()
        {
            ContextMenuStrip CMS = new ContextMenuStrip();

            Image imgScreenZaznaczenia = Image.FromFile(@"Images\rectScreen2.ico");
            Image imgScreenCalegoEkranu = Image.FromFile(@"Images\fullscreen2.ico");
            Image imgWyjscie = Image.FromFile(@"Images\exit2.ico");
            Image imgPrzeglądanieScreenów = Image.FromFile(@"Images\browse.ico");

            CMS.Items.Add("Screen całego ekranu", imgScreenCalegoEkranu, ScreenshotOfEntireScreen_Click);
            CMS.Items.Add("Screen zaznaczenia", imgScreenZaznaczenia, ScreenshotOfUserSelection_Click);
            CMS.Items.Add("Przeglądanie screenów", imgPrzeglądanieScreenów, ScreenshotManager_Click);
            CMS.Items.Add("Wyjście", imgWyjscie, Exit_Click);

            return CMS;
        }
        #region event handlery ContextMenuStrip
        private static void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //nowa funkcja jeszce nie dodana
        private static void ScreenshotManager_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void ScreenshotOfUserSelection_Click(object sender, EventArgs e)
        {
            Background noweTło = new Background();
            System.Threading.Thread.Sleep(270);
            noweTło.BackgroundImage = ScreenshotHelper.TakeScreenshotOfEntireScreen(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            noweTło.TopMost = true;
            noweTło.Show();
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
