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
        #region prywatne pola
        private static string fileName;
        private static string folderPath;
        private static bool czyUserZapisalScreena;
        #endregion
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result">Parametr uzyskany z ofd.ShowDialog opisuje interakcje usera z okienkiem czy anulował zapis czy zapisał itd... </param>
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

        /// <summary>
        /// Metoda czyszcząca pola klasy InfoAboutScreenshot przed przypisaniem nowych danych pola są czyszczone
        /// </summary>
        public static void WyczyscDane()
        {
            InfoAboutScreenshot.CzyUserZapisalScreena = false;
            InfoAboutScreenshot.FileName = "";
            InfoAboutScreenshot.FolderPath = "";
        }
    }
}
