using SharpShell.Attributes;
using SharpShell.SharpDeskBand;
using System.Runtime.InteropServices;

namespace VirtualDesktopNameDeskband
{
    [ComVisible(true)]
    [DisplayName("VirtualDeskNameDeskband")]
    public class VirtualDeskNameBand : SharpDeskBand
    {
        private DeskbandControl deskbandControl;

        protected override System.Windows.Forms.UserControl CreateDeskBand()
        {
            return deskbandControl ?? (deskbandControl = new DeskbandControl());
        }

        protected override BandOptions GetBandOptions()
        {
            return new BandOptions
            {
                HasVariableHeight = false,
                IsSunken = false,
                ShowTitle = true,
                Title = "VirtualDeskNameDeskband",
                UseBackgroundColour = false,
                AlwaysShowGripper = false
            };
        }

        protected override void OnBandRemoved()
        {
            deskbandControl?.Close();

            base.OnBandRemoved();
        }
    }
}