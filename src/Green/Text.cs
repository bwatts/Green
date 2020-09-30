using System;
using System.Collections.Generic;
using System.Globalization;

namespace Green
{
  /// <summary>
  /// Formats text for use in expectation messages
  /// </summary>
  public static class Text
  {
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
    public static Text<TKey, TValue> Pair<TKey, TValue>(KeyValuePair<TKey, TValue> pair) =>
      new Text<TKey, TValue>(pair);

    /// <summary>
    /// Gets text for <paramref name="key"/> and <paramref name="value"/> that defers formatting until requested
    /// </summary>
    /// <typeparam name="TKey">The type of key in the pair to format</typeparam>
    /// <typeparam name="TValue">The type of value in the pair to format</typeparam>
    /// <param name="key">The key in the pair to format</param>
    /// <param name="value">The key in the pair to format</param>
    /// <returns>Text for <paramref name="key"/> and <paramref name="value"/> that defers formatting until requested</returns>
    public static Text<TKey, TValue> Pair<TKey, TValue>(TKey key, TValue value) =>
      Pair(new KeyValuePair<TKey, TValue>(key, value));

    /// <summary>
    /// Gets text for <paramref name="items"/> that defers formatting until requested
    /// </summary>
    /// <typeparam name="T">The type of items in the sequence to format</typeparam>
    /// <param name="items">The sequence to format</param>
    /// <returns>Text for <paramref name="items"/> that defers formatting until requested</returns>
    public static TextMany<T> Many<T>(IEnumerable<T>? items) =>
      new TextMany<T>(items);

    /// <summary>
    /// Gets text for <paramref name="pairs"/> that defers formatting until requested
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the dictionary to format</typeparam>
    /// <typeparam name="TValue">The type of values in the dictionary to format</typeparam>
    /// <param name="pairs">The dictionary to format</param>
    /// <returns>Text for <paramref name="pairs"/> that defers formatting until requested</returns>
    public static TextMany<TKey, TValue> Many<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>>? pairs) =>
      new TextMany<TKey, TValue>(pairs);
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
        char c when char.IsControl(c) || char.IsHighSurrogate(c) || char.IsLowSurrogate(c) => @$"\u{(int) c:X4}",
        char c => $"'{c}'",
        bool b => b.ToString().ToLowerInvariant(),
        IFormattable formattable => formattable.ToString(format, formatProvider),
        _ => _value.ToString() ?? ""
      };

    /// <summary>
    /// Implicitly gets the <see cref="string"/> value of <paramref name="text"/>
    /// </summary>
    /// <param name="text">The text to implicitly convert</param>
    /// <returns>The <see cref="string"/> value of <paramref name="text"/></returns>
    public static implicit operator string(Text<T> text) =>
      text.ToString();
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
      $"[{Text.Of(_pair.Key).ToString(format, formatProvider)}] = {Text.Of(_pair.Value).ToString(format, formatProvider)}";

    /// <summary>
    /// Implicitly gets the <see cref="string"/> value of <paramref name="text"/>
    /// </summary>
    /// <param name="text">The text to implicitly convert</param>
    /// <returns>The <see cref="string"/> value of <paramref name="text"/></returns>
    public static implicit operator string(Text<TKey, TValue> text) =>
      text.ToString();
  }
}