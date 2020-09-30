using System;
using System.Collections.Generic;
using System.Linq;

namespace Green
{
  /// <summary>
  /// Defines operators available to queries that throw <see cref="ExpectException"/> if not met
  /// </summary>
  public static partial class Expectable
  {
    /// <summary>
    /// Expects the target is <see langword="true"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<bool> IsTrue(this Expect<bool> expect, Issue<bool>? issue = null) =>
      expect.That(t => t, issue.Operator());

    /// <summary>
    /// Expects the target is <see langword="false"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<bool> IsFalse(this Expect<bool> expect, Issue<bool>? issue = null) =>
      expect.That(t => !t, issue.Operator());

    //
    // Null
    //

    /// <summary>
    /// Expects the target is <see langword="null"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<T> IsNull<T>(this Expect<T> expect, Issue<T>? issue = null) where T : class =>
      expect.That(t => t == null, issue.Operator());

    /// <summary>
    /// Expects the target is <see langword="null"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<T?> IsNull<T>(this Expect<T?> expect, Issue<T?>? issue = null) where T : struct =>
      expect.That(t => t == null, issue.Operator());

    /// <summary>
    /// Expects the target is not <see langword="null"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<T> IsNotNull<T>(this Expect<T> expect, Issue<T>? issue = null) where T : class =>
      expect.That(t => t != null, issue.Operator());

    /// <summary>
    /// Expects the target is not <see langword="null"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<T?> IsNotNull<T>(this Expect<T?> expect, Issue<T?>? issue = null) where T : struct =>
      expect.That(t => t != null, issue.Operator());

    //
    // Comparisons
    //

    /// <summary>
    /// Expects the target equals <paramref name="value"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<T> Is<T>(this Expect<T> expect, T value, IEqualityComparer<T> comparer, Issue<T>? issue = null) =>
      expect.That(t => Equals(t, value, comparer), issue.Operator(value, comparer));

    /// <summary>
    /// Expects the target does not equal <paramref name="value"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<T> IsNot<T>(this Expect<T> expect, T value, IEqualityComparer<T> comparer, Issue<T>? issue = null) =>
      expect.That(t => !Equals(t, value, comparer), issue.Operator(value, comparer));

    /// <summary>
    /// Expects the target is less than <paramref name="value"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<T> IsLessThan<T>(this Expect<T> expect, T value, IComparer<T> comparer, Issue<T>? issue = null) =>
      expect.That(t => Compare(t, value, comparer) < 0, issue.Operator(value, comparer));

    /// <summary>
    /// Expects the target is greater than <paramref name="value"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<T> IsGreaterThan<T>(this Expect<T> expect, T value, IComparer<T> comparer, Issue<T>? issue = null) =>
      expect.That(t => Compare(t, value, comparer) > 0, issue.Operator(value, comparer));

    /// <summary>
    /// Expects the target is at least <paramref name="minimum"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="minimum">The value to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<T> IsAtLeast<T>(this Expect<T> expect, T minimum, IComparer<T> comparer, Issue<T>? issue = null) =>
      expect.That(t => Compare(t, minimum, comparer) >= 0, issue.Operator(minimum, comparer));

    /// <summary>
    /// Expects the target is at most <paramref name="maximum"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="maximum">The value to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<T> IsAtMost<T>(this Expect<T> expect, T maximum, IComparer<T> comparer, Issue<T>? issue = null) =>
      expect.That(t => Compare(t, maximum, comparer) <= 0, issue.Operator(maximum, comparer));

    /// <summary>
    /// Expects the target is at least <paramref name="minimum"/> and at most <paramref name="maximum"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="minimum">The minimum value to compare using <paramref name="comparer"/></param>
    /// <param name="maximum">The maximum value to compare using <paramref name="comparer"/></param>
    /// <param name="comparer">The object that performs the comparisons</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<T> IsInRange<T>(this Expect<T> expect, T minimum, T maximum, IComparer<T> comparer, Issue<T>? issue = null) =>
      expect.That(t => Compare(t, minimum, comparer) >= 0 && Compare(t, maximum, comparer) <= 0, issue.Operator(minimum, maximum, comparer));

    static bool Equals<T>(T target, T value, IEqualityComparer<T>? comparer = null) =>
      (comparer ?? EqualityComparer<T>.Default).Equals(target, value);

    static int Compare<T>(T target, T value, IComparer<T>? comparer = null) =>
      (comparer ?? Comparer<T>.Default).Compare(target, value);

    //
    // Comparisons (default comparer)
    //

    /// <summary>
    /// Expects the target equals <paramref name="value"/> using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare using <see cref="EqualityComparer{T}.Default"/></param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<T> Is<T>(this Expect<T> expect, T value, Issue<T>? issue = null) =>
      expect.That(t => Equals(t, value), issue.Operator(value));

    /// <summary>
    /// Expects the target does not equal <paramref name="value"/> using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare using <see cref="EqualityComparer{T}.Default"/></param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<T> IsNot<T>(this Expect<T> expect, T value, Issue<T>? issue = null) =>
      expect.That(t => !Equals(t, value), issue.Operator(value));

    /// <summary>
    /// Expects the target is less then <paramref name="value"/> using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare using <see cref="EqualityComparer{T}.Default"/></param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<T> IsLessThan<T>(this Expect<T> expect, T value, Issue<T>? issue = null) =>
      expect.That(t => Compare(t, value) < 0, issue.Operator(value));

    /// <summary>
    /// Expects the target is greater than <paramref name="value"/> using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare using <see cref="EqualityComparer{T}.Default"/></param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<T> IsGreaterThan<T>(this Expect<T> expect, T value, Issue<T>? issue = null) =>
      expect.That(t => Compare(t, value) > 0, issue.Operator(value));

    /// <summary>
    /// Expects the target is at least <paramref name="minimum"/> using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="minimum">The value to compare using <see cref="EqualityComparer{T}.Default"/></param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<T> IsAtLeast<T>(this Expect<T> expect, T minimum, Issue<T>? issue = null) =>
      expect.That(t => Compare(t, minimum) >= 0, issue.Operator(minimum));

    /// <summary>
    /// Expects the target is at most <paramref name="maximum"/> using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="maximum">The value to compare using <see cref="EqualityComparer{T}.Default"/></param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<T> IsAtMost<T>(this Expect<T> expect, T maximum, Issue<T>? issue = null) =>
      expect.That(t => Compare(t, maximum) <= 0, issue.Operator(maximum));

    /// <summary>
    /// Expects the target is at least <paramref name="minimum"/> and at most <paramref name="maximum"/> using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="minimum">The minimum value to compare using <see cref="EqualityComparer{T}.Default"/></param>
    /// <param name="maximum">The maximum value to compare using <see cref="EqualityComparer{T}.Default"/></param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<T> IsInRange<T>(this Expect<T> expect, T minimum, T maximum, Issue<T>? issue = null) =>
      expect.That(t => Compare(t, minimum) >= 0 && Compare(t, maximum) <= 0, issue.Operator(minimum, maximum));

    //
    // In
    //

    /// <summary>
    /// Expects <paramref name="values"/> contains the target using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="values">The values to compare using <paramref name="comparer"/></param>
    /// <param name="comparer">The object that performs the comparisons</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<T> IsIn<T>(this Expect<T> expect, IEnumerable<T> values, IEqualityComparer<T> comparer, Issue<T>? issue = null) =>
      expect.That(t => values != null && values.Contains(t, comparer), issue.Operator(values, comparer));

    /// <summary>
    /// Expects <paramref name="values"/> contains the target using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="values">The values to compare using <see cref="EqualityComparer{T}.Default"/></param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<T> IsIn<T>(this Expect<T> expect, IEnumerable<T> values, Issue<T>? issue = null) =>
      expect.IsIn(values.AsEnumerable(), issue);

    /// <summary>
    /// Expects <paramref name="values"/> contains the target using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="values">The values to compare using <see cref="EqualityComparer{T}.Default"/></param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<T> IsIn<T>(this Expect<T> expect, params T[] values) =>
      expect.IsIn(values.AsEnumerable());

    /// <summary>
    /// Expects <paramref name="values"/> contains the target using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="values">The values to compare using <see cref="EqualityComparer{T}.Default"/></param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<T> IsIn<T>(this Expect<T> expect, Issue<T> issue, params T[] values) =>
      expect.IsIn(values.AsEnumerable(), issue);

    /// <summary>
    /// Expects <paramref name="values"/> contains the target using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="values">The values to compare using <paramref name="comparer"/></param>
    /// <param name="comparer">The object that performs the comparisons</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<T> IsIn<T>(this Expect<T> expect, IEqualityComparer<T> comparer, params T[] values) =>
      expect.IsIn(values.AsEnumerable(), comparer);

    /// <summary>
    /// Expects <paramref name="values"/> contains the target using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="values">The values to compare using <paramref name="comparer"/></param>
    /// <param name="comparer">The object that performs the comparisons</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<T> IsIn<T>(this Expect<T> expect, IEqualityComparer<T> comparer, Issue<T> issue, params T[] values) =>
      expect.IsIn(values.AsEnumerable(), comparer, issue);

    //
    // Not in
    //

    /// <summary>
    /// Expects <paramref name="values"/> does not contain the target using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="values">The values to compare using <paramref name="comparer"/></param>
    /// <param name="comparer">The object that performs the comparisons</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<T> IsNotIn<T>(this Expect<T> expect, IEnumerable<T> values, IEqualityComparer<T> comparer, Issue<T>? issue = null) =>
      expect.That(t => values != null && values.Contains(t, comparer), issue.Operator(values, comparer));

    /// <summary>
    /// Expects <paramref name="values"/> does not contain the target using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="values">The values to compare using <see cref="EqualityComparer{T}.Default"/></param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<T> IsNotIn<T>(this Expect<T> expect, IEnumerable<T> values, Issue<T>? issue = null) =>
      expect.IsNotIn(values.AsEnumerable(), issue);

    /// <summary>
    /// Expects <paramref name="values"/> does not contain the target using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="values">The values to compare using <see cref="EqualityComparer{T}.Default"/></param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<T> IsNotIn<T>(this Expect<T> expect, params T[] values) =>
      expect.IsNotIn(values.AsEnumerable());

    /// <summary>
    /// Expects <paramref name="values"/> does not contain the target using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="values">The values to compare using <see cref="EqualityComparer{T}.Default"/></param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<T> IsNotIn<T>(this Expect<T> expect, Issue<T> issue, params T[] values) =>
      expect.IsNotIn(values.AsEnumerable(), issue);

    /// <summary>
    /// Expects <paramref name="values"/> does not contain the target using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="values">The values to compare using <paramref name="comparer"/></param>
    /// <param name="comparer">The object that performs the comparisons</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<T> IsNotIn<T>(this Expect<T> expect, IEqualityComparer<T> comparer, params T[] values) =>
      expect.IsNotIn(values.AsEnumerable(), comparer);

    /// <summary>
    /// Expects <paramref name="values"/> does not contain the target using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="values">The values to compare using <paramref name="comparer"/></param>
    /// <param name="comparer">The object that performs the comparisons</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<T> IsNotIn<T>(this Expect<T> expect, IEqualityComparer<T> comparer, Issue<T> issue, params T[] values) =>
      expect.IsNotIn(values.AsEnumerable(), comparer, issue);

    //
    // Types
    //

    /// <summary>
    /// Expects the target type is assignable from <paramref name="type"/>, that is, if it can appear on the left-hand side of an assignment with <paramref name="type"/> on the right
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="type">The type to check for assignability to the target type</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<Type> IsAssignableFrom(this Expect<Type> expect, Type type, Issue<Type>? issue = null) =>
      expect.That(t => t != null && type != null && t.IsAssignableFrom(type), issue.Operator(type));

    /// <summary>
    /// Expects the target type is assignable to <paramref name="type"/>, that is, if it can appear on the right-hand side of an assignment with <paramref name="type"/> on the left
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="type">The type to check for assignability from the target type</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<Type> IsAssignableTo(this Expect<Type> expect, Type type, Issue<Type>? issue = null) =>
      expect.That(t => t != null && type != null && type.IsAssignableFrom(t), issue.Operator(type));

    /// <summary>
    /// Expects the target type is assignable to <typeparamref name="T"/>, that is, if it can appear on the right-hand side of an assignment with <typeparamref name="T"/> on the left
    /// </summary>
    /// <typeparam name="T">The type to check for assignability from the target type</typeparam>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<Type> IsAssignableTo<T>(this Expect<Type> expect, Issue<Type>? issue = null) =>
      expect.IsAssignableTo(typeof(T), issue);

    //
    // Details
    //

    /// <summary>
    /// Calls the specified action with an <see cref="Expect{T}"/> referencing <paramref name="target"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="target">The value of the expected argument</param>
    /// <returns><see langword="true"/> to enable use in expressions</returns>
    /// <exception cref="ExpectException">Thrown if <paramref name="expectValue"/> throws for <paramref name="target"/></exception>
    public static bool Invoke<T>(this Action<Expect<T>> expectValue, T target)
    {
      expectValue?.Invoke(Expect.That(target));

      return true;
    }
  }
}