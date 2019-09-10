using System;
using System.Linq;
using System.Runtime.CompilerServices;
using EnumsNET;
using MeteoSharp.Attibutes;
using MeteoSharp.Bulletins.DataDesignators;
using MeteoSharp.Codes;

namespace MeteoSharp.Bulletins
{
    public static class WmoBulletinProductTypeHelper
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static WmoBulletinProductType GetProductType(in this WmoBulletin bulletin) =>
            GetProductType((byte) bulletin.T1, (byte) bulletin.T2);

        public static WmoBulletinProductType GetProductType(byte t1, byte t2)
        {
            WmoBulletinProductType productType = default;
            ProcessEnum((T1)t1);
            if (productType != default)
                return productType;

            if (productType != default)
                return productType;

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
                        productType |= WmoBulletinProductType.DecodableText;
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

            return productType;

            void ProcessEnum<T>(T value) where T : struct, Enum
            {
                var attributes = value.GetAttributes()?.GetAll<FormatAttribute>().ToArray() ?? Array.Empty<FormatAttribute>();
                foreach (var attribute in attributes)
                {
                    switch (attribute)
                    {
                        case BinaryAttribute _:
                            productType |= WmoBulletinProductType.Binary;
                            break;
                        case TextAttribute _:
                            productType |= WmoBulletinProductType.PlainText;
                            break;
                        case XmlAttribute _:
                            productType |= WmoBulletinProductType.Xml;
                            break;
                        case AnyFormatAttribute any when (any.AlphanumericOnly):
                            productType |= WmoBulletinProductType.PlainText | WmoBulletinProductType.DecodableText;
                            break;
                        case AnyFormatAttribute _:
                            productType |= WmoBulletinProductType.Any;
                            break;
                        case CodeFormAttribute cf when cf.StandardCodeForm != CodeForm.Invalid:
                            productType |= cf.StandardCodeForm.GetAttributes()?.Has<BinaryAttribute>() ?? false
                                ? WmoBulletinProductType.Binary
                                : WmoBulletinProductType.DecodableText;
                            break;
                    }
                }
            }
        }
    }
}
