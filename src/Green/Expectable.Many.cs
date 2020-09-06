using System;
using System.Collections.Generic;
using System.Linq;
using Green.Messages;
using static Green.Local;
using static Green.Messages.Local;

namespace Green
{
  public static partial class Expectable
  {
    //
    // Has
    //

    public static ExpectMany<T> Has<T>(this ExpectMany<T> expect, T value, IssueMany<T>? issue = null) =>
      expect.That(t => t != null && t.Contains(value), issue.ElseExpected(Text(value)));

    public static ExpectMany<T> Has<T>(this ExpectMany<T> expect, T value, IEqualityComparer<T> comparer, IssueMany<T>? issue = null) =>
      expect.That(t => t != null && t.Contains(value, comparer), issue.ElseExpected($"{Text(value)}{comparer.ToSuffix()}"));

    public static ExpectMany<T> DoesNotHave<T>(this ExpectMany<T> expect, T value, IssueMany<T>? issue = null) =>
      expect.Not(t => t != null && t.Contains(value), issue.ElseExpected($"not {Text(value)}"));

    public static ExpectMany<T> DoesNotHave<T>(this ExpectMany<T> expect, T value, IEqualityComparer<T> comparer, IssueMany<T>? issue = null) =>
      expect.Not(t => t != null && t.Contains(value, comparer), issue.ElseExpected($"not {value}{comparer.ToSuffix()}"));

    //
    // All
    //

    public static ExpectMany<T> HasAll<T>(this ExpectMany<T> expect, IEnumerable<T> values, IEqualityComparer<T> comparer, IssueMany<T>? issue = null) =>
      expect.That(
        t => t != null && values != null && t.IsSupersetOf(values, comparer),
        issue.ElseExpected(t => $"all of {TextMany(values)}{comparer.ToSuffix()}"));

    public static ExpectMany<T> HasAll<T>(this ExpectMany<T> expect, IEnumerable<T> values, IssueMany<T>? issue = null) =>
      expect.HasAll(values, EqualityComparer<T>.Default, issue);

    public static ExpectMany<T> HasAll<T>(this ExpectMany<T> expect, params T[] values) =>
      expect.HasAll(values.AsEnumerable());

    public static ExpectMany<T> HasAll<T>(this ExpectMany<T> expect, IssueMany<T> issue, params T[] values) =>
      expect.HasAll(values.AsEnumerable(), issue);

    public static ExpectMany<T> HasAll<T>(this ExpectMany<T> expect, IEqualityComparer<T> comparer, params T[] values) =>
      expect.HasAll(values.AsEnumerable(), comparer);

    public static ExpectMany<T> HasAll<T>(this ExpectMany<T> expect, IEqualityComparer<T> comparer, IssueMany<T> issue, params T[] values) =>
      expect.HasAll(values.AsEnumerable(), comparer, issue);

    public static ExpectMany<T> HasAll<T>(this ExpectMany<T> check, Action<Expect<T>> expectItem) =>
      check.That(t => t != null && t.All(expectItem.Invoke));

    //
    // Any
    //

    public static ExpectMany<T> HasAny<T>(this ExpectMany<T> expect, IEnumerable<T> values, IEqualityComparer<T> comparer, IssueMany<T>? issue = null) =>
      expect.That(
        t => t != null && values != null && t.IntersectsWith(values, comparer),
        issue.ElseExpected(t => $"any of {TextMany(values)}{comparer.ToSuffix()}"));

    public static ExpectMany<T> HasAny<T>(this ExpectMany<T> expect, IEnumerable<T> values, IssueMany<T>? issue = null) =>
      expect.HasAny(values, EqualityComparer<T>.Default, issue);

    public static ExpectMany<T> HasAny<T>(this ExpectMany<T> expect, params T[] values) =>
      expect.HasAny(values.AsEnumerable());

    public static ExpectMany<T> HasAny<T>(this ExpectMany<T> expect, IssueMany<T> issue, params T[] values) =>
      expect.HasAny(values.AsEnumerable(), issue);

    public static ExpectMany<T> HasAny<T>(this ExpectMany<T> expect, IEqualityComparer<T> comparer, params T[] values) =>
      expect.HasAny(values.AsEnumerable(), comparer);

    public static ExpectMany<T> HasAny<T>(this ExpectMany<T> expect, IEqualityComparer<T> comparer, IssueMany<T> issue, params T[] values) =>
      expect.HasAny(values.AsEnumerable(), comparer, issue);

    //
    // None
    //

    public static ExpectMany<T> HasNone<T>(this ExpectMany<T> expect, IEnumerable<T> values, IEqualityComparer<T> comparer, IssueMany<T>? issue = null) =>
      expect.That(
        t => t != null && values != null && !t.IntersectsWith(values, comparer),
        issue.ElseExpected(t => $"none of {TextMany(values)}{comparer.ToSuffix()}"));

    public static ExpectMany<T> HasNone<T>(this ExpectMany<T> expect, IEnumerable<T> values, IssueMany<T>? issue = null) =>
      expect.HasNone(values, EqualityComparer<T>.Default, issue);

    public static ExpectMany<T> HasNone<T>(this ExpectMany<T> expect, params T[] values) =>
      expect.HasNone(values.AsEnumerable());

    public static ExpectMany<T> HasNone<T>(this ExpectMany<T> expect, IssueMany<T> issue, params T[] values) =>
      expect.HasNone(values.AsEnumerable(), issue);

    public static ExpectMany<T> HasNone<T>(this ExpectMany<T> expect, IEqualityComparer<T> comparer, params T[] values) =>
      expect.HasNone(values.AsEnumerable(), comparer);

    public static ExpectMany<T> HasNone<T>(this ExpectMany<T> expect, IEqualityComparer<T> comparer, IssueMany<T> issue, params T[] values) =>
      expect.HasNone(values.AsEnumerable(), comparer, issue);

    //
    // Where
    //

    public static ExpectMany<T> HasAllWhere<T>(this ExpectMany<T> expect, Func<T, bool> predicate, IssueMany<T>? issue = null) =>
      expect.That(t => t != null && predicate != null && t.All(predicate), issue.ElseExpected($"all match predicate {predicate}"));

    public static ExpectMany<T> HasAnyWhere<T>(this ExpectMany<T> expect, Func<T, bool> predicate, IssueMany<T>? issue = null) =>
      expect.That(t => t != null && predicate != null && t.Any(predicate), issue.ElseExpected($"any match predicate {predicate}"));

    public static ExpectMany<T> HasNoneWhere<T>(this ExpectMany<T> expect, Func<T, bool> predicate, IssueMany<T>? issue = null) =>
      expect.That(t => t != null && predicate != null && !t.Any(predicate), issue.ElseExpected($"none match predicate {predicate}"));

    public static ExpectMany<T> HasCountWhere<T>(this ExpectMany<T> expect, int count, Func<T, bool> predicate, IssueMany<T>? issue = null) =>
      expect.That(t => t != null && predicate != null && t.Count(predicate) == count, issue.ElseExpected($"count of {count} matching predicate {predicate}"));

    //
    // Same
    //

    public static ExpectMany<T> HasSame<T>(this ExpectMany<T> expect, IEnumerable<T> items, IEqualityComparer<T> comparer, IssueMany<T>? issue = null) =>
      expect.That(
        t => t != null && items != null && t.OrderBy(item => item).SequenceEqual(items.OrderBy(item => item), comparer),
        issue.ElseExpected(t => $"same items as {TextMany(items)}{comparer.ToSuffix()}"));

    public static ExpectMany<T> HasSame<T>(this ExpectMany<T> expect, IEnumerable<T> items, IssueMany<T>? issue = null) =>
      expect.HasSame(items, EqualityComparer<T>.Default, issue);

    public static ExpectMany<T> HasSame<T>(this ExpectMany<T> expect, params T[] items) =>
      expect.HasSame(items.AsEnumerable());

    public static ExpectMany<T> HasSame<T>(this ExpectMany<T> expect, IssueMany<T> issue, params T[] items) =>
      expect.HasSame(items.AsEnumerable(), issue);

    public static ExpectMany<T> HasSame<T>(this ExpectMany<T> expect, IEqualityComparer<T> comparer, params T[] items) =>
      expect.HasSame(items.AsEnumerable(), comparer);

    public static ExpectMany<T> HasSame<T>(this ExpectMany<T> expect, IEqualityComparer<T> comparer, IssueMany<T> issue, params T[] items) =>
      expect.HasSame(items.AsEnumerable(), comparer, issue);

    //
    // Same in order
    //

    public static ExpectMany<T> HasSameInOrder<T>(this ExpectMany<T> expect, IEnumerable<T> items, IEqualityComparer<T> comparer, IssueMany<T>? issue = null) =>
      expect.That(
        t => t != null && items != null && t.SequenceEqual(items, comparer),
        issue.ElseExpected(t => $"same items in same order as {TextMany(items)}{comparer.ToSuffix()}"));

    public static ExpectMany<T> HasSameInOrder<T>(this ExpectMany<T> expect, IEnumerable<T> items, IssueMany<T>? issue = null) =>
      expect.HasSameInOrder(items, EqualityComparer<T>.Default, issue);

    public static ExpectMany<T> HasSameInOrder<T>(this ExpectMany<T> expect, params T[] items) =>
      expect.HasSameInOrder(items.AsEnumerable());

    public static ExpectMany<T> HasSameInOrder<T>(this ExpectMany<T> expect, IssueMany<T> issue, params T[] items) =>
      expect.HasSameInOrder(items.AsEnumerable(), issue);

    public static ExpectMany<T> HasSameInOrder<T>(this ExpectMany<T> expect, IEqualityComparer<T> comparer, params T[] items) =>
      expect.HasSameInOrder(items.AsEnumerable(), comparer);

    public static ExpectMany<T> HasSameInOrder<T>(this ExpectMany<T> expect, IEqualityComparer<T> comparer, IssueMany<T> issue, params T[] items) =>
      expect.HasSameInOrder(items.AsEnumerable(), comparer, issue);

    //
    // Counts
    //

    public static ExpectMany<T> HasCount<T>(this ExpectMany<T> expect, int value, IssueMany<T>? issue = null) =>
      expect.That(t => t != null &&
        Expect(t.GetOrFindCount()).Is(value, count => Expected(count, $"Count == {value}", $"Count == {count} ({TextMany(t)})")));

    public static ExpectMany<T> HasCount<T>(this ExpectMany<T> expect, Action<Expect<int>> expectValue) =>
      expect.That(t => t != null && expectValue.Invoke(t.GetOrFindCount()));

    public static ExpectMany<T> Has1<T>(this ExpectMany<T> expect) => expect.HasCount(1);
    public static ExpectMany<T> Has2<T>(this ExpectMany<T> expect) => expect.HasCount(2);
    public static ExpectMany<T> Has3<T>(this ExpectMany<T> expect) => expect.HasCount(3);
    public static ExpectMany<T> Has4<T>(this ExpectMany<T> expect) => expect.HasCount(4);
    public static ExpectMany<T> Has5<T>(this ExpectMany<T> expect) => expect.HasCount(5);
    public static ExpectMany<T> Has6<T>(this ExpectMany<T> expect) => expect.HasCount(6);
    public static ExpectMany<T> Has7<T>(this ExpectMany<T> expect) => expect.HasCount(7);
    public static ExpectMany<T> Has8<T>(this ExpectMany<T> expect) => expect.HasCount(8);

    public static ExpectMany<T> Has1<T>(this ExpectMany<T> expect, Action<T> expectItem, IssueMany<T>? issue = null) =>
      expect.HasN(1, issue, items => expectItem?.Invoke(items[0]));

    public static ExpectMany<T> Has2<T>(this ExpectMany<T> expect, Action<T, T> expectItems, IssueMany<T>? issue = null) =>
      expect.HasN(2, issue, items => expectItems?.Invoke(items[0], items[1]));

    public static ExpectMany<T> Has3<T>(this ExpectMany<T> expect, Action<T, T, T> expectItems, IssueMany<T>? issue = null) =>
      expect.HasN(3, issue, items => expectItems?.Invoke(items[0], items[1], items[2]));

    public static ExpectMany<T> Has4<T>(this ExpectMany<T> expect, Action<T, T, T, T> expectItems, IssueMany<T>? issue = null) =>
      expect.HasN(4, issue, items => expectItems?.Invoke(items[0], items[1], items[2], items[3]));

    public static ExpectMany<T> Has5<T>(this ExpectMany<T> expect, Action<T, T, T, T, T> expectItems, IssueMany<T>? issue = null) =>
      expect.HasN(5, issue, items => expectItems?.Invoke(items[0], items[1], items[2], items[3], items[4]));

    public static ExpectMany<T> Has6<T>(this ExpectMany<T> expect, Action<T, T, T, T, T, T> expectItems, IssueMany<T>? issue = null) =>
      expect.HasN(6, issue, items => expectItems?.Invoke(items[0], items[1], items[2], items[3], items[4], items[5]));

    public static ExpectMany<T> Has7<T>(this ExpectMany<T> expect, Action<T, T, T, T, T, T, T> expectItems, IssueMany<T>? issue = null) =>
      expect.HasN(7, issue, items => expectItems?.Invoke(items[0], items[1], items[2], items[3], items[4], items[5], items[6]));

    public static ExpectMany<T> Has8<T>(this ExpectMany<T> expect, Action<T, T, T, T, T, T, T, T> expectItems, IssueMany<T>? issue = null) =>
      expect.HasN(8, issue, items => expectItems?.Invoke(items[0], items[1], items[2], items[3], items[4], items[5], items[6], items[7]));

    static ExpectMany<T> HasN<T>(this ExpectMany<T> expect, int n, IssueMany<T>? issue, Action<IList<T>> expectItems) =>
        expect.That(t =>
        {
          if(!t.TryCountItems(n, out var items))
          {
            return false;
          }

          expectItems(items);

          return true;
        }, issue.ElseExpected($"Count == {n}", t => $"Count == {t.GetOrFindCount()} ({TextMany(t)})"));

    //
    // Has (pairs)
    //

    public static ExpectMany<TKey, TValue> Has<TKey, TValue>(this ExpectMany<TKey, TValue> expect, KeyValuePair<TKey, TValue> pair, IssueMany<TKey, TValue>? issue = null) =>
      expect.Has(pair, pair.GetComparer(), issue);

    public static ExpectMany<TKey, TValue> Has<TKey, TValue>(this ExpectMany<TKey, TValue> expect, KeyValuePair<TKey, TValue> pair, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && t.Contains(pair, comparer.ElseDefault()), issue.ElseExpected($"{Text(pair)}{comparer.ToSuffix()}"));

    public static ExpectMany<TKey, TValue> Has<TKey, TValue>(this ExpectMany<TKey, TValue> expect, KeyValuePair<TKey, TValue> pair, IEqualityComparer<TKey> keyComparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && t.Contains(pair, pair.GetComparer(keyComparer)), issue.ElseExpected($"{Text(pair)}{keyComparer.ToKeySuffix()}"));

    public static ExpectMany<TKey, TValue> Has<TKey, TValue>(this ExpectMany<TKey, TValue> expect, KeyValuePair<TKey, TValue> pair, IEqualityComparer<TValue> valueComparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && t.Contains(pair, pair.GetComparer(valueComparer)), issue.ElseExpected($"{Text(pair)}{valueComparer.ToValueSuffix()}"));

    public static ExpectMany<TKey, TValue> Has<TKey, TValue>(this ExpectMany<TKey, TValue> expect, KeyValuePair<TKey, TValue> pair, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && t.Contains(pair, pair.GetComparer(keyComparer, valueComparer)), issue.ElseExpected($"{Text(pair)}{keyComparer.ToKeySuffix()}{valueComparer.ToValueSuffix()}"));

    public static ExpectMany<TKey, TValue> Has<TKey, TValue>(this ExpectMany<TKey, TValue> expect, TKey key, TValue value, IssueMany<TKey, TValue>? issue = null) =>
      expect.Has(new KeyValuePair<TKey, TValue>(key, value), issue);

    public static ExpectMany<TKey, TValue> Has<TKey, TValue>(this ExpectMany<TKey, TValue> expect, TKey key, TValue value, IEqualityComparer<TKey> keyComparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.Has(new KeyValuePair<TKey, TValue>(key, value), keyComparer, issue);

    public static ExpectMany<TKey, TValue> Has<TKey, TValue>(this ExpectMany<TKey, TValue> expect, TKey key, TValue value, IEqualityComparer<TValue> valueComparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.Has(new KeyValuePair<TKey, TValue>(key, value), valueComparer, issue);

    public static ExpectMany<TKey, TValue> Has<TKey, TValue>(this ExpectMany<TKey, TValue> expect, TKey key, TValue value, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.Has(new KeyValuePair<TKey, TValue>(key, value), keyComparer, valueComparer, issue);

    //
    // All (pairs)
    //

    public static ExpectMany<TKey, TValue> HasAll<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IssueMany<TKey, TValue>? issue = null) =>
      expect.HasAll(pairs, pairs.GetComparer(), issue);

    public static ExpectMany<TKey, TValue> HasAll<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && pairs != null && t.IsSupersetOf(pairs, comparer.ElseDefault()), issue.ElseExpected($"all of {TextMany(pairs)}{comparer.ToSuffix()}"));

    public static ExpectMany<TKey, TValue> HasAll<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<TKey> keyComparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && pairs != null && t.IsSupersetOf(pairs, pairs.GetComparer(keyComparer)), issue.ElseExpected($"all of {TextMany(pairs)}{keyComparer.ToKeySuffix()}"));

    public static ExpectMany<TKey, TValue> HasAll<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<TValue> valueComparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && pairs != null && t.IsSupersetOf(pairs, pairs.GetComparer(valueComparer)), issue.ElseExpected($"all of {TextMany(pairs)}{valueComparer.ToValueSuffix()}"));

    public static ExpectMany<TKey, TValue> HasAll<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && pairs != null && t.IsSupersetOf(pairs, pairs.GetComparer(keyComparer, valueComparer)), issue.ElseExpected($"all of {TextMany(pairs)}{keyComparer.ToKeySuffix()}{valueComparer.ToValueSuffix()}"));

    public static ExpectMany<TKey, TValue> HasAll<TKey, TValue>(this ExpectMany<TKey, TValue> expect, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasAll(pairs.AsEnumerable());

    public static ExpectMany<TKey, TValue> HasAll<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasAll(pairs.AsEnumerable(), comparer);

    public static ExpectMany<TKey, TValue> HasAll<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TKey> keyComparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasAll(pairs.AsEnumerable(), keyComparer);

    public static ExpectMany<TKey, TValue> HasAll<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TValue> valueComparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasAll(pairs.AsEnumerable(), valueComparer);

    public static ExpectMany<TKey, TValue> HasAll<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasAll(pairs.AsEnumerable(), keyComparer, valueComparer);

    public static ExpectMany<TKey, TValue> HasAll<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasAll(pairs.AsEnumerable(), issue);

    public static ExpectMany<TKey, TValue> HasAll<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasAll(pairs.AsEnumerable(), comparer, issue);

    public static ExpectMany<TKey, TValue> HasAll<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TKey> keyComparer, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasAll(pairs.AsEnumerable(), keyComparer, issue);

    public static ExpectMany<TKey, TValue> HasAll<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TValue> valueComparer, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasAll(pairs.AsEnumerable(), valueComparer, issue);

    public static ExpectMany<TKey, TValue> HasAll<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasAll(pairs.AsEnumerable(), keyComparer, valueComparer, issue);

    public static ExpectMany<TKey, TValue> HasAll<TKey, TValue>(this ExpectMany<TKey, TValue> expect, Action<Expect<TKey>> expectKeys) =>
      expect.That(t => t != null && t.All(pair => expectKeys.Invoke(pair.Key)));

    public static ExpectMany<TKey, TValue> HasAll<TKey, TValue>(this ExpectMany<TKey, TValue> expect, Action<Expect<TValue>> expectValues) =>
      expect.That(t => t != null && t.All(pair => expectValues.Invoke(pair.Value)));

    public static ExpectMany<TKey, TValue> HasAll<TKey, TValue>(this ExpectMany<TKey, TValue> expect, Action<Expect<TKey>, Expect<TValue>> expectPairs) =>
      expect.That(t => t != null && t.All(pair => expectPairs.Invoke(pair)));

    //
    // Any (pairs)
    //

    public static ExpectMany<TKey, TValue> HasAny<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IssueMany<TKey, TValue>? issue = null) =>
      expect.HasAny(pairs, pairs.GetComparer(), issue);

    public static ExpectMany<TKey, TValue> HasAny<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && pairs != null && t.IntersectsWith(pairs, comparer.ElseDefault()), issue.ElseExpected($"any of {TextMany(pairs)}{comparer.ToSuffix()}"));

    public static ExpectMany<TKey, TValue> HasAny<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<TKey> keyComparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && pairs != null && t.IntersectsWith(pairs, pairs.GetComparer(keyComparer)), issue.ElseExpected($"any of {TextMany(pairs)}{keyComparer.ToKeySuffix()}"));

    public static ExpectMany<TKey, TValue> HasAny<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<TValue> valueComparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && pairs != null && t.IntersectsWith(pairs, pairs.GetComparer(valueComparer)), issue.ElseExpected($"any of {TextMany(pairs)}{valueComparer.ToValueSuffix()}"));

    public static ExpectMany<TKey, TValue> HasAny<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && pairs != null && t.IntersectsWith(pairs, pairs.GetComparer(keyComparer, valueComparer)), issue.ElseExpected($"any of {TextMany(pairs)}{keyComparer.ToKeySuffix()}{valueComparer.ToValueSuffix()}"));

    public static ExpectMany<TKey, TValue> HasAny<TKey, TValue>(this ExpectMany<TKey, TValue> expect, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasAny(pairs.AsEnumerable());

    public static ExpectMany<TKey, TValue> HasAny<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasAny(pairs.AsEnumerable(), comparer);

    public static ExpectMany<TKey, TValue> HasAny<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TKey> keyComparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasAny(pairs.AsEnumerable(), keyComparer);

    public static ExpectMany<TKey, TValue> HasAny<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TValue> valueComparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasAny(pairs.AsEnumerable(), valueComparer);

    public static ExpectMany<TKey, TValue> HasAny<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasAny(pairs.AsEnumerable(), keyComparer, valueComparer);

    public static ExpectMany<TKey, TValue> HasAny<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasAny(pairs.AsEnumerable(), issue);

    public static ExpectMany<TKey, TValue> HasAny<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasAny(pairs.AsEnumerable(), comparer, issue);

    public static ExpectMany<TKey, TValue> HasAny<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TKey> keyComparer, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasAny(pairs.AsEnumerable(), keyComparer, issue);

    public static ExpectMany<TKey, TValue> HasAny<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TValue> valueComparer, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasAny(pairs.AsEnumerable(), valueComparer, issue);

    public static ExpectMany<TKey, TValue> HasAny<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasAny(pairs.AsEnumerable(), keyComparer, valueComparer, issue);

    //
    // None (pairs)
    //

    public static ExpectMany<TKey, TValue> HasNone<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IssueMany<TKey, TValue>? issue = null) =>
      expect.HasNone(pairs, pairs.GetComparer(), issue);

    public static ExpectMany<TKey, TValue> HasNone<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && pairs != null && !t.IntersectsWith(pairs, comparer.ElseDefault()), issue.ElseExpected($"none of {TextMany(pairs)}{comparer.ToSuffix()}"));

    public static ExpectMany<TKey, TValue> HasNone<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<TKey> keyComparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && pairs != null && !t.IntersectsWith(pairs, pairs.GetComparer(keyComparer)), issue.ElseExpected($"none of {TextMany(pairs)}{keyComparer.ToKeySuffix()}"));

    public static ExpectMany<TKey, TValue> HasNone<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<TValue> valueComparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && pairs != null && !t.IntersectsWith(pairs, pairs.GetComparer(valueComparer)), issue.ElseExpected($"none of {TextMany(pairs)}{valueComparer.ToValueSuffix()}"));

    public static ExpectMany<TKey, TValue> HasNone<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && pairs != null && !t.IntersectsWith(pairs, pairs.GetComparer(keyComparer, valueComparer)), issue.ElseExpected($"none of {TextMany(pairs)}{keyComparer.ToKeySuffix()}{valueComparer.ToValueSuffix()}"));

    public static ExpectMany<TKey, TValue> HasNone<TKey, TValue>(this ExpectMany<TKey, TValue> expect, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasNone(pairs.AsEnumerable());

    public static ExpectMany<TKey, TValue> HasNone<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasNone(pairs.AsEnumerable(), comparer);

    public static ExpectMany<TKey, TValue> HasNone<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TKey> keyComparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasNone(pairs.AsEnumerable(), keyComparer);

    public static ExpectMany<TKey, TValue> HasNone<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TValue> valueComparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasNone(pairs.AsEnumerable(), valueComparer);

    public static ExpectMany<TKey, TValue> HasNone<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasNone(pairs.AsEnumerable(), keyComparer, valueComparer);

    public static ExpectMany<TKey, TValue> HasNone<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasNone(pairs.AsEnumerable(), issue);

    public static ExpectMany<TKey, TValue> HasNone<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasNone(pairs.AsEnumerable(), comparer, issue);

    public static ExpectMany<TKey, TValue> HasNone<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TKey> keyComparer, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasNone(pairs.AsEnumerable(), keyComparer, issue);

    public static ExpectMany<TKey, TValue> HasNone<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TValue> valueComparer, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasNone(pairs.AsEnumerable(), valueComparer, issue);

    public static ExpectMany<TKey, TValue> HasNone<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasNone(pairs.AsEnumerable(), keyComparer, valueComparer, issue);

    //
    // Where (pairs)
    //

    public static ExpectMany<TKey, TValue> HasAllWhere<TKey, TValue>(this ExpectMany<TKey, TValue> expect, Func<KeyValuePair<TKey, TValue>, bool> predicate, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && predicate != null && t.All(predicate), issue.ElseExpected($"all match predicate {predicate}"));

    public static ExpectMany<TKey, TValue> HasAllWhere<TKey, TValue>(this ExpectMany<TKey, TValue> expect, Func<TKey, TValue, bool> predicate, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && predicate != null && t.All(pair => predicate(pair.Key, pair.Value)), issue.ElseExpected($"all match predicate {predicate}"));

    public static ExpectMany<TKey, TValue> HasAnyWhere<TKey, TValue>(this ExpectMany<TKey, TValue> expect, Func<KeyValuePair<TKey, TValue>, bool> predicate, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && predicate != null && t.Any(predicate), issue.ElseExpected($"any match predicate {predicate}"));

    public static ExpectMany<TKey, TValue> HasAnyWhere<TKey, TValue>(this ExpectMany<TKey, TValue> expect, Func<TKey, TValue, bool> predicate, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && predicate != null && t.Any(pair => predicate(pair.Key, pair.Value)), issue.ElseExpected($"any match predicate {predicate}"));

    public static ExpectMany<TKey, TValue> HasNoneWhere<TKey, TValue>(this ExpectMany<TKey, TValue> expect, Func<KeyValuePair<TKey, TValue>, bool> predicate, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && predicate != null && !t.Any(predicate), issue.ElseExpected($"none match predicate {predicate}"));

    public static ExpectMany<TKey, TValue> HasNoneWhere<TKey, TValue>(this ExpectMany<TKey, TValue> expect, Func<TKey, TValue, bool> predicate, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && predicate != null && !t.Any(pair => predicate(pair.Key, pair.Value)), issue.ElseExpected($"none match predicate {predicate}"));

    public static ExpectMany<TKey, TValue> HasCountWhere<TKey, TValue>(this ExpectMany<TKey, TValue> expect, int count, Func<KeyValuePair<TKey, TValue>, bool> predicate, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && predicate != null && t.Count(predicate) == count, issue.ElseExpected($"{count} matching predicate {predicate}"));

    public static ExpectMany<TKey, TValue> HasCountWhere<TKey, TValue>(this ExpectMany<TKey, TValue> expect, int count, Func<TKey, TValue, bool> predicate, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && predicate != null && t.Count(pair => predicate(pair.Key, pair.Value)) == count, issue.ElseExpected($"{count} matching predicate {predicate}"));

    //
    // Same (pairs)
    //

    public static ExpectMany<TKey, TValue> HasSame<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IssueMany<TKey, TValue>? issue = null) =>
      expect.HasSame(pairs, pairs.GetComparer(), issue);

    public static ExpectMany<TKey, TValue> HasSame<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && pairs != null && t.OrderBy(pair => pair.Key).SequenceEqual(pairs.OrderBy(pair => pair.Key), comparer.ElseDefault()), issue.ElseExpected($"same items as {TextMany(pairs)}{comparer.ToSuffix()}"));

    public static ExpectMany<TKey, TValue> HasSame<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<TKey> keyComparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && pairs != null && t.OrderBy(pair => pair.Key).SequenceEqual(pairs.OrderBy(pair => pair.Key), pairs.GetComparer(keyComparer)), issue.ElseExpected($"same items as {TextMany(pairs)}{keyComparer.ToKeySuffix()}"));

    public static ExpectMany<TKey, TValue> HasSame<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<TValue> valueComparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && pairs != null && t.OrderBy(pair => pair.Key).SequenceEqual(pairs.OrderBy(pair => pair.Key), pairs.GetComparer(valueComparer)), issue.ElseExpected($"same items as {TextMany(pairs)}{valueComparer.ToValueSuffix()}"));

    public static ExpectMany<TKey, TValue> HasSame<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && pairs != null && t.OrderBy(pair => pair.Key).SequenceEqual(pairs.OrderBy(pair => pair.Key), pairs.GetComparer(keyComparer, valueComparer)), issue.ElseExpected($"same items as {TextMany(pairs)}{keyComparer.ToKeySuffix()}{valueComparer.ToValueSuffix()}"));

    public static ExpectMany<TKey, TValue> HasSame<TKey, TValue>(this ExpectMany<TKey, TValue> expect, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasSame(pairs.AsEnumerable());

    public static ExpectMany<TKey, TValue> HasSame<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasSame(pairs.AsEnumerable(), comparer);

    public static ExpectMany<TKey, TValue> HasSame<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TKey> keyComparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasSame(pairs.AsEnumerable(), keyComparer);

    public static ExpectMany<TKey, TValue> HasSame<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TValue> valueComparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasSame(pairs.AsEnumerable(), valueComparer);

    public static ExpectMany<TKey, TValue> HasSame<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasSame(pairs.AsEnumerable(), keyComparer, valueComparer);

    public static ExpectMany<TKey, TValue> HasSame<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasSame(pairs.AsEnumerable(), issue);

    public static ExpectMany<TKey, TValue> HasSame<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasSame(pairs.AsEnumerable(), comparer, issue);

    public static ExpectMany<TKey, TValue> HasSame<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TKey> keyComparer, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasSame(pairs.AsEnumerable(), keyComparer, issue);

    public static ExpectMany<TKey, TValue> HasSame<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TValue> valueComparer, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasSame(pairs.AsEnumerable(), valueComparer, issue);

    public static ExpectMany<TKey, TValue> HasSame<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasSame(pairs.AsEnumerable(), keyComparer, valueComparer, issue);

    //
    // Same in order (pairs)
    //

    public static ExpectMany<TKey, TValue> HasSameInOrder<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IssueMany<TKey, TValue>? issue = null) =>
      expect.HasSame(pairs, pairs.GetComparer(), issue);

    public static ExpectMany<TKey, TValue> HasSameInOrder<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && pairs != null && t.SequenceEqual(pairs, comparer.ElseDefault()), issue.ElseExpected($"same items in same order as {TextMany(pairs)}{comparer.ToSuffix()}"));

    public static ExpectMany<TKey, TValue> HasSameInOrder<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<TKey> keyComparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && pairs != null && t.SequenceEqual(pairs, pairs.GetComparer(keyComparer)), issue.ElseExpected($"same items in same order as {TextMany(pairs)}{keyComparer.ToKeySuffix()}"));

    public static ExpectMany<TKey, TValue> HasSameInOrder<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<TValue> valueComparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && pairs != null && t.SequenceEqual(pairs, pairs.GetComparer(valueComparer)), issue.ElseExpected($"same items in same order as {TextMany(pairs)}{valueComparer.ToValueSuffix()}"));

    public static ExpectMany<TKey, TValue> HasSameInOrder<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && pairs != null && t.SequenceEqual(pairs, pairs.GetComparer(keyComparer, valueComparer)), issue.ElseExpected($"same items in same order as {TextMany(pairs)}{keyComparer.ToKeySuffix()}{valueComparer.ToValueSuffix()}"));

    public static ExpectMany<TKey, TValue> HasSameInOrder<TKey, TValue>(this ExpectMany<TKey, TValue> expect, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasSameInOrder(pairs.AsEnumerable());

    public static ExpectMany<TKey, TValue> HasSameInOrder<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasSameInOrder(pairs.AsEnumerable(), comparer);

    public static ExpectMany<TKey, TValue> HasSameInOrder<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TKey> keyComparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasSameInOrder(pairs.AsEnumerable(), keyComparer);

    public static ExpectMany<TKey, TValue> HasSameInOrder<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TValue> valueComparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasSameInOrder(pairs.AsEnumerable(), valueComparer);

    public static ExpectMany<TKey, TValue> HasSameInOrder<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasSameInOrder(pairs.AsEnumerable(), keyComparer, valueComparer);

    public static ExpectMany<TKey, TValue> HasSameInOrder<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasSameInOrder(pairs.AsEnumerable(), issue);

    public static ExpectMany<TKey, TValue> HasSameInOrder<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasSameInOrder(pairs.AsEnumerable(), comparer, issue);

    public static ExpectMany<TKey, TValue> HasSameInOrder<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TKey> keyComparer, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasSameInOrder(pairs.AsEnumerable(), keyComparer, issue);

    public static ExpectMany<TKey, TValue> HasSameInOrder<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TValue> valueComparer, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasSameInOrder(pairs.AsEnumerable(), valueComparer, issue);

    public static ExpectMany<TKey, TValue> HasSameInOrder<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasSameInOrder(pairs.AsEnumerable(), keyComparer, valueComparer, issue);

    //
    // Keys
    //

    public static ExpectMany<TKey, TValue> HasKey<TKey, TValue>(this ExpectMany<TKey, TValue> expect, TKey key, IEqualityComparer<TKey> comparer, IssueMany<TKey, TValue>? issue = null) =>
      comparer != null
        ? expect.That(t => t != null && t.Any(pair => comparer.Equals(pair.Key, key)), issue.ElseExpected($"key {Text(key)}", received: t => $"{TextMany(t.Select(pair => pair.Key))}"))
        : expect.That(t => t != null && t switch
        {
          IDictionary<TKey, TValue> dictionary => dictionary.ContainsKey(key),
          IReadOnlyDictionary<TKey, TValue> dictionary => dictionary.ContainsKey(key),
          _ => t.Any(pair => EqualityComparer<TKey>.Default.Equals(pair.Key, key))
        }, issue.ElseExpected($"key {Text(key)}", received: t => $"{TextMany(t.Select(pair => pair.Key))}"));

    public static ExpectMany<TKey, TValue> HasKey<TKey, TValue>(this ExpectMany<TKey, TValue> expect, TKey key, IssueMany<TKey, TValue>? issue = null) =>
      expect.HasKey(key, EqualityComparer<TKey>.Default, issue);

    public static ExpectMany<TKey, TValue> HasKey<TKey, TValue>(this ExpectMany<TKey, TValue> expect, Action<Expect<TKey>> expectKey) =>
      expect.That(t => t != null && expectKey != null && t.All(pair => expectKey.Invoke(pair.Key)));

    public static ExpectMany<TKey, TValue> HasKeys<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<TKey> keys, IEqualityComparer<TKey> comparer, IssueMany<TKey, TValue>? issue = null) =>
      comparer != null
        ? expect.That(t => t != null && keys != null && t.Select(pair => pair.Key).IsSupersetOf(keys, comparer), issue.ElseExpected($"keys {TextMany(keys)}", received: t => $"{TextMany(t.Select(pair => pair.Key))}"))
        : expect.That(t => t != null && keys != null && t switch
        {
          IDictionary<TKey, TValue> dictionary => keys.All(dictionary.ContainsKey),
          IReadOnlyDictionary<TKey, TValue> dictionary => keys.All(dictionary.ContainsKey),
          _ => t.Select(pair => pair.Key).IsSupersetOf(keys)
        }, issue.ElseExpected($"keys {TextMany(keys)}", received: t => $"{TextMany(t.Select(pair => pair.Key))}"));

    public static ExpectMany<TKey, TValue> HasKeys<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<TKey> keys, IssueMany<TKey, TValue>? issue = null) =>
      expect.HasKeys(keys, EqualityComparer<TKey>.Default, issue);

    public static ExpectMany<TKey, TValue> HasKeys<TKey, TValue>(this ExpectMany<TKey, TValue> expect, params TKey[] keys) =>
      expect.HasKeys(keys.AsEnumerable());

    public static ExpectMany<TKey, TValue> HasKeys<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IssueMany<TKey, TValue> issue, params TKey[] keys) =>
      expect.HasKeys(keys.AsEnumerable(), issue);

    public static ExpectMany<TKey, TValue> HasKeys<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TKey> comparer, params TKey[] keys) =>
      expect.HasKeys(keys.AsEnumerable(), comparer);

    public static ExpectMany<TKey, TValue> HasKeys<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TKey> comparer, IssueMany<TKey, TValue> issue, params TKey[] keys) =>
      expect.HasKeys(keys.AsEnumerable(), comparer, issue);

    //
    // Values
    //

    public static ExpectMany<TKey, TValue> HasValue<TKey, TValue>(this ExpectMany<TKey, TValue> expect, TValue value, IEqualityComparer<TValue> comparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && t.Any(pair => (comparer ?? EqualityComparer<TValue>.Default).Equals(pair.Value, value)), issue.ElseExpected($"value {Text(value)}", received: t => $"{TextMany(t.Select(pair => pair.Value))}"));

    public static ExpectMany<TKey, TValue> HasValue<TKey, TValue>(this ExpectMany<TKey, TValue> expect, TValue value, IssueMany<TKey, TValue>? issue = null) =>
      expect.HasValue(value, EqualityComparer<TValue>.Default, issue);

    public static ExpectMany<TKey, TValue> HasValue<TKey, TValue>(this ExpectMany<TKey, TValue> expect, Action<Expect<TValue>> expectValue) =>
      expect.That(t => t != null && expectValue != null && t.All(pair => expectValue.Invoke(pair.Value)));

    public static ExpectMany<TKey, TValue> HasValues<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<TValue> values, IEqualityComparer<TValue> comparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && values != null && t.Select(pair => pair.Value).IsSupersetOf(values, comparer), issue.ElseExpected($"values {TextMany(values)}{comparer.ToValueSuffix()}", received: t => $"{TextMany(t.Select(pair => pair.Value))}"));

    public static ExpectMany<TKey, TValue> HasValues<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<TValue> values, IssueMany<TKey, TValue>? issue = null) =>
      expect.HasValues(values, EqualityComparer<TValue>.Default, issue);

    public static ExpectMany<TKey, TValue> HasValues<TKey, TValue>(this ExpectMany<TKey, TValue> expect, params TValue[] values) =>
      expect.HasValues(values.AsEnumerable());

    public static ExpectMany<TKey, TValue> HasValues<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IssueMany<TKey, TValue> issue, params TValue[] values) =>
      expect.HasValues(values.AsEnumerable(), issue);

    public static ExpectMany<TKey, TValue> HasValues<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TValue> comparer, params TValue[] values) =>
      expect.HasValues(values.AsEnumerable(), comparer);

    public static ExpectMany<TKey, TValue> HasValues<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TValue> comparer, IssueMany<TKey, TValue> issue, params TValue[] values) =>
      expect.HasValues(values.AsEnumerable(), comparer, issue);

    //
    // Counts
    //

    public static ExpectMany<TKey, TValue> HasCount<TKey, TValue>(this ExpectMany<TKey, TValue> expect, int value, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null &&
        Expect(t.GetOrFindCount()).Is(value, count => Expected(count, $"Count == {value}", $"Count == {count} ({TextMany(t)})")));

    public static ExpectMany<TKey, TValue> HasCount<TKey, TValue>(this ExpectMany<TKey, TValue> expect, Action<Expect<int>> expectValue) =>
      expect.That(t => t != null && expectValue.Invoke(t.GetOrFindCount()));

    public static ExpectMany<TKey, TValue> Has1<TKey, TValue>(this ExpectMany<TKey, TValue> expect) => expect.HasCount(1);
    public static ExpectMany<TKey, TValue> Has2<TKey, TValue>(this ExpectMany<TKey, TValue> expect) => expect.HasCount(2);
    public static ExpectMany<TKey, TValue> Has3<TKey, TValue>(this ExpectMany<TKey, TValue> expect) => expect.HasCount(3);
    public static ExpectMany<TKey, TValue> Has4<TKey, TValue>(this ExpectMany<TKey, TValue> expect) => expect.HasCount(4);
    public static ExpectMany<TKey, TValue> Has5<TKey, TValue>(this ExpectMany<TKey, TValue> expect) => expect.HasCount(5);
    public static ExpectMany<TKey, TValue> Has6<TKey, TValue>(this ExpectMany<TKey, TValue> expect) => expect.HasCount(6);
    public static ExpectMany<TKey, TValue> Has7<TKey, TValue>(this ExpectMany<TKey, TValue> expect) => expect.HasCount(7);
    public static ExpectMany<TKey, TValue> Has8<TKey, TValue>(this ExpectMany<TKey, TValue> expect) => expect.HasCount(8);

    public static ExpectMany<TKey, TValue> Has1<TKey, TValue>(this ExpectMany<TKey, TValue> expect, Action<KeyValuePair<TKey, TValue>> expectItem, IssueMany<TKey, TValue>? issue = null) =>
      expect.HasN(1, issue, items => expectItem?.Invoke(items[0]));

    public static ExpectMany<TKey, TValue> Has1<TKey, TValue>(this ExpectMany<TKey, TValue> expect, Action<TKey, TValue> expectItem, IssueMany<TKey, TValue>? issue = null) =>
      expect.HasN(1, issue, items => expectItem?.Invoke(items[0].Key, items[0].Value));

    public static ExpectMany<TKey, TValue> Has2<TKey, TValue>(this ExpectMany<TKey, TValue> expect, Action<KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>> expectItems, IssueMany<TKey, TValue>? issue = null) =>
      expect.HasN(2, issue, items => expectItems?.Invoke(items[0], items[1]));

    public static ExpectMany<TKey, TValue> Has3<TKey, TValue>(this ExpectMany<TKey, TValue> expect, Action<KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>> expectItems, IssueMany<TKey, TValue>? issue = null) =>
      expect.HasN(3, issue, items => expectItems?.Invoke(items[0], items[1], items[2]));

    public static ExpectMany<TKey, TValue> Has4<TKey, TValue>(this ExpectMany<TKey, TValue> expect, Action<KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>> expectItems, IssueMany<TKey, TValue>? issue = null) =>
      expect.HasN(4, issue, items => expectItems?.Invoke(items[0], items[1], items[2], items[3]));

    public static ExpectMany<TKey, TValue> Has5<TKey, TValue>(this ExpectMany<TKey, TValue> expect, Action<KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>> expectItems, IssueMany<TKey, TValue>? issue = null) =>
      expect.HasN(5, issue, items => expectItems?.Invoke(items[0], items[1], items[2], items[3], items[4]));

    public static ExpectMany<TKey, TValue> Has6<TKey, TValue>(this ExpectMany<TKey, TValue> expect, Action<KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>> expectItems, IssueMany<TKey, TValue>? issue = null) =>
      expect.HasN(6, issue, items => expectItems?.Invoke(items[0], items[1], items[2], items[3], items[4], items[5]));

    public static ExpectMany<TKey, TValue> Has7<TKey, TValue>(this ExpectMany<TKey, TValue> expect, Action<KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>> expectItems, IssueMany<TKey, TValue>? issue = null) =>
      expect.HasN(7, issue, items => expectItems?.Invoke(items[0], items[1], items[2], items[3], items[4], items[5], items[6]));

    public static ExpectMany<TKey, TValue> Has8<TKey, TValue>(this ExpectMany<TKey, TValue> expect, Action<KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>> expectItems, IssueMany<TKey, TValue>? issue = null) =>
      expect.HasN(8, issue, items => expectItems?.Invoke(items[0], items[1], items[2], items[3], items[4], items[5], items[6], items[7]));

    static ExpectMany<TKey, TValue> HasN<TKey, TValue>(this ExpectMany<TKey, TValue> expect, int n, IssueMany<TKey, TValue>? issue, Action<IList<KeyValuePair<TKey, TValue>>> expectItems) =>
        expect.That(t =>
        {
          if(!t.TryCountItems(n, out var items))
          {
            return false;
          }

          expectItems(items);

          return true;
        }, issue.ElseExpected($"Count == {n}", t => $"Count == {t.GetOrFindCount()} ({TextMany(t)})"));

    //
    // Details
    //

    public static bool Invoke<T>(this Action<ExpectMany<T>> expect, IEnumerable<T> target)
    {
      expect?.Invoke(ExpectMany.That(target));
      return false;
    }

    public static bool Invoke<TKey, TValue>(this Action<ExpectMany<TKey, TValue>> expect, IEnumerable<KeyValuePair<TKey, TValue>> target)
    {
      expect?.Invoke(ExpectMany.That(target));
      return true;
    }

    public static bool Invoke<TKey, TValue>(this Action<Expect<TKey>, Expect<TValue>> expect, KeyValuePair<TKey, TValue> target)
    {
      expect?.Invoke(Expect.That(target.Key), Expect.That(target.Value));
      return true;
    }
  }
}