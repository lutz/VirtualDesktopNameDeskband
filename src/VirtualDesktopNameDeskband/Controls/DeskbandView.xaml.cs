using System;
using System.Windows;
using System.Windows.Controls;
using VirtualDesktop;
using FormsKeys = System.Windows.Forms.Keys;

namespace VirtualDesktopNameDeskband
{
    /// <summary>
    /// Interaktionslogik für UserControl1.xaml
    /// </summary>
    public partial class DeskbandView : UserControl
    {
        readonly GlobalKeyboardHook globalKeyboardHook;

        public DeskbandView()
        {
            InitializeComponent();

            globalKeyboardHook = new GlobalKeyboardHook(new FormsKeys[] { FormsKeys.D, FormsKeys.Left, FormsKeys.Right, FormsKeys.F4 });
            globalKeyboardHook.KeyboardPressed += GlobalKeyboardHook_KeyboardPressed;

            txtBlock.Text = Desktop.Current.Name;
        }

        private void GlobalKeyboardHook_KeyboardPressed(object sender, GlobalKeyboardHookEventArgs e)
        {
            if (e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyUp && Keyboard.IsKeyDown(FormsKeys.LControlKey) && Keyboard.IsKeyDown(FormsKeys.LWin))
            {
                switch (e.KeyboardData.Key)
                {
                    case FormsKeys.D:
                    case FormsKeys.F4:
                    case FormsKeys.Left:
                    case FormsKeys.Right:
                        txtBlock.Text = Desktop.Current.Name;
                        break;
                }
            }
        }

        internal void Close()
        {
            globalKeyboardHook.KeyboardPressed -= GlobalKeyboardHook_KeyboardPressed;
            globalKeyboardHook.Dispose();
        }

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

        private void SetHeightTo100Percent() => Height = SystemParameters.PrimaryScreenHeight - SystemParameters.WorkArea.Height;
    }
}
