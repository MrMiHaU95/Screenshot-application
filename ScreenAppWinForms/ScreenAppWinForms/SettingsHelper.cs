using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenAppWinForms
{
    public static class SettingsHelper
    {
        private static string currentLanguage;

        public static string CurrentLanguage
        {
            get { return SettingsHelper.currentLanguage; }
            set { SettingsHelper.currentLanguage = value; }
        }
    }
}
