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
    /// klasa statyczna zawiera jedną metodę do dodawania przezroczystego koloru aby odróżnić tryb pracy programu
    /// </summary>
    static class BackgroundHelper
    {
        /// <summary>
        /// metoda dodająca półprzezroczysty kolor
        /// </summary>
        /// <param name="e">obiekt klasy PaintEventArgs dodany z event Form_Paint() który jest często wywoływany gdy tylko trzeba narysować okienko od nowa</param>
        /// <param name="selectedArea">obiekt klasy Rectangle odpowiadający zaznaczeniu narysowanemu przez usera</param>
        /// <param name="PrimaryScreenHeight">wysokość ekranu usera</param>
        /// <param name="PrimaryScreenWidth">szerokość ekranu usera</param>
        public static void AddTransparentBlackColor(PaintEventArgs e,Rectangle selectedArea,int PrimaryScreenHeight, int PrimaryScreenWidth)
        {
            const int alfaChannel = 125;
            const int red = 0;
            const int green = 0;
            const int blue = 0;
            using (Brush b = new SolidBrush(Color.FromArgb(alfaChannel, red, green, blue)))
            {
                Rectangle leftArea = new Rectangle(0, 0, selectedArea.X, PrimaryScreenHeight);
                Rectangle rightArea = new Rectangle(selectedArea.X + selectedArea.Width + 1, 0, PrimaryScreenWidth - leftArea.Width, PrimaryScreenHeight);
                Rectangle lowerArea = new Rectangle(selectedArea.X, selectedArea.Y + selectedArea.Height + 1, selectedArea.Width, PrimaryScreenHeight - (selectedArea.Y + selectedArea.Height));
                Rectangle UpperArea = new Rectangle(selectedArea.X, 0, selectedArea.Width, PrimaryScreenHeight - selectedArea.Height - lowerArea.Height);
                //uzupelnienienie 1px
                Rectangle upperOnePx = new Rectangle(selectedArea.X + selectedArea.Width, 0, 1, PrimaryScreenHeight - selectedArea.Height - lowerArea.Height);
                Rectangle lowerOnePx = new Rectangle(selectedArea.X + selectedArea.Width, selectedArea.Y + selectedArea.Height, 1, PrimaryScreenHeight - (selectedArea.Y + selectedArea.Height));

                e.Graphics.FillRectangle(b, leftArea);
                e.Graphics.FillRectangle(b, rightArea);
                e.Graphics.FillRectangle(b, lowerArea);
                e.Graphics.FillRectangle(b, UpperArea);
                e.Graphics.FillRectangle(b, upperOnePx);
                e.Graphics.FillRectangle(b, lowerOnePx);
            }
        }
    }
}
