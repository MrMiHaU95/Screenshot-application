using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenAppWinForms
{
    /// <summary>
    /// prosta klasa statyczna zawierające informacje o screenie, nazwę oraz ścieżkę do pliku
    /// </summary>
    static class InfoAboutScreenshot
    {
        private static string fileName;
        private static string folderPath;
        private static bool czyUserZapisalScreena;

        #region właściwości
        public static bool CzyUserZapisalScreena
        {
            get
            {
                return czyUserZapisalScreena;
            }
            set
            {
                czyUserZapisalScreena = value;
            }
        }

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
        #endregion

        public static void SprawdzCzyUserZapisalScreena(DialogResult result)
        {
            if(result != DialogResult.Cancel && result != DialogResult.Abort)
            {
                InfoAboutScreenshot.CzyUserZapisalScreena = true;
            }
            else
            {
                InfoAboutScreenshot.CzyUserZapisalScreena = false;
            }
        }

        public static void WyczyscDane()
        {
            InfoAboutScreenshot.CzyUserZapisalScreena = false;
            InfoAboutScreenshot.FileName = "";
            InfoAboutScreenshot.FolderPath = "";
        }
    }
}
