namespace Trex.Framework.Service.iOS.Network
{
    using System;
    using System.Net;

    using CoreFoundation;
    using SystemConfiguration;
    using Trex.Framework.Core.Services;

    public static class Reachability
    {
        private static NetworkReachability defaultRouteReachability;
        public static bool IsReachableWithoutRequiringConnection(NetworkReachabilityFlags flags)
        {
            return (flags & NetworkReachabilityFlags.Reachable) != 0
                   && (((flags & NetworkReachabilityFlags.IsWWAN) != 0)
                       || (flags & NetworkReachabilityFlags.ConnectionRequired) == 0);
        }

       
       
        public static event EventHandler ReachabilityChanged;
 
        public static NetworkStatus InternetConnectionStatus()
        {
            NetworkReachabilityFlags flags;

            if ((IsNetworkAvailable(out flags) && ((flags & NetworkReachabilityFlags.IsDirect) != 0)) || flags == 0)
            {
                return NetworkStatus.NotReachable;
            }

            return (flags & NetworkReachabilityFlags.IsWWAN) != 0
                       ? NetworkStatus.ReachableViaMobileData
                       : NetworkStatus.ReachableViaWiFi;
        }

     

        private static void OnChange(NetworkReachabilityFlags flags)
        {
            var h = ReachabilityChanged;
            if (h != null)
            {
                h(null, EventArgs.Empty);
            }
        }

        public static bool IsNetworkAvailable(out NetworkReachabilityFlags flags)
        {
            if (defaultRouteReachability == null)
            {
                defaultRouteReachability = new NetworkReachability(new IPAddress(0));
                defaultRouteReachability.SetNotification(OnChange);
                defaultRouteReachability.Schedule(CFRunLoop.Current, CFRunLoop.ModeDefault);
            }

            return defaultRouteReachability.TryGetFlags(out flags) && IsReachableWithoutRequiringConnection(flags);
        }
    }
}