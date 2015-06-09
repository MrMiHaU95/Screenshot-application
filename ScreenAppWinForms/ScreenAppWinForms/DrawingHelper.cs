using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenAppWinForms
{
    static class DrawingHelper
    {
        private static bool canDraw;

        public static bool CanDraw
        {
            get { return DrawingHelper.canDraw; }
            set { DrawingHelper.canDraw = value; }
        }

    }
}
