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
    /// Klasa zawiera Funkcje robienia screena całego ekranu jak i części oraz zapisu screenu do pliku
    /// </summary>
    static class ScreenshotHelper
    {
        /// <summary>
        /// wykonuje screena "całego ekranu" jeśli podasz wymiary ekranu
        /// </summary>
        /// <param name="primaryScreenWidth">szerokość screena całego ekranu Screen.PrimaryScreen.Bounds.Width</param>
        /// <param name="primaryScreenHeight">wysokość screena całego ekranu Screen.PrimaryScreen.Bounds.Height</param>
        /// <returns></returns>
        public static Bitmap TakeScreenshotOfEntireScreen(int primaryScreenWidth, int primaryScreenHeight)
        {
            Bitmap fullScreen = new Bitmap(primaryScreenWidth, primaryScreenHeight);
            Graphics g = Graphics.FromImage(fullScreen as Image);
            g.CopyFromScreen(0, 0, 0, 0, fullScreen.Size);
            return fullScreen;
        }
        /// <summary>
        /// wykonuje screena zaznaczenia narysowanego przez usera
        /// </summary>
        /// <param name="selectedArea">zaznaczenie narysowanie przez usera w postaci obiektu klasy Rectangle</param>
        /// <returns></returns>
        public static Bitmap TakeScreenshotOfUserSelection(Rectangle selectedArea)
        {
            Bitmap screenshotOfUserSelection = new Bitmap(selectedArea.Width - 1, selectedArea.Height - 1);
            Graphics g = Graphics.FromImage(screenshotOfUserSelection as Image);
            g.CopyFromScreen(selectedArea.X + 1, selectedArea.Y + 1, 0, 0, selectedArea.Size);
            return screenshotOfUserSelection;
        }
        /// <summary>
        /// zapisuje bitmapę czyli screena do pliku w formacie wybranym przez usera obojętnie czy to screen całego ekranu czy zaznaczenia dostepne formaty
        /// Jpeg,Bmp,Gif,Png
        /// </summary>
        /// <param name="screenshot">obiekt klasy Bitmap zostanie skonwertowany do formatu wybranego przez usera</param>
        /// <returns></returns>
        public static void SaveScreenshot(Bitmap screenshot)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Zapisz screena jako...";
            sfd.Filter = "JPEG|*.jpg|Bitmapa|*.bmp|Gif|*.gif|PNG|*.png";
            DialogResult result = sfd.ShowDialog();

            //ustawianie wartości klasy zawierającej informacje o screenie
            InfoAboutScreenshot.WyczyscDane();
            InfoAboutScreenshot.FileName = Path.GetFileName(sfd.FileName);
            InfoAboutScreenshot.FolderPath = sfd.FileName;
            InfoAboutScreenshot.SprawdzCzyUserZapisalScreena(result);

            //switch w zależności od wyboru użytkownika formatu screena
            if (sfd.FileName != "")
            {
                if (screenshot != null)
                {
                    switch (sfd.FilterIndex)
                    {
                        case 1:
                            screenshot.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;
                        case 2:
                            screenshot.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                            break;
                        case 3:
                            screenshot.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Gif);
                            break;
                        case 4:
                            screenshot.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Png);
                            break;
                    }
                }
            }
        }
    }
}
