using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenAppWinForms
{
    static class AddTextHelper
    {
        private static bool canAddText;

        public static bool CanAddText
        {
            get { return AddTextHelper.canAddText; }
            set { AddTextHelper.canAddText = value; }
        }

    }
}
