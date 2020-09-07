using System;
using System.Collections.Generic;
using System.Globalization;

namespace Green.Messages
{
  /// <summary>
  /// A <see cref="string"/> value that implicitly converts from <see cref="string"/> and <see cref="FormattableString"/>.
  /// When present in a pair of overloads alongside <see cref="FormattableString"/>, the compiler sends interpolated strings ($"...")
  /// into the <see cref="FormattableString"/> overload, allowing Green to defer string formatting until an expectation fails.
  /// </summary>
  /// <remarks>
  /// Overloads that pair <see cref="string"/> and <see cref="FormattableString"/> always resolve to <see cref="string"/>.
  /// However, because <see cref="Text"/> requires a conversion step, the compiler instead chooses <see cref="FormattableString"/>.
  /// </remarks>
  public struct Text
  {
    readonly string? _value;

    Text(string? value) => _value = value;

    /// <summary>
    /// Gets the value of this text
    /// </summary>
    /// <returns>The value of this text, or empty if there is no value</returns>
    public override string ToString() =>
      _value ?? "";

    /// <summary>
    /// Creates a <see cref="Text"/> instance for <paramref name="value"/>
    /// </summary>
    /// <param name="value">The value of the instance</param>
    public static implicit operator Text(string value) =>
      new Text(value);

    /// <summary>
    /// Creates a <see cref="Text"/> instance for <paramref name="value"/>
    /// </summary>
    /// <param name="value">The value of the instance</param>
    public static implicit operator Text(FormattableString value) =>
      new Text(value?.ToString());

    /// <summary>
    /// Gets the <see cref="string"/> value of <paramref name="text"/>
    /// </summary>
    /// <param name="text">The instance with the <see cref="string"/> value</param>
    /// <returns>The <see cref="string"/> value of <paramref name="text"/></returns>
    public static implicit operator string(Text text) =>
      text.ToString();

    /// <summary>
    /// Gets text for <paramref name="value"/> that defers formatting until requested
    /// </summary>
    /// <typeparam name="T">The type of value to format</typeparam>
    /// <param name="value">The value to format</param>
    /// <returns>Text for <paramref name="value"/> that defers formatting until requested</returns>
    public static Text<T> Of<T>(T value) =>
      new Text<T>(value);

    /// <summary>
    /// Gets text for <paramref name="pair"/> that defers formatting until requested
    /// </summary>
    /// <typeparam name="TKey">The type of key in the pair to format</typeparam>
    /// <typeparam name="TValue">The type of value in the pair to format</typeparam>
    /// <param name="pair">The pair to format</param>
    /// <returns>Text for <paramref name="pair"/> that defers formatting until requested</returns>
    public static Text<TKey, TValue> Of<TKey, TValue>(KeyValuePair<TKey, TValue> pair) =>
      new Text<TKey, TValue>(pair);

    /// <summary>
    /// Gets text for <paramref name="items"/> that defers formatting until requested
    /// </summary>
    /// <typeparam name="T">The type of items in the sequence to format</typeparam>
    /// <param name="items">The sequence to format</param>
    /// <returns>Text for <paramref name="items"/> that defers formatting until requested</returns>
    public static TextMany<T> Many<T>(IEnumerable<T> items) =>
      new TextMany<T>(items);

    /// <summary>
    /// Gets text for <paramref name="pairs"/> that defers formatting until requested
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the dictionary to format</typeparam>
    /// <typeparam name="TValue">The type of values in the dictionary to format</typeparam>
    /// <returns>Text for <paramref name="pairs"/> that defers formatting until requested</returns>
    public static TextMany<TKey, TValue> Many<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> pairs) =>
      new TextMany<TKey, TValue>(pairs);

    /// <summary>
    /// Formats <paramref name="value"/> by passing <paramref name="format"/> and <paramref name="formatProvider"/> to its <see cref="IFormattable"/> implementation, if any
    /// </summary>
    /// <typeparam name="T">The type of value to format</typeparam>
    /// <param name="value">The value to format</param>
    /// <param name="format">The format string to pass to <see cref="IFormattable.ToString(string, IFormatProvider)"/>, if implemented</param>
    /// <param name="formatProvider">The format provider to pass to <see cref="IFormattable.ToString(string, IFormatProvider)"/>, if implemented</param>
    /// <returns>The result of formatting <paramref name="value"/></returns>
    public static string Format<T>(T value, string? format, IFormatProvider? formatProvider) =>
      Of(value).ToString(format, formatProvider);

    /// <summary>
    /// Text describing the <see langword="null"/> reference
    /// </summary>
    public const string Null = "<null>";

    /// <summary>
    /// Text describing the empty string ("")
    /// </summary>
    public const string Empty = "\"\"";

    /// <summary>
    /// Formats a message for <paramref name="target"/> with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="T">The type of value to format</typeparam>
    /// <param name="target">The value to format</param>
    /// <param name="expected">The section describing the expected value</param>
    /// <param name="received">The section describing the received value</param>
    /// <returns>The formatted message</returns>
    public static string Expected<T>(T target, string expected, string received) =>
      $@"Unexpected value of type {target?.GetType() ?? typeof(T)}
Expected: {expected}
Received: {received}";

    /// <summary>
    /// Formats a message for <paramref name="target"/> with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="T">The type of items in the sequence to format</typeparam>
    /// <param name="target">The sequence to format</param>
    /// <param name="expected">The section describing the expected sequence</param>
    /// <param name="received">The section describing the received sequence</param>
    /// <returns>The formatted message</returns>
    public static string Expected<T>(IEnumerable<T> target, string expected, string received) =>
      $@"Unexpected sequence of type {target?.GetType() ?? typeof(IEnumerable<T>)}
Expected: {expected}
Received: {received}";

    /// <summary>
    /// Formats a message for <paramref name="target"/> with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the dictionary to format</typeparam>
    /// <typeparam name="TValue">The type of values in the dictionary to format</typeparam>
    /// <param name="target">The dictionary to format</param>
    /// <param name="expected">The section describing the expected dictionary</param>
    /// <param name="received">The section describing the received dictionary</param>
    /// <returns>The formatted message</returns>
    public static string Expected<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> target, string expected, string received) =>
      $@"Unexpected pair sequence of type {target?.GetType() ?? typeof(IEnumerable<KeyValuePair<TKey, TValue>>)}
Expected: {expected}
Received: {received}";

    /// <summary>
    /// Formats a message for <paramref name="target"/> with <paramref name="expected"/> and received sections
    /// </summary>
    /// <typeparam name="T">The type of value to format</typeparam>
    /// <param name="target">The value to format</param>
    /// <param name="expected">The section describing the expected value</param>
    /// <returns>The formatted message</returns>
    public static string Expected<T>(T target, string expected) =>
      Expected(target, expected, Of(target));

    /// <summary>
    /// Formats a message for <paramref name="target"/> with <paramref name="expected"/> and received sections
    /// </summary>
    /// <typeparam name="T">The type of items in the sequence to format</typeparam>
    /// <param name="target">The sequence to format</param>
    /// <param name="expected">The section describing the expected sequence</param>
    /// <returns>The formatted message</returns>
    public static string Expected<T>(IEnumerable<T> target, string expected) =>
      Expected(target, expected, Many(target));

    /// <summary>
    /// Formats a message for <paramref name="target"/> with <paramref name="expected"/> and received sections
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the dictionary to format</typeparam>
    /// <typeparam name="TValue">The type of values in the dictionary to format</typeparam>
    /// <param name="target">The dictionary to format</param>
    /// <param name="expected">The section describing the expected dictionary</param>
    /// <returns>The formatted message</returns>
    public static string Expected<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> target, string expected) =>
      Expected(target, expected, Many(target));
  }

  /// <summary>
  /// A value of type <typeparamref name="T"/> that defers formatting until requested
  /// </summary>
  /// <typeparam name="T">The type of value to format</typeparam>
  public struct Text<T> : IFormattable
  {
    readonly T _value;

    internal Text(T value)
    {
      _value = value;
    }

    /// <summary>
    /// Formats the value using <see cref="CultureInfo.CurrentCulture"/>
    /// </summary>
    /// <returns>The result of formatting the value</returns>
    public override string ToString() =>
      ToString(null, CultureInfo.CurrentCulture);

    /// <summary>
    /// Formats the value by passing <paramref name="format"/> and <paramref name="formatProvider"/> to its <see cref="IFormattable"/> implementation, if any
    /// </summary>
    /// <param name="format">The format string to pass to <see cref="IFormattable.ToString(string, IFormatProvider)"/>, if implemented</param>
    /// <param name="formatProvider">The format provider to pass to <see cref="IFormattable.ToString(string, IFormatProvider)"/>, if implemented</param>
    /// <returns>The result of formatting the value</returns>
    public string ToString(string? format, IFormatProvider? formatProvider) =>
      _value switch
      {
        null => "<null>",
        string s => $"\"{s}\"",
        char c when char.IsControl(c) || char.IsHighSurrogate(c) || char.IsLowSurrogate(c) => @$"\u{c:X4}",
        char c => $"'{c}'",
        bool b => b.ToString().ToLowerInvariant(),
        IFormattable formattable => formattable.ToString(format, formatProvider),
        _ => _value.ToString() ?? ""
      };

    /// <summary>
    /// Implicitly gets the <see cref="Text"/> value of <paramref name="text"/>
    /// </summary>
    /// <param name="text">The text to implicitly convert</param>
    /// <returns>The <see cref="Text"/> value of <paramref name="text"/></returns>
    public static implicit operator Text(Text<T> text) => text.ToString();

    /// <summary>
    /// Implicitly gets the <see cref="string"/> value of <paramref name="text"/>
    /// </summary>
    /// <param name="text">The text to implicitly convert</param>
    /// <returns>The <see cref="string"/> value of <paramref name="text"/></returns>
    public static implicit operator string(Text<T> text) => text.ToString();
  }

  /// <summary>
  /// A pair with keys of type <typeparamref name="TKey"/> and values of type <typeparamref name="TValue"/> that defers formatting until requested
  /// </summary>
  /// <typeparam name="TKey">The type of key in the pair to format</typeparam>
  /// <typeparam name="TValue">The type of value in the pair to format</typeparam>
  public struct Text<TKey, TValue> : IFormattable
  {
    readonly KeyValuePair<TKey, TValue> _pair;

    internal Text(KeyValuePair<TKey, TValue> pair)
    {
      _pair = pair;
    }

    /// <summary>
    /// Formats the pair using <see cref="CultureInfo.CurrentCulture"/>
    /// </summary>
    /// <returns>The result of formatting the value</returns>
    public override string ToString() =>
      ToString(null, CultureInfo.CurrentCulture);

    /// <summary>
    /// Formats the pair by passing <paramref name="format"/> and <paramref name="formatProvider"/> to it keys' and values'  <see cref="IFormattable"/> implementations, if any
    /// </summary>
    /// <param name="format">The format string to pass to <see cref="IFormattable.ToString(string, IFormatProvider)"/>, if implemented</param>
    /// <param name="formatProvider">The format provider to pass to <see cref="IFormattable.ToString(string, IFormatProvider)"/>, if implemented</param>
    /// <returns>The result of formatting the pair</returns>
    public string ToString(string? format, IFormatProvider? formatProvider) =>
      $"[{Text.Format(_pair.Key, format, formatProvider)}] = {Text.Format(_pair.Value, format, formatProvider)}";

    /// <summary>
    /// Implicitly gets the <see cref="Text"/> value of <paramref name="text"/>
    /// </summary>
    /// <param name="text">The text to implicitly convert</param>
    /// <returns>The <see cref="Text"/> value of <paramref name="text"/></returns>
    public static implicit operator Text(Text<TKey, TValue> text) => text.ToString();

    /// <summary>
    /// Implicitly gets the <see cref="string"/> value of <paramref name="text"/>
    /// </summary>
    /// <param name="text">The text to implicitly convert</param>
    /// <returns>The <see cref="string"/> value of <paramref name="text"/></returns>
    public static implicit operator string(Text<TKey, TValue> text) => text.ToString();
  }
}