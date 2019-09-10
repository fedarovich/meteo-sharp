using System;
using System.Collections.Generic;
using System.Text;

namespace MeteoSharp.Bulletins
{
    [Flags]
    public enum WmoBulletinProductType : byte
    {
        Unknown = 0,
        DecodableText = 0x01,
        PlainText = 0x02,
        Binary = 0x04,
        Xml = 0x08,
        Any = 0x0F
    }
}
