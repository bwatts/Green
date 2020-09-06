using System;
using System.Collections.Generic;
using System.Linq;

namespace Green
{
  /// <summary>
  /// Defines operators available to <see langword="bool"/>-valued queries
  /// </summary>
  public static partial class Checkable
  {
    /// <summary>
    /// Checks if the target is <see langword="true"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<bool> IsTrue(this Check<bool> check) =>
      check.That(t => t);

    /// <summary>
    /// Checks if the target is <see langword="false"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<bool> IsFalse(this Check<bool> check) =>
      check.Not(t => t);

    /// <summary>
    /// Checks if the target is not <see langword="null"/> and results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <typeparam name="T">The type of checked value</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the value if present</param>
    /// <returns></returns>
    public static Check<T?> HasValue<T>(this Check<T?> check, Func<Check<T>, bool> checkValue) where T : struct =>
      check.That(t => t != null && checkValue != null && checkValue(Check.That(t.Value)));

    //
    // Null
    //

    /// <summary>
    /// Checks if the target is <see langword="null"/>
    /// </summary>
    /// <typeparam name="T">The type of checked value</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<T> IsNull<T>(this Check<T> check) where T : class =>
      check.That(t => t == null);

    /// <summary>
    /// Checks if the target is <see langword="null"/>
    /// </summary>
    /// <typeparam name="T">The type of checked value</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<T?> IsNull<T>(this Check<T?> check) where T : struct =>
      check.That(t => t == null);

    /// <summary>
    /// Checks if the target is not <see langword="null"/>
    /// </summary>
    /// <typeparam name="T">The type of checked value</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<T> IsNotNull<T>(this Check<T> check) where T : class =>
      check.Not(t => t == null);

    /// <summary>
    /// Checks if the target is not <see langword="null"/>
    /// </summary>
    /// <typeparam name="T">The type of checked value</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<T?> IsNotNull<T>(this Check<T?> check) where T : struct =>
      check.Not(t => t == null);

    //
    // Comparisons
    //

    /// <summary>
    /// Checks if the target equals <paramref name="value"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of checked value</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare using <paramref name="comparer"/></param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<T> Is<T>(this Check<T> check, T value, IEqualityComparer<T> comparer) where T : IEquatable<T> =>
      check.That(t => Equals(t, value, comparer));

    /// <summary>
    /// Checks if the target is not equal to <paramref name="value"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of checked value</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare using <paramref name="comparer"/></param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<T> IsNot<T>(this Check<T> check, T value, IEqualityComparer<T> comparer) where T : IEquatable<T> =>
      check.Not(t => Equals(t, value, comparer));

    /// <summary>
    /// Checks if the target is less than <paramref name="value"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of checked value</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare using <paramref name="comparer"/></param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<T> IsLessThan<T>(this Check<T> check, T value, IComparer<T> comparer) where T : IComparable<T> =>
      check.That(t => Compare(t, value, comparer) < 0);

    /// <summary>
    /// Checks if the target is greater than <paramref name="value"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of checked value</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare using <paramref name="comparer"/></param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<T> IsGreaterThan<T>(this Check<T> check, T value, IComparer<T> comparer) where T : IComparable<T> =>
      check.That(t => Compare(t, value, comparer) > 0);

    /// <summary>
    /// Checks if the target is at least <paramref name="minimum"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of checked value</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="minimum">The value to compare using <paramref name="comparer"/></param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<T> IsAtLeast<T>(this Check<T> check, T minimum, IComparer<T> comparer) where T : IComparable<T> =>
      check.That(t => Compare(t, minimum, comparer) >= 0);

    /// <summary>
    /// Checks if the target is at most <paramref name="maximum"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of checked value</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="maximum">The value to compare using <paramref name="comparer"/></param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<T> IsAtMost<T>(this Check<T> check, T maximum, IComparer<T> comparer) where T : IComparable<T> =>
      check.That(t => Compare(t, maximum, comparer) <= 0);

    /// <summary>
    /// Checks if the target is at least <paramref name="minimum"/> and at most <paramref name="maximum"/> using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of checked value</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="minimum">The minimum value to compare using <paramref name="comparer"/></param>
    /// <param name="maximum">The maximum value to compare using <paramref name="comparer"/></param>
    /// <param name="comparer">The object that performs the comparisons</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<T> IsInRange<T>(this Check<T> check, T minimum, T maximum, IComparer<T> comparer) where T : IComparable<T> =>
      check.That(t => Compare(t, minimum, comparer) >= 0 && Compare(t, maximum, comparer) <= 0);

    static bool Equals<T>(T target, T other, IEqualityComparer<T> comparer) =>
      (comparer ?? EqualityComparer<T>.Default).Equals(target, other);

    static int Compare<T>(T target, T other, IComparer<T> comparer) =>
      (comparer ?? Comparer<T>.Default).Compare(target, other);

    //
    // Comparisons (default comparer)
    //

    /// <summary>
    /// Checks if the target equals <paramref name="value"/> using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of checked value</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare using <see cref="EqualityComparer{T}.Default"/></param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<T> Is<T>(this Check<T> check, T value) where T : IEquatable<T> =>
      check.Is(value, EqualityComparer<T>.Default);

    /// <summary>
    /// Checks if the target is not equal to <paramref name="value"/> using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of checked value</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare using <see cref="EqualityComparer{T}.Default"/></param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<T> IsNot<T>(this Check<T> check, T value) where T : IEquatable<T> =>
      check.IsNot(value, EqualityComparer<T>.Default);

    /// <summary>
    /// Checks if the target is less than <paramref name="value"/> using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of checked value</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare using <see cref="EqualityComparer{T}.Default"/></param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<T> IsLessThan<T>(this Check<T> check, T value) where T : IComparable<T> =>
      check.IsLessThan(value, Comparer<T>.Default);

    /// <summary>
    /// Checks if the target is greater than <paramref name="value"/> using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of checked value</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare using <see cref="EqualityComparer{T}.Default"/></param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<T> IsGreaterThan<T>(this Check<T> check, T value) where T : IComparable<T> =>
      check.IsGreaterThan(value, Comparer<T>.Default);

    /// <summary>
    /// Checks if the target is at least <paramref name="minimum"/> using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of checked value</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="minimum">The value to compare using <see cref="EqualityComparer{T}.Default"/></param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<T> IsAtLeast<T>(this Check<T> check, T minimum) where T : IComparable<T> =>
      check.IsAtLeast(minimum, Comparer<T>.Default);

    /// <summary>
    /// Checks if the target is at most <paramref name="maximum"/> using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of checked value</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="maximum">The value to compare using  <see cref="EqualityComparer{T}.Default"/></param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<T> IsAtMost<T>(this Check<T> check, T maximum) where T : IComparable<T> =>
      check.IsAtMost(maximum, Comparer<T>.Default);

    /// <summary>
    /// Checks if the target is at least <paramref name="minimum"/> and at most <paramref name="maximum"/> using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of checked value</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="minimum">The minimum value to compare using <see cref="EqualityComparer{T}.Default"/></param>
    /// <param name="maximum">The maximum value to compare using <see cref="EqualityComparer{T}.Default"/></param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<T> IsInRange<T>(this Check<T> check, T minimum, T maximum) where T : IComparable<T> =>
      check.IsInRange(minimum, maximum, Comparer<T>.Default);

    //
    // In
    //

    /// <summary>
    /// Checks if <paramref name="values"/> contains the target using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of checked value</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="values">The values to compare using <paramref name="comparer"/></param>
    /// <param name="comparer">The object that performs the comparisons</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<T> IsIn<T>(this Check<T> check, IEnumerable<T> values, IEqualityComparer<T> comparer) =>
      check.That(t => values != null && values.Contains(t, comparer));

    /// <summary>
    /// Checks if <paramref name="values"/> contains the target using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of checked value</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="values">The values to compare using <see cref="EqualityComparer{T}.Default"/></param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<T> IsIn<T>(this Check<T> check, IEnumerable<T> values) =>
      check.IsIn(values, EqualityComparer<T>.Default);

    /// <summary>
    /// Checks if <paramref name="values"/> contains the target using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of checked value</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="values">The values to compare using <see cref="EqualityComparer{T}.Default"/></param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<T> IsIn<T>(this Check<T> check, params T[] values) =>
      check.IsIn(values, EqualityComparer<T>.Default);

    /// <summary>
    /// Checks if <paramref name="values"/> contains the target using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of checked value</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="comparer">The object that performs the comparisons</param>
    /// <param name="values">The values to compare using <paramref name="comparer"/></param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<T> IsIn<T>(this Check<T> check, IEqualityComparer<T> comparer, params T[] values) =>
      check.IsIn(values, comparer);

    //
    // Not in
    //

    /// <summary>
    /// Checks if <paramref name="values"/> does not contain the target using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of checked value</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="values">The values to compare using <paramref name="comparer"/></param>
    /// <param name="comparer">The object that performs the comparisons</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<T> IsNotIn<T>(this Check<T> check, IEnumerable<T> values, IEqualityComparer<T> comparer) =>
      check.Not(t => values != null && values.Contains(t, comparer));

    /// <summary>
    /// Checks if <paramref name="values"/> does not contain the target using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of checked value</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="values">The values to compare using <see cref="EqualityComparer{T}.Default"/></param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<T> IsNotIn<T>(this Check<T> check, IEnumerable<T> values) =>
      check.IsNotIn(values, EqualityComparer<T>.Default);

    /// <summary>
    /// Checks if <paramref name="values"/> does not contain the target using <paramref name="comparer"/>
    /// </summary>
    /// <typeparam name="T">The type of checked value</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="comparer">The object that performs the comparisons</param>
    /// <param name="values">The values to compare using <paramref name="comparer"/></param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<T> IsNotIn<T>(this Check<T> check, IEqualityComparer<T> comparer, params T[] values) =>
      check.IsNotIn(values, comparer);

    /// <summary>
    /// Checks if <paramref name="values"/> does not contain the target using <see cref="EqualityComparer{T}.Default"/>
    /// </summary>
    /// <typeparam name="T">The type of checked value</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="values">The values to compare using <see cref="EqualityComparer{T}.Default"/></param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<T> IsNotIn<T>(this Check<T> check, params T[] values) =>
      check.IsNotIn(values, EqualityComparer<T>.Default);

    //
    // Types
    //

    /// <summary>
    /// Checks if the target type is assignable from <paramref name="type"/>, that is, if it can appear on the left-hand side of an assignment with <paramref name="type"/> on the right
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="type">The type to check for assignability to the target type</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Type> IsAssignableFrom(this Check<Type> check, Type type) =>
      check.That(t => t != null && type != null && t.IsAssignableFrom(type));

    /// <summary>
    /// Checks if the target type is assignable to <paramref name="type"/>, that is, if it can appear on the right-hand side of an assignment with <paramref name="type"/> on the left
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="type">The type to check for assignability from the target type</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Type> IsAssignableTo(this Check<Type> check, Type type) =>
      check.That(t => t != null && type != null && type.IsAssignableFrom(t));

    /// <summary>
    /// Checks if the target type is assignable to <typeparamref name="T"/>, that is, if it can appear on the right-hand side of an assignment with <typeparamref name="T"/> on the left
    /// </summary>
    /// <typeparam name="T">The type to check for assignability from the target type</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Type> IsAssignableTo<T>(this Check<Type> check) =>
      check.IsAssignableTo(typeof(T));

    //
    // Checked arguments
    //

    /// <summary>
    /// Calls the specified function with a <see cref="Check{T}"/> referencing <paramref name="target"/>
    /// </summary>
    /// <typeparam name="T">The type of checked value</typeparam>
    /// <param name="checkValue">The function to invoke with a checked argument</param>
    /// <param name="target">The value of the checked argument</param>
    /// <returns>The result fo calling <paramref name="checkValue"/> with a <see cref="Check{T}"/> referencing <paramref name="target"/></returns>
    public static bool Invoke<T>(this Func<Check<T>, bool> checkValue, T target) =>
      checkValue != null && checkValue(Check.That(target));
  }
}