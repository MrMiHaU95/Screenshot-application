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
    class Screenshot
    {
        /// <summary>
        /// wykonuje screena "całego ekranu" jeśli podasz wymiary ekranu
        /// </summary>
        /// <param name="width">szerokość screena całego ekranu Screen.PrimaryScreen.Bounds.Width</param>
        /// <param name="height">wysokość screena całego ekranu Screen.PrimaryScreen.Bounds.Height</param>
        /// <returns></returns>
        public Bitmap ZróbScreenaCałegoEkranu(int width, int height)
        {
            Bitmap fullScreen = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(fullScreen as Image);
            g.CopyFromScreen(0, 0, 0, 0, fullScreen.Size);
            return fullScreen;
        }
        /// <summary>
        /// wykonuje screena zaznaczenia narysowanego przez usera
        /// </summary>
        /// <param name="rect">zaznaczenie narysowanie przez usera w postaci obiektu klasy Rectangle</param>
        /// <returns></returns>
        public Bitmap ZróbScreenaCzęściEkranu(Rectangle rect)
        {
            Bitmap ScreenKawałkaEkranu = new Bitmap(rect.Width-1,rect.Height-1);
            Graphics g = Graphics.FromImage(ScreenKawałkaEkranu as Image);
            g.CopyFromScreen(rect.X+1,rect.Y+1, 0, 0, rect.Size);
            return ScreenKawałkaEkranu;
        }
        /// <summary>
        /// zapisuje bitmapę czyli screena do pliku w formacie wybranym przez usera obojętnie czy to screen całego ekranu czy zaznaczenia dostepne formaty
        /// Jpeg,Bmp,Gif,Png
        /// </summary>
        /// <param name="screen">obiekt klasy Bitmap zostanie skonwertowany do formatu wybranego przez usera</param>
        /// <returns></returns>
        public void ZapiszScreena(Bitmap screen)
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
                if (screen != null)
                {
                    switch (sfd.FilterIndex)
                    {
                        case 1:
                            screen.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;
                        case 2:
                            screen.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                            break;
                        case 3:
                            screen.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Gif);
                            break;
                        case 4:
                            screen.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Png);
                            break;
                    }
                }
            }
        }
    }
}
