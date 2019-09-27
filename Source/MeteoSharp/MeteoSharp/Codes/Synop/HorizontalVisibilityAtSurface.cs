using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MeteoSharp.Codes.Synop
{
    /// <summary>
    /// Code table 4377: Horizontal visibility at surface; Visibility towards the sea
    /// </summary>
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public enum HorizontalVisibilityAtSurface
    {
        /// <summary>
        /// Less than 0.1 km
        /// </summary>
        LessThan0_1km = 0,

        /// <summary>
        /// 0.1 km
        /// </summary>
        _0_1km = 1,

        /// <summary>
        /// 0.2 km
        /// </summary>
        _0_2km = 2,

        /// <summary>
        /// 0.3 km
        /// </summary>
        _0_3km = 3,

        /// <summary>
        /// 0.4 km
        /// </summary>
        _0_4km = 4,

        /// <summary>
        /// 0.5 km
        /// </summary>
        _0_5km = 5,

        /// <summary>
        /// 0.6 km
        /// </summary>
        _0_6km = 6,

        /// <summary>
        /// 0.7 km
        /// </summary>
        _0_7km = 7,

        /// <summary>
        /// 0.8 km
        /// </summary>
        _0_8km = 8,

        /// <summary>
        /// 0.9 km
        /// </summary>
        _0_9km = 9,

        /// <summary>
        /// 1 km
        /// </summary>
        _1_0km = 10,

        /// <summary>
        /// 1.1 km
        /// </summary>
        _1_1km = 11,

        /// <summary>
        /// 1.2 km
        /// </summary>
        _1_2km = 12,

        /// <summary>
        /// 1.3 km
        /// </summary>
        _1_3km = 13,

        /// <summary>
        /// 1.4 km
        /// </summary>
        _1_4km = 14,

        /// <summary>
        /// 1.5 km
        /// </summary>
        _1_5km = 15,

        /// <summary>
        /// 1.6 km
        /// </summary>
        _1_6km = 16,

        /// <summary>
        /// 1.7 km
        /// </summary>
        _1_7km = 17,

        /// <summary>
        /// 1.8 km
        /// </summary>
        _1_8km = 18,

        /// <summary>
        /// 1.9 km
        /// </summary>
        _1_9km = 19,

        /// <summary>
        /// 2 km
        /// </summary>
        _2_0km = 20,

        /// <summary>
        /// 2.1 km
        /// </summary>
        _2_1km = 21,

        /// <summary>
        /// 2.2 km
        /// </summary>
        _2_2km = 22,

        /// <summary>
        /// 2.3 km
        /// </summary>
        _2_3km = 23,

        /// <summary>
        /// 2.4 km
        /// </summary>
        _2_4km = 24,

        /// <summary>
        /// 2.5 km
        /// </summary>
        _2_5km = 25,

        /// <summary>
        /// 2.6 km
        /// </summary>
        _2_6km = 26,

        /// <summary>
        /// 2.7 km
        /// </summary>
        _2_7km = 27,

        /// <summary>
        /// 2.8 km
        /// </summary>
        _2_8km = 28,

        /// <summary>
        /// 2.9 km
        /// </summary>
        _2_9km = 29,

        /// <summary>
        /// 3 km
        /// </summary>
        _3_0km = 30,

        /// <summary>
        /// 3.1 km
        /// </summary>
        _3_1km = 31,

        /// <summary>
        /// 3.2 km
        /// </summary>
        _3_2km = 32,

        /// <summary>
        /// 3.3 km
        /// </summary>
        _3_3km = 33,

        /// <summary>
        /// 3.4 km
        /// </summary>
        _3_4km = 34,

        /// <summary>
        /// 3.5 km
        /// </summary>
        _3_5km = 35,

        /// <summary>
        /// 3.6 km
        /// </summary>
        _3_6km = 36,

        /// <summary>
        /// 3.7 km
        /// </summary>
        _3_7km = 37,

        /// <summary>
        /// 3.8 km
        /// </summary>
        _3_8km = 38,

        /// <summary>
        /// 3.9 km
        /// </summary>
        _3_9km = 39,

        /// <summary>
        /// 4 km
        /// </summary>
        _4_0km = 40,

        /// <summary>
        /// 4.1 km
        /// </summary>
        _4_1km = 41,

        /// <summary>
        /// 4.2 km
        /// </summary>
        _4_2km = 42,

        /// <summary>
        /// 4.3 km
        /// </summary>
        _4_3km = 43,

        /// <summary>
        /// 4.4 km
        /// </summary>
        _4_4km = 44,

        /// <summary>
        /// 4.5 km
        /// </summary>
        _4_5km = 45,

        /// <summary>
        /// 4.6 km
        /// </summary>
        _4_6km = 46,

        /// <summary>
        /// 4.7 km
        /// </summary>
        _4_7km = 47,

        /// <summary>
        /// 4.8 km
        /// </summary>
        _4_8km = 48,

        /// <summary>
        /// 4.9 km
        /// </summary>
        _4_9km = 49,

        /// <summary>
        /// 5 km
        /// </summary>
        _5_0km = 50,

        /// <summary>
        /// 6 km
        /// </summary>
        _6km = 56,

        /// <summary>
        /// 7 km
        /// </summary>
        _7km = 57,

        /// <summary>
        /// 8 km
        /// </summary>
        _8km = 58,

        /// <summary>
        /// 9 km
        /// </summary>
        _9km = 59,

        /// <summary>
        /// 10 km
        /// </summary>
        _10km = 60,

        /// <summary>
        /// 11 km
        /// </summary>
        _11km = 61,

        /// <summary>
        /// 12 km
        /// </summary>
        _12km = 62,

        /// <summary>
        /// 13 km
        /// </summary>
        _13km = 63,

        /// <summary>
        /// 14 km
        /// </summary>
        _14km = 64,

        /// <summary>
        /// 15 km
        /// </summary>
        _15km = 65,

        /// <summary>
        /// 16 km
        /// </summary>
        _16km = 66,

        /// <summary>
        /// 17 km
        /// </summary>
        _17km = 67,

        /// <summary>
        /// 18 km
        /// </summary>
        _18km = 68,

        /// <summary>
        /// 19 km
        /// </summary>
        _19km = 69,

        /// <summary>
        /// 20 km
        /// </summary>
        _20km = 70,

        /// <summary>
        /// 21 km
        /// </summary>
        _21km = 71,

        /// <summary>
        /// 22 km
        /// </summary>
        _22km = 72,

        /// <summary>
        /// 23 km
        /// </summary>
        _23km = 73,

        /// <summary>
        /// 24 km
        /// </summary>
        _24km = 74,

        /// <summary>
        /// 25 km
        /// </summary>
        _25km = 75,

        /// <summary>
        /// 26 km
        /// </summary>
        _26km = 76,

        /// <summary>
        /// 27 km
        /// </summary>
        _27km = 77,

        /// <summary>
        /// 28 km
        /// </summary>
        _28km = 78,

        /// <summary>
        /// 29 km
        /// </summary>
        _29km = 79,

        /// <summary>
        /// 30 km
        /// </summary>
        _30km = 80,

        /// <summary>
        /// 35 km
        /// </summary>
        _35km = 81,

        /// <summary>
        /// 40 km
        /// </summary>
        _40km = 82,

        /// <summary>
        /// 45 km
        /// </summary>
        _45km = 83,

        /// <summary>
        /// 50 km
        /// </summary>
        _50km = 84,

        /// <summary>
        /// 55 km
        /// </summary>
        _55km = 85,

        /// <summary>
        /// 60 km
        /// </summary>
        _60km = 86,

        /// <summary>
        /// 65 km
        /// </summary>
        _65km = 87,

        /// <summary>
        /// 70 km
        /// </summary>
        _70km = 88,

        /// <summary>
        /// More than 70 km
        /// </summary>
        MoreThan70km = 89,

        /// <summary>
        /// Less than 0.05 km
        /// </summary>
        Sea_LessThan0_05km = 90,

        /// <summary>
        /// 0.05 km
        /// </summary>
        Sea_0_05kmAtSea = 91,

        /// <summary>
        /// 0.2 km
        /// </summary>
        Sea_0_2km = 92,

        /// <summary>
        /// 0.5 km
        /// </summary>
        Sea_0_5km = 93,

        /// <summary>
        /// 1 km
        /// </summary>
        Sea_1km = 94,

        /// <summary>
        /// 2 km
        /// </summary>
        Sea_2km = 95,

        /// <summary>
        /// 4 km
        /// </summary>
        Sea_4km = 96,

        /// <summary>
        /// 10 km
        /// </summary>
        Sea_10km = 97,

        /// <summary>
        /// 20 km
        /// </summary>
        Sea_20km = 98,

        /// <summary>
        /// More than 50 km
        /// </summary>
        Sea_MoreThan50km = 99
    }
}
