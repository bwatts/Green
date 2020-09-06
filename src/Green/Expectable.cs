using System;
using System.Collections.Generic;
using System.Linq;
using Green.Messages;
using static Green.Messages.Local;

namespace Green
{
  public static partial class Expectable
  {
    public static Expect<bool> IsTrue(this Expect<bool> expect, Issue<bool>? issue = null) =>
      expect.That(t => t, issue.ElseExpected("true", received: "false"));

    public static Expect<bool> IsFalse(this Expect<bool> expect, Issue<bool>? issue = null) =>
      expect.Not(t => t, issue.ElseExpected("false", received: "true"));

    //
    // Null
    //

    public static Expect<T> IsNull<T>(this Expect<T> expect, Issue<T>? issue = null) where T : class =>
      expect.That(t => t == null, issue.ElseExpected(NullText));

    public static Expect<T?> IsNull<T>(this Expect<T?> expect, Issue<T?>? issue = null) where T : struct =>
      expect.That(t => t == null, issue.ElseExpected(NullText));

    public static Expect<T> IsNotNull<T>(this Expect<T> expect, Issue<T>? issue = null) where T : class =>
      expect.Not(t => t == null, issue.ElseExpected($"not {NullText}", received: NullText));

    public static Expect<T?> IsNotNull<T>(this Expect<T?> expect, Issue<T?>? issue = null) where T : struct =>
      expect.Not(t => t == null, issue.ElseExpected($"not {NullText}", received: NullText));

    //
    // Comparisons
    //

    public static Expect<T> Is<T>(this Expect<T> expect, T value, IEqualityComparer<T> comparer, Issue<T>? issue = null) =>
      expect.That(t => Equals(t, value, comparer), issue.ElseExpected($"{Text(value)}{comparer.ToSuffix()}"));

    public static Expect<T> IsNot<T>(this Expect<T> expect, T value, IEqualityComparer<T> comparer, Issue<T>? issue = null) =>
      expect.Not(t => Equals(t, value, comparer), issue.ElseExpected($"not {Text(value)}{comparer.ToSuffix()}"));

    public static Expect<T> IsLessThan<T>(this Expect<T> expect, T value, IComparer<T> comparer, Issue<T>? issue = null) =>
      expect.That(t => Compare(t, value, comparer) < 0, issue.ElseExpected($"less than {Text(value)}{comparer.ToSuffix()}"));

    public static Expect<T> IsGreaterThan<T>(this Expect<T> expect, T value, IComparer<T> comparer, Issue<T>? issue = null) =>
      expect.That(t => Compare(t, value, comparer) > 0, issue.ElseExpected($"greater than {Text(value)}{comparer.ToSuffix()}"));

    public static Expect<T> IsAtLeast<T>(this Expect<T> expect, T value, IComparer<T> comparer, Issue<T>? issue = null) =>
      expect.That(t => Compare(t, value, comparer) >= 0, issue.ElseExpected($"at least {Text(value)}{comparer.ToSuffix()}"));

    public static Expect<T> IsAtMost<T>(this Expect<T> expect, T value, IComparer<T> comparer, Issue<T>? issue = null) =>
      expect.That(t => Compare(t, value, comparer) <= 0, issue.ElseExpected($"at most {Text(value)}{comparer.ToSuffix()}"));

    public static Expect<T> IsInRange<T>(this Expect<T> expect, T minimum, T maximum, IComparer<T> comparer, Issue<T>? issue = null) =>
      expect.That(
        t => Compare(t, minimum, comparer) >= 0 && Compare(t, maximum, comparer) <= 0,
        issue.ElseExpected($"in range {Text(minimum)}-{Text(maximum)}{comparer.ToSuffix()}"));

    static bool Equals<T>(T target, T value, IEqualityComparer<T> comparer) =>
      (comparer ?? EqualityComparer<T>.Default).Equals(target, value);

    static int Compare<T>(T target, T value, IComparer<T> comparer) =>
      (comparer ?? Comparer<T>.Default).Compare(target, value);

    //
    // Comparisons (default comparer)
    //

    public static Expect<T> Is<T>(this Expect<T> expect, T value, Issue<T>? issue = null) =>
      expect.Is(value, EqualityComparer<T>.Default, issue);

    public static Expect<T> IsNot<T>(this Expect<T> expect, T value, Issue<T>? issue = null) =>
      expect.Is(value, EqualityComparer<T>.Default, issue);

    public static Expect<T> IsLessThan<T>(this Expect<T> expect, T value, Issue<T>? issue = null) =>
      expect.IsLessThan(value, Comparer<T>.Default, issue);

    public static Expect<T> IsGreaterThan<T>(this Expect<T> expect, T value, Issue<T>? issue = null) =>
      expect.IsGreaterThan(value, Comparer<T>.Default, issue);

    public static Expect<T> IsAtLeast<T>(this Expect<T> expect, T minimum, Issue<T>? issue = null) =>
      expect.IsAtLeast(minimum, Comparer<T>.Default, issue);

    public static Expect<T> IsAtMost<T>(this Expect<T> expect, T maximum, Issue<T>? issue = null) =>
      expect.IsAtMost(maximum, Comparer<T>.Default, issue);

    public static Expect<T> IsInRange<T>(this Expect<T> expect, T minimum, T maximum, Issue<T>? issue = null) =>
      expect.IsInRange(minimum, maximum, Comparer<T>.Default, issue);

    //
    // In
    //

    public static Expect<T> IsIn<T>(this Expect<T> expect, IEnumerable<T> values, IEqualityComparer<T> comparer, Issue<T>? issue = null) =>
      expect.That(t => values != null && values.Contains(t, comparer), issue.ElseExpected($"in {TextMany(values)}{comparer.ToSuffix()}"));

    public static Expect<T> IsIn<T>(this Expect<T> expect, IEnumerable<T> values, Issue<T>? issue = null) =>
      expect.IsIn(values.AsEnumerable(), issue);

    public static Expect<T> IsIn<T>(this Expect<T> expect, params T[] values) =>
      expect.IsIn(values.AsEnumerable());

    public static Expect<T> IsIn<T>(this Expect<T> expect, Issue<T> issue, params T[] values) =>
      expect.IsIn(values.AsEnumerable(), issue);

    public static Expect<T> IsIn<T>(this Expect<T> expect, IEqualityComparer<T> comparer, params T[] values) =>
      expect.IsIn(values.AsEnumerable(), comparer);

    public static Expect<T> IsIn<T>(this Expect<T> expect, IEqualityComparer<T> comparer, Issue<T> issue, params T[] values) =>
      expect.IsIn(values.AsEnumerable(), comparer, issue);

    //
    // Not in
    //

    public static Expect<T> IsNotIn<T>(this Expect<T> expect, IEnumerable<T> values, IEqualityComparer<T> comparer, Issue<T>? issue = null) =>
      expect.That(t => values != null && values.Contains(t, comparer), issue.ElseExpected($"not in {TextMany(values)}{comparer.ToSuffix()}"));

    public static Expect<T> IsNotIn<T>(this Expect<T> expect, IEnumerable<T> values, Issue<T>? issue = null) =>
      expect.IsNotIn(values.AsEnumerable(), issue);

    public static Expect<T> IsNotIn<T>(this Expect<T> expect, params T[] values) =>
      expect.IsNotIn(values.AsEnumerable());

    public static Expect<T> IsNotIn<T>(this Expect<T> expect, Issue<T> issue, params T[] values) =>
      expect.IsNotIn(values.AsEnumerable(), issue);

    public static Expect<T> IsNotIn<T>(this Expect<T> expect, IEqualityComparer<T> comparer, params T[] values) =>
      expect.IsNotIn(values.AsEnumerable(), comparer);

    public static Expect<T> IsNotIn<T>(this Expect<T> expect, IEqualityComparer<T> comparer, Issue<T> issue, params T[] values) =>
      expect.IsNotIn(values.AsEnumerable(), comparer, issue);

    //
    // Types
    //

    public static Expect<Type> IsAssignableFrom(this Expect<Type> expect, Type type, Issue<Type>? issue = null) =>
      expect.That(t => t != null && type != null && t.IsAssignableFrom(type), issue.ElseExpected($"assignable from {type}"));

    public static Expect<Type> IsAssignableTo(this Expect<Type> expect, Type type, Issue<Type>? issue = null) =>
      expect.That(t => t != null && type != null && type.IsAssignableFrom(t), issue.ElseExpected($"assignable to {type}"));

    public static Expect<Type> IsAssignableTo<T>(this Expect<Type> expect, Issue<Type>? issue = null) =>
      expect.IsAssignableTo(typeof(T), issue);

    //
    // Details
    //

    public static bool Invoke<T>(this Action<Expect<T>> expect, T target)
    {
      expect?.Invoke(Expect.That(target));

      return true;
    }

    static string? ToSuffix<T>(this IComparer<T> comparer) =>
      comparer == null ? null : $" (comparer = {comparer})";

    static string? ToSuffix<T>(this IEqualityComparer<T> comparer) =>
      comparer == null ? null : $" (comparer = {comparer})";

    static string? ToKeySuffix<T>(this IEqualityComparer<T> comparer) =>
      comparer == null ? null : $" (key comparer = {comparer})";

    static string? ToValueSuffix<T>(this IEqualityComparer<T> comparer) =>
      comparer == null ? null : $" (value comparer = {comparer})";

    static string? ToSuffix(this StringComparison comparison) =>
      $" (comparison = {comparison})";
  }
}