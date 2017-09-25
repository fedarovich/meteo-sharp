using System;
using System.Collections.Generic;

namespace MeteoSharp.Measurements
{
    /// <summary>
    /// Represents the Length.
    /// </summary>
#if NETSTANDARD2_0
    [Serializable]
#endif
    public struct Length : IMeasurement<Length, LengthUnit>
    {
        #region Constants

        /// <summary>
        /// Gets the length of 1 meter.
        /// </summary>
        public static Length Meter { get; } = (1, LengthUnit.Meter);

        /// <summary>
        /// Gets the length of 1 kilometer.
        /// </summary>
        public static Length Kilometer { get; } = (1, LengthUnit.Kilometer);

        /// <summary>
        /// Gets the length of 1 foot.
        /// </summary>
        public static Length Foot { get; } = (1, LengthUnit.Foot);

        /// <summary>
        /// Gets the length of 1 statute mile.
        /// </summary>
        public static Length StatuteMile { get; } = (1, LengthUnit.StatuteMile);

        /// <summary>
        /// Gets the length of 1 nautical mile.
        /// </summary>
        public static Length NauticalMile { get; } = (1, LengthUnit.NauticalMile);

        private static readonly ConversionTable<Length, LengthUnit> Conversions =
            new ConversionTable<Length, LengthUnit>
            {
                [from: LengthUnit.Kilometer,    to: LengthUnit.Meter       ] = 1000m,
                [from: LengthUnit.Foot,         to: LengthUnit.Meter       ] = 0.3048m,
                [from: LengthUnit.StatuteMile,  to: LengthUnit.Meter       ] = 1609.344m,
                [from: LengthUnit.NauticalMile, to: LengthUnit.Meter       ] = 1852m,
                [from: LengthUnit.Foot,         to: LengthUnit.Kilometer   ] = 0.0003048m,
                [from: LengthUnit.StatuteMile,  to: LengthUnit.Kilometer   ] = 1.609344m,
                [from: LengthUnit.NauticalMile, to: LengthUnit.Kilometer   ] = 1.852m,
                [from: LengthUnit.StatuteMile,  to: LengthUnit.Foot        ] = 5280m,
                [from: LengthUnit.NauticalMile, to: LengthUnit.Foot        ] = 6076.1155m,
                [from: LengthUnit.StatuteMile,  to: LengthUnit.NauticalMile] = 0.86897624m
            };

        private static readonly string[] Abbreviations = {"m", "km", "ft", "mi", "NM"};

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Length"/> structure.
        /// </summary>
        /// <param name="value">The length value.</param>
        /// <param name="unit">The length unit.</param>
        public Length(decimal value, LengthUnit unit)
        {
            Value = value;
            Unit = unit;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        public decimal Value { get; }

        /// <summary>
        /// Gets the unit.
        /// </summary>
        public LengthUnit Unit { get; }

        /// <summary>
        /// Gets the value in the specified <paramref name="unit"/>s.
        /// </summary>
        public decimal ValueIn(LengthUnit unit) => Conversions.ConvertValue(this, unit);

        /// <summary>
        /// Gets the <see cref="Length"/> in the specified <paramref name="unit"/>s.
        /// </summary>
        public Length In(LengthUnit unit) => Conversions.Convert(this, unit);

        public override string ToString() => $"{Value} {Abbreviations[(int) Unit]}";

        #region Equality

        public bool Equals(Length other)
        {
            if (Unit == other.Unit)
                return Value == other.Value;

            return ValueIn(LengthUnit.Meter) == other.ValueIn(LengthUnit.Meter);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Length && Equals((Length)obj);
        }

        public override int GetHashCode()
        {
            return ValueIn(LengthUnit.Meter).GetHashCode();
        }

        #endregion

        #region Comparison

        public int CompareTo(Length other)
        {
            if (Unit == other.Unit)
                return Value.CompareTo(other.Value);

            return ValueIn(LengthUnit.Meter).CompareTo(other.ValueIn(LengthUnit.Meter));
        }


        public int CompareTo(object obj)
        {
            if (ReferenceEquals(null, obj)) return 1;
            if (!(obj is Length)) throw new ArgumentException($"Object must be of type {nameof(Length)}");
            return CompareTo((Length) obj);
        }

        #endregion

        #region Operators

        public static implicit operator Length((decimal value, LengthUnit unit) valueWithUnit)
        {
            return new Length(valueWithUnit.value, valueWithUnit.unit);
        }

        public static implicit operator (decimal value, LengthUnit unit) (Length length)
        {
            return (length.Value, length.Unit);
        }

        public static bool operator ==(Length left, Length right) => left.Equals(right);

        public static bool operator !=(Length left, Length right) => !left.Equals(right);

        public static bool operator <(Length left, Length right) => left.CompareTo(right) < 0;

        public static bool operator >(Length left, Length right) => left.CompareTo(right) > 0;

        public static bool operator <=(Length left, Length right) => left.CompareTo(right) <= 0;

        public static bool operator >=(Length left, Length right) => left.CompareTo(right) >= 0;

        public static Length operator +(Length l1, Length l2) => new Length(l1.Value + l2.ValueIn(l1.Unit), l1.Unit);

        public static Length operator -(Length l1, Length l2) => new Length(l1.Value - l2.ValueIn(l1.Unit), l1.Unit);

        public static Length operator *(decimal multiplier, Length length) => new Length(multiplier * length.Value, length.Unit);

        public static Length operator *(Length length, decimal multiplier) => new Length(multiplier * length.Value, length.Unit);

        public static Length operator /(Length length, decimal divisor) => new Length(length.Value / divisor, length.Unit);

        #endregion
    }
}
