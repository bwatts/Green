using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Green.Messages
{
  public struct TextMany<T> : IFormattable
  {
    readonly IEnumerable<T> _items;

    public TextMany(IEnumerable<T> items)
    {
      _items = items;
    }

    public override string ToString() =>
      ToString(null, CultureInfo.CurrentCulture);

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

    public static implicit operator Text(TextMany<T> text) => text.ToString();
    public static implicit operator string(TextMany<T> text) => text.ToString();
  }

  public struct TextMany<TKey, TValue> : IFormattable
  {
    readonly IEnumerable<KeyValuePair<TKey, TValue>> _pairs;

    public TextMany(IEnumerable<KeyValuePair<TKey, TValue>> pairs)
    {
      _pairs = pairs;
    }
      
    public override string ToString() =>
      ToString(null, CultureInfo.CurrentCulture);

    public string ToString(string? format, IFormatProvider? formatProvider)
    {
      var text = new StringBuilder();

      foreach(var pair in _pairs ?? Enumerable.Empty<KeyValuePair<TKey, TValue>>())
      {
        if(text.Length == 0)
        {
          text.AppendLine("{");
        }
        else
        {
          text.AppendLine(",");
        }

        text.Append(" ").Append(Text.Format(pair, format, formatProvider));
      }

      return text.AppendLine().Append("}").ToString();
    }

    public static implicit operator Text(TextMany<TKey, TValue> text) => text.ToString();
    public static implicit operator string(TextMany<TKey, TValue> text) => text.ToString();
  }
}