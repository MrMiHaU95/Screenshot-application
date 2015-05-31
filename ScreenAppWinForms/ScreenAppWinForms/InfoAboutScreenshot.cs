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
        private static bool didUserSavedScreenshot;
        #endregion
        #region właściwości
        public static bool DidUserSavedScreenshot
        {
            get
            {
                return didUserSavedScreenshot;
            }
            set
            {
                didUserSavedScreenshot = value;
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
        /// metoda sprawdzająca czy user zapisał screena (potrzebne do wyświetlania tooltipa)
        /// </summary>
        /// <param name="result">Parametr uzyskany z ofd.ShowDialog opisuje interakcje usera z okienkiem czy anulował zapis czy zapisał itd... </param>
        public static void CheckIfUserSavedScreenshot(DialogResult result)
        {
            if(result != DialogResult.Cancel && result != DialogResult.Abort)
            {
                InfoAboutScreenshot.DidUserSavedScreenshot = true;
            }
            else
            {
                InfoAboutScreenshot.DidUserSavedScreenshot = false;
            }
        }

        /// <summary>
        /// Metoda czyszcząca pola klasy InfoAboutScreenshot przed przypisaniem nowych danych pola są czyszczone
        /// </summary>
        public static void ClearFieldsData()
        {
            InfoAboutScreenshot.DidUserSavedScreenshot = false;
            InfoAboutScreenshot.FileName = "";
            InfoAboutScreenshot.FolderPath = "";
        }
    }
}
