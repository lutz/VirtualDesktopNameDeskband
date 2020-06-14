﻿// Author: Markus Scholtes, 2020
// Version 1.5, 2020-05-24
// Version for Windows 10 1809
// Compile with:
// C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe VirtualDesktop.cs

using Microsoft.Win32;
using System;
using System.Runtime.InteropServices;

namespace VirtualDesktop
{
    internal static class Guids
    {
        public static readonly Guid CLSID_ImmersiveShell = new Guid("C2F03A33-21F5-47FA-B4BB-156362A2F239");
        public static readonly Guid CLSID_VirtualDesktopManagerInternal = new Guid("C5E0CDCA-7B6E-41B2-9FC4-D93975CC467B");
        public static readonly Guid CLSID_VirtualDesktopManager = new Guid("AA509086-5CA9-4C25-8F95-589D3C07B48A");
        public static readonly Guid CLSID_VirtualDesktopPinnedApps = new Guid("B5A399E7-1C87-46B8-88E9-FC5747B171BD");
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct Size
    {
        public int X;
        public int Y;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct Rect
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }

    internal enum APPLICATION_VIEW_CLOAK_TYPE : int
    {
        AVCT_NONE = 0,
        AVCT_DEFAULT = 1,
        AVCT_VIRTUAL_DESKTOP = 2
    }

    internal enum APPLICATION_VIEW_COMPATIBILITY_POLICY : int
    {
        AVCP_NONE = 0,
        AVCP_SMALL_SCREEN = 1,
        AVCP_TABLET_SMALL_SCREEN = 2,
        AVCP_VERY_SMALL_SCREEN = 3,
        AVCP_HIGH_SCALE_FACTOR = 4
    }

    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIInspectable)]
    [Guid("372E1D3B-38D3-42E4-A15B-8AB2B178F513")]
    internal interface IApplicationView
    {
        int SetFocus();
        int SwitchTo();
        int TryInvokeBack(IntPtr /* IAsyncCallback* */ callback);
        int GetThumbnailWindow(out IntPtr hwnd);
        int GetMonitor(out IntPtr /* IImmersiveMonitor */ immersiveMonitor);
        int GetVisibility(out int visibility);
        int SetCloak(APPLICATION_VIEW_CLOAK_TYPE cloakType, int unknown);
        int GetPosition(ref Guid guid /* GUID for IApplicationViewPosition */, out IntPtr /* IApplicationViewPosition** */ position);
        int SetPosition(ref IntPtr /* IApplicationViewPosition* */ position);
        int InsertAfterWindow(IntPtr hwnd);
        int GetExtendedFramePosition(out Rect rect);
        int GetAppUserModelId([MarshalAs(UnmanagedType.LPWStr)] out string id);
        int SetAppUserModelId(string id);
        int IsEqualByAppUserModelId(string id, out int result);
        int GetViewState(out uint state);
        int SetViewState(uint state);
        int GetNeediness(out int neediness);
        int GetLastActivationTimestamp(out ulong timestamp);
        int SetLastActivationTimestamp(ulong timestamp);
        int GetVirtualDesktopId(out Guid guid);
        int SetVirtualDesktopId(ref Guid guid);
        int GetShowInSwitchers(out int flag);
        int SetShowInSwitchers(int flag);
        int GetScaleFactor(out int factor);
        int CanReceiveInput(out bool canReceiveInput);
        int GetCompatibilityPolicyType(out APPLICATION_VIEW_COMPATIBILITY_POLICY flags);
        int SetCompatibilityPolicyType(APPLICATION_VIEW_COMPATIBILITY_POLICY flags);
        int GetSizeConstraints(IntPtr /* IImmersiveMonitor* */ monitor, out Size size1, out Size size2);
        int GetSizeConstraintsForDpi(uint uint1, out Size size1, out Size size2);
        int SetSizeConstraintsForDpi(ref uint uint1, ref Size size1, ref Size size2);
        int OnMinSizePreferencesUpdated(IntPtr hwnd);
        int ApplyOperation(IntPtr /* IApplicationViewOperation* */ operation);
        int IsTray(out bool isTray);
        int IsInHighZOrderBand(out bool isInHighZOrderBand);
        int IsSplashScreenPresented(out bool isSplashScreenPresented);
        int Flash();
        int GetRootSwitchableOwner(out IApplicationView rootSwitchableOwner);
        int EnumerateOwnershipTree(out IObjectArray ownershipTree);
        int GetEnterpriseId([MarshalAs(UnmanagedType.LPWStr)] out string enterpriseId);
        int IsMirrored(out bool isMirrored);
        int Unknown1(out int unknown);
        int Unknown2(out int unknown);
        int Unknown3(out int unknown);
        int Unknown4(out int unknown);
        int Unknown5(out int unknown);
        int Unknown6(int unknown);
        int Unknown7();
        int Unknown8(out int unknown);
        int Unknown9(int unknown);
        int Unknown10(int unknownX, int unknownY);
        int Unknown11(int unknown);
        int Unknown12(out Size size1);
    }

    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("1841C6D7-4F9D-42C0-AF41-8747538F10E5")]
    internal interface IApplicationViewCollection
    {
        int GetViews(out IObjectArray array);
        int GetViewsByZOrder(out IObjectArray array);
        int GetViewsByAppUserModelId(string id, out IObjectArray array);
        int GetViewForHwnd(IntPtr hwnd, out IApplicationView view);
        int GetViewForApplication(object application, out IApplicationView view);
        int GetViewForAppUserModelId(string id, out IApplicationView view);
        int GetViewInFocus(out IntPtr view);
        int Unknown1(out IntPtr view);
        void RefreshCollection();
        int RegisterForApplicationViewChanges(object listener, out int cookie);
        int UnregisterForApplicationViewChanges(int cookie);
    }

    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("FF72FFDD-BE7E-43FC-9C03-AD81681E88E4")]
    internal interface IVirtualDesktop
    {
        bool IsViewVisible(IApplicationView view);
        Guid GetId();
    }

    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("F31574D6-B682-4CDC-BD56-1827860ABEC6")]
    internal interface IVirtualDesktopManagerInternal
    {
        int GetCount();
        void MoveViewToDesktop(IApplicationView view, IVirtualDesktop desktop);
        bool CanViewMoveDesktops(IApplicationView view);
        IVirtualDesktop GetCurrentDesktop();
        void GetDesktops(out IObjectArray desktops);
        [PreserveSig]
        int GetAdjacentDesktop(IVirtualDesktop from, int direction, out IVirtualDesktop desktop);
        void SwitchDesktop(IVirtualDesktop desktop);
        IVirtualDesktop CreateDesktop();
        void RemoveDesktop(IVirtualDesktop desktop, IVirtualDesktop fallback);
        IVirtualDesktop FindDesktop(ref Guid desktopid);
    }

    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("A5CD92FF-29BE-454C-8D04-D82879FB3F1B")]
    internal interface IVirtualDesktopManager
    {
        bool IsWindowOnCurrentVirtualDesktop(IntPtr topLevelWindow);
        Guid GetWindowDesktopId(IntPtr topLevelWindow);
        void MoveWindowToDesktop(IntPtr topLevelWindow, ref Guid desktopId);
    }

    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("4CE81583-1E4C-4632-A621-07A53543148F")]
    internal interface IVirtualDesktopPinnedApps
    {
        bool IsAppIdPinned(string appId);
        void PinAppID(string appId);
        void UnpinAppID(string appId);
        bool IsViewPinned(IApplicationView applicationView);
        void PinView(IApplicationView applicationView);
        void UnpinView(IApplicationView applicationView);
    }

    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("92CA9DCD-5622-4BBA-A805-5E9F541BD8C9")]
    internal interface IObjectArray
    {
        void GetCount(out int count);
        void GetAt(int index, ref Guid iid, [MarshalAs(UnmanagedType.Interface)] out object obj);
    }

    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("6D5140C1-7436-11CE-8034-00AA006009FA")]
    internal interface IServiceProvider10
    {
        [return: MarshalAs(UnmanagedType.IUnknown)]
        object QueryService(ref Guid service, ref Guid riid);
    }

    internal static class DesktopManager
    {
        static DesktopManager()
        {
            var shell = (IServiceProvider10)Activator.CreateInstance(Type.GetTypeFromCLSID(Guids.CLSID_ImmersiveShell));
            VirtualDesktopManagerInternal = (IVirtualDesktopManagerInternal)shell.QueryService(Guids.CLSID_VirtualDesktopManagerInternal, typeof(IVirtualDesktopManagerInternal).GUID);
            VirtualDesktopManager = (IVirtualDesktopManager)Activator.CreateInstance(Type.GetTypeFromCLSID(Guids.CLSID_VirtualDesktopManager));
            ApplicationViewCollection = (IApplicationViewCollection)shell.QueryService(typeof(IApplicationViewCollection).GUID, typeof(IApplicationViewCollection).GUID);
            VirtualDesktopPinnedApps = (IVirtualDesktopPinnedApps)shell.QueryService(Guids.CLSID_VirtualDesktopPinnedApps, typeof(IVirtualDesktopPinnedApps).GUID);
        }

        internal static IVirtualDesktopManagerInternal VirtualDesktopManagerInternal;
        internal static IVirtualDesktopManager VirtualDesktopManager;
        internal static IApplicationViewCollection ApplicationViewCollection;
        internal static IVirtualDesktopPinnedApps VirtualDesktopPinnedApps;

        internal static IVirtualDesktop GetDesktop(int index)
        {
            int count = VirtualDesktopManagerInternal.GetCount();
            if (index < 0 || index >= count) throw new ArgumentOutOfRangeException("index");

            VirtualDesktopManagerInternal.GetDesktops(out IObjectArray desktops);
            desktops.GetAt(index, typeof(IVirtualDesktop).GUID, out object objdesktop);

            Marshal.ReleaseComObject(desktops);

            return (IVirtualDesktop)objdesktop;
        }

        internal static int GetDesktopIndex(IVirtualDesktop desktop)
        {
            var index = -1;
            var IdSearch = desktop.GetId();
            VirtualDesktopManagerInternal.GetDesktops(out IObjectArray desktops);
            for (int i = 0; i < VirtualDesktopManagerInternal.GetCount(); i++)
            {
                desktops.GetAt(i, typeof(IVirtualDesktop).GUID, out object objdesktop);
                if (IdSearch.CompareTo(((IVirtualDesktop)objdesktop).GetId()) == 0)
                {
                    index = i;
                    break;
                }
            }
            Marshal.ReleaseComObject(desktops);
            return index;
        }

        internal static IApplicationView GetApplicationView(this IntPtr hWnd)
        {
            // get application view to window handle
            ApplicationViewCollection.GetViewForHwnd(hWnd, out IApplicationView view);
            return view;
        }

        internal static string GetAppId(IntPtr hWnd)
        {
            // get Application ID to window handle
            hWnd.GetApplicationView().GetAppUserModelId(out string appId);
            return appId;
        }
    }


    public class Desktop
    {
        #region User32.dll

        // Get process id to window handle
        [DllImport("user32.dll")]
        public static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

        // Get handle of active window
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        #endregion

        private readonly IVirtualDesktop ivd;

        private Desktop(IVirtualDesktop desktop) => ivd = desktop;

        public static int Count => DesktopManager.VirtualDesktopManagerInternal.GetCount();

        public static Desktop Current => new Desktop(DesktopManager.VirtualDesktopManagerInternal.GetCurrentDesktop());

        public Guid Guid => ivd.GetId();

        public string Name
        {
            get
            {
                var name = Registry.GetValue(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VirtualDesktops\Desktops\{" + Guid.ToString() + "}", "Name", null).ToString();

                if (string.IsNullOrEmpty(name))
                {
                    return $"Desktop {FromDesktop(Current) + 1}";
                }

                return name;
            }
        }

        public override int GetHashCode() => ivd.GetHashCode();

        public override bool Equals(object obj) => obj is Desktop desk && ReferenceEquals(ivd, desk.ivd);

        public static Desktop FromIndex(int index) => new Desktop(DesktopManager.GetDesktop(index));

        public static Desktop FromWindow(IntPtr hWnd)
        { // Creates desktop object on which window <hWnd> is displayed
            if (hWnd == IntPtr.Zero)
            {
                throw new ArgumentNullException();
            }

            var id = DesktopManager.VirtualDesktopManager.GetWindowDesktopId(hWnd);
            return new Desktop(DesktopManager.VirtualDesktopManagerInternal.FindDesktop(ref id));
        }

        public static int FromDesktop(Desktop desktop)
        { // Returns index of desktop object or -1 if not found
            return DesktopManager.GetDesktopIndex(desktop.ivd);
        }

        public static Desktop Create() => new Desktop(DesktopManager.VirtualDesktopManagerInternal.CreateDesktop());

        public void Remove(Desktop fallback = null)
        {
            // Destroy desktop and switch to <fallback>
            IVirtualDesktop fallbackdesktop;
            if (fallback == null)
            { // if no fallback is given use desktop to the left except for desktop 0.
                Desktop dtToCheck = new Desktop(DesktopManager.GetDesktop(0));
                if (Equals(dtToCheck))
                { // desktop 0: set fallback to second desktop (= "right" desktop)
                    DesktopManager.VirtualDesktopManagerInternal.GetAdjacentDesktop(ivd, 4, out fallbackdesktop); // 4 = RightDirection
                }
                else
                { // set fallback to "left" desktop
                    DesktopManager.VirtualDesktopManagerInternal.GetAdjacentDesktop(ivd, 3, out fallbackdesktop); // 3 = LeftDirection
                }
            }
            else
                // set fallback desktop
                fallbackdesktop = fallback.ivd;

            DesktopManager.VirtualDesktopManagerInternal.RemoveDesktop(ivd, fallbackdesktop);
        }

        public bool IsVisible => ReferenceEquals(ivd, DesktopManager.VirtualDesktopManagerInternal.GetCurrentDesktop());

        public void MakeVisible() => DesktopManager.VirtualDesktopManagerInternal.SwitchDesktop(ivd);

        public Desktop Left
        { // Returns desktop at the left of this one, null if none
            get
            {
                var hr = DesktopManager.VirtualDesktopManagerInternal.GetAdjacentDesktop(ivd, 3, out IVirtualDesktop desktop); // 3 = LeftDirection
                if (hr == 0)
                    return new Desktop(desktop);
                else
                    return null;
            }
        }

        public Desktop Right
        {
            get
            {
                var hr = DesktopManager.VirtualDesktopManagerInternal.GetAdjacentDesktop(ivd, 4, out IVirtualDesktop desktop); // 4 = RightDirection
                if (hr == 0)
                    return new Desktop(desktop);
                else
                    return null;
            }
        }

        public void MoveWindow(IntPtr hWnd)
        { // Move window <hWnd> to this desktop
            int processId;
            if (hWnd == IntPtr.Zero) throw new ArgumentNullException();
            GetWindowThreadProcessId(hWnd, out processId);

            if (System.Diagnostics.Process.GetCurrentProcess().Id == processId)
            { // window of process
                try // the easy way (if we are owner)
                {
                    DesktopManager.VirtualDesktopManager.MoveWindowToDesktop(hWnd, ivd.GetId());
                }
                catch // window of process, but we are not the owner
                {
                    IApplicationView view;
                    DesktopManager.ApplicationViewCollection.GetViewForHwnd(hWnd, out view);
                    DesktopManager.VirtualDesktopManagerInternal.MoveViewToDesktop(view, ivd);
                }
            }
            else
            {
                DesktopManager.ApplicationViewCollection.GetViewForHwnd(hWnd, out IApplicationView view);
                try
                {
                    DesktopManager.VirtualDesktopManagerInternal.MoveViewToDesktop(view, ivd);
                }
                catch
                { // could not move active window, try main window (or whatever windows thinks is the main window)
                    DesktopManager.ApplicationViewCollection.GetViewForHwnd(System.Diagnostics.Process.GetProcessById(processId).MainWindowHandle, out view);
                    DesktopManager.VirtualDesktopManagerInternal.MoveViewToDesktop(view, ivd);
                }
            }
        }

        public void MoveActiveWindow() => MoveWindow(GetForegroundWindow());

        public bool HasWindow(IntPtr hWnd)
        { // Returns true if window <hWnd> is on this desktop
            if (hWnd == IntPtr.Zero) throw new ArgumentNullException();
            return ivd.GetId() == DesktopManager.VirtualDesktopManager.GetWindowDesktopId(hWnd);
        }

        public static bool IsWindowPinned(IntPtr hWnd)
        { // Returns true if window <hWnd> is pinned to all desktops
            if (hWnd == IntPtr.Zero) throw new ArgumentNullException();
            return DesktopManager.VirtualDesktopPinnedApps.IsViewPinned(hWnd.GetApplicationView());
        }

        public static void PinWindow(IntPtr hWnd)
        { // pin window <hWnd> to all desktops
            if (hWnd == IntPtr.Zero) throw new ArgumentNullException();
            var view = hWnd.GetApplicationView();
            if (!DesktopManager.VirtualDesktopPinnedApps.IsViewPinned(view))
            { // pin only if not already pinned
                DesktopManager.VirtualDesktopPinnedApps.PinView(view);
            }
        }

        public static void UnpinWindow(IntPtr hWnd)
        { // unpin window <hWnd> from all desktops
            if (hWnd == IntPtr.Zero) throw new ArgumentNullException();
            var view = hWnd.GetApplicationView();
            if (DesktopManager.VirtualDesktopPinnedApps.IsViewPinned(view))
            { // unpin only if not already unpinned
                DesktopManager.VirtualDesktopPinnedApps.UnpinView(view);
            }
        }

        public static bool IsApplicationPinned(IntPtr hWnd)
        { // Returns true if application for window <hWnd> is pinned to all desktops
            if (hWnd == IntPtr.Zero) throw new ArgumentNullException();
            return DesktopManager.VirtualDesktopPinnedApps.IsAppIdPinned(DesktopManager.GetAppId(hWnd));
        }

        public static void PinApplication(IntPtr hWnd)
        { // pin application for window <hWnd> to all desktops
            if (hWnd == IntPtr.Zero) throw new ArgumentNullException();
            string appId = DesktopManager.GetAppId(hWnd);
            if (!DesktopManager.VirtualDesktopPinnedApps.IsAppIdPinned(appId))
            { // pin only if not already pinned
                DesktopManager.VirtualDesktopPinnedApps.PinAppID(appId);
            }
        }

        public static void UnpinApplication(IntPtr hWnd)
        { // unpin application for window <hWnd> from all desktops
            if (hWnd == IntPtr.Zero) throw new ArgumentNullException();
            var view = hWnd.GetApplicationView();
            string appId = DesktopManager.GetAppId(hWnd);
            if (DesktopManager.VirtualDesktopPinnedApps.IsAppIdPinned(appId))
            { // unpin only if already pinned
                DesktopManager.VirtualDesktopPinnedApps.UnpinAppID(appId);
            }
        }
    }
}