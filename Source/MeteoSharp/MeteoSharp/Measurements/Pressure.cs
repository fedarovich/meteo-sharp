using System;
using System.Collections.Generic;
using MeteoSharp.Core;

namespace MeteoSharp.Measurements
{
    /// <summary>
    /// Represents the Length.
    /// </summary>
    public readonly struct Pressure : IMeasurement<Pressure, PressureUnit>
    {
        #region Constants

        /// <summary>
        /// Gets the Pressure of 1 Pascal.
        /// </summary>
        public static Pressure Pascal { get; } = (1, PressureUnit.Pascal);

        /// <summary>
        /// Gets the Pressure of 1 HektoPascal.
        /// </summary>
        public static Pressure HektoPascal { get; } = (1, PressureUnit.HektoPascal);

        /// <summary>
        /// Gets the Pressure of 1 MillimeterOfMercury.
        /// </summary>
        public static Pressure MillimeterOfMercury { get; } = (1, PressureUnit.MillimeterOfMercury);

        /// <summary>
        /// Gets the Pressure of 1 InchOfMercury.
        /// </summary>
        public static Pressure InchOfMercury { get; } = (1, PressureUnit.InchOfMercury);

        private static readonly ConversionTable<Pressure, PressureUnit> Conversions =
            new ConversionTable<Pressure, PressureUnit>
            {
                [from: PressureUnit.HektoPascal,          to: PressureUnit.Pascal] = 100m,
                [from: PressureUnit.MillimeterOfMercury,  to: PressureUnit.Pascal] = 133.322368m,
                [from: PressureUnit.InchOfMercury,        to: PressureUnit.Pascal] = 3386.38816m,
                [from: PressureUnit.MillimeterOfMercury,  to: PressureUnit.HektoPascal] = 1.33322368m,
                [from: PressureUnit.InchOfMercury,        to: PressureUnit.HektoPascal] = 33.8638816m,
                [from: PressureUnit.MillimeterOfMercury,  to: PressureUnit.InchOfMercury] = 0.0393700787m,
               
            };

        private static readonly string[] Abbreviations = { "Pa", "hPa", "mmHg", "inHg" };

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Pressure"/> structure.
        /// </summary>
        /// <param name="value">The Pressure value.</param>
        /// <param name="unit">The Pressure unit.</param>
        public Pressure(SmallDecimal value, PressureUnit unit)
        {
            Value = value;
            Unit = unit;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        public SmallDecimal Value { get; }

        /// <summary>
        /// Gets the unit.
        /// </summary>
        public PressureUnit Unit { get; }

        /// <summary>
        /// Gets the value in the specified <paramref name="unit"/>s.
        /// </summary>
        public SmallDecimal ValueIn(PressureUnit unit) => Conversions.ConvertValue(this, unit);

        /// <summary>
        /// Gets the <see cref="Pressure"/> in the specified <paramref name="unit"/>s.
        /// </summary>
        public Pressure In(PressureUnit unit) => Conversions.Convert(this, unit);

        public override string ToString() => $"{Value} {Abbreviations[(int)Unit]}";

        public void Deconstruct(out SmallDecimal value, out PressureUnit unit)
        {
            value = Value;
            unit = Unit;
        }

        #region Equality

        public bool Equals(Pressure other)
        {
            if (Unit == other.Unit)
                return Value == other.Value;

            return ValueIn(PressureUnit.Pascal) == other.ValueIn(PressureUnit.Pascal);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Pressure && Equals((Pressure)obj);
        }

        public override int GetHashCode()
        {
            return ValueIn(PressureUnit.Pascal).GetHashCode();
        }

        #endregion

        #region Comparison

        public int CompareTo(Pressure other)
        {
            if (Unit == other.Unit)
                return Value.CompareTo(other.Value);

            return ValueIn(PressureUnit.Pascal).CompareTo(other.ValueIn(PressureUnit.Pascal));
        }


        public int CompareTo(object obj)
        {
            if (ReferenceEquals(null, obj)) return 1;
            if (!(obj is Pressure)) throw new ArgumentException($"Object must be of type {nameof(Pressure)}");
            return CompareTo((Pressure)obj);
        }

        #endregion

        #region Operators

        public static implicit operator Pressure((decimal value, PressureUnit unit) valueWithUnit)
        {
            return new Pressure(valueWithUnit.value, valueWithUnit.unit);
        }

        public static implicit operator (decimal value, PressureUnit unit) (Pressure pressure)
        {
            return (pressure.Value, pressure.Unit);
        }

        public static bool operator ==(Pressure left, Pressure right) => left.Equals(right);

        public static bool operator !=(Pressure left, Pressure right) => !left.Equals(right);

        public static bool operator <(Pressure left, Pressure right) => left.CompareTo(right) < 0;

        public static bool operator >(Pressure left, Pressure right) => left.CompareTo(right) > 0;

        public static bool operator <=(Pressure left, Pressure right) => left.CompareTo(right) <= 0;

        public static bool operator >=(Pressure left, Pressure right) => left.CompareTo(right) >= 0;

        public static Pressure operator +(Pressure l1, Pressure l2) => new Pressure(l1.Value + l2.ValueIn(l1.Unit), l1.Unit);

        public static Pressure operator -(Pressure l1, Pressure l2) => new Pressure(l1.Value - l2.ValueIn(l1.Unit), l1.Unit);

        public static Pressure operator *(decimal multiplier, Pressure pressure) => new Pressure(multiplier * pressure.Value, pressure.Unit);

        public static Pressure operator *(Pressure pressure, decimal multiplier) => new Pressure(multiplier * pressure.Value, pressure.Unit);

        public static Pressure operator /(Pressure pressure, decimal divisor) => new Pressure(pressure.Value / divisor, pressure.Unit);

        #endregion
    }
}
