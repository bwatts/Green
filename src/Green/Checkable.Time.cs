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
    public static Check<DateTime> HasDate(this Check<DateTime> check, DateTime value) =>
      check.That(t => t.Date == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTime.Day"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> HasDay(this Check<DateTime> check, int value) =>
      check.That(t => t.Day == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTime.DayOfWeek"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> HasDayOfWeek(this Check<DateTime> check, DayOfWeek value) =>
      check.That(t => t.DayOfWeek == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTime.DayOfYear"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> HasDayOfYear(this Check<DateTime> check, int value) =>
      check.That(t => t.DayOfYear == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTime.Hour"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> HasHour(this Check<DateTime> check, int value) =>
      check.That(t => t.Hour == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTime.Kind"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> HasKind(this Check<DateTime> check, DateTimeKind value) =>
      check.That(t => t.Kind == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTime.Millisecond"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> HasMillisecond(this Check<DateTime> check, int value) =>
      check.That(t => t.Millisecond == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTime.Minute"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> HasMinute(this Check<DateTime> check, int value) =>
      check.That(t => t.Minute == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTime.Month"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> HasMonth(this Check<DateTime> check, int value) =>
      check.That(t => t.Month == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTime.Second"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> HasSecond(this Check<DateTime> check, int value) =>
      check.That(t => t.Second == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTime.Ticks"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> HasTicks(this Check<DateTime> check, long value) =>
      check.That(t => t.Ticks == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTime.TimeOfDay"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> HasTimeOfDay(this Check<DateTime> check, TimeSpan value) =>
      check.That(t => t.TimeOfDay == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTime.Year"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> HasYear(this Check<DateTime> check, int value) =>
      check.That(t => t.Year == value);

    /// <summary>
    /// Checks if the target falls on a leap year
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> IsLeapYear(this Check<DateTime> check) =>
      check.That(t => DateTime.IsLeapYear(t.Year));

    /// <summary>
    /// Checks if the target is a weekday
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> IsWeekday(this Check<DateTime> check) =>
      check.That(t => t.DayOfWeek != DayOfWeek.Saturday && t.DayOfWeek != DayOfWeek.Sunday);

    /// <summary>
    /// Checks if the target is a weekend day
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> IsWeekend(this Check<DateTime> check) =>
      check.That(t => t.DayOfWeek == DayOfWeek.Saturday || t.DayOfWeek == DayOfWeek.Sunday);

    //
    // DateTime (values)
    //

    /// <summary>
    /// Checks if the target's <see cref="DateTime.Date"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> HasDate(this Check<DateTime> check, Func<Check<DateTime>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Date));

    /// <summary>
    /// Checks if the target's <see cref="DateTime.Day"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> HasDay(this Check<DateTime> check, Func<Check<int>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Day));

    /// <summary>
    /// Checks if the target's <see cref="DateTime.DayOfWeek"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> HasDayOfWeek(this Check<DateTime> check, Func<Check<DayOfWeek>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.DayOfWeek));

    /// <summary>
    /// Checks if the target's <see cref="DateTime.DayOfYear"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> HasDayOfYear(this Check<DateTime> check, Func<Check<int>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.DayOfYear));

    /// <summary>
    /// Checks if the target's <see cref="DateTime.Hour"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> HasHour(this Check<DateTime> check, Func<Check<int>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Hour));

    /// <summary>
    /// Checks if the target's <see cref="DateTime.Kind"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> HasKind(this Check<DateTime> check, Func<Check<DateTimeKind>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Kind));

    /// <summary>
    /// Checks if the target's <see cref="DateTime.Millisecond"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> HasMillisecond(this Check<DateTime> check, Func<Check<int>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Millisecond));

    /// <summary>
    /// Checks if the target's <see cref="DateTime.Minute"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> HasMinute(this Check<DateTime> check, Func<Check<int>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Minute));

    /// <summary>
    /// Checks if the target's <see cref="DateTime.Month"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> HasMonth(this Check<DateTime> check, Func<Check<int>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Month));

    /// <summary>
    /// Checks if the target's <see cref="DateTime.Second"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> HasSecond(this Check<DateTime> check, Func<Check<int>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Second));

    /// <summary>
    /// Checks if the target's <see cref="DateTime.Ticks"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> HasTicks(this Check<DateTime> check, Func<Check<long>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Ticks));

    /// <summary>
    /// Checks if the target's <see cref="DateTime.TimeOfDay"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> HasTimeOfDay(this Check<DateTime> check, Func<Check<TimeSpan>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.TimeOfDay));

    /// <summary>
    /// Checks if the target's <see cref="DateTime.Year"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTime> HasYear(this Check<DateTime> check, Func<Check<int>, bool> checkValue) =>
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
    public static Check<DateTimeOffset> HasDate(this Check<DateTimeOffset> check, DateTime value) =>
      check.That(t => t.Date == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.DateTime"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> HasDateTime(this Check<DateTimeOffset> check, DateTime value) =>
      check.That(t => t.DateTime == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.Day"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> HasDay(this Check<DateTimeOffset> check, int value) =>
      check.That(t => t.Day == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.DayOfWeek"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> HasDayOfWeek(this Check<DateTimeOffset> check, DayOfWeek value) =>
      check.That(t => t.DayOfWeek == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.DayOfYear"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> HasDayOfYear(this Check<DateTimeOffset> check, int value) =>
      check.That(t => t.DayOfYear == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.Hour"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> HasHour(this Check<DateTimeOffset> check, int value) =>
      check.That(t => t.Hour == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.LocalDateTime"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> HasLocalDateTime(this Check<DateTimeOffset> check, DateTime value) =>
      check.That(t => t.LocalDateTime == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.Millisecond"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> HasMillisecond(this Check<DateTimeOffset> check, int value) =>
      check.That(t => t.Millisecond == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.Minute"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> HasMinute(this Check<DateTimeOffset> check, int value) =>
      check.That(t => t.Minute == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.Month"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> HasMonth(this Check<DateTimeOffset> check, int value) =>
      check.That(t => t.Month == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.Offset"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> HasOffset(this Check<DateTimeOffset> check, TimeSpan value) =>
      check.That(t => t.Offset == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.Second"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> HasSecond(this Check<DateTimeOffset> check, int value) =>
      check.That(t => t.Second == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.Ticks"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> HasTicks(this Check<DateTimeOffset> check, long value) =>
      check.That(t => t.Ticks == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.TimeOfDay"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> HasTimeOfDay(this Check<DateTimeOffset> check, TimeSpan value) =>
      check.That(t => t.TimeOfDay == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.UtcDateTime"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> HasUtcDateTime(this Check<DateTimeOffset> check, DateTime value) =>
      check.That(t => t.UtcDateTime == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.UtcTicks"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> HasUtcTicks(this Check<DateTimeOffset> check, long value) =>
      check.That(t => t.UtcTicks == value);

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.Year"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> HasYear(this Check<DateTimeOffset> check, int value) =>
      check.That(t => t.Year == value);

    /// <summary>
    /// Checks if the target falls on a leap year
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> IsLeapYear(this Check<DateTimeOffset> check) =>
      check.That(t => t != null && DateTime.IsLeapYear(t.Year));

    /// <summary>
    /// Checks if the target is a weekday
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> IsWeekday(this Check<DateTimeOffset> check) =>
      check.That(t => t.DayOfWeek != DayOfWeek.Saturday && t.DayOfWeek != DayOfWeek.Sunday);

    /// <summary>
    /// Checks if the target is a weekend
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> IsWeekend(this Check<DateTimeOffset> check) =>
      check.That(t => t.DayOfWeek == DayOfWeek.Saturday || t.DayOfWeek == DayOfWeek.Sunday);

    //
    // DateTimeOffset (values)
    //

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.Date"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> HasDate(this Check<DateTimeOffset> check, Func<Check<DateTime>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Date));

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.DateTime"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> HasDateTime(this Check<DateTimeOffset> check, Func<Check<DateTime>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.DateTime));

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.Day"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> HasDay(this Check<DateTimeOffset> check, Func<Check<int>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Day));

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.DayOfWeek"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> HasDayOfWeek(this Check<DateTimeOffset> check, Func<Check<DayOfWeek>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.DayOfWeek));

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.DayOfYear"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> HasDayOfYear(this Check<DateTimeOffset> check, Func<Check<int>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.DayOfYear));

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.Hour"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> HasHour(this Check<DateTimeOffset> check, Func<Check<int>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Hour));

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.LocalDateTime"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> HasLocalDateTime(this Check<DateTimeOffset> check, Func<Check<DateTime>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.LocalDateTime));

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.Millisecond"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> HasMillisecond(this Check<DateTimeOffset> check, Func<Check<int>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Millisecond));

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.Minute"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> HasMinute(this Check<DateTimeOffset> check, Func<Check<int>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Minute));

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.Month"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> HasMonth(this Check<DateTimeOffset> check, Func<Check<int>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Month));

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.Offset"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> HasOffset(this Check<DateTimeOffset> check, Func<Check<TimeSpan>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Offset));

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.Second"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> HasSecond(this Check<DateTimeOffset> check, Func<Check<int>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Second));

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.Ticks"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> HasTicks(this Check<DateTimeOffset> check, Func<Check<long>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Ticks));

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.TimeOfDay"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> HasTimeOfDay(this Check<DateTimeOffset> check, Func<Check<TimeSpan>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.TimeOfDay));

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.UtcDateTime"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> HasUtcDateTime(this Check<DateTimeOffset> check, Func<Check<DateTime>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.UtcDateTime));

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.UtcTicks"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> HasUtcTicks(this Check<DateTimeOffset> check, Func<Check<long>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.UtcTicks));

    /// <summary>
    /// Checks if the target's <see cref="DateTimeOffset.Year"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<DateTimeOffset> HasYear(this Check<DateTimeOffset> check, Func<Check<int>, bool> checkValue) =>
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
    public static Check<TimeSpan> HasDays(this Check<TimeSpan> check, int value) =>
      check.That(t => t.Days == value);

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.Duration"/> method returns <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> HasDuration(this Check<TimeSpan> check, TimeSpan value) =>
      check.That(t => t.Duration() == value);

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.Hours"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> HasHours(this Check<TimeSpan> check, int value) =>
      check.That(t => t.Hours == value);

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.Milliseconds"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> HasMilliseconds(this Check<TimeSpan> check, int value) =>
      check.That(t => t.Milliseconds == value);

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.Minutes"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> HasMinutes(this Check<TimeSpan> check, int value) =>
      check.That(t => t.Minutes == value);

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.Negate"/> method returns <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> HasNegated(this Check<TimeSpan> check, TimeSpan value) =>
      check.That(t => t.Negate() == value);

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.Seconds"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> HasSeconds(this Check<TimeSpan> check, int value) =>
      check.That(t => t.Seconds == value);

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.Ticks"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> HasTicks(this Check<TimeSpan> check, long value) =>
      check.That(t => t.Ticks == value);

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.TotalDays"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> HasTotalDays(this Check<TimeSpan> check, double value) =>
      check.That(t => t.TotalDays == value);

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.TotalHours"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> HasTotalHours(this Check<TimeSpan> check, double value) =>
      check.That(t => t.TotalHours == value);

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.TotalMilliseconds"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> HasTotalMilliseconds(this Check<TimeSpan> check, double value) =>
      check.That(t => t.TotalMilliseconds == value);

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.TotalMinutes"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> HasTotalMinutes(this Check<TimeSpan> check, double value) =>
      check.That(t => t.TotalMinutes == value);

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.TotalSeconds"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> HasTotalSeconds(this Check<TimeSpan> check, double value) =>
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
    public static Check<TimeSpan> HasDays(this Check<TimeSpan> check, Func<Check<int>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Days));

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.Duration"/> method results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> HasDuration(this Check<TimeSpan> check, Func<Check<TimeSpan>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Duration()));

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.Hours"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> HasHours(this Check<TimeSpan> check, Func<Check<int>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Hours));

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.Milliseconds"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> HasMilliseconds(this Check<TimeSpan> check, Func<Check<int>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Milliseconds));

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.Minutes"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> HasMinutes(this Check<TimeSpan> check, Func<Check<int>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Minutes));

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.Negate"/> method results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> HasNegated(this Check<TimeSpan> check, Func<Check<TimeSpan>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Negate()));

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.Seconds"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> HasSeconds(this Check<TimeSpan> check, Func<Check<int>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Seconds));

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.Ticks"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> HasTicks(this Check<TimeSpan> check, Func<Check<long>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.Ticks));

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.TotalDays"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> HasTotalDays(this Check<TimeSpan> check, Func<Check<double>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.TotalDays));

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.TotalHours"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> HasTotalHours(this Check<TimeSpan> check, Func<Check<double>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.TotalHours));

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.TotalMilliseconds"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> HasTotalMilliseconds(this Check<TimeSpan> check, Func<Check<double>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.TotalMilliseconds));

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.TotalMinutes"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> HasTotalMinutes(this Check<TimeSpan> check, Func<Check<double>, bool> checkValue) =>
      check.That(t => checkValue.Invoke(t.TotalMinutes));

    /// <summary>
    /// Checks if the target's <see cref="TimeSpan.TotalSeconds"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeSpan> HasTotalSeconds(this Check<TimeSpan> check, Func<Check<double>, bool> checkValue) =>
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
    public static Check<TimeZoneInfo> HasBaseUtcOffset(this Check<TimeZoneInfo> check, TimeSpan value) =>
      check.That(t => t?.BaseUtcOffset == value);

    /// <summary>
    /// Checks if the target's <see cref="TimeZoneInfo.DaylightName"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeZoneInfo> HasDaylightName(this Check<TimeZoneInfo> check, string value) =>
      check.That(t => t?.DaylightName == value);

    /// <summary>
    /// Checks if the target's <see cref="TimeZoneInfo.DisplayName"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeZoneInfo> HasDisplayName(this Check<TimeZoneInfo> check, string value) =>
      check.That(t => t?.DisplayName == value);

    /// <summary>
    /// Checks if the target's <see cref="TimeZoneInfo.Id"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeZoneInfo> HasId(this Check<TimeZoneInfo> check, string value) =>
      check.That(t => t?.Id == value);

    /// <summary>
    /// Checks if the target's <see cref="TimeZoneInfo.ToSerializedString"/> method returns <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeZoneInfo> HasSerializedString(this Check<TimeZoneInfo> check, string value) =>
      check.That(t => t?.ToSerializedString() == value);

    /// <summary>
    /// Checks if the target's <see cref="TimeZoneInfo.StandardName"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeZoneInfo> HasStandardName(this Check<TimeZoneInfo> check, string value) =>
      check.That(t => t?.StandardName == value);

    /// <summary>
    /// Checks if the target's <see cref="TimeZoneInfo.SupportsDaylightSavingTime"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeZoneInfo> SupportsDaylightSavingTime(this Check<TimeZoneInfo> check, bool value) =>
      check.That(t => t?.SupportsDaylightSavingTime == value);

    //
    // TimeZoneInfo (values)
    //

    /// <summary>
    /// Checks if the target's <see cref="TimeZoneInfo.BaseUtcOffset"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeZoneInfo> HasBaseUtcOffset(this Check<TimeZoneInfo> check, Func<Check<TimeSpan>, bool> checkValue) =>
      check.That(t => t != null && checkValue.Invoke(t.BaseUtcOffset));

    /// <summary>
    /// Checks if the target's <see cref="TimeZoneInfo.DaylightName"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeZoneInfo> HasDaylightName(this Check<TimeZoneInfo> check, Func<Check<string>, bool> checkValue) =>
      check.That(t => t != null && checkValue.Invoke(t.DaylightName));

    /// <summary>
    /// Checks if the target's <see cref="TimeZoneInfo.DisplayName"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeZoneInfo> HasDisplayName(this Check<TimeZoneInfo> check, Func<Check<string>, bool> checkValue) =>
      check.That(t => t != null && checkValue.Invoke(t.DisplayName));

    /// <summary>
    /// Checks if the target's <see cref="TimeZoneInfo.Id"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeZoneInfo> HasId(this Check<TimeZoneInfo> check, Func<Check<string>, bool> checkValue) =>
      check.That(t => t != null && checkValue.Invoke(t.Id));

    /// <summary>
    /// Checks if the target's <see cref="TimeZoneInfo.ToSerializedString"/> method results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeZoneInfo> HasSerializedString(this Check<TimeZoneInfo> check, Func<Check<string>, bool> checkValue) =>
      check.That(t => t != null && checkValue.Invoke(t.ToSerializedString()));

    /// <summary>
    /// Checks if the target's <see cref="TimeZoneInfo.StandardName"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<TimeZoneInfo> HasStandardName(this Check<TimeZoneInfo> check, Func<Check<string>, bool> checkValue) =>
      check.That(t => t != null && checkValue.Invoke(t.StandardName));
  }
}