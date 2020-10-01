using System;
using System.Collections.Generic;
using System.Linq;
using static Green.Local;

namespace Green
{
  public static partial class Expectable
  {
    //
    // Has
    //

    /// <summary>
    /// Expects the target has an item that equals <paramref name="value"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> Has<T>(this ExpectMany<T> expect, T value, IEqualityComparer<T> comparer, IssueMany<T>? issue = null) =>
      expect.That(t => t != null && t.Contains(value, comparer), issue.Operator(value, comparer));

    /// <summary>
    /// Expects the target has an item that equals <paramref name="value"/> using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> Has<T>(this ExpectMany<T> expect, T value, IssueMany<T>? issue = null) =>
      expect.Has(value, EqualityComparer<T>.Default, issue);

    /// <summary>
    /// Expects the target does not have an item that equals <paramref name="value"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> DoesNotHave<T>(this ExpectMany<T> expect, T value, IEqualityComparer<T> comparer, IssueMany<T>? issue = null) =>
      expect.That(t => t == null || !t.Contains(value, comparer), issue.Operator(value, comparer));

    /// <summary>
    /// Expects the target does not have an item that equals <paramref name="value"/> using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> DoesNotHave<T>(this ExpectMany<T> expect, T value, IssueMany<T>? issue = null) =>
      expect.DoesNotHave(value, EqualityComparer<T>.Default, issue);

    //
    // All
    //

    /// <summary>
    /// Expects the target has all of the items in <paramref name="values"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="values">The values to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> HasAll<T>(this ExpectMany<T> expect, IEnumerable<T> values, IEqualityComparer<T> comparer, IssueMany<T>? issue = null) =>
      expect.That(t => t != null && values != null && t.IsSupersetOf(values, comparer), issue.Operator(values, comparer));

    /// <summary>
    /// Expects the target has all of the items in <paramref name="values"/> using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="values">The values to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> HasAll<T>(this ExpectMany<T> expect, IEnumerable<T> values, IssueMany<T>? issue = null) =>
      expect.HasAll(values, EqualityComparer<T>.Default, issue);

    /// <summary>
    /// Expects the target has all of the items in <paramref name="values"/> using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="values">The values to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> HasAll<T>(this ExpectMany<T> expect, params T[] values) =>
      expect.HasAll(values.AsEnumerable());

    /// <summary>
    /// Expects the target has all of the items in <paramref name="values"/> using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="values">The values to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> HasAll<T>(this ExpectMany<T> expect, IssueMany<T> issue, params T[] values) =>
      expect.HasAll(values.AsEnumerable(), issue);

    /// <summary>
    /// Expects the target has all of the items in <paramref name="values"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="values">The values to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> HasAll<T>(this ExpectMany<T> expect, IEqualityComparer<T> comparer, params T[] values) =>
      expect.HasAll(values.AsEnumerable(), comparer);

    /// <summary>
    /// Expects the target has all of the items in <paramref name="values"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="values">The values to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> HasAll<T>(this ExpectMany<T> expect, IEqualityComparer<T> comparer, IssueMany<T> issue, params T[] values) =>
      expect.HasAll(values.AsEnumerable(), comparer, issue);

    /// <summary>
    /// Expects the target's items to all meet <paramref name="expectItem"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectItem">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> HasAll<T>(this ExpectMany<T> expect, Action<Expect<T>> expectItem, IssueMany<T>? issue = null) =>
      expect.That(t => t != null && t.All(expectItem.Invoke), issue.Operator(expectItem));

    //
    // Any
    //

    /// <summary>
    /// Expects the target has any of the items in <paramref name="values"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="values">The values to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> HasAny<T>(this ExpectMany<T> expect, IEnumerable<T> values, IEqualityComparer<T> comparer, IssueMany<T>? issue = null) =>
      expect.That(t => t != null && values != null && t.IntersectsWith(values, comparer), issue.Operator(values, comparer));

    /// <summary>
    /// Expects the target has any of the items in <paramref name="values"/> using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="values">The values to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> HasAny<T>(this ExpectMany<T> expect, IEnumerable<T> values, IssueMany<T>? issue = null) =>
      expect.HasAny(values, EqualityComparer<T>.Default, issue);

    /// <summary>
    /// Expects the target has any of the items in <paramref name="values"/> using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="values">The values to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> HasAny<T>(this ExpectMany<T> expect, params T[] values) =>
      expect.HasAny(values.AsEnumerable());

    /// <summary>
    /// Expects the target has any of the items in <paramref name="values"/> using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="values">The values to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> HasAny<T>(this ExpectMany<T> expect, IssueMany<T> issue, params T[] values) =>
      expect.HasAny(values.AsEnumerable(), issue);

    /// <summary>
    /// Expects the target has any of the items in <paramref name="values"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="values">The values to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> HasAny<T>(this ExpectMany<T> expect, IEqualityComparer<T> comparer, params T[] values) =>
      expect.HasAny(values.AsEnumerable(), comparer);

    /// <summary>
    /// Expects the target has any of the items in <paramref name="values"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="values">The values to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> HasAny<T>(this ExpectMany<T> expect, IEqualityComparer<T> comparer, IssueMany<T> issue, params T[] values) =>
      expect.HasAny(values.AsEnumerable(), comparer, issue);

    /// <summary>
    /// Expects the target has any items
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> HasAny<T>(this ExpectMany<T> expect, IssueMany<T>? issue) =>
      expect.That(t => t != null && t.Any(), issue.Operator());

    //
    // None
    //

    /// <summary>
    /// Expects the target has none of the items in <paramref name="values"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="values">The values to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> HasNone<T>(this ExpectMany<T> expect, IEnumerable<T> values, IEqualityComparer<T> comparer, IssueMany<T>? issue = null) =>
      expect.That(t => t != null && values != null && !t.IntersectsWith(values, comparer), issue.Operator(values, comparer));

    /// <summary>
    /// Expects the target has none of the items in <paramref name="values"/> using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="values">The values to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> HasNone<T>(this ExpectMany<T> expect, IEnumerable<T> values, IssueMany<T>? issue = null) =>
      expect.HasNone(values, EqualityComparer<T>.Default, issue);

    /// <summary>
    /// Expects the target has none of the items in <paramref name="values"/> using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="values">The values to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> HasNone<T>(this ExpectMany<T> expect, params T[] values) =>
      expect.HasNone(values.AsEnumerable());

    /// <summary>
    /// Expects the target has none of the items in <paramref name="values"/> using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="values">The values to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> HasNone<T>(this ExpectMany<T> expect, IssueMany<T> issue, params T[] values) =>
      expect.HasNone(values.AsEnumerable(), issue);

    /// <summary>
    /// Expects the target has none of the items in <paramref name="values"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="values">The values to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> HasNone<T>(this ExpectMany<T> expect, IEqualityComparer<T> comparer, params T[] values) =>
      expect.HasNone(values.AsEnumerable(), comparer);

    /// <summary>
    /// Expects the target has none of the items in <paramref name="values"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="values">The values to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> HasNone<T>(this ExpectMany<T> expect, IEqualityComparer<T> comparer, IssueMany<T> issue, params T[] values) =>
      expect.HasNone(values.AsEnumerable(), comparer, issue);

    /// <summary>
    /// Expects the target has no items
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> HasNone<T>(this ExpectMany<T> expect, IssueMany<T>? issue = null) =>
      expect.That(t => t != null && !t.Any(), issue.Operator());

    //
    // Where
    //

    /// <summary>
    /// Expects the target has all items resulting in <see langword="true"/> from <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="predicate">The function that checks each item</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> HasAllWhere<T>(this ExpectMany<T> expect, Func<T, bool> predicate, IssueMany<T>? issue = null) =>
      expect.That(t => t != null && predicate != null && t.All(predicate), issue.Operator(predicate));

    /// <summary>
    /// Expects the target has any items resulting in <see langword="true"/> from <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="predicate">The function that checks each item</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> HasAnyWhere<T>(this ExpectMany<T> expect, Func<T, bool> predicate, IssueMany<T>? issue = null) =>
      expect.That(t => t != null && predicate != null && t.Any(predicate), issue.Operator(predicate));

    /// <summary>
    /// Expects the target has no items resulting in <see langword="true"/> from <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="predicate">The function that checks each item</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> HasNoneWhere<T>(this ExpectMany<T> expect, Func<T, bool> predicate, IssueMany<T>? issue = null) =>
      expect.That(t => t != null && predicate != null && !t.Any(predicate), issue.Operator(predicate));

    /// <summary>
    /// Expects the target has <paramref name="count"/> items resulting in <see langword="true"/> from <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="predicate">The function that checks each item</param>
    /// <param name="count">The number of items that should result in <see langword="true"/> from <paramref name="predicate"/></param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> HasCountWhere<T>(this ExpectMany<T> expect, int count, Func<T, bool> predicate, IssueMany<T>? issue = null) =>
      expect.That(t => t != null && predicate != null && t.Count(predicate) == count, issue.Operator(count, predicate));

    //
    // Same
    //

    /// <summary>
    /// Expects the target has the same items as <paramref name="items"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="items">The items to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> HasSame<T>(this ExpectMany<T> expect, IEnumerable<T> items, IEqualityComparer<T> comparer, IssueMany<T>? issue = null) =>
      expect.That(t => t != null && items != null && t.OrderBy(item => item).SequenceEqual(items.OrderBy(item => item), comparer), issue.Operator(items, comparer));

    /// <summary>
    /// Expects the target has the same items as <paramref name="items"/> using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="items">The items to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> HasSame<T>(this ExpectMany<T> expect, IEnumerable<T> items, IssueMany<T>? issue = null) =>
      expect.HasSame(items, EqualityComparer<T>.Default, issue);

    /// <summary>
    /// Expects the target has the same items as <paramref name="items"/> using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="items">The items to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> HasSame<T>(this ExpectMany<T> expect, params T[] items) =>
      expect.HasSame(items.AsEnumerable());

    /// <summary>
    /// Expects the target has the same items as <paramref name="items"/> using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="items">The items to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> HasSame<T>(this ExpectMany<T> expect, IssueMany<T> issue, params T[] items) =>
      expect.HasSame(items.AsEnumerable(), issue);

    /// <summary>
    /// Expects the target has the same items as <paramref name="items"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="items">The items to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> HasSame<T>(this ExpectMany<T> expect, IEqualityComparer<T> comparer, params T[] items) =>
      expect.HasSame(items.AsEnumerable(), comparer);

    /// <summary>
    /// Expects the target has the same items as <paramref name="items"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="items">The items to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> HasSame<T>(this ExpectMany<T> expect, IEqualityComparer<T> comparer, IssueMany<T> issue, params T[] items) =>
      expect.HasSame(items.AsEnumerable(), comparer, issue);

    //
    // Same in order
    //

    /// <summary>
    /// Expects the target has the same items in the same order as <paramref name="items"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="items">The items to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> HasSameInOrder<T>(this ExpectMany<T> expect, IEnumerable<T> items, IEqualityComparer<T> comparer, IssueMany<T>? issue = null) =>
      expect.That(t => t != null && items != null && t.SequenceEqual(items, comparer), issue.Operator(items, comparer));

    /// <summary>
    /// Expects the target has the same items in the same order as <paramref name="items"/> using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="items">The items to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> HasSameInOrder<T>(this ExpectMany<T> expect, IEnumerable<T> items, IssueMany<T>? issue = null) =>
      expect.HasSameInOrder(items, EqualityComparer<T>.Default, issue);

    /// <summary>
    /// Expects the target has the same items in the same order as <paramref name="items"/> using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="items">The items to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    public static ExpectMany<T> HasSameInOrder<T>(this ExpectMany<T> expect, params T[] items) =>
      expect.HasSameInOrder(items.AsEnumerable());

    /// <summary>
    /// Expects the target has the same items in the same order as <paramref name="items"/> using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="items">The items to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> HasSameInOrder<T>(this ExpectMany<T> expect, IssueMany<T> issue, params T[] items) =>
      expect.HasSameInOrder(items.AsEnumerable(), issue);

    /// <summary>
    /// Expects the target has the same items in the same order as <paramref name="items"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="items">The items to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> HasSameInOrder<T>(this ExpectMany<T> expect, IEqualityComparer<T> comparer, params T[] items) =>
      expect.HasSameInOrder(items.AsEnumerable(), comparer);

    /// <summary>
    /// Expects the target has the same items in the same order as <paramref name="items"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="items">The items to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> HasSameInOrder<T>(this ExpectMany<T> expect, IEqualityComparer<T> comparer, IssueMany<T> issue, params T[] items) =>
      expect.HasSameInOrder(items.AsEnumerable(), comparer, issue);

    //
    // Counts
    //

    /// <summary>
    /// Expects the target's count is <paramref name="value"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The count to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> HasCount<T>(this ExpectMany<T> expect, int value, IssueMany<T>? issue = null) =>
      expect.That(t => t != null && t.GetOrFindCount() == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's count to meet <paramref name="expectValue"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> HasCount<T>(this ExpectMany<T> expect, Action<Expect<int>> expectValue, IssueMany<T>? issue = null) =>
      expect.That(t => t != null && expectValue.Invoke(t.GetOrFindCount()), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's count is 1
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> Has1<T>(this ExpectMany<T> expect, IssueMany<T>? issue = null) =>
      expect.HasCount(1, issue);

    /// <summary>
    /// Expects the target's count is 2
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> Has2<T>(this ExpectMany<T> expect, IssueMany<T>? issue = null) =>
      expect.HasCount(2, issue);

    /// <summary>
    /// Expects the target's count is 3
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> Has3<T>(this ExpectMany<T> expect, IssueMany<T>? issue = null) =>
      expect.HasCount(3, issue);

    /// <summary>
    /// Expects the target's count is 4
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> Has4<T>(this ExpectMany<T> expect, IssueMany<T>? issue = null) =>
      expect.HasCount(4, issue);

    /// <summary>
    /// Expects the target's count is 5
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> Has5<T>(this ExpectMany<T> expect, IssueMany<T>? issue = null) =>
      expect.HasCount(5, issue);

    /// <summary>
    /// Expects the target's count is 6
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> Has6<T>(this ExpectMany<T> expect, IssueMany<T>? issue = null) =>
      expect.HasCount(6, issue);

    /// <summary>
    /// Expects the target's count is 7
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> Has7<T>(this ExpectMany<T> expect, IssueMany<T>? issue = null) =>
      expect.HasCount(7, issue);

    /// <summary>
    /// Expects the target's count is 8
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> Has8<T>(this ExpectMany<T> expect, IssueMany<T>? issue = null) =>
      expect.HasCount(8, issue);

    /// <summary>
    /// Expects the target's count is 1 and item to meet <paramref name="expectItem"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectItem">The function the item is expected to meet</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> Has1<T>(this ExpectMany<T> expect, Action<T> expectItem, IssueMany<T>? issue = null) =>
      expect.HasN(1, issue, items => expectItem?.Invoke(items[0]));

    /// <summary>
    /// Expects the target's count is 2 and items to meet <paramref name="expectItems"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectItems">The function the items are expected to meet</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> Has2<T>(this ExpectMany<T> expect, Action<T, T> expectItems, IssueMany<T>? issue = null) =>
      expect.HasN(2, issue, items => expectItems?.Invoke(items[0], items[1]));

    /// <summary>
    /// Expects the target's count is 3 and items to meet <paramref name="expectItems"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectItems">The function the items are expected to meet</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> Has3<T>(this ExpectMany<T> expect, Action<T, T, T> expectItems, IssueMany<T>? issue = null) =>
      expect.HasN(3, issue, items => expectItems?.Invoke(items[0], items[1], items[2]));

    /// <summary>
    /// Expects the target's count is 4 and items to meet <paramref name="expectItems"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectItems">The function the items are expected to meet</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> Has4<T>(this ExpectMany<T> expect, Action<T, T, T, T> expectItems, IssueMany<T>? issue = null) =>
      expect.HasN(4, issue, items => expectItems?.Invoke(items[0], items[1], items[2], items[3]));

    /// <summary>
    /// Expects the target's count is 5 and items to meet <paramref name="expectItems"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectItems">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> Has5<T>(this ExpectMany<T> expect, Action<T, T, T, T, T> expectItems, IssueMany<T>? issue = null) =>
      expect.HasN(5, issue, items => expectItems?.Invoke(items[0], items[1], items[2], items[3], items[4]));

    /// <summary>
    /// Expects the target's count is 6 and items to meet <paramref name="expectItems"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectItems">The function the items are expected to meet</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> Has6<T>(this ExpectMany<T> expect, Action<T, T, T, T, T, T> expectItems, IssueMany<T>? issue = null) =>
      expect.HasN(6, issue, items => expectItems?.Invoke(items[0], items[1], items[2], items[3], items[4], items[5]));

    /// <summary>
    /// Expects the target's count is 7 and items to meet <paramref name="expectItems"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectItems">The function the items are expected to meet</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<T> Has7<T>(this ExpectMany<T> expect, Action<T, T, T, T, T, T, T> expectItems, IssueMany<T>? issue = null) =>
      expect.HasN(7, issue, items => expectItems?.Invoke(items[0], items[1], items[2], items[3], items[4], items[5], items[6]));

    /// <summary>
    /// Expects the target's count is 8 and items to meet <paramref name="expectItems"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectItems">The function the items are expected to meet</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
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
        }, issue.Operator(n, expectItems));

    //
    // Has (pairs)
    //

    /// <summary>
    /// Expects the target has an item that equals <paramref name="pair"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="pair">The pair to compare keys and values</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> Has<TKey, TValue>(this ExpectMany<TKey, TValue> expect, KeyValuePair<TKey, TValue> pair, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && t.Contains(pair, comparer.ElseDefault()), issue.Operator(pair, comparer));

    /// <summary>
    /// Expects the target has an item that equals <paramref name="pair"/> using <paramref name="keyComparer"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="pair">The pair to compare keys and values</param>
    /// <param name="keyComparer">The object that performs value comparisons</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> Has<TKey, TValue>(this ExpectMany<TKey, TValue> expect, KeyValuePair<TKey, TValue> pair, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && t.Contains(pair, PairComparer.For(keyComparer, valueComparer)), issue.Operator(pair, keyComparer));

    /// <summary>
    /// Expects the target has an item that equals <paramref name="pair"/> using <paramref name="keyComparer"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="pair">The pair to compare keys and values</param>
    /// <param name="keyComparer">The object that performs value comparisons</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> Has<TKey, TValue>(this ExpectMany<TKey, TValue> expect, KeyValuePair<TKey, TValue> pair, IEqualityComparer<TKey> keyComparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && t.Contains(pair, PairComparer.For<TKey, TValue>(keyComparer)), issue.Operator(pair, keyComparer));

    /// <summary>
    /// Expects the target has an item that equals <paramref name="pair"/> using <see cref="EqualityComparer{TKey}.Default"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="pair">The pair to compare keys and values</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> Has<TKey, TValue>(this ExpectMany<TKey, TValue> expect, KeyValuePair<TKey, TValue> pair, IEqualityComparer<TValue> valueComparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && t.Contains(pair, PairComparer.For<TKey, TValue>(valueComparer)), issue.Operator(pair, valueComparer));

    /// <summary>
    /// Expects the target has an item that equals <paramref name="pair"/> using <see cref="EqualityComparer{TKey}.Default"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="pair">The pair to compare keys and values</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> Has<TKey, TValue>(this ExpectMany<TKey, TValue> expect, KeyValuePair<TKey, TValue> pair, IssueMany<TKey, TValue>? issue = null) =>
      expect.Has(pair, PairComparer.For<TKey, TValue>(), issue);

    //
    // Has (key/value)
    //

    /// <summary>
    /// Expects the target has a pair that equals <paramref name="key"/> and <paramref name="value"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="key">The key to compare</param>
    /// <param name="value">The value to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> Has<TKey, TValue>(this ExpectMany<TKey, TValue> expect, TKey key, TValue value, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && t.Contains(KeyValuePair.Create(key, value), comparer.ElseDefault()), issue.Operator(key, value, comparer));

    /// <summary>
    /// Expects the target has a pair that equals <paramref name="key"/> and <paramref name="value"/> using <paramref name="keyComparer"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="key">The key to compare</param>
    /// <param name="value">The value to compare</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> Has<TKey, TValue>(this ExpectMany<TKey, TValue> expect, TKey key, TValue value, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && t.Contains(KeyValuePair.Create(key, value), PairComparer.For(keyComparer, valueComparer)), issue.Operator(key, value, keyComparer, valueComparer));

    /// <summary>
    /// Expects the target has a pair that equals <paramref name="key"/> and <paramref name="value"/> using <paramref name="keyComparer"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="key">The key to compare</param>
    /// <param name="value">The value to compare</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> Has<TKey, TValue>(this ExpectMany<TKey, TValue> expect, TKey key, TValue value, IEqualityComparer<TKey> keyComparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && t.Contains(KeyValuePair.Create(key, value), PairComparer.For<TKey, TValue>(keyComparer)), issue.Operator(key, value, keyComparer));

    /// <summary>
    /// Expects the target has a pair that equals <paramref name="key"/> and <paramref name="value"/> using <see cref="EqualityComparer{TKey}.Default"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="key">The key to compare</param>
    /// <param name="value">The value to compare</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> Has<TKey, TValue>(this ExpectMany<TKey, TValue> expect, TKey key, TValue value, IEqualityComparer<TValue> valueComparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && t.Contains(KeyValuePair.Create(key, value), PairComparer.For<TKey, TValue>(valueComparer)), issue.Operator(key, value, valueComparer));

    /// <summary>
    /// Expects the target has a pair that equals <paramref name="key"/> and <paramref name="value"/> using <see cref="EqualityComparer{TKey}.Default"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="key">The key to compare</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> Has<TKey, TValue>(this ExpectMany<TKey, TValue> expect, TKey key, TValue value, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && t.Contains(KeyValuePair.Create(key, value), PairComparer.For<TKey, TValue>()), issue.Operator(key, value));

    //
    // All (pairs)
    //

    /// <summary>
    /// Expects the target has all of the items in <paramref name="pairs"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasAll<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && pairs != null && t.IsSupersetOf(pairs, comparer.ElseDefault()), issue.Operator(pairs, comparer));

    /// <summary>
    /// Expects the target has all of the items in <paramref name="pairs"/> using <paramref name="keyComparer"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasAll<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && pairs != null && t.IsSupersetOf(pairs, PairComparer.For(keyComparer, valueComparer)), issue.Operator(pairs, keyComparer, valueComparer));

    /// <summary>
    /// Expects the target has all of the items in <paramref name="pairs"/> using <paramref name="keyComparer"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasAll<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<TKey> keyComparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && pairs != null && t.IsSupersetOf(pairs, PairComparer.For<TKey, TValue>(keyComparer)), issue.Operator(pairs, keyComparer));

    /// <summary>
    /// Expects the target has all of the items in <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasAll<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<TValue> valueComparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && pairs != null && t.IsSupersetOf(pairs, PairComparer.For<TKey, TValue>(valueComparer)), issue.Operator(pairs, valueComparer));

    /// <summary>
    /// Expects the target has all of the items in <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasAll<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IssueMany<TKey, TValue>? issue = null) =>
      expect.HasAll(pairs, PairComparer.For<TKey, TValue>(), issue);

    /// <summary>
    /// Expects the target's keys to all meet <paramref name="expectKey"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectKey">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasAll<TKey, TValue>(this ExpectMany<TKey, TValue> expect, Action<Expect<TKey>> expectKey, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && t.All(pair => expectKey.Invoke(pair.Key)), issue.Operator(expectKey));

    /// <summary>
    /// Expects the target's values to all meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasAll<TKey, TValue>(this ExpectMany<TKey, TValue> expect, Action<Expect<TValue>> expectValue, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && t.All(pair => expectValue.Invoke(pair.Value)), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's pairs to all meet <paramref name="expectPair"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectPair">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasAll<TKey, TValue>(this ExpectMany<TKey, TValue> expect, Action<Expect<TKey>, Expect<TValue>> expectPair, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && t.All(pair => expectPair.Invoke(pair)), issue.Operator(expectPair));

    //
    // All (pairs params)
    //

    /// <summary>
    /// Expects the target has all of the items in <paramref name="pairs"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasAll<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasAll(pairs.AsEnumerable(), comparer);

    /// <summary>
    /// Expects the target has all of the items in <paramref name="pairs"/> using <paramref name="keyComparer"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasAll<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasAll(pairs.AsEnumerable(), keyComparer, valueComparer);

    /// <summary>
    /// Expects the target has all of the items in <paramref name="pairs"/> using <paramref name="keyComparer"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasAll<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TKey> keyComparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasAll(pairs.AsEnumerable(), keyComparer);

    /// <summary>
    /// Expects the target has all of the items in <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasAll<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TValue> valueComparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasAll(pairs.AsEnumerable(), valueComparer);

    /// <summary>
    /// Expects the target has all of the items in <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasAll<TKey, TValue>(this ExpectMany<TKey, TValue> expect, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasAll(pairs.AsEnumerable());

    /// <summary>
    /// Expects the target has all of the items in <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasAll<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasAll(pairs.AsEnumerable(), comparer, issue);

    /// <summary>
    /// Expects the target has all of the items in <paramref name="pairs"/> using <paramref name="keyComparer"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasAll<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasAll(pairs.AsEnumerable(), keyComparer, valueComparer, issue);

    /// <summary>
    /// Expects the target has all of the items in <paramref name="pairs"/> using <paramref name="keyComparer"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasAll<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TKey> keyComparer, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasAll(pairs.AsEnumerable(), keyComparer, issue);

    /// <summary>
    /// Expects the target has all of the items in <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasAll<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TValue> valueComparer, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasAll(pairs.AsEnumerable(), valueComparer, issue);

    /// <summary>
    /// Expects the target has all of the items in <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasAll<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasAll(pairs.AsEnumerable(), issue);

    //
    // Any (pairs)
    //

    /// <summary>
    /// Expects the target has any of the items in <paramref name="pairs"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasAny<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && pairs != null && t.IntersectsWith(pairs, comparer.ElseDefault()), issue.Operator(pairs, comparer));

    /// <summary>
    /// Expects the target has any of the items in <paramref name="pairs"/> using <paramref name="keyComparer"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasAny<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && pairs != null && t.IntersectsWith(pairs, PairComparer.For(keyComparer, valueComparer)), issue.Operator(pairs, keyComparer, valueComparer));

    /// <summary>
    /// Expects the target has any of the items in <paramref name="pairs"/> using <paramref name="keyComparer"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasAny<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<TKey> keyComparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && pairs != null && t.IntersectsWith(pairs, PairComparer.For<TKey, TValue>(keyComparer)), issue.Operator(pairs, keyComparer));

    /// <summary>
    /// Expects the target has any of the items in <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasAny<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<TValue> valueComparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && pairs != null && t.IntersectsWith(pairs, PairComparer.For<TKey, TValue>(valueComparer)), issue.Operator(pairs, valueComparer));

    /// <summary>
    /// Expects the target has any of the items in <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasAny<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IssueMany<TKey, TValue>? issue = null) =>
      expect.HasAny(pairs, PairComparer.For<TKey, TValue>(), issue);

    //
    // Any (pairs params)
    //

    /// <summary>
    /// Expects the target has any of the items in <paramref name="pairs"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasAny<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasAny(pairs.AsEnumerable(), comparer);

    /// <summary>
    /// Expects the target has any of the items in <paramref name="pairs"/> using <paramref name="keyComparer"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasAny<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasAny(pairs.AsEnumerable(), keyComparer, valueComparer);

    /// <summary>
    /// Expects the target has any of the items in <paramref name="pairs"/> using <paramref name="keyComparer"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasAny<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TKey> keyComparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasAny(pairs.AsEnumerable(), keyComparer);

    /// <summary>
    /// Expects the target has any of the items in <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasAny<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TValue> valueComparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasAny(pairs.AsEnumerable(), valueComparer);

    /// <summary>
    /// Expects the target has any of the items in <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasAny<TKey, TValue>(this ExpectMany<TKey, TValue> expect, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasAny(pairs.AsEnumerable());

    /// <summary>
    /// Expects the target has any of the items in <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasAny<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasAny(pairs.AsEnumerable(), comparer, issue);

    /// <summary>
    /// Expects the target has any of the items in <paramref name="pairs"/> using <paramref name="keyComparer"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasAny<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasAny(pairs.AsEnumerable(), keyComparer, valueComparer, issue);

    /// <summary>
    /// Expects the target has any of the items in <paramref name="pairs"/> using <paramref name="keyComparer"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasAny<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TKey> keyComparer, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasAny(pairs.AsEnumerable(), keyComparer, issue);

    /// <summary>
    /// Expects the target has any of the items in <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasAny<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TValue> valueComparer, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasAny(pairs.AsEnumerable(), valueComparer, issue);

    /// <summary>
    /// Expects the target has any of the items in <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasAny<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasAny(pairs.AsEnumerable(), issue);

    //
    // None (pairs)
    //

    /// <summary>
    /// Expects the target has none of the items in <paramref name="pairs"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasNone<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && pairs != null && !t.IntersectsWith(pairs, comparer.ElseDefault()), issue.Operator(pairs, comparer));

    /// <summary>
    /// Expects the target has none of the items in <paramref name="pairs"/> using <paramref name="keyComparer"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasNone<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && pairs != null && !t.IntersectsWith(pairs, PairComparer.For(keyComparer, valueComparer)), issue.Operator(pairs, keyComparer, valueComparer));

    /// <summary>
    /// Expects the target has none of the items in <paramref name="pairs"/> using <paramref name="keyComparer"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasNone<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<TKey> keyComparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && pairs != null && !t.IntersectsWith(pairs, PairComparer.For<TKey, TValue>(keyComparer)), issue.Operator(pairs, keyComparer));

    /// <summary>
    /// Expects the target has none of the items in <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasNone<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<TValue> valueComparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && pairs != null && !t.IntersectsWith(pairs, PairComparer.For<TKey, TValue>(valueComparer)), issue.Operator(pairs, valueComparer));

    /// <summary>
    /// Expects the target has none of the items in <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasNone<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IssueMany<TKey, TValue>? issue = null) =>
      expect.HasNone(pairs, PairComparer.For<TKey, TValue>(), issue);

    //
    // None (pairs params)
    //

    /// <summary>
    /// Expects the target has none of the items in <paramref name="pairs"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasNone<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasNone(pairs.AsEnumerable(), comparer);

    /// <summary>
    /// Expects the target has none of the items in <paramref name="pairs"/> using <paramref name="keyComparer"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasNone<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasNone(pairs.AsEnumerable(), keyComparer, valueComparer);

    /// <summary>
    /// Expects the target has none of the items in <paramref name="pairs"/> using <paramref name="keyComparer"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasNone<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TKey> keyComparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasNone(pairs.AsEnumerable(), keyComparer);

    /// <summary>
    /// Expects the target has none of the items in <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasNone<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TValue> valueComparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasNone(pairs.AsEnumerable(), valueComparer);

    /// <summary>
    /// Expects the target has none of the items in <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasNone<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasNone(pairs.AsEnumerable(), issue);

    /// <summary>
    /// Expects the target has none of the items in <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasNone<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasNone(pairs.AsEnumerable(), comparer, issue);

    /// <summary>
    /// Expects the target has none of the items in <paramref name="pairs"/> using <paramref name="keyComparer"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasNone<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasNone(pairs.AsEnumerable(), keyComparer, valueComparer, issue);

    /// <summary>
    /// Expects the target has none of the items in <paramref name="pairs"/> using <paramref name="keyComparer"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasNone<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TKey> keyComparer, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasNone(pairs.AsEnumerable(), keyComparer, issue);

    /// <summary>
    /// Expects the target has none of the items in <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasNone<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TValue> valueComparer, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasNone(pairs.AsEnumerable(), valueComparer, issue);

    /// <summary>
    /// Expects the target has none of the items in <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasNone<TKey, TValue>(this ExpectMany<TKey, TValue> expect, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasNone(pairs.AsEnumerable());

    //
    // Where (pairs)
    //

    /// <summary>
    /// Expects the target has all pairs resulting in <see langword="true"/> from <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="predicate">The function that checks each item</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasAllWhere<TKey, TValue>(this ExpectMany<TKey, TValue> expect, Func<KeyValuePair<TKey, TValue>, bool> predicate, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && predicate != null && t.All(predicate), issue.Operator(predicate));

    /// <summary>
    /// Expects the target has all pairs resulting in <see langword="true"/> from <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="predicate">The function that checks each item</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasAllWhere<TKey, TValue>(this ExpectMany<TKey, TValue> expect, Func<TKey, TValue, bool> predicate, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && predicate != null && t.All(pair => predicate(pair.Key, pair.Value)), issue.Operator(predicate));

    /// <summary>
    /// Expects the target has any pairs resulting in <see langword="true"/> from <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="predicate">The function that checks each item</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasAnyWhere<TKey, TValue>(this ExpectMany<TKey, TValue> expect, Func<KeyValuePair<TKey, TValue>, bool> predicate, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && predicate != null && t.Any(predicate), issue.Operator(predicate));

    /// <summary>
    /// Expects the target has any pairs resulting in <see langword="true"/> from <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="predicate">The function that checks each item</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasAnyWhere<TKey, TValue>(this ExpectMany<TKey, TValue> expect, Func<TKey, TValue, bool> predicate, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && predicate != null && t.Any(pair => predicate(pair.Key, pair.Value)), issue.Operator(predicate));

    /// <summary>
    /// Expects the target has no pairs resulting in <see langword="true"/> from <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="predicate">The function that checks each item</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasNoneWhere<TKey, TValue>(this ExpectMany<TKey, TValue> expect, Func<KeyValuePair<TKey, TValue>, bool> predicate, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && predicate != null && !t.Any(predicate), issue.Operator(predicate));

    /// <summary>
    /// Expects the target has no pairs resulting in <see langword="true"/> from <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="predicate">The function that checks each item</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasNoneWhere<TKey, TValue>(this ExpectMany<TKey, TValue> expect, Func<TKey, TValue, bool> predicate, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && predicate != null && !t.Any(pair => predicate(pair.Key, pair.Value)), issue.Operator(predicate));

    /// <summary>
    /// Expects the target has <paramref name="count"/> items resulting in <see langword="true"/> from <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="predicate">The function that checks each item</param>
    /// <param name="count">The number of items that should result in <see langword="true"/> from <paramref name="predicate"/></param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasCountWhere<TKey, TValue>(this ExpectMany<TKey, TValue> expect, int count, Func<KeyValuePair<TKey, TValue>, bool> predicate, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && predicate != null && t.Count(predicate) == count, issue.Operator(count, predicate));

    /// <summary>
    /// Expects the target has <paramref name="count"/> items resulting in <see langword="true"/> from <paramref name="predicate"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="predicate">The function that checks each item</param>
    /// <param name="count">The number of items that should result in <see langword="true"/> from <paramref name="predicate"/></param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasCountWhere<TKey, TValue>(this ExpectMany<TKey, TValue> expect, int count, Func<TKey, TValue, bool> predicate, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && predicate != null && t.Count(pair => predicate(pair.Key, pair.Value)) == count, issue.Operator(count, predicate));

    //
    // Same (pairs)
    //

    /// <summary>
    /// Expects the target has the same items as <paramref name="pairs"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasSame<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && pairs != null && t.OrderBy(pair => pair.Key).SequenceEqual(pairs.OrderBy(pair => pair.Key), comparer.ElseDefault()), issue.Operator(pairs, comparer));

    /// <summary>
    /// Expects the target has the same items as <paramref name="pairs"/> using <paramref name="keyComparer"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasSame<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && pairs != null && t.OrderBy(pair => pair.Key).SequenceEqual(pairs.OrderBy(pair => pair.Key), PairComparer.For(keyComparer, valueComparer)), issue.Operator(pairs, keyComparer, valueComparer));

    /// <summary>
    /// Expects the target has the same items as <paramref name="pairs"/> using <paramref name="keyComparer"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasSame<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<TKey> keyComparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && pairs != null && t.OrderBy(pair => pair.Key).SequenceEqual(pairs.OrderBy(pair => pair.Key), PairComparer.For<TKey, TValue>(keyComparer)), issue.Operator(pairs, keyComparer));

    /// <summary>
    /// Expects the target has the same items as <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasSame<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<TValue> valueComparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && pairs != null && t.OrderBy(pair => pair.Key).SequenceEqual(pairs.OrderBy(pair => pair.Key), PairComparer.For<TKey, TValue>(valueComparer)), issue.Operator(pairs, valueComparer));

    /// <summary>
    /// Expects the target has the same items as <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasSame<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IssueMany<TKey, TValue>? issue = null) =>
      expect.HasSame(pairs, PairComparer.For<TKey, TValue>(), issue);

    //
    // Same (pairs params)
    //

    /// <summary>
    /// Expects the target has the same items as <paramref name="pairs"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasSame<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasSame(pairs.AsEnumerable(), comparer);

    /// <summary>
    /// Expects the target has the same items as <paramref name="pairs"/> using <paramref name="keyComparer"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasSame<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasSame(pairs.AsEnumerable(), keyComparer, valueComparer);

    /// <summary>
    /// Expects the target has the same items as <paramref name="pairs"/> using <paramref name="keyComparer"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasSame<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TKey> keyComparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasSame(pairs.AsEnumerable(), keyComparer);

    /// <summary>
    /// Expects the target has the same items as <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasSame<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TValue> valueComparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasSame(pairs.AsEnumerable(), valueComparer);

    /// <summary>
    /// Expects the target has the same items as <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasSame<TKey, TValue>(this ExpectMany<TKey, TValue> expect, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasSame(pairs.AsEnumerable());

    //
    // Same (pairs params)
    //

    /// <summary>
    /// Expects the target has the same items as <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasSame<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasSame(pairs.AsEnumerable(), comparer, issue);

    /// <summary>
    /// Expects the target has the same items as <paramref name="pairs"/> using <paramref name="keyComparer"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasSame<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasSame(pairs.AsEnumerable(), keyComparer, valueComparer, issue);

    /// <summary>
    /// Expects the target has the same items as <paramref name="pairs"/> using <paramref name="keyComparer"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasSame<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TKey> keyComparer, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasSame(pairs.AsEnumerable(), keyComparer, issue);

    /// <summary>
    /// Expects the target has the same items as <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasSame<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TValue> valueComparer, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasSame(pairs.AsEnumerable(), valueComparer, issue);

    /// <summary>
    /// Expects the target has the same items as <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasSame<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasSame(pairs.AsEnumerable(), issue);

    //
    // Same in order (pairs)
    //

    /// <summary>
    /// Expects the target has the same items in the same order as <paramref name="pairs"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasSameInOrder<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && pairs != null && t.SequenceEqual(pairs, comparer.ElseDefault()), issue.Operator(pairs, comparer));

    /// <summary>
    /// Expects the target has the same items in the same order as <paramref name="pairs"/> using <paramref name="keyComparer"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasSameInOrder<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && pairs != null && t.SequenceEqual(pairs, PairComparer.For(keyComparer, valueComparer)), issue.Operator(pairs, keyComparer, valueComparer));

    /// <summary>
    /// Expects the target has the same items in the same order as <paramref name="pairs"/> using <paramref name="keyComparer"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasSameInOrder<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<TKey> keyComparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && pairs != null && t.SequenceEqual(pairs, PairComparer.For<TKey, TValue>(keyComparer)), issue.Operator(pairs, keyComparer));

    /// <summary>
    /// Expects the target has the same items in the same order as <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasSameInOrder<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IEqualityComparer<TValue> valueComparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && pairs != null && t.SequenceEqual(pairs, PairComparer.For<TKey, TValue>(valueComparer)), issue.Operator(pairs, valueComparer));

    /// <summary>
    /// Expects the target has the same items in the same order as <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasSameInOrder<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<KeyValuePair<TKey, TValue>> pairs, IssueMany<TKey, TValue>? issue = null) =>
      expect.HasSame(pairs, PairComparer.For<TKey, TValue>(), issue);

    //
    // Same in order (pairs params)
    //

    /// <summary>
    /// Expects the target has the same items in the same order as <paramref name="pairs"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasSameInOrder<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasSameInOrder(pairs.AsEnumerable(), comparer);

    /// <summary>
    /// Expects the target has the same items in the same order as <paramref name="pairs"/> using <paramref name="keyComparer"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasSameInOrder<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasSameInOrder(pairs.AsEnumerable(), keyComparer, valueComparer);

    /// <summary>
    /// Expects the target has the same items in the same order as <paramref name="pairs"/> using <paramref name="keyComparer"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasSameInOrder<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TKey> keyComparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasSameInOrder(pairs.AsEnumerable(), keyComparer);

    /// <summary>
    /// Expects the target has the same items in the same order as <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasSameInOrder<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TValue> valueComparer, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasSameInOrder(pairs.AsEnumerable(), valueComparer);

    /// <summary>
    /// Expects the target has the same items in the same order as <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasSameInOrder<TKey, TValue>(this ExpectMany<TKey, TValue> expect, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasSameInOrder(pairs.AsEnumerable());

    /// <summary>
    /// Expects the target has the same items in the same order as <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasSameInOrder<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasSameInOrder(pairs.AsEnumerable(), comparer, issue);

    /// <summary>
    /// Expects the target has the same items in the same order as <paramref name="pairs"/> using <paramref name="keyComparer"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasSameInOrder<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TKey> keyComparer, IEqualityComparer<TValue> valueComparer, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasSameInOrder(pairs.AsEnumerable(), keyComparer, valueComparer, issue);

    /// <summary>
    /// Expects the target has the same items in the same order as <paramref name="pairs"/> using <paramref name="keyComparer"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="keyComparer">The object that performs key comparisons</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasSameInOrder<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TKey> keyComparer, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasSameInOrder(pairs.AsEnumerable(), keyComparer, issue);

    /// <summary>
    /// Expects the target has the same items in the same order as <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <paramref name="valueComparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="valueComparer">The object that performs value comparisons</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasSameInOrder<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TValue> valueComparer, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasSameInOrder(pairs.AsEnumerable(), valueComparer, issue);

    /// <summary>
    /// Expects the target has the same items in the same order as <paramref name="pairs"/> using <see cref="EqualityComparer{TKey}.Default"/> and <see cref="EqualityComparer{TValue}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="pairs">The pairs to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasSameInOrder<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IssueMany<TKey, TValue> issue, params KeyValuePair<TKey, TValue>[] pairs) =>
      expect.HasSameInOrder(pairs.AsEnumerable(), issue);

    //
    // Keys
    //

    /// <summary>
    /// Expects the target has a key that equals <paramref name="key"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="key">The key to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasKey<TKey, TValue>(this ExpectMany<TKey, TValue> expect, TKey key, IEqualityComparer<TKey> comparer, IssueMany<TKey, TValue>? issue = null) =>
      comparer != null
        ? expect.That(t => t != null && t.Any(pair => comparer.Equals(pair.Key, key)), issue.Operator(key, comparer))
        : expect.That(t => t != null && t switch
        {
          IDictionary<TKey, TValue> dictionary => dictionary.ContainsKey(key),
          IReadOnlyDictionary<TKey, TValue> dictionary => dictionary.ContainsKey(key),
          _ => t.Any(pair => EqualityComparer<TKey>.Default.Equals(pair.Key, key))
        }, issue.Operator(key, comparer));

    /// <summary>
    /// Expects the target has a key that equals <paramref name="key"/> using <see cref="EqualityComparer{TKey}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="key">The key to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasKey<TKey, TValue>(this ExpectMany<TKey, TValue> expect, TKey key, IssueMany<TKey, TValue>? issue = null) =>
      expect.HasKey(key, EqualityComparer<TKey>.Default, issue);

    /// <summary>
    /// Expects the target's key to meet <paramref name="expectKey"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectKey">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasKey<TKey, TValue>(this ExpectMany<TKey, TValue> expect, Action<Expect<TKey>> expectKey, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && expectKey != null && t.All(pair => expectKey.Invoke(pair.Key)), issue.Operator(expectKey));

    /// <summary>
    /// Expects the target has all keys in <paramref name="keys"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="keys">The keys to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasKeys<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<TKey> keys, IEqualityComparer<TKey> comparer, IssueMany<TKey, TValue>? issue = null) =>
      comparer != null
        ? expect.That(t => t != null && keys != null && t.Select(pair => pair.Key).IsSupersetOf(keys, comparer), issue.Operator(keys, comparer))
        : expect.That(t => t != null && keys != null && t switch
        {
          IDictionary<TKey, TValue> dictionary => keys.All(dictionary.ContainsKey),
          IReadOnlyDictionary<TKey, TValue> dictionary => keys.All(dictionary.ContainsKey),
          _ => t.Select(pair => pair.Key).IsSupersetOf(keys)
        }, issue.Operator(keys, comparer));

    /// <summary>
    /// Expects the target has all keys in <paramref name="keys"/> using <see cref="EqualityComparer{TKey}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="keys">The keys to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasKeys<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<TKey> keys, IssueMany<TKey, TValue>? issue = null) =>
      expect.HasKeys(keys, EqualityComparer<TKey>.Default, issue);

    /// <summary>
    /// Expects the target has all keys in <paramref name="keys"/> using <see cref="EqualityComparer{TKey}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="keys">The keys to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasKeys<TKey, TValue>(this ExpectMany<TKey, TValue> expect, params TKey[] keys) =>
      expect.HasKeys(keys.AsEnumerable());

    /// <summary>
    /// Expects the target has all keys in <paramref name="keys"/> using <see cref="EqualityComparer{TKey}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="keys">The keys to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasKeys<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IssueMany<TKey, TValue> issue, params TKey[] keys) =>
      expect.HasKeys(keys.AsEnumerable(), issue);

    /// <summary>
    /// Expects the target has all keys in <paramref name="keys"/> using <see cref="EqualityComparer{TKey}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="keys">The keys to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasKeys<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TKey> comparer, params TKey[] keys) =>
      expect.HasKeys(keys.AsEnumerable(), comparer);

    /// <summary>
    /// Expects the target has all keys in <paramref name="keys"/> using <see cref="EqualityComparer{TKey}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="keys">The keys to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasKeys<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TKey> comparer, IssueMany<TKey, TValue> issue, params TKey[] keys) =>
      expect.HasKeys(keys.AsEnumerable(), comparer, issue);

    //
    // Values
    //

    /// <summary>
    /// Expects the target has a value that equals <paramref name="value"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasValue<TKey, TValue>(this ExpectMany<TKey, TValue> expect, TValue value, IEqualityComparer<TValue> comparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && t.Any(pair => (comparer ?? EqualityComparer<TValue>.Default).Equals(pair.Value, value)), issue.Operator(value, comparer));

    /// <summary>
    /// Expects the target has a value that equals <paramref name="value"/> using <see cref="EqualityComparer{TKey}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasValue<TKey, TValue>(this ExpectMany<TKey, TValue> expect, TValue value, IssueMany<TKey, TValue>? issue = null) =>
      expect.HasValue(value, EqualityComparer<TValue>.Default, issue);

    /// <summary>
    /// Expects the target has a value to meet <paramref name="expectValue"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasValue<TKey, TValue>(this ExpectMany<TKey, TValue> expect, Action<Expect<TValue>> expectValue, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && expectValue != null && t.All(pair => expectValue.Invoke(pair.Value)), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target has all values in <paramref name="values"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="values">The values to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasValues<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<TValue> values, IEqualityComparer<TValue> comparer, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && values != null && t.Select(pair => pair.Value).IsSupersetOf(values, comparer), issue.Operator(values, comparer));

    /// <summary>
    /// Expects the target has all keys in <paramref name="values"/> using <see cref="EqualityComparer{TKey}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="values">The values to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasValues<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEnumerable<TValue> values, IssueMany<TKey, TValue>? issue = null) =>
      expect.HasValues(values, EqualityComparer<TValue>.Default, issue);

    /// <summary>
    /// Expects the target has all keys in <paramref name="values"/> using <see cref="EqualityComparer{TKey}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="values">The values to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasValues<TKey, TValue>(this ExpectMany<TKey, TValue> expect, params TValue[] values) =>
      expect.HasValues(values.AsEnumerable());

    /// <summary>
    /// Expects the target has all values in <paramref name="values"/> using <see cref="EqualityComparer{TKey}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="values">The values to compare</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasValues<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IssueMany<TKey, TValue> issue, params TValue[] values) =>
      expect.HasValues(values.AsEnumerable(), issue);

    /// <summary>
    /// Expects the target has all keys in <paramref name="values"/> using <see cref="EqualityComparer{TKey}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="values">The values to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasValues<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TValue> comparer, params TValue[] values) =>
      expect.HasValues(values.AsEnumerable(), comparer);

    /// <summary>
    /// Expects the target has all values in <paramref name="values"/> using <see cref="EqualityComparer{TKey}.Default"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="values">The keys to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasValues<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IEqualityComparer<TValue> comparer, IssueMany<TKey, TValue> issue, params TValue[] values) =>
      expect.HasValues(values.AsEnumerable(), comparer, issue);

    //
    // Counts (pairs)
    //

    /// <summary>
    /// Expects the target's count is <paramref name="value"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The count to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasCount<TKey, TValue>(this ExpectMany<TKey, TValue> expect, int value, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && t.GetOrFindCount() == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's count to meet <paramref name="expectValue"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> HasCount<TKey, TValue>(this ExpectMany<TKey, TValue> expect, Action<Expect<int>> expectValue, IssueMany<TKey, TValue>? issue = null) =>
      expect.That(t => t != null && expectValue.Invoke(t.GetOrFindCount()), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's count is 1
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> Has1<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IssueMany<TKey, TValue>? issue = null) =>
      expect.HasCount(1, issue);

    /// <summary>
    /// Expects the target's count is 2
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> Has2<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IssueMany<TKey, TValue>? issue = null) =>
      expect.HasCount(2, issue);

    /// <summary>
    /// Expects the target's count is 3
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> Has3<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IssueMany<TKey, TValue>? issue = null) =>
      expect.HasCount(3, issue);

    /// <summary>
    /// Expects the target's count is 4
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> Has4<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IssueMany<TKey, TValue>? issue = null) =>
      expect.HasCount(4, issue);

    /// <summary>
    /// Expects the target's count is 5
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> Has5<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IssueMany<TKey, TValue>? issue = null) =>
      expect.HasCount(5, issue);

    /// <summary>
    /// Expects the target's count is 6
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> Has6<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IssueMany<TKey, TValue>? issue = null) =>
      expect.HasCount(6, issue);

    /// <summary>
    /// Expects the target's count is 7
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> Has7<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IssueMany<TKey, TValue>? issue = null) =>
      expect.HasCount(7, issue);

    /// <summary>
    /// Expects the target's count is 8
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> Has8<TKey, TValue>(this ExpectMany<TKey, TValue> expect, IssueMany<TKey, TValue>? issue = null) =>
      expect.HasCount(8, issue);

    /// <summary>
    /// Expects the target's count is 1 and pair to meet <paramref name="expectPair"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectPair">The function the pair is expected to meet</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> Has1<TKey, TValue>(this ExpectMany<TKey, TValue> expect, Action<KeyValuePair<TKey, TValue>> expectPair, IssueMany<TKey, TValue>? issue = null) =>
      expect.HasN(1, issue, items => expectPair?.Invoke(items[0]));

    /// <summary>
    /// Expects the target's count is 1 and pair to meet <paramref name="expectPair"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectPair">The function the pair is expected to meet</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> Has1<TKey, TValue>(this ExpectMany<TKey, TValue> expect, Action<TKey, TValue> expectPair, IssueMany<TKey, TValue>? issue = null) =>
      expect.HasN(1, issue, items => expectPair?.Invoke(items[0].Key, items[0].Value));

    /// <summary>
    /// Expects the target's count is 2 and to meet <paramref name="expectItems"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectItems">The function the items are expected to meet</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> Has2<TKey, TValue>(this ExpectMany<TKey, TValue> expect, Action<KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>> expectItems, IssueMany<TKey, TValue>? issue = null) =>
      expect.HasN(2, issue, items => expectItems?.Invoke(items[0], items[1]));

    /// <summary>
    /// Expects the target's count is 3 and to meet <paramref name="expectItems"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectItems">The function the items are expected to meet</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> Has3<TKey, TValue>(this ExpectMany<TKey, TValue> expect, Action<KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>> expectItems, IssueMany<TKey, TValue>? issue = null) =>
      expect.HasN(3, issue, items => expectItems?.Invoke(items[0], items[1], items[2]));

    /// <summary>
    /// Expects the target's count is 4 and to meet <paramref name="expectItems"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectItems">The function the items are expected to meet</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> Has4<TKey, TValue>(this ExpectMany<TKey, TValue> expect, Action<KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>> expectItems, IssueMany<TKey, TValue>? issue = null) =>
      expect.HasN(4, issue, items => expectItems?.Invoke(items[0], items[1], items[2], items[3]));

    /// <summary>
    /// Expects the target's count is 5 and to meet <paramref name="expectItems"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectItems">The function the items are expected to meet</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> Has5<TKey, TValue>(this ExpectMany<TKey, TValue> expect, Action<KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>> expectItems, IssueMany<TKey, TValue>? issue = null) =>
      expect.HasN(5, issue, items => expectItems?.Invoke(items[0], items[1], items[2], items[3], items[4]));

    /// <summary>
    /// Expects the target's count is 6 and to meet <paramref name="expectItems"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectItems">The function the items are expected to meet</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> Has6<TKey, TValue>(this ExpectMany<TKey, TValue> expect, Action<KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>> expectItems, IssueMany<TKey, TValue>? issue = null) =>
      expect.HasN(6, issue, items => expectItems?.Invoke(items[0], items[1], items[2], items[3], items[4], items[5]));

    /// <summary>
    /// Expects the target's count is 7 and to meet <paramref name="expectItems"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectItems">The function the items are expected to meet</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static ExpectMany<TKey, TValue> Has7<TKey, TValue>(this ExpectMany<TKey, TValue> expect, Action<KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>, KeyValuePair<TKey, TValue>> expectItems, IssueMany<TKey, TValue>? issue = null) =>
      expect.HasN(7, issue, items => expectItems?.Invoke(items[0], items[1], items[2], items[3], items[4], items[5], items[6]));

    /// <summary>
    /// Expects the target's count is 8 and to meet <paramref name="expectItems"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectItems">The function the items are expected to meet</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
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
        }, issue.Operator(n, expectItems));

    //
    // Checked arguments
    //

    /// <summary>
    /// Calls the specified action with an <see cref="ExpectMany{T}"/> referencing <paramref name="target"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="expectItems">The function to invoke with an expected argument</param>
    /// <param name="target">The value of the expected argument</param>
    /// <returns><see langword="true"/> to enable use in expressions</returns>
    /// <exception cref="ExpectException">Thrown if <paramref name="expectItems"/> throws for <paramref name="target"/></exception>
    public static bool Invoke<T>(this Action<ExpectMany<T>> expectItems, IEnumerable<T> target)
    {
      expectItems?.Invoke(Expect.Many(target));
      return false;
    }

    /// <summary>
    /// Calls the specified action with an <see cref="ExpectMany{T}"/> referencing <paramref name="target"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="expectPairs">The function to invoke with an expected argument</param>
    /// <param name="target">The value of the expected argument</param>
    /// <returns><see langword="true"/> to enable use in expressions</returns>
    /// <exception cref="ExpectException">Thrown if <paramref name="expectPairs"/> throws for <paramref name="target"/></exception>
    public static bool Invoke<TKey, TValue>(this Action<ExpectMany<TKey, TValue>> expectPairs, IEnumerable<KeyValuePair<TKey, TValue>> target)
    {
      expectPairs?.Invoke(Expect.Many(target));
      return true;
    }

    /// <summary>
    /// Calls the specified action with an <see cref="ExpectMany{TKey, TValue}"/> referencing <paramref name="target"/>
    /// </summary>
    /// <typeparam name="TKey">The type of key in the target pair</typeparam>
    /// <typeparam name="TValue">The type of value in the target pair</typeparam>
    /// <param name="expectPair">The function to invoke with expected arguments</param>
    /// <param name="target">The value of the expected argument</param>
    /// <returns><see langword="true"/> to enable use in expressions</returns>
    /// <exception cref="ExpectException">Thrown if <paramref name="expectPair"/> throws for <paramref name="target"/></exception>
    public static bool Invoke<TKey, TValue>(this Action<Expect<TKey>, Expect<TValue>> expectPair, KeyValuePair<TKey, TValue> target)
    {
      expectPair?.Invoke(Expect.That(target.Key), Expect.That(target.Value));
      return true;
    }
  }
}