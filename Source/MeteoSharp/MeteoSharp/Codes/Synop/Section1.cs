using System;
using System.Collections.Generic;
using System.Text;

namespace MeteoSharp.Codes.Synop
{
    public class Section1
    {
        public PrecipationDataInclusion PrecipationDataInclusion { get; private set; }

        public StationOperationAndWeatherData StationOperationAndWeatherData { get; private set; }

        public LowestCloudBase LowestCloudBase { get; private set; }

        public HorizontalVisibilityAtSurface HorizontalVisibilityAtSurface { get; private set; }
    }
}
