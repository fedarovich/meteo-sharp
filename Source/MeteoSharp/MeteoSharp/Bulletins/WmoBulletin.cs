using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text;
using MeteoSharp.Time;

namespace MeteoSharp.Bulletins
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    [SuppressMessage("ReSharper", "ConvertToAutoProperty")]
    public readonly struct WmoBulletin
    {


        private readonly byte _t1;
        private readonly byte _t2;
        private readonly byte _a1;
        private readonly byte _a2;
        private readonly byte _ii;
        private readonly byte _reserved;
        private readonly WmoBulletinType _type;
        private readonly byte _bbbIndex;
        private readonly uint _cccc;
        private readonly DayHourMinute _time;
        private readonly string[] _reports;

        public char T1 => (char)_t1;
        public char T2 => (char)_t2;
        public char A1 => (char)_a1;
        public char A2 => (char)_a2;
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public byte ii => _ii;
        
        public WmoBulletinType Type => _type;
        public byte Index => _bbbIndex;
        public char IndexChar => (char)('A' + _bbbIndex);
        public bool IsLost => _bbbIndex == ('Y' - 'A');
        public bool IsCompiled => _bbbIndex == ('Z' - 'A');

        public unsafe string Location
        {
            get
            {
                fixed (void* p = &_cccc)
                {
                    return Encoding.ASCII.GetString((byte*) p, 4);
                }
            }
        }

        public DayHourMinute Time => _time;

        public IReadOnlyList<string> Reports => _reports;
    }
}
