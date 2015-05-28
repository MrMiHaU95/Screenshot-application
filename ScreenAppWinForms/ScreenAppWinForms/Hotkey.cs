using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace registerHotkey
{
    class Hotkey
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private readonly IntPtr _hwnd;

        public Hotkey(IntPtr hwnd)
        {
            _hwnd = hwnd;
        }

        public enum WindowKeys
        {
            None = 0x000,
            Alt = 0x0001,
            Control = 0x0002,
            Shift = 0x0004,
            Window = 0x0008,
        }

        public void RegisterHotKeys()
        {
            RegisterHotKey(_hwnd, 1, (int)WindowKeys.None, (uint)Keys.F10);
            RegisterHotKey(_hwnd, 2,(int)WindowKeys.None, (uint)Keys.F11);
        }

        public void UnregisterHotKeys()
        {
            UnregisterHotKey(_hwnd, 1);
            UnregisterHotKey(_hwnd, 2);
        }
    }
}
