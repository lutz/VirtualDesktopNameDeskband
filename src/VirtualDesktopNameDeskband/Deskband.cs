using SharpShell.Attributes;
using SharpShell.SharpDeskBand;
using System.Runtime.InteropServices;

namespace VirtualDesktopNameDeskband
{
    [ComVisible(true)]
    [DisplayName("VirtualDeskNameDeskband")]
    public class WebSearchDeskBand : SharpDeskBand
    {
        protected override System.Windows.Forms.UserControl CreateDeskBand() => new DeskbandControl();

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
