using System;
using System.Collections.Generic;
using static Green.Messages.Local;

namespace Green.Messages
{
  /// <summary>
  /// Extends <see cref="Issue{T}"/>, <see cref="IssueMany{T}"/>, and <see cref="IssueMany{TKey, TValue}"/>
  /// with methods to build messages for unmet expectations
  /// </summary>
  public static partial class IssueExtensions
  {
    /// <summary>
    /// Throws an exception with the message returned from <paramref name="issue"/> for <paramref name="target"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="issue">A message describing the issue with <paramref name="target"/></param>
    /// <param name="target">The value with the issue</param>
    /// <exception cref="ExpectException">Always thrown</exception>
    public static void Throw<T>(this Issue<T>? issue, T target) =>
      throw new ExpectException(issue?.Invoke(target) ?? Text(target));

    /// <summary>
    /// Throws an exception with the message returned from <paramref name="issue"/> for <paramref name="target"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="issue">A message describing the issue with <paramref name="target"/></param>
    /// <param name="target">The sequence with the issue</param>
    /// <exception cref="ExpectException">Always thrown</exception>
    public static void Throw<T>(this IssueMany<T>? issue, IEnumerable<T> target) =>
      throw new ExpectException(issue?.Invoke(target) ?? TextMany(target));

    /// <summary>
    /// Throws an exception with the message returned from <paramref name="issue"/> for <paramref name="target"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of valuesin the target dictionary</typeparam>
    /// <param name="issue">A message describing the issue with <paramref name="target"/></param>
    /// <param name="target">The dictionary with the issue</param>
    /// <exception cref="ExpectException">Always thrown</exception>
    public static void Throw<TKey, TValue>(this IssueMany<TKey, TValue>? issue, IEnumerable<KeyValuePair<TKey, TValue>> target) =>
      throw new ExpectException(issue?.Invoke(target) ?? TextMany(target));

    //
    // Values
    //

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue for <paramref name="message"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="message">The message to use if <paramref name="issue"/> is <see langword="null"/></param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue for <paramref name="message"/></returns>
    public static Issue<T> ElseMessage<T>(this Issue<T>? issue, Text message) =>
      issue ?? (t => message);

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue for <paramref name="message"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="message">The message to use if <paramref name="issue"/> is <see langword="null"/></param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue for <paramref name="message"/></returns>
    public static Issue<T> ElseMessage<T>(this Issue<T>? issue, FormattableString message) =>
      issue ?? (t => FormatPart(message));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue for <paramref name="message"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="message">The function that formats the target value into a message</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue for <paramref name="message"/></returns>
    public static Issue<T> ElseMessage<T>(this Issue<T>? issue, Func<T, Text> message) =>
      issue ?? (t => InvokePart(message, t));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue for <paramref name="message"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="message">The function that formats the target value into a message</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue for <paramref name="message"/></returns>
    public static Issue<T> ElseMessage<T>(this Issue<T>? issue, Func<T, FormattableString> message) =>
      issue ?? (t => InvokePart(message, t));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and received sections
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The section describing the expected value</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static Issue<T> ElseExpected<T>(this Issue<T>? issue, Text expected) =>
      issue ?? (t => Text.Expected(t, expected));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and received sections
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The section describing the expected value</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static Issue<T> ElseExpected<T>(this Issue<T>? issue, FormattableString expected) =>
      issue ?? (t => Text.Expected(t, FormatPart(expected)));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and received sections
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The function that formats the section describing the expected value</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static Issue<T> ElseExpected<T>(this Issue<T>? issue, Func<T, Text> expected) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t)));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and received sections
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The function that formats the section describing the expected value</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static Issue<T> ElseExpected<T>(this Issue<T>? issue, Func<T, FormattableString> expected) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t)));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The section describing the expected value</param>
    /// <param name="received">The section describing the received value</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static Issue<T> ElseExpected<T>(this Issue<T>? issue, Text expected, Text received) =>
      issue ?? (t => Text.Expected(t, expected, received));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The section describing the expected value</param>
    /// <param name="received">The section describing the received value</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static Issue<T> ElseExpected<T>(this Issue<T>? issue, Text expected, FormattableString received) =>
      issue ?? (t => Text.Expected(t, expected, FormatPart(received)));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The section describing the expected value</param>
    /// <param name="received">The function that formats the section describing the received value</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static Issue<T> ElseExpected<T>(this Issue<T>? issue, Text expected, Func<T, Text> received) =>
      issue ?? (t => Text.Expected(t, expected, InvokePart(received, t)));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The section describing the expected value</param>
    /// <param name="received">The function that formats the section describing the received value</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static Issue<T> ElseExpected<T>(this Issue<T>? issue, Text expected, Func<T, FormattableString> received) =>
      issue ?? (t => Text.Expected(t, expected, InvokePart(received, t)));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The section describing the expected value</param>
    /// <param name="received">The section describing the received value</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static Issue<T> ElseExpected<T>(this Issue<T>? issue, FormattableString expected, Text received) =>
      issue ?? (t => Text.Expected(t, FormatPart(expected), received));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The section describing the expected value</param>
    /// <param name="received">The section describing the received value</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static Issue<T> ElseExpected<T>(this Issue<T>? issue, FormattableString expected, FormattableString received) =>
      issue ?? (t => Text.Expected(t, FormatPart(expected), FormatPart(received)));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The section describing the expected value</param>
    /// <param name="received">The function that formats the section describing the received value</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static Issue<T> ElseExpected<T>(this Issue<T>? issue, FormattableString expected, Func<T, Text> received) =>
      issue ?? (t => Text.Expected(t, FormatPart(expected), InvokePart(received, t)));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The section describing the expected value</param>
    /// <param name="received">The function that formats the section describing the received value</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static Issue<T> ElseExpected<T>(this Issue<T>? issue, FormattableString expected, Func<T, FormattableString> received) =>
      issue ?? (t => Text.Expected(t, FormatPart(expected), InvokePart(received, t)));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The function that formats the section describing the expected value</param>
    /// <param name="received">The section describing the received value</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static Issue<T> ElseExpected<T>(this Issue<T>? issue, Func<T, Text> expected, Text received) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t), received));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The function that formats the section describing the expected value</param>
    /// <param name="received">The section describing the received value</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static Issue<T> ElseExpected<T>(this Issue<T>? issue, Func<T, Text> expected, FormattableString received) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t), FormatPart(received)));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The function that formats the section describing the expected value</param>
    /// <param name="received">The function that formats the section describing the received value</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static Issue<T> ElseExpected<T>(this Issue<T>? issue, Func<T, Text> expected, Func<T, Text> received) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t), InvokePart(received, t)));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The function that formats the section describing the expected value</param>
    /// <param name="received">The function that formats the section describing the received value</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static Issue<T> ElseExpected<T>(this Issue<T>? issue, Func<T, Text> expected, Func<T, FormattableString> received) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t), InvokePart(received, t)));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The function that formats the section describing the expected value</param>
    /// <param name="received">The section describing the received value</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static Issue<T> ElseExpected<T>(this Issue<T>? issue, Func<T, FormattableString> expected, Text received) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t), received));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The function that formats the section describing the expected value</param>
    /// <param name="received">The section describing the received value</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static Issue<T> ElseExpected<T>(this Issue<T>? issue, Func<T, FormattableString> expected, FormattableString received) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t), FormatPart(received)));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The function that formats the section describing the expected value</param>
    /// <param name="received">The function that formats the section describing the received value</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static Issue<T> ElseExpected<T>(this Issue<T>? issue, Func<T, FormattableString> expected, Func<T, Text> received) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t), InvokePart(received, t)));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The function that formats the section describing the expected value</param>
    /// <param name="received">The function that formats the section describing the received value</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static Issue<T> ElseExpected<T>(this Issue<T>? issue, Func<T, FormattableString> expected, Func<T, FormattableString> received) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t), InvokePart(received, t)));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue describing an expectation on <paramref name="member"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <typeparam name="TValue">The type of member value</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="member">The name of the accessed member</param>
    /// <param name="value">The value to compare against the member value</param>
    /// <param name="getValue">The function which accesses the member on the target value</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static Issue<T> ElseExpectedHas<T, TValue>(this Issue<T>? issue, string member, TValue value, Func<T, TValue> getValue) =>
      issue.ElseExpected(
        $"{member} == {Text(value)}",
        t => t == null ? NullText : $"{member} == {Text(getValue(t))} ({Text(t)})");

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue describing an expectation on <paramref name="member"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <typeparam name="TValue">The type of member value</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="member">The name of the accessed member</param>
    /// <param name="value">The value to compare against the member value</param>
    /// <param name="getValue">The function which accesses the member on the target value</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
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

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue for <paramref name="message"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="message">The message to use if <paramref name="issue"/> is <see langword="null"/></param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue for <paramref name="message"/></returns>
    public static IssueMany<T> ElseMessage<T>(this IssueMany<T>? issue, Text message) =>
      issue ?? (t => message);

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue for <paramref name="message"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="message">The message to use if <paramref name="issue"/> is <see langword="null"/></param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue for <paramref name="message"/></returns>
    public static IssueMany<T> ElseMessage<T>(this IssueMany<T>? issue, FormattableString message) =>
      issue ?? (t => FormatPart(message));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue for <paramref name="message"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="message">The function that formats the target sequence into a message</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue for <paramref name="message"/></returns>
    public static IssueMany<T> ElseMessage<T>(this IssueMany<T>? issue, Func<IEnumerable<T>, Text> message) =>
      issue ?? (t => InvokePart(message, t));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue for <paramref name="message"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="message">The function that formats the target sequence into a message</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue for <paramref name="message"/></returns>
    public static IssueMany<T> ElseMessage<T>(this IssueMany<T>? issue, Func<IEnumerable<T>, FormattableString> message) =>
      issue ?? (t => InvokePart(message, t));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and received sections
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The section describing the expected sequence</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static IssueMany<T> ElseExpected<T>(this IssueMany<T>? issue, Text expected) =>
      issue ?? (t => Text.Expected(t, expected));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and received sections
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The section describing the expected sequence</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static IssueMany<T> ElseExpected<T>(this IssueMany<T>? issue, FormattableString expected) =>
      issue ?? (t => Text.Expected(t, FormatPart(expected)));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and received sections
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The function that formats the section describing the expected sequence</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static IssueMany<T> ElseExpected<T>(this IssueMany<T>? issue, Func<IEnumerable<T>, Text> expected) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t)));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and received sections
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The function that formats the section describing the expected sequence</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static IssueMany<T> ElseExpected<T>(this IssueMany<T>? issue, Func<IEnumerable<T>, FormattableString> expected) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t)));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The section describing the expected sequence</param>
    /// <param name="received">The section describing the received sequence</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static IssueMany<T> ElseExpected<T>(this IssueMany<T>? issue, Text expected, Text received) =>
      issue ?? (t => Text.Expected(t, expected, received));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The section describing the expected sequence</param>
    /// <param name="received">The section describing the received sequence</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static IssueMany<T> ElseExpected<T>(this IssueMany<T>? issue, Text expected, FormattableString received) =>
      issue ?? (t => Text.Expected(t, expected, FormatPart(received)));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The section describing the expected sequence</param>
    /// <param name="received">The function that formats the section describing the received sequence</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static IssueMany<T> ElseExpected<T>(this IssueMany<T>? issue, Text expected, Func<IEnumerable<T>, Text> received) =>
      issue ?? (t => Text.Expected(t, expected, InvokePart(received, t)));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The section describing the expected sequence</param>
    /// <param name="received">The function that formats the section describing the received sequence</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static IssueMany<T> ElseExpected<T>(this IssueMany<T>? issue, Text expected, Func<IEnumerable<T>, FormattableString> received) =>
      issue ?? (t => Text.Expected(t, expected, InvokePart(received, t)));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The section describing the expected sequence</param>
    /// <param name="received">The section describing the received sequence</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static IssueMany<T> ElseExpected<T>(this IssueMany<T>? issue, FormattableString expected, Text received) =>
      issue ?? (t => Text.Expected(t, FormatPart(expected), received));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The section describing the expected sequence</param>
    /// <param name="received">The section describing the received sequence</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static IssueMany<T> ElseExpected<T>(this IssueMany<T>? issue, FormattableString expected, FormattableString received) =>
      issue ?? (t => Text.Expected(t, FormatPart(expected), FormatPart(received)));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The section describing the expected sequence</param>
    /// <param name="received">The function that formats the section describing the received sequence</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static IssueMany<T> ElseExpected<T>(this IssueMany<T>? issue, FormattableString expected, Func<IEnumerable<T>, Text> received) =>
      issue ?? (t => Text.Expected(t, FormatPart(expected), InvokePart(received, t)));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The section describing the expected sequence</param>
    /// <param name="received">The function that formats the section describing the received sequence</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static IssueMany<T> ElseExpected<T>(this IssueMany<T>? issue, FormattableString expected, Func<IEnumerable<T>, FormattableString> received) =>
      issue ?? (t => Text.Expected(t, FormatPart(expected), InvokePart(received, t)));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The function that formats the section describing the expected sequence</param>
    /// <param name="received">The section describing the received sequence</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static IssueMany<T> ElseExpected<T>(this IssueMany<T>? issue, Func<IEnumerable<T>, Text> expected, Text received) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t), received));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The function that formats the section describing the expected sequence</param>
    /// <param name="received">The section describing the received sequence</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static IssueMany<T> ElseExpected<T>(this IssueMany<T>? issue, Func<IEnumerable<T>, Text> expected, FormattableString received) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t), FormatPart(received)));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The function that formats the section describing the expected sequence</param>
    /// <param name="received">The function that formats the section describing the received sequence</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static IssueMany<T> ElseExpected<T>(this IssueMany<T>? issue, Func<IEnumerable<T>, Text> expected, Func<IEnumerable<T>, Text> received) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t), InvokePart(received, t)));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The function that formats the section describing the expected sequence</param>
    /// <param name="received">The function that formats the section describing the received sequence</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static IssueMany<T> ElseExpected<T>(this IssueMany<T>? issue, Func<IEnumerable<T>, Text> expected, Func<IEnumerable<T>, FormattableString> received) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t), InvokePart(received, t)));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The function that formats the section describing the expected sequence</param>
    /// <param name="received">The section describing the received sequence</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static IssueMany<T> ElseExpected<T>(this IssueMany<T>? issue, Func<IEnumerable<T>, FormattableString> expected, Text received) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t), received));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The function that formats the section describing the expected sequence</param>
    /// <param name="received">The section describing the received sequence</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static IssueMany<T> ElseExpected<T>(this IssueMany<T>? issue, Func<IEnumerable<T>, FormattableString> expected, FormattableString received) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t), FormatPart(received)));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The function that formats the section describing the expected sequence</param>
    /// <param name="received">The function that formats the section describing the received sequence</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static IssueMany<T> ElseExpected<T>(this IssueMany<T>? issue, Func<IEnumerable<T>, FormattableString> expected, Func<IEnumerable<T>, Text> received) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t), InvokePart(received, t)));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The function that formats the section describing the expected sequence</param>
    /// <param name="received">The function that formats the section describing the received sequence</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static IssueMany<T> ElseExpected<T>(this IssueMany<T>? issue, Func<IEnumerable<T>, FormattableString> expected, Func<IEnumerable<T>, FormattableString> received) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t), InvokePart(received, t)));

    static string InvokePart<T>(Func<IEnumerable<T>, Text> part, IEnumerable<T> target) =>
      part?.Invoke(target) ?? TextMany(target);

    static string InvokePart<T>(Func<IEnumerable<T>, FormattableString> part, IEnumerable<T> target) =>
      part?.Invoke(target)?.ToString() ?? TextMany(target);

    //
    // Pairs
    //

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue for <paramref name="message"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="message">The message to use if <paramref name="issue"/> is <see langword="null"/></param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue for <paramref name="message"/></returns>
    public static IssueMany<TKey, TValue> ElseMessage<TKey, TValue>(this IssueMany<TKey, TValue>? issue, Text message) =>
      issue ?? (t => message);

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue for <paramref name="message"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="message">The message to use if <paramref name="issue"/> is <see langword="null"/></param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue for <paramref name="message"/></returns>
    public static IssueMany<TKey, TValue> ElseMessage<TKey, TValue>(this IssueMany<TKey, TValue>? issue, FormattableString message) =>
      issue ?? (t => FormatPart(message));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue for <paramref name="message"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="message">The function that formats the target dictionary into a message</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue for <paramref name="message"/></returns>
    public static IssueMany<TKey, TValue> ElseMessage<TKey, TValue>(this IssueMany<TKey, TValue>? issue, Func<IEnumerable<KeyValuePair<TKey, TValue>>, Text> message) =>
      issue ?? (t => InvokePart(message, t));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue for <paramref name="message"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="message">The function that formats the target dictionary into a message</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue for <paramref name="message"/></returns>
    public static IssueMany<TKey, TValue> ElseMessage<TKey, TValue>(this IssueMany<TKey, TValue>? issue, Func<IEnumerable<KeyValuePair<TKey, TValue>>, FormattableString> message) =>
      issue ?? (t => InvokePart(message, t));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and received sections
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The section describing the expected dictionary</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static IssueMany<TKey, TValue> ElseExpected<TKey, TValue>(this IssueMany<TKey, TValue>? issue, Text expected) =>
      issue ?? (t => Text.Expected(t, expected));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and received sections
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The section describing the expected dictionary</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static IssueMany<TKey, TValue> ElseExpected<TKey, TValue>(this IssueMany<TKey, TValue>? issue, FormattableString expected) =>
      issue ?? (t => Text.Expected(t, FormatPart(expected)));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and received sections
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The function that formats the section describing the expected dictionary</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static IssueMany<TKey, TValue> ElseExpected<TKey, TValue>(this IssueMany<TKey, TValue>? issue, Func<IEnumerable<KeyValuePair<TKey, TValue>>, Text> expected) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t)));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and received sections
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The function that formats the section describing the expected dictionary</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static IssueMany<TKey, TValue> ElseExpected<TKey, TValue>(this IssueMany<TKey, TValue>? issue, Func<IEnumerable<KeyValuePair<TKey, TValue>>, FormattableString> expected) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t)));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The section describing the expected dictionary</param>
    /// <param name="received">The section describing the received dictionary</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static IssueMany<TKey, TValue> ElseExpected<TKey, TValue>(this IssueMany<TKey, TValue>? issue, Text expected, Text received) =>
      issue ?? (t => Text.Expected(t, expected, received));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The section describing the expected dictionary</param>
    /// <param name="received">The section describing the received dictionary</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static IssueMany<TKey, TValue> ElseExpected<TKey, TValue>(this IssueMany<TKey, TValue>? issue, Text expected, FormattableString received) =>
      issue ?? (t => Text.Expected(t, expected, FormatPart(received)));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The section describing the expected dictionary</param>
    /// <param name="received">The function that formats the section describing the received dictionary</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static IssueMany<TKey, TValue> ElseExpected<TKey, TValue>(this IssueMany<TKey, TValue>? issue, Text expected, Func<IEnumerable<KeyValuePair<TKey, TValue>>, Text> received) =>
      issue ?? (t => Text.Expected(t, expected, InvokePart(received, t)));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The section describing the expected dictionary</param>
    /// <param name="received">The function that formats the section describing the received dictionary</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static IssueMany<TKey, TValue> ElseExpected<TKey, TValue>(this IssueMany<TKey, TValue>? issue, Text expected, Func<IEnumerable<KeyValuePair<TKey, TValue>>, FormattableString> received) =>
      issue ?? (t => Text.Expected(t, expected, InvokePart(received, t)));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The section describing the expected dictionary</param>
    /// <param name="received">The section describing the received dictionary</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static IssueMany<TKey, TValue> ElseExpected<TKey, TValue>(this IssueMany<TKey, TValue>? issue, FormattableString expected, Text received) =>
      issue ?? (t => Text.Expected(t, FormatPart(expected), received));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The section describing the expected dictionary</param>
    /// <param name="received">The section describing the received dictionary</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static IssueMany<TKey, TValue> ElseExpected<TKey, TValue>(this IssueMany<TKey, TValue>? issue, FormattableString expected, FormattableString received) =>
      issue ?? (t => Text.Expected(t, FormatPart(expected), FormatPart(received)));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The section describing the expected dictionary</param>
    /// <param name="received">The function that formats the section describing the received dictionary</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static IssueMany<TKey, TValue> ElseExpected<TKey, TValue>(this IssueMany<TKey, TValue>? issue, FormattableString expected, Func<IEnumerable<KeyValuePair<TKey, TValue>>, Text> received) =>
      issue ?? (t => Text.Expected(t, FormatPart(expected), InvokePart(received, t)));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The section describing the expected dictionary</param>
    /// <param name="received">The function that formats the section describing the received dictionary</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static IssueMany<TKey, TValue> ElseExpected<TKey, TValue>(this IssueMany<TKey, TValue>? issue, FormattableString expected, Func<IEnumerable<KeyValuePair<TKey, TValue>>, FormattableString> received) =>
      issue ?? (t => Text.Expected(t, FormatPart(expected), InvokePart(received, t)));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The function that formats the section describing the expected dictionary</param>
    /// <param name="received">The section describing the received dictionary</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static IssueMany<TKey, TValue> ElseExpected<TKey, TValue>(this IssueMany<TKey, TValue>? issue, Func<IEnumerable<KeyValuePair<TKey, TValue>>, Text> expected, Text received) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t), received));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The function that formats the section describing the expected dictionary</param>
    /// <param name="received">The section describing the received dictionary</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static IssueMany<TKey, TValue> ElseExpected<TKey, TValue>(this IssueMany<TKey, TValue>? issue, Func<IEnumerable<KeyValuePair<TKey, TValue>>, Text> expected, FormattableString received) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t), FormatPart(received)));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The function that formats the section describing the expected dictionary</param>
    /// <param name="received">The function that formats the section describing the received dictionary</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static IssueMany<TKey, TValue> ElseExpected<TKey, TValue>(this IssueMany<TKey, TValue>? issue, Func<IEnumerable<KeyValuePair<TKey, TValue>>, Text> expected, Func<IEnumerable<KeyValuePair<TKey, TValue>>, Text> received) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t), InvokePart(received, t)));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The function that formats the section describing the expected dictionary</param>
    /// <param name="received">The function that formats the section describing the received dictionary</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static IssueMany<TKey, TValue> ElseExpected<TKey, TValue>(this IssueMany<TKey, TValue>? issue, Func<IEnumerable<KeyValuePair<TKey, TValue>>, Text> expected, Func<IEnumerable<KeyValuePair<TKey, TValue>>, FormattableString> received) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t), InvokePart(received, t)));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The function that formats the section describing the expected dictionary</param>
    /// <param name="received">The section describing the received dictionary</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static IssueMany<TKey, TValue> ElseExpected<TKey, TValue>(this IssueMany<TKey, TValue>? issue, Func<IEnumerable<KeyValuePair<TKey, TValue>>, FormattableString> expected, Text received) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t), received));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The function that formats the section describing the expected dictionary</param>
    /// <param name="received">The section describing the received dictionary</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static IssueMany<TKey, TValue> ElseExpected<TKey, TValue>(this IssueMany<TKey, TValue>? issue, Func<IEnumerable<KeyValuePair<TKey, TValue>>, FormattableString> expected, FormattableString received) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t), FormatPart(received)));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The function that formats the section describing the expected dictionary</param>
    /// <param name="received">The function that formats the section describing the received dictionary</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static IssueMany<TKey, TValue> ElseExpected<TKey, TValue>(this IssueMany<TKey, TValue>? issue, Func<IEnumerable<KeyValuePair<TKey, TValue>>, FormattableString> expected, Func<IEnumerable<KeyValuePair<TKey, TValue>>, Text> received) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t), InvokePart(received, t)));

    /// <summary>
    /// Returns <paramref name="issue"/> if not <see langword="null"/>, else an issue with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="expected">The function that formats the section describing the expected dictionary</param>
    /// <param name="received">The function that formats the section describing the received dictionary</param>
    /// <returns><paramref name="issue"/> if not <see langword="null"/>, else an issue with the default format</returns>
    public static IssueMany<TKey, TValue> ElseExpected<TKey, TValue>(this IssueMany<TKey, TValue>? issue, Func<IEnumerable<KeyValuePair<TKey, TValue>>, FormattableString> expected, Func<IEnumerable<KeyValuePair<TKey, TValue>>, FormattableString> received) =>
      issue ?? (t => Text.Expected(t, InvokePart(expected, t), InvokePart(received, t)));

    static string InvokePart<TKey, TValue>(Func<IEnumerable<KeyValuePair<TKey, TValue>>, Text> part, IEnumerable<KeyValuePair<TKey, TValue>> target) =>
      part?.Invoke(target) ?? TextMany(target);

    static string InvokePart<TKey, TValue>(Func<IEnumerable<KeyValuePair<TKey, TValue>>, FormattableString> part, IEnumerable<KeyValuePair<TKey, TValue>> target) =>
      part?.Invoke(target)?.ToString() ?? TextMany(target);
  }
}