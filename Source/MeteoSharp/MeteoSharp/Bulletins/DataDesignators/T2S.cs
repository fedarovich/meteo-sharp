using System.Diagnostics.CodeAnalysis;
using MeteoSharp.Attibutes;
using static MeteoSharp.Codes.CodeForm;

namespace MeteoSharp.Bulletins.DataDesignators
{
    /// <summary>
    /// T2 Designator for T1 = S (Surface data)
    /// </summary>
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public enum T2S : byte
    {
        /// <summary>
        /// Invalid value
        /// </summary>
        Invalid = 0,

        /// <summary>
        /// Aviation routine reports
        /// </summary>
        [CodeForm(METAR)] AviationRoutineReports = (byte) 'A',

        /// <summary>
        /// Radar reports (Part A)
        /// </summary>
        [CodeForm(RADOB)] RadarReportsPartA = (byte) 'B',

        /// <summary>
        /// Radar reports (Part B)
        /// </summary>
        [CodeForm(RADOB)] RadarReportsPartB = (byte) 'C',

        /// <summary>
        /// Radar reports (Parts A &amp; B)
        /// </summary>
        [CodeForm(RADOB)] RadarReportsPartsAB = (byte) 'D',

        /// <summary>
        /// Seismic data
        /// </summary>
        [CodeForm("SEISMIC", "SEISMIC")] SeismicData = (byte) 'E',

        /// <summary>
        /// Atmospherics reports
        /// </summary>
        [CodeForm(SFAZI), CodeForm(SFLOC), CodeForm(SFAZU)] AtmosphericsReports = (byte) 'F',

        /// <summary>
        /// Radiological data report
        /// </summary>
        [CodeForm(RADREP)] RadiologicalDataReport = (byte) 'G',

        /// <summary>
        /// Reports from DCP stations
        /// </summary>
        [AnyFormat] ReportsFromDCPStations = (byte) 'H',

        /// <summary>
        /// Intermediate synoptic hour
        /// </summary>
        [CodeForm(SYNOP), CodeForm(SHIP)] IntermediateSynopticHour = (byte) 'I',

        /// <summary>
        /// Main synoptic hour
        /// </summary>
        [CodeForm(SYNOP), CodeForm(SHIP)] MainSynopticHour = (byte) 'M',

        /// <summary>
        /// Non-standard synoptic hour
        /// </summary>
        [CodeForm(SYNOP), CodeForm(SHIP)] NonStandardSynopticHour = (byte) 'N',

        /// <summary>
        /// Oceanographic data
        /// </summary>
        [CodeForm(BATHY), CodeForm(TESAC), CodeForm(TRACKOB)] OceanographicData = (byte) 'O',

        /// <summary>
        /// Special aviation weather reports
        /// </summary>
        [CodeForm(SPECI)] SpecialAviationWeatherReports = (byte) 'P',

        /// <summary>
        /// Hydrological (river) reports
        /// </summary>
        [CodeForm(HYDRA)] HydrologicalRiverReports = (byte) 'R',

        /// <summary>
        /// Drifting buoy reports
        /// </summary>
        [CodeForm(BUOY), CodeForm("FM 18", "DRIFTER")] DriftingBuoyReports = (byte) 'S',

        /// <summary>
        /// Sea ice
        /// </summary>
        [Text] SeaIce = (byte) 'T',

        /// <summary>
        /// Snow depth
        /// </summary>
        [Text] SnowDepth = (byte) 'U',

        /// <summary>
        /// Lake ice
        /// </summary>
        [Text] LakeIce = (byte) 'V',

        /// <summary>
        /// Wave information
        /// </summary>
        [CodeForm(WAVEOB)] WaveInformation = (byte) 'W',

        /// <summary>
        /// Miscellaneous
        /// </summary>
        [Text] Miscellaneous = (byte) 'X',

        /// <summary>
        /// Seismic waveform data
        /// </summary>
        [AnyFormat] SeismicWaveformData = (byte) 'Y',

        /// <summary>
        /// Sea-level data and deep-ocean tsunami data
        /// </summary>
        [AnyFormat(AlphanumericOnly = true)] SeaLevelDataAndDeepOceanTsunamiData = (byte) 'Z',
    }
}
