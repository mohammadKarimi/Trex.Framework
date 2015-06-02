namespace Trex.Framework.Service
{
    using System;
    public interface INetwork
    {
        NetworkStatus InternetConnectionStatus();
        event Action<NetworkStatus> NetworkStatusChanged;
    }
}
