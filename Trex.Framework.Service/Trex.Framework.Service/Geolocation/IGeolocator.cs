namespace Trex.Framework.Service.Geolocation
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Trex.Framework.Core.Geolocation;
    public interface IGeolocator
    {
        /// <summary>
        ///دقت مورد نظر
        /// </summary>
        double DesiredAccuracy { get; set; }

        bool IsListening { get; }

        bool SupportsHeading { get; }

        bool IsGeolocationAvailable { get; }

        bool IsGeolocationEnabled { get; }

        event EventHandler<PositionErrorEventArgs> PositionError;

        event EventHandler<PositionEventArgs> PositionChanged;

        Task<Position> GetPositionAsync(int timeout);

        Task<Position> GetPositionAsync(int timeout, bool includeHeading);

        Task<Position> GetPositionAsync(CancellationToken cancelToken);

        Task<Position> GetPositionAsync(CancellationToken cancelToken, bool includeHeading);

        Task<Position> GetPositionAsync(int timeout, CancellationToken cancelToken);

        Task<Position> GetPositionAsync(int timeout, CancellationToken cancelToken, bool includeHeading);

        /// <summary>
        ///شروع گوش دادن به تغییرات لوکیشن
        /// </summary>

        void StartListening(uint minTime, double minDistance);

        /// <summary>
        ///شروع گوش دادن به تغییرات لوکیشن
        /// </summary>
        void StartListening(uint minTime, double minDistance, bool includeHeading);

        /// <summary>
        ///اتمام گوش دادن به تغییرات لوکیشن
        /// </summary>
        void StopListening();
    }
}
