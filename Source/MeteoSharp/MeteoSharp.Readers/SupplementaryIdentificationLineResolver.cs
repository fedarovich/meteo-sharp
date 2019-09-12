using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace MeteoSharp.Readers
{
    public delegate string SupplementaryIdentificationLineResolver(ref ReadOnlySequence<byte> report, byte t1, byte t2);
}
