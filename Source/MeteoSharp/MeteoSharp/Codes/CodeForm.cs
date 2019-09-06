using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using MeteoSharp.Attibutes;

namespace MeteoSharp.Codes
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public enum CodeForm
    {
        /// <summary>
        /// Invalid
        /// </summary>
        Invalid = 0,

        /// <summary>
        /// Report of surface observation from a fixed land station
        /// </summary>
        [CodeForm("FM 12", "SYNOP")] SYNOP = 12,

        /// <summary>
        /// Report of surface observation from a sea station
        /// </summary>
        [CodeForm("FM 13", "SHIP")] SHIP = 13,

        /// <summary>
        /// Report of surface observation from a mobile land station
        /// </summary>
        [CodeForm("FM 14", "SYNOP MOBIL")] SYNOP_MOBIL = 14,

        /// <summary>
        /// Aerodrome routine meteorological report (with or without trend
        /// forecast)
        /// </summary>
        [CodeForm("FM 15", "METAR")] METAR = 15,

        /// <summary>
        /// Aerodrome special meteorological report (with or without trend
        /// forecast)
        /// </summary>
        [CodeForm("FM 16", "SPECI")] SPECI = 16,

        /// <summary>
        /// Report of a buoy observation
        /// </summary>
        [CodeForm("FM 18", "BUOY")] BUOY = 18,

        /// <summary>
        /// Report of ground radar weather observation
        /// </summary>
        [CodeForm("FM 20", "RADOB")] RADOB = 20,

        /// <summary>
        /// Radiological data report (monitored on a routine basis and/or in case
        /// of accident)
        /// </summary>
        [CodeForm("FM 22", "RADREP")] RADREP = 22,

        /// <summary>
        /// Upper-wind report from a fixed land station
        /// </summary>
        [CodeForm("FM 32", "PILOT")] PILOT = 32,

        /// <summary>
        /// Upper-wind report from a sea station
        /// </summary>
        [CodeForm("FM 33", "PILOT SHIP")] PILOT_SHIP = 33,

        /// <summary>
        /// Upper-wind report from a mobile land station
        /// </summary>
        [CodeForm("FM 34", "PILOT MOBIL")] PILOT_MOBIL = 34,

        /// <summary>
        /// Upper-level pressure, temperature, humidity and wind report from a
        /// fixed land station
        /// </summary>
        [CodeForm("FM 35", "TEMP")] TEMP = 35,

        /// <summary>
        /// Upper-level pressure, temperature, humidity and wind report from a
        /// sea station
        /// </summary>
        [CodeForm("FM 36", "TEMP SHIP")] TEMP_SHIP = 36,

        /// <summary>
        /// Upper-level pressure, temperature, humidity and wind report from a
        /// sonde released by carrier balloons or aircraft
        /// </summary>
        [CodeForm("FM 37", "TEMP DROP")] TEMP_DROP = 37,

        /// <summary>
        /// Upper-level pressure, temperature, humidity and wind report from a
        /// mobile land station
        /// </summary>
        [CodeForm("FM 38", "TEMP MOBIL")] TEMP_MOBIL = 38,

        /// <summary>
        /// Upper-level temperature, wind and air density report from a land
        /// rocketsonde station
        /// </summary>
        [CodeForm("FM 39", "ROCOB")] ROCOB = 39,

        /// <summary>
        /// Upper-level temperature, wind and air density report from a
        /// rocketsonde station on a ship
        /// </summary>
        [CodeForm("FM 40", "ROCOB SHIP")] ROCOB_SHIP = 40,

        /// <summary>
        /// Upper-air report from an aircraft (other than weather reconnaissance aircraft)
        /// </summary>
        [CodeForm("FM 41", "CODAR")] CODAR = 41,

        /// <summary>
        /// Aircraft report (aircraft meteorological data relay)
        /// </summary>
        [CodeForm("FM 42", "AMDAR")] AMDAR = 42,

        /// <summary>
        /// Ice analysis
        /// </summary>
        [CodeForm("FM 44", "ICEAN")] ICEAN = 44,

        /// <summary>
        /// Analysis in full form
        /// </summary>
        [CodeForm("FM 45", "IAC")] IAC = 45,

        /// <summary>
        /// Analysis in abbreviated form
        /// </summary>
        [CodeForm("FM 46", "IAC FLEET")] IAC_FLEET = 46,

        /// <summary>
        /// Processed data in the form of grid-point values
        /// </summary>
        [CodeForm("FM 47", "GRID")] GRID = 47,

        /// <summary>
        /// Processed data in the form of grid-point values (abbreviated code form)
        /// </summary>
        [CodeForm("FM 49", "GRAF")] GRAF = 49,

        /// <summary>
        /// Forecast upper wind and temperature for aviation
        /// </summary>
        [CodeForm("FM 50", "WINTEM")] WINTEM = 50,

        /// <summary>
        /// Aerodrome forecast
        /// </summary>
        [CodeForm("FM 51", "TAF")] TAF = 51,

        /// <summary>
        /// Area forecast for aviation
        /// </summary>
        [CodeForm("FM 53", "ARFOR")] ARFOR = 53,

        /// <summary>
        /// Route forecast for aviation
        /// </summary>
        [CodeForm("FM 54", "ROFOR")] ROFOR = 54,

        /// <summary>
        /// Radiological trajectory dose forecast (defined time of arrival and
        /// location)
        /// </summary>
        [CodeForm("FM 57", "RADOF")] RADOF = 57,

        /// <summary>
        /// Forecast for shipping
        /// </summary>
        [CodeForm("FM 61", "MAFOR")] MAFOR = 61,

        /// <summary>
        /// Report of marine surface observation along a ship’s track
        /// </summary>
        [CodeForm("FM 62", "TRACKOB")] TRACKOB = 62,

        /// <summary>
        /// Report of bathythermal observation
        /// </summary>
        [CodeForm("FM 63", "BATHY")] BATHY = 63,

        /// <summary>
        /// Temperature, salinity and current report from a sea station
        /// </summary>
        [CodeForm("FM 64", "TESAC")] TESAC = 64,

        /// <summary>
        /// Report of spectral wave information from a sea station or from a
        /// remote platform (aircraft or satellite)
        /// </summary>
        [CodeForm("FM 65", "WAVEOB")] WAVEOB = 65,

        /// <summary>
        /// Report of hydrological observation from a hydrological station
        /// </summary>
        [CodeForm("FM 67", "HYDRA")] HYDRA = 67,

        /// <summary>
        /// Hydrological forecast
        /// </summary>
        [CodeForm("FM 68", "HYFOR")] HYFOR = 68,

        /// <summary>
        /// Report of monthly values from a land station
        /// </summary>
        [CodeForm("FM 71", "CLIMAT")] CLIMAT = 71,

        /// <summary>
        /// Report of monthly means and totals from an ocean weather station
        /// </summary>
        [CodeForm("FM 72", "CLIMAT SHIP")] CLIMAT_SHIP = 72,

        /// <summary>
        /// Report of monthly means for an oceanic area
        /// </summary>
        [CodeForm("FM 73", "NACLI")] NACLI = 73,
        /// <summary>
        /// Report of monthly means for an oceanic area
        /// </summary>
        [CodeForm("FM 73", "CLINP")] CLINP = 73,
        /// <summary>
        /// Report of monthly means for an oceanic area
        /// </summary>
        [CodeForm("FM 73", "SPCLI")] SPCLI = 73,
        /// <summary>
        /// Report of monthly means for an oceanic area
        /// </summary>
        [CodeForm("FM 73", "CLISA")] CLISA = 73,
        /// <summary>
        /// Report of monthly means for an oceanic area
        /// </summary>
        [CodeForm("FM 73", "INCLI")] INCLI = 73,

        /// <summary>
        /// Report of monthly aerological means from a land station
        /// </summary>
        [CodeForm("FM 75", "CLIMAT TEMP")] CLIMAT_TEMP = 75,

        /// <summary>
        /// Report of monthly aerological means from an ocean weather station
        /// </summary>
        [CodeForm("FM 76", "CLIMAT TEMP SHIP")] CLIMAT_TEMP_SHIP = 76,

        /// <summary>
        /// Synoptic report of bearings of sources of atmospherics
        /// </summary>
        [CodeForm("FM 81", "SFAZI")] SFAZI = 81,

        /// <summary>
        /// Synoptic report of the geographical location of sources of
        /// atmospherics
        /// </summary>
        [CodeForm("FM 82", "SFLOC")] SFLOC = 82,

        /// <summary>
        /// Detailed report of the distribution of sources of atmospherics by
        /// bearings for any period up to and including 24 hours
        /// </summary>
        [CodeForm("FM 83", "SFAZU")] SFAZU = 83,

        /// <summary>
        /// Report of synoptic interpretation of cloud data obtained by a
        /// meteorological satellite
        /// </summary>
        [CodeForm("FM 85", "SAREP")] SAREP = 85,

        /// <summary>
        /// Report of satellite remote upper-air soundings of pressure,
        /// temperature and humidity
        /// </summary>
        [CodeForm("FM 86", "SATEM")] SATEM = 86,

        /// <summary>
        /// Report of satellite clear radiance observations
        /// </summary>
        [CodeForm("FM 87", "SARAD")] SARAD = 87,

        /// <summary>
        /// Report of satellite observations of wind, surface temperature, cloud,
        /// humidity and radiation
        /// </summary>
        [CodeForm("FM 88", "SATOB")] SATOB = 88,

        /// <summary>
        /// General regularly distributed information in binary form
        /// </summary>
        [CodeForm("FM 92", "GRIB"), Binary] GRIB = 92,

        /// <summary>
        /// Binary universal form for the representation of meteorological data
        /// </summary>
        [CodeForm("FM 94", "BUFR"), Binary] BUFR = 94,

        /// <summary>
        /// Character form for the representation and exchange of data
        /// </summary>
        [CodeForm("FM 95", "CREX")] CREX = 95,
    }
}
