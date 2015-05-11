namespace Trex.Framework.Service.Droid.Network
{
    using Android.App;
    using Android.Content;
    using Android.Net;
    using System;
    using Trex.Framework.Core.Services.Network;
    public class Network :BroadcastMonitor, INetwork
    {
        private Action<NetworkStatus> networkStatusChanged;
        private readonly object lockObject = new object();
        public NetworkStatus InternetConnectionStatus()
        {
            var status = NetworkStatus.NotReachable;
            using (var connectivityManager = (ConnectivityManager)Application.Context.GetSystemService(Context.ConnectivityService))
            using (var networkInfo = connectivityManager.ActiveNetworkInfo)
            {
                if (networkInfo != null && networkInfo.IsConnectedOrConnecting)
                {
                    var name = networkInfo.TypeName.ToUpper();
                    if (name.Contains("WIFI"))
                    {
                        status = NetworkStatus.ReachableViaWiFi;
                    }
                    else if (name.Contains("MOBILE"))
                    {
                        status = NetworkStatus.ReachableViaMobileData;
                    }
                    else
                    {
                        status = NetworkStatus.ReachableViaUnknownNetwork;
                    }
                }
            }
            return status;
        }
        public event Action<NetworkStatus> NetworkStatusChanged
        {
            add
            {
                lock (this.lockObject)
                {
                    if (this.networkStatusChanged == null)
                    {
                        this.Start();
                    }
                    this.networkStatusChanged += value;
                }
            }
            remove
            {
                lock (this.lockObject)
                {
                    this.networkStatusChanged -= value;

                    if (this.networkStatusChanged == null)
                    {
                        this.Stop();
                    }
                }
            }
        }
        public override void OnReceive(Context context, Intent intent)
        {
            var handler = this.networkStatusChanged;
            if (handler != null)
            {
                handler(this.InternetConnectionStatus());
            }
        }
        protected override IntentFilter Filter
        {
            get { return new IntentFilter(ConnectivityManager.ConnectivityAction); }
        }
    }
}