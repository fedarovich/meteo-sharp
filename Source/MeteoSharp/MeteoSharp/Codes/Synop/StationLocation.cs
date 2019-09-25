using System;
using System.Collections.Generic;
using System.Text;
using EnumsNET;
using MeteoSharp.Core;
using MeteoSharp.Measurements;

namespace MeteoSharp.Codes.Synop
{
    public readonly struct StationLocation : IEquatable<StationLocation>
    {
        public StationLocation(SmallDecimal absoluteLatitude, SmallDecimal absoluteLongitude, GlobeQuadrant quadrant) : this()
        {
            if (absoluteLatitude < 0 || absoluteLatitude > 90) throw new ArgumentOutOfRangeException(nameof(absoluteLatitude));
            if (absoluteLongitude < 0 || absoluteLongitude > 180) throw new ArgumentOutOfRangeException(nameof(absoluteLongitude));
            if (quadrant == default || !quadrant.IsDefined()) throw new ArgumentOutOfRangeException(nameof(quadrant));

            AbsoluteLatitude = absoluteLatitude;
            AbsoluteLongitude = absoluteLongitude;
            Quadrant = quadrant;
        }

        public StationLocation(SmallDecimal absoluteLatitude, SmallDecimal absoluteLongitude, GlobeQuadrant quadrant,
            short marsdenSquareNumber, SmallDecimal elevation, ElevationUnitAndAccuracy elevationUnitAndAccuracy) : this(absoluteLatitude, absoluteLongitude, quadrant)
        {
            if (marsdenSquareNumber < 0 || marsdenSquareNumber > 999) throw new ArgumentOutOfRangeException(nameof(marsdenSquareNumber));

            switch (elevationUnitAndAccuracy)
            {
                case ElevationUnitAndAccuracy.MeterExcellent:
                    Elevation = (elevation, LengthUnit.Meter);
                    ElevationAccuracy = Codes.ElevationAccuracy.Excellent;
                    break;
                case ElevationUnitAndAccuracy.MeterGood:
                    Elevation = (elevation, LengthUnit.Meter);
                    ElevationAccuracy = Codes.ElevationAccuracy.Good;
                    break;
                case ElevationUnitAndAccuracy.MeterFair:
                    Elevation = (elevation, LengthUnit.Meter);
                    ElevationAccuracy = Codes.ElevationAccuracy.Fair;
                    break;
                case ElevationUnitAndAccuracy.MeterPoor:
                    Elevation = (elevation, LengthUnit.Meter);
                    ElevationAccuracy = Codes.ElevationAccuracy.Poor;
                    break;
                case ElevationUnitAndAccuracy.FootExcellent:
                    Elevation = (elevation, LengthUnit.Foot);
                    ElevationAccuracy = Codes.ElevationAccuracy.Excellent;
                    break;
                case ElevationUnitAndAccuracy.FootGood:
                    Elevation = (elevation, LengthUnit.Foot);
                    ElevationAccuracy = Codes.ElevationAccuracy.Good;
                    break;
                case ElevationUnitAndAccuracy.FootFair:
                    Elevation = (elevation, LengthUnit.Foot);
                    ElevationAccuracy = Codes.ElevationAccuracy.Fair;
                    break;
                case ElevationUnitAndAccuracy.FootPoor:
                    Elevation = (elevation, LengthUnit.Foot);
                    ElevationAccuracy = Codes.ElevationAccuracy.Poor;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(elevationUnitAndAccuracy), elevationUnitAndAccuracy, null);
            }
        }

        public StationLocation(SmallDecimal latitude, SmallDecimal longitude) : this()
        {
            if (latitude < -90 || latitude > 90) throw new ArgumentOutOfRangeException(nameof(latitude));
            if (longitude < -180 || longitude > 180) throw new ArgumentOutOfRangeException(nameof(longitude));

            bool north = latitude >= 0;
            bool east = longitude >= 0;
            AbsoluteLatitude = north ? latitude : -latitude;
            AbsoluteLongitude = east ? longitude : -longitude;
            Quadrant = (north, east) switch
            {
                (true, true) => GlobeQuadrant.NorthEast,
                (true, false) => GlobeQuadrant.NorthWest,
                (false, true) => GlobeQuadrant.SouthEast,
                (false, false) => GlobeQuadrant.SouthWest
            };
        }

        public StationLocation(SmallDecimal latitude, SmallDecimal longitude,
            short marsdenSquareNumber, Length elevation, ElevationAccuracy elevationAccuracy)
            : this(latitude, longitude)
        {
            if (marsdenSquareNumber < 0 || marsdenSquareNumber > 999) throw new ArgumentOutOfRangeException(nameof(marsdenSquareNumber));

            MarsdenSquareNumber = marsdenSquareNumber;
            Elevation = elevation;
            ElevationAccuracy = elevationAccuracy;
        }

        public SmallDecimal AbsoluteLatitude { get; }

        public SmallDecimal AbsoluteLongitude { get; }

        public GlobeQuadrant Quadrant { get; }

        public short? MarsdenSquareNumber { get; }

        public Length? Elevation { get; }

        public ElevationAccuracy? ElevationAccuracy { get; }

        public SmallDecimal Latitude =>
            Quadrant == GlobeQuadrant.SouthEast || Quadrant == GlobeQuadrant.SouthWest
                ? -AbsoluteLatitude
                : AbsoluteLatitude;

        public SmallDecimal Longitude =>
            Quadrant == GlobeQuadrant.NorthWest || Quadrant == GlobeQuadrant.SouthWest
                ? -AbsoluteLongitude
                : AbsoluteLongitude;


        public bool Equals(StationLocation other)
        {
            return AbsoluteLatitude.Equals(other.AbsoluteLatitude)
                && AbsoluteLongitude.Equals(other.AbsoluteLongitude)
                && Quadrant == other.Quadrant
                && MarsdenSquareNumber == other.MarsdenSquareNumber
                && Nullable.Equals(Elevation, other.Elevation)
                && ElevationAccuracy == other.ElevationAccuracy;
        }

        public override bool Equals(object obj)
        {
            return obj is StationLocation other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = AbsoluteLatitude.GetHashCode();
                hashCode = (hashCode * 397) ^ AbsoluteLongitude.GetHashCode();
                hashCode = (hashCode * 397) ^ (int)Quadrant;
                hashCode = (hashCode * 397) ^ MarsdenSquareNumber.GetHashCode();
                hashCode = (hashCode * 397) ^ Elevation.GetHashCode();
                hashCode = (hashCode * 397) ^ ElevationAccuracy.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(StationLocation left, StationLocation right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(StationLocation left, StationLocation right)
        {
            return !left.Equals(right);
        }
    }
}
