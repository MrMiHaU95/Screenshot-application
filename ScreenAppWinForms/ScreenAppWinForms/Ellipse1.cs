using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenAppWinForms
{
    class Ellipse1:Shape
    {
        private Pen ellipsePen;

        public Pen EllipsePen
        {
            get { return ellipsePen; }
            set { ellipsePen = value; }
        }
        private Point startPosition;

        public Point StartPosition
        {
            get { return startPosition; }
            set { startPosition = value; }
        }
        private Point endposition;

        public Point Endposition
        {
            get { return endposition; }
            set { endposition = value; }
        }
        private int width;

        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        private int height;

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public Ellipse1()
        {
            id = 3;
        }
    }
}
