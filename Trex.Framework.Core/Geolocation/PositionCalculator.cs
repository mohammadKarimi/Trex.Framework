namespace Trex.Framework.Core.Geolocation
{
    using System;
    public static class PositionCalculator
    {
        public const int EquatorRadius = 6378137;
        public static double DistanceFrom(this Position a, Position b)
        {
            var dLat = b.Latitude.DegreesToRadians() - a.Latitude.DegreesToRadians();
            var dLon = b.Longitude.DegreesToRadians() - a.Longitude.DegreesToRadians();

            var a1 = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Cos(a.Latitude.DegreesToRadians()) * Math.Cos(b.Latitude.DegreesToRadians()) * Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            var distance = 2 * Math.Atan2(Math.Sqrt(a1), Math.Sqrt(1 - a1));

            return EquatorRadius * distance;
        }
        public static double BearingFrom(this Position start, Position stop)
        {
            var deltaLon = stop.Longitude - start.Longitude;
            var cosStop = Math.Cos(stop.Latitude);
            return Math.Atan2(
                (Math.Cos(start.Latitude) * Math.Sin(stop.Latitude)) -
                (Math.Sin(start.Latitude) * cosStop * Math.Cos(deltaLon)),
                Math.Sin(deltaLon) * cosStop);
        }
        public static double RadiansToDegrees(this double rad)
        {
            return 180.0 * rad / Math.PI;
        }
        public static double DegreesToRadians(this double deg)
        {
            return Math.PI * deg / 180.0;
        }
    }
}
