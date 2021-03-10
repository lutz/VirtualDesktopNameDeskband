using System.Windows.Forms;
using VirtualDesktop;

namespace VirtualDesktopNameDeskband
{
    public partial class DeskbandControl : UserControl
    {
        private readonly GlobalKeyboardHook globalKeyboardHook;

        public DeskbandControl()
        {
            InitializeComponent();

            globalKeyboardHook = new GlobalKeyboardHook(new Keys[] { Keys.D, Keys.Left, Keys.Right, Keys.F4, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9 });
            globalKeyboardHook.KeyboardPressed += GlobalKeyboardHook_KeyboardPressed;

            lblDesktopName.Text = Desktop.DesktopNameFromDesktop(Desktop.Current);
        }

        private void GlobalKeyboardHook_KeyboardPressed(object sender, GlobalKeyboardHookEventArgs e)
        {
            if (e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyUp && Keyboard.IsKeyDown(Keys.LControlKey))
            {
                if (Keyboard.IsKeyDown(Keys.LWin))
                {
                    lblDesktopName.Text = Desktop.DesktopNameFromDesktop(Desktop.Current);
                }
                else
                {
                    switch (e.KeyboardData.Key)
                    {
                        case Keys.D1: SwitchTo(0); break;
                        case Keys.D2: SwitchTo(1); break;
                        case Keys.D3: SwitchTo(2); break;
                        case Keys.D4: SwitchTo(3); break;
                        case Keys.D5: SwitchTo(4); break;
                        case Keys.D6: SwitchTo(5); break;
                        case Keys.D7: SwitchTo(6); break;
                        case Keys.D8: SwitchTo(7); break;
                        case Keys.D9: SwitchTo(8); break;
                    }

                    lblDesktopName.Text = Desktop.DesktopNameFromDesktop(Desktop.Current);
                }
            }
        }


        private void SwitchTo(int index)
        {
            if (index < 0)
            {
                Desktop.FromIndex(0)?.MakeVisible();
                return;
            }

            if (index >= Desktop.Count)
            {
                Desktop.FromIndex(Desktop.Count - 1)?.MakeVisible();
                return;
            }

            Desktop.FromIndex(index)?.MakeVisible();
        }

        internal void Close()
        {
            globalKeyboardHook.KeyboardPressed -= GlobalKeyboardHook_KeyboardPressed;
            globalKeyboardHook.Dispose();
        }

    }
}
