using SharpShell.Attributes;
using SharpShell.SharpDeskBand;
using System.Runtime.InteropServices;

namespace VirtualDesktopNameDeskband
{
    [ComVisible(true)]
    [DisplayName("VirtualDeskNameDeskband")]
    public class VirtualDeskNameBand : SharpDeskBand
    {
        protected override System.Windows.Forms.UserControl CreateDeskBand()
        {
            return new DeskbandControl();
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
    }
}