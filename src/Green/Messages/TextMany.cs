using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Green.Messages
{
  /// <summary>
  /// A sequence with items of type <typeparamref name="T"/> that defers formatting until requested
  /// </summary>
  /// <typeparam name="T">The type of items in the sequence to format</typeparam>
  public struct TextMany<T> : IFormattable
  {
    readonly IEnumerable<T> _items;

    internal TextMany(IEnumerable<T> items)
    {
      _items = items;
    }

    /// <summary>
    /// Formats the sequence using <see cref="CultureInfo.CurrentCulture"/>
    /// </summary>
    /// <returns>The result of formatting the sequence</returns>
    public override string ToString() =>
      ToString(null, CultureInfo.CurrentCulture);

    /// <summary>
    /// Formats the sequence by passing <paramref name="format"/> and <paramref name="formatProvider"/> to its items' <see cref="IFormattable"/> implementations, if any
    /// </summary>
    /// <param name="format">The format string to pass to <see cref="IFormattable.ToString(string, IFormatProvider)"/>, if implemented</param>
    /// <param name="formatProvider">The format provider to pass to <see cref="IFormattable.ToString(string, IFormatProvider)"/>, if implemented</param>
    /// <returns>The result of formatting the sequence</returns>
    public string ToString(string? format, IFormatProvider? formatProvider)
    {
      var values = new List<string>();
      var totalLength = 0;

      foreach(var item in _items ?? Enumerable.Empty<T>())
      {
        var value = Text.Of(item).ToString(format, formatProvider);

        values.Add(value);
        totalLength += value.Length;
      }

      if(totalLength <= 60)
      {
        return $"[{string.Join(", ", values)}]";
      }

      var text = new StringBuilder();

      foreach(var value in values)
      {
        if(text.Length == 0)
        {
          text.AppendLine("[");
        }
        else
        {
          text.AppendLine(",");
        }

        text.Append("  ").Append(value);
      }

      return text.AppendLine().Append("]").ToString();
    }

    /// <summary>
    /// Implicitly gets the <see cref="Text"/> value of <paramref name="text"/>
    /// </summary>
    /// <param name="text">The text to implicitly convert</param>
    /// <returns>The <see cref="Text"/> value of <paramref name="text"/></returns>
    public static implicit operator Text(TextMany<T> text) =>
      text.ToString();

    /// <summary>
    /// Implicitly gets the <see cref="string"/> value of <paramref name="text"/>
    /// </summary>
    /// <param name="text">The text to implicitly convert</param>
    /// <returns>The <see cref="string"/> value of <paramref name="text"/></returns>
    public static implicit operator string(TextMany<T> text) =>
      text.ToString();
  }

  /// <summary>
  /// A dictionary with keys of type <typeparamref name="TKey"/> and values of type <typeparamref name="TValue"/> that defers formatting until requested
  /// </summary>
  /// <typeparam name="TKey">The type of keys in the dictionary to format</typeparam>
  /// <typeparam name="TValue">The type of values in the dictionary to format</typeparam>
  public struct TextMany<TKey, TValue> : IFormattable
  {
    readonly IEnumerable<KeyValuePair<TKey, TValue>> _pairs;

    internal TextMany(IEnumerable<KeyValuePair<TKey, TValue>> pairs)
    {
      _pairs = pairs;
    }

    /// <summary>
    /// Formats the dictionary using <see cref="CultureInfo.CurrentCulture"/>
    /// </summary>
    /// <returns>The result of formatting the dictionary</returns>
    public override string ToString() =>
      ToString(null, CultureInfo.CurrentCulture);

    /// <summary>
    /// Formats the dictionary by passing <paramref name="format"/> and <paramref name="formatProvider"/> to its keys' and values' <see cref="IFormattable"/> implementations, if any
    /// </summary>
    /// <param name="format">The format string to pass to <see cref="IFormattable.ToString(string, IFormatProvider)"/>, if implemented</param>
    /// <param name="formatProvider">The format provider to pass to <see cref="IFormattable.ToString(string, IFormatProvider)"/>, if implemented</param>
    /// <returns>The result of formatting the dictionary</returns>
    public string ToString(string? format, IFormatProvider? formatProvider)
    {
      var text = new StringBuilder("{");

      foreach(var pair in _pairs ?? Enumerable.Empty<KeyValuePair<TKey, TValue>>())
      {
        if(text.Length > 1)
        {
          text.Append(",");
        }

        text.AppendLine().Append("  ").Append(Text.Pair(pair).ToString(format, formatProvider));
      }

      if(text.Length > 1)
      {
        text.AppendLine();
      }

      return text.Append("}").ToString();
    }

    /// <summary>
    /// Implicitly gets the <see cref="Text"/> value of <paramref name="text"/>
    /// </summary>
    /// <param name="text">The text to implicitly convert</param>
    /// <returns>The <see cref="Text"/> value of <paramref name="text"/></returns>
    public static implicit operator Text(TextMany<TKey, TValue> text) =>
      text.ToString();

    /// <summary>
    /// Implicitly gets the <see cref="string"/> value of <paramref name="text"/>
    /// </summary>
    /// <param name="text">The text to implicitly convert</param>
    /// <returns>The <see cref="string"/> value of <paramref name="text"/></returns>
    public static implicit operator string(TextMany<TKey, TValue> text) =>
      text.ToString();
  }
}