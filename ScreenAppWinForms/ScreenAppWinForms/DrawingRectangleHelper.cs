using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenAppWinForms
{
    static class DrawingRectangleHelper
    {
        private static bool canDrawRectangle;

        public static bool CanDrawRectangle
        {
            get { return DrawingRectangleHelper.canDrawRectangle; }
            set { DrawingRectangleHelper.canDrawRectangle = value; }
        }
    }
}
