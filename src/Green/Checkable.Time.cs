using System;

namespace Green
{
  public static partial class Checkable
  {
    /// <summary>
    /// Checks if the target's <see cref="DateTime.Date"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> Date(this Check<DateTime> check, DateTime value) =>
      check.That(t => t.Date == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTime.Day"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> Day(this Check<DateTime> check, int value) =>
      check.That(t => t.Day == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTime.DayOfWeek"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> DayOfWeek(this Check<DateTime> check, DayOfWeek value) =>
      check.That(t => t.DayOfWeek == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTime.DayOfYear"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> DayOfYear(this Check<DateTime> check, int value) =>
      check.That(t => t.DayOfYear == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTime.Hour"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> Hour(this Check<DateTime> check, int value) =>
      check.That(t => t.Hour == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTime.Kind"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> Kind(this Check<DateTime> check, DateTimeKind value) =>
      check.That(t => t.Kind == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTime.Millisecond"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> Millisecond(this Check<DateTime> check, int value) =>
      check.That(t => t.Millisecond == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTime.Minute"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> Minute(this Check<DateTime> check, int value) =>
      check.That(t => t.Minute == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTime.Month"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> Month(this Check<DateTime> check, int value) =>
      check.That(t => t.Month == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTime.Second"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> Second(this Check<DateTime> check, int value) =>
      check.That(t => t.Second == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTime.Ticks"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> Ticks(this Check<DateTime> check, long value) =>
      check.That(t => t.Ticks == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTime.TimeOfDay"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> TimeOfDay(this Check<DateTime> check, TimeSpan value) =>
      check.That(t => t.TimeOfDay == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTime.Year"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> Year(this Check<DateTime> check, int value) =>
      check.That(t => t.Year == value);

    /// <summary>
    /// Checks if the target is a leap year
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> LeapYear(this Check<DateTime> check) =>
      check.That(t => System.DateTime.IsLeapYear(t.Year));

    /// <summary>
    /// Checks if the target is a weekday
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> Weekday(this Check<DateTime> check) =>
      check.That(t => t.DayOfWeek != System.DayOfWeek.Saturday && t.DayOfWeek != System.DayOfWeek.Sunday);

    /// <summary>
    /// Checks if the target is a weekend day
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> Weekend(this Check<DateTime> check) =>
      check.That(t => t.DayOfWeek == System.DayOfWeek.Saturday || t.DayOfWeek == System.DayOfWeek.Sunday);

    /// <summary>
    /// Checks if the target is not a leap year
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> NotLeapYear(this Check<DateTime> check) =>
      check.Not(t => System.DateTime.IsLeapYear(t.Year));

    /// <summary>
    /// Checks if the target is a not weekday
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> NotWeekday(this Check<DateTime> check) =>
      check.Not(t => t.DayOfWeek != System.DayOfWeek.Saturday && t.DayOfWeek != System.DayOfWeek.Sunday);

    /// <summary>
    /// Checks if the target is not a weekend day
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> NotWeekend(this Check<DateTime> check) =>
      check.Not(t => t.DayOfWeek == System.DayOfWeek.Saturday || t.DayOfWeek == System.DayOfWeek.Sunday);

    //
    // DateTime (values)
    //

    /// <summary>
    /// Checks if the target's <see cref="DateTime.Date"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> Date(this Check<DateTime> check, Func<Check<DateTime>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Date));

    /// <summary>
    /// Checks if the target's <see cref="DateTime.Day"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> Day(this Check<DateTime> check, Func<Check<int>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Day));

    /// <summary>
    /// Checks if the target's <see cref="DateTime.DayOfWeek"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> DayOfWeek(this Check<DateTime> check, Func<Check<DayOfWeek>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.DayOfWeek));

    /// <summary>
    /// Checks if the target's <see cref="DateTime.DayOfYear"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> DayOfYear(this Check<DateTime> check, Func<Check<int>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.DayOfYear));

    /// <summary>
    /// Checks if the target's <see cref="DateTime.Hour"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> Hour(this Check<DateTime> check, Func<Check<int>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Hour));

    /// <summary>
    /// Checks if the target's <see cref="DateTime.Kind"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> Kind(this Check<DateTime> check, Func<Check<DateTimeKind>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Kind));

    /// <summary>
    /// Checks if the target's <see cref="DateTime.Millisecond"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> Millisecond(this Check<DateTime> check, Func<Check<int>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Millisecond));

    /// <summary>
    /// Checks if the target's <see cref="DateTime.Minute"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> Minute(this Check<DateTime> check, Func<Check<int>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Minute));

    /// <summary>
    /// Checks if the target's <see cref="DateTime.Month"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> Month(this Check<DateTime> check, Func<Check<int>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Month));

    /// <summary>
    /// Checks if the target's <see cref="DateTime.Second"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> Second(this Check<DateTime> check, Func<Check<int>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Second));

    /// <summary>
    /// Checks if the target's <see cref="DateTime.Ticks"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> Ticks(this Check<DateTime> check, Func<Check<long>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Ticks));

    /// <summary>
    /// Checks if the target's <see cref="DateTime.TimeOfDay"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> TimeOfDay(this Check<DateTime> check, Func<Check<TimeSpan>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.TimeOfDay));

    /// <summary>
    /// Checks if the target's <see cref="DateTime.Year"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> Year(this Check<DateTime> check, Func<Check<int>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Year));

    //
    // DateTimeOffset
    //

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.Date"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> Date(this Check<DateTimeOffset> check, DateTime value) =>
      check.That(t => t.Date == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.DateTime"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> DateTime(this Check<DateTimeOffset> check, DateTime value) =>
      check.That(t => t.DateTime == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.Day"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> Day(this Check<DateTimeOffset> check, int value) =>
      check.That(t => t.Day == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.DayOfWeek"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> DayOfWeek(this Check<DateTimeOffset> check, DayOfWeek value) =>
      check.That(t => t.DayOfWeek == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.DayOfYear"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> DayOfYear(this Check<DateTimeOffset> check, int value) =>
      check.That(t => t.DayOfYear == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.Hour"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> Hour(this Check<DateTimeOffset> check, int value) =>
      check.That(t => t.Hour == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.LocalDateTime"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> LocalDateTime(this Check<DateTimeOffset> check, DateTime value) =>
      check.That(t => t.LocalDateTime == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.Millisecond"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> Millisecond(this Check<DateTimeOffset> check, int value) =>
      check.That(t => t.Millisecond == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.Minute"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> Minute(this Check<DateTimeOffset> check, int value) =>
      check.That(t => t.Minute == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.Month"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> Month(this Check<DateTimeOffset> check, int value) =>
      check.That(t => t.Month == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.Offset"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> Offset(this Check<DateTimeOffset> check, TimeSpan value) =>
      check.That(t => t.Offset == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.Second"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> Second(this Check<DateTimeOffset> check, int value) =>
      check.That(t => t.Second == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.Ticks"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> Ticks(this Check<DateTimeOffset> check, long value) =>
      check.That(t => t.Ticks == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.TimeOfDay"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> TimeOfDay(this Check<DateTimeOffset> check, TimeSpan value) =>
      check.That(t => t.TimeOfDay == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.UtcDateTime"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> UtcDateTime(this Check<DateTimeOffset> check, DateTime value) =>
      check.That(t => t.UtcDateTime == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.UtcTicks"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> UtcTicks(this Check<DateTimeOffset> check, long value) =>
      check.That(t => t.UtcTicks == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.Year"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> Year(this Check<DateTimeOffset> check, int value) =>
      check.That(t => t.Year == value);

    /// <summary>
    /// Checks if the target is a leap year
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> LeapYear(this Check<DateTimeOffset> check) =>
      check.That(t => t != null && System.DateTime.IsLeapYear(t.Year));

    /// <summary>
    /// Checks if the target is a weekday
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> Weekday(this Check<DateTimeOffset> check) =>
      check.That(t => t.DayOfWeek != System.DayOfWeek.Saturday && t.DayOfWeek != System.DayOfWeek.Sunday);

    /// <summary>
    /// Checks if the target is a weekend
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> Weekend(this Check<DateTimeOffset> check) =>
      check.That(t => t.DayOfWeek == System.DayOfWeek.Saturday || t.DayOfWeek == System.DayOfWeek.Sunday);

    /// <summary>
    /// Checks if the target is not a leap year
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> NotLeapYear(this Check<DateTimeOffset> check) =>
      check.Not(t => t != null && System.DateTime.IsLeapYear(t.Year));

    /// <summary>
    /// Checks if the target is a weekday
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> NotWeekday(this Check<DateTimeOffset> check) =>
      check.Not(t => t.DayOfWeek != System.DayOfWeek.Saturday && t.DayOfWeek != System.DayOfWeek.Sunday);

    /// <summary>
    /// Checks if the target is a weekend
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> NotWeekend(this Check<DateTimeOffset> check) =>
      check.Not(t => t.DayOfWeek == System.DayOfWeek.Saturday || t.DayOfWeek == System.DayOfWeek.Sunday);

    //
    // DateTimeOffset (values)
    //

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.Date"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> Date(this Check<DateTimeOffset> check, Func<Check<DateTime>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Date));

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.DateTime"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> DateTime(this Check<DateTimeOffset> check, Func<Check<DateTime>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.DateTime));

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.Day"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> Day(this Check<DateTimeOffset> check, Func<Check<int>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Day));

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.DayOfWeek"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> DayOfWeek(this Check<DateTimeOffset> check, Func<Check<DayOfWeek>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.DayOfWeek));

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.DayOfYear"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> DayOfYear(this Check<DateTimeOffset> check, Func<Check<int>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.DayOfYear));

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.Hour"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> Hour(this Check<DateTimeOffset> check, Func<Check<int>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Hour));

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.LocalDateTime"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> LocalDateTime(this Check<DateTimeOffset> check, Func<Check<DateTime>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.LocalDateTime));

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.Millisecond"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> Millisecond(this Check<DateTimeOffset> check, Func<Check<int>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Millisecond));

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.Minute"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> Minute(this Check<DateTimeOffset> check, Func<Check<int>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Minute));

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.Month"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> Month(this Check<DateTimeOffset> check, Func<Check<int>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Month));

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.Offset"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> Offset(this Check<DateTimeOffset> check, Func<Check<TimeSpan>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Offset));

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.Second"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> Second(this Check<DateTimeOffset> check, Func<Check<int>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Second));

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.Ticks"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> Ticks(this Check<DateTimeOffset> check, Func<Check<long>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Ticks));

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.TimeOfDay"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> TimeOfDay(this Check<DateTimeOffset> check, Func<Check<TimeSpan>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.TimeOfDay));

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.UtcDateTime"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> UtcDateTime(this Check<DateTimeOffset> check, Func<Check<DateTime>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.UtcDateTime));

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.UtcTicks"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> UtcTicks(this Check<DateTimeOffset> check, Func<Check<long>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.UtcTicks));

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.Year"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> Year(this Check<DateTimeOffset> check, Func<Check<int>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Year));

    //
    // TimeSpan
    //

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.Days"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> Days(this Check<TimeSpan> check, int value) =>
      check.That(t => t.Days == value);

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.Duration"/> method returns <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> Duration(this Check<TimeSpan> check, TimeSpan value) =>
      check.That(t => t.Duration() == value);

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.Hours"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> Hours(this Check<TimeSpan> check, int value) =>
      check.That(t => t.Hours == value);

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.Milliseconds"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> Milliseconds(this Check<TimeSpan> check, int value) =>
      check.That(t => t.Milliseconds == value);

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.Minutes"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> Minutes(this Check<TimeSpan> check, int value) =>
      check.That(t => t.Minutes == value);

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.Negate"/> method returns <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> Negated(this Check<TimeSpan> check, TimeSpan value) =>
      check.That(t => t.Negate() == value);

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.Seconds"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> Seconds(this Check<TimeSpan> check, int value) =>
      check.That(t => t.Seconds == value);

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.Ticks"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> Ticks(this Check<TimeSpan> check, long value) =>
      check.That(t => t.Ticks == value);

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.TotalDays"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> TotalDays(this Check<TimeSpan> check, double value) =>
      check.That(t => t.TotalDays == value);

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.TotalHours"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> TotalHours(this Check<TimeSpan> check, double value) =>
      check.That(t => t.TotalHours == value);

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.TotalMilliseconds"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> TotalMilliseconds(this Check<TimeSpan> check, double value) =>
      check.That(t => t.TotalMilliseconds == value);

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.TotalMinutes"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> TotalMinutes(this Check<TimeSpan> check, double value) =>
      check.That(t => t.TotalMinutes == value);

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.TotalSeconds"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> TotalSeconds(this Check<TimeSpan> check, double value) =>
      check.That(t => t.TotalSeconds == value);

    //
    // TimeSpan (values)
    //

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.Days"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> Days(this Check<TimeSpan> check, Func<Check<int>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Days));

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.Duration"/> method results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> Duration(this Check<TimeSpan> check, Func<Check<TimeSpan>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Duration()));

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.Hours"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> Hours(this Check<TimeSpan> check, Func<Check<int>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Hours));

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.Milliseconds"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> Milliseconds(this Check<TimeSpan> check, Func<Check<int>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Milliseconds));

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.Minutes"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> Minutes(this Check<TimeSpan> check, Func<Check<int>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Minutes));

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.Negate"/> method results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> Negated(this Check<TimeSpan> check, Func<Check<TimeSpan>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Negate()));

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.Seconds"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> Seconds(this Check<TimeSpan> check, Func<Check<int>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Seconds));

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.Ticks"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> Ticks(this Check<TimeSpan> check, Func<Check<long>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Ticks));

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.TotalDays"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> TotalDays(this Check<TimeSpan> check, Func<Check<double>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.TotalDays));

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.TotalHours"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> TotalHours(this Check<TimeSpan> check, Func<Check<double>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.TotalHours));

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.TotalMilliseconds"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> TotalMilliseconds(this Check<TimeSpan> check, Func<Check<double>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.TotalMilliseconds));

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.TotalMinutes"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> TotalMinutes(this Check<TimeSpan> check, Func<Check<double>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.TotalMinutes));

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.TotalSeconds"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> TotalSeconds(this Check<TimeSpan> check, Func<Check<double>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.TotalSeconds));

    //
    // TimeZoneInfo
    //

    /// <summary>
    /// Checks if the target's <see cref="TimeZoneInfo.BaseUtcOffset"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeZoneInfo> BaseUtcOffset(this Check<TimeZoneInfo> check, TimeSpan value) =>
      check.That(t => t?.BaseUtcOffset == value);

    /// <summary>
    /// Checks if the target's <see cref="TimeZoneInfo.DaylightName"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeZoneInfo> DaylightName(this Check<TimeZoneInfo> check, string value) =>
      check.That(t => t?.DaylightName == value);

    /// <summary>
    /// Checks if the target's <see cref="TimeZoneInfo.DisplayName"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeZoneInfo> DisplayName(this Check<TimeZoneInfo> check, string value) =>
      check.That(t => t?.DisplayName == value);

    /// <summary>
    /// Checks if the target's <see cref="TimeZoneInfo.Id"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeZoneInfo> Id(this Check<TimeZoneInfo> check, string value) =>
      check.That(t => t?.Id == value);

    /// <summary>
    /// Checks if the target's <see cref="TimeZoneInfo.ToSerializedString"/> method returns <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeZoneInfo> SerializedString(this Check<TimeZoneInfo> check, string value) =>
      check.That(t => t?.ToSerializedString() == value);

    /// <summary>
    /// Checks if the target's <see cref="TimeZoneInfo.StandardName"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeZoneInfo> StandardName(this Check<TimeZoneInfo> check, string value) =>
      check.That(t => t?.StandardName == value);

    /// <summary>
    /// Checks if the target's <see cref="TimeZoneInfo.SupportsDaylightSavingTime"/> property is <see langword="true"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeZoneInfo> SupportsDaylightSavingTime(this Check<TimeZoneInfo> check) =>
      check.That(t => t?.SupportsDaylightSavingTime == true);

    /// <summary>
    /// Checks if the target's <see cref="TimeZoneInfo.SupportsDaylightSavingTime"/> property is <see langword="false"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeZoneInfo> DoesNotSupportDaylightSavingTime(this Check<TimeZoneInfo> check) =>
      check.That(t => t?.SupportsDaylightSavingTime == false);

    //
    // TimeZoneInfo (values)
    //

    /// <summary>
    /// Checks if the target's <see cref="TimeZoneInfo.BaseUtcOffset"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeZoneInfo> BaseUtcOffset(this Check<TimeZoneInfo> check, Func<Check<TimeSpan>, bool> checkValue) =>
      check.That(t => t != null && checkValue.Invoke(t.BaseUtcOffset));

    /// <summary>
    /// Checks if the target's <see cref="TimeZoneInfo.DaylightName"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeZoneInfo> DaylightName(this Check<TimeZoneInfo> check, Func<Check<string>, bool> checkValue) =>
      check.That(t => t != null && checkValue.Invoke(t.DaylightName));

    /// <summary>
    /// Checks if the target's <see cref="TimeZoneInfo.DisplayName"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeZoneInfo> DisplayName(this Check<TimeZoneInfo> check, Func<Check<string>, bool> checkValue) =>
      check.That(t => t != null && checkValue.Invoke(t.DisplayName));

    /// <summary>
    /// Checks if the target's <see cref="TimeZoneInfo.Id"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeZoneInfo> Id(this Check<TimeZoneInfo> check, Func<Check<string>, bool> checkValue) =>
      check.That(t => t != null && checkValue.Invoke(t.Id));

    /// <summary>
    /// Checks if the target's <see cref="TimeZoneInfo.ToSerializedString"/> method results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeZoneInfo> SerializedString(this Check<TimeZoneInfo> check, Func<Check<string>, bool> checkValue) =>
      check.That(t => t != null && checkValue.Invoke(t.ToSerializedString()));

    /// <summary>
    /// Checks if the target's <see cref="TimeZoneInfo.StandardName"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeZoneInfo> StandardName(this Check<TimeZoneInfo> check, Func<Check<string>, bool> checkValue) =>
      check.That(t => t != null && checkValue.Invoke(t.StandardName));
  }
}