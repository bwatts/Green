using System;
using System.Collections.Generic;
using static Green.Messages.Local;

namespace Green.Messages
{
  public static partial class IssueExtensions
  {
    public static void Throw<T>(this Issue<T> issue, T target) =>
      throw new ExpectException(issue?.Invoke(target) ?? Text(target));

    public static void Throw<T>(this IssueMany<T> issue, IEnumerable<T> target) =>
      throw new ExpectException(issue?.Invoke(target) ?? TextMany(target));

    public static void Throw<TKey, TValue>(this IssueMany<TKey, TValue> issue, IEnumerable<KeyValuePair<TKey, TValue>> target) =>
      throw new ExpectException(issue?.Invoke(target) ?? TextMany(target));

    //
    // Values
    //

    public static Issue<T> ElseMessage<T>(this Issue<T> issue, Text message) =>
      issue ?? (t => message);

    public static Issue<T> ElseMessage<T>(this Issue<T> issue, FormattableString message) =>
      issue ?? (t => FormatPart(message));

    public static Issue<T> ElseMessage<T>(this Issue<T> issue, Func<T, Text> message) =>
      issue ?? (t => InvokePart(message, t));

    public static Issue<T> ElseMessage<T>(this Issue<T> issue, Func<T, FormattableString> message) =>
      issue ?? (t => InvokePart(message, t));

    public static Issue<T> ElseExpected<T>(this Issue<T> issue, Text expected) =>
      issue ?? (t => Text.Expected(t, expected));

    public static Issue<T> ElseExpected<T>(this Issue<T> issue, FormattableString expected) =>
      issue ?? (t => Text.Expected(t, FormatPart(expected)));

    public static Issue<T> ElseExpected<T>(this Issue<T> issue, Func<T, Text> expected) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t)));

    public static Issue<T> ElseExpected<T>(this Issue<T> issue, Func<T, FormattableString> expected) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t)));

    public static Issue<T> ElseExpected<T>(this Issue<T> issue, Text expected, Text received) =>
      issue ?? (t => Text.Expected(t, expected, received));

    public static Issue<T> ElseExpected<T>(this Issue<T> issue, Text expected, FormattableString received) =>
      issue ?? (t => Text.Expected(t, expected, FormatPart(received)));

    public static Issue<T> ElseExpected<T>(this Issue<T> issue, Text expected, Func<T, Text> received) =>
      issue ?? (t => Text.Expected(t, expected, InvokePart(received, t)));

    public static Issue<T> ElseExpected<T>(this Issue<T> issue, Text expected, Func<T, FormattableString> received) =>
      issue ?? (t => Text.Expected(t, expected, InvokePart(received, t)));

    public static Issue<T> ElseExpected<T>(this Issue<T> issue, FormattableString expected, Text received) =>
      issue ?? (t => Text.Expected(t, FormatPart(expected), received));

    public static Issue<T> ElseExpected<T>(this Issue<T> issue, FormattableString expected, FormattableString received) =>
      issue ?? (t => Text.Expected(t, FormatPart(expected), FormatPart(received)));

    public static Issue<T> ElseExpected<T>(this Issue<T> issue, FormattableString expected, Func<T, Text> received) =>
      issue ?? (t => Text.Expected(t, FormatPart(expected), InvokePart(received, t)));

    public static Issue<T> ElseExpected<T>(this Issue<T> issue, FormattableString expected, Func<T, FormattableString> received) =>
      issue ?? (t => Text.Expected(t, FormatPart(expected), InvokePart(received, t)));

    public static Issue<T> ElseExpected<T>(this Issue<T> issue, Func<T, Text> expected, Text received) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t), received));

    public static Issue<T> ElseExpected<T>(this Issue<T> issue, Func<T, Text> expected, FormattableString received) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t), FormatPart(received)));

    public static Issue<T> ElseExpected<T>(this Issue<T> issue, Func<T, Text> expected, Func<T, Text> received) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t), InvokePart(received, t)));

    public static Issue<T> ElseExpected<T>(this Issue<T> issue, Func<T, Text> expected, Func<T, FormattableString> received) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t), InvokePart(received, t)));

    public static Issue<T> ElseExpected<T>(this Issue<T> issue, Func<T, FormattableString> expected, Text received) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t), received));

    public static Issue<T> ElseExpected<T>(this Issue<T> issue, Func<T, FormattableString> expected, FormattableString received) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t), FormatPart(received)));

    public static Issue<T> ElseExpected<T>(this Issue<T> issue, Func<T, FormattableString> expected, Func<T, Text> received) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t), InvokePart(received, t)));

    public static Issue<T> ElseExpected<T>(this Issue<T> issue, Func<T, FormattableString> expected, Func<T, FormattableString> received) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t), InvokePart(received, t)));

    public static Issue<T> ElseExpectedHas<T, TValue>(this Issue<T> issue, string member, TValue value, Func<T, TValue> getValue) =>
      issue.ElseExpected(
        $"{member} == {Text(value)}",
        t => t == null ? NullText : $"{member} == {Text(getValue(t))} ({Text(t)})");

    public static Issue<T?> ElseExpectedHas<T, TValue>(this Issue<T?> issue, string member, TValue value, Func<T, TValue> getValue) where T : struct =>
      issue.ElseExpected(
        $"{member} == {Text(value)}",
        t => t == null ? NullText : $"{member} == {Text(getValue(t.Value))} ({Text(t)})");

    static string FormatPart(FormattableString part) =>
      part?.ToString() ?? "";

    static string InvokePart<T>(Func<T, Text> part, T target) =>
      part?.Invoke(target) ?? Text(target);

    static string InvokePart<T>(Func<T, FormattableString> part, T target) =>
      part?.Invoke(target)?.ToString() ?? Text(target);

    //
    // Items
    //

    public static IssueMany<T> ElseMessage<T>(this IssueMany<T> issue, Text message) =>
      issue ?? (t => message);

    public static IssueMany<T> ElseMessage<T>(this IssueMany<T> issue, FormattableString message) =>
      issue ?? (t => FormatPart(message));

    public static IssueMany<T> ElseMessage<T>(this IssueMany<T> issue, Func<IEnumerable<T>, Text> message) =>
      issue ?? (t => InvokePart(message, t));

    public static IssueMany<T> ElseMessage<T>(this IssueMany<T> issue, Func<IEnumerable<T>, FormattableString> message) =>
      issue ?? (t => InvokePart(message, t));

    public static IssueMany<T> ElseExpected<T>(this IssueMany<T> issue, Text expected) =>
      issue ?? (t => Text.Expected(t, expected));

    public static IssueMany<T> ElseExpected<T>(this IssueMany<T> issue, FormattableString expected) =>
      issue ?? (t => Text.Expected(t, FormatPart(expected)));

    public static IssueMany<T> ElseExpected<T>(this IssueMany<T> issue, Func<IEnumerable<T>, Text> expected) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t)));

    public static IssueMany<T> ElseExpected<T>(this IssueMany<T> issue, Func<IEnumerable<T>, FormattableString> expected) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t)));

    public static IssueMany<T> ElseExpected<T>(this IssueMany<T> issue, Text expected, Text received) =>
      issue ?? (t => Text.Expected(t, expected, received));

    public static IssueMany<T> ElseExpected<T>(this IssueMany<T> issue, Text expected, FormattableString received) =>
      issue ?? (t => Text.Expected(t, expected, FormatPart(received)));

    public static IssueMany<T> ElseExpected<T>(this IssueMany<T> issue, Text expected, Func<IEnumerable<T>, Text> received) =>
      issue ?? (t => Text.Expected(t, expected, InvokePart(received, t)));

    public static IssueMany<T> ElseExpected<T>(this IssueMany<T> issue, Text expected, Func<IEnumerable<T>, FormattableString> received) =>
      issue ?? (t => Text.Expected(t, expected, InvokePart(received, t)));

    public static IssueMany<T> ElseExpected<T>(this IssueMany<T> issue, FormattableString expected, Text received) =>
      issue ?? (t => Text.Expected(t, FormatPart(expected), received));

    public static IssueMany<T> ElseExpected<T>(this IssueMany<T> issue, FormattableString expected, FormattableString received) =>
      issue ?? (t => Text.Expected(t, FormatPart(expected), FormatPart(received)));

    public static IssueMany<T> ElseExpected<T>(this IssueMany<T> issue, FormattableString expected, Func<IEnumerable<T>, Text> received) =>
      issue ?? (t => Text.Expected(t, FormatPart(expected), InvokePart(received, t)));

    public static IssueMany<T> ElseExpected<T>(this IssueMany<T> issue, FormattableString expected, Func<IEnumerable<T>, FormattableString> received) =>
      issue ?? (t => Text.Expected(t, FormatPart(expected), InvokePart(received, t)));

    public static IssueMany<T> ElseExpected<T>(this IssueMany<T> issue, Func<IEnumerable<T>, Text> expected, Text received) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t), received));

    public static IssueMany<T> ElseExpected<T>(this IssueMany<T> issue, Func<IEnumerable<T>, Text> expected, FormattableString received) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t), FormatPart(received)));

    public static IssueMany<T> ElseExpected<T>(this IssueMany<T> issue, Func<IEnumerable<T>, Text> expected, Func<IEnumerable<T>, Text> received) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t), InvokePart(received, t)));

    public static IssueMany<T> ElseExpected<T>(this IssueMany<T> issue, Func<IEnumerable<T>, Text> expected, Func<IEnumerable<T>, FormattableString> received) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t), InvokePart(received, t)));

    public static IssueMany<T> ElseExpected<T>(this IssueMany<T> issue, Func<IEnumerable<T>, FormattableString> expected, Text received) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t), received));

    public static IssueMany<T> ElseExpected<T>(this IssueMany<T> issue, Func<IEnumerable<T>, FormattableString> expected, FormattableString received) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t), FormatPart(received)));

    public static IssueMany<T> ElseExpected<T>(this IssueMany<T> issue, Func<IEnumerable<T>, FormattableString> expected, Func<IEnumerable<T>, Text> received) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t), InvokePart(received, t)));

    public static IssueMany<T> ElseExpected<T>(this IssueMany<T> issue, Func<IEnumerable<T>, FormattableString> expected, Func<IEnumerable<T>, FormattableString> received) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t), InvokePart(received, t)));

    static string InvokePart<T>(Func<IEnumerable<T>, Text> part, IEnumerable<T> target) =>
      part?.Invoke(target) ?? TextMany(target);

    static string InvokePart<T>(Func<IEnumerable<T>, FormattableString> part, IEnumerable<T> target) =>
      part?.Invoke(target)?.ToString() ?? TextMany(target);

    //
    // Pairs
    //

    public static IssueMany<TKey, TValue> ElseMessage<TKey, TValue>(this IssueMany<TKey, TValue> issue, Text message) =>
      issue ?? (t => message);

    public static IssueMany<TKey, TValue> ElseMessage<TKey, TValue>(this IssueMany<TKey, TValue> issue, FormattableString message) =>
      issue ?? (t => FormatPart(message));

    public static IssueMany<TKey, TValue> ElseMessage<TKey, TValue>(this IssueMany<TKey, TValue> issue, Func<IEnumerable<KeyValuePair<TKey, TValue>>, Text> message) =>
      issue ?? (t => InvokePart(message, t));

    public static IssueMany<TKey, TValue> ElseMessage<TKey, TValue>(this IssueMany<TKey, TValue> issue, Func<IEnumerable<KeyValuePair<TKey, TValue>>, FormattableString> message) =>
      issue ?? (t => InvokePart(message, t));

    public static IssueMany<TKey, TValue> ElseExpected<TKey, TValue>(this IssueMany<TKey, TValue> issue, Text expected) =>
      issue ?? (t => Text.Expected(t, expected));

    public static IssueMany<TKey, TValue> ElseExpected<TKey, TValue>(this IssueMany<TKey, TValue> issue, FormattableString expected) =>
      issue ?? (t => Text.Expected(t, FormatPart(expected)));

    public static IssueMany<TKey, TValue> ElseExpected<TKey, TValue>(this IssueMany<TKey, TValue> issue, Func<IEnumerable<KeyValuePair<TKey, TValue>>, Text> expected) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t)));

    public static IssueMany<TKey, TValue> ElseExpected<TKey, TValue>(this IssueMany<TKey, TValue> issue, Func<IEnumerable<KeyValuePair<TKey, TValue>>, FormattableString> expected) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t)));

    public static IssueMany<TKey, TValue> ElseExpected<TKey, TValue>(this IssueMany<TKey, TValue> issue, Text expected, Text received) =>
      issue ?? (t => Text.Expected(t, expected, received));

    public static IssueMany<TKey, TValue> ElseExpected<TKey, TValue>(this IssueMany<TKey, TValue> issue, Text expected, FormattableString received) =>
      issue ?? (t => Text.Expected(t, expected, FormatPart(received)));

    public static IssueMany<TKey, TValue> ElseExpected<TKey, TValue>(this IssueMany<TKey, TValue> issue, Text expected, Func<IEnumerable<KeyValuePair<TKey, TValue>>, Text> received) =>
      issue ?? (t => Text.Expected(t, expected, InvokePart(received, t)));

    public static IssueMany<TKey, TValue> ElseExpected<TKey, TValue>(this IssueMany<TKey, TValue> issue, Text expected, Func<IEnumerable<KeyValuePair<TKey, TValue>>, FormattableString> received) =>
      issue ?? (t => Text.Expected(t, expected, InvokePart(received, t)));

    public static IssueMany<TKey, TValue> ElseExpected<TKey, TValue>(this IssueMany<TKey, TValue> issue, FormattableString expected, Text received) =>
      issue ?? (t => Text.Expected(t, FormatPart(expected), received));

    public static IssueMany<TKey, TValue> ElseExpected<TKey, TValue>(this IssueMany<TKey, TValue> issue, FormattableString expected, FormattableString received) =>
      issue ?? (t => Text.Expected(t, FormatPart(expected), FormatPart(received)));

    public static IssueMany<TKey, TValue> ElseExpected<TKey, TValue>(this IssueMany<TKey, TValue> issue, FormattableString expected, Func<IEnumerable<KeyValuePair<TKey, TValue>>, Text> received) =>
      issue ?? (t => Text.Expected(t, FormatPart(expected), InvokePart(received, t)));

    public static IssueMany<TKey, TValue> ElseExpected<TKey, TValue>(this IssueMany<TKey, TValue> issue, FormattableString expected, Func<IEnumerable<KeyValuePair<TKey, TValue>>, FormattableString> received) =>
      issue ?? (t => Text.Expected(t, FormatPart(expected), InvokePart(received, t)));

    public static IssueMany<TKey, TValue> ElseExpected<TKey, TValue>(this IssueMany<TKey, TValue> issue, Func<IEnumerable<KeyValuePair<TKey, TValue>>, Text> expected, Text received) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t), received));

    public static IssueMany<TKey, TValue> ElseExpected<TKey, TValue>(this IssueMany<TKey, TValue> issue, Func<IEnumerable<KeyValuePair<TKey, TValue>>, Text> expected, FormattableString received) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t), FormatPart(received)));

    public static IssueMany<TKey, TValue> ElseExpected<TKey, TValue>(this IssueMany<TKey, TValue> issue, Func<IEnumerable<KeyValuePair<TKey, TValue>>, Text> expected, Func<IEnumerable<KeyValuePair<TKey, TValue>>, Text> received) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t), InvokePart(received, t)));

    public static IssueMany<TKey, TValue> ElseExpected<TKey, TValue>(this IssueMany<TKey, TValue> issue, Func<IEnumerable<KeyValuePair<TKey, TValue>>, Text> expected, Func<IEnumerable<KeyValuePair<TKey, TValue>>, FormattableString> received) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t), InvokePart(received, t)));

    public static IssueMany<TKey, TValue> ElseExpected<TKey, TValue>(this IssueMany<TKey, TValue> issue, Func<IEnumerable<KeyValuePair<TKey, TValue>>, FormattableString> expected, Text received) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t), received));

    public static IssueMany<TKey, TValue> ElseExpected<TKey, TValue>(this IssueMany<TKey, TValue> issue, Func<IEnumerable<KeyValuePair<TKey, TValue>>, FormattableString> expected, FormattableString received) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t), FormatPart(received)));

    public static IssueMany<TKey, TValue> ElseExpected<TKey, TValue>(this IssueMany<TKey, TValue> issue, Func<IEnumerable<KeyValuePair<TKey, TValue>>, FormattableString> expected, Func<IEnumerable<KeyValuePair<TKey, TValue>>, Text> received) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t), InvokePart(received, t)));

    public static IssueMany<TKey, TValue> ElseExpected<TKey, TValue>(this IssueMany<TKey, TValue> issue, Func<IEnumerable<KeyValuePair<TKey, TValue>>, FormattableString> expected, Func<IEnumerable<KeyValuePair<TKey, TValue>>, FormattableString> received) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t), InvokePart(received, t)));

    static string InvokePart<TKey, TValue>(Func<IEnumerable<KeyValuePair<TKey, TValue>>, Text> part, IEnumerable<KeyValuePair<TKey, TValue>> target) =>
      part?.Invoke(target) ?? TextMany(target);

    static string InvokePart<TKey, TValue>(Func<IEnumerable<KeyValuePair<TKey, TValue>>, FormattableString> part, IEnumerable<KeyValuePair<TKey, TValue>> target) =>
      part?.Invoke(target)?.ToString() ?? TextMany(target);
  }
}