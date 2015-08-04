using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenAppWinForms
{
    public static class SettingsHelper
    {
        private static string currentLanguage;
        private static uint captureScreenShortcut;
        private static uint captureAreaShortcut;
        private static uint capureScreenUploadShortcut;

        private static string captureScreenShortcutText;
        private static string captureAreaShortcutText;
        private static string capureScreenUploadShortcutText;
        private static IntPtr windowHandle;
        #region properties
        public static IntPtr WindowHandle
        {
            get { return SettingsHelper.windowHandle; }
            set { SettingsHelper.windowHandle = value; }
        }
        public static string CapureScreenUploadShortcutText
        {
            get { return SettingsHelper.capureScreenUploadShortcutText; }
            set { SettingsHelper.capureScreenUploadShortcutText = value; }
        }
        public static string CaptureAreaShortcutText
        {
            get { return SettingsHelper.captureAreaShortcutText; }
            set { SettingsHelper.captureAreaShortcutText = value; }
        }
        public static string CaptureScreenShortcutText
        {
            get { return SettingsHelper.captureScreenShortcutText; }
            set { SettingsHelper.captureScreenShortcutText = value; }
        }
        public static string CurrentLanguage
        {
            get { return SettingsHelper.currentLanguage; }
            set { SettingsHelper.currentLanguage = value; }
        }
        public static uint CaptureScreenShortcut
        {
            get { return SettingsHelper.captureScreenShortcut; }
            set { SettingsHelper.captureScreenShortcut = value; }
        }
        public static uint CaptureAreaShortcut
        {
            get { return SettingsHelper.captureAreaShortcut; }
            set { SettingsHelper.captureAreaShortcut = value; }
        }
        public static uint CapureScreenUploadShortcut
        {
            get { return SettingsHelper.capureScreenUploadShortcut; }
            set { SettingsHelper.capureScreenUploadShortcut = value; }
        }
        #endregion

        public static void InitializeShortucts()
        {
            //odczytywanie z pliku xml zeby zachowac skróty a nie po każdym restarcie sa te same
            KeysConverter converter = new KeysConverter();
            captureScreenShortcut = (uint)Keys.F10;
            captureAreaShortcut = (uint)Keys.F11;
            capureScreenUploadShortcut = (uint)Keys.F9;

            captureScreenShortcutText = Convert.ToString(Keys.F10);
            captureAreaShortcutText = Convert.ToString(Keys.F11);
            capureScreenUploadShortcutText = Convert.ToString(Keys.F9);
        }
    }
}
