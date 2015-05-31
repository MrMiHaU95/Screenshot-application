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
    public partial class Background : Form
    {
        private bool ToolTipShown;

        public Background()
        {
            InitializeComponent();
            //podwójne buforowanie zmiejsza migotanie rysowanych obiektów tooltipów itd
            this.DoubleBuffered = true;

            //ustawia pole klasy statycznej na obiekt tej klasy
            ButtonsHelper.SetBackgroundObject(this);
        }

        //rysowanie obszaru screena
        private void Background_MouseDown(object sender, MouseEventArgs e)
        {
            UserSelectionHelper.StartUpCursorPosition = e.Location;
            ButtonsHelper.DisposeButtons();
            UserSelectionHelper.SetMoveSelectionCursorPosition(e);

            this.Invalidate();
        }

        private void Background_MouseMove(object sender, MouseEventArgs e)
        {
            //rysowanie zaznaczenia
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                UserSelectionHelper.CurrentCursorPosition = e.Location;
                UserSelectionHelper.DrawSelection();
                UserSelectionHelper.SelectionDrawn = true;
                Cursor.Current = Cursors.SizeNWSE;

                this.Invalidate();
            }
                //przesuwanie zaznaczenia
            //nie zmieniać kolejności bo przestanie działać
            if (UserSelectionHelper.CheckIfCursorIsInsideOfUserSelectionAndMouseButtonRightIsPressed(e))
            {
                ButtonsHelper.DisposeButtons();
                toolTip1.Hide(this);
                UserSelectionHelper.DontAllowUserSelectionToGoOutsideOfScreenBounds(e, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                ButtonsHelper.CheckIfButtonsOffScreen(UserSelectionHelper.UserSelection, Screen.PrimaryScreen.Bounds.Height);
                UserSelectionHelper.StartUpMoveSelectionCursorPosition = e.Location;
                this.Invalidate();
            }
                //zmiana kursora na krzyzyk gdy kursor jest w obszarze zaznaczenia 
            else if (UserSelectionHelper.CheckIfCursorIsInsideOfUserSelection(e))
            {
                Cursor.Current = Cursors.SizeAll;

                //tooltip
                if (!ToolTipShown)
                {
                    Point tempPoint = new Point(e.X, e.Y - 50);
                    toolTip1.Show("naciśnij i przytrzymaj prawy przycisk myszy i przesun mysz aby utworzyć zaznaczenie", this, e.X, e.Y);
                    ToolTipShown = true;
                }
            }
        }

        //dodawanie przycisków do obszarów zaznaczenia
        private void Background_MouseUp(object sender, MouseEventArgs e)
        {
            if (UserSelectionHelper.SelectionDrawn)
            {
                ButtonsHelper.DrawAndMoveButtons(UserSelectionHelper.UserSelection);
            }
        }

        //paint event
        private void Background_Paint(object sender, PaintEventArgs e)
        {
            using (Pen p = new Pen(Color.Red, 1))
            {
                //rysowanie zaznaczenia
                e.Graphics.DrawRectangle(p, UserSelectionHelper.UserSelection);
            }
            //przyciemnienie okna
            BackgroundHelper.AddTransparentBlackColor(e, UserSelectionHelper.UserSelection, Screen.PrimaryScreen.Bounds.Height, Screen.PrimaryScreen.Bounds.Width);
        }

        //zamknięcie tego trybu ESC
        private void Background_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                UserSelectionHelper.ResetUserSelection();
                this.Close();
            }
            //zapis screena do pliku
            if (e.KeyCode == Keys.Enter)
            {
                if (UserSelectionHelper.StartUpCursorPosition != null && UserSelectionHelper.CurrentCursorPosition != null)
                {
                    //ukrywanie tooltipa
                    toolTip1.Hide(this);
                    toolTip1.Active = false;

                    Bitmap screen = ScreenshotHelper.TakeScreenshotOfUserSelection(UserSelectionHelper.UserSelection);
                    ScreenshotHelper.SaveScreenshot(screen);

                    if (InfoAboutScreenshot.DidUserSavedScreenshot)
                    {
                        NotifyIconHelper.ShowBallonTip();
                    }
                    this.Close();
                }
            }
        }
    }
}
