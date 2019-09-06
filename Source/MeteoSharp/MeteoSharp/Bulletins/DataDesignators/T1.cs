using System.Diagnostics.CodeAnalysis;
using MeteoSharp.Attibutes;
using MeteoSharp.Codes;
using static MeteoSharp.Codes.CodeForm;

namespace MeteoSharp.Bulletins.DataDesignators
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public enum T1 : byte
    {
        /// <summary>
        /// Invalid value
        /// </summary>
        Invalid = 0,

        /// <summary>
        /// Analyses
        /// </summary>
        Analyses = (byte)'A',
        /// <summary>
        /// Addressed message
        /// </summary>
        AddressedMessage = (byte)'B',
        /// <summary>
        /// Climatic data
        /// </summary>
        ClimaticData = (byte)'C',
        /// <summary>
        /// Grid point information (GRID)
        /// </summary>
        GridPointInformationD = (byte)'D',
        /// <summary>
        /// Satellite imagery
        /// </summary>
        SatelliteImagery = (byte)'E',
        /// <summary>
        /// Forecasts
        /// </summary>
        Forecasts = (byte)'F',
        /// <summary>
        /// Grid point information (GRID)
        /// </summary>
        GridPointInformationG = (byte)'G',
        /// <summary>
        /// Grid point information (GRIB)
        /// </summary>
        [Binary, CodeForm(GRIB)] GridPointInformationH = (byte)'H',
        /// <summary>
        /// Observational data (Binary coded) – BUFR
        /// </summary>
        [Binary, CodeForm(BUFR)] ObservationData = (byte)'I',
        /// <summary>
        /// Forecast information (Binary coded) – BUFR
        /// </summary>
        [Binary, CodeForm(BUFR)] ForecastInformation = (byte)'J',
        /// <summary>
        /// CREX
        /// </summary>
        [CodeForm(CodeForm.CREX)] CREX = (byte)'K',
        AviationInformationXml = (byte)'L',

        /// <summary>
        /// Notices
        /// </summary>
        Notices = (byte)'N',
        /// <summary>
        /// Oceanographic information (GRIB)
        /// </summary>
        [Binary, CodeForm(GRIB)] OceanographicInformation = (byte)'O',
        /// <summary>
        /// Pictorial information (Binary coded)
        /// </summary>
        [Binary] PictorialInformation = (byte)'P',
        /// <summary>
        /// Pictorial information regional (Binary coded)
        /// </summary>
        [Binary] PictorialInformationRegional = (byte)'Q',

        /// <summary>
        /// Surface data
        /// </summary>
        SurfaceData = (byte)'S',
        /// <summary>
        /// Satellite data
        /// </summary>
        SatelliteData = (byte)'T',
        /// <summary>
        /// Upper-air data
        /// </summary>
        UpperAirData = (byte)'U',
        /// <summary>
        /// National data
        /// </summary>
        NationalDate = (byte)'V',
        /// <summary>
        /// Warnings
        /// </summary>
        Warnings = (byte)'W',
        /// <summary>
        /// Common Alert Protocol (CAP) messages
        /// </summary>
        CommonAlertProtocolMessages = (byte)'X',
        /// <summary>
        /// GRIB regional use
        /// </summary>
        [Binary, CodeForm(GRIB)] GRIBRegionalUse = (byte)'Y'
    }
}
