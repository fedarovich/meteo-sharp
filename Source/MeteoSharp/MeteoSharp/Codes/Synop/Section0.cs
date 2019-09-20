using System;
using System.Collections.Generic;
using System.Text;
using MeteoSharp.Core;
using MeteoSharp.Measurements;
using MeteoSharp.Time;

namespace MeteoSharp.Codes.Synop
{
    public class Section0
    {
        public StationId StationId { get; private set; }

        public DayHour ObservationTime { get; private set; }

        public WindSourceAndUnits WindSourceAndUnits { get; private set; }

        public FixedLandStationId? FixedLandStationId { get; private set; }

        public SmallDecimal Latitude { get; private set; }

        public SmallDecimal Longitude { get; private set; }

        public GlobeQuadrant Quadrant { get; private set; }

        public short MarsdenSquareNumber { get; private set; }

        public SmallDecimal StationElevationValue { get; private set; }

        public ElevationUnitAndAccuracy StationElevationUnitAndAccuracy { get; private set; }

        public Length? StationElevation
        {
            get
            {
                switch (StationElevationUnitAndAccuracy)
                {
                    case ElevationUnitAndAccuracy.MeterExcellent:
                    case ElevationUnitAndAccuracy.MeterGood:
                    case ElevationUnitAndAccuracy.MeterFair:
                    case ElevationUnitAndAccuracy.MeterPoor:
                        return (StationElevationValue, LengthUnit.Meter);
                    case ElevationUnitAndAccuracy.FootExcellent:
                    case ElevationUnitAndAccuracy.FootGood:
                    case ElevationUnitAndAccuracy.FootFair:
                    case ElevationUnitAndAccuracy.FootPoor:
                        return (StationElevationValue, LengthUnit.Foot);
                    default:
                        return null;
                }
            }
        }
    }
}
