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
    public static Check<bool> True(this Check<bool> check) =>
      check.That(t => t);

    /// <summary>
    /// Checks if the target is <see langword="false"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<bool> False(this Check<bool> check) =>
      check.Not(t => t);

    //
    // Comparisons
    //

    /// <summary>
    /// Checks if the target is equal to <paramref name="value"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <param name="comparer">The object that performs the comparison, or <see cref="EqualityComparer{T}.Default"/></param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<T> EqualTo<T>(this Check<T> check, T value, IEqualityComparer<T>? comparer = null) where T : IEquatable<T> =>
      check.That(t => EqualTo(t, value, comparer));

    /// <summary>
    /// Checks if the target is not equal to <paramref name="value"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <param name="comparer">The object that performs the comparison, or <see cref="EqualityComparer{T}.Default"/></param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<T> NotEqualTo<T>(this Check<T> check, T value, IEqualityComparer<T>? comparer = null) where T : IEquatable<T> =>
      check.Not(t => EqualTo(t, value, comparer));

    /// <summary>
    /// Checks if the target is less than <paramref name="value"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <param name="comparer">The object that performs the comparison, or <see cref="EqualityComparer{T}.Default"/></param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<T> LessThan<T>(this Check<T> check, T value, IComparer<T>? comparer = null) where T : IComparable<T> =>
      check.That(t => Compare(t, value, comparer) < 0);

    /// <summary>
    /// Checks if the target is greater than <paramref name="value"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <param name="comparer">The object that performs the comparison, or <see cref="EqualityComparer{T}.Default"/></param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<T> GreaterThan<T>(this Check<T> check, T value, IComparer<T>? comparer = null) where T : IComparable<T> =>
      check.That(t => Compare(t, value, comparer) > 0);

    /// <summary>
    /// Checks if the target is at least <paramref name="minimum"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="minimum">The value to compare</param>
    /// <param name="comparer">The object that performs the comparison, or <see cref="EqualityComparer{T}.Default"/></param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<T> AtLeast<T>(this Check<T> check, T minimum, IComparer<T>? comparer = null) where T : IComparable<T> =>
      check.That(t => Compare(t, minimum, comparer) >= 0);

    /// <summary>
    /// Checks if the target is at most <paramref name="maximum"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="maximum">The value to compare</param>
    /// <param name="comparer">The object that performs the comparison, or <see cref="EqualityComparer{T}.Default"/></param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<T> AtMost<T>(this Check<T> check, T maximum, IComparer<T>? comparer = null) where T : IComparable<T> =>
      check.That(t => Compare(t, maximum, comparer) <= 0);

    /// <summary>
    /// Checks if the target is at least <paramref name="minimum"/> and at most <paramref name="maximum"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="minimum">The minimum value to compare</param>
    /// <param name="maximum">The maximum value to compare</param>
    /// <param name="comparer">The object that performs the comparisons, or <see cref="EqualityComparer{T}.Default"/></param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<T> InRange<T>(this Check<T> check, T minimum, T maximum, IComparer<T>? comparer = null) where T : IComparable<T> =>
      check.That(t => Compare(t, minimum, comparer) >= 0 && Compare(t, maximum, comparer) <= 0);

    static bool EqualTo<T>(T target, T value, IEqualityComparer<T>? comparer) =>
      (comparer ?? EqualityComparer<T>.Default).Equals(target, value);

    static int Compare<T>(T target, T other, IComparer<T>? comparer) =>
      (comparer ?? Comparer<T>.Default).Compare(target, other);

    //
    // ContainedIn
    //

    /// <summary>
    /// Checks if the target is contained in <paramref name="values"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="values">The values to compare</param>
    /// <param name="comparer">The object that performs the comparisons, or <see cref="EqualityComparer{T}.Default</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<T> ContainedIn<T>(this Check<T> check, IEnumerable<T> values, IEqualityComparer<T>? comparer = null) =>
      check.That(t => values != null && values.Contains(t, comparer));

    /// <summary>
    /// Checks if the target is contained in <paramref name="values"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="values">The values to compare</param>
    /// <param name="comparer">The object that performs the comparisons</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<T> ContainedIn<T>(this Check<T> check, IEqualityComparer<T>? comparer, params T[] values) =>
      check.That(t => values != null && values.Contains(t, comparer));

    /// <summary>
    /// Checks if the target is contained in <paramref name="values"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="values">The values to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<T> ContainedIn<T>(this Check<T> check, params T[] values) =>
      check.That(t => values != null && values.Contains(t));

    /// <summary>
    /// Checks if the target is not contained in <paramref name="values"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="values">The values to compare</param>
    /// <param name="comparer">The object that performs the comparisons, or <see cref="EqualityComparer{T}.Default</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<T> NotContainedIn<T>(this Check<T> check, IEnumerable<T> values, IEqualityComparer<T>? comparer = null) =>
      check.Not(t => values != null && values.Contains(t, comparer));

    /// <summary>
    /// Checks if the target is not contained in <paramref name="values"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="values">The values to compare</param>
    /// <param name="comparer">The object that performs the comparisons</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<T> NotContainedIn<T>(this Check<T> check, IEqualityComparer<T>? comparer, params T[] values) =>
      check.Not(t => values != null && values.Contains(t, comparer));

    /// <summary>
    /// Checks if the target is not contained in <paramref name="values"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="values">The values to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<T> NotContainedIn<T>(this Check<T> check, params T[] values) =>
      check.Not(t => values != null && values.Contains(t));

    //
    // Assignable
    //

    /// <summary>
    /// Checks if the target is assignable to <paramref name="type"/>, that is, if it can appear on the right-hand side of an assignment with <paramref name="type"/> on the left
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="type">The type to check for assignability from the target</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<T> AssignableTo<T>(this Check<T> check, Type type) =>
      check.That(t => t != null && type != null && type.IsAssignableFrom(t.GetType()));

    /// <summary>
    /// Checks if the target type is assignable to <paramref name="type"/>, that is, if it can appear on the right-hand side of an assignment with <paramref name="type"/> on the left
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="type">The type to check for assignability from the target type</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Type> AssignableTo(this Check<Type> check, Type type) =>
      check.That(t => t != null && type != null && type.IsAssignableFrom(t));

    /// <summary>
    /// Checks if the target type is assignable to <typeparamref name="T"/>, that is, if it can appear on the right-hand side of an assignment with <typeparamref name="T"/> on the left
    /// </summary>
    /// <typeparam name="T">The type to check for assignability from the target type</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Type> AssignableTo<T>(this Check<Type> check) =>
      check.AssignableTo(typeof(T));

    /// <summary>
    /// Checks if the target type is assignable from <paramref name="type"/>, that is, if it can appear on the left-hand side of an assignment with <paramref name="type"/> on the right
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="type">The type to check for assignability to the target type</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Type> AssignableFrom(this Check<Type> check, Type type) =>
      check.That(t => t != null && type != null && t.IsAssignableFrom(type));

    /// <summary>
    /// Checks if the target is not assignable to <paramref name="type"/>, that is, if it cannot appear on the right-hand side of an assignment with <paramref name="type"/> on the left
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="type">The type to check for assignability from the target</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<T> NotAssignableTo<T>(this Check<T> check, Type type) =>
      check.That(t => t != null && type != null && type.IsAssignableFrom(t.GetType()));

    /// <summary>
    /// Checks if the target type is not assignable to <paramref name="type"/>, that is, if it cannot appear on the right-hand side of an assignment with <paramref name="type"/> on the left
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="type">The type to check for assignability from the target type</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Type> NotAssignableTo(this Check<Type> check, Type type) =>
      check.Not(t => t != null && type != null && type.IsAssignableFrom(t));

    /// <summary>
    /// Checks if the target type is not assignable to <typeparamref name="T"/>, that is, if it cannot appear on the right-hand side of an assignment with <typeparamref name="T"/> on the left
    /// </summary>
    /// <typeparam name="T">The type to check for assignability from the target type</typeparam>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Type> NotAssignableTo<T>(this Check<Type> check) =>
      check.NotAssignableTo(typeof(T));

    /// <summary>
    /// Checks if the target type is not assignable from <paramref name="type"/>, that is, if it cannot appear on the left-hand side of an assignment with <paramref name="type"/> on the right
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="type">The type to check for assignability to the target type</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Type> NotAssignableFrom(this Check<Type> check, Type type) =>
      check.Not(t => t != null && type != null && t.IsAssignableFrom(type));

    //
    // Checked arguments
    //

    /// <summary>
    /// Calls the specified function with a <see cref="Check{T}"/> referencing <paramref name="target"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="checkValue">The function to invoke with a checked argument</param>
    /// <param name="target">The value of the checked argument</param>
    /// <returns>The result of calling <paramref name="checkValue"/> with a <see cref="Check{T}"/> referencing <paramref name="target"/></returns>
    public static bool Invoke<T>(this Func<Check<T>, bool>? checkValue, T target) =>
      checkValue != null && checkValue(Check.That(target));
  }
}