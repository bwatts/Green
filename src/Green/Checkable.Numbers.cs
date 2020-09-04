using System;

namespace Green
{
  public static partial class Checkable
  {
    //
    // Byte
    //

    /// <summary>
    /// Checks if the target is zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<byte> IsZero(this Check<byte> check) =>
      check.That(t => t == 0);

    /// <summary>
    /// Checks if the target is not zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<byte> IsNotZero(this Check<byte> check) =>
      check.That(t => t != 0);

    /// <summary>
    /// Checks if the target is divisible by 2
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<byte> IsEven(this Check<byte> check) =>
      check.That(t => t % 2 == 0);

    /// <summary>
    /// Checks if the target is not divisible by 2
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<byte> IsOdd(this Check<byte> check) =>
      check.That(t => t % 2 != 0);

    /// <summary>
    /// Checks if the target is in the range 0-100
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<byte> IsPercentage(this Check<byte> check) =>
      check.That(t => t >= 0 && t <= 100);

    /// <summary>
    /// Checks if the target is <see cref="byte.MinValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<byte> IsMinValue(this Check<byte> check) =>
      check.That(t => t == 0);

    /// <summary>
    /// Checks if the target is <see cref="byte.MaxValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<byte> IsMaxValue(this Check<byte> check) =>
      check.That(t => t == 0);

    /// <summary>
    /// Checks if the target is not <see cref="byte.MinValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<byte> IsNotMinValue(this Check<byte> check) =>
      check.That(t => t == 0);

    /// <summary>
    /// Checks if the target is not <see cref="byte.MaxValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<byte> IsNotMaxValue(this Check<byte> check) =>
      check.That(t => t == 0);

    //
    // Decimal
    //

    /// <summary>
    /// Checks if the target is less than zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<decimal> IsNegative(this Check<decimal> check) =>
      check.That(t => t < 0);

    /// <summary>
    /// Checks if the target is less than or equal to zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<decimal> IsNotPositive(this Check<decimal> check) =>
      check.That(t => t <= 0);

    /// <summary>
    /// Checks if the target is zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<decimal> IsZero(this Check<decimal> check) =>
      check.That(t => t == 0);

    /// <summary>
    /// Checks if the target is greater than or equal to zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<decimal> IsNotNegative(this Check<decimal> check) =>
      check.That(t => t >= 0);

    /// <summary>
    /// Checks if the target is greater than zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<decimal> IsPositive(this Check<decimal> check) =>
      check.That(t => t > 0);

    /// <summary>
    /// Checks if the target is in the range 0-100
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<decimal> IsAdjustedPercentage(this Check<decimal> check) =>
      check.That(t => t >= 0 && t <= 100);

    /// <summary>
    /// Checks if the target is in the range 0-1
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<decimal> IsLiteralPercentage(this Check<decimal> check) =>
      check.That(t => t >= 0 && t <= 1);

    /// <summary>
    /// Checks if the target is <paramref name="value"/> ± <paramref name="precision"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare using <paramref name="precision"/></param>
    /// <param name="precision">The amount the target and <paramref name="value"/> may differ by while still being equal</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<decimal> IsCloseTo(this Check<decimal> check, decimal value, decimal precision) =>
      check.That(t => Math.Abs(t - value) <= precision);

    /// <summary>
    /// Checks if the target is <see cref="decimal.MinValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<decimal> IsMinValue(this Check<decimal> check) =>
      check.That(t => t == decimal.MinValue);

    /// <summary>
    /// Checks if the target is <see cref="decimal.MaxValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<decimal> IsMaxValue(this Check<decimal> check) =>
      check.That(t => t == decimal.MaxValue);

    /// <summary>
    /// Checks if the target is <see cref="decimal.MinValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<decimal> IsNotMinValue(this Check<decimal> check) =>
      check.That(t => t == decimal.MinValue);

    /// <summary>
    /// Checks if the target is <see cref="decimal.MaxValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<decimal> IsNotMaxValue(this Check<decimal> check) =>
      check.That(t => t == decimal.MaxValue);

    //
    // Double
    //

    /// <summary>
    /// Checks if the target is less than zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<double> IsNegative(this Check<double> check) =>
      check.That(t => t < 0);

    /// <summary>
    /// Checks if the target is less than or equal to zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<double> IsNotPositive(this Check<double> check) =>
      check.That(t => t <= 0);

    /// <summary>
    /// Checks if the target is zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<double> IsZero(this Check<double> check) =>
      check.That(t => t == 0);

    /// <summary>
    /// Checks if the target is greater than or equal to zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<double> IsNotNegative(this Check<double> check) =>
      check.That(t => t >= 0);

    /// <summary>
    /// Checks if the target is greater than zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<double> IsPositive(this Check<double> check) =>
      check.That(t => t > 0);

    /// <summary>
    /// Checks if the target is in the range 0-100
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<double> IsAdjustedPercentage(this Check<double> check) =>
      check.That(t => t >= 0 && t <= 100);

    /// <summary>
    /// Checks if the target is in the range 0-1
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<double> IsLiteralPercentage(this Check<double> check) =>
      check.That(t => t >= 0 && t <= 1);

    /// <summary>
    /// Checks if the target is <paramref name="value"/> ± <paramref name="precision"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare using <paramref name="precision"/></param>
    /// <param name="precision">The amount the target and <paramref name="value"/> may differ by while still being equal</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<double> IsCloseTo(this Check<double> check, double value, double precision) =>
      check.That(t => Math.Abs(t - value) <= precision);

    /// <summary>
    /// Checks if the target is <see cref="double.MinValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<double> IsMinValue(this Check<double> check) =>
      check.That(t => t == double.MinValue);

    /// <summary>
    /// Checks if the target is <see cref="double.MaxValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<double> IsMaxValue(this Check<double> check) =>
      check.That(t => t == double.MaxValue);

    /// <summary>
    /// Checks if the target is <see cref="double.MinValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<double> IsNotMinValue(this Check<double> check) =>
      check.That(t => t == double.MinValue);

    /// <summary>
    /// Checks if the target is <see cref="double.MaxValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<double> IsNotMaxValue(this Check<double> check) =>
      check.That(t => t == double.MaxValue);

    //
    // Int16
    //

    /// <summary>
    /// Checks if the target is less than zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<short> IsNegative(this Check<short> check) =>
      check.That(t => t < 0);

    /// <summary>
    /// Checks if the target is less than or equal to zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<short> IsNotPositive(this Check<short> check) =>
      check.That(t => t <= 0);

    /// <summary>
    /// Checks if the target is zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<short> IsZero(this Check<short> check) =>
      check.That(t => t == 0);

    /// <summary>
    /// Checks if the target is greater than or equal to zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<short> IsNotNegative(this Check<short> check) =>
      check.That(t => t >= 0);

    /// <summary>
    /// Checks if the target is greater than zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<short> IsPositive(this Check<short> check) =>
      check.That(t => t > 0);

    /// <summary>
    /// Checks if the target is divisible by 2
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<short> IsEven(this Check<short> check) =>
      check.That(t => t % 2 == 0);

    /// <summary>
    /// Checks if the target is not divisible by 2
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<short> IsOdd(this Check<short> check) =>
      check.That(t => t % 2 != 0);

    /// <summary>
    /// Checks if the target is in the range 0-100
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<short> IsPercentage(this Check<short> check) =>
      check.That(t => t >= 0 && t <= 100);

    /// <summary>
    /// Checks if the target is <see cref="short.MinValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<short> IsMinValue(this Check<short> check) =>
      check.That(t => t == short.MinValue);

    /// <summary>
    /// Checks if the target is <see cref="short.MaxValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<short> IsMaxValue(this Check<short> check) =>
      check.That(t => t == short.MaxValue);

    /// <summary>
    /// Checks if the target is <see cref="short.MinValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<short> IsNotMinValue(this Check<short> check) =>
      check.That(t => t == short.MinValue);

    /// <summary>
    /// Checks if the target is <see cref="short.MaxValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<short> IsNotMaxValue(this Check<short> check) =>
      check.That(t => t == short.MaxValue);

    //
    // Int32
    //

    /// <summary>
    /// Checks if the target is less than zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<int> IsNegative(this Check<int> check) =>
      check.That(t => t < 0);

    /// <summary>
    /// Checks if the target is less than or equal to zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<int> IsNotPositive(this Check<int> check) =>
      check.That(t => t <= 0);

    /// <summary>
    /// Checks if the target is zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<int> IsZero(this Check<int> check) =>
      check.That(t => t == 0);

    /// <summary>
    /// Checks if the target is greater than or equal to zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<int> IsNotNegative(this Check<int> check) =>
      check.That(t => t >= 0);

    /// <summary>
    /// Checks if the target is greater than zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<int> IsPositive(this Check<int> check) =>
      check.That(t => t > 0);

    /// <summary>
    /// Checks if the target is divisible by 2
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<int> IsEven(this Check<int> check) =>
      check.That(t => t % 2 == 0);

    /// <summary>
    /// Checks if the target is not divisible by 2
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<int> IsOdd(this Check<int> check) =>
      check.That(t => t % 2 != 0);

    /// <summary>
    /// Checks if the target is in the range 0-100
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<int> IsPercentage(this Check<int> check) =>
      check.That(t => t >= 0 && t <= 100);

    /// <summary>
    /// Checks if the target is <see cref="int.MinValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<int> IsMinValue(this Check<int> check) =>
      check.That(t => t == int.MinValue);

    /// <summary>
    /// Checks if the target is <see cref="int.MaxValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<int> IsMaxValue(this Check<int> check) =>
      check.That(t => t == int.MaxValue);

    /// <summary>
    /// Checks if the target is <see cref="int.MinValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<int> IsNotMinValue(this Check<int> check) =>
      check.That(t => t == int.MinValue);

    /// <summary>
    /// Checks if the target is <see cref="int.MaxValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<int> IsNotMaxValue(this Check<int> check) =>
      check.That(t => t == int.MaxValue);

    //
    // Int64
    //

    /// <summary>
    /// Checks if the target is less than zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<long> IsNegative(this Check<long> check) =>
      check.That(t => t < 0);

    /// <summary>
    /// Checks if the target is less than or equal to zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<long> IsNotPositive(this Check<long> check) =>
      check.That(t => t <= 0);

    /// <summary>
    /// Checks if the target is zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<long> IsZero(this Check<long> check) =>
      check.That(t => t == 0);

    /// <summary>
    /// Checks if the target is greater than or equal to zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<long> IsNotNegative(this Check<long> check) =>
      check.That(t => t >= 0);

    /// <summary>
    /// Checks if the target is greater than zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<long> IsPositive(this Check<long> check) =>
      check.That(t => t > 0);

    /// <summary>
    /// Checks if the target is divisible by 2
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<long> IsEven(this Check<long> check) =>
      check.That(t => t % 2 == 0);

    /// <summary>
    /// Checks if the target is not divisible by 2
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<long> IsOdd(this Check<long> check) =>
      check.That(t => t % 2 != 0);

    /// <summary>
    /// Checks if the target is in the range 0-100
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<long> IsPercentage(this Check<long> check) =>
      check.That(t => t >= 0 && t <= 100);

    /// <summary>
    /// Checks if the target is <see cref="long.MinValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<long> IsMinValue(this Check<long> check) =>
      check.That(t => t == long.MinValue);

    /// <summary>
    /// Checks if the target is <see cref="long.MaxValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<long> IsMaxValue(this Check<long> check) =>
      check.That(t => t == long.MaxValue);

    /// <summary>
    /// Checks if the target is <see cref="long.MinValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<long> IsNotMinValue(this Check<long> check) =>
      check.That(t => t == long.MinValue);

    /// <summary>
    /// Checks if the target is <see cref="long.MaxValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<long> IsNotMaxValue(this Check<long> check) =>
      check.That(t => t == long.MaxValue);

    //
    // Single
    //

    /// <summary>
    /// Checks if the target is less than zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<float> IsNegative(this Check<float> check) =>
      check.That(t => t < 0);

    /// <summary>
    /// Checks if the target is less than or equal to zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<float> IsNotPositive(this Check<float> check) =>
      check.That(t => t <= 0);

    /// <summary>
    /// Checks if the target is zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<float> IsZero(this Check<float> check) =>
      check.That(t => t == 0);

    /// <summary>
    /// Checks if the target is greater than or equal to zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<float> IsNotNegative(this Check<float> check) =>
      check.That(t => t >= 0);

    /// <summary>
    /// Checks if the target is greater than zero
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<float> IsPositive(this Check<float> check) =>
      check.That(t => t > 0);

    /// <summary>
    /// Checks if the target is in the range 0-100
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<float> IsAdjustedPercentage(this Check<float> check) =>
      check.That(t => t >= 0 && t <= 100);

    /// <summary>
    /// Checks if the target is in the range 0-1
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<float> IsLiteralPercentage(this Check<float> check) =>
      check.That(t => t >= 0 && t <= 1);

    /// <summary>
    /// Checks if the target is <paramref name="value"/> ± <paramref name="precision"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare using <paramref name="precision"/></param>
    /// <param name="precision">The amount the target and <paramref name="value"/> may differ by while still being equal</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<float> IsCloseTo(this Check<float> check, float value, float precision) =>
      check.That(t => Math.Abs(t - value) <= precision);

    /// <summary>
    /// Checks if the target is <see cref="float.MinValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<float> IsMinValue(this Check<float> check) =>
      check.That(t => t == float.MinValue);

    /// <summary>
    /// Checks if the target is <see cref="float.MaxValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<float> IsMaxValue(this Check<float> check) =>
      check.That(t => t == float.MaxValue);

    /// <summary>
    /// Checks if the target is <see cref="float.MinValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<float> IsNotMinValue(this Check<float> check) =>
      check.That(t => t == float.MinValue);

    /// <summary>
    /// Checks if the target is <see cref="float.MaxValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<float> IsNotMaxValue(this Check<float> check) =>
      check.That(t => t == float.MaxValue);
  }
}