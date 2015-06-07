using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenAppWinForms
{
    class Line
    {
        private Pen linePen;

        public Pen LinePen
        {
            get { return linePen; }
            set { linePen = value; }
        }
        private Point startPoint;

        public Point StartPoint
        {
            get { return startPoint; }
            set { startPoint = value; }
        }
        private Point endPoint;

        public Point EndPoint
        {
            get { return endPoint; }
            set { endPoint = value; }
        }

        public Line(Pen linePen,Point startPoint,Point endPoint)
        {
            LinePen = linePen;
            StartPoint = startPoint;
            EndPoint = endPoint;
        }
    }
}
