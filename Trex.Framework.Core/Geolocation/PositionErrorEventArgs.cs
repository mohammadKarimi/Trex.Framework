
namespace Trex.Framework.Core.Geolocation
{
    using System;
    public class PositionErrorEventArgs : EventArgs
    {
        public PositionErrorEventArgs(GeolocationError error)
        {
            Error = error;
        }
        public GeolocationError Error { get; private set; }
    }
}
