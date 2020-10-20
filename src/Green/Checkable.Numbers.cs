using System;

namespace Green
{
  public static partial class Checkable
  {
    /// <summary>
    /// Checks if the target is zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<byte> Zero(this Check<byte> check) =>
      check.That(t => t == 0);

    /// <summary>
    /// Checks if the target is not zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<byte> NotZero(this Check<byte> check) =>
      check.That(t => t != 0);

    /// <summary>
    /// Checks if the target is divisible by 2
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<byte> Even(this Check<byte> check) =>
      check.That(t => t % 2 == 0);

    /// <summary>
    /// Checks if the target is not divisible by 2
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<byte> Odd(this Check<byte> check) =>
      check.That(t => t % 2 != 0);

    /// <summary>
    /// Checks if the target is in the range 0-100
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<byte> Percentage(this Check<byte> check) =>
      check.That(t => t >= 0 && t <= 100);

    /// <summary>
    /// Checks if the target is <see cref="byte.MinValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<byte> MinValue(this Check<byte> check) =>
      check.That(t => t == byte.MinValue);

    /// <summary>
    /// Checks if the target is <see cref="byte.MaxValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<byte> MaxValue(this Check<byte> check) =>
      check.That(t => t == byte.MaxValue);

    /// <summary>
    /// Checks if the target is not <see cref="byte.MinValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<byte> NotMinValue(this Check<byte> check) =>
      check.That(t => t != byte.MinValue);

    /// <summary>
    /// Checks if the target is not <see cref="byte.MaxValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<byte> NotMaxValue(this Check<byte> check) =>
      check.That(t => t != byte.MaxValue);

    //
    // Decimal
    //

    /// <summary>
    /// Checks if the target is less than zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<decimal> Negative(this Check<decimal> check) =>
      check.That(t => t < 0);

    /// <summary>
    /// Checks if the target is less than or equal to zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<decimal> NotPositive(this Check<decimal> check) =>
      check.That(t => t <= 0);

    /// <summary>
    /// Checks if the target is zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<decimal> Zero(this Check<decimal> check) =>
      check.That(t => t == 0);

    /// <summary>
    /// Checks if the target is greater than or equal to zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<decimal> NotNegative(this Check<decimal> check) =>
      check.That(t => t >= 0);

    /// <summary>
    /// Checks if the target is greater than zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<decimal> Positive(this Check<decimal> check) =>
      check.That(t => t > 0);

    /// <summary>
    /// Checks if the target is in the range 0-100
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<decimal> AdjustedPercentage(this Check<decimal> check) =>
      check.That(t => t >= 0 && t <= 100);

    /// <summary>
    /// Checks if the target is in the range 0-1
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<decimal> LiteralPercentage(this Check<decimal> check) =>
      check.That(t => t >= 0 && t <= 1);

    /// <summary>
    /// Checks if the target is <paramref name="value"/> ± <paramref name="precision"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare using <paramref name="precision"/></param>
    /// <param name="precision">The amount the target and <paramref name="value"/> may differ by while still being equal</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<decimal> Approximately(this Check<decimal> check, decimal value, decimal precision) =>
      check.That(t => Math.Abs(t - value) <= precision);

    /// <summary>
    /// Checks if the target is <see cref="decimal.MinValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<decimal> MinValue(this Check<decimal> check) =>
      check.That(t => t == decimal.MinValue);

    /// <summary>
    /// Checks if the target is <see cref="decimal.MaxValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<decimal> MaxValue(this Check<decimal> check) =>
      check.That(t => t == decimal.MaxValue);

    /// <summary>
    /// Checks if the target is not <see cref="decimal.MinValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<decimal> NotMinValue(this Check<decimal> check) =>
      check.That(t => t != decimal.MinValue);

    /// <summary>
    /// Checks if the target is not <see cref="decimal.MaxValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<decimal> NotMaxValue(this Check<decimal> check) =>
      check.That(t => t != decimal.MaxValue);

    //
    // Double
    //

    /// <summary>
    /// Checks if the target is less than zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<double> Negative(this Check<double> check) =>
      check.That(t => t < 0);

    /// <summary>
    /// Checks if the target is less than or equal to zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<double> NotPositive(this Check<double> check) =>
      check.That(t => t <= 0);

    /// <summary>
    /// Checks if the target is zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<double> Zero(this Check<double> check) =>
      check.That(t => t == 0);

    /// <summary>
    /// Checks if the target is greater than or equal to zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<double> NotNegative(this Check<double> check) =>
      check.That(t => t >= 0);

    /// <summary>
    /// Checks if the target is greater than zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<double> Positive(this Check<double> check) =>
      check.That(t => t > 0);

    /// <summary>
    /// Checks if the target is in the range 0-100
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<double> AdjustedPercentage(this Check<double> check) =>
      check.That(t => t >= 0 && t <= 100);

    /// <summary>
    /// Checks if the target is in the range 0-1
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<double> LiteralPercentage(this Check<double> check) =>
      check.That(t => t >= 0 && t <= 1);

    /// <summary>
    /// Checks if the target is <paramref name="value"/> ± <paramref name="precision"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare using <paramref name="precision"/></param>
    /// <param name="precision">The amount the target and <paramref name="value"/> may differ by while still being equal</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<double> Approximately(this Check<double> check, double value, double precision) =>
      check.That(t => Math.Abs(t - value) <= precision);

    /// <summary>
    /// Checks if the target is <see cref="double.MinValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<double> MinValue(this Check<double> check) =>
      check.That(t => t == double.MinValue);

    /// <summary>
    /// Checks if the target is <see cref="double.MaxValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<double> MaxValue(this Check<double> check) =>
      check.That(t => t == double.MaxValue);

    /// <summary>
    /// Checks if the target is not <see cref="double.MinValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<double> NotMinValue(this Check<double> check) =>
      check.That(t => t == double.MinValue);

    /// <summary>
    /// Checks if the target is not <see cref="double.MaxValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<double> NotMaxValue(this Check<double> check) =>
      check.That(t => t == double.MaxValue);

    //
    // Int16
    //

    /// <summary>
    /// Checks if the target is less than zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<short> Negative(this Check<short> check) =>
      check.That(t => t < 0);

    /// <summary>
    /// Checks if the target is less than or equal to zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<short> NotPositive(this Check<short> check) =>
      check.That(t => t <= 0);

    /// <summary>
    /// Checks if the target is zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<short> Zero(this Check<short> check) =>
      check.That(t => t == 0);

    /// <summary>
    /// Checks if the target is greater than or equal to zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<short> NotNegative(this Check<short> check) =>
      check.That(t => t >= 0);

    /// <summary>
    /// Checks if the target is greater than zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<short> Positive(this Check<short> check) =>
      check.That(t => t > 0);

    /// <summary>
    /// Checks if the target is divisible by 2
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<short> Even(this Check<short> check) =>
      check.That(t => t % 2 == 0);

    /// <summary>
    /// Checks if the target is not divisible by 2
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<short> Odd(this Check<short> check) =>
      check.That(t => t % 2 != 0);

    /// <summary>
    /// Checks if the target is in the range 0-100
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<short> Percentage(this Check<short> check) =>
      check.That(t => t >= 0 && t <= 100);

    /// <summary>
    /// Checks if the target is <see cref="short.MinValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<short> MinValue(this Check<short> check) =>
      check.That(t => t == short.MinValue);

    /// <summary>
    /// Checks if the target is <see cref="short.MaxValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<short> MaxValue(this Check<short> check) =>
      check.That(t => t == short.MaxValue);

    /// <summary>
    /// Checks if the target is <see cref="short.MinValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<short> NotMinValue(this Check<short> check) =>
      check.That(t => t == short.MinValue);

    /// <summary>
    /// Checks if the target is <see cref="short.MaxValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<short> NotMaxValue(this Check<short> check) =>
      check.That(t => t == short.MaxValue);

    //
    // Int32
    //

    /// <summary>
    /// Checks if the target is less than zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<int> Negative(this Check<int> check) =>
      check.That(t => t < 0);

    /// <summary>
    /// Checks if the target is less than or equal to zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<int> NotPositive(this Check<int> check) =>
      check.That(t => t <= 0);

    /// <summary>
    /// Checks if the target is zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<int> Zero(this Check<int> check) =>
      check.That(t => t == 0);

    /// <summary>
    /// Checks if the target is greater than or equal to zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<int> NotNegative(this Check<int> check) =>
      check.That(t => t >= 0);

    /// <summary>
    /// Checks if the target is greater than zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<int> Positive(this Check<int> check) =>
      check.That(t => t > 0);

    /// <summary>
    /// Checks if the target is divisible by 2
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<int> Even(this Check<int> check) =>
      check.That(t => t % 2 == 0);

    /// <summary>
    /// Checks if the target is not divisible by 2
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<int> Odd(this Check<int> check) =>
      check.That(t => t % 2 != 0);

    /// <summary>
    /// Checks if the target is in the range 0-100
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<int> Percentage(this Check<int> check) =>
      check.That(t => t >= 0 && t <= 100);

    /// <summary>
    /// Checks if the target is <see cref="int.MinValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<int> MinValue(this Check<int> check) =>
      check.That(t => t == int.MinValue);

    /// <summary>
    /// Checks if the target is <see cref="int.MaxValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<int> MaxValue(this Check<int> check) =>
      check.That(t => t == int.MaxValue);

    /// <summary>
    /// Checks if the target is not <see cref="int.MinValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<int> NotMinValue(this Check<int> check) =>
      check.That(t => t == int.MinValue);

    /// <summary>
    /// Checks if the target is not <see cref="int.MaxValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<int> NotMaxValue(this Check<int> check) =>
      check.That(t => t == int.MaxValue);

    //
    // Int64
    //

    /// <summary>
    /// Checks if the target is less than zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<long> Negative(this Check<long> check) =>
      check.That(t => t < 0);

    /// <summary>
    /// Checks if the target is less than or equal to zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<long> NotPositive(this Check<long> check) =>
      check.That(t => t <= 0);

    /// <summary>
    /// Checks if the target is zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<long> Zero(this Check<long> check) =>
      check.That(t => t == 0);

    /// <summary>
    /// Checks if the target is greater than or equal to zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<long> NotNegative(this Check<long> check) =>
      check.That(t => t >= 0);

    /// <summary>
    /// Checks if the target is greater than zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<long> Positive(this Check<long> check) =>
      check.That(t => t > 0);

    /// <summary>
    /// Checks if the target is divisible by 2
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<long> Even(this Check<long> check) =>
      check.That(t => t % 2 == 0);

    /// <summary>
    /// Checks if the target is not divisible by 2
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<long> Odd(this Check<long> check) =>
      check.That(t => t % 2 != 0);

    /// <summary>
    /// Checks if the target is in the range 0-100
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<long> Percentage(this Check<long> check) =>
      check.That(t => t >= 0 && t <= 100);

    /// <summary>
    /// Checks if the target is <see cref="long.MinValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<long> MinValue(this Check<long> check) =>
      check.That(t => t == long.MinValue);

    /// <summary>
    /// Checks if the target is <see cref="long.MaxValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<long> MaxValue(this Check<long> check) =>
      check.That(t => t == long.MaxValue);

    /// <summary>
    /// Checks if the target is not <see cref="long.MinValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<long> NotMinValue(this Check<long> check) =>
      check.That(t => t == long.MinValue);

    /// <summary>
    /// Checks if the target is not <see cref="long.MaxValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<long> NotMaxValue(this Check<long> check) =>
      check.That(t => t == long.MaxValue);

    //
    // Single
    //

    /// <summary>
    /// Checks if the target is less than zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<float> Negative(this Check<float> check) =>
      check.That(t => t < 0);

    /// <summary>
    /// Checks if the target is less than or equal to zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<float> NotPositive(this Check<float> check) =>
      check.That(t => t <= 0);

    /// <summary>
    /// Checks if the target is zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<float> Zero(this Check<float> check) =>
      check.That(t => t == 0);

    /// <summary>
    /// Checks if the target is greater than or equal to zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<float> NotNegative(this Check<float> check) =>
      check.That(t => t >= 0);

    /// <summary>
    /// Checks if the target is greater than zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<float> Positive(this Check<float> check) =>
      check.That(t => t > 0);

    /// <summary>
    /// Checks if the target is in the range 0-100
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<float> AdjustedPercentage(this Check<float> check) =>
      check.That(t => t >= 0 && t <= 100);

    /// <summary>
    /// Checks if the target is in the range 0-1
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<float> LiteralPercentage(this Check<float> check) =>
      check.That(t => t >= 0 && t <= 1);

    /// <summary>
    /// Checks if the target is <paramref name="value"/> ± <paramref name="precision"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare using <paramref name="precision"/></param>
    /// <param name="precision">The amount the target and <paramref name="value"/> may differ by while still being equal</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<float> Approximately(this Check<float> check, float value, float precision) =>
      check.That(t => Math.Abs(t - value) <= precision);

    /// <summary>
    /// Checks if the target is <see cref="float.MinValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<float> MinValue(this Check<float> check) =>
      check.That(t => t == float.MinValue);

    /// <summary>
    /// Checks if the target is <see cref="float.MaxValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<float> MaxValue(this Check<float> check) =>
      check.That(t => t == float.MaxValue);

    /// <summary>
    /// Checks if the target is not <see cref="float.MinValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<float> NotMinValue(this Check<float> check) =>
      check.That(t => t == float.MinValue);

    /// <summary>
    /// Checks if the target is not <see cref="float.MaxValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<float> NotMaxValue(this Check<float> check) =>
      check.That(t => t == float.MaxValue);
  }
}