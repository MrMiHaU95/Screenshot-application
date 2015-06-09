using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenAppWinForms
{
    static class PenToolHelper
    {
        private static bool canUsePenTool;

        public static bool CanUsePenTool
        {
            get { return PenToolHelper.canUsePenTool; }
            set { PenToolHelper.canUsePenTool = value; }
        }
    }
}
