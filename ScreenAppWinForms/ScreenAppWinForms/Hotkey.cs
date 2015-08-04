using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ScreenAppWinForms;

namespace registerHotkey
{
    /// <summary>
    /// klasa do rejestrowania i wyrejestrowania globalnych skrótów klawiszowych klasa wykorzystuje WindowsAPI
    /// </summary>
    class Hotkey
    {

        /// <summary>
        /// window handle 
        /// </summary>
        public readonly IntPtr _hwnd;

        #region deklaracje metod windows API 
        /// <summary>
        /// metoda służąca do rejestrowania skrótów klawiszowych
        /// </summary>
        /// <param name="hWnd">window handle uchwyt do okna do którego mają zostać przypisane skróty</param>
        /// <param name="id">id skrótu po id można odróżnić skróty dla pierwszego skrótu 1 dla drugiego 2 itd</param>
        /// <param name="fsModifiers">jeśli chcesz aby user musiał wcisnąć jeszce dodatkowo np ctrl to podaj wartość z enuma odpowiadającą danemu przyciskowi</param>
        /// <param name="vk">klawisz do którego zostaje przypisany skrót</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        /// <summary>
        /// metoda służąca do wyrejestrowywania skrótów 
        /// </summary>
        /// <param name="hWnd">window handle uchwyt okna do jakiego przypisany jest dany skrót</param>
        /// <param name="id">id skrótu do wyrejestrowania</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        #endregion

        /// <summary>
        /// w konstruktorze trzeba podać uchwy okna do którego mają zostać przypisane skróty
        /// </summary>
        /// <param name="hwnd">window handle</param>
        public Hotkey(IntPtr hwnd)
        {
            _hwnd = hwnd;
            SettingsHelper.WindowHandle = hwnd;
        }
        

        /// <summary>
        /// enum dla podstawowych klawiszy takich jak alt ctrl shift itd
        /// </summary>
        public enum WindowKeys
        {
            None = 0x000,
            Alt = 0x0001,
            Control = 0x0002,
            Shift = 0x0004,
            Window = 0x0008,
        }

        /// <summary>
        /// metoda rejestrująca wszystkie skróty dla aplikacji
        /// </summary>
        public void RegisterHotKeys()
        {
            KeysConverter converter = new KeysConverter();
            SettingsHelper.InitializeShortucts();
            RegisterHotKey(_hwnd, 1, (int)WindowKeys.None, SettingsHelper.CaptureScreenShortcut);
            RegisterHotKey(_hwnd, 2, (int)WindowKeys.None, SettingsHelper.CaptureAreaShortcut);
            RegisterHotKey(_hwnd, 3, (int)WindowKeys.None, SettingsHelper.CapureScreenUploadShortcut);
            //RegisterHotKey(_hwnd, 1, (int)WindowKeys.None, (uint)Keys.F10 );
            //RegisterHotKey(_hwnd, 1, (int)WindowKeys.None, (uint)Keys.F11);
            //RegisterHotKey(_hwnd, 1, (int)WindowKeys.None, (uint)Keys.F9);
        }

        /// <summary>
        /// metoda powinna zostać dodana do eventu Form_Closed wyrejestrowuje skróty dla aplikacji
        /// </summary>
        public void UnregisterHotKeys()
        {
            UnregisterHotKey(_hwnd, 1);
            UnregisterHotKey(_hwnd, 2);
            UnregisterHotKey(_hwnd, 3);
        }

        /// <summary>
        /// rejestrowanie nowego skrótu 
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="id"></param>
        /// <param name="fsModifiers"></param>
        /// <param name="vk"></param>
        public static void RegisterNewHotkey(IntPtr hWnd, int id, uint fsModifiers, uint vk)
        {
            RegisterHotKey(hWnd, id, fsModifiers, vk);
        }
        /// <summary>
        /// usuwanie starego skrótu
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="id"></param>
        public static void UnregisterOldHotkey(IntPtr hWnd, int id)
        {
            UnregisterHotKey(hWnd, id);
        }
        }
}
