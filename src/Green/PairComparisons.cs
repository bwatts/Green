using System;
using System.Collections.Generic;

namespace Green
{
  internal static class PairComparisons
  {
    internal static IEqualityComparer<KeyValuePair<TKey, TValue>> Default<TKey, TValue>() =>
      EqualityComparer<TKey, TValue>.Default;

    internal static IEqualityComparer<KeyValuePair<TKey, TValue>> ElseDefault<TKey, TValue>(this IEqualityComparer<KeyValuePair<TKey, TValue>> comparer) =>
      comparer ?? EqualityComparer<TKey, TValue>.Default;

    internal static IEqualityComparer<KeyValuePair<TKey, TValue>> GetComparer<TKey, TValue>(this KeyValuePair<TKey, TValue> _) =>
      EqualityComparer<TKey, TValue>.Default;

    internal static IEqualityComparer<KeyValuePair<TKey, TValue>> GetComparer<TKey, TValue>(this KeyValuePair<TKey, TValue> _, IEqualityComparer<TKey> keyComparer) =>
      new EqualityComparer<TKey, TValue>(keyComparer);

    internal static IEqualityComparer<KeyValuePair<TKey, TValue>> GetComparer<TKey, TValue>(this KeyValuePair<TKey, TValue> _, IEqualityComparer<TValue> valueComparer) =>
      new EqualityComparer<TKey, TValue>(valueComparer);

    internal static IEqualityComparer<KeyValuePair<TKey, TValue>> GetComparer<TKey, TValue>(this KeyValuePair<TKey, TValue> _, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer) =>
      new EqualityComparer<TKey, TValue>(keyComparer, valueComparer);

    internal static IEqualityComparer<KeyValuePair<TKey, TValue>> GetComparer<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> _) =>
      EqualityComparer<TKey, TValue>.Default;

    internal static IEqualityComparer<KeyValuePair<TKey, TValue>> GetComparer<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> _, IEqualityComparer<TKey> keyComparer) =>
      new EqualityComparer<TKey, TValue>(keyComparer);

    internal static IEqualityComparer<KeyValuePair<TKey, TValue>> GetComparer<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> _, IEqualityComparer<TValue> valueComparer) =>
      new EqualityComparer<TKey, TValue>(valueComparer);

    internal static IEqualityComparer<KeyValuePair<TKey, TValue>> GetComparer<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> _, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer) =>
      new EqualityComparer<TKey, TValue>(keyComparer, valueComparer);

    class EqualityComparer<TKey, TValue> : IEqualityComparer<KeyValuePair<TKey, TValue>>
    {
      readonly IEqualityComparer<TKey> _keyComparer;
      readonly IEqualityComparer<TValue> _valueComparer;

      internal EqualityComparer(IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer)
      {
        _keyComparer = keyComparer ?? EqualityComparer<TKey>.Default;
        _valueComparer = valueComparer ?? EqualityComparer<TValue>.Default;
      }

      internal EqualityComparer(IEqualityComparer<TKey> keyComparer) : this(keyComparer, null)
      {}

      internal EqualityComparer(IEqualityComparer<TValue> valueComparer) : this(null, valueComparer)
      {}

      internal EqualityComparer() : this(null, null)
      {}

      public bool Equals(KeyValuePair<TKey, TValue> x, KeyValuePair<TKey, TValue> y) =>
        _keyComparer.Equals(x.Key, y.Key) && _valueComparer.Equals(x.Value, y.Value);

      public int GetHashCode(KeyValuePair<TKey, TValue> obj) =>
        HashCode.Combine(_keyComparer.GetHashCode(obj.Key), _valueComparer.GetHashCode(obj.Value));

      internal static readonly EqualityComparer<TKey, TValue> Default = new EqualityComparer<TKey, TValue>();
    }
  }
}