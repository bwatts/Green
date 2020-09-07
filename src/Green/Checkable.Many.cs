using System;
using System.Collections.Generic;
using System.Linq;

namespace Green
{
  public static partial class Checkable
  {
    /// <summary>
    /// Checks if the target has an item that equals <paramref name="value"/> using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> Has<T>(this CheckMany<T> check, T value) =>
      check.Has(value, EqualityComparer<T>.Default);

    /// <summary>
    /// Checks if the target has an item that equals <paramref name="value"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> Has<T>(this CheckMany<T> check, T value, IEqualityComparer<T> comparer) =>
      check.That(t => t != null && t.Contains(value, comparer));

    /// <summary>
    /// Checks if the target does not have an item that equals <paramref name="value"/> using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> DoesNotHave<T>(this CheckMany<T> check, T value) =>
      check.DoesNotHave(value, EqualityComparer<T>.Default);

    /// <summary>
    /// Checks if the target does not have an item that equals <paramref name="value"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> DoesNotHave<T>(this CheckMany<T> check, T value, IEqualityComparer<T> comparer) =>
      check.Not(t => t != null && t.Contains(value, comparer));

    //
    // All
    //

    /// <summary>
    /// Checks if the target has all of the items in <paramref name="values"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="values">The values to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> HasAll<T>(this CheckMany<T> check, IEnumerable<T> values, IEqualityComparer<T> comparer) =>
      check.That(t => t != null && values != null && t.IsSupersetOf(values, comparer));

    /// <summary>
    /// Checks if the target has all of the items in <paramref name="values"/> using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="values">The values to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> HasAll<T>(this CheckMany<T> check, IEnumerable<T> values) =>
      check.HasAll(values, EqualityComparer<T>.Default);

    /// <summary>
    /// Checks if the target has all of the items in <paramref name="values"/> using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="values">The values to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> HasAll<T>(this CheckMany<T> check, params T[] values) =>
      check.HasAll(values.AsEnumerable(), EqualityComparer<T>.Default);

    /// <summary>
    /// Checks if the target has all of the items in <paramref name="values"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="values">The values to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> HasAll<T>(this CheckMany<T> check, IEqualityComparer<T> comparer, params T[] values) =>
      check.HasAll(values.AsEnumerable(), comparer);

    /// <summary>
    /// Checks if the target has all items resulting in <see langword="true"/> from <paramref name="checkItem"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkItem">The function that checks each item</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> HasAll<T>(this CheckMany<T> check, Func<Check<T>, bool> checkItem) =>
      check.That(t => t != null && t.All(checkItem.Invoke));

    //
    // Any
    //

    /// <summary>
    /// Checks if the target has any of the items in <paramref name="values"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="values">The values to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> HasAny<T>(this CheckMany<T> check, IEnumerable<T> values, IEqualityComparer<T> comparer) =>
      check.That(t => t != null && values != null && t.IntersectsWith(values, comparer));

    /// <summary>
    /// Checks if the target has any of the items in <paramref name="values"/> using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="values">The values to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> HasAny<T>(this CheckMany<T> check, IEnumerable<T> values) =>
      check.HasAny(values, EqualityComparer<T>.Default);

    /// <summary>
    /// Checks if the target has any of the items in <paramref name="values"/> using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="values">The values to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> HasAny<T>(this CheckMany<T> check, params T[] values) =>
      check.HasAny(values.AsEnumerable());

    /// <summary>
    /// Checks if the target has any of the items in <paramref name="values"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="values">The values to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> HasAny<T>(this CheckMany<T> check, IEqualityComparer<T> comparer, params T[] values) =>
      check.HasAny(values.AsEnumerable(), comparer);

    /// <summary>
    /// Checks if the target has any items resulting in <see langword="true"/> from <paramref name="checkItem"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkItem">The function that checks each item</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> HasAny<T>(this CheckMany<T> check, Func<Check<T>, bool> checkItem) =>
      check.That(t => t != null && t.Any(checkItem.Invoke));

    /// <summary>
    /// Checks if the target has any items
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> HasAny<T>(this CheckMany<T> check) =>
      check.That(t => t != null && t.Any());

    //
    // None
    //

    /// <summary>
    /// Checks if the target has none of the items in <paramref name="values"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="values">The values to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> HasNone<T>(this CheckMany<T> check, IEnumerable<T> values, IEqualityComparer<T> comparer) =>
      check.That(t => t != null && values != null && !t.IntersectsWith(values, comparer));

    /// <summary>
    /// Checks if the target has none of the items in <paramref name="values"/> using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="values">The values to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> HasNone<T>(this CheckMany<T> check, IEnumerable<T> values) =>
      check.HasNone(values, EqualityComparer<T>.Default);

    /// <summary>
    /// Checks if the target has none of the items in <paramref name="values"/> using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="values">The values to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> HasNone<T>(this CheckMany<T> check, params T[] values) =>
      check.HasNone(values.AsEnumerable());

    /// <summary>
    /// Checks if the target has none of the items in <paramref name="values"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="values">The values to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> HasNone<T>(this CheckMany<T> check, IEqualityComparer<T> comparer, params T[] values) =>
      check.HasNone(values.AsEnumerable(), comparer);

    /// <summary>
    /// Checks if the target has no items resulting in <see langword="true"/> from <paramref name="checkItem"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkItem">The function that checks each item</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> HasNone<T>(this CheckMany<T> check, Func<Check<T>, bool> checkItem) =>
      check.That(t => t != null && !t.Any(checkItem.Invoke));

    /// <summary>
    /// Checks if the target has no items
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> HasNone<T>(this CheckMany<T> check) =>
      check.That(t => t != null && !t.Any());

    //
    // Where
    //

    /// <summary>
    /// Checks if the target has all items resulting in <see langword="true"/> from <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="predicate">The function that checks each item</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> HasAllWhere<T>(this CheckMany<T> check, Func<T, bool> predicate) =>
      check.That(t => t != null && predicate != null && t.All(predicate));

    /// <summary>
    /// Checks if the target has any items resulting in <see langword="true"/> from <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="predicate">The function that checks each item</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> HasAnyWhere<T>(this CheckMany<T> check, Func<T, bool> predicate) =>
      check.That(t => t != null && predicate != null && t.Any(predicate));

    /// <summary>
    /// Checks if the target has no items resulting in <see langword="true"/> from <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="predicate">The function that checks each item</param>
    /// <returns>A continuation of <paramref name="check"/> check this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> HasNoneWhere<T>(this CheckMany<T> check, Func<T, bool> predicate) =>
      check.That(t => t != null && predicate != null && !t.Any(predicate));

    /// <summary>
    /// Checks if the target has <paramref name="count"/> items resulting in <see langword="true"/> from <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="count">The number of items that should result in <see langword="true"/> from <paramref name="predicate"/></param>
    /// <param name="predicate">The function that checks each item</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> HasCountWhere<T>(this CheckMany<T> check, int count, Func<T, bool> predicate) =>
      check.That(t => t != null && predicate != null && t.Count(predicate) == count);

    //
    // Same
    //

    /// <summary>
    /// Checks if the target has the same items as <paramref name="items"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="items">The items to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> HasSame<T>(this CheckMany<T> check, IEnumerable<T> items, IEqualityComparer<T> comparer) =>
      check.That(t => t != null && items != null && t.OrderBy(item => item).SequenceEqual(items.OrderBy(item => item), comparer));

    /// <summary>
    /// Checks if the target has the same items as <paramref name="items"/> using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="items">The items to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> HasSame<T>(this CheckMany<T> check, IEnumerable<T> items) =>
      check.HasSame(items, EqualityComparer<T>.Default);

    /// <summary>
    /// Checks if the target has the same items as <paramref name="items"/> using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="items">The items to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> HasSame<T>(this CheckMany<T> check, params T[] items) =>
      check.HasSame(items.AsEnumerable());

    /// <summary>
    /// Checks if the target has the same items as <paramref name="items"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="items">The items to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> HasSame<T>(this CheckMany<T> check, IEqualityComparer<T> comparer, params T[] items) =>
      check.HasSame(items.AsEnumerable(), comparer);

    //
    // Same in order
    //

    /// <summary>
    /// Checks if the target has the same items in the same order as <paramref name="items"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="items">The items to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> HasSameInOrder<T>(this CheckMany<T> check, IEnumerable<T> items, IEqualityComparer<T> comparer) =>
      check.That(t => t != null && items != null && t.SequenceEqual(items, comparer));

    /// <summary>
    /// Checks if the target has the same items in the same order as <paramref name="items"/> using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="items">The items to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> HasSameInOrder<T>(this CheckMany<T> check, IEnumerable<T> items) =>
      check.HasSameInOrder(items, EqualityComparer<T>.Default);

    /// <summary>
    /// Checks if the target has the same items in the same order as <paramref name="items"/> using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="items">The items to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> HasSameInOrder<T>(this CheckMany<T> check, params T[] items) =>
      check.HasSameInOrder(items.AsEnumerable());

    /// <summary>
    /// Checks if the target has the same items in the same order as <paramref name="items"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="items">The items to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> HasSameInOrder<T>(this CheckMany<T> check, IEqualityComparer<T> comparer, params T[] items) =>
      check.HasSameInOrder(items.AsEnumerable(), comparer);

    //
    // Counts
    //

    /// <summary>
    /// Checks if the target's count equals <paramref name="value"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The count to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> HasCount<T>(this CheckMany<T> check, int value) =>
      check.That(t => t != null && t.GetOrFindCount() == value);

    /// <summary>
    /// Checks if the target's count results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the count value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> HasCount<T>(this CheckMany<T> check, Func<Check<int>, bool> checkValue) =>
      check.That(t => t != null && checkValue.Invoke(t.GetOrFindCount()));

    /// <summary>
    /// Checks if the target's count equals 1
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> Has1<T>(this CheckMany<T> check) =>
      check.HasCount(1);

    /// <summary>
    /// Checks if the target's count equals 2
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> Has2<T>(this CheckMany<T> check) =>
      check.HasCount(2);

    /// <summary>
    /// Checks if the target's count equals 3
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> Has3<T>(this CheckMany<T> check) =>
      check.HasCount(3);

    /// <summary>
    /// Checks if the target's count equals 4
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> Has4<T>(this CheckMany<T> check) =>
      check.HasCount(4);

    /// <summary>
    /// Checks if the target's count equals 5
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> Has5<T>(this CheckMany<T> check) =>
      check.HasCount(5);

    /// <summary>
    /// Checks if the target's count equals 6
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> Has6<T>(this CheckMany<T> check) =>
      check.HasCount(6);

    /// <summary>
    /// Checks if the target's count equals 7
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> Has7<T>(this CheckMany<T> check) =>
      check.HasCount(7);

    /// <summary>
    /// Checks if the target's count equals 8
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> Has8<T>(this CheckMany<T> check) =>
      check.HasCount(8);

    /// <summary>
    /// Checks if the target's count equals 1 and if the item results in <see langword="true"/> from <paramref name="checkItem"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkItem">The function that checks the item</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> Has1<T>(this CheckMany<T> check, Func<T, bool> checkItem) =>
      check.That(t => t.TryCountItems(1, out var items) && (checkItem == null || checkItem(items[0])));

    /// <summary>
    /// Checks if the target's count equals 2 and if the items result in <see langword="true"/> from <paramref name="checkItems"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkItems">The function that checks each item</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> Has2<T>(this CheckMany<T> check, Func<T, T, bool> checkItems) =>
      check.That(t => t.TryCountItems(2, out var items) && (checkItems == null || checkItems(items[0], items[1])));

    /// <summary>
    /// Checks if the target's count equals 3 and if the items result in <see langword="true"/> from <paramref name="checkItems"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkItems">The function that checks each item</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> Has3<T>(this CheckMany<T> check, Func<T, T, T, bool> checkItems) =>
      check.That(t => t.TryCountItems(3, out var items) && (checkItems == null || checkItems(items[0], items[1], items[2])));

    /// <summary>
    /// Checks if the target's count equals 4 and if the items result in <see langword="true"/> from <paramref name="checkItems"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkItems">The function that checks each item</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> Has4<T>(this CheckMany<T> check, Func<T, T, T, T, bool> checkItems) =>
      check.That(t => t.TryCountItems(4, out var items) && (checkItems == null || checkItems(items[0], items[1], items[2], items[3])));

    /// <summary>
    /// Checks if the target's count equals 5 and if the items result in <see langword="true"/> from <paramref name="checkItems"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkItems">The function that checks each item</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> Has5<T>(this CheckMany<T> check, Func<T, T, T, T, T, bool> checkItems) =>
      check.That(t => t.TryCountItems(5, out var items) && (checkItems == null || checkItems(items[0], items[1], items[2], items[3], items[4])));

    /// <summary>
    /// Checks if the target's count equals 6 and if the items result in <see langword="true"/> from <paramref name="checkItems"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkItems">The function that checks each item</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> Has6<T>(this CheckMany<T> check, Func<T, T, T, T, T, T, bool> checkItems) =>
      check.That(t => t.TryCountItems(6, out var items) && (checkItems == null || checkItems(items[0], items[1], items[2], items[3], items[4], items[5])));

    /// <summary>
    /// Checks if the target's count equals 7 and if the items result in <see langword="true"/> from <paramref name="checkItems"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkItems">The function that checks each item</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> Has7<T>(this CheckMany<T> check, Func<T, T, T, T, T, T, T, bool> checkItems) =>
      check.That(t => t.TryCountItems(7, out var items) && (checkItems == null || checkItems(items[0], items[1], items[2], items[3], items[4], items[5], items[6])));

    /// <summary>
    /// Checks if the target's count equals 8 and if the items result in <see langword="true"/> from <paramref name="checkItems"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkItems">The function that checks each item</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<T> Has8<T>(this CheckMany<T> check, Func<T, T, T, T, T, T, T, T, bool> checkItems) =>
      check.That(t => t.TryCountItems(8, out var items) && (checkItems == null || checkItems(items[0], items[1], items[2], items[3], items[4], items[5], items[6], items[7])));

    //
    // Has (pairs)
    //

    /// <summary>
    /// Checks if the target has an item that equals <paramref name="pair"/> using <see cref="EqualityComparer{TKey}.Default"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="pair">The pair to compare keys and values</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> Has<TKey, TValue>(this CheckMany<TKey, TValue> check, KeyValuePair<TKey, TValue> pair) =>
      check.Has(pair, pair.GetComparer());

    /// <summary>
    /// Checks if the target has an item that equals <paramref name="pair"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="pair">The pair to compare keys and values</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> Has<TKey, TValue>(this CheckMany<TKey, TValue> check, KeyValuePair<TKey, TValue> pair, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer) =>
      check.That(t => t != null && t.Contains(pair, comparer.ElseDefault()));

    /// <summary>
    /// Checks if the target has an item that equals <paramref name="pair"/> using <paramref name="keyComparer"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="pair"></param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> Has<TKey, TValue>(this CheckMany<TKey, TValue> check, KeyValuePair<TKey, TValue> pair, IEqualityComparer<TKey> keyComparer) =>
      check.That(t => t != null && t.Contains(pair, pair.GetComparer(keyComparer)));

    /// <summary>
    /// Checks if the target has an item that equals <paramref name="pair"/> using <see cref="EqualityComparer{TKey}.Default"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="pair"></param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> Has<TKey, TValue>(this CheckMany<TKey, TValue> check, KeyValuePair<TKey, TValue> pair, IEqualityComparer<TValue> valueComparer) =>
      check.That(t => t != null && t.Contains(pair, pair.GetComparer(valueComparer)));

    /// <summary>
    /// Checks if the target has an item that equals <paramref name="pair"/> using <paramref name="keyComparer"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="pair"></param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> Has<TKey, TValue>(this CheckMany<TKey, TValue> check, KeyValuePair<TKey, TValue> pair, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer) =>
      check.That(t => t != null && t.Contains(pair, pair.GetComparer(keyComparer, valueComparer)));

    /// <summary>
    /// Checks if the target has a pair that equals <paramref name="key"/> and <paramref name="value"/> using <see cref="EqualityComparer{TKey}.Default"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="key">The key to compare</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> Has<TKey, TValue>(this CheckMany<TKey, TValue> check, TKey key, TValue value) =>
      check.Has(new KeyValuePair<TKey, TValue>(key, value));

    /// <summary>
    /// Checks if the target has a pair that equals <paramref name="key"/> and <paramref name="value"/> using <paramref name="keyComparer"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="key">The key to compare</param>
    /// <param name="value">The value to compare</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> Has<TKey, TValue>(this CheckMany<TKey, TValue> check, TKey key, TValue value, IEqualityComparer<TKey> keyComparer) =>
      check.Has(new KeyValuePair<TKey, TValue>(key, value), keyComparer);

    /// <summary>
    /// Checks if the target has a pair that equals <paramref name="key"/> and <paramref name="value"/> using <see cref="EqualityComparer{TKey}.Default"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="key">The key to compare</param>
    /// <param name="value">The value to compare</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> Has<TKey, TValue>(this CheckMany<TKey, TValue> check, TKey key, TValue value, IEqualityComparer<TValue> valueComparer) =>
      check.Has(new KeyValuePair<TKey, TValue>(key, value), valueComparer);

    /// <summary>
    /// Checks if the target has a pair that equals <paramref name="key"/> and <paramref name="value"/> using <paramref name="keyComparer"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="key">The key to compare</param>
    /// <param name="value">The value to compare</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> Has<TKey, TValue>(this CheckMany<TKey, TValue> check, TKey key, TValue value, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer) =>
      check.Has(new KeyValuePair<TKey, TValue>(key, value), keyComparer, valueComparer);

    //
    // All (pairs)
    //

    /// <summary>
    /// Checks if the target has all of the items in <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasAll<TKey, TValue>(this CheckMany<TKey, TValue> check, IEnumerable<KeyValuePair<TKey, TValue>> pairs) =>
      check.HasAll(pairs, pairs.GetComparer());

    /// <summary>
    /// Checks if the target has all of the items in <paramref name="pairs"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasAll<TKey, TValue>(this CheckMany<TKey, TValue> check, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer) =>
      check.That(t => t != null && pairs != null && t.IsSupersetOf(pairs, comparer.ElseDefault()));

    /// <summary>
    /// Checks if the target has all of the items in <paramref name="pairs"/> using <paramref name="keyComparer"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasAll<TKey, TValue>(this CheckMany<TKey, TValue> check, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<TKey> keyComparer) =>
      check.That(t => t != null && pairs != null && t.IsSupersetOf(pairs, pairs.GetComparer(keyComparer)));

    /// <summary>
    /// Checks if the target has all of the items in <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasAll<TKey, TValue>(this CheckMany<TKey, TValue> check, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<TValue> valueComparer) =>
      check.That(t => t != null && pairs != null && t.IsSupersetOf(pairs, pairs.GetComparer(valueComparer)));

    /// <summary>
    /// Checks if the target has all of the items in <paramref name="pairs"/> using <paramref name="keyComparer"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasAll<TKey, TValue>(this CheckMany<TKey, TValue> check, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer) =>
      check.That(t => t != null && pairs != null && t.IsSupersetOf(pairs, pairs.GetComparer(keyComparer, valueComparer)));

    /// <summary>
    /// Checks if the target has all of the items in <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasAll<TKey, TValue>(this CheckMany<TKey, TValue> check, params KeyValuePair<TKey, TValue>[] pairs) =>
      check.HasAll(pairs.AsEnumerable());

    /// <summary>
    /// Checks if the target has all of the items in <paramref name="pairs"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasAll<TKey, TValue>(this CheckMany<TKey, TValue> check, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      check.HasAll(pairs.AsEnumerable(), comparer);

    /// <summary>
    /// Checks if the target has all of the items in <paramref name="pairs"/> using <paramref name="keyComparer"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasAll<TKey, TValue>(this CheckMany<TKey, TValue> check, IEqualityComparer<TKey> keyComparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      check.HasAll(pairs.AsEnumerable(), keyComparer);

    /// <summary>
    /// Checks if the target has all of the items in <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasAll<TKey, TValue>(this CheckMany<TKey, TValue> check, IEqualityComparer<TValue> valueComparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      check.HasAll(pairs.AsEnumerable(), valueComparer);

    /// <summary>
    /// Checks if the target has all of the items in <paramref name="pairs"/> using <paramref name="keyComparer"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasAll<TKey, TValue>(this CheckMany<TKey, TValue> check, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      check.HasAll(pairs.AsEnumerable(), keyComparer, valueComparer);

    /// <summary>
    /// Checks if the target has all items resulting in <see langword="true"/> from <paramref name="checkPair"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkPair">The function that checks each pair</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasAll<TKey, TValue>(this CheckMany<TKey, TValue> check, Func<Check<KeyValuePair<TKey, TValue>>, bool> checkPair) =>
      check.That(t => t != null && t.All(checkPair.Invoke));

    /// <summary>
    /// Checks if the target has all keys resulting in <see langword="true"/> from <paramref name="checkKeys"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkKeys"></param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasAll<TKey, TValue>(this CheckMany<TKey, TValue> check, Func<Check<TKey>, bool> checkKeys) =>
      check.That(t => t != null && t.All(pair => checkKeys.Invoke(pair.Key)));

    /// <summary>
    /// Checks if the target has all values resulting in <see langword="true"/> from <paramref name="checkValues"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValues"></param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasAll<TKey, TValue>(this CheckMany<TKey, TValue> check, Func<Check<TValue>, bool> checkValues) =>
      check.That(t => t != null && t.All(pair => checkValues.Invoke(pair.Value)));

    /// <summary>
    /// Checks if the target has all items resulting in <see langword="true"/> from <paramref name="checkPairs"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkPairs"></param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasAll<TKey, TValue>(this CheckMany<TKey, TValue> check, Func<Check<TKey>, Check<TValue>, bool> checkPairs) =>
      check.That(t => t != null && t.All(pair => checkPairs.Invoke(pair)));

    //
    // Any (pairs)
    //

    /// <summary>
    /// Checks if the target has any items
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasAny<TKey, TValue>(this CheckMany<TKey, TValue> check) =>
      check.That(t => t != null && t.Any());

    /// <summary>
    /// Checks if the target has any of the items in <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasAny<TKey, TValue>(this CheckMany<TKey, TValue> check, IEnumerable<KeyValuePair<TKey, TValue>> pairs) =>
      check.HasAll(pairs, pairs.GetComparer());

    /// <summary>
    /// Checks if the target has any of the items in <paramref name="pairs"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasAny<TKey, TValue>(this CheckMany<TKey, TValue> check, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer) =>
      check.That(t => t != null && pairs != null && t.IntersectsWith(pairs, comparer.ElseDefault()));

    /// <summary>
    /// Checks if the target has any of the items in <paramref name="pairs"/> using <paramref name="keyComparer"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasAny<TKey, TValue>(this CheckMany<TKey, TValue> check, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<TKey> keyComparer) =>
      check.That(t => t != null && pairs != null && t.IntersectsWith(pairs, pairs.GetComparer(keyComparer)));

    /// <summary>
    /// Checks if the target has any of the items in <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasAny<TKey, TValue>(this CheckMany<TKey, TValue> check, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<TValue> valueComparer) =>
      check.That(t => t != null && pairs != null && t.IntersectsWith(pairs, pairs.GetComparer(valueComparer)));

    /// <summary>
    /// Checks if the target has any of the items in <paramref name="pairs"/> using <paramref name="keyComparer"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasAny<TKey, TValue>(this CheckMany<TKey, TValue> check, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer) =>
      check.That(t => t != null && pairs != null && t.IntersectsWith(pairs, pairs.GetComparer(keyComparer, valueComparer)));

    /// <summary>
    /// Checks if the target has any of the items in <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasAny<TKey, TValue>(this CheckMany<TKey, TValue> check, params KeyValuePair<TKey, TValue>[] pairs) =>
      check.HasAny(pairs.AsEnumerable());

    /// <summary>
    /// Checks if the target has any of the items in <paramref name="pairs"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasAny<TKey, TValue>(this CheckMany<TKey, TValue> check, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      check.HasAny(pairs.AsEnumerable(), comparer);

    /// <summary>
    /// Checks if the target has any of the items in <paramref name="pairs"/> using <paramref name="keyComparer"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasAny<TKey, TValue>(this CheckMany<TKey, TValue> check, IEqualityComparer<TKey> keyComparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      check.HasAny(pairs.AsEnumerable(), keyComparer);

    /// <summary>
    /// Checks if the target has any of the items in <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasAny<TKey, TValue>(this CheckMany<TKey, TValue> check, IEqualityComparer<TValue> valueComparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      check.HasAny(pairs.AsEnumerable(), valueComparer);

    /// <summary>
    /// Checks if the target has any of the items in <paramref name="pairs"/> using <paramref name="keyComparer"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasAny<TKey, TValue>(this CheckMany<TKey, TValue> check, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      check.HasAny(pairs.AsEnumerable(), keyComparer, valueComparer);

    /// <summary>
    /// Checks if the target has any items resulting in <see langword="true"/> from <paramref name="checkPair"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkPair">The function that checks each pair</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasAny<TKey, TValue>(this CheckMany<TKey, TValue> check, Func<Check<KeyValuePair<TKey, TValue>>, bool> checkPair) =>
      check.That(t => t != null && t.Any(checkPair.Invoke));

    /// <summary>
    /// Checks if the target has any keys resulting in <see langword="true"/> from <paramref name="checkKey"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkKey"></param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasAny<TKey, TValue>(this CheckMany<TKey, TValue> check, Func<Check<TKey>, bool> checkKey) =>
      check.That(t => t != null && t.Any(pair => checkKey.Invoke(pair.Key)));

    /// <summary>
    /// Checks if the target has any values resulting in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue"></param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasAny<TKey, TValue>(this CheckMany<TKey, TValue> check, Func<Check<TValue>, bool> checkValue) =>
      check.That(t => t != null && t.Any(pair => checkValue.Invoke(pair.Value)));

    /// <summary>
    /// Checks if the target has any items resulting in <see langword="true"/> from <paramref name="checkPair"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkPair">The function that checks each pair</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasAny<TKey, TValue>(this CheckMany<TKey, TValue> check, Func<Check<TKey>, Check<TValue>, bool> checkPair) =>
      check.That(t => t != null && t.Any(pair => checkPair.Invoke(pair)));

    //
    // None (pairs)
    //

    /// <summary>
    /// Checks if the target has no items
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasNone<TKey, TValue>(this CheckMany<TKey, TValue> check) =>
      check.That(t => t != null && !t.Any());

    /// <summary>
    /// Checks if the target has none of the items in <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasNone<TKey, TValue>(this CheckMany<TKey, TValue> check, IEnumerable<KeyValuePair<TKey, TValue>> pairs) =>
      check.HasAll(pairs, pairs.GetComparer());

    /// <summary>
    /// Checks if the target has none of the items in <paramref name="pairs"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasNone<TKey, TValue>(this CheckMany<TKey, TValue> check, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer) =>
      check.That(t => t != null && pairs != null && !t.IntersectsWith(pairs, comparer.ElseDefault()));

    /// <summary>
    /// Checks if the target has none of the items in <paramref name="pairs"/> using <paramref name="keyComparer"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasNone<TKey, TValue>(this CheckMany<TKey, TValue> check, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<TKey> keyComparer) =>
      check.That(t => t != null && pairs != null && !t.IntersectsWith(pairs, pairs.GetComparer(keyComparer)));

    /// <summary>
    /// Checks if the target has none of the items in <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasNone<TKey, TValue>(this CheckMany<TKey, TValue> check, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<TValue> valueComparer) =>
      check.That(t => t != null && pairs != null && !t.IntersectsWith(pairs, pairs.GetComparer(valueComparer)));

    /// <summary>
    /// Checks if the target has none of the items in <paramref name="pairs"/> using <paramref name="keyComparer"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasNone<TKey, TValue>(this CheckMany<TKey, TValue> check, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer) =>
      check.That(t => t != null && pairs != null && !t.IntersectsWith(pairs, pairs.GetComparer(keyComparer, valueComparer)));

    /// <summary>
    /// Checks if the target has none of the items in <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasNone<TKey, TValue>(this CheckMany<TKey, TValue> check, params KeyValuePair<TKey, TValue>[] pairs) =>
      check.HasNone(pairs.AsEnumerable());

    /// <summary>
    /// Checks if the target has none of the items in <paramref name="pairs"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasNone<TKey, TValue>(this CheckMany<TKey, TValue> check, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      check.HasNone(pairs.AsEnumerable(), comparer);

    /// <summary>
    /// Checks if the target has none of the items in <paramref name="pairs"/> using <paramref name="keyComparer"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasNone<TKey, TValue>(this CheckMany<TKey, TValue> check, IEqualityComparer<TKey> keyComparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      check.HasNone(pairs.AsEnumerable(), keyComparer);

    /// <summary>
    /// Checks if the target has none of the items in <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasNone<TKey, TValue>(this CheckMany<TKey, TValue> check, IEqualityComparer<TValue> valueComparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      check.HasNone(pairs.AsEnumerable(), valueComparer);

    /// <summary>
    /// Checks if the target has none of the items in <paramref name="pairs"/> using <paramref name="keyComparer"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasNone<TKey, TValue>(this CheckMany<TKey, TValue> check, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      check.HasNone(pairs.AsEnumerable(), keyComparer, valueComparer);

    /// <summary>
    /// Checks if the target has no items resulting in <see langword="true"/> from <paramref name="checkPair"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkPair">The function that checks each pair</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasNone<TKey, TValue>(this CheckMany<TKey, TValue> check, Func<Check<KeyValuePair<TKey, TValue>>, bool> checkPair) =>
      check.That(t => t != null && t.Any(checkPair.Invoke));

    /// <summary>
    /// Checks if the target has no items resulting in <see langword="true"/> from <paramref name="checkKey"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkKey"></param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasNone<TKey, TValue>(this CheckMany<TKey, TValue> check, Func<Check<TKey>, bool> checkKey) =>
      check.That(t => t != null && !t.Any(pair => checkKey.Invoke(pair.Key)));

    /// <summary>
    /// Checks if the target has no values resulting in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue"></param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasNone<TKey, TValue>(this CheckMany<TKey, TValue> check, Func<Check<TValue>, bool> checkValue) =>
      check.That(t => t != null && !t.Any(pair => checkValue.Invoke(pair.Value)));

    /// <summary>
    /// Checks if the target has no items resulting in <see langword="true"/> from <paramref name="checkPair"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkPair">The function that checks each pair</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasNone<TKey, TValue>(this CheckMany<TKey, TValue> check, Func<Check<TKey>, Check<TValue>, bool> checkPair) =>
      check.That(t => t != null && !t.Any(pair => checkPair.Invoke(pair)));

    //
    // Where (pairs)
    //

    /// <summary>
    /// Checks if the target has all pairs resulting in <see langword="true"/> from <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="predicate">The function that checks each pair</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasAllWhere<TKey, TValue>(this CheckMany<TKey, TValue> check, Func<KeyValuePair<TKey, TValue>, bool> predicate) =>
      check.That(t => t != null && predicate != null && t.All(predicate));

    /// <summary>
    /// Checks if the target has all pairs resulting in <see langword="true"/> from <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="predicate">The function that checks each pair</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasAllWhere<TKey, TValue>(this CheckMany<TKey, TValue> check, Func<TKey, TValue, bool> predicate) =>
      check.That(t => t != null && predicate != null && t.All(pair => predicate(pair.Key, pair.Value)));

    /// <summary>
    /// Checks if the target has any pairs resulting in <see langword="true"/> from <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="predicate">The function that checks each pair</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasAnyWhere<TKey, TValue>(this CheckMany<TKey, TValue> check, Func<KeyValuePair<TKey, TValue>, bool> predicate) =>
      check.That(t => t != null && predicate != null && t.Any(predicate));

    /// <summary>
    /// Checks if the target has any pairs resulting in <see langword="true"/> from <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="predicate">The function that checks each pair</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasAnyWhere<TKey, TValue>(this CheckMany<TKey, TValue> check, Func<TKey, TValue, bool> predicate) =>
      check.That(t => t != null && predicate != null && t.Any(pair => predicate(pair.Key, pair.Value)));

    /// <summary>
    /// Checks if the target has no pairs resulting in <see langword="true"/> from <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="predicate">The function that checks each pair</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasNoneWhere<TKey, TValue>(this CheckMany<TKey, TValue> check, Func<KeyValuePair<TKey, TValue>, bool> predicate) =>
      check.That(t => t != null && predicate != null && !t.Any(predicate));

    /// <summary>
    /// Checks if the target has no pairs resulting in <see langword="true"/> from <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="predicate">The function that checks each pair</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasNoneWhere<TKey, TValue>(this CheckMany<TKey, TValue> check, Func<TKey, TValue, bool> predicate) =>
      check.That(t => t != null && predicate != null && !t.Any(pair => predicate(pair.Key, pair.Value)));

    /// <summary>
    /// Checks if the target has <paramref name="count"/> pairs resulting in <see langword="true"/> from <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="count">The number of items that should result in <see langword="true"/> from <paramref name="predicate"/></param>
    /// <param name="predicate">The function that checks each pair</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasCountWhere<TKey, TValue>(this CheckMany<TKey, TValue> check, int count, Func<KeyValuePair<TKey, TValue>, bool> predicate) =>
      check.That(t => t != null && predicate != null && t.Count(predicate) == count);

    /// <summary>
    /// Checks if the target has <paramref name="count"/> pairs resulting in <see langword="true"/> from <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="count">The number of items that should result in <see langword="true"/> from <paramref name="predicate"/></param>
    /// <param name="predicate">The function that checks each pair</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasCountWhere<TKey, TValue>(this CheckMany<TKey, TValue> check, int count, Func<TKey, TValue, bool> predicate) =>
      check.That(t => t != null && predicate != null && t.Count(pair => predicate(pair.Key, pair.Value)) == count);

    //
    // Same (pairs)
    //

    /// <summary>
    /// Checks if the target has the same pairs as <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasSame<TKey, TValue>(this CheckMany<TKey, TValue> check, IEnumerable<KeyValuePair<TKey, TValue>> pairs) =>
      check.HasSame(pairs, pairs.GetComparer());

    /// <summary>
    /// Checks if the target has the same pairs as <paramref name="pairs"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasSame<TKey, TValue>(this CheckMany<TKey, TValue> check, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer) =>
      check.That(t => t != null && pairs != null && t.OrderBy(pair => pair.Key).SequenceEqual(pairs.OrderBy(pair => pair.Key), comparer.ElseDefault()));

    /// <summary>
    /// Checks if the target has the same pairs as <paramref name="pairs"/> using <paramref name="keyComparer"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasSame<TKey, TValue>(this CheckMany<TKey, TValue> check, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<TKey> keyComparer) =>
      check.That(t => t != null && pairs != null && t.OrderBy(pair => pair.Key).SequenceEqual(pairs.OrderBy(pair => pair.Key), pairs.GetComparer(keyComparer)));

    /// <summary>
    /// Checks if the target has the same pairs as <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasSame<TKey, TValue>(this CheckMany<TKey, TValue> check, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<TValue> valueComparer) =>
      check.That(t => t != null && pairs != null && t.OrderBy(pair => pair.Key).SequenceEqual(pairs.OrderBy(pair => pair.Key), pairs.GetComparer(valueComparer)));

    /// <summary>
    /// Checks if the target has the same pairs as <paramref name="pairs"/> using <paramref name="keyComparer"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasSame<TKey, TValue>(this CheckMany<TKey, TValue> check, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer) =>
      check.That(t => t != null && pairs != null && t.OrderBy(pair => pair.Key).SequenceEqual(pairs.OrderBy(pair => pair.Key), pairs.GetComparer(keyComparer, valueComparer)));

    /// <summary>
    /// Checks if the target has the same pairs as <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasSame<TKey, TValue>(this CheckMany<TKey, TValue> check, params KeyValuePair<TKey, TValue>[] pairs) =>
      check.HasSame(pairs.AsEnumerable());

    /// <summary>
    /// Checks if the target has the same pairs as <paramref name="pairs"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasSame<TKey, TValue>(this CheckMany<TKey, TValue> check, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      check.HasSame(pairs.AsEnumerable(), comparer);

    /// <summary>
    /// Checks if the target has the same pairs as <paramref name="pairs"/> using <paramref name="keyComparer"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasSame<TKey, TValue>(this CheckMany<TKey, TValue> check, IEqualityComparer<TKey> keyComparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      check.HasSame(pairs.AsEnumerable(), keyComparer);

    /// <summary>
    /// Checks if the target has the same pairs as <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasSame<TKey, TValue>(this CheckMany<TKey, TValue> check, IEqualityComparer<TValue> valueComparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      check.HasSame(pairs.AsEnumerable(), valueComparer);

    /// <summary>
    /// Checks if the target has the same pairs as <paramref name="pairs"/> using <paramref name="keyComparer"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasSame<TKey, TValue>(this CheckMany<TKey, TValue> check, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      check.HasSame(pairs.AsEnumerable(), keyComparer, valueComparer);

    //
    // Same in order (pairs)
    //

    /// <summary>
    /// Checks if the target has the same pairs in the same order as <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasSameInOrder<TKey, TValue>(this CheckMany<TKey, TValue> check, IEnumerable<KeyValuePair<TKey, TValue>> pairs) =>
      check.HasSame(pairs, pairs.GetComparer());

    /// <summary>
    /// Checks if the target has the same pairs in the same order as <paramref name="pairs"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasSameInOrder<TKey, TValue>(this CheckMany<TKey, TValue> check, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer) =>
      check.That(t => t != null && pairs != null && t.SequenceEqual(pairs, comparer.ElseDefault()));

    /// <summary>
    /// Checks if the target has the same pairs in the same order as <paramref name="pairs"/> using <paramref name="keyComparer"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasSameInOrder<TKey, TValue>(this CheckMany<TKey, TValue> check, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<TKey> keyComparer) =>
      check.That(t => t != null && pairs != null && t.SequenceEqual(pairs, pairs.GetComparer(keyComparer)));

    /// <summary>
    /// Checks if the target has the same pairs in the same order as <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasSameInOrder<TKey, TValue>(this CheckMany<TKey, TValue> check, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<TValue> valueComparer) =>
      check.That(t => t != null && pairs != null && t.SequenceEqual(pairs, pairs.GetComparer(valueComparer)));

    /// <summary>
    /// Checks if the target has the same pairs in the same order as <paramref name="pairs"/> using <paramref name="keyComparer"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasSameInOrder<TKey, TValue>(this CheckMany<TKey, TValue> check, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer) =>
      check.That(t => t != null && pairs != null && t.SequenceEqual(pairs, pairs.GetComparer(keyComparer, valueComparer)));

    /// <summary>
    /// Checks if the target has the same pairs in the same order as <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasSameInOrder<TKey, TValue>(this CheckMany<TKey, TValue> check, params KeyValuePair<TKey, TValue>[] pairs) =>
      check.HasSameInOrder(pairs.AsEnumerable());

    /// <summary>
    /// Checks if the target has the same pairs in the same order as <paramref name="pairs"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasSameInOrder<TKey, TValue>(this CheckMany<TKey, TValue> check, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      check.HasSameInOrder(pairs.AsEnumerable(), comparer);

    /// <summary>
    /// Checks if the target has the same pairs in the same order as <paramref name="pairs"/> using <paramref name="keyComparer"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasSameInOrder<TKey, TValue>(this CheckMany<TKey, TValue> check, IEqualityComparer<TKey> keyComparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      check.HasSameInOrder(pairs.AsEnumerable(), keyComparer);

    /// <summary>
    /// Checks if the target has the same pairs in the same order as <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasSameInOrder<TKey, TValue>(this CheckMany<TKey, TValue> check, IEqualityComparer<TValue> valueComparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      check.HasSameInOrder(pairs.AsEnumerable(), valueComparer);

    /// <summary>
    /// Checks if the target has the same pairs in the same order as <paramref name="pairs"/> using <paramref name="keyComparer"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasSameInOrder<TKey, TValue>(this CheckMany<TKey, TValue> check, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      check.HasSameInOrder(pairs.AsEnumerable(), keyComparer, valueComparer);

    //
    // Keys
    //

    /// <summary>
    /// Checks if the target has a key that equals <paramref name="key"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="key">The key to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasKey<TKey, TValue>(this CheckMany<TKey, TValue> check, TKey key, IEqualityComparer<TKey> comparer) =>
      comparer != null
        ? check.That(t => t.Any(pair => (comparer ?? EqualityComparer<TKey>.Default).Equals(pair.Key, key)))
        : check.That(t => t != null && t switch
        {
          IDictionary<TKey, TValue> dictionary => dictionary.ContainsKey(key),
          IReadOnlyDictionary<TKey, TValue> dictionary => dictionary.ContainsKey(key),
          _ => t.Any(pair => (comparer ?? EqualityComparer<TKey>.Default).Equals(pair.Key, key))
        });

    /// <summary>
    /// Checks if the target has a key that equals <paramref name="key"/> using <see cref="EqualityComparer{TKey}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="key">The key to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasKey<TKey, TValue>(this CheckMany<TKey, TValue> check, TKey key) =>
      check.HasKey(key, EqualityComparer<TKey>.Default);

    /// <summary>
    /// Checks if the target has a key that results in <see langword="true"/> from <paramref name="checkKey"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkKey">The function that checks each key</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasKey<TKey, TValue>(this CheckMany<TKey, TValue> check, Func<Check<TKey>, bool> checkKey) =>
      check.That(t => t != null && checkKey != null && t.Any(pair => checkKey.Invoke(pair.Key)));

    /// <summary>
    /// Checks if the target has all keys in <paramref name="keys"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="keys">The keys to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasKeys<TKey, TValue>(this CheckMany<TKey, TValue> check, IEnumerable<TKey> keys, IEqualityComparer<TKey> comparer) =>
      comparer != null
        ? check.That(t => t != null && keys != null && t.Select(pair => pair.Key).IsSupersetOf(keys, comparer))
        : check.That(t => t != null && keys != null && t switch
        {
          IDictionary<TKey, TValue> dictionary => keys.All(dictionary.ContainsKey),
          IReadOnlyDictionary<TKey, TValue> dictionary => keys.All(dictionary.ContainsKey),
          _ => t.Select(pair => pair.Key).IsSupersetOf(keys, comparer)
        });

    /// <summary>
    /// Checks if the target has all keys in <paramref name="keys"/> using <see cref="EqualityComparer{TKey}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="keys">The keys to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasKeys<TKey, TValue>(this CheckMany<TKey, TValue> check, IEnumerable<TKey> keys) =>
      check.HasKeys(keys, EqualityComparer<TKey>.Default);

    /// <summary>
    /// Checks if the target has all keys in <paramref name="keys"/> using <see cref="EqualityComparer{TKey}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="keys">The keys to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasKeys<TKey, TValue>(this CheckMany<TKey, TValue> check, params TKey[] keys) =>
      check.HasKeys(keys.AsEnumerable());

    /// <summary>
    /// Checks if the target has all keys in <paramref name="keys"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="keys">The keys to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasKeys<TKey, TValue>(this CheckMany<TKey, TValue> check, IEqualityComparer<TKey> comparer, params TKey[] keys) =>
      check.HasKeys(keys.AsEnumerable(), comparer);

    //
    // Values
    //

    /// <summary>
    /// Checks if the target has a value that equals <paramref name="value"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasValue<TKey, TValue>(this CheckMany<TKey, TValue> check, TValue value, IEqualityComparer<TValue> comparer) =>
      check.That(t => t != null && t.Any(pair => (comparer ?? EqualityComparer<TValue>.Default).Equals(pair.Value, value)));

    /// <summary>
    /// Checks if the target has a value that equals <paramref name="value"/> using <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasValue<TKey, TValue>(this CheckMany<TKey, TValue> check, TValue value) =>
      check.HasValue(value, EqualityComparer<TValue>.Default);

    /// <summary>
    /// Checks if the target has a value that results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks each value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasValue<TKey, TValue>(this CheckMany<TKey, TValue> check, Func<Check<TValue>, bool> checkValue) =>
      check.That(t => t != null && checkValue != null && t.Any(pair => checkValue.Invoke(pair.Value)));

    /// <summary>
    /// Checks if the target has all values in <paramref name="values"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="values">The values to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasValues<TKey, TValue>(this CheckMany<TKey, TValue> check, IEnumerable<TValue> values, IEqualityComparer<TValue> comparer) =>
      check.That(t => t != null && values != null && t.Select(pair => pair.Value).IsSupersetOf(values, comparer));

    /// <summary>
    /// Checks if the target has all values in <paramref name="values"/> using <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="values">The values to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasValues<TKey, TValue>(this CheckMany<TKey, TValue> check, IEnumerable<TValue> values) =>
      check.HasValues(values, EqualityComparer<TValue>.Default);

    /// <summary>
    /// Checks if the target has all values in <paramref name="values"/> using <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="values">The values to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasValues<TKey, TValue>(this CheckMany<TKey, TValue> check, params TValue[] values) =>
      check.HasValues(values.AsEnumerable());

    /// <summary>
    /// Checks if the target has all values in <paramref name="values"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="values">The values to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasValues<TKey, TValue>(this CheckMany<TKey, TValue> check, IEqualityComparer<TValue> comparer, params TValue[] values) =>
      check.HasValues(values.AsEnumerable(), comparer);

    //
    // Counts (pairs)
    //

    /// <summary>
    /// Checks if the target's count equals <paramref name="value"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value"></param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasCount<TKey, TValue>(this CheckMany<TKey, TValue> check, int value) =>
      check.That(t => t != null && t.GetOrFindCount() == value);

    /// <summary>
    /// Checks if the target's count results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue"></param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> HasCount<TKey, TValue>(this CheckMany<TKey, TValue> check, Func<Check<int>, bool> checkValue) =>
      check.That(t => t != null && checkValue.Invoke(t.GetOrFindCount()));

    /// <summary>
    /// Checks if the target's count equals 1
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> Has1<TKey, TValue>(this CheckMany<TKey, TValue> check) =>
      check.HasCount(1);

    /// <summary>
    /// Checks if the target's count equals 2
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> Has2<TKey, TValue>(this CheckMany<TKey, TValue> check) =>
      check.HasCount(2);

    /// <summary>
    /// Checks if the target's count equals 3
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> Has3<TKey, TValue>(this CheckMany<TKey, TValue> check) =>
      check.HasCount(3);

    /// <summary>
    /// Checks if the target's count equals 4
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> Has4<TKey, TValue>(this CheckMany<TKey, TValue> check) =>
      check.HasCount(4);

    /// <summary>
    /// Checks if the target's count equals 5
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> Has5<TKey, TValue>(this CheckMany<TKey, TValue> check) =>
      check.HasCount(5);

    /// <summary>
    /// Checks if the target's count equals 6
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> Has6<TKey, TValue>(this CheckMany<TKey, TValue> check) =>
      check.HasCount(6);

    /// <summary>
    /// Checks if the target's count equals 7
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> Has7<TKey, TValue>(this CheckMany<TKey, TValue> check) =>
      check.HasCount(7);

    /// <summary>
    /// Checks if the target's count equals 8
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> Has8<TKey, TValue>(this CheckMany<TKey, TValue> check) =>
      check.HasCount(8);

    /// <summary>
    /// Checks if the target's count equals 1 and if the pair results in <see langword="true"/> from <paramref name="checkPair"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkPair">The function that checks each item</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> Has1<TKey, TValue>(this CheckMany<TKey, TValue> check, Func<KeyValuePair<TKey, TValue>, bool> checkPair) =>
      check.That(t => TryCountItems(t, 1, out var items) && (checkPair == null || checkPair(items[0])));

    /// <summary>
    /// Checks if the target's count equals 2 and if the pairs result in <see langword="true"/> from <paramref name="checkPairs"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkPairs">The function that checks each item</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> Has2<TKey, TValue>(this CheckMany<TKey, TValue> check, Func<KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, bool> checkPairs) =>
      check.That(t => TryCountItems(t, 2, out var items) && (checkPairs == null || checkPairs(items[0], items[1])));

    /// <summary>
    /// Checks if the target's count equals 3 and if the pairs result in <see langword="true"/> from <paramref name="checkPairs"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkPairs">The function that checks each item</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> Has3<TKey, TValue>(this CheckMany<TKey, TValue> check, Func<KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, bool> checkPairs) =>
      check.That(t => TryCountItems(t, 3, out var items) && (checkPairs == null || checkPairs(items[0], items[1], items[2])));

    /// <summary>
    /// Checks if the target's count equals 4 and if the pairs result in <see langword="true"/> from <paramref name="checkPairs"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkPairs">The function that checks each item</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> Has4<TKey, TValue>(this CheckMany<TKey, TValue> check, Func<KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, bool> checkPairs) =>
      check.That(t => TryCountItems(t, 4, out var items) && (checkPairs == null || checkPairs(items[0], items[1], items[2], items[3])));

    /// <summary>
    /// Checks if the target's count equals 5 and if the pairs result in <see langword="true"/> from <paramref name="checkPairs"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkPairs">The function that checks each item</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> Has5<TKey, TValue>(this CheckMany<TKey, TValue> check, Func<KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, bool> checkPairs) =>
      check.That(t => TryCountItems(t, 5, out var items) && (checkPairs == null || checkPairs(items[0], items[1], items[2], items[3], items[4])));

    /// <summary>
    /// Checks if the target's count equals 6 and if the pairs result in <see langword="true"/> from <paramref name="checkPairs"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkPairs">The function that checks each item</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> Has6<TKey, TValue>(this CheckMany<TKey, TValue> check, Func<KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, bool> checkPairs) =>
      check.That(t => TryCountItems(t, 6, out var items) && (checkPairs == null || checkPairs(items[0], items[1], items[2], items[3], items[4], items[5])));

    /// <summary>
    /// Checks if the target's count equals 7 and if the pairs result in <see langword="true"/> from <paramref name="checkPairs"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkPairs">The function that checks each item</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> Has7<TKey, TValue>(this CheckMany<TKey, TValue> check, Func<KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, bool> checkPairs) =>
      check.That(t => TryCountItems(t, 7, out var items) && (checkPairs == null || checkPairs(items[0], items[1], items[2], items[3], items[4], items[5], items[6])));

    /// <summary>
    /// Checks if the target's count equals 8 and if the pairs result in <see langword="true"/> from <paramref name="checkPairs"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkPairs">The function that checks each item</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static CheckMany<TKey, TValue> Has8<TKey, TValue>(this CheckMany<TKey, TValue> check, Func<KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, bool> checkPairs) =>
      check.That(t => TryCountItems(t, 8, out var items) && (checkPairs == null || checkPairs(items[0], items[1], items[2], items[3], items[4], items[5], items[6], items[7])));

    //
    // Checked arguments
    //

    /// <summary>
    /// Calls the specified function with a <see cref="CheckMany{T}"/> referencing <paramref name="target"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="checkPairs">The function to invoke with a checked argument</param>
    /// <param name="target">The value of the checked argument</param>
    /// <returns>The result of calling <paramref name="checkPairs"/> with a checked argument</returns>
    public static bool Invoke<T>(this Func<CheckMany<T>, bool> checkPairs, IEnumerable<T> target) =>
      checkPairs != null && checkPairs(CheckMany.That(target));

    /// <summary>
    /// Calls the specified function with a <see cref="CheckMany{TKey, TValue}"/> referencing <paramref name="target"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="checkPairs">The function to invoke with a checked argument</param>
    /// <param name="target">The value of the checked argument</param>
    /// <returns>The result of calling <paramref name="checkPairs"/> with a checked argument</returns>
    public static bool Invoke<TKey, TValue>(this Func<CheckMany<TKey, TValue>, bool> checkPairs, IEnumerable<KeyValuePair<TKey, TValue>> target) =>
      checkPairs != null && checkPairs(CheckMany.That(target));

    /// <summary>
    /// Calls the specified function with a <see cref="Check{TKey}"/> referencing <paramref name="target"/>.Key and
    /// a <see cref="Check{TValue}"/> referencing <paramref name="target"/>.Value
    /// </summary>
    /// <typeparam name="TKey">The type of key in the pair</typeparam>
    /// <typeparam name="TValue">The type of value in the pair</typeparam>
    /// <param name="checkPair">The function to invoke with checked arguments</param>
    /// <param name="target">The pair whose key and value are checked argument</param>
    /// <returns>The result of calling <paramref name="checkPair"/> with checked arguments</returns>
    public static bool Invoke<TKey, TValue>(this Func<Check<TKey>, Check<TValue>, bool> checkPair, KeyValuePair<TKey, TValue> target) =>
      checkPair != null && checkPair(Check.That(target.Key), Check.That(target.Value));

    //
    // Details
    //

    internal static bool IsSupersetOf<T>(this IEnumerable<T> target, IEnumerable<T> values, IEqualityComparer<T>? comparer = null) =>
      !values.Except(target, comparer).Any();

    internal static bool IntersectsWith<T>(this IEnumerable<T> target, IEnumerable<T> values, IEqualityComparer<T>? comparer = null) =>
      target.Intersect(values, comparer).Any();

    internal static int GetOrFindCount<T>(this IEnumerable<T> target) =>
      target switch
      {
        ICollection<T> collection => collection.Count,
        IReadOnlyCollection<T> collection => collection.Count,
        _ => target.Count()
      };

    internal static bool TryCountItems<T>(this IEnumerable<T> target, int count, out IList<T> items)
    {
      items = target as IList<T> ?? (target ?? Enumerable.Empty<T>()).ToArray();

      return items.Count == count;
    }
  }
}