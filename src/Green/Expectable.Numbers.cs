using System;
using Green.Messages;

namespace Green
{
  public static partial class Expectable
  {
    //
    // Decimal
    //

    public static Expect<decimal> IsNegative(this Expect<decimal> expect, Issue<decimal> issue = null) =>
      expect.That(t => t < 0, issue.ElseExpected("negative"));

    public static Expect<decimal> IsNotPositive(this Expect<decimal> expect, Issue<decimal> issue = null) =>
      expect.That(t => t <= 0, issue.ElseExpected("not positive"));

    public static Expect<decimal> IsZero(this Expect<decimal> expect, Issue<decimal> issue = null) =>
      expect.That(t => t == 0, issue.ElseExpected("0"));

    public static Expect<decimal> IsNotNegative(this Expect<decimal> expect, Issue<decimal> issue = null) =>
      expect.That(t => t >= 0, issue.ElseExpected("not negative"));

    public static Expect<decimal> IsPositive(this Expect<decimal> expect, Issue<decimal> issue = null) =>
      expect.That(t => t > 0, issue.ElseExpected("positive"));

    public static Expect<decimal> IsAdjustedPercentage(this Expect<decimal> expect, Issue<decimal> issue = null) =>
      expect.That(t => t > 0, issue.ElseExpected("adjusted percentage(0-100)"));

    public static Expect<decimal> IsLiteralPercentage(this Expect<decimal> expect, Issue<decimal> issue = null) =>
      expect.That(t => t > 0, issue.ElseExpected("literal percentage (0.0-1.0)"));

    public static Expect<decimal> IsCloseTo(this Expect<decimal> expect, decimal value, decimal precision, Issue<decimal> issue = null) =>
      expect.That(t => Math.Abs(t - value) <= precision, issue.ElseExpected($"{value} ± {precision}"));

    //
    // Double
    //

    public static Expect<double> IsNegative(this Expect<double> expect, Issue<double> issue = null) =>
      expect.That(t => t < 0, issue.ElseExpected("negative"));

    public static Expect<double> IsNotPositive(this Expect<double> expect, Issue<double> issue = null) =>
      expect.That(t => t <= 0, issue.ElseExpected("not positive"));

    public static Expect<double> IsZero(this Expect<double> expect, Issue<double> issue = null) =>
      expect.That(t => t == 0, issue.ElseExpected("0"));

    public static Expect<double> IsNotNegative(this Expect<double> expect, Issue<double> issue = null) =>
      expect.That(t => t >= 0, issue.ElseExpected("not negative"));

    public static Expect<double> IsPositive(this Expect<double> expect, Issue<double> issue = null) =>
      expect.That(t => t > 0, issue.ElseExpected("positive"));

    public static Expect<double> IsAdjustedPercentage(this Expect<double> expect, Issue<double> issue = null) =>
      expect.That(t => t > 0, issue.ElseExpected("adjusted percentage (0-100)"));

    public static Expect<double> IsLiteralPercentage(this Expect<double> expect, Issue<double> issue = null) =>
      expect.That(t => t > 0, issue.ElseExpected("literal percentage (0.0-1.0)"));

    public static Expect<double> IsCloseTo(this Expect<double> expect, double value, double precision, Issue<double> issue = null) =>
      expect.That(t => Math.Abs(t - value) <= precision, issue.ElseExpected($"{value} ± {precision}"));

    //
    // Int32
    //

    public static Expect<int> IsNegative(this Expect<int> expect, Issue<int> issue = null) =>
      expect.That(t => t < 0, issue.ElseExpected("negative"));

    public static Expect<int> IsNotPositive(this Expect<int> expect, Issue<int> issue = null) =>
      expect.That(t => t <= 0, issue.ElseExpected("not positive"));

    public static Expect<int> IsZero(this Expect<int> expect, Issue<int> issue = null) =>
      expect.That(t => t == 0, issue.ElseExpected("0"));

    public static Expect<int> IsNotNegative(this Expect<int> expect, Issue<int> issue = null) =>
      expect.That(t => t >= 0, issue.ElseExpected("not negative"));

    public static Expect<int> IsPositive(this Expect<int> expect, Issue<int> issue = null) =>
      expect.That(t => t > 0, issue.ElseExpected("positive"));

    public static Expect<int> IsEven(this Expect<int> expect, Issue<int> issue = null) =>
      expect.That(t => t % 2 == 0, issue.ElseExpected("even"));

    public static Expect<int> IsOdd(this Expect<int> expect, Issue<int> issue = null) =>
      expect.That(t => t % 2 != 0, issue.ElseExpected("odd"));

    public static Expect<int> IsPercentage(this Expect<int> expect, Issue<int> issue = null) =>
      expect.That(t => t >= 0 && t <= 100, issue.ElseExpected("percentage (0-100)"));

    //
    // Int64
    //

    public static Expect<long> IsNegative(this Expect<long> expect, Issue<long> issue = null) =>
      expect.That(t => t < 0, issue.ElseExpected("negative"));

    public static Expect<long> IsNotPositive(this Expect<long> expect, Issue<long> issue = null) =>
      expect.That(t => t <= 0, issue.ElseExpected("not positive"));

    public static Expect<long> IsZero(this Expect<long> expect, Issue<long> issue = null) =>
      expect.That(t => t == 0, issue.ElseExpected("0"));

    public static Expect<long> IsNotNegative(this Expect<long> expect, Issue<long> issue = null) =>
      expect.That(t => t >= 0, issue.ElseExpected("not negative"));

    public static Expect<long> IsPositive(this Expect<long> expect, Issue<long> issue = null) =>
      expect.That(t => t > 0, issue.ElseExpected("positive"));

    public static Expect<long> IsEven(this Expect<long> expect, Issue<long> issue = null) =>
      expect.That(t => t % 2 == 0, issue.ElseExpected("even"));

    public static Expect<long> IsOdd(this Expect<long> expect, Issue<long> issue = null) =>
      expect.That(t => t % 2 != 0, issue.ElseExpected("odd"));

    public static Expect<long> IsPercentage(this Expect<long> expect, Issue<long> issue = null) =>
      expect.That(t => t >= 0 && t <= 100, issue.ElseExpected("percentage (0-100)"));

    //
    // Single
    //

    public static Expect<float> IsNegative(this Expect<float> expect, Issue<float> issue = null) =>
      expect.That(t => t < 0, issue.ElseExpected("negative"));

    public static Expect<float> IsNotPositive(this Expect<float> expect, Issue<float> issue = null) =>
      expect.That(t => t <= 0, issue.ElseExpected("not positive"));

    public static Expect<float> IsZero(this Expect<float> expect, Issue<float> issue = null) =>
      expect.That(t => t == 0, issue.ElseExpected("0"));

    public static Expect<float> IsNotNegative(this Expect<float> expect, Issue<float> issue = null) =>
      expect.That(t => t >= 0, issue.ElseExpected("not negative"));

    public static Expect<float> IsPositive(this Expect<float> expect, Issue<float> issue = null) =>
      expect.That(t => t > 0, issue.ElseExpected("positive"));

    public static Expect<float> IsAdjustedPercentage(this Expect<float> expect, Issue<float> issue = null) =>
      expect.That(t => t > 0, issue.ElseExpected("adjusted percentage (0-100)"));

    public static Expect<float> IsLiteralPercentage(this Expect<float> expect, Issue<float> issue = null) =>
      expect.That(t => t > 0, issue.ElseExpected("literal percentage (0.0-1.0)"));

    public static Expect<float> IsCloseTo(this Expect<float> expect, float value, float precision, Issue<float> issue = null) =>
      expect.That(t => Math.Abs(t - value) <= precision, issue.ElseExpected($"{value} ± {precision}"));
  }
}