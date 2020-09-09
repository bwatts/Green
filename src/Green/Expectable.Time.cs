using System;
using Green.Messages;

namespace Green
{
  public static partial class Expectable
  {
    /// <summary>
    /// Expects the target's <see cref="DateTime.Date"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasDate(this Expect<DateTime> expect, DateTime value, Issue<DateTime>? issue = null) =>
      expect.That(t => t.Date == value, issue.ElseExpectedHas(nameof(DateTime.Date), value, t => t.Date));

    /// <summary>
    /// Expects the target's <see cref="DateTime.Day"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasDay(this Expect<DateTime> expect, int value, Issue<DateTime>? issue = null) =>
      expect.That(t => t.Day == value, issue.ElseExpectedHas(nameof(DateTime.Day), value, t => t.Day));

    /// <summary>
    /// Expects the target's <see cref="DateTime.DayOfWeek"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasDayOfWeek(this Expect<DateTime> expect, DayOfWeek value, Issue<DateTime>? issue = null) =>
      expect.That(t => t.DayOfWeek == value, issue.ElseExpectedHas(nameof(DateTime.DayOfWeek), value, t => t.DayOfWeek));

    /// <summary>
    /// Expects the target's <see cref="DateTime.DayOfYear"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasDayOfYear(this Expect<DateTime> expect, int value, Issue<DateTime>? issue = null) =>
      expect.That(t => t.DayOfYear == value, issue.ElseExpectedHas(nameof(DateTime.DayOfYear), value, t => t.DayOfYear));

    /// <summary>
    /// Expects the target's <see cref="DateTime.Hour"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasHour(this Expect<DateTime> expect, int value, Issue<DateTime>? issue = null) =>
      expect.That(t => t.Hour == value, issue.ElseExpectedHas(nameof(DateTime.Hour), value, t => t.Hour));

    /// <summary>
    /// Expects the target's <see cref="DateTime.Kind"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasKind(this Expect<DateTime> expect, DateTimeKind value, Issue<DateTime>? issue = null) =>
      expect.That(t => t.Kind == value, issue.ElseExpectedHas(nameof(DateTime.Kind), value, t => t.Kind));

    /// <summary>
    /// Expects the target's <see cref="DateTime.Millisecond"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasMillisecond(this Expect<DateTime> expect, int value, Issue<DateTime>? issue = null) =>
      expect.That(t => t.Millisecond == value, issue.ElseExpectedHas(nameof(DateTime.Millisecond), value, t => t.Millisecond));

    /// <summary>
    /// Expects the target's <see cref="DateTime.Minute"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasMinute(this Expect<DateTime> expect, int value, Issue<DateTime>? issue = null) =>
      expect.That(t => t.Minute == value, issue.ElseExpectedHas(nameof(DateTime.Minute), value, t => t.Minute));

    /// <summary>
    /// Expects the target's <see cref="DateTime.Month"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasMonth(this Expect<DateTime> expect, int value, Issue<DateTime>? issue = null) =>
      expect.That(t => t.Month == value, issue.ElseExpectedHas(nameof(DateTime.Month), value, t => t.Month));

    /// <summary>
    /// Expects the target's <see cref="DateTime.Second"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasSecond(this Expect<DateTime> expect, int value, Issue<DateTime>? issue = null) =>
      expect.That(t => t.Second == value, issue.ElseExpectedHas(nameof(DateTime.Second), value, t => t.Second));

    /// <summary>
    /// Expects the target's <see cref="DateTime.Ticks"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasTicks(this Expect<DateTime> expect, long value, Issue<DateTime>? issue = null) =>
      expect.That(t => t.Ticks == value, issue.ElseExpectedHas(nameof(DateTime.Ticks), value, t => t.Ticks));

    /// <summary>
    /// Expects the target's <see cref="DateTime.TimeOfDay"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasTimeOfDay(this Expect<DateTime> expect, TimeSpan value, Issue<DateTime>? issue = null) =>
      expect.That(t => t.TimeOfDay == value, issue.ElseExpectedHas(nameof(DateTime.TimeOfDay), value, t => t.TimeOfDay));

    /// <summary>
    /// Expects the target's <see cref="DateTime.Year"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasYear(this Expect<DateTime> expect, int value, Issue<DateTime>? issue = null) =>
      expect.That(t => t.Year == value, issue.ElseExpectedHas(nameof(DateTime.Year), value, t => t.Year));

    /// <summary>
    /// Expects the target falls on a leap year
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> IsLeapYear(this Expect<DateTime> expect, Issue<DateTime>? issue = null) =>
      expect.That(t => DateTime.IsLeapYear(t.Year), issue.ElseExpected("leap year"));

    /// <summary>
    /// Expects the target falls on a weekday
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> IsWeekday(this Expect<DateTime> expect, Issue<DateTime>? issue = null) =>
      expect.That(t => t.DayOfWeek != DayOfWeek.Saturday && t.DayOfWeek != DayOfWeek.Sunday, issue.ElseExpected("weekday"));

    /// <summary>
    /// Expects the target falls on a weekend
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> IsWeekend(this Expect<DateTime> expect, Issue<DateTime>? issue = null) =>
      expect.That(t => t.DayOfWeek == DayOfWeek.Saturday || t.DayOfWeek == DayOfWeek.Sunday, issue.ElseExpected("weekend"));

    //
    // DateTime (values)
    //

    /// <summary>
    /// Expects the target's <see cref="DateTime.Date"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasDate(this Expect<DateTime> expect, Action<Expect<DateTime>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Date));

    /// <summary>
    /// Expects the target's <see cref="DateTime.Day"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasDay(this Expect<DateTime> expect, Action<Expect<int>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Day));

    /// <summary>
    /// Expects the target's <see cref="DateTime.DayOfWeek"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasDayOfWeek(this Expect<DateTime> expect, Action<Expect<DayOfWeek>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.DayOfWeek));

    /// <summary>
    /// Expects the target's <see cref="DateTime.DayOfYear"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasDayOfYear(this Expect<DateTime> expect, Action<Expect<int>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.DayOfYear));

    /// <summary>
    /// Expects the target's <see cref="DateTime.Hour"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasHour(this Expect<DateTime> expect, Action<Expect<int>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Hour));

    /// <summary>
    /// Expects the target's <see cref="DateTime.Kind"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasKind(this Expect<DateTime> expect, Action<Expect<DateTimeKind>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Kind));

    /// <summary>
    /// Expects the target's <see cref="DateTime.Millisecond"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasMillisecond(this Expect<DateTime> expect, Action<Expect<int>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Millisecond));

    /// <summary>
    /// Expects the target's <see cref="DateTime.Minute"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasMinute(this Expect<DateTime> expect, Action<Expect<int>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Minute));

    /// <summary>
    /// Expects the target's <see cref="DateTime.Month"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasMonth(this Expect<DateTime> expect, Action<Expect<int>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Month));

    /// <summary>
    /// Expects the target's <see cref="DateTime.Second"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasSecond(this Expect<DateTime> expect, Action<Expect<int>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Second));

    /// <summary>
    /// Expects the target's <see cref="DateTime.Ticks"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasTicks(this Expect<DateTime> expect, Action<Expect<long>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Ticks));

    /// <summary>
    /// Expects the target's <see cref="DateTime.TimeOfDay"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasTimeOfDay(this Expect<DateTime> expect, Action<Expect<TimeSpan>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.TimeOfDay));

    /// <summary>
    /// Expects the target's <see cref="DateTime.Year"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasYear(this Expect<DateTime> expect, Action<Expect<int>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Year));

    //
    // DateTimeOffset
    //

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.Date"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasDate(this Expect<DateTimeOffset> expect, DateTime value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.Date == value, issue.ElseExpectedHas(nameof(DateTimeOffset.Date), value, t => t.Date));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.DateTime"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasDateTime(this Expect<DateTimeOffset> expect, DateTime value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.DateTime == value, issue.ElseExpectedHas(nameof(DateTimeOffset.DateTime), value, t => t.DateTime));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.Day"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasDay(this Expect<DateTimeOffset> expect, int value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.Day == value, issue.ElseExpectedHas(nameof(DateTimeOffset.Day), value, t => t.Day));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.DayOfWeek"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasDayOfWeek(this Expect<DateTimeOffset> expect, DayOfWeek value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.DayOfWeek == value, issue.ElseExpectedHas(nameof(DateTimeOffset.DayOfWeek), value, t => t.DayOfWeek));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.DayOfYear"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasDayOfYear(this Expect<DateTimeOffset> expect, int value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.DayOfYear == value, issue.ElseExpectedHas(nameof(DateTimeOffset.DayOfYear), value, t => t.DayOfYear));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.Hour"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasHour(this Expect<DateTimeOffset> expect, int value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.Hour == value, issue.ElseExpectedHas(nameof(DateTimeOffset.Hour), value, t => t.Hour));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.LocalDateTime"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasLocalDateTime(this Expect<DateTimeOffset> expect, DateTime value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.LocalDateTime == value, issue.ElseExpectedHas(nameof(DateTimeOffset.LocalDateTime), value, t => t.LocalDateTime));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.Millisecond"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasMillisecond(this Expect<DateTimeOffset> expect, int value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.Millisecond == value, issue.ElseExpectedHas(nameof(DateTimeOffset.Millisecond), value, t => t.Millisecond));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.Minute"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasMinute(this Expect<DateTimeOffset> expect, int value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.Minute == value, issue.ElseExpectedHas(nameof(DateTimeOffset.Minute), value, t => t.Minute));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.Month"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasMonth(this Expect<DateTimeOffset> expect, int value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.Month == value, issue.ElseExpectedHas(nameof(DateTimeOffset.Month), value, t => t.Month));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.Offset"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasOffset(this Expect<DateTimeOffset> expect, TimeSpan value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.Offset == value, issue.ElseExpectedHas(nameof(DateTimeOffset.Offset), value, t => t.Offset));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.Second"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasSecond(this Expect<DateTimeOffset> expect, int value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.Second == value, issue.ElseExpectedHas(nameof(DateTimeOffset.Second), value, t => t.Second));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.Ticks"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasTicks(this Expect<DateTimeOffset> expect, long value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.Ticks == value, issue.ElseExpectedHas(nameof(DateTimeOffset.Ticks), value, t => t.Ticks));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.TimeOfDay"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasTimeOfDay(this Expect<DateTimeOffset> expect, TimeSpan value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.TimeOfDay == value, issue.ElseExpectedHas(nameof(DateTimeOffset.TimeOfDay), value, t => t.TimeOfDay));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.UtcDateTime"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasUtcDateTime(this Expect<DateTimeOffset> expect, DateTime value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.UtcDateTime == value, issue.ElseExpectedHas(nameof(DateTimeOffset.UtcDateTime), value, t => t.UtcDateTime));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.UtcTicks"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasUtcTicks(this Expect<DateTimeOffset> expect, long value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.UtcTicks == value, issue.ElseExpectedHas(nameof(DateTimeOffset.UtcTicks), value, t => t.UtcTicks));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.Year"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasYear(this Expect<DateTimeOffset> expect, int value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.Year == value, issue.ElseExpectedHas(nameof(DateTimeOffset.Year), value, t => t.Year));

    /// <summary>
    /// Expects the target falls on a leap year
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> IsLeapYear(this Expect<DateTimeOffset> expect, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => DateTime.IsLeapYear(t.Year), issue.ElseExpected("leap year"));

    /// <summary>
    /// Expects the target falls on a weekday
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> IsWeekday(this Expect<DateTimeOffset> expect, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.DayOfWeek != DayOfWeek.Saturday && t.DayOfWeek != DayOfWeek.Sunday, issue.ElseExpected("weekday"));

    /// <summary>
    /// Expects the target falls on a weekend
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> IsWeekend(this Expect<DateTimeOffset> expect, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.DayOfWeek == DayOfWeek.Saturday || t.DayOfWeek == DayOfWeek.Sunday, issue.ElseExpected("weekend"));

    //
    // DateTimeOffset (values)
    //

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.Date"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasDate(this Expect<DateTimeOffset> expect, Action<Expect<DateTime>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Date));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.DateTime"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasDateTime(this Expect<DateTimeOffset> expect, Action<Expect<DateTime>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.DateTime));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.Day"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasDay(this Expect<DateTimeOffset> expect, Action<Expect<int>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Day));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.DayOfWeek"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasDayOfWeek(this Expect<DateTimeOffset> expect, Action<Expect<DayOfWeek>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.DayOfWeek));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.DayOfYear"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasDayOfYear(this Expect<DateTimeOffset> expect, Action<Expect<int>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.DayOfYear));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.Hour"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasHour(this Expect<DateTimeOffset> expect, Action<Expect<int>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Hour));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.LocalDateTime"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasLocalDateTime(this Expect<DateTimeOffset> expect, Action<Expect<DateTime>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.LocalDateTime));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.Millisecond"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasMillisecond(this Expect<DateTimeOffset> expect, Action<Expect<int>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Millisecond));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.Minute"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasMinute(this Expect<DateTimeOffset> expect, Action<Expect<int>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Minute));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.Month"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasMonth(this Expect<DateTimeOffset> expect, Action<Expect<int>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Month));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.Offset"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasOffset(this Expect<DateTimeOffset> expect, Action<Expect<TimeSpan>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Offset));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.Second"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasSecond(this Expect<DateTimeOffset> expect, Action<Expect<int>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Second));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.Ticks"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasTicks(this Expect<DateTimeOffset> expect, Action<Expect<long>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Ticks));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.TimeOfDay"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasTimeOfDay(this Expect<DateTimeOffset> expect, Action<Expect<TimeSpan>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.TimeOfDay));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.UtcDateTime"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasUtcDateTime(this Expect<DateTimeOffset> expect, Action<Expect<DateTime>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.UtcDateTime));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.UtcTicks"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasUtcTicks(this Expect<DateTimeOffset> expect, Action<Expect<long>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.UtcTicks));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.Year"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasYear(this Expect<DateTimeOffset> expect, Action<Expect<int>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Year));

    //
    // TimeSpan
    //

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.Days"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasDays(this Expect<TimeSpan> expect, int value, Issue<TimeSpan>? issue = null) =>
      expect.That(t => t.Days == value, issue.ElseExpectedHas(nameof(TimeSpan.Days), value, t => t.Days));

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.Duration"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasDuration(this Expect<TimeSpan> expect, TimeSpan value, Issue<TimeSpan>? issue = null) =>
      expect.That(t => t.Duration() == value, issue.ElseExpectedHas($"{nameof(TimeSpan.Duration)}()", value, t => t.Duration()));

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.Hours"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasHours(this Expect<TimeSpan> expect, int value, Issue<TimeSpan>? issue = null) =>
      expect.That(t => t.Hours == value, issue.ElseExpectedHas(nameof(TimeSpan.Hours), value, t => t.Hours));

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.Milliseconds"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasMilliseconds(this Expect<TimeSpan> expect, int value, Issue<TimeSpan>? issue = null) =>
      expect.That(t => t.Milliseconds == value, issue.ElseExpectedHas(nameof(TimeSpan.Milliseconds), value, t => t.Milliseconds));

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.Minutes"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasMinutes(this Expect<TimeSpan> expect, int value, Issue<TimeSpan>? issue = null) =>
      expect.That(t => t.Minutes == value, issue.ElseExpectedHas(nameof(TimeSpan.Minutes), value, t => t.Minutes));

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.Negate"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasNegated(this Expect<TimeSpan> expect, TimeSpan value, Issue<TimeSpan>? issue = null) =>
      expect.That(t => t.Negate() == value, issue.ElseExpectedHas($"{nameof(TimeSpan.Negate)}()", value, t => t.Negate()));

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.Seconds"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasSeconds(this Expect<TimeSpan> expect, int value, Issue<TimeSpan>? issue = null) =>
      expect.That(t => t.Seconds == value, issue.ElseExpectedHas(nameof(TimeSpan.Seconds), value, t => t.Seconds));

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.Ticks"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasTicks(this Expect<TimeSpan> expect, long value, Issue<TimeSpan>? issue = null) =>
      expect.That(t => t.Ticks == value, issue.ElseExpectedHas(nameof(TimeSpan.Ticks), value, t => t.Ticks));

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.TotalDays"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasTotalDays(this Expect<TimeSpan> expect, double value, Issue<TimeSpan>? issue = null) =>
      expect.That(t => t.TotalDays == value, issue.ElseExpectedHas(nameof(TimeSpan.TotalDays), value, t => t.TotalDays));

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.TotalHours"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasTotalHours(this Expect<TimeSpan> expect, double value, Issue<TimeSpan>? issue = null) =>
      expect.That(t => t.TotalHours == value, issue.ElseExpectedHas(nameof(TimeSpan.TotalHours), value, t => t.TotalHours));

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.TotalMilliseconds"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasTotalMilliseconds(this Expect<TimeSpan> expect, double value, Issue<TimeSpan>? issue = null) =>
      expect.That(t => t.TotalMilliseconds == value, issue.ElseExpectedHas(nameof(TimeSpan.TotalMilliseconds), value, t => t.TotalMilliseconds));

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.TotalMinutes"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasTotalMinutes(this Expect<TimeSpan> expect, double value, Issue<TimeSpan>? issue = null) =>
      expect.That(t => t.TotalMinutes == value, issue.ElseExpectedHas(nameof(TimeSpan.TotalMinutes), value, t => t.TotalMinutes));

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.TotalSeconds"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasTotalSeconds(this Expect<TimeSpan> expect, double value, Issue<TimeSpan>? issue = null) =>
      expect.That(t => t.TotalSeconds == value, issue.ElseExpectedHas(nameof(TimeSpan.TotalSeconds), value, t => t.TotalSeconds));

    //
    // TimeSpan (values)
    //

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.Days"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasDays(this Expect<TimeSpan> expect, Action<Expect<int>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Days));

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.Duration"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasDuration(this Expect<TimeSpan> expect, Action<Expect<TimeSpan>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Duration()));

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.Hours"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasHours(this Expect<TimeSpan> expect, Action<Expect<int>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Hours));

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.Milliseconds"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasMilliseconds(this Expect<TimeSpan> expect, Action<Expect<int>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Milliseconds));

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.Minutes"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasMinutes(this Expect<TimeSpan> expect, Action<Expect<int>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Minutes));

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.Negate"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasNegated(this Expect<TimeSpan> expect, Action<Expect<TimeSpan>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Negate()));

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.Seconds"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasSeconds(this Expect<TimeSpan> expect, Action<Expect<int>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Seconds));

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.Ticks"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasTicks(this Expect<TimeSpan> expect, Action<Expect<long>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Ticks));

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.TotalDays"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasTotalDays(this Expect<TimeSpan> expect, Action<Expect<double>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.TotalDays));

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.TotalHours"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasTotalHours(this Expect<TimeSpan> expect, Action<Expect<double>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.TotalHours));

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.TotalMilliseconds"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasTotalMilliseconds(this Expect<TimeSpan> expect, Action<Expect<double>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.TotalMilliseconds));

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.TotalMinutes"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasTotalMinutes(this Expect<TimeSpan> expect, Action<Expect<double>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.TotalMinutes));

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.TotalSeconds"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasTotalSeconds(this Expect<TimeSpan> expect, Action<Expect<double>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.TotalSeconds));

    //
    // TimeZoneInfo
    //

    /// <summary>
    /// Expects the target's <see cref="TimeZoneInfo.BaseUtcOffset"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeZoneInfo> HasBaseUtcOffset(this Expect<TimeZoneInfo> expect, TimeSpan value, Issue<TimeZoneInfo>? issue = null) =>
      expect.That(t => t?.BaseUtcOffset == value, issue.ElseExpectedHas(nameof(TimeZoneInfo.BaseUtcOffset), value, t => t.BaseUtcOffset));

    /// <summary>
    /// Expects the target's <see cref="TimeZoneInfo.DaylightName"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeZoneInfo> HasDaylightName(this Expect<TimeZoneInfo> expect, string value, Issue<TimeZoneInfo>? issue = null) =>
      expect.That(t => t?.DaylightName == value, issue.ElseExpectedHas(nameof(TimeZoneInfo.DaylightName), value, t => t.DaylightName));

    /// <summary>
    /// Expects the target's <see cref="TimeZoneInfo.DisplayName"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeZoneInfo> HasDisplayName(this Expect<TimeZoneInfo> expect, string value, Issue<TimeZoneInfo>? issue = null) =>
      expect.That(t => t?.DisplayName == value, issue.ElseExpectedHas(nameof(TimeZoneInfo.DisplayName), value, t => t.DisplayName));

    /// <summary>
    /// Expects the target's <see cref="TimeZoneInfo.Id"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeZoneInfo> HasId(this Expect<TimeZoneInfo> expect, string value, Issue<TimeZoneInfo>? issue = null) =>
      expect.That(t => t?.Id == value, issue.ElseExpectedHas(nameof(TimeZoneInfo.Id), value, t => t.Id));

    /// <summary>
    /// Expects the target's <see cref="TimeZoneInfo.ToSerializedString"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeZoneInfo> HasSerializedString(this Expect<TimeZoneInfo> expect, string value, Issue<TimeZoneInfo>? issue = null) =>
      expect.That(t => t?.ToSerializedString() == value, issue.ElseExpectedHas($"{nameof(TimeZoneInfo.ToSerializedString)}()", value, t => t.ToSerializedString()));

    /// <summary>
    /// Expects the target's <see cref="TimeZoneInfo.StandardName"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeZoneInfo> HasStandardName(this Expect<TimeZoneInfo> expect, string value, Issue<TimeZoneInfo>? issue = null) =>
      expect.That(t => t?.StandardName == value, issue.ElseExpectedHas(nameof(TimeZoneInfo.StandardName), value, t => t.StandardName));

    /// <summary>
    /// Expects the target's <see cref="TimeZoneInfo.SupportsDaylightSavingTime"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeZoneInfo> SupportsDaylightSavingTime(this Expect<TimeZoneInfo> expect, bool value, Issue<TimeZoneInfo>? issue = null) =>
      expect.That(t => t?.SupportsDaylightSavingTime == value, issue.ElseExpectedHas(nameof(TimeZoneInfo.SupportsDaylightSavingTime), value, t => t.SupportsDaylightSavingTime));

    //
    // TimeZoneInfo (values)
    //

    /// <summary>
    /// Expects the target's <see cref="TimeZoneInfo.BaseUtcOffset"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeZoneInfo> HasBaseUtcOffset(this Expect<TimeZoneInfo> expect, Action<Expect<TimeSpan>> expectValue) =>
      expect.That(t => t != null && expectValue.Invoke(t.BaseUtcOffset));

    /// <summary>
    /// Expects the target's <see cref="TimeZoneInfo.DaylightName"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeZoneInfo> HasDaylightName(this Expect<TimeZoneInfo> expect, Action<Expect<string>> expectValue) =>
      expect.That(t => t != null && expectValue.Invoke(t.DaylightName));

    /// <summary>
    /// Expects the target's <see cref="TimeZoneInfo.DisplayName"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeZoneInfo> HasDisplayName(this Expect<TimeZoneInfo> expect, Action<Expect<string>> expectValue) =>
      expect.That(t => t != null && expectValue.Invoke(t.DisplayName));

    /// <summary>
    /// Expects the target's <see cref="TimeZoneInfo.Id"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeZoneInfo> HasId(this Expect<TimeZoneInfo> expect, Action<Expect<string>> expectValue) =>
      expect.That(t => t != null && expectValue.Invoke(t.Id));

    /// <summary>
    /// Expects the target's <see cref="TimeZoneInfo.ToSerializedString"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeZoneInfo> HasSerializedString(this Expect<TimeZoneInfo> expect, Action<Expect<string>> expectValue) =>
      expect.That(t => t != null && expectValue.Invoke(t.ToSerializedString()));

    /// <summary>
    /// Expects the target's <see cref="TimeZoneInfo.StandardName"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeZoneInfo> HasStandardName(this Expect<TimeZoneInfo> expect, Action<Expect<string>> expectValue) =>
      expect.That(t => t != null && expectValue.Invoke(t.StandardName));
  }
}