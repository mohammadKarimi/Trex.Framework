namespace Trex.Framework.Core.Services
{
    using System;
    public interface INetwork
    {
        NetworkStatus InternetConnectionStatus();
        event Action<NetworkStatus> NetworkStatusChanged;
    }
}
