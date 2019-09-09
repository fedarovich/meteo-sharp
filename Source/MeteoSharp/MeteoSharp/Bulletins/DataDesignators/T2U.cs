using System.Diagnostics.CodeAnalysis;
using MeteoSharp.Attibutes;
using static MeteoSharp.Codes.CodeForm;

namespace MeteoSharp.Bulletins.DataDesignators
{
    /// <summary>
    /// T2 Designator for T1 = U (Upper-air data)
    /// </summary>
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public enum T2U : byte
    {
        /// <summary>
        /// Invalid value
        /// </summary>
        Invalid = 0,

        /// <summary>
        /// Aircraft reports
        /// </summary>
        [CodeForm(CODAR), CodeForm("ICAO", "AIREP")] AircraftReportsA = (byte)'A',

        /// <summary>
        /// Aircraft reports
        /// </summary>
        [CodeForm(AMDAR)] AircraftReportsD = (byte)'D',

        /// <summary>
        /// Upper-level pressure, temperature, humidity and wind (Part D)
        /// </summary>
        [CodeForm(TEMP), CodeForm(TEMP_SHIP), CodeForm(TEMP_MOBIL)] UpperLevelPressureTemperatureHumidityWindPartD = (byte)'E',

        /// <summary>
        /// Upper-level pressure, temperature, humidity and wind (Parts C and D) [National and bilateral option]
        /// </summary>
        [CodeForm(TEMP), CodeForm(TEMP_SHIP), CodeForm(TEMP_MOBIL)] UpperLevelPressureTemperatureHumidityWindPartsCD = (byte)'F',

        /// <summary>
        /// Upper wind (Part B)
        /// </summary>
        [CodeForm(PILOT), CodeForm(PILOT_SHIP), CodeForm(PILOT_MOBIL)] UpperWindPartB = (byte)'G',

        /// <summary>
        /// Upper wind (Part C)
        /// </summary>
        [CodeForm(PILOT), CodeForm(PILOT_SHIP), CodeForm(PILOT_MOBIL)] UpperWindPartC = (byte)'H',

        /// <summary>
        /// Upper wind (Parts A and B) [National and bilateral option]
        /// </summary>
        [CodeForm(PILOT), CodeForm(PILOT_SHIP), CodeForm(PILOT_MOBIL)] UpperWindPartsAB = (byte)'I',

        /// <summary>
        /// Upper-level pressure, temperature, humidity and wind (Part B)
        /// </summary>
        [CodeForm(TEMP), CodeForm(TEMP_SHIP), CodeForm(TEMP_MOBIL)] UpperLevelPressureTemperatureHumidityWindPartB = (byte)'K',

        /// <summary>
        /// Upper-level pressure, temperature, humidity and wind (Part C)
        /// </summary>
        [CodeForm(TEMP), CodeForm(TEMP_SHIP), CodeForm(TEMP_MOBIL)] UpperLevelPressureTemperatureHumidityWindPartC = (byte)'L',

        /// <summary>
        /// Upper-level pressure, temperature, humidity and wind (Parts A and B) [National and bilateral option]
        /// </summary>
        [CodeForm(TEMP), CodeForm(TEMP_SHIP), CodeForm(TEMP_MOBIL)] UpperLevelPressureTemperatureHumidityWindPartsAB = (byte)'M',

        /// <summary>
        /// Rocketsonde reports
        /// </summary>
        [CodeForm(ROCOB), CodeForm(ROCOB_SHIP)] RocketsondeReports = (byte)'N',

        /// <summary>
        /// Upper wind (Part A)
        /// </summary>
        [CodeForm(PILOT), CodeForm(PILOT_SHIP), CodeForm(PILOT_MOBIL)] UpperWindPartA = (byte)'P',

        /// <summary>
        /// Upper wind (Part D)
        /// </summary>
        [CodeForm(PILOT), CodeForm(PILOT_SHIP), CodeForm(PILOT_MOBIL)] UpperWindPartD = (byte)'Q',

        /// <summary>
        /// Aircraft report
        /// </summary>
        [CodeForm("NATIONAL", "RECCO")] AircraftReportR = (byte)'R',

        /// <summary>
        /// Upper-level pressure, temperature, humidity and wind (Part A)
        /// </summary>
        [CodeForm(TEMP), CodeForm(TEMP_SHIP), CodeForm(TEMP_MOBIL)] UpperLevelPressureTemperatureHumidityWindPartA = (byte)'S',

        /// <summary>
        /// Aircraft report
        /// </summary>
        [CodeForm(CODAR)] AircraftReportT = (byte)'T',

        /// <summary>
        /// Miscellaneous
        /// </summary>
        [Text] Miscellaneous = (byte)'X',

        /// <summary>
        /// Upper wind (Parts C and D) [National and bilateral option]
        /// </summary>
        [CodeForm(PILOT), CodeForm(PILOT_SHIP), CodeForm(PILOT_MOBIL)] UpperWindPartsCD = (byte)'Y',

        /// <summary>
        /// Upper-level pressure, temperature, humidity
        /// and wind from a sonde released by carrier
        /// balloon or aircraft (Parts A, B, C, D)
        /// </summary>
        [CodeForm(TEMP_DROP)] UpperLevelPressureTemperatureHumidityWindFromSondeReleasedByBalloonOrAircraft = (byte)'Z',
    }
}
