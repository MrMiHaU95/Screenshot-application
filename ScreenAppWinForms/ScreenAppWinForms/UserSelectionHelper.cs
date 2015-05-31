using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenAppWinForms
{
    /// <summary>
    /// Klasa pomagająca zawiera metody do rysowania zaznaczenia i jego przesuwania 
    /// </summary>
    static class UserSelectionHelper
    {
        #region prywatne pola klasy
        private static Rectangle userSelection;
        private static Point startUpCursorPosition;
        private static Point currentCursorPosition;
        private static Point startUpMoveSelectionCursorPosition;
        private static bool selectionDrawn;

        #endregion
        #region właściwości
        public static Rectangle UserSelection
        {
            get { return UserSelectionHelper.userSelection; }
            set { UserSelectionHelper.userSelection = value; }
        }
        public static Point StartUpCursorPosition
        {
            get { return UserSelectionHelper.startUpCursorPosition; }
            set { UserSelectionHelper.startUpCursorPosition = value; }
        }
        public static Point CurrentCursorPosition
        {
            get { return UserSelectionHelper.currentCursorPosition; }
            set { UserSelectionHelper.currentCursorPosition = value; }
        }
        public static Point StartUpMoveSelectionCursorPosition
        {
            get { return UserSelectionHelper.startUpMoveSelectionCursorPosition; }
            set { UserSelectionHelper.startUpMoveSelectionCursorPosition = value; }
        }
        public static bool SelectionDrawn
        {
            get { return UserSelectionHelper.selectionDrawn; }
            set { UserSelectionHelper.selectionDrawn = value; }
        }
        #endregion
        /// <summary>
        /// ustawienie początkowej pozycji kursora (do rysowania zanaczenia)
        /// </summary>
        /// <param name="e">informacje o evencie służy do odczytania pozycji kursora w momencie wystąpienia eventu<</param>
        public static void SetMoveSelectionCursorPosition(MouseEventArgs e)
        {
            if (CheckIfCursorIsInsideOfUserSelectionAndMouseButtonRightIsPressed(e))
            {
                startUpMoveSelectionCursorPosition = e.Location;
            }
        }

        #region metody
        /// <summary>
        /// obliczanie parametrów nowego obszaru zaznaczenia 
        /// </summary>
        public static void DrawSelection()
        {
            int x = Math.Min(StartUpCursorPosition.X, currentCursorPosition.X);
            int y = Math.Min(StartUpCursorPosition.Y, currentCursorPosition.Y);
            int width = Math.Abs(currentCursorPosition.X - StartUpCursorPosition.X);
            int height = Math.Abs(currentCursorPosition.Y - StartUpCursorPosition.Y);
            userSelection = new Rectangle(x, y, width, height);
        }
        /// <summary>
        /// sprawdza czy kursor znajduje się wewnątrz zaznaczenia (zmiana kursora na krzyżyk)
        /// </summary>
        /// <param name="e">informacje o evencie służy do odczytania pozycji kursora w momencie wystąpienia eventu</param>
        /// <returns></returns>
        public static bool CheckIfCursorIsInsideOfUserSelection(MouseEventArgs e)
        {
            return e.X > UserSelection.X && e.X < UserSelection.X + UserSelection.Width && e.Y > UserSelection.Y && e.Y < UserSelection.Y + UserSelection.Height;
        }
        /// <summary>
        /// sprawdza czy kursor znajduje się wewnątrz zaznaczenia i czy prawy przycisk myszy jest wciśnięty 
        /// </summary>
        /// <param name="e">informacje o evencie służy do odczytania pozycji kursora w momencie wystąpienia eventu</param>
        /// <returns></returns>
        public static bool CheckIfCursorIsInsideOfUserSelectionAndMouseButtonRightIsPressed(MouseEventArgs e)
        {
            return e.Button == MouseButtons.Right && e.X > UserSelection.X && e.X < UserSelection.X + UserSelection.Width && e.Y > UserSelection.Y && e.Y < UserSelection.Y + UserSelection.Height;
        }
        /// <summary>
        /// nie pozwala na "wyjechanie" zaznaczeniu po za obszar ekranu
        /// </summary>
        /// <param name="e">informacje o evencie służy do odczytania pozycji kursora w momencie wystąpienia eventu</param>
        /// <param name="primaryScreenWidth">szerokość głównego ekranu usera Screen.Primary.Bounds.Width</param>
        /// <param name="primaryScreenHeight">wysokość głównego ekranu usera Screen.Primary.Bounds.Width</param>
        public static void DontAllowUserSelectionToGoOutsideOfScreenBounds(MouseEventArgs e, int primaryScreenWidth,int primaryScreenHeight)
        {
            Point tempPoint = new Point((e.X - StartUpMoveSelectionCursorPosition.X) + UserSelection.Left, (e.Y - StartUpMoveSelectionCursorPosition.Y) + UserSelection.Top);

            if (tempPoint.Y > 0 && tempPoint.X > 0 && tempPoint.X + UserSelection.Width < primaryScreenWidth && tempPoint.Y + UserSelection.Height < primaryScreenHeight)
            {
                userSelection.Location = new Point((e.X - StartUpMoveSelectionCursorPosition.X) + UserSelection.Left, (e.Y - StartUpMoveSelectionCursorPosition.Y) + UserSelection.Top);

            }
        }
        /// <summary>
        /// ustawia wartość 0,0,0,0 dla Rectangle aby po wyłączeniu Background i ponownym włączeniu nie było wyświetlane ostatnie zaznaczenie
        /// </summary>
        public static void ResetUserSelection()
        {
            UserSelection = new Rectangle(0, 0, 0, 0);
        }
        #endregion
    }
}
