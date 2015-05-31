using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenAppWinForms
{
    static class UserSelectionHelper
    {
        private static Rectangle userSelection;
        private static Point startUpCursorPosition;
        private static Point currentCursorPosition;
        private static Point startUpMoveSelectionCursorPosition;
        private static bool selectionDrawn;

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

        public static void SetMoveSelectionCursorPosition(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.X > UserSelection.X && e.X < UserSelection.X + UserSelection.Width && e.Y > UserSelection.Y && e.Y < UserSelection.Y + UserSelection.Height)
            {
                startUpMoveSelectionCursorPosition = e.Location;
            }
        }
    }
}
