using System;

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
      expect.That(t => t.Date == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="DateTime.Day"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasDay(this Expect<DateTime> expect, int value, Issue<DateTime>? issue = null) =>
      expect.That(t => t.Day == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="DateTime.DayOfWeek"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasDayOfWeek(this Expect<DateTime> expect, DayOfWeek value, Issue<DateTime>? issue = null) =>
      expect.That(t => t.DayOfWeek == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="DateTime.DayOfYear"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasDayOfYear(this Expect<DateTime> expect, int value, Issue<DateTime>? issue = null) =>
      expect.That(t => t.DayOfYear == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="DateTime.Hour"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasHour(this Expect<DateTime> expect, int value, Issue<DateTime>? issue = null) =>
      expect.That(t => t.Hour == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="DateTime.Kind"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasKind(this Expect<DateTime> expect, DateTimeKind value, Issue<DateTime>? issue = null) =>
      expect.That(t => t.Kind == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="DateTime.Millisecond"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasMillisecond(this Expect<DateTime> expect, int value, Issue<DateTime>? issue = null) =>
      expect.That(t => t.Millisecond == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="DateTime.Minute"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasMinute(this Expect<DateTime> expect, int value, Issue<DateTime>? issue = null) =>
      expect.That(t => t.Minute == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="DateTime.Month"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasMonth(this Expect<DateTime> expect, int value, Issue<DateTime>? issue = null) =>
      expect.That(t => t.Month == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="DateTime.Second"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasSecond(this Expect<DateTime> expect, int value, Issue<DateTime>? issue = null) =>
      expect.That(t => t.Second == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="DateTime.Ticks"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasTicks(this Expect<DateTime> expect, long value, Issue<DateTime>? issue = null) =>
      expect.That(t => t.Ticks == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="DateTime.TimeOfDay"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasTimeOfDay(this Expect<DateTime> expect, TimeSpan value, Issue<DateTime>? issue = null) =>
      expect.That(t => t.TimeOfDay == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="DateTime.Year"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasYear(this Expect<DateTime> expect, int value, Issue<DateTime>? issue = null) =>
      expect.That(t => t.Year == value, issue.Operator(value));

    /// <summary>
    /// Expects the target falls on a leap year
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> IsLeapYear(this Expect<DateTime> expect, Issue<DateTime>? issue = null) =>
      expect.That(t => DateTime.IsLeapYear(t.Year), issue.Operator());

    /// <summary>
    /// Expects the target falls on a weekday
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> IsWeekday(this Expect<DateTime> expect, Issue<DateTime>? issue = null) =>
      expect.That(t => t.DayOfWeek != DayOfWeek.Saturday && t.DayOfWeek != DayOfWeek.Sunday, issue.Operator());

    /// <summary>
    /// Expects the target falls on a weekend
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> IsWeekend(this Expect<DateTime> expect, Issue<DateTime>? issue = null) =>
      expect.That(t => t.DayOfWeek == DayOfWeek.Saturday || t.DayOfWeek == DayOfWeek.Sunday, issue.Operator());

    //
    // DateTime (values)
    //

    /// <summary>
    /// Expects the target's <see cref="DateTime.Date"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasDate(this Expect<DateTime> expect, Action<Expect<DateTime>> expectValue, Issue<DateTime>? issue = null) =>
      expect.That(t => expectValue.Invoke(t.Date), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="DateTime.Day"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasDay(this Expect<DateTime> expect, Action<Expect<int>> expectValue, Issue<DateTime>? issue = null) =>
      expect.That(t => expectValue.Invoke(t.Day), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="DateTime.DayOfWeek"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasDayOfWeek(this Expect<DateTime> expect, Action<Expect<DayOfWeek>> expectValue, Issue<DateTime>? issue = null) =>
      expect.That(t => expectValue.Invoke(t.DayOfWeek), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="DateTime.DayOfYear"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasDayOfYear(this Expect<DateTime> expect, Action<Expect<int>> expectValue, Issue<DateTime>? issue = null) =>
      expect.That(t => expectValue.Invoke(t.DayOfYear), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="DateTime.Hour"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasHour(this Expect<DateTime> expect, Action<Expect<int>> expectValue, Issue<DateTime>? issue = null) =>
      expect.That(t => expectValue.Invoke(t.Hour), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="DateTime.Kind"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasKind(this Expect<DateTime> expect, Action<Expect<DateTimeKind>> expectValue, Issue<DateTime>? issue = null) =>
      expect.That(t => expectValue.Invoke(t.Kind), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="DateTime.Millisecond"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasMillisecond(this Expect<DateTime> expect, Action<Expect<int>> expectValue, Issue<DateTime>? issue = null) =>
      expect.That(t => expectValue.Invoke(t.Millisecond), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="DateTime.Minute"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasMinute(this Expect<DateTime> expect, Action<Expect<int>> expectValue, Issue<DateTime>? issue = null) =>
      expect.That(t => expectValue.Invoke(t.Minute), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="DateTime.Month"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasMonth(this Expect<DateTime> expect, Action<Expect<int>> expectValue, Issue<DateTime>? issue = null) =>
      expect.That(t => expectValue.Invoke(t.Month), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="DateTime.Second"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasSecond(this Expect<DateTime> expect, Action<Expect<int>> expectValue, Issue<DateTime>? issue = null) =>
      expect.That(t => expectValue.Invoke(t.Second), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="DateTime.Ticks"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasTicks(this Expect<DateTime> expect, Action<Expect<long>> expectValue, Issue<DateTime>? issue = null) =>
      expect.That(t => expectValue.Invoke(t.Ticks), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="DateTime.TimeOfDay"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasTimeOfDay(this Expect<DateTime> expect, Action<Expect<TimeSpan>> expectValue, Issue<DateTime>? issue = null) =>
      expect.That(t => expectValue.Invoke(t.TimeOfDay), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="DateTime.Year"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTime> HasYear(this Expect<DateTime> expect, Action<Expect<int>> expectValue, Issue<DateTime>? issue = null) =>
      expect.That(t => expectValue.Invoke(t.Year), issue.Operator(expectValue));

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
      expect.That(t => t.Date == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.DateTime"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasDateTime(this Expect<DateTimeOffset> expect, DateTime value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.DateTime == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.Day"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasDay(this Expect<DateTimeOffset> expect, int value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.Day == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.DayOfWeek"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasDayOfWeek(this Expect<DateTimeOffset> expect, DayOfWeek value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.DayOfWeek == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.DayOfYear"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasDayOfYear(this Expect<DateTimeOffset> expect, int value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.DayOfYear == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.Hour"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasHour(this Expect<DateTimeOffset> expect, int value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.Hour == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.LocalDateTime"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasLocalDateTime(this Expect<DateTimeOffset> expect, DateTime value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.LocalDateTime == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.Millisecond"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasMillisecond(this Expect<DateTimeOffset> expect, int value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.Millisecond == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.Minute"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasMinute(this Expect<DateTimeOffset> expect, int value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.Minute == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.Month"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasMonth(this Expect<DateTimeOffset> expect, int value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.Month == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.Offset"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasOffset(this Expect<DateTimeOffset> expect, TimeSpan value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.Offset == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.Second"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasSecond(this Expect<DateTimeOffset> expect, int value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.Second == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.Ticks"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasTicks(this Expect<DateTimeOffset> expect, long value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.Ticks == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.TimeOfDay"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasTimeOfDay(this Expect<DateTimeOffset> expect, TimeSpan value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.TimeOfDay == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.UtcDateTime"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasUtcDateTime(this Expect<DateTimeOffset> expect, DateTime value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.UtcDateTime == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.UtcTicks"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasUtcTicks(this Expect<DateTimeOffset> expect, long value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.UtcTicks == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.Year"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasYear(this Expect<DateTimeOffset> expect, int value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.Year == value, issue.Operator(value));

    /// <summary>
    /// Expects the target falls on a leap year
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> IsLeapYear(this Expect<DateTimeOffset> expect, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => DateTime.IsLeapYear(t.Year), issue.Operator());

    /// <summary>
    /// Expects the target falls on a weekday
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> IsWeekday(this Expect<DateTimeOffset> expect, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.DayOfWeek != DayOfWeek.Saturday && t.DayOfWeek != DayOfWeek.Sunday, issue.Operator());

    /// <summary>
    /// Expects the target falls on a weekend
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> IsWeekend(this Expect<DateTimeOffset> expect, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.DayOfWeek == DayOfWeek.Saturday || t.DayOfWeek == DayOfWeek.Sunday, issue.Operator());

    //
    // DateTimeOffset (values)
    //

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.Date"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasDate(this Expect<DateTimeOffset> expect, Action<Expect<DateTime>> expectValue, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => expectValue.Invoke(t.Date), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.DateTime"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasDateTime(this Expect<DateTimeOffset> expect, Action<Expect<DateTime>> expectValue, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => expectValue.Invoke(t.DateTime), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.Day"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasDay(this Expect<DateTimeOffset> expect, Action<Expect<int>> expectValue, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => expectValue.Invoke(t.Day), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.DayOfWeek"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasDayOfWeek(this Expect<DateTimeOffset> expect, Action<Expect<DayOfWeek>> expectValue, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => expectValue.Invoke(t.DayOfWeek), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.DayOfYear"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasDayOfYear(this Expect<DateTimeOffset> expect, Action<Expect<int>> expectValue, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => expectValue.Invoke(t.DayOfYear), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.Hour"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasHour(this Expect<DateTimeOffset> expect, Action<Expect<int>> expectValue, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => expectValue.Invoke(t.Hour), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.LocalDateTime"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasLocalDateTime(this Expect<DateTimeOffset> expect, Action<Expect<DateTime>> expectValue, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => expectValue.Invoke(t.LocalDateTime), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.Millisecond"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasMillisecond(this Expect<DateTimeOffset> expect, Action<Expect<int>> expectValue, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => expectValue.Invoke(t.Millisecond), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.Minute"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasMinute(this Expect<DateTimeOffset> expect, Action<Expect<int>> expectValue, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => expectValue.Invoke(t.Minute), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.Month"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasMonth(this Expect<DateTimeOffset> expect, Action<Expect<int>> expectValue, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => expectValue.Invoke(t.Month), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.Offset"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasOffset(this Expect<DateTimeOffset> expect, Action<Expect<TimeSpan>> expectValue, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => expectValue.Invoke(t.Offset), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.Second"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasSecond(this Expect<DateTimeOffset> expect, Action<Expect<int>> expectValue, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => expectValue.Invoke(t.Second), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.Ticks"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasTicks(this Expect<DateTimeOffset> expect, Action<Expect<long>> expectValue, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => expectValue.Invoke(t.Ticks), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.TimeOfDay"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasTimeOfDay(this Expect<DateTimeOffset> expect, Action<Expect<TimeSpan>> expectValue, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => expectValue.Invoke(t.TimeOfDay), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.UtcDateTime"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasUtcDateTime(this Expect<DateTimeOffset> expect, Action<Expect<DateTime>> expectValue, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => expectValue.Invoke(t.UtcDateTime), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.UtcTicks"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasUtcTicks(this Expect<DateTimeOffset> expect, Action<Expect<long>> expectValue, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => expectValue.Invoke(t.UtcTicks), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="DateTimeOffset.Year"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<DateTimeOffset> HasYear(this Expect<DateTimeOffset> expect, Action<Expect<int>> expectValue, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => expectValue.Invoke(t.Year), issue.Operator(expectValue));

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
      expect.That(t => t.Days == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.Duration"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasDuration(this Expect<TimeSpan> expect, TimeSpan value, Issue<TimeSpan>? issue = null) =>
      expect.That(t => t.Duration() == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.Hours"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasHours(this Expect<TimeSpan> expect, int value, Issue<TimeSpan>? issue = null) =>
      expect.That(t => t.Hours == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.Milliseconds"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasMilliseconds(this Expect<TimeSpan> expect, int value, Issue<TimeSpan>? issue = null) =>
      expect.That(t => t.Milliseconds == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.Minutes"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasMinutes(this Expect<TimeSpan> expect, int value, Issue<TimeSpan>? issue = null) =>
      expect.That(t => t.Minutes == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.Negate"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasNegated(this Expect<TimeSpan> expect, TimeSpan value, Issue<TimeSpan>? issue = null) =>
      expect.That(t => t.Negate() == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.Seconds"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasSeconds(this Expect<TimeSpan> expect, int value, Issue<TimeSpan>? issue = null) =>
      expect.That(t => t.Seconds == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.Ticks"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasTicks(this Expect<TimeSpan> expect, long value, Issue<TimeSpan>? issue = null) =>
      expect.That(t => t.Ticks == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.TotalDays"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasTotalDays(this Expect<TimeSpan> expect, double value, Issue<TimeSpan>? issue = null) =>
      expect.That(t => t.TotalDays == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.TotalHours"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasTotalHours(this Expect<TimeSpan> expect, double value, Issue<TimeSpan>? issue = null) =>
      expect.That(t => t.TotalHours == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.TotalMilliseconds"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasTotalMilliseconds(this Expect<TimeSpan> expect, double value, Issue<TimeSpan>? issue = null) =>
      expect.That(t => t.TotalMilliseconds == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.TotalMinutes"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasTotalMinutes(this Expect<TimeSpan> expect, double value, Issue<TimeSpan>? issue = null) =>
      expect.That(t => t.TotalMinutes == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.TotalSeconds"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasTotalSeconds(this Expect<TimeSpan> expect, double value, Issue<TimeSpan>? issue = null) =>
      expect.That(t => t.TotalSeconds == value, issue.Operator(value));

    //
    // TimeSpan (values)
    //

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.Days"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasDays(this Expect<TimeSpan> expect, Action<Expect<int>> expectValue, Issue<TimeSpan>? issue = null) =>
      expect.That(t => expectValue.Invoke(t.Days), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.Duration"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasDuration(this Expect<TimeSpan> expect, Action<Expect<TimeSpan>> expectValue, Issue<TimeSpan>? issue = null) =>
      expect.That(t => expectValue.Invoke(t.Duration()), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.Hours"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasHours(this Expect<TimeSpan> expect, Action<Expect<int>> expectValue, Issue<TimeSpan>? issue = null) =>
      expect.That(t => expectValue.Invoke(t.Hours), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.Milliseconds"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasMilliseconds(this Expect<TimeSpan> expect, Action<Expect<int>> expectValue, Issue<TimeSpan>? issue = null) =>
      expect.That(t => expectValue.Invoke(t.Milliseconds), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.Minutes"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasMinutes(this Expect<TimeSpan> expect, Action<Expect<int>> expectValue, Issue<TimeSpan>? issue = null) =>
      expect.That(t => expectValue.Invoke(t.Minutes), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.Negate"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasNegated(this Expect<TimeSpan> expect, Action<Expect<TimeSpan>> expectValue, Issue<TimeSpan>? issue = null) =>
      expect.That(t => expectValue.Invoke(t.Negate()), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.Seconds"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasSeconds(this Expect<TimeSpan> expect, Action<Expect<int>> expectValue, Issue<TimeSpan>? issue = null) =>
      expect.That(t => expectValue.Invoke(t.Seconds), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.Ticks"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasTicks(this Expect<TimeSpan> expect, Action<Expect<long>> expectValue, Issue<TimeSpan>? issue = null) =>
      expect.That(t => expectValue.Invoke(t.Ticks), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.TotalDays"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasTotalDays(this Expect<TimeSpan> expect, Action<Expect<double>> expectValue, Issue<TimeSpan>? issue = null) =>
      expect.That(t => expectValue.Invoke(t.TotalDays), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.TotalHours"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasTotalHours(this Expect<TimeSpan> expect, Action<Expect<double>> expectValue, Issue<TimeSpan>? issue = null) =>
      expect.That(t => expectValue.Invoke(t.TotalHours), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.TotalMilliseconds"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasTotalMilliseconds(this Expect<TimeSpan> expect, Action<Expect<double>> expectValue, Issue<TimeSpan>? issue = null) =>
      expect.That(t => expectValue.Invoke(t.TotalMilliseconds), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.TotalMinutes"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasTotalMinutes(this Expect<TimeSpan> expect, Action<Expect<double>> expectValue, Issue<TimeSpan>? issue = null) =>
      expect.That(t => expectValue.Invoke(t.TotalMinutes), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="TimeSpan.TotalSeconds"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeSpan> HasTotalSeconds(this Expect<TimeSpan> expect, Action<Expect<double>> expectValue, Issue<TimeSpan>? issue = null) =>
      expect.That(t => expectValue.Invoke(t.TotalSeconds), issue.Operator(expectValue));

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
      expect.That(t => t?.BaseUtcOffset == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="TimeZoneInfo.DaylightName"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeZoneInfo> HasDaylightName(this Expect<TimeZoneInfo> expect, string value, Issue<TimeZoneInfo>? issue = null) =>
      expect.That(t => t?.DaylightName == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="TimeZoneInfo.DisplayName"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeZoneInfo> HasDisplayName(this Expect<TimeZoneInfo> expect, string value, Issue<TimeZoneInfo>? issue = null) =>
      expect.That(t => t?.DisplayName == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="TimeZoneInfo.Id"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeZoneInfo> HasId(this Expect<TimeZoneInfo> expect, string value, Issue<TimeZoneInfo>? issue = null) =>
      expect.That(t => t?.Id == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="TimeZoneInfo.ToSerializedString"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeZoneInfo> HasSerializedString(this Expect<TimeZoneInfo> expect, string value, Issue<TimeZoneInfo>? issue = null) =>
      expect.That(t => t?.ToSerializedString() == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="TimeZoneInfo.StandardName"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeZoneInfo> HasStandardName(this Expect<TimeZoneInfo> expect, string value, Issue<TimeZoneInfo>? issue = null) =>
      expect.That(t => t?.StandardName == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="TimeZoneInfo.SupportsDaylightSavingTime"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeZoneInfo> SupportsDaylightSavingTime(this Expect<TimeZoneInfo> expect, bool value, Issue<TimeZoneInfo>? issue = null) =>
      expect.That(t => t?.SupportsDaylightSavingTime == value, issue.Operator(value));

    //
    // TimeZoneInfo (values)
    //

    /// <summary>
    /// Expects the target's <see cref="TimeZoneInfo.BaseUtcOffset"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeZoneInfo> HasBaseUtcOffset(this Expect<TimeZoneInfo> expect, Action<Expect<TimeSpan>> expectValue, Issue<TimeZoneInfo>? issue = null) =>
      expect.That(t => t != null && expectValue.Invoke(t.BaseUtcOffset), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="TimeZoneInfo.DaylightName"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeZoneInfo> HasDaylightName(this Expect<TimeZoneInfo> expect, Action<Expect<string>> expectValue, Issue<TimeZoneInfo>? issue = null) =>
      expect.That(t => t != null && expectValue.Invoke(t.DaylightName), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="TimeZoneInfo.DisplayName"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeZoneInfo> HasDisplayName(this Expect<TimeZoneInfo> expect, Action<Expect<string>> expectValue, Issue<TimeZoneInfo>? issue = null) =>
      expect.That(t => t != null && expectValue.Invoke(t.DisplayName), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="TimeZoneInfo.Id"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeZoneInfo> HasId(this Expect<TimeZoneInfo> expect, Action<Expect<string>> expectValue, Issue<TimeZoneInfo>? issue = null) =>
      expect.That(t => t != null && expectValue.Invoke(t.Id), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="TimeZoneInfo.ToSerializedString"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeZoneInfo> HasSerializedString(this Expect<TimeZoneInfo> expect, Action<Expect<string>> expectValue, Issue<TimeZoneInfo>? issue = null) =>
      expect.That(t => t != null && expectValue.Invoke(t.ToSerializedString()), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="TimeZoneInfo.StandardName"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<TimeZoneInfo> HasStandardName(this Expect<TimeZoneInfo> expect, Action<Expect<string>> expectValue, Issue<TimeZoneInfo>? issue = null) =>
      expect.That(t => t != null && expectValue.Invoke(t.StandardName), issue.Operator(expectValue));
  }
}