using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Green
{
  internal static class Text
  {
    internal static string Of(object? value) =>
      value == null || value is string ? OfValue(value) : OfObject(value);

    static string OfValue(object? value) =>
      value switch
      {
        null => "<null>",
        string s => $"\"{s}\"",
        char c when char.IsControl(c) || char.IsHighSurrogate(c) || char.IsLowSurrogate(c) => @$"\u{(int) c:X4}",
        char c => $"'{c}'",
        bool b => b.ToString().ToLowerInvariant(),
        Delegate d => (d.Method.DeclaringType.Name.Contains("<") ? "" : d.Method.DeclaringType.Name + ".") + d.Method.Name,
        _ => value.ToString() ?? ""
      };

    static string OfObject(object value)
    {
      var type = value.GetType();

      return type.TryOfPair(value) ?? type.TryOfMany(value) ?? OfValue(value);
    }

    static string? TryOfPair(this Type type, object value) =>
      type.IsPair(out var keyType, out var valueType) ? Format.Pair(value, keyType!, valueType!) : null;

    static string? TryOfMany(this Type type, object value)
    {
      var enumerableArgs =
        from i in type.GetInterfaces()
        where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>)
        select i.GetGenericArguments().Single();

      var itemType = default(Type);

      foreach(var enumerableArg in enumerableArgs)
      {
        if(enumerableArg.IsPair(out var keyType, out var valueType))
        {
          return Format.Pairs(value, keyType!, valueType!);
        }

        itemType ??= enumerableArg;
      }

      return itemType != null ? Format.Items(value, itemType) : null;
    }

    static bool IsPair(this Type type, out Type? keyType, out Type? valueType)
    {
      if(type.IsGenericType && type.GetGenericTypeDefinition() == typeof(KeyValuePair<,>))
      {
        var typeArgs = type.GetGenericArguments();

        keyType = typeArgs[0];
        valueType = typeArgs[1];
        return true;
      }

      keyType = null;
      valueType = null;
      return false;
    }

    static class Format
    {
      static readonly MethodInfo _pair = typeof(Format).GetMethod(nameof(FormatPair), BindingFlags.Static | BindingFlags.NonPublic);
      static readonly MethodInfo _pairs = typeof(Format).GetMethod(nameof(FormatPairs), BindingFlags.Static | BindingFlags.NonPublic);
      static readonly MethodInfo _items = typeof(Format).GetMethod(nameof(FormatItems), BindingFlags.Static | BindingFlags.NonPublic);

      internal static string Pair(object value, Type keyType, Type valueType) =>
       (string) _pair.MakeGenericMethod(keyType, valueType).Invoke(null, new[] { value });

      internal static string Pairs(object value, Type keyType, Type valueType) =>
        (string) _pairs.MakeGenericMethod(keyType, valueType).Invoke(null, new[] { value });

      internal static string Items(object value, Type itemType) =>
        (string) _items.MakeGenericMethod(itemType).Invoke(null, new[] { value });

      static string FormatPair<TKey, TValue>(KeyValuePair<TKey, TValue> pair) =>
        $"[{Of(pair.Key)}] = {Of(pair.Value)}";

      static string FormatPairs<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>>? pairs)
      {
        var text = new StringBuilder("{");

        foreach(var pair in pairs ?? Enumerable.Empty<KeyValuePair<TKey, TValue>>())
        {
          if(text.Length > 1)
          {
            text.Append(",");
          }

          text.AppendLine().Append("  ").Append(Of(pair));
        }

        if(text.Length > 1)
        {
          text.AppendLine();
        }

        return text.Append("}").ToString();
      }

      static string FormatItems<T>(IEnumerable<T>? items)
      {
        var values = new List<string>();
        var totalLength = 0;

        foreach(var item in items ?? Enumerable.Empty<T>())
        {
          var value = Of(item);

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
    }
  }
}