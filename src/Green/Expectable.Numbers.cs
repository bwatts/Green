using System;

namespace Green
{
  public static partial class Expectable
  {
    //
    // Byte
    //

    /// <summary>
    /// Expects the target is zero
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<byte> IsZero(this Expect<byte> expect, Issue<byte>? issue = null) =>
      expect.That(t => t == 0, issue.Operator());

    /// <summary>
    /// Expects the target is not zero
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<byte> IsNotZero(this Expect<byte> expect, Issue<byte>? issue = null) =>
      expect.That(t => t != 0, issue.Operator());

    /// <summary>
    /// Expects the target is divisible by 2
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<byte> IsEven(this Expect<byte> expect, Issue<byte>? issue = null) =>
      expect.That(t => t % 2 == 0, issue.Operator());

    /// <summary>
    /// Expects the target is not divisible by 2
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<byte> IsOdd(this Expect<byte> expect, Issue<byte>? issue = null) =>
      expect.That(t => t % 2 != 0, issue.Operator());

    /// <summary>
    /// Expects the target is in the range 0-100
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<byte> IsPercentage(this Expect<byte> expect, Issue<byte>? issue = null) =>
      expect.That(t => t >= 0 && t <= 100, issue.Operator());

    /// <summary>
    /// Expects the target is <see cref="byte.MinValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<byte> IsMinValue(this Expect<byte> expect, Issue<byte>? issue = null) =>
      expect.That(t => t == byte.MinValue, issue.Operator());

    /// <summary>
    /// Expects the target is <see cref="byte.MaxValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<byte> IsMaxValue(this Expect<byte> expect, Issue<byte>? issue = null) =>
      expect.That(t => t == byte.MaxValue, issue.Operator());

    /// <summary>
    /// Expects the target is not <see cref="byte.MinValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<byte> IsNotMinValue(this Expect<byte> expect, Issue<byte>? issue = null) =>
      expect.That(t => t != byte.MinValue, issue.Operator());

    /// <summary>
    /// Expects the target is not <see cref="byte.MaxValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<byte> IsNotMaxValue(this Expect<byte> expect, Issue<byte>? issue = null) =>
      expect.That(t => t != byte.MaxValue, issue.Operator());

    //
    // Decimal
    //

    /// <summary>
    /// Expects the target is less than zero
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<decimal> IsNegative(this Expect<decimal> expect, Issue<decimal>? issue = null) =>
      expect.That(t => t < 0, issue.Operator());

    /// <summary>
    /// Expects the target is less than or equal to zero
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<decimal> IsNotPositive(this Expect<decimal> expect, Issue<decimal>? issue = null) =>
      expect.That(t => t <= 0, issue.Operator());

    /// <summary>
    /// Expects the target is zero
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<decimal> IsZero(this Expect<decimal> expect, Issue<decimal>? issue = null) =>
      expect.That(t => t == 0, issue.Operator());

    /// <summary>
    /// Expects the target is greater than or equal to zero
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<decimal> IsNotNegative(this Expect<decimal> expect, Issue<decimal>? issue = null) =>
      expect.That(t => t >= 0, issue.Operator());

    /// <summary>
    /// Expects the target is greater than zero
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<decimal> IsPositive(this Expect<decimal> expect, Issue<decimal>? issue = null) =>
      expect.That(t => t > 0, issue.Operator());

    /// <summary>
    /// Expects the target is in the range 0-100
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<decimal> IsAdjustedPercentage(this Expect<decimal> expect, Issue<decimal>? issue = null) =>
      expect.That(t => t > 0, issue.Operator());

    /// <summary>
    /// Expects the target is in the range 0-1
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<decimal> IsLiteralPercentage(this Expect<decimal> expect, Issue<decimal>? issue = null) =>
      expect.That(t => t > 0, issue.Operator());

    /// <summary>
    /// Expects the target is <paramref name="value"/> ± <paramref name="precision"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare using <paramref name="precision"/></param>
    /// <param name="precision">The amount the target and <paramref name="value"/> may differ by while still being equal</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<decimal> IsCloseTo(this Expect<decimal> expect, decimal value, decimal precision, Issue<decimal>? issue = null) =>
      expect.That(t => Math.Abs(t - value) <= precision, issue.Operator(value, precision));

    /// <summary>
    /// Expects the target is <see cref="decimal.MinValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<decimal> IsMinValue(this Expect<decimal> expect, Issue<decimal>? issue = null) =>
      expect.That(t => t == decimal.MinValue, issue.Operator());

    /// <summary>
    /// Expects the target is <see cref="decimal.MaxValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<decimal> IsMaxValue(this Expect<decimal> expect, Issue<decimal>? issue = null) =>
      expect.That(t => t == decimal.MaxValue, issue.Operator());

    /// <summary>
    /// Expects the target is not <see cref="decimal.MinValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<decimal> IsNotMinValue(this Expect<decimal> expect, Issue<decimal>? issue = null) =>
      expect.That(t => t != decimal.MinValue, issue.Operator());

    /// <summary>
    /// Expects the target is not <see cref="decimal.MaxValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<decimal> IsNotMaxValue(this Expect<decimal> expect, Issue<decimal>? issue = null) =>
      expect.That(t => t != decimal.MaxValue, issue.Operator());

    //
    // Double
    //

    /// <summary>
    /// Expects the target is less than zero
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<double> IsNegative(this Expect<double> expect, Issue<double>? issue = null) =>
      expect.That(t => t < 0, issue.Operator());

    /// <summary>
    /// Expects the target is less than or equal to zero
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<double> IsNotPositive(this Expect<double> expect, Issue<double>? issue = null) =>
      expect.That(t => t <= 0, issue.Operator());

    /// <summary>
    /// Expects the target is zero
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<double> IsZero(this Expect<double> expect, Issue<double>? issue = null) =>
      expect.That(t => t == 0, issue.Operator());

    /// <summary>
    /// Expects the target is greater than or equal to zero
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<double> IsNotNegative(this Expect<double> expect, Issue<double>? issue = null) =>
      expect.That(t => t >= 0, issue.Operator());

    /// <summary>
    /// Expects the target is greater than zero
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<double> IsPositive(this Expect<double> expect, Issue<double>? issue = null) =>
      expect.That(t => t > 0, issue.Operator());

    /// <summary>
    /// Expects the target is in the range 0-100
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<double> IsAdjustedPercentage(this Expect<double> expect, Issue<double>? issue = null) =>
      expect.That(t => t > 0, issue.Operator());

    /// <summary>
    /// Expects the target is in the range 0-1
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<double> IsLiteralPercentage(this Expect<double> expect, Issue<double>? issue = null) =>
      expect.That(t => t > 0, issue.Operator());

    /// <summary>
    /// Expects the target is <paramref name="value"/> ± <paramref name="precision"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare using <paramref name="precision"/></param>
    /// <param name="precision">The amount the target and <paramref name="value"/> may differ by while still being equal</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<double> IsCloseTo(this Expect<double> expect, double value, double precision, Issue<double>? issue = null) =>
      expect.That(t => Math.Abs(t - value) <= precision, issue.Operator(value, precision));

    /// <summary>
    /// Expects the target is <see cref="double.MinValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<double> IsMinValue(this Expect<double> expect, Issue<double>? issue = null) =>
      expect.That(t => t == double.MinValue, issue.Operator());

    /// <summary>
    /// Expects the target is <see cref="double.MaxValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<double> IsMaxValue(this Expect<double> expect, Issue<double>? issue = null) =>
      expect.That(t => t == double.MaxValue, issue.Operator());

    /// <summary>
    /// Expects the target is not <see cref="double.MinValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<double> IsNotMinValue(this Expect<double> expect, Issue<double>? issue = null) =>
      expect.That(t => t != double.MinValue, issue.Operator());

    /// <summary>
    /// Expects the target is not <see cref="double.MaxValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<double> IsNotMaxValue(this Expect<double> expect, Issue<double>? issue = null) =>
      expect.That(t => t != double.MaxValue, issue.Operator());

    //
    // Int16
    //

    /// <summary>
    /// Expects the target is less than zero
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<short> IsNegative(this Expect<short> expect, Issue<short>? issue = null) =>
      expect.That(t => t < 0, issue.Operator());

    /// <summary>
    /// Expects the target is less than or equal to zero
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<short> IsNotPositive(this Expect<short> expect, Issue<short>? issue = null) =>
      expect.That(t => t <= 0, issue.Operator());

    /// <summary>
    /// Expects the target is zero
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<short> IsZero(this Expect<short> expect, Issue<short>? issue = null) =>
      expect.That(t => t == 0, issue.Operator());

    /// <summary>
    /// Expects the target is greater than or equal to zero
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<short> IsNotNegative(this Expect<short> expect, Issue<short>? issue = null) =>
      expect.That(t => t >= 0, issue.Operator());

    /// <summary>
    /// Expects the target is greater than zero
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<short> IsPositive(this Expect<short> expect, Issue<short>? issue = null) =>
      expect.That(t => t > 0, issue.Operator());

    /// <summary>
    /// Expects the target is is divisible by 2
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<short> IsEven(this Expect<short> expect, Issue<short>? issue = null) =>
      expect.That(t => t % 2 == 0, issue.Operator());

    /// <summary>
    /// Expects the target is not divisible by 2
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<short> IsOdd(this Expect<short> expect, Issue<short>? issue = null) =>
      expect.That(t => t % 2 != 0, issue.Operator());

    /// <summary>
    /// Expects the target is in the range 0-100
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<short> IsPercentage(this Expect<short> expect, Issue<short>? issue = null) =>
      expect.That(t => t >= 0 && t <= 100, issue.Operator());

    /// <summary>
    /// Expects the target is <see cref="short.MinValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<short> IsMinValue(this Expect<short> expect, Issue<short>? issue = null) =>
      expect.That(t => t == short.MinValue, issue.Operator());

    /// <summary>
    /// Expects the target is <see cref="short.MaxValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<short> IsMaxValue(this Expect<short> expect, Issue<short>? issue = null) =>
      expect.That(t => t == short.MaxValue, issue.Operator());

    /// <summary>
    /// Expects the target is not <see cref="short.MinValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<short> IsNotMinValue(this Expect<short> expect, Issue<short>? issue = null) =>
      expect.That(t => t != short.MinValue, issue.Operator());

    /// <summary>
    /// Expects the target is not <see cref="short.MaxValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<short> IsNotMaxValue(this Expect<short> expect, Issue<short>? issue = null) =>
      expect.That(t => t != short.MaxValue, issue.Operator());

    //
    // Int32
    //

    /// <summary>
    /// Expects the target is less than zero
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<int> IsNegative(this Expect<int> expect, Issue<int>? issue = null) =>
      expect.That(t => t < 0, issue.Operator());

    /// <summary>
    /// Expects the target is less than or equal to zero
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<int> IsNotPositive(this Expect<int> expect, Issue<int>? issue = null) =>
      expect.That(t => t <= 0, issue.Operator());

    /// <summary>
    /// Expects the target is zero
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<int> IsZero(this Expect<int> expect, Issue<int>? issue = null) =>
      expect.That(t => t == 0, issue.Operator());

    /// <summary>
    /// Expects the target is greater than or equal to zero
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<int> IsNotNegative(this Expect<int> expect, Issue<int>? issue = null) =>
      expect.That(t => t >= 0, issue.Operator());

    /// <summary>
    /// Expects the target is greater than zero
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<int> IsPositive(this Expect<int> expect, Issue<int>? issue = null) =>
      expect.That(t => t > 0, issue.Operator());

    /// <summary>
    /// Expects the target is is divisible by 2
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<int> IsEven(this Expect<int> expect, Issue<int>? issue = null) =>
      expect.That(t => t % 2 == 0, issue.Operator());

    /// <summary>
    /// Expects the target is not divisible by 2
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<int> IsOdd(this Expect<int> expect, Issue<int>? issue = null) =>
      expect.That(t => t % 2 != 0, issue.Operator());

    /// <summary>
    /// Expects the target is in the range 0-100
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<int> IsPercentage(this Expect<int> expect, Issue<int>? issue = null) =>
      expect.That(t => t >= 0 && t <= 100, issue.Operator());

    /// <summary>
    /// Expects the target is <see cref="int.MinValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<int> IsMinValue(this Expect<int> expect, Issue<int>? issue = null) =>
      expect.That(t => t == int.MinValue, issue.Operator());

    /// <summary>
    /// Expects the target is <see cref="int.MaxValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<int> IsMaxValue(this Expect<int> expect, Issue<int>? issue = null) =>
      expect.That(t => t == int.MaxValue, issue.Operator());

    /// <summary>
    /// Expects the target is not <see cref="int.MinValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<int> IsNotMinValue(this Expect<int> expect, Issue<int>? issue = null) =>
      expect.That(t => t != int.MinValue, issue.Operator());

    /// <summary>
    /// Expects the target is not <see cref="int.MaxValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<int> IsNotMaxValue(this Expect<int> expect, Issue<int>? issue = null) =>
      expect.That(t => t != int.MaxValue, issue.Operator());

    //
    // Int64
    //

    /// <summary>
    /// Expects the target is less than zero
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<long> IsNegative(this Expect<long> expect, Issue<long>? issue = null) =>
      expect.That(t => t < 0, issue.Operator());

    /// <summary>
    /// Expects the target is less than or equal to zero
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<long> IsNotPositive(this Expect<long> expect, Issue<long>? issue = null) =>
      expect.That(t => t <= 0, issue.Operator());

    /// <summary>
    /// Expects the target is zero
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<long> IsZero(this Expect<long> expect, Issue<long>? issue = null) =>
      expect.That(t => t == 0, issue.Operator());

    /// <summary>
    /// Expects the target is greater than or equal to zero
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<long> IsNotNegative(this Expect<long> expect, Issue<long>? issue = null) =>
      expect.That(t => t >= 0, issue.Operator());

    /// <summary>
    /// Expects the target is greater than zero
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<long> IsPositive(this Expect<long> expect, Issue<long>? issue = null) =>
      expect.That(t => t > 0, issue.Operator());

    /// <summary>
    /// Expects the target is is divisible by 2
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<long> IsEven(this Expect<long> expect, Issue<long>? issue = null) =>
      expect.That(t => t % 2 == 0, issue.Operator());

    /// <summary>
    /// Expects the target is not divisible by 2
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<long> IsOdd(this Expect<long> expect, Issue<long>? issue = null) =>
      expect.That(t => t % 2 != 0, issue.Operator());

    /// <summary>
    /// Expects the target is in the range 0-100
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<long> IsPercentage(this Expect<long> expect, Issue<long>? issue = null) =>
      expect.That(t => t >= 0 && t <= 100, issue.Operator());

    /// <summary>
    /// Expects the target is <see cref="long.MinValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<long> IsMinValue(this Expect<long> expect, Issue<long>? issue = null) =>
      expect.That(t => t == long.MinValue, issue.Operator());

    /// <summary>
    /// Expects the target is <see cref="long.MaxValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<long> IsMaxValue(this Expect<long> expect, Issue<long>? issue = null) =>
      expect.That(t => t == long.MaxValue, issue.Operator());

    /// <summary>
    /// Expects the target is not <see cref="long.MinValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<long> IsNotMinValue(this Expect<long> expect, Issue<long>? issue = null) =>
      expect.That(t => t != long.MinValue, issue.Operator());

    /// <summary>
    /// Expects the target is not <see cref="long.MaxValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<long> IsNotMaxValue(this Expect<long> expect, Issue<long>? issue = null) =>
      expect.That(t => t != long.MaxValue, issue.Operator());

    //
    // Single
    //

    /// <summary>
    /// Expects the target is less than zero
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<float> IsNegative(this Expect<float> expect, Issue<float>? issue = null) =>
      expect.That(t => t < 0, issue.Operator());

    /// <summary>
    /// Expects the target is less than or equal to zero
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<float> IsNotPositive(this Expect<float> expect, Issue<float>? issue = null) =>
      expect.That(t => t <= 0, issue.Operator());

    /// <summary>
    /// Expects the target is zero
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<float> IsZero(this Expect<float> expect, Issue<float>? issue = null) =>
      expect.That(t => t == 0, issue.Operator());

    /// <summary>
    /// Expects the target is greater than or equal to zero
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<float> IsNotNegative(this Expect<float> expect, Issue<float>? issue = null) =>
      expect.That(t => t >= 0, issue.Operator());

    /// <summary>
    /// Expects the target is greater than zero
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<float> IsPositive(this Expect<float> expect, Issue<float>? issue = null) =>
      expect.That(t => t > 0, issue.Operator());

    /// <summary>
    /// Expects the target is in the range 0-100
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<float> IsAdjustedPercentage(this Expect<float> expect, Issue<float>? issue = null) =>
      expect.That(t => t > 0, issue.Operator());

    /// <summary>
    /// Expects the target is in the range 0-1
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<float> IsLiteralPercentage(this Expect<float> expect, Issue<float>? issue = null) =>
      expect.That(t => t > 0, issue.Operator());

    /// <summary>
    /// Expects the target is <paramref name="value"/> ± <paramref name="precision"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare using <paramref name="precision"/></param>
    /// <param name="precision">The amount the target and <paramref name="value"/> may differ by while still being equal</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<float> IsCloseTo(this Expect<float> expect, float value, float precision, Issue<float>? issue = null) =>
      expect.That(t => Math.Abs(t - value) <= precision, issue.Operator(value, precision));

    /// <summary>
    /// Expects the target is <see cref="float.MinValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<float> IsMinValue(this Expect<float> expect, Issue<float>? issue = null) =>
      expect.That(t => t == float.MinValue, issue.Operator());

    /// <summary>
    /// Expects the target is <see cref="float.MaxValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<float> IsMaxValue(this Expect<float> expect, Issue<float>? issue = null) =>
      expect.That(t => t == float.MaxValue, issue.Operator());

    /// <summary>
    /// Expects the target is not <see cref="float.MinValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<float> IsNotMinValue(this Expect<float> expect, Issue<float>? issue = null) =>
      expect.That(t => t != float.MinValue, issue.Operator());

    /// <summary>
    /// Expects the target is not <see cref="float.MaxValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<float> IsNotMaxValue(this Expect<float> expect, Issue<float>? issue = null) =>
      expect.That(t => t != float.MaxValue, issue.Operator());
  }
}