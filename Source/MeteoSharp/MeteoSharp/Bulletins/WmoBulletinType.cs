using System;
using System.Collections.Generic;
using System.Text;

namespace MeteoSharp.Bulletins
{
    public enum WmoBulletinType : byte
    {
        Normal,
        Delayed,
        Correction,
        Amendment
    }
}
