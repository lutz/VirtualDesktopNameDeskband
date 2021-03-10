using System.Windows.Forms;
using VirtualDesktop;

namespace VirtualDesktopNameDeskband
{
    public partial class DeskbandControl : UserControl
    {
        private readonly System.Timers.Timer _timer;

        public DeskbandControl()
        {
            InitializeComponent();

            lblDesktopName.Text = Desktop.DesktopNameFromDesktop(Desktop.Current);

            _timer = new System.Timers.Timer();
            _timer.Elapsed += _timer_Elapsed;
            _timer.AutoReset = true;
            _timer.Interval = 100;
            _timer.Start();
        }

        private void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)(() => { lblDesktopName.Text = Desktop.DesktopNameFromDesktop(Desktop.Current); }));
            }
            else
            {
                lblDesktopName.Text = Desktop.DesktopNameFromDesktop(Desktop.Current);
            }
        }


        internal void Close()
        {
            _timer.Stop();
            _timer.Dispose();
        }
    }
}
