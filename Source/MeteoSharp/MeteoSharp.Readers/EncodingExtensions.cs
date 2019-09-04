using System;
using System.Collections.Generic;
using System.Text;

namespace MeteoSharp.Readers
{
#if NETSTANDARD2_0
    internal static class EncodingExtensions
    {
        public static unsafe string GetString(this Encoding encoding, in ReadOnlySpan<byte> bytes)
        {
            if (bytes.IsEmpty)
                return string.Empty;

            fixed (byte* p = bytes)
            {
                return encoding.GetString(p, bytes.Length);
            }
        }
    }
#endif
}
