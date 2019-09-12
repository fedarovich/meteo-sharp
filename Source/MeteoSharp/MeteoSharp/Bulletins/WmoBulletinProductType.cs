using System;
using System.Collections.Generic;
using System.Text;

namespace MeteoSharp.Bulletins
{
    public enum WmoBulletinProductType : byte
    {
        DecodableText = 0,
        PlainText = 1,
        Binary = 2,
        Xml = 3
    }
}
