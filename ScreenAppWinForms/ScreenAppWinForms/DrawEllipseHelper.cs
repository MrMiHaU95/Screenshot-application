using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenAppWinForms
{
    static class DrawEllipseHelper
    {
        private static bool canDrawEllipse;

        public static bool CanDrawEllipse
        {
            get { return DrawEllipseHelper.canDrawEllipse; }
            set { DrawEllipseHelper.canDrawEllipse = value; }
        }
    }
}
