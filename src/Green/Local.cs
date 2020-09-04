using System.Collections.Generic;

namespace Green
{
  /// <summary>
  /// Brings top-level Green methods into the local scope:
  /// <code>Check</code>
  /// <code>CheckNot</code>
  /// <code>CheckMany</code>
  /// <code>CheckManyNot</code>
  /// <code>Expect</code>
  /// <code>ExpectNot</code>
  /// <code>ExpectMany</code>
  /// <code>ExpectManyNot</code>
  /// </summary>
  public static class Local
  {
    /// <summary>
    /// Starts a <see langword="bool"/>-valued query of <paramref name="target"/>.
    /// Returns <see langword="true"/> if all subsequent operators return <see langword="true"/>.
    /// </summary>
    /// <typeparam name="T">The type of checked value</typeparam>
    /// <param name="target">The checked value</param>
    /// <returns>A <see langword="bool"/>-valued query applied to <paramref name="target"/></returns>
    public static Check<T> Check<T>(T target) =>
      Green.Check.That(target);

    /// <summary>
    /// Starts a <see langword="bool"/>-valued query of <paramref name="target"/>.
    /// Returns <see langword="true"/> if all subsequent operators return <see langword="false"/>.
    /// </summary>
    /// <typeparam name="T">The type of checked value</typeparam>
    /// <param name="target">The checked value</param>
    /// <returns>A <see langword="bool"/>-valued query applied to <paramref name="target"/></returns>
    public static Check<T> CheckNot<T>(T target) =>
      Green.Check.Not(target);

    /// <summary>
    /// Starts a <see langword="bool"/>-valued query of <paramref name="target"/>.
    /// Returns <see langword="true"/> if all subsequent operators return <see langword="true"/>.
    /// </summary>
    /// <typeparam name="T">The type of items in the checked sequence</typeparam>
    /// <param name="target">The checked sequence</param>
    /// <returns>A <see langword="bool"/>-valued query applied to <paramref name="target"/></returns>
    public static CheckMany<T> CheckMany<T>(IEnumerable<T> target) =>
      Green.CheckMany.That(target);

    /// <summary>
    /// Starts a <see langword="bool"/>-valued query of <paramref name="target"/>.
    /// Returns <see langword="true"/> if all subsequent operators return <see langword="false"/>.
    /// </summary>
    /// <typeparam name="T">The type of items in the checked sequence</typeparam>
    /// <param name="target">The checked sequence</param>
    /// <returns>A <see langword="bool"/>-valued query applied to <paramref name="target"/></returns>
    public static CheckMany<T> CheckManyNot<T>(IEnumerable<T> target) =>
      Green.CheckMany.Not(target);

    /// <summary>
    /// Starts a <see langword="bool"/>-valued query of <paramref name="target"/>.
    /// Returns <see langword="true"/> if all subsequent operators return <see langword="true"/>.
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the checked dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the checked dictionary</typeparam>
    /// <param name="target">The checked dictionary</param>
    /// <returns>A <see langword="bool"/>-valued query applied to <paramref name="target"/></returns>
    public static CheckMany<TKey, TValue> CheckMany<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> target) =>
      Green.CheckMany.That(target);

    /// <summary>
    /// Starts a <see langword="bool"/>-valued query of <paramref name="target"/>.
    /// Evaluates to <see langword="true"/> if all subsequent operators are <see langword="false"/>.
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the checked dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the checked dictionary</typeparam>
    /// <param name="target">The checked dictionary</param>
    /// <returns>A <see langword="bool"/>-valued query applied to <paramref name="target"/></returns>
    public static CheckMany<TKey, TValue> CheckManyNot<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> target) =>
      Green.CheckMany.Not(target);

    //
    // Expect
    //

    public static Expect<T> Expect<T>(T target) =>
      Green.Expect.That(target);

    public static Expect<T> ExpectNot<T>(T target) =>
      Green.Expect.Not(target);

    public static ExpectMany<T> ExpectMany<T>(IEnumerable<T> target) =>
      Green.ExpectMany.That(target);

    public static ExpectMany<T> ExpectManyNot<T>(IEnumerable<T> target) =>
      Green.ExpectMany.Not(target);

    public static ExpectMany<TKey, TValue> ExpectMany<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> target) =>
      Green.ExpectMany.That(target);

    public static ExpectMany<TKey, TValue> ExpectManyNot<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> target) =>
      Green.ExpectMany.Not(target);
  }
}