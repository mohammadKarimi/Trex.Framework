namespace Trex.Framework.Service.Droid.Geolocation
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    using Android.Locations;
    using Android.OS;

    using Object = Java.Lang.Object;
    using Trex.Framework.Core.Geolocation;

    /// <summary>
    ///     Class GeolocationContinuousListener.
    /// </summary>
    internal class GeolocationContinuousListener : Object, ILocationListener
    {
        /// <summary>
        ///     The active provider
        /// </summary>
        private string _activeProvider;

        /// <summary>
        ///     The last location
        /// </summary>
        private Location _lastLocation;

        /// <summary>
        ///     The providers
        /// </summary>
        private IList<string> _providers;

        /// <summary>
        ///     The time period
        /// </summary>
        private TimeSpan _timePeriod;

        /// <summary>
        ///     The active providers
        /// </summary>
        private readonly HashSet<string> _activeProviders = new HashSet<string>();

        /// <summary>
        ///     The manager
        /// </summary>
        private readonly LocationManager _manager;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GeolocationContinuousListener" /> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        /// <param name="timePeriod">The time period.</param>
        /// <param name="providers">The providers.</param>
        public GeolocationContinuousListener(LocationManager manager, TimeSpan timePeriod, IList<string> providers)
        {
            _manager = manager;
            _timePeriod = timePeriod;
            _providers = providers;

            foreach (var p in providers)
            {
                if (manager.IsProviderEnabled(p))
                {
                    _activeProviders.Add(p);
                }
            }
        }

        /// <summary>
        ///     Called when the location has changed.
        /// </summary>
        /// <param name="location">The new location, as a Location object.</param>
        /// <since version="Added in API level 1" />
        /// <remarks>
        ///     <para tool="javadoc-to-mdoc">
        ///         Called when the location has changed.
        ///     </para>
        ///     <para tool="javadoc-to-mdoc"> There are no restrictions on the use of the supplied Location object.</para>
        ///     <para tool="javadoc-to-mdoc">
        ///         <format type="text/html">
        ///             <a
        ///                 href="http://developer.android.com/reference/android/location/LocationListener.html#onLocationChanged(android.location.Location)"
        ///                 target="_blank">
        ///                 [Android Documentation]
        ///             </a>
        ///         </format>
        ///     </para>
        /// </remarks>
        public void OnLocationChanged(Location location)
        {
            if (location.Provider != _activeProvider)
            {
                if (_activeProvider != null && _manager.IsProviderEnabled(_activeProvider))
                {
                    var pr = _manager.GetProvider(location.Provider);
                    var lapsed = GetTimeSpan(location.Time) - GetTimeSpan(_lastLocation.Time);

                    if (pr.Accuracy > _manager.GetProvider(_activeProvider).Accuracy && lapsed < _timePeriod.Add(_timePeriod))
                    {
                        location.Dispose();
                        return;
                    }
                }

                _activeProvider = location.Provider;
            }

            var previous = Interlocked.Exchange(ref _lastLocation, location);
            if (previous != null)
            {
                previous.Dispose();
            }

            var p = new Position();
            if (location.HasAccuracy)
            {
                p.Accuracy = location.Accuracy;
            }
            if (location.HasAltitude)
            {
                p.Altitude = location.Altitude;
            }
            if (location.HasBearing)
            {
                p.Heading = location.Bearing;
            }
            if (location.HasSpeed)
            {
                p.Speed = location.Speed;
            }

            p.Longitude = location.Longitude;
            p.Latitude = location.Latitude;
            p.Timestamp = Geolocator.GetTimestamp(location);

            var changed = PositionChanged;
            if (changed != null)
            {
                changed(this, new PositionEventArgs(p));
            }
        }

        public void OnProviderDisabled(string provider)
        {
            if (provider == LocationManager.PassiveProvider)
            {
                return;
            }

            lock (_activeProviders)
            {
                if (_activeProviders.Remove(provider) && _activeProviders.Count == 0)
                {
                    OnPositionError(new PositionErrorEventArgs(GeolocationError.PositionUnavailable));
                }
            }
        }

        public void OnProviderEnabled(string provider)
        {
            if (provider == LocationManager.PassiveProvider)
            {
                return;
            }

            lock (_activeProviders) _activeProviders.Add(provider);
        }

        public void OnStatusChanged(string provider, Availability status, Bundle extras)
        {
            switch (status)
            {
                case Availability.Available:
                    OnProviderEnabled(provider);
                    break;

                case Availability.OutOfService:
                    OnProviderDisabled(provider);
                    break;
            }
        }

        public event EventHandler<PositionErrorEventArgs> PositionError;

        public event EventHandler<PositionEventArgs> PositionChanged;

        private TimeSpan GetTimeSpan(long time)
        {
            return new TimeSpan(TimeSpan.TicksPerMillisecond * time);
        }

        private void OnPositionError(PositionErrorEventArgs e)
        {
            var error = PositionError;
            if (error != null)
            {
                error(this, e);
            }
        }
    }
}