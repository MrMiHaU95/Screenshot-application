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
    public partial class Tło : Form
    {
        private Rectangle rect;
        private Point punktPoczatkowyKursora;
        private Point punkGdzieAktualnieZnajdujeSieKurosor;
        private Screenshot screenshotObject;

        private Point PunktStartowyPrzesuwania;

        private bool CzyToolTipBylWyswietlony;

        private Button btnZapiszScreenaObszaru;
        private Button btnUsunZaznaczenieObszaru;

        private bool CzyUserNarysowalZaznaczenie;

        public Tło()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        //rysowanie obszaru screena
        private void Tło_MouseDown(object sender, MouseEventArgs e)
        {
            punktPoczatkowyKursora = e.Location;
            this.Invalidate();

            //usuwanie buttonów
            if (btnZapiszScreenaObszaru != null && btnUsunZaznaczenieObszaru != null)
            {
                btnZapiszScreenaObszaru.Dispose();
                btnUsunZaznaczenieObszaru.Dispose();
            }

            //przesuwanie zaznaczenia
            if (e.Button == MouseButtons.Right && e.X > rect.X && e.X < rect.X + rect.Width && e.Y > rect.Y && e.Y < rect.Y + rect.Height)
            {
                PunktStartowyPrzesuwania = e.Location;

                
            }

        }

        private void Tło_MouseMove(object sender, MouseEventArgs e)
        {
            //ToolTip tt= new ToolTip();

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
                //usuniencie tooltipa gdy user nacisnie prawy przycisk myszy w obrębie zaznaczenia
                //if(tt != null)
                //{
                //    tt.Active = false;
                //    tt.RemoveAll();
                //}

                //usuwanie buttonów
                if (btnZapiszScreenaObszaru != null && btnUsunZaznaczenieObszaru != null)
                {
                    btnZapiszScreenaObszaru.Dispose();
                    btnUsunZaznaczenieObszaru.Dispose();
                }

                toolTip1.Hide(this);

                //rect.Location = new Point((e.X - PunktStartowyPrzesuwania.X) + rect.Left, (e.Y - PunktStartowyPrzesuwania.Y) + rect.Top);

                //blokowanie zaznaczenia aby nie wychodziło po za obszar ekranu
                Point tempPoint = new Point((e.X - PunktStartowyPrzesuwania.X) + rect.Left, (e.Y - PunktStartowyPrzesuwania.Y) + rect.Top);

                if (tempPoint.Y > 0 && tempPoint.X > 0 && tempPoint.X + rect.Width < this.Width && tempPoint.Y + rect.Height < this.Height)
                {
                    rect.Location = new Point((e.X - PunktStartowyPrzesuwania.X) + rect.Left, (e.Y - PunktStartowyPrzesuwania.Y) + rect.Top);
                    
                }

                PunktStartowyPrzesuwania = e.Location;
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
                    
                    //tt.Show("Aby przesunąć zaznaczenie naciśnij prawy przycisk myszy", this, MousePosition, 3000);

                   
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
                btnZapiszScreenaObszaru = new Button();
                btnZapiszScreenaObszaru.Location = new Point(rect.X + rect.Width - 55, rect.Y + rect.Height + 5);
                string sourceAcceptImage = @"C:\Users\Win7\Documents\Visual Studio 2013\Projects\DrawingRectanglesOnForm\DrawingRectanglesOnForm\Images\accept2.png";
                btnZapiszScreenaObszaru.Image = Image.FromFile(sourceAcceptImage);
                btnZapiszScreenaObszaru.Width = 27;
                btnZapiszScreenaObszaru.Height = 27;
                btnZapiszScreenaObszaru.Click += btnZapiszScreenaObszaru_Click;

                btnUsunZaznaczenieObszaru = new Button();
                btnUsunZaznaczenieObszaru.Location = new Point(btnZapiszScreenaObszaru.Location.X + btnZapiszScreenaObszaru.Width, btnZapiszScreenaObszaru.Location.Y);
                string sourceDeleteImage = @"C:\Users\Win7\Documents\Visual Studio 2013\Projects\DrawingRectanglesOnForm\DrawingRectanglesOnForm\Images\decline3.png";
                btnUsunZaznaczenieObszaru.Image = Image.FromFile(sourceDeleteImage);
                btnUsunZaznaczenieObszaru.Width = 27;
                btnUsunZaznaczenieObszaru.Height = 27;
                btnUsunZaznaczenieObszaru.Click += btnUsunZaznaczenieObszaru_Click;

                this.Controls.Add(btnZapiszScreenaObszaru);
                this.Controls.Add(btnUsunZaznaczenieObszaru);
            }
        }

        //event handler buttonów obszaru zaznaczenia
        void btnUsunZaznaczenieObszaru_Click(object sender, EventArgs e)
        {
            if (btnZapiszScreenaObszaru != null && btnUsunZaznaczenieObszaru != null)
            {
                btnZapiszScreenaObszaru.Dispose();
                btnUsunZaznaczenieObszaru.Dispose();
            }

            rect = new Rectangle(0, 0, 0, 0);
            this.Invalidate();
        }

        //event handler buttonów obszaru zaznaczenia
        void btnZapiszScreenaObszaru_Click(object sender, EventArgs e)
        {
            if (punktPoczatkowyKursora != null && punkGdzieAktualnieZnajdujeSieKurosor != null)
            {
                screenshotObject = new Screenshot();
                Bitmap screen = screenshotObject.ZróbScreenaCzęściEkranu(punktPoczatkowyKursora.X, punktPoczatkowyKursora.Y,
                     punkGdzieAktualnieZnajdujeSieKurosor.X, punkGdzieAktualnieZnajdujeSieKurosor.Y, rect);

                toolTip1.Hide(this);
                toolTip1.Active = false;


                screenshotObject.ZapiszScreena(screen);

                this.Close();
            }
        }

        private void Tło_Paint(object sender, PaintEventArgs e)
        {
            using (Pen p = new Pen(Color.Red, 1))
            {
                e.Graphics.DrawRectangle(p, rect);
            }

            //przyciemnienie okna
            using (Brush b = new SolidBrush(Color.FromArgb(150, 0, 0, 0)))
            {
                Rectangle lewyObszarZaciemnienia = new Rectangle(0, 0, rect.X, this.Height);
                Rectangle prawyObszarZaciemnienia = new Rectangle(rect.X + rect.Width +1, 0, this.Width - lewyObszarZaciemnienia.Width, this.Height);
                Rectangle dolnyObszarZaciemnienia = new Rectangle(rect.X, rect.Y + rect.Height+1, rect.Width, this.Height - (rect.Y + rect.Height));
                Rectangle górnyObszarZaciemnienia = new Rectangle(rect.X, 0, rect.Width, this.Height - rect.Height - dolnyObszarZaciemnienia.Height);

                e.Graphics.FillRectangle(b, lewyObszarZaciemnienia);
                e.Graphics.FillRectangle(b, prawyObszarZaciemnienia);
                e.Graphics.FillRectangle(b, dolnyObszarZaciemnienia);
                e.Graphics.FillRectangle(b, górnyObszarZaciemnienia);

                //uzupelnienienie 1px
                Rectangle górneUzupelnienie = new Rectangle(rect.X + rect.Width, 0, 1, this.Height - rect.Height - dolnyObszarZaciemnienia.Height);
                Rectangle dolneUzupelnienie = new Rectangle(rect.X + rect.Width, rect.Y + rect.Height, 1, this.Height - (rect.Y + rect.Height));

                e.Graphics.FillRectangle(b, górneUzupelnienie);
                e.Graphics.FillRectangle(b, dolneUzupelnienie);
            }
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
                    screenshotObject = new Screenshot();
                    Bitmap screen = screenshotObject.ZróbScreenaCzęściEkranu(punktPoczatkowyKursora.X, punktPoczatkowyKursora.Y,
                         punkGdzieAktualnieZnajdujeSieKurosor.X, punkGdzieAktualnieZnajdujeSieKurosor.Y, rect);

                    toolTip1.Hide(this);
                    toolTip1.Active = false;
                    

                    screenshotObject.ZapiszScreena(screen);

                    this.Close();
                }
            }


        }

        private void Tło_MouseEnter(object sender, EventArgs e)
        {

        }
    }
}
