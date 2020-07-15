using System;
using System.Windows;
using System.Windows.Controls;
using VirtualDesktop;
using FormsKeys = System.Windows.Forms.Keys;

namespace VirtualDesktopNameDeskband
{
    public partial class DeskbandView : UserControl
    {
        // Events

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);
            SetHeightTo100Percent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            SetHeightTo100Percent();
        }

        // Fields

        readonly GlobalKeyboardHook globalKeyboardHook;

        // Constructors

        public DeskbandView()
        {
            InitializeComponent();

            globalKeyboardHook = new GlobalKeyboardHook(new FormsKeys[] { FormsKeys.D, FormsKeys.Left, FormsKeys.Right, FormsKeys.F4, FormsKeys.D1, FormsKeys.D2, FormsKeys.D3, FormsKeys.D4, FormsKeys.D5, FormsKeys.D6, FormsKeys.D7, FormsKeys.D8, FormsKeys.D9, FormsKeys.R, FormsKeys.T });
            globalKeyboardHook.KeyboardPressed += GlobalKeyboardHook_KeyboardPressed;

            txtBlock.Text = Desktop.DesktopNameFromDesktop(Desktop.Current);
        }

        // EventHandlers

        void GlobalKeyboardHook_KeyboardPressed(object sender, GlobalKeyboardHookEventArgs e)
        {
            if (e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyUp && Keyboard.IsKeyDown(FormsKeys.LControlKey))
            {
                if (Keyboard.IsKeyDown(FormsKeys.LWin))
                {
                    switch (e.KeyboardData.Key)
                    {
                        case FormsKeys.T: ((Action)(() => MoveCurrentWindow(Direction.Left))).IgnoreException(); break;
                        case FormsKeys.R: ((Action)(() => MoveCurrentWindow(Direction.Right))).IgnoreException(); break;
                    }

                    txtBlock.Text = Desktop.DesktopNameFromDesktop(Desktop.Current);
                }
                else
                {
                    switch (e.KeyboardData.Key)
                    {
                        case FormsKeys.D1: SwitchTo(0); break;
                        case FormsKeys.D2: SwitchTo(1); break;
                        case FormsKeys.D3: SwitchTo(2); break;
                        case FormsKeys.D4: SwitchTo(3); break;
                        case FormsKeys.D5: SwitchTo(4); break;
                        case FormsKeys.D6: SwitchTo(5); break;
                        case FormsKeys.D7: SwitchTo(6); break;
                        case FormsKeys.D8: SwitchTo(7); break;
                        case FormsKeys.D9: SwitchTo(8); break;
                    }

                    txtBlock.Text = Desktop.DesktopNameFromDesktop(Desktop.Current);
                }
            }
        }

        // Methods

        void MoveCurrentWindow(Direction direction)
        {
            if (direction == Direction.Left)
            {
                Desktop.Current?.Left?.MoveActiveWindow();
                Desktop.Current?.Left?.MakeVisible();
            }
            else
            {
                Desktop.Current?.Right?.MoveActiveWindow();
                Desktop.Current?.Right?.MakeVisible();
            }
        }

        void SwitchTo(int index)
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

        void SetHeightTo100Percent() => Height = SystemParameters.PrimaryScreenHeight - SystemParameters.WorkArea.Height;
    }
}
