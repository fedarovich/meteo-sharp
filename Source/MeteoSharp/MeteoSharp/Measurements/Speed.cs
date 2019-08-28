using System;
using System.Collections.Generic;

namespace MeteoSharp.Measurements
{
    /// <summary>
    /// Represents the Speed.
    /// </summary>
    public readonly struct Speed : IMeasurement<Speed, SpeedUnit>
    {
        #region Constants

        /// <summary>
        /// Gets the Speed of 1 MeterPerSecond.
        /// </summary>
        public static Speed MeterPerSecond { get; } = (1, SpeedUnit.MeterPerSecond);

        /// <summary>
        /// Gets the Speed of 1 KilometerPerHour.
        /// </summary>
        public static Speed KilometerPerHour { get; } = (1, SpeedUnit.KilometerPerHour);

        /// <summary>
        /// Gets the Speed of 1 MilePerHour.
        /// </summary>
        public static Speed MilePerHour { get; } = (1, SpeedUnit.MilePerHour);

        /// <summary>
        /// Gets the Speed of 1 Knot.
        /// </summary>
        public static Speed Knot { get; } = (1, SpeedUnit.Knot);

        private static readonly ConversionTable<Speed, SpeedUnit> Conversions =
            new ConversionTable<Speed, SpeedUnit>
            {
                [from: SpeedUnit.KilometerPerHour, to: SpeedUnit.MeterPerSecond] = 0.277778m,
                [from: SpeedUnit.MilePerHour,      to: SpeedUnit.MeterPerSecond] = 0.44704m,
                [from: SpeedUnit.Knot,             to: SpeedUnit.MeterPerSecond] = 0.514444m,
                [from: SpeedUnit.MilePerHour,      to: SpeedUnit.KilometerPerHour] = 1.609344m,
                [from: SpeedUnit.Knot,             to: SpeedUnit.KilometerPerHour] = 1.852m,
                [from: SpeedUnit.MilePerHour,      to: SpeedUnit.Knot] =0.868976m,

            };

        private static readonly string[] Abbreviations = { "m/s", "km/h", "mph", "kn" };

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Speed"/> structure.
        /// </summary>
        /// <param name="value">The Speed value.</param>
        /// <param name="unit">The Speed unit.</param>
        public Speed(decimal value, SpeedUnit unit)
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
        public SpeedUnit Unit { get; }

        /// <summary>
        /// Gets the value in the specified <paramref name="unit"/>s.
        /// </summary>
        public decimal ValueIn(SpeedUnit unit) => Conversions.ConvertValue(this, unit);

        /// <summary>
        /// Gets the <see cref="Speed"/> in the specified <paramref name="unit"/>s.
        /// </summary>
        public Speed In(SpeedUnit unit) => Conversions.Convert(this, unit);

        public override string ToString() => $"{Value} {Abbreviations[(int)Unit]}";

        public void Deconstruct(out decimal value, out SpeedUnit unit)
        {
            value = Value;
            unit = Unit;
        }

        #region Equality

        public bool Equals(Speed other)
        {
            if (Unit == other.Unit)
                return Value == other.Value;

            return ValueIn(SpeedUnit.MeterPerSecond) == other.ValueIn(SpeedUnit.MeterPerSecond);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Speed && Equals((Speed)obj);
        }

        public override int GetHashCode()
        {
            return ValueIn(SpeedUnit.MeterPerSecond).GetHashCode();
        }

        #endregion

        #region Comparison

        public int CompareTo(Speed other)
        {
            if (Unit == other.Unit)
                return Value.CompareTo(other.Value);

            return ValueIn(SpeedUnit.MeterPerSecond).CompareTo(other.ValueIn(SpeedUnit.MeterPerSecond));
        }


        public int CompareTo(object obj)
        {
            if (ReferenceEquals(null, obj)) return 1;
            if (!(obj is Speed)) throw new ArgumentException($"Object must be of type {nameof(Speed)}");
            return CompareTo((Speed)obj);
        }

        #endregion

        #region Operators

        public static implicit operator Speed((decimal value, SpeedUnit unit) valueWithUnit)
        {
            return new Speed(valueWithUnit.value, valueWithUnit.unit);
        }

        public static implicit operator (decimal value, SpeedUnit unit) (Speed speed)
        {
            return (speed.Value, speed.Unit);
        }

        public static bool operator ==(Speed left, Speed right) => left.Equals(right);

        public static bool operator !=(Speed left, Speed right) => !left.Equals(right);

        public static bool operator <(Speed left, Speed right) => left.CompareTo(right) < 0;

        public static bool operator >(Speed left, Speed right) => left.CompareTo(right) > 0;

        public static bool operator <=(Speed left, Speed right) => left.CompareTo(right) <= 0;

        public static bool operator >=(Speed left, Speed right) => left.CompareTo(right) >= 0;

        public static Speed operator +(Speed l1, Speed l2) => new Speed(l1.Value + l2.ValueIn(l1.Unit), l1.Unit);

        public static Speed operator -(Speed l1, Speed l2) => new Speed(l1.Value - l2.ValueIn(l1.Unit), l1.Unit);

        public static Speed operator *(decimal multiplier, Speed speed) => new Speed(multiplier * speed.Value, speed.Unit);

        public static Speed operator *(Speed speed, decimal multiplier) => new Speed(multiplier * speed.Value, speed.Unit);

        public static Speed operator /(Speed speed, decimal divisor) => new Speed(speed.Value / divisor, speed.Unit);

        #endregion
    }
}
