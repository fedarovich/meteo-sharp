using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace MeteoSharp.Core
{
    [Serializable]
    public readonly struct SmallDecimal : IFormattable, 
        IEquatable<SmallDecimal>, IComparable<SmallDecimal>, 
        IEquatable<decimal>, IComparable<decimal>,
        IComparable
    {
        private const int CoefOffset = 4;
        private const int ExpMask = (1 << CoefOffset) - 1;

        private readonly int _value;

        private static readonly int[] PowersOfTen =
        {
            1,
            10,
            100,
            1000,
            10000,
            100000,
            1000000,
            10000000
        };

        private static readonly decimal[] DecimalPowersOfTen =
        {
            1e7m,
            1e6m,
            1e5m,
            1e4m,
            1e3m,
            1e2m,
            1e1m,
            1e0m,
            1e-1m,
            1e-2m,
            1e-3m,
            1e-4m,
            1e-5m,
            1e-6m,
            1e-7m,
            1e-8m,
            1e-9m,
            1e-10m,
            1e-11m,
            1e-12m,
            1e-13m,
            1e-14m,
            1e-15m,
            1e-16m,
            1e-17m,
            1e-18m,
            1e-19m,
            1e-20m
        };

        private byte Exp
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => unchecked((byte) (_value & ExpMask));
        }

        private int Coef
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _value >> CoefOffset;
        }

        public SmallDecimal(int value) : this(value, 0)
        {
        }

        public SmallDecimal(decimal value)
        {
            if (value >= 99_999_999.5m || value <= -99_999_999.5m)
                throw new OverflowException();

            if (TryGetValue(ref value, out _value))
                return;

            var abs = Math.Abs(value);
            for (int i = 0; i < DecimalPowersOfTen.Length; i++)
            {
                if (abs > DecimalPowersOfTen[i])
                {
                    value = decimal.Round(value, i, MidpointRounding.AwayFromZero);
                    if (TryGetValue(ref value, out _value))
                        break;
                }
            }

            static bool TryGetValue(ref decimal value, out int result)
            {
                ref readonly var layout = ref Unsafe.As<decimal, DecimalLayout>(ref value);
                byte exp = (byte)((layout.flags & 0x00FF0000) >> 16);
                if (layout.hi == 0 && layout.mid == 0 && unchecked((uint)layout.lo) <= 99_999_999 && exp < 16)
                {
                    int coef = layout.flags >= 0 ? layout.lo : -layout.lo;
                    result = unchecked((coef << CoefOffset) | exp);
                    return true;
                }

                result = default;
                return false;
            }
        }

        public SmallDecimal(int coef, byte exponent)
        {
            if (coef < -99_999_999 || coef > 99_999_999)
                throw new ArgumentOutOfRangeException(nameof(coef));
            if (exponent > 15)
                throw new ArgumentOutOfRangeException(nameof(exponent));

            _value = unchecked((coef << CoefOffset) | exponent);
        }


        public decimal ToDecimal()
        {
            var coef = Coef;
            bool neg = coef < 0;
            return new decimal(neg ? -coef : coef, 0, 0, neg, Exp);
        }

        #region Format

        public override string ToString() => ToString(null);

        public string ToString(IFormatProvider formatProvider) => ((IFormattable) this).ToString(null, formatProvider);
        
        string IFormattable.ToString(string format, IFormatProvider formatProvider)
        {
            var exp = Exp;
            var coef = Coef;
            var coefStr = coef.ToString(formatProvider);
            if (exp == 0)
                return coefStr;

            var len = coefStr.Length;
            var sep = NumberFormatInfo.GetInstance(formatProvider).NumberDecimalSeparator;

            if (coef >= 0)
            {
                if (len > exp)
                    return coefStr.Insert(coefStr.Length - exp, sep);

                return len < exp
                    ? string.Concat("0", sep, new string('0', -(len - exp)), coefStr)
                    : string.Concat("0", sep, coefStr);
            }

            if (len > exp + 1)
                return coefStr.Insert(coefStr.Length - exp, sep);

            var neg = NumberFormatInfo.GetInstance(formatProvider).NegativeSign;
            return len < exp + 1
                ? string.Concat(neg, "0", sep, new string('0', -(len - exp) + 1), coefStr.Substring(1))
                : string.Concat(neg, "0", sep, coefStr.Substring(1));
        }

        #endregion

        #region Equality

        public bool Equals(SmallDecimal other)
        {
            if (other.Exp == Exp)
                return _value.Equals(other._value);

            return ToDecimal().Equals(other.ToDecimal());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        bool IEquatable<decimal>.Equals(decimal other) => ToDecimal().Equals(other);

        public override bool Equals(object obj)
        {
            return obj is SmallDecimal other && Equals(other);
        }

        public override int GetHashCode()
        {
            return ToDecimal().GetHashCode();
        }

        public static bool operator ==(SmallDecimal left, SmallDecimal right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SmallDecimal left, SmallDecimal right)
        {
            return !left.Equals(right);
        }

        #endregion

        #region Comparison

        public int CompareTo(SmallDecimal other)
        {
            if (Exp == other.Exp)
                return _value.CompareTo(other._value);

            return ToDecimal().CompareTo(other.ToDecimal());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        int IComparable<decimal>.CompareTo(decimal other) => ToDecimal().CompareTo(other);

        public int CompareTo(object obj)
        {
            if (ReferenceEquals(null, obj)) return 1;
            return obj is SmallDecimal other ? CompareTo(other) : throw new ArgumentException($"Object must be of type {nameof(SmallDecimal)}");
        }

        public static bool operator <(SmallDecimal left, SmallDecimal right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator >(SmallDecimal left, SmallDecimal right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator <=(SmallDecimal left, SmallDecimal right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >=(SmallDecimal left, SmallDecimal right)
        {
            return left.CompareTo(right) >= 0;
        }

        #endregion

        #region Convertions

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator SmallDecimal(int value) => new SmallDecimal(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator SmallDecimal(decimal value) => new SmallDecimal(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator decimal(SmallDecimal value) => value.ToDecimal();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int(SmallDecimal value) => value.Exp > 7 ? 0 : value.Coef / PowersOfTen[value.Exp];

        #endregion

        #region Arithmetics

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SmallDecimal operator +(SmallDecimal x, SmallDecimal y) => x.ToDecimal() + y.ToDecimal();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SmallDecimal operator -(SmallDecimal x, SmallDecimal y) => x.ToDecimal() - y.ToDecimal();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SmallDecimal operator *(SmallDecimal x, SmallDecimal y) => x.ToDecimal() * y.ToDecimal();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SmallDecimal operator /(SmallDecimal x, SmallDecimal y) => x.ToDecimal() / y.ToDecimal();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SmallDecimal Add(SmallDecimal x, SmallDecimal y) => x + y;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SmallDecimal Subtract(SmallDecimal x, SmallDecimal y) => x - y;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SmallDecimal Multiply(SmallDecimal x, SmallDecimal y) => x * y;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SmallDecimal Divide(SmallDecimal x, SmallDecimal y) => x / y;

        #endregion

        private readonly struct DecimalLayout
        {
            public readonly int flags;
            public readonly int hi;
            public readonly int lo;
            public readonly int mid;
        }
    }
}
