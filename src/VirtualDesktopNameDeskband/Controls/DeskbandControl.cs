using System;
using System.Windows.Forms;
using VirtualDesktop;

namespace VirtualDesktopNameDeskband
{
    public partial class DeskbandControl : UserControl
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            timer.Enabled = true;
        }

        public DeskbandControl()
        {
            InitializeComponent();
        }

        internal void Close()
        {
            timer.Enabled = false;
            timer.Dispose();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            lblDesktopName.Text = Desktop.DesktopNameFromDesktop(Desktop.Current) ?? "...";
        }
    }
}
