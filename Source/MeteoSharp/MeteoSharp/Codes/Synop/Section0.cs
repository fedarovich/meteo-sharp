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

        public StationLocation? StationLocation { get; private set; }
    }
}
