using Xamarin.Forms;
using Trex.Framework.Service.Droid.Geolocation;
[assembly: Dependency(typeof(Geolocator))]
namespace Trex.Framework.Service.Droid.Geolocation
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Android.App;
    using Android.Content;
    using Android.Locations;
    using Android.OS;

    using Java.Lang;
    using Trex.Framework.Service.Geolocation;
    using Trex.Framework.Core.Geolocation;

    public class Geolocator : IGeolocator
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private string _headingProvider;
        private Position _lastPosition;
        private GeolocationContinuousListener _listener;
        private readonly LocationManager _manager;
        private readonly object _positionSync = new object();
        private readonly string[] _providers;

        public Geolocator()
        {
            _manager = (LocationManager)Application.Context.GetSystemService(Context.LocationService);
            _providers = _manager.GetProviders(false).Where(s => s != LocationManager.PassiveProvider).ToArray();
        }

        public bool IsListening
        {
            get
            {
                return _listener != null;
            }
        }
        public double DesiredAccuracy { get; set; }
        public bool SupportsHeading
        {
            get
            {
                return false;
            }
        }

        public bool IsGeolocationAvailable
        {
            get
            {
                return _providers.Length > 0;
            }
        }

        public bool IsGeolocationEnabled
        {
            get
            {
                return _providers.Any(_manager.IsProviderEnabled);
            }
        }

        public void StopListening()
        {
            if (_listener == null)
            {
                return;
            }

            _listener.PositionChanged -= OnListenerPositionChanged;
            _listener.PositionError -= OnListenerPositionError;

            for (var i = 0; i < _providers.Length; ++i)
            {
                _manager.RemoveUpdates(_listener);
            }

            _listener = null;
        }
        public event EventHandler<PositionErrorEventArgs> PositionError;
        public event EventHandler<PositionEventArgs> PositionChanged;

        public Task<Position> GetPositionAsync(CancellationToken cancelToken)
        {
            return GetPositionAsync(cancelToken, false);
        }
        public Task<Position> GetPositionAsync(CancellationToken cancelToken, bool includeHeading)
        {
            return GetPositionAsync(Timeout.Infinite, cancelToken);
        }

        public Task<Position> GetPositionAsync(int timeout)
        {
            return GetPositionAsync(timeout, false);
        }

        public Task<Position> GetPositionAsync(int timeout, bool includeHeading)
        {
            return GetPositionAsync(timeout, CancellationToken.None);
        }
        public Task<Position> GetPositionAsync(int timeout, CancellationToken cancelToken)
        {
            return GetPositionAsync(timeout, cancelToken, false);
        }
        public Task<Position> GetPositionAsync(int timeout, CancellationToken cancelToken, bool includeHeading)
        {
            if (timeout <= 0 && timeout != Timeout.Infinite)
            {
                throw new ArgumentOutOfRangeException("timeout", "timeout must be greater than or equal to 0");
            }

            var tcs = new TaskCompletionSource<Position>();

            if (!IsListening)
            {
                GeolocationSingleListener singleListener = null;
                singleListener = new GeolocationSingleListener(
                    (float)DesiredAccuracy,
                    timeout,
                    _providers.Where(_manager.IsProviderEnabled),
                    () =>
                    {
                        for (var i = 0; i < _providers.Length; ++i)
                        {
                            _manager.RemoveUpdates(singleListener);
                        }
                    });

                if (cancelToken != CancellationToken.None)
                {
                    cancelToken.Register(
                        () =>
                        {
                            singleListener.Cancel();

                            for (var i = 0; i < _providers.Length; ++i)
                            {
                                _manager.RemoveUpdates(singleListener);
                            }
                        },
                        true);
                }

                try
                {
                    var looper = Looper.MyLooper() ?? Looper.MainLooper;

                    var enabled = 0;
                    for (var i = 0; i < _providers.Length; ++i)
                    {
                        if (_manager.IsProviderEnabled(_providers[i]))
                        {
                            enabled++;
                        }

                        _manager.RequestLocationUpdates(_providers[i], 0, 0, singleListener, looper);
                    }

                    if (enabled == 0)
                    {
                        for (var i = 0; i < _providers.Length; ++i)
                        {
                            _manager.RemoveUpdates(singleListener);
                        }

                        tcs.SetException(new GeolocationException(GeolocationError.PositionUnavailable));
                        return tcs.Task;
                    }
                }
                catch (SecurityException ex)
                {
                    tcs.SetException(new GeolocationException(GeolocationError.Unauthorized, ex));
                    return tcs.Task;
                }

                return singleListener.Task;
            }

            // If we're already listening, just use the current listener
            lock (_positionSync)
            {
                if (_lastPosition == null)
                {
                    if (cancelToken != CancellationToken.None)
                    {
                        cancelToken.Register(() => tcs.TrySetCanceled());
                    }

                    EventHandler<PositionEventArgs> gotPosition = null;
                    gotPosition = (s, e) =>
                        {
                            tcs.TrySetResult(e.Position);
                            PositionChanged -= gotPosition;
                        };

                    PositionChanged += gotPosition;
                }
                else
                {
                    tcs.SetResult(_lastPosition);
                }
            }

            return tcs.Task;
        }
        public void StartListening(uint minTime, double minDistance)
        {
            StartListening(minTime, minDistance, false);
        }

        public void StartListening(uint minTime, double minDistance, bool includeHeading)
        {
            if (minTime < 0)
            {
                throw new ArgumentOutOfRangeException("minTime");
            }
            if (minDistance < 0)
            {
                throw new ArgumentOutOfRangeException("minDistance");
            }
            if (IsListening)
            {
                throw new InvalidOperationException("This Geolocator is already listening");
            }

            _listener = new GeolocationContinuousListener(_manager, TimeSpan.FromMilliseconds(minTime), _providers);
            _listener.PositionChanged += OnListenerPositionChanged;
            _listener.PositionError += OnListenerPositionError;

            var looper = Looper.MyLooper() ?? Looper.MainLooper;
            for (var i = 0; i < _providers.Length; ++i)
            {
                _manager.RequestLocationUpdates(_providers[i], minTime, (float)minDistance, _listener, looper);
            }
        }

        private void OnListenerPositionChanged(object sender, PositionEventArgs e)
        {
            if (!IsListening) // ignore anything that might come in afterwards
            {
                return;
            }

            lock (_positionSync)
            {
                _lastPosition = e.Position;

                var changed = PositionChanged;
                if (changed != null)
                {
                    changed(this, e);
                }
            }
        }
        private void OnListenerPositionError(object sender, PositionErrorEventArgs e)
        {
            StopListening();

            var error = PositionError;
            if (error != null)
            {
                error(this, e);
            }
        }
        internal static DateTimeOffset GetTimestamp(Location location)
        {
            return new DateTimeOffset(Epoch.AddMilliseconds(location.Time));
        }
    }
}