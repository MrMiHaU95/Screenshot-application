using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenAppWinForms
{
    /// <summary>
    /// prosta klasa statyczna zawierające informacje o screenie, nazwę oraz ścieżkę do pliku
    /// </summary>
    static class InfoAboutScreenshot
    {
        private static string fileName;
        private static string folderPath;

        public static string FileName
        {
            get
            {
                return fileName;
            }
            set
            {
                fileName = value;
            }
        }

        public static string FolderPath
        {
            get
            {
                return folderPath;
            }
            set
            {
                folderPath = value;
            }
        }
    }
}
