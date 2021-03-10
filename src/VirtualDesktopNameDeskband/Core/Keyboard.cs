using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace VirtualDesktopNameDeskband
{
    internal class Keyboard
    {
        #region User32.dll

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern short GetKeyState(int keyCode);

        private const int KEY_PRESSED = 0x8000;

        #endregion

        public static bool IsKeyDown(Keys key)
        {
            return Convert.ToBoolean(GetKeyState((int)key) & KEY_PRESSED);
        }
    }
}
