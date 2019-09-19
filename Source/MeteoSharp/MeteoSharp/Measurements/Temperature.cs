using System;
using System.Collections.Generic;
using MeteoSharp.Core;

namespace MeteoSharp.Measurements
{
    /// <summary>
    /// Represents the Length.
    /// </summary>
    public readonly struct Temperature : IMeasurement<Temperature, TemperatureUnit>
    {
        #region Constants

        /// <summary>
        /// Gets the Temperature of 1 Kelvin.
        /// </summary>
        public static Temperature Kelvin { get; } = (1, TemperatureUnit.Kelvin);

        /// <summary>
        /// Gets the length of 1  Celsius.
        /// </summary>
        public static Temperature Celsius { get; } = (1, TemperatureUnit.Celsius);

        /// <summary>
        /// Gets the length of 1  Fahrenheit.
        /// </summary>
        public static Temperature Fahrenheit { get; } = (1, TemperatureUnit.Fahrenheit);

        private static readonly string[] Abbreviations = { "K", "°C", "°F" };

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Temperature"/> structure.
        /// </summary>
        /// <param name="value">The Temperature value.</param>
        /// <param name="unit">The Temperature unit.</param>
        public Temperature(SmallDecimal value, TemperatureUnit unit)
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
        public TemperatureUnit Unit { get; }

        /// <summary>
        /// Gets the value in the specified <paramref name="unit"/>s.
        /// </summary>
        public SmallDecimal ValueIn(TemperatureUnit unit)
        {
            if (Unit == unit)
                return Value;

            switch (unit)
            {
                case TemperatureUnit.Kelvin:
                    return ValueInKelvin();
                case TemperatureUnit.Celsius:
                    return ValueInCelsius();
                case TemperatureUnit.Fahrenheit:
                    return ValueInFahrenheit();
                default:
                    throw new ArgumentOutOfRangeException(nameof(unit), unit, null);
            }
        }

        public Temperature In(TemperatureUnit unit) => new Temperature(ValueIn(unit), unit);

        private decimal ValueInKelvin()
        {
            switch (Unit)
            {
                case TemperatureUnit.Kelvin:
                    return Value;
                case TemperatureUnit.Celsius:
                    return Value.ToDecimal() + 273.15m;
                case TemperatureUnit.Fahrenheit:
                    return (Value.ToDecimal() + 459.67m) * 5 / 9;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private decimal ValueInCelsius()
        {
            switch (Unit)
            {
                case TemperatureUnit.Kelvin:
                    return Value.ToDecimal() - 273.15m;
                case TemperatureUnit.Celsius:
                    return Value;
                case TemperatureUnit.Fahrenheit:
                    return (Value.ToDecimal() - 32m) * 5 / 9;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private decimal ValueInFahrenheit()
        {
            switch (Unit)
            {
                case TemperatureUnit.Kelvin:
                    return Value.ToDecimal() * 9/5 - 459.67m;
                case TemperatureUnit.Celsius:
                    return Value.ToDecimal() * 9/5 + 32m;
                case TemperatureUnit.Fahrenheit:
                    return Value;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override string ToString() => $"{Value} {Abbreviations[(int)Unit]}";

        public void Deconstruct(out SmallDecimal value, out TemperatureUnit unit)
        {
            value = Value;
            unit = Unit;
        }

        #region Equality

        public bool Equals(Temperature other)
        {
            if (Unit == other.Unit)
                return Value == other.Value;

            return ValueIn(TemperatureUnit.Kelvin) == other.ValueIn(TemperatureUnit.Kelvin);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Temperature && Equals((Temperature)obj);
        }
        public override int GetHashCode()
        {
            return ValueIn(TemperatureUnit.Kelvin).GetHashCode();
        }

        #endregion

        #region Comparison

        public int CompareTo(Temperature other)
        {
            if (Unit == other.Unit)
                return Value.CompareTo(other.Value);

            return ValueIn(TemperatureUnit.Kelvin).CompareTo(other.ValueIn(TemperatureUnit.Kelvin));
        }


        public int CompareTo(object obj)
        {
            if (ReferenceEquals(null, obj)) return 1;
            if (!(obj is Temperature)) throw new ArgumentException($"Object must be of type {nameof(Temperature)}");
            return CompareTo((Temperature)obj);
        }

        #endregion


        #region Operators

        public static implicit operator Temperature((decimal value, TemperatureUnit unit) valueWithUnit)
        {
            return new Temperature(valueWithUnit.value, valueWithUnit.unit);
        }

        public static implicit operator (decimal value, TemperatureUnit unit) (Temperature temperature)
        {
            return (temperature.Value, temperature.Unit);
        }

        public static bool operator ==(Temperature left, Temperature right) => left.Equals(right);

        public static bool operator !=(Temperature left, Temperature right) => !left.Equals(right);

        public static bool operator <(Temperature left, Temperature right) => left.CompareTo(right) < 0;

        public static bool operator >(Temperature left, Temperature right) => left.CompareTo(right) > 0;

        public static bool operator <=(Temperature left, Temperature right) => left.CompareTo(right) <= 0;

        public static bool operator >=(Temperature left, Temperature right) => left.CompareTo(right) >= 0;

        public static Temperature operator +(Temperature l1, Temperature l2) => new Temperature(l1.Value + l2.ValueIn(l1.Unit), l1.Unit);

        public static Temperature operator -(Temperature l1, Temperature l2) => new Temperature(l1.Value - l2.ValueIn(l1.Unit), l1.Unit);

        public static Temperature operator *(decimal multiplier, Temperature length) => new Temperature(multiplier * length.Value, length.Unit);

        public static Temperature operator *(Temperature temperature, decimal multiplier) => new Temperature(multiplier * temperature.Value, temperature.Unit);

        public static Temperature operator /(Temperature temperature, decimal divisor) => new Temperature(temperature.Value / divisor, temperature.Unit);

        #endregion
    }
}
