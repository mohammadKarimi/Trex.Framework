namespace Trex.Framework.Service.WinPhone.Network
{
    using Microsoft.Phone.Net.NetworkInformation;
    using System;
    using Trex.Framework.Core.Services;
    public class Network : INetwork
    {
        private readonly NetworkStatus _networkStatus;
        public Network()
        {
            _networkStatus = InternetConnectionStatus();
        }
        public NetworkStatus InternetConnectionStatus()
        {
            if (DeviceNetworkInformation.IsNetworkAvailable)
            {
                if (DeviceNetworkInformation.IsWiFiEnabled
                    && NetworkInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                {
                    return NetworkStatus.ReachableViaWiFi;
                }

                if (NetworkInterface.NetworkInterfaceType == NetworkInterfaceType.MobileBroadbandCdma
                    || NetworkInterface.NetworkInterfaceType == NetworkInterfaceType.MobileBroadbandGsm)
                {
                    return NetworkStatus.ReachableViaMobileData;
                }
                return NetworkStatus.ReachableViaUnknownNetwork;
            }
            return NetworkStatus.NotReachable;
        }
        private event Action<NetworkStatus> networkStatusChanged;
        public event Action<NetworkStatus> NetworkStatusChanged
        {
            add
            {
                if (this.networkStatusChanged == null)
                {
                    DeviceNetworkInformation.NetworkAvailabilityChanged += DeviceNetworkInformationNetworkAvailabilityChanged;
                }

                this.networkStatusChanged += value;
            }
            remove
            {
                this.networkStatusChanged -= value;

                if (this.networkStatusChanged == null)
                {
                    DeviceNetworkInformation.NetworkAvailabilityChanged -= DeviceNetworkInformationNetworkAvailabilityChanged;
                }
            }
        }

        private void DeviceNetworkInformationNetworkAvailabilityChanged(object sender, NetworkNotificationEventArgs e)
        {
            var status = InternetConnectionStatus();

            if (status == _networkStatus)
            {
                return;
            }

            var handler = networkStatusChanged;

            if (handler != null)
            {
                handler(status);
            }
        }
    }
}
