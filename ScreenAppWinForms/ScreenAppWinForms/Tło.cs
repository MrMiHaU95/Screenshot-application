using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenAppWinForms
{
    public partial class Tło : Form
    {
        //public Rectangle rect;
        //private Point punktPoczatkowyKursora;
        //private Point punkGdzieAktualnieZnajdujeSieKurosor;

        //private Point PunktStartowyPrzesuwania;

        private bool CzyToolTipBylWyswietlony;

        //private bool CzyUserNarysowalZaznaczenie;

        public Tło()
        {
            InitializeComponent();
            //podwójne buforowanie zmiejsza migotanie rysowanych obiektów tooltipów itd
            this.DoubleBuffered = true;

            //ustawia pole klasy statycznej na obiekt tej klasy
            ButtonsHelper.SetBackgroundObject(this);
        }

        //rysowanie obszaru screena
        private void Tło_MouseDown(object sender, MouseEventArgs e)
        {
            //punktPoczatkowyKursora = e.Location;
            UserSelectionHelper.StartUpCursorPosition = e.Location;
            
            ButtonsHelper.DisposeButtons();

            //przesuwanie zaznaczenia
            //if (e.Button == MouseButtons.Right && e.X > rect.X && e.X < rect.X + rect.Width && e.Y > rect.Y && e.Y < rect.Y + rect.Height)
            //{
            //    PunktStartowyPrzesuwania = e.Location;
            //}
            UserSelectionHelper.SetMoveSelectionCursorPosition(e);

            this.Invalidate();
        }

        private void Tło_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                punkGdzieAktualnieZnajdujeSieKurosor = e.Location;
                int x = Math.Min(punktPoczatkowyKursora.X, punkGdzieAktualnieZnajdujeSieKurosor.X);
                int y = Math.Min(punktPoczatkowyKursora.Y, punkGdzieAktualnieZnajdujeSieKurosor.Y);
                int width = Math.Abs(punkGdzieAktualnieZnajdujeSieKurosor.X - punktPoczatkowyKursora.X);
                int height = Math.Abs(punkGdzieAktualnieZnajdujeSieKurosor.Y - punktPoczatkowyKursora.Y);
                rect = new Rectangle(x, y, width, height);
                this.Invalidate();

                Cursor.Current = Cursors.SizeNWSE;

                CzyUserNarysowalZaznaczenie = true;
            }

                //przesuwanie zaznaczenia
            if (e.Button == MouseButtons.Right && e.X > rect.X && e.X < rect.X + rect.Width && e.Y > rect.Y && e.Y < rect.Y + rect.Height)
            {
                toolTip1.Hide(this);

                //blokowanie zaznaczenia aby nie wychodziło po za obszar ekranu
                Point tempPoint = new Point((e.X - PunktStartowyPrzesuwania.X) + rect.Left, (e.Y - PunktStartowyPrzesuwania.Y) + rect.Top);

                if (tempPoint.Y > 0 && tempPoint.X > 0 && tempPoint.X + rect.Width < this.Width && tempPoint.Y + rect.Height < this.Height)
                {
                    rect.Location = new Point((e.X - PunktStartowyPrzesuwania.X) + rect.Left, (e.Y - PunktStartowyPrzesuwania.Y) + rect.Top);
                    
                }
                PunktStartowyPrzesuwania = e.Location;
                ButtonsHelper.CheckIfButtonsOffScreen(rect, Screen.PrimaryScreen.Bounds.Height);
                ButtonsHelper.DisposeButtons();
                this.Invalidate();
                
            }
                //zmiana kursora na krzyzyk gdy kursor jest w obszarze zaznaczenia 
            else if(e.X > rect.X && e.X < rect.X + rect.Width && e.Y > rect.Y && e.Y < rect.Y + rect.Height)
            {
                Cursor.Current = Cursors.SizeAll;

                //tooltip
                if (!CzyToolTipBylWyswietlony)
                {
                    Point tempPoint = new Point(e.X, e.Y - 50);
                    toolTip1.Show("naciśnij i przytrzymaj prawy przycisk myszy i przesun mysz aby utworzyć zaznaczenie",this,e.X,e.Y);
                    CzyToolTipBylWyswietlony = true;
                }
            }
        }

        //dodawanie przycisków do obszarów zaznaczenia
        private void Tło_MouseUp(object sender, MouseEventArgs e)
        {
            if (CzyUserNarysowalZaznaczenie)
            {
                ButtonsHelper.DrawAndMoveButtons(rect);
            }
        }

        //event handler ballon tip
        static void notifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            if (File.Exists(InfoAboutScreenshot.FolderPath))
            {
                string argument = @"/select, " + InfoAboutScreenshot.FolderPath;
                System.Diagnostics.Process.Start("explorer.exe", argument);
            }
        }

        private void Tło_Paint(object sender, PaintEventArgs e)
        {
            using (Pen p = new Pen(Color.Red, 1))
            {
                e.Graphics.DrawRectangle(p, rect);
            }
            //przyciemnienie okna
            BackgroundHelper.AddTransparentBlackColor(e, rect, Screen.PrimaryScreen.Bounds.Height, Screen.PrimaryScreen.Bounds.Width);
        }

        //zamknięcie tego trybu ESC
        private void Tło_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            //zapis screena do pliku
            if (e.KeyCode == Keys.Enter)
            {
                if (punktPoczatkowyKursora != null && punkGdzieAktualnieZnajdujeSieKurosor != null)
                {
                    toolTip1.Hide(this);
                    toolTip1.Active = false;

                    Bitmap screen = ScreenshotHelper.TakeScreenshotOfUserSelection(rect);
                    ScreenshotHelper.SaveScreenshot(screen);

                    if (InfoAboutScreenshot.CzyUserZapisalScreena)
                    {
                        NotifyIconHelper.ShowBallonTip();
                    }
                    this.Close();
                }
            }
        }
    }
}
