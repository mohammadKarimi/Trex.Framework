namespace Trex.Framework.Core.Services.Network
{
    using System;
    public interface INetwork
    {
        NetworkStatus InternetConnectionStatus();
        event Action<NetworkStatus> NetworkStatusChanged;
    }
}
