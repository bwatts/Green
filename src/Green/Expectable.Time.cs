using System;
using Green.Messages;

namespace Green
{
  public static partial class Expectable
  {
    public static Expect<DateTime> HasDate(this Expect<DateTime> expect, DateTime value, Issue<DateTime>? issue = null) =>
      expect.That(t => t.Date == value, issue.ElseExpectedHas(nameof(DateTime.Date), value, t => t.Date));

    public static Expect<DateTime> HasDay(this Expect<DateTime> expect, int value, Issue<DateTime>? issue = null) =>
      expect.That(t => t.Day == value, issue.ElseExpectedHas(nameof(DateTime.Day), value, t => t.Day));

    public static Expect<DateTime> HasDayOfWeek(this Expect<DateTime> expect, DayOfWeek value, Issue<DateTime>? issue = null) =>
      expect.That(t => t.DayOfWeek == value, issue.ElseExpectedHas(nameof(DateTime.DayOfWeek), value, t => t.DayOfWeek));

    public static Expect<DateTime> HasDayOfYear(this Expect<DateTime> expect, int value, Issue<DateTime>? issue = null) =>
      expect.That(t => t.DayOfYear == value, issue.ElseExpectedHas(nameof(DateTime.DayOfYear), value, t => t.DayOfYear));

    public static Expect<DateTime> HasHour(this Expect<DateTime> expect, int value, Issue<DateTime>? issue = null) =>
      expect.That(t => t.Hour == value, issue.ElseExpectedHas(nameof(DateTime.Hour), value, t => t.Hour));

    public static Expect<DateTime> HasKind(this Expect<DateTime> expect, DateTimeKind value, Issue<DateTime>? issue = null) =>
      expect.That(t => t.Kind == value, issue.ElseExpectedHas(nameof(DateTime.Kind), value, t => t.Kind));

    public static Expect<DateTime> HasMillisecond(this Expect<DateTime> expect, int value, Issue<DateTime>? issue = null) =>
      expect.That(t => t.Millisecond == value, issue.ElseExpectedHas(nameof(DateTime.Millisecond), value, t => t.Millisecond));

    public static Expect<DateTime> HasMinute(this Expect<DateTime> expect, int value, Issue<DateTime>? issue = null) =>
      expect.That(t => t.Minute == value, issue.ElseExpectedHas(nameof(DateTime.Minute), value, t => t.Minute));

    public static Expect<DateTime> HasMonth(this Expect<DateTime> expect, int value, Issue<DateTime>? issue = null) =>
      expect.That(t => t.Month == value, issue.ElseExpectedHas(nameof(DateTime.Month), value, t => t.Month));

    public static Expect<DateTime> HasSecond(this Expect<DateTime> expect, int value, Issue<DateTime>? issue = null) =>
      expect.That(t => t.Second == value, issue.ElseExpectedHas(nameof(DateTime.Second), value, t => t.Second));

    public static Expect<DateTime> HasTicks(this Expect<DateTime> expect, long value, Issue<DateTime>? issue = null) =>
      expect.That(t => t.Ticks == value, issue.ElseExpectedHas(nameof(DateTime.Ticks), value, t => t.Ticks));

    public static Expect<DateTime> HasTimeOfDay(this Expect<DateTime> expect, TimeSpan value, Issue<DateTime>? issue = null) =>
      expect.That(t => t.TimeOfDay == value, issue.ElseExpectedHas(nameof(DateTime.TimeOfDay), value, t => t.TimeOfDay));

    public static Expect<DateTime> HasYear(this Expect<DateTime> expect, int value, Issue<DateTime>? issue = null) =>
      expect.That(t => t.Year == value, issue.ElseExpectedHas(nameof(DateTime.Year), value, t => t.Year));

    public static Expect<DateTime> IsLeapYear(this Expect<DateTime> expect, Issue<DateTime>? issue = null) =>
      expect.That(t => DateTime.IsLeapYear(t.Year), issue.ElseExpected("leap year"));

    public static Expect<DateTime> IsWeekday(this Expect<DateTime> expect, Issue<DateTime>? issue = null) =>
      expect.That(t => t.DayOfWeek != DayOfWeek.Saturday && t.DayOfWeek != DayOfWeek.Sunday, issue.ElseExpected("weekday"));

    public static Expect<DateTime> IsWeekend(this Expect<DateTime> expect, Issue<DateTime>? issue = null) =>
      expect.That(t => t.DayOfWeek == DayOfWeek.Saturday || t.DayOfWeek == DayOfWeek.Sunday, issue.ElseExpected("weekend"));

    //
    // DateTime (values)
    //

    public static Expect<DateTime> HasDate(this Expect<DateTime> expect, Action<Expect<DateTime>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Date));

    public static Expect<DateTime> HasDay(this Expect<DateTime> expect, Action<Expect<int>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Day));

    public static Expect<DateTime> HasDayOfWeek(this Expect<DateTime> expect, Action<Expect<DayOfWeek>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.DayOfWeek));

    public static Expect<DateTime> HasDayOfYear(this Expect<DateTime> expect, Action<Expect<int>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.DayOfYear));

    public static Expect<DateTime> HasHour(this Expect<DateTime> expect, Action<Expect<int>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Hour));

    public static Expect<DateTime> HasKind(this Expect<DateTime> expect, Action<Expect<DateTimeKind>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Kind));

    public static Expect<DateTime> HasMillisecond(this Expect<DateTime> expect, Action<Expect<int>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Millisecond));

    public static Expect<DateTime> HasMinute(this Expect<DateTime> expect, Action<Expect<int>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Minute));

    public static Expect<DateTime> HasMonth(this Expect<DateTime> expect, Action<Expect<int>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Month));

    public static Expect<DateTime> HasSecond(this Expect<DateTime> expect, Action<Expect<int>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Second));

    public static Expect<DateTime> HasTicks(this Expect<DateTime> expect, Action<Expect<long>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Ticks));

    public static Expect<DateTime> HasTimeOfDay(this Expect<DateTime> expect, Action<Expect<TimeSpan>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.TimeOfDay));

    public static Expect<DateTime> HasYear(this Expect<DateTime> expect, Action<Expect<int>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Year));

    //
    // DateTimeOffset
    //

    public static Expect<DateTimeOffset> HasDate(this Expect<DateTimeOffset> expect, DateTime value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.Date == value, issue.ElseExpectedHas(nameof(DateTimeOffset.Date), value, t => t.Date));

    public static Expect<DateTimeOffset> HasDateTime(this Expect<DateTimeOffset> expect, DateTime value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.DateTime == value, issue.ElseExpectedHas(nameof(DateTimeOffset.DateTime), value, t => t.DateTime));

    public static Expect<DateTimeOffset> HasDay(this Expect<DateTimeOffset> expect, int value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.Day == value, issue.ElseExpectedHas(nameof(DateTimeOffset.Day), value, t => t.Day));

    public static Expect<DateTimeOffset> HasDayOfWeek(this Expect<DateTimeOffset> expect, DayOfWeek value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.DayOfWeek == value, issue.ElseExpectedHas(nameof(DateTimeOffset.DayOfWeek), value, t => t.DayOfWeek));

    public static Expect<DateTimeOffset> HasDayOfYear(this Expect<DateTimeOffset> expect, int value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.DayOfYear == value, issue.ElseExpectedHas(nameof(DateTimeOffset.DayOfYear), value, t => t.DayOfYear));

    public static Expect<DateTimeOffset> HasHour(this Expect<DateTimeOffset> expect, int value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.Hour == value, issue.ElseExpectedHas(nameof(DateTimeOffset.Hour), value, t => t.Hour));

    public static Expect<DateTimeOffset> HasLocalDateTime(this Expect<DateTimeOffset> expect, DateTime value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.LocalDateTime == value, issue.ElseExpectedHas(nameof(DateTimeOffset.LocalDateTime), value, t => t.LocalDateTime));

    public static Expect<DateTimeOffset> HasMillisecond(this Expect<DateTimeOffset> expect, int value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.Millisecond == value, issue.ElseExpectedHas(nameof(DateTimeOffset.Millisecond), value, t => t.Millisecond));

    public static Expect<DateTimeOffset> HasMinute(this Expect<DateTimeOffset> expect, int value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.Minute == value, issue.ElseExpectedHas(nameof(DateTimeOffset.Minute), value, t => t.Minute));

    public static Expect<DateTimeOffset> HasMonth(this Expect<DateTimeOffset> expect, int value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.Month == value, issue.ElseExpectedHas(nameof(DateTimeOffset.Month), value, t => t.Month));

    public static Expect<DateTimeOffset> HasOffset(this Expect<DateTimeOffset> expect, TimeSpan value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.Offset == value, issue.ElseExpectedHas(nameof(DateTimeOffset.Offset), value, t => t.Offset));

    public static Expect<DateTimeOffset> HasSecond(this Expect<DateTimeOffset> expect, int value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.Second == value, issue.ElseExpectedHas(nameof(DateTimeOffset.Second), value, t => t.Second));

    public static Expect<DateTimeOffset> HasTicks(this Expect<DateTimeOffset> expect, long value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.Ticks == value, issue.ElseExpectedHas(nameof(DateTimeOffset.Ticks), value, t => t.Ticks));

    public static Expect<DateTimeOffset> HasTimeOfDay(this Expect<DateTimeOffset> expect, TimeSpan value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.TimeOfDay == value, issue.ElseExpectedHas(nameof(DateTimeOffset.TimeOfDay), value, t => t.TimeOfDay));

    public static Expect<DateTimeOffset> HasUtcDateTime(this Expect<DateTimeOffset> expect, DateTime value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.UtcDateTime == value, issue.ElseExpectedHas(nameof(DateTimeOffset.UtcDateTime), value, t => t.UtcDateTime));

    public static Expect<DateTimeOffset> HasUtcTicks(this Expect<DateTimeOffset> expect, long value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.UtcTicks == value, issue.ElseExpectedHas(nameof(DateTimeOffset.UtcTicks), value, t => t.UtcTicks));

    public static Expect<DateTimeOffset> HasYear(this Expect<DateTimeOffset> expect, int value, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.Year == value, issue.ElseExpectedHas(nameof(DateTimeOffset.Year), value, t => t.Year));

    public static Expect<DateTimeOffset> IsLeapYear(this Expect<DateTimeOffset> expect, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => DateTime.IsLeapYear(t.Year), issue.ElseExpected("leap year"));

    public static Expect<DateTimeOffset> IsWeekday(this Expect<DateTimeOffset> expect, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.DayOfWeek != DayOfWeek.Saturday && t.DayOfWeek != DayOfWeek.Sunday, issue.ElseExpected("weekday"));

    public static Expect<DateTimeOffset> IsWeekend(this Expect<DateTimeOffset> expect, Issue<DateTimeOffset>? issue = null) =>
      expect.That(t => t.DayOfWeek == DayOfWeek.Saturday || t.DayOfWeek == DayOfWeek.Sunday, issue.ElseExpected("weekend"));

    //
    // DateTimeOffset (values)
    //

    public static Expect<DateTimeOffset> HasDate(this Expect<DateTimeOffset> expect, Action<Expect<DateTime>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Date));

    public static Expect<DateTimeOffset> HasDateTime(this Expect<DateTimeOffset> expect, Action<Expect<DateTime>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.DateTime));

    public static Expect<DateTimeOffset> HasDay(this Expect<DateTimeOffset> expect, Action<Expect<int>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Day));

    public static Expect<DateTimeOffset> HasDayOfWeek(this Expect<DateTimeOffset> expect, Action<Expect<DayOfWeek>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.DayOfWeek));

    public static Expect<DateTimeOffset> HasDayOfYear(this Expect<DateTimeOffset> expect, Action<Expect<int>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.DayOfYear));

    public static Expect<DateTimeOffset> HasHour(this Expect<DateTimeOffset> expect, Action<Expect<int>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Hour));

    public static Expect<DateTimeOffset> HasLocalDateTime(this Expect<DateTimeOffset> expect, Action<Expect<DateTime>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.LocalDateTime));

    public static Expect<DateTimeOffset> HasMillisecond(this Expect<DateTimeOffset> expect, Action<Expect<int>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Millisecond));

    public static Expect<DateTimeOffset> HasMinute(this Expect<DateTimeOffset> expect, Action<Expect<int>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Minute));

    public static Expect<DateTimeOffset> HasMonth(this Expect<DateTimeOffset> expect, Action<Expect<int>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Month));

    public static Expect<DateTimeOffset> HasOffset(this Expect<DateTimeOffset> expect, Action<Expect<TimeSpan>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Offset));

    public static Expect<DateTimeOffset> HasSecond(this Expect<DateTimeOffset> expect, Action<Expect<int>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Second));

    public static Expect<DateTimeOffset> HasTicks(this Expect<DateTimeOffset> expect, Action<Expect<long>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Ticks));

    public static Expect<DateTimeOffset> HasTimeOfDay(this Expect<DateTimeOffset> expect, Action<Expect<TimeSpan>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.TimeOfDay));

    public static Expect<DateTimeOffset> HasUtcDateTime(this Expect<DateTimeOffset> expect, Action<Expect<DateTime>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.UtcDateTime));

    public static Expect<DateTimeOffset> HasUtcTicks(this Expect<DateTimeOffset> expect, Action<Expect<long>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.UtcTicks));

    public static Expect<DateTimeOffset> HasYear(this Expect<DateTimeOffset> expect, Action<Expect<int>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Year));

    //
    // TimeSpan
    //

    public static Expect<TimeSpan> HasDays(this Expect<TimeSpan> expect, int value, Issue<TimeSpan>? issue = null) =>
      expect.That(t => t.Days == value, issue.ElseExpectedHas(nameof(TimeSpan.Days), value, t => t.Days));

    public static Expect<TimeSpan> HasDuration(this Expect<TimeSpan> expect, TimeSpan value, Issue<TimeSpan>? issue = null) =>
      expect.That(t => t.Duration() == value, issue.ElseExpectedHas($"{nameof(TimeSpan.Duration)}()", value, t => t.Duration()));

    public static Expect<TimeSpan> HasHours(this Expect<TimeSpan> expect, int value, Issue<TimeSpan>? issue = null) =>
      expect.That(t => t.Hours == value, issue.ElseExpectedHas(nameof(TimeSpan.Hours), value, t => t.Hours));

    public static Expect<TimeSpan> HasMilliseconds(this Expect<TimeSpan> expect, int value, Issue<TimeSpan>? issue = null) =>
      expect.That(t => t.Milliseconds == value, issue.ElseExpectedHas(nameof(TimeSpan.Milliseconds), value, t => t.Milliseconds));

    public static Expect<TimeSpan> HasMinutes(this Expect<TimeSpan> expect, int value, Issue<TimeSpan>? issue = null) =>
      expect.That(t => t.Minutes == value, issue.ElseExpectedHas(nameof(TimeSpan.Minutes), value, t => t.Minutes));

    public static Expect<TimeSpan> HasNegated(this Expect<TimeSpan> expect, TimeSpan value, Issue<TimeSpan>? issue = null) =>
      expect.That(t => t.Negate() == value, issue.ElseExpectedHas($"{nameof(TimeSpan.Negate)}()", value, t => t.Negate()));

    public static Expect<TimeSpan> HasSeconds(this Expect<TimeSpan> expect, int value, Issue<TimeSpan>? issue = null) =>
      expect.That(t => t.Seconds == value, issue.ElseExpectedHas(nameof(TimeSpan.Seconds), value, t => t.Seconds));

    public static Expect<TimeSpan> HasTicks(this Expect<TimeSpan> expect, long value, Issue<TimeSpan>? issue = null) =>
      expect.That(t => t.Ticks == value, issue.ElseExpectedHas(nameof(TimeSpan.Ticks), value, t => t.Ticks));

    public static Expect<TimeSpan> HasTotalDays(this Expect<TimeSpan> expect, double value, Issue<TimeSpan>? issue = null) =>
      expect.That(t => t.TotalDays == value, issue.ElseExpectedHas(nameof(TimeSpan.TotalDays), value, t => t.TotalDays));

    public static Expect<TimeSpan> HasTotalHours(this Expect<TimeSpan> expect, double value, Issue<TimeSpan>? issue = null) =>
      expect.That(t => t.TotalHours == value, issue.ElseExpectedHas(nameof(TimeSpan.TotalHours), value, t => t.TotalHours));

    public static Expect<TimeSpan> HasTotalMilliseconds(this Expect<TimeSpan> expect, double value, Issue<TimeSpan>? issue = null) =>
      expect.That(t => t.TotalMilliseconds == value, issue.ElseExpectedHas(nameof(TimeSpan.TotalMilliseconds), value, t => t.TotalMilliseconds));

    public static Expect<TimeSpan> HasTotalMinutes(this Expect<TimeSpan> expect, double value, Issue<TimeSpan>? issue = null) =>
      expect.That(t => t.TotalMinutes == value, issue.ElseExpectedHas(nameof(TimeSpan.TotalMinutes), value, t => t.TotalMinutes));

    public static Expect<TimeSpan> HasTotalSeconds(this Expect<TimeSpan> expect, double value, Issue<TimeSpan>? issue = null) =>
      expect.That(t => t.TotalSeconds == value, issue.ElseExpectedHas(nameof(TimeSpan.TotalSeconds), value, t => t.TotalSeconds));

    //
    // TimeSpan (values)
    //

    public static Expect<TimeSpan> HasDays(this Expect<TimeSpan> expect, Action<Expect<int>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Days));

    public static Expect<TimeSpan> HasDuration(this Expect<TimeSpan> expect, Action<Expect<TimeSpan>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Duration()));

    public static Expect<TimeSpan> HasHours(this Expect<TimeSpan> expect, Action<Expect<int>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Hours));

    public static Expect<TimeSpan> HasMilliseconds(this Expect<TimeSpan> expect, Action<Expect<int>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Milliseconds));

    public static Expect<TimeSpan> HasMinutes(this Expect<TimeSpan> expect, Action<Expect<int>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Minutes));

    public static Expect<TimeSpan> HasNegated(this Expect<TimeSpan> expect, Action<Expect<TimeSpan>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Negate()));

    public static Expect<TimeSpan> HasSeconds(this Expect<TimeSpan> expect, Action<Expect<int>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Seconds));

    public static Expect<TimeSpan> HasTicks(this Expect<TimeSpan> expect, Action<Expect<long>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.Ticks));

    public static Expect<TimeSpan> HasTotalDays(this Expect<TimeSpan> expect, Action<Expect<double>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.TotalDays));

    public static Expect<TimeSpan> HasTotalHours(this Expect<TimeSpan> expect, Action<Expect<double>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.TotalHours));

    public static Expect<TimeSpan> HasTotalMilliseconds(this Expect<TimeSpan> expect, Action<Expect<double>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.TotalMilliseconds));

    public static Expect<TimeSpan> HasTotalMinutes(this Expect<TimeSpan> expect, Action<Expect<double>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.TotalMinutes));

    public static Expect<TimeSpan> HasTotalSeconds(this Expect<TimeSpan> expect, Action<Expect<double>> expectValue) =>
      expect.That(t => expectValue.Invoke(t.TotalSeconds));

    //
    // TimeZoneInfo
    //

    public static Expect<TimeZoneInfo> HasBaseUtcOffset(this Expect<TimeZoneInfo> expect, TimeSpan value, Issue<TimeZoneInfo>? issue = null) =>
      expect.That(t => t?.BaseUtcOffset == value, issue.ElseExpectedHas(nameof(TimeZoneInfo.BaseUtcOffset), value, t => t.BaseUtcOffset));

    public static Expect<TimeZoneInfo> HasDaylightName(this Expect<TimeZoneInfo> expect, string value, Issue<TimeZoneInfo>? issue = null) =>
      expect.That(t => t?.DaylightName == value, issue.ElseExpectedHas(nameof(TimeZoneInfo.DaylightName), value, t => t.DaylightName));

    public static Expect<TimeZoneInfo> HasDisplayName(this Expect<TimeZoneInfo> expect, string value, Issue<TimeZoneInfo>? issue = null) =>
      expect.That(t => t?.DisplayName == value, issue.ElseExpectedHas(nameof(TimeZoneInfo.DisplayName), value, t => t.DisplayName));

    public static Expect<TimeZoneInfo> HasId(this Expect<TimeZoneInfo> expect, string value, Issue<TimeZoneInfo>? issue = null) =>
      expect.That(t => t?.Id == value, issue.ElseExpectedHas(nameof(TimeZoneInfo.Id), value, t => t.Id));

    public static Expect<TimeZoneInfo> HasSerializedString(this Expect<TimeZoneInfo> expect, string value, Issue<TimeZoneInfo>? issue = null) =>
      expect.That(t => t?.ToSerializedString() == value, issue.ElseExpectedHas($"{nameof(TimeZoneInfo.ToSerializedString)}()", value, t => t.ToSerializedString()));

    public static Expect<TimeZoneInfo> HasStandardName(this Expect<TimeZoneInfo> expect, string value, Issue<TimeZoneInfo>? issue = null) =>
      expect.That(t => t?.StandardName == value, issue.ElseExpectedHas(nameof(TimeZoneInfo.StandardName), value, t => t.StandardName));

    public static Expect<TimeZoneInfo> SupportsDaylightSavingTime(this Expect<TimeZoneInfo> expect, bool value, Issue<TimeZoneInfo>? issue = null) =>
      expect.That(t => t?.SupportsDaylightSavingTime == value, issue.ElseExpectedHas(nameof(TimeZoneInfo.SupportsDaylightSavingTime), value, t => t.SupportsDaylightSavingTime));

    //
    // TimeZoneInfo (values)
    //

    public static Expect<TimeZoneInfo> HasBaseUtcOffset(this Expect<TimeZoneInfo> expect, Action<Expect<TimeSpan>> expectValue) =>
      expect.That(t => t != null && expectValue.Invoke(t.BaseUtcOffset));

    public static Expect<TimeZoneInfo> HasDaylightName(this Expect<TimeZoneInfo> expect, Action<Expect<string>> expectValue) =>
      expect.That(t => t != null && expectValue.Invoke(t.DaylightName));

    public static Expect<TimeZoneInfo> HasDisplayName(this Expect<TimeZoneInfo> expect, Action<Expect<string>> expectValue) =>
      expect.That(t => t != null && expectValue.Invoke(t.DisplayName));

    public static Expect<TimeZoneInfo> HasId(this Expect<TimeZoneInfo> expect, Action<Expect<string>> expectValue) =>
      expect.That(t => t != null && expectValue.Invoke(t.Id));

    public static Expect<TimeZoneInfo> HasSerializedString(this Expect<TimeZoneInfo> expect, Action<Expect<string>> expectValue) =>
      expect.That(t => t != null && expectValue.Invoke(t.ToSerializedString()));

    public static Expect<TimeZoneInfo> HasStandardName(this Expect<TimeZoneInfo> expect, Action<Expect<string>> expectValue) =>
      expect.That(t => t != null && expectValue.Invoke(t.StandardName));
  }
}