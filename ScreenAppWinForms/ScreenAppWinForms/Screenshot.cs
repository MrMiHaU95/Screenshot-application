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
    class Screenshot
    {
        public Image ZróbScreenaCałegoEkranu(int width, int height)
        {
            //System.Threading.Thread.Sleep(270);

            Bitmap fullScreen = new Bitmap(width, height);

            Graphics g = Graphics.FromImage(fullScreen as Image);

            g.CopyFromScreen(0, 0, 0, 0, fullScreen.Size);

            return fullScreen;

        }

        public Bitmap ZróbScreenaCzęściEkranu(int xSource, int ySource, int xDestination, int yDestination, Rectangle rect)
        {
            //System.Threading.Thread.Sleep(270);

            Bitmap ScreenKawałkaEkranu = new Bitmap(rect.Width-1,rect.Height-1);

            Graphics g = Graphics.FromImage(ScreenKawałkaEkranu as Image);

            
            g.CopyFromScreen(rect.X+1,rect.Y+1, 0, 0, rect.Size);

            return ScreenKawałkaEkranu;
        }

        public DialogResult ZapiszScreena(Bitmap screen)
        {
            //refactor utworzyć klasę z tą metodą
            SaveFileDialog sfd = new SaveFileDialog();
            
            sfd.Title = "Zapisz screena jako...";
            sfd.Filter = "JPEG|*.jpg|Bitmapa|*.bmp|Gif|*.gif|PNG|*.png";
            DialogResult result = sfd.ShowDialog();

            InfoAboutScreenshot.WyczyscDane();
            InfoAboutScreenshot.FileName = Path.GetFileName(sfd.FileName);
            InfoAboutScreenshot.FolderPath = sfd.FileName;
            InfoAboutScreenshot.SprawdzCzyUserZapisalScreena(result);

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
            return result;

            

            
        }
    }
}
