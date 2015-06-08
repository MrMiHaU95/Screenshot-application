using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenAppWinForms
{
    class Rectangle1:Shape
    {
        private Point startPosition;

        public Point StartPosition
        {
            get { return startPosition; }
            set { startPosition = value; }
        }
        private Point currentPosition;

        public Point CurrentPosition
        {
            get { return currentPosition; }
            set { currentPosition = value; }
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
        private Pen rectPen;

        public Pen RectPen
        {
            get { return rectPen; }
            set { rectPen = value; }
        }

        public Rectangle1()
        {
            id = 2;
        }

        
    }
}
