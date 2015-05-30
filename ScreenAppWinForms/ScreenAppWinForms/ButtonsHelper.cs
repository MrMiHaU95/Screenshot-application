using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenAppWinForms
{
    static class ButtonsHelper
    {
        private static Button btnSaveSelectedArea;
        private static Button btnDeleteSelectedArea;
        private static bool buttonsOfScreen;
        private static Tło background;

        public static Button BtnSaveSelectedArea
        {
            get
            {
                return btnSaveSelectedArea;
            }
            private set
            {
                btnSaveSelectedArea = value;
            }
        }

        public static Button BtnDeleteSelectedArea
        {
            get
            {
                return btnDeleteSelectedArea;
            }
            set
            {
                btnDeleteSelectedArea = value;
            }
        }

        public static bool ButtonsOfScreen
        {
            get
            {
                return buttonsOfScreen;
            }
            private set
            {
                buttonsOfScreen = value;
            }
        }

        private static Tło Background
        {
            get
            {
                return background;
            }
            set
            {
                background = value;
            }
        }

        //usuwa buttony ze aby je przesunąć nie powodując migotania (flickering)
        public static void HideButtons()
        {
            if (btnSaveSelectedArea != null && btnSaveSelectedArea != null)
            {
                //jak nie działą to Dispose();
                btnSaveSelectedArea.Visible = false;
                btnSaveSelectedArea.Visible = false;
            }
        }
        /// <summary>
        /// Metoda sprawdzająca czy przyciski sa po za ekranem
        /// </summary>
        /// <param name="selectedArea">obiekt klasy Rectangle odpowiadający zaznaczeniu narysowanemu przez usera</param>
        /// <param name="primaryScreenHeight">wysokość ekranu usera</param>
        public static void CheckIfButtonsOffScreen(Rectangle selectedArea, int primaryScreenHeight)
        {
            Point tempPoint = new Point(selectedArea.X + selectedArea.Width, selectedArea.Y + selectedArea.Height);
            const int buttonHeightAndMargin = 35;
            if (tempPoint.Y + buttonHeightAndMargin > primaryScreenHeight)
            {
                ButtonsOfScreen = true;
            }
            else
            {
                ButtonsOfScreen = false;
            }
        }

        public static void MoveButtons(Rectangle selectedArea)
        {

            if (BtnSaveSelectedArea != null && BtnDeleteSelectedArea != null)
            {
                const int minusX = 55;
                const int minusYOffScreen = 30;
                const int plusOnScreen = 5;
                if (ButtonsOfScreen)
                {
                    BtnSaveSelectedArea.Location = new Point(selectedArea.X + selectedArea.Width - minusX, selectedArea.Y - minusYOffScreen);
                    BtnDeleteSelectedArea.Location = new Point(BtnSaveSelectedArea.Location.X + BtnSaveSelectedArea.Width, BtnSaveSelectedArea.Location.Y);
                    SetButtonsVisibleToTrue();
                }
                else
                {
                    BtnSaveSelectedArea.Location = new Point(selectedArea.X + selectedArea.Width - minusX, selectedArea.Y + selectedArea.Height + plusOnScreen);
                    BtnDeleteSelectedArea.Location = new Point(BtnSaveSelectedArea.Location.X + BtnSaveSelectedArea.Width, BtnSaveSelectedArea.Location.Y);
                    SetButtonsVisibleToTrue();
                }
            }
            else
            {
                BtnSaveSelectedArea = new Button();
                BtnDeleteSelectedArea = new Button();

                string sourceAcceptImage = @"C:\Users\Win7\Documents\Visual Studio 2013\Projects\DrawingRectanglesOnForm\DrawingRectanglesOnForm\Images\accept2.png";
                BtnSaveSelectedArea.Image = Image.FromFile(sourceAcceptImage);
                BtnSaveSelectedArea.Width = 27;
                BtnSaveSelectedArea.Height = 27;
                BtnSaveSelectedArea.Click += btnZapiszScreenaObszaru_Click;

                BtnDeleteSelectedArea.Location = new Point(BtnSaveSelectedArea.Location.X + BtnSaveSelectedArea.Width, BtnSaveSelectedArea.Location.Y);
                string sourceDeleteImage = @"C:\Users\Win7\Documents\Visual Studio 2013\Projects\DrawingRectanglesOnForm\DrawingRectanglesOnForm\Images\decline3.png";
                BtnDeleteSelectedArea.Image = Image.FromFile(sourceDeleteImage);
                BtnDeleteSelectedArea.Width = 27;
                BtnDeleteSelectedArea.Height = 27;
                BtnDeleteSelectedArea.Click += btnUsunZaznaczenieObszaru_Click;
                SetButtonsVisibleToTrue();
                Background.Controls.Add(BtnSaveSelectedArea);
                Background.Controls.Add(BtnDeleteSelectedArea);
            }
        }

        //event handler buttonów obszaru zaznaczenia
        static void btnUsunZaznaczenieObszaru_Click(object sender, EventArgs e)
        {
            SetButtonsVisibleToTrue();
            Background.rect = new Rectangle(0, 0, 0, 0);
            Background.Invalidate();
        }

        static void btnZapiszScreenaObszaru_Click(object sender, EventArgs e)
        {
            //if (punktPoczatkowyKursora != null && punkGdzieAktualnieZnajdujeSieKurosor != null)
            //{
                Background.screenshotObject = new Screenshot();
                Bitmap screen = Background.screenshotObject.ZróbScreenaCzęściEkranu(Background.rect);

                Background.toolTip1.Hide(Background);
                Background.toolTip1.Active = false;
                Background.screenshotObject.ZapiszScreena(screen);
            //pokazywanie ballon tipa
                if (InfoAboutScreenshot.CzyUserZapisalScreena)
                {
                    NotifyIconHelper.ShowBallonTip();
                }
                Background.Close();
            //}
        }

        public static void SetButtonsVisibleToTrue()
        {
            BtnSaveSelectedArea.Visible = true;
            BtnDeleteSelectedArea.Visible = true;
        }

        //ustawia wartość pola klasy Tło
        public static void SetBackgroundObject(Tło tlo)
        {
            Background = tlo;
        }
            
    }
}
