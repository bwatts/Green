using System;
using System.Collections.Generic;
using System.Globalization;

namespace Green.Messages
{
  public struct Text
  {
    readonly string _value;

    Text(string value)
    {
      _value = value;
    }

    public override string ToString() => _value ?? "";
    public string ToString(IFormatProvider provider) => _value?.ToString(provider) ?? "";

    public static implicit operator Text(string value) => new Text(value);
    public static implicit operator Text(FormattableString value) => new Text(value?.ToString());
    public static implicit operator string(Text text) => text.ToString();

    public static Text<T> Of<T>(T value) => new Text<T>(value);
    public static Text<TKey, TValue> Of<TKey, TValue>(KeyValuePair<TKey, TValue> pair) => new Text<TKey, TValue>(pair);
    public static TextMany<T> Many<T>(IEnumerable<T> items) => new TextMany<T>(items);
    public static TextMany<TKey, TValue> Many<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> pairs) => new TextMany<TKey, TValue>(pairs);

    public const string Null = "<null>";
    public const string Empty = "\"\"";

    public static string Expected<T>(T target, string expected, string received) =>
      $@"Unexpected value of type {target?.GetType() ?? typeof(T)}
Expected: {expected}
Received: {received}";

    public static string Expected<T>(IEnumerable<T> target, string expected, string received) =>
      $@"Unexpected sequence of type {target?.GetType() ?? typeof(IEnumerable<T>)}
Expected: {expected}
Received: {received}";

    public static string Expected<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> target, string expected, string received) =>
      $@"Unexpected pair sequence of type {target?.GetType() ?? typeof(IEnumerable<KeyValuePair<TKey, TValue>>)}
Expected: {expected}
Received: {received}";

    public static string Expected<T>(T target, string expected) =>
      Expected(target, expected, Of(target));

    public static string Expected<T>(IEnumerable<T> target, string expected) =>
      Expected(target, expected, Many(target));

    public static string Expected<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> target, string expected) =>
      Expected(target, expected, Many(target));
  }

  public struct Text<T> : IFormattable
  {
    readonly T _value;

    public Text(T value)
    {
      _value = value;
    }

    public string ToString(string format, IFormatProvider formatProvider) =>
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

    public override string ToString() =>
      ToString(null, CultureInfo.CurrentCulture);

    public static implicit operator Text(Text<T> text) => text.ToString();
    public static implicit operator string(Text<T> text) => text.ToString();
  }

  public struct Text<TKey, TValue> : IFormattable
  {
    readonly KeyValuePair<TKey, TValue> _pair;

    public Text(KeyValuePair<TKey, TValue> pair)
    {
      _pair = pair;
    }

    public string ToString(string format, IFormatProvider formatProvider) =>
      $"[{Text.Of(_pair.Key)}] = {Text.Of(_pair.Value)}";

    public override string ToString() =>
      ToString(null, CultureInfo.CurrentCulture);

    public static implicit operator Text(Text<TKey, TValue> text) => text.ToString();
    public static implicit operator string(Text<TKey, TValue> text) => text.ToString();
  }
}