using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using EnumsNET;
using MeteoSharp.Attibutes;
using MeteoSharp.Bulletins.DataDesignators;
using MeteoSharp.Codes;

namespace MeteoSharp.Bulletins
{
    public static class WmoBulletinProductTypesHelper
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static WmoBulletinProductTypes GetProductTypes(in this WmoBulletin bulletin) =>
            GetProductTypes((byte) bulletin.T1, (byte) bulletin.T2);

        public static WmoBulletinProductTypes GetProductTypes(byte t1, byte t2)
        {
            WmoBulletinProductTypes productTypes = default;
            ProcessEnum((T1)t1);
            if (productTypes != default)
                return productTypes;

            if (productTypes != default)
                return productTypes;

            switch ((T1)t1)
            {
                case T1.Analyses:
                    ProcessEnum((T2A)t2);
                    break;
                case T1.ClimaticData:
                    ProcessEnum((T2C)t2);
                    break;
                case T1.Forecasts:
                    ProcessEnum((T2F)t2);
                    break;
                case T1.Notices:
                    ProcessEnum((T2N)t2);
                    break;
                case T1.SurfaceData:
                    ProcessEnum((T2S)t2);
                    if ((T2S) t2 == T2S.SeismicData)
                        productTypes |= WmoBulletinProductTypes.DecodableText;
                    break;
                case T1.SatelliteData:
                    ProcessEnum((T2T)t2);
                    break;
                case T1.UpperAirData:
                    ProcessEnum((T2U)t2);
                    break;
                case T1.Warnings:
                    ProcessEnum((T2W)t2);
                    break;
            }

            return productTypes;

            void ProcessEnum<T>(T value) where T : struct, Enum
            {
                var attributes = value.GetAttributes()?.GetAll<FormatAttribute>().ToArray() ?? Array.Empty<FormatAttribute>();
                foreach (var attribute in attributes)
                {
                    switch (attribute)
                    {
                        case BinaryAttribute _:
                            productTypes |= WmoBulletinProductTypes.Binary;
                            break;
                        case TextAttribute _:
                            productTypes |= WmoBulletinProductTypes.PlainText;
                            break;
                        case XmlAttribute _:
                            productTypes |= WmoBulletinProductTypes.Xml;
                            break;
                        case AnyFormatAttribute any when (any.AlphanumericOnly):
                            productTypes |= WmoBulletinProductTypes.PlainText | WmoBulletinProductTypes.DecodableText;
                            break;
                        case AnyFormatAttribute _:
                            productTypes |= WmoBulletinProductTypes.Any;
                            break;
                        case CodeFormAttribute cf when cf.StandardCodeForm != CodeForm.Invalid:
                            productTypes |= cf.StandardCodeForm.GetAttributes()?.Has<BinaryAttribute>() ?? false
                                ? WmoBulletinProductTypes.Binary
                                : WmoBulletinProductTypes.DecodableText;
                            break;
                    }
                }
            }
        }
    }
}
