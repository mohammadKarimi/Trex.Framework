namespace Trex.Framework.Service.iOS.Network
{

    using System;
    using Trex.Framework.Service;
    public class Network : INetwork
    {
        public NetworkStatus InternetConnectionStatus()
        {
            return Reachability.InternetConnectionStatus();
        }
        private Action<NetworkStatus> networkStatusChanged;
        private void HandleReachabilityChanged(object sender, EventArgs e)
        {
            var reachabilityChanged = this.networkStatusChanged;
            if (reachabilityChanged != null)
            {
                reachabilityChanged(InternetConnectionStatus());
            }
        }
        public event Action<NetworkStatus> NetworkStatusChanged
        {
            add
            {
                if (networkStatusChanged == null)
                {
                    Reachability.ReachabilityChanged += HandleReachabilityChanged;
                }
                networkStatusChanged += value;
            }
            remove
            {
                networkStatusChanged -= value;
                if (networkStatusChanged == null)
                {
                    Reachability.ReachabilityChanged -= HandleReachabilityChanged;
                }
            }
        }
    }
}