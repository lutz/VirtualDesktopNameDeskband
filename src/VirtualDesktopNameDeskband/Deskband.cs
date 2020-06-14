using CSDeskBand;
using System;
using System.Runtime.InteropServices;
using System.Windows;

namespace VirtualDesktopNameDeskband
{
    [ComVisible(true)]
    [Guid("77B05500-B3CC-4565-BAFD-EDB512E5ADC8")]
    [CSDeskBandRegistration(Name = "Virtual Desktop Name")]
    public class Deskband : CSDeskBandWpf
    {
        public Deskband()
        {
            Options.MinHorizontalSize = new Size(70, 28);
            Options.HeightCanChange = true;
        }
        protected override UIElement UIElement => new DeskbandView();

        protected override void DeskbandOnClosed() => (UIElement as DeskbandView)?.Close();
    }
}
