using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using FluentAssertions;
using MeteoSharp.Core;
using NUnit.Framework;

namespace MeteoSharp.Tests.Core
{
    [SetCulture("inv")]
    public class SmallDecimalTests
    {
        [Test]
        [TestCase( 1230, 0,  ExpectedResult = "1230")]
        [TestCase( 1230, 1,  ExpectedResult = "123.0")]
        [TestCase( 1230, 2,  ExpectedResult = "12.30")]
        [TestCase( 1230, 3,  ExpectedResult = "1.230")]
        [TestCase( 1230, 4,  ExpectedResult = "0.1230")]
        [TestCase( 1230, 5,  ExpectedResult = "0.01230")]
        [TestCase( 1230, 6,  ExpectedResult = "0.001230")]
        [TestCase( 1230, 7,  ExpectedResult = "0.0001230")]
        [TestCase( 1230, 8,  ExpectedResult = "0.00001230")]
        [TestCase( 1230, 9,  ExpectedResult = "0.000001230")]
        [TestCase( 1230, 10, ExpectedResult = "0.0000001230")]
        [TestCase( 1230, 11, ExpectedResult = "0.00000001230")]
        [TestCase( 1230, 12, ExpectedResult = "0.000000001230")]
        [TestCase( 1230, 13, ExpectedResult = "0.0000000001230")]
        [TestCase( 1230, 14, ExpectedResult = "0.00000000001230")]
        [TestCase( 1230, 15, ExpectedResult = "0.000000000001230")]
        [TestCase(-1230, 0,  ExpectedResult = "-1230")]
        [TestCase(-1230, 1,  ExpectedResult = "-123.0")]
        [TestCase(-1230, 2,  ExpectedResult = "-12.30")]
        [TestCase(-1230, 3,  ExpectedResult = "-1.230")]
        [TestCase(-1230, 4,  ExpectedResult = "-0.1230")]
        [TestCase(-1230, 5,  ExpectedResult = "-0.01230")]
        [TestCase(-1230, 6,  ExpectedResult = "-0.001230")]
        [TestCase(-1230, 7,  ExpectedResult = "-0.0001230")]
        [TestCase(-1230, 8,  ExpectedResult = "-0.00001230")]
        [TestCase(-1230, 9,  ExpectedResult = "-0.000001230")]
        [TestCase(-1230, 10, ExpectedResult = "-0.0000001230")]
        [TestCase(-1230, 11, ExpectedResult = "-0.00000001230")]
        [TestCase(-1230, 12, ExpectedResult = "-0.000000001230")]
        [TestCase(-1230, 13, ExpectedResult = "-0.0000000001230")]
        [TestCase(-1230, 14, ExpectedResult = "-0.00000000001230")]
        [TestCase(-1230, 15, ExpectedResult = "-0.000000000001230")]
        public string Format(int coef, byte exponent)
        {
            var number = new SmallDecimal(coef, exponent);
            return number.ToString(CultureInfo.InvariantCulture);
        }

        [Test]
        [TestCase( 1230, 0,  "1230")]
        [TestCase( 1230, 1,  "123.0")]
        [TestCase( 1230, 2,  "12.30")]
        [TestCase( 1230, 3,  "1.230")]
        [TestCase( 1230, 4,  "0.1230")]
        [TestCase( 1230, 5,  "0.01230")]
        [TestCase( 1230, 6,  "0.001230")]
        [TestCase( 1230, 7,  "0.0001230")]
        [TestCase( 1230, 8,  "0.00001230")]
        [TestCase( 1230, 9,  "0.000001230")]
        [TestCase( 1230, 10, "0.0000001230")]
        [TestCase( 1230, 11, "0.00000001230")]
        [TestCase( 1230, 12, "0.000000001230")]
        [TestCase( 1230, 13, "0.0000000001230")]
        [TestCase( 1230, 14, "0.00000000001230")]
        [TestCase( 1230, 15, "0.000000000001230")]
        [TestCase(-1230, 0,  "-1230")]
        [TestCase(-1230, 1,  "-123.0")]
        [TestCase(-1230, 2,  "-12.30")]
        [TestCase(-1230, 3,  "-1.230")]
        [TestCase(-1230, 4,  "-0.1230")]
        [TestCase(-1230, 5,  "-0.01230")]
        [TestCase(-1230, 6,  "-0.001230")]
        [TestCase(-1230, 7,  "-0.0001230")]
        [TestCase(-1230, 8,  "-0.00001230")]
        [TestCase(-1230, 9,  "-0.000001230")]
        [TestCase(-1230, 10, "-0.0000001230")]
        [TestCase(-1230, 11, "-0.00000001230")]
        [TestCase(-1230, 12, "-0.000000001230")]
        [TestCase(-1230, 13, "-0.0000000001230")]
        [TestCase(-1230, 14, "-0.00000000001230")]
        [TestCase(-1230, 15, "-0.000000000001230")]
        public void ToDecimal(int coef, byte exponent, string expectedString)
        {
            var number = new SmallDecimal(coef, exponent);
            number.ToDecimal().Should().Be(decimal.Parse(expectedString));
        }

        [Test]
        [TestCase(1230, 0, "1230")]
        [TestCase(1230, 1, "123.0")]
        [TestCase(1230, 2, "12.30")]
        [TestCase(1230, 3, "1.230")]
        [TestCase(1230, 4, "0.1230")]
        [TestCase(1230, 5, "0.01230")]
        [TestCase(1230, 6, "0.001230")]
        [TestCase(1230, 7, "0.0001230")]
        [TestCase(1230, 8, "0.00001230")]
        [TestCase(1230, 9, "0.000001230")]
        [TestCase(1230, 10, "0.0000001230")]
        [TestCase(1230, 11, "0.00000001230")]
        [TestCase(1230, 12, "0.000000001230")]
        [TestCase(1230, 13, "0.0000000001230")]
        [TestCase(1230, 14, "0.00000000001230")]
        [TestCase(1230, 15, "0.000000000001230")]
        [TestCase(-1230, 0, "-1230")]
        [TestCase(-1230, 1, "-123.0")]
        [TestCase(-1230, 2, "-12.30")]
        [TestCase(-1230, 3, "-1.230")]
        [TestCase(-1230, 4, "-0.1230")]
        [TestCase(-1230, 5, "-0.01230")]
        [TestCase(-1230, 6, "-0.001230")]
        [TestCase(-1230, 7, "-0.0001230")]
        [TestCase(-1230, 8, "-0.00001230")]
        [TestCase(-1230, 9, "-0.000001230")]
        [TestCase(-1230, 10, "-0.0000001230")]
        [TestCase(-1230, 11, "-0.00000001230")]
        [TestCase(-1230, 12, "-0.000000001230")]
        [TestCase(-1230, 13, "-0.0000000001230")]
        [TestCase(-1230, 14, "-0.00000000001230")]
        [TestCase(-1230, 15, "-0.000000000001230")]
        [TestCase(99_999_999, 0, "99999999.11111111")]
        [TestCase(-99_999_999, 0, "-99999999.11111111")]
        [TestCase(0, 0, "1e-28")]
        [TestCase(0, 0, "1e-27")]
        [TestCase(0, 0, "1e-26")]
        [TestCase(0, 0, "1e-25")]
        [TestCase(0, 0, "1e-24")]
        [TestCase(0, 0, "1e-23")]
        [TestCase(0, 0, "1e-22")]
        [TestCase(0, 0, "1e-21")]
        [TestCase(0, 0, "1e-20")]
        [TestCase(0, 0, "1e-19")]
        [TestCase(0, 0, "1e-18")]
        [TestCase(0, 0, "1e-17")]
        [TestCase(0, 0, "1e-16")]
        [TestCase(1, 15, "1e-15")]
        [TestCase(1, 14, "1e-14")]
        [TestCase(1, 13, "1e-13")]
        [TestCase(1, 12, "1e-12")]
        [TestCase(1, 11, "1e-11")]
        [TestCase(1, 10, "1e-10")]
        public void FromDecimal(int coef, byte exponent, string decimalString)
        {
            var dec = decimal.Parse(decimalString, NumberStyles.AllowExponent | NumberStyles.Number);
            var number = new SmallDecimal(dec);
            number.Should().Be(new SmallDecimal(coef, exponent));
        }
    }
}
