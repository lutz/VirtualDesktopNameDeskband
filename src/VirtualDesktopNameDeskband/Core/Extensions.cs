using System;

namespace VirtualDesktopNameDeskband
{
    internal static class Extensions
    {
        public static void IgnoreException(this Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception) { }
        }
    }
}
