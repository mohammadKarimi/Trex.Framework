namespace Trex.Framework.Service.Droid.Geolocation
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using Android.Locations;
    using Android.OS;

    using Object = Java.Lang.Object;
    using Trex.Framework.Core.Geolocation;

    internal class GeolocationSingleListener : Object, ILocationListener
    {
        private Location _bestLocation;

        private readonly HashSet<string> _activeProviders;

        private readonly TaskCompletionSource<Position> _completionSource = new TaskCompletionSource<Position>();


        private readonly float _desiredAccuracy;

        private readonly Action _finishedCallback;

        private readonly object _locationSync = new object();


        private readonly Timer _timer;

        public GeolocationSingleListener(
            float desiredAccuracy,
            int timeout,
            IEnumerable<string> activeProviders,
            Action finishedCallback)
        {
            _desiredAccuracy = desiredAccuracy;
            _finishedCallback = finishedCallback;

            _activeProviders = new HashSet<string>(activeProviders);

            if (timeout != Timeout.Infinite)
            {
                _timer = new Timer(TimesUp, null, timeout, 0);
            }
        }

        public Task<Position> Task
        {
            get
            {
                return _completionSource.Task;
            }
        }


        public void OnLocationChanged(Location location)
        {
            if (location.Accuracy <= _desiredAccuracy)
            {
                Finish(location);
                return;
            }

            lock (_locationSync)
            {
                if (_bestLocation == null || location.Accuracy <= _bestLocation.Accuracy)
                {
                    _bestLocation = location;
                }
            }
        }

        public void OnProviderDisabled(string provider)
        {
            lock (_activeProviders)
            {
                if (_activeProviders.Remove(provider) && _activeProviders.Count == 0)
                {
                    _completionSource.TrySetException(new GeolocationException(GeolocationError.PositionUnavailable));
                }
            }
        }


        public void OnProviderEnabled(string provider)
        {
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


        public void Cancel()
        {
            _completionSource.TrySetCanceled();
        }


        private void TimesUp(object state)
        {
            lock (_locationSync)
            {
                if (_bestLocation == null)
                {
                    if (_completionSource.TrySetCanceled() && _finishedCallback != null)
                    {
                        _finishedCallback();
                    }
                }
                else
                {
                    Finish(_bestLocation);
                }
            }
        }


        private void Finish(Location location)
        {
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

            if (_finishedCallback != null)
            {
                _finishedCallback();
            }

            _completionSource.TrySetResult(p);
        }
    }
}