﻿using System;
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
        #region prywatne pola klasy
        private static Button btnSaveSelectedArea;
        private static Button btnDeleteSelectedArea;
        private static bool buttonsOfScreen;
        private static Tło background;
        #endregion

        #region właściwości klasy
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
        #endregion

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
        /// <summary>
        /// Przesuwa przyciski wraz z zaznaczeniem, mało wydajny sposób wymagający usuwania i tworzenia na nowo obiektów klasy Button
        /// </summary>
        /// <param name="selectedArea">obiekt klasy Rectangle odpowiadający zaznaczeniu narysowanemu przez usera</param>
        public static void DrawAndMoveButtons(Rectangle selectedArea)
        {
            #region stałe
            const int minusX = 55;
                const int minusYOffScreen = 30;
                const int plusOnScreen = 5;
            #endregion
                BtnSaveSelectedArea = new Button();
                BtnDeleteSelectedArea = new Button();
            //jeśli przyciski po za ekranem to ustawia nową lokalizację w zależności od położenia zaznaczenia
                if (ButtonsOfScreen)
                {
                    BtnSaveSelectedArea.Location = new Point(selectedArea.X + selectedArea.Width - minusX, selectedArea.Y - minusYOffScreen);
                }
                else
                {
                    BtnSaveSelectedArea.Location = new Point(selectedArea.X + selectedArea.Width - minusX, selectedArea.Y + selectedArea.Height + plusOnScreen);
                }

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
                
                Background.Controls.Add(BtnSaveSelectedArea);
                Background.Controls.Add(BtnDeleteSelectedArea);
        }
        #region event handlery buttonów
        //event handler buttonów obszaru zaznaczenia
        static void btnUsunZaznaczenieObszaru_Click(object sender, EventArgs e)
        {
            DisposeButtons();
            Background.rect = new Rectangle(0, 0, 0, 0);
            Background.Invalidate();
        }
        //event handler btn zapiszscreena
        static void btnZapiszScreenaObszaru_Click(object sender, EventArgs e)
        {
                Bitmap screen = ScreenshotHelper.TakeScreenshotOfUserSelection(Background.rect);

                Background.toolTip1.Hide(Background);
                Background.toolTip1.Active = false;
                ScreenshotHelper.SaveScreenshot(screen);
            //pokazywanie ballon tipa
                if (InfoAboutScreenshot.CzyUserZapisalScreena)
                {
                    NotifyIconHelper.ShowBallonTip();
                }
                Background.Close();
        }
        #endregion
        //usuwa przyciski
        public static void DisposeButtons()
        {
            if(BtnSaveSelectedArea != null && BtnDeleteSelectedArea != null)
            {
                BtnDeleteSelectedArea.Dispose();
                BtnSaveSelectedArea.Dispose();
            }
        }

        //ustawia wartość pola klasy pobranie obiektu klasy Tło jest wymagane aby klasa ButtonHelper mogła działać
        public static void SetBackgroundObject(Tło tlo)
        {
            Background = tlo;
        }   
    }
}
