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
    /// Starts a <see langword="bool"/>-valued query of <paramref name="target"/> that returns
    /// <see langword="true"/> if all subsequent operators return <see langword="true"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="target">The value to which the check applies</param>
    /// <returns>A <see langword="bool"/>-valued query applied to <paramref name="target"/></returns>
    public static Check<T> Check<T>(T target) =>
      Green.Check.That(target);

    /// <summary>
    /// Starts a <see langword="bool"/>-valued query of <paramref name="target"/> that returns
    /// <see langword="true"/> if all subsequent operators return <see langword="false"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="target">The value to which the check applies</param>
    /// <returns>A <see langword="bool"/>-valued query applied to <paramref name="target"/></returns>
    public static Check<T> CheckNot<T>(T target) =>
      Green.Check.Not(target);

    /// <summary>
    /// Starts a <see langword="bool"/>-valued query of <paramref name="target"/> that returns
    /// <see langword="true"/> if all subsequent operators return <see langword="true"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="target">The sequence to which the check applies</param>
    /// <returns>A <see langword="bool"/>-valued query applied to <paramref name="target"/></returns>
    public static CheckMany<T> CheckMany<T>(IEnumerable<T> target) =>
      Green.CheckMany.That(target);

    /// <summary>
    /// Starts a <see langword="bool"/>-valued query of <paramref name="target"/> that returns
    /// <see langword="true"/> if all subsequent operators return <see langword="false"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="target">The sequence to which the check applies</param>
    /// <returns>A <see langword="bool"/>-valued query applied to <paramref name="target"/></returns>
    public static CheckMany<T> CheckManyNot<T>(IEnumerable<T> target) =>
      Green.CheckMany.Not(target);

    /// <summary>
    /// Starts a <see langword="bool"/>-valued query of <paramref name="target"/> that returns
    /// <see langword="true"/> if all subsequent operators return <see langword="true"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="target">The dictionary to which the check applies</param>
    /// <returns>A <see langword="bool"/>-valued query applied to <paramref name="target"/></returns>
    public static CheckMany<TKey, TValue> CheckMany<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> target) =>
      Green.CheckMany.That(target);

    /// <summary>
    /// Starts a <see langword="bool"/>-valued query of <paramref name="target"/> that returns
    /// <see langword="true"/> if all subsequent operators are <see langword="false"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="target">The dictionary to which the check applies</param>
    /// <returns>A <see langword="bool"/>-valued query applied to <paramref name="target"/></returns>
    public static CheckMany<TKey, TValue> CheckManyNot<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> target) =>
      Green.CheckMany.Not(target);

    //
    // Expect
    //

    /// <summary>
    /// Starts a query of <paramref name="target"/> that throws <see cref="ExpectException"/> if any subseqeuent
    /// operator returns <see langword="false"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="target">The expected value</param>
    /// <returns>An expectation applied to <paramref name="target"/></returns>
    public static Expect<T> Expect<T>(T target) =>
      Green.Expect.That(target);

    /// <summary>
    /// Starts a query of <paramref name="target"/> that throws <see cref="ExpectException"/> if any subseqeuent
    /// operator returns <see langword="true"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="target">The expected value</param>
    /// <returns>An expectation applied to <paramref name="target"/></returns>
    public static Expect<T> ExpectNot<T>(T target) =>
      Green.Expect.Not(target);

    /// <summary>
    /// Starts a query of <paramref name="target"/> that throws <see cref="ExpectException"/> if any subseqeuent
    /// operator returns <see langword="false"/>
    /// </summary>
    /// <typeparam name="T">The type of expected sequence</typeparam>
    /// <param name="target">The expected sequence</param>
    /// <returns>An expectation applied to <paramref name="target"/></returns>
    public static ExpectMany<T> ExpectMany<T>(IEnumerable<T> target) =>
      Green.ExpectMany.That(target);

    /// <summary>
    /// Starts a query of <paramref name="target"/> that throws <see cref="ExpectException"/> if any subseqeuent
    /// operator returns <see langword="true"/>
    /// </summary>
    /// <typeparam name="T">The type of expected sequence</typeparam>
    /// <param name="target">The expected sequence</param>
    /// <returns>An expectation applied to <paramref name="target"/></returns>
    public static ExpectMany<T> ExpectManyNot<T>(IEnumerable<T> target) =>
      Green.ExpectMany.Not(target);

    /// <summary>
    /// Starts a query of <paramref name="target"/> that throws <see cref="ExpectException"/> if any subseqeuent
    /// operator returns <see langword="false"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the expected dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the expected dictionary</typeparam>
    /// <param name="target">The expected dictionary</param>
    /// <returns>An expectation applied to <paramref name="target"/></returns>
    public static ExpectMany<TKey, TValue> ExpectMany<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> target) =>
      Green.ExpectMany.That(target);

    /// <summary>
    /// Starts a query of <paramref name="target"/> that throws <see cref="ExpectException"/> if any subseqeuent
    /// operator returns <see langword="true"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the expected dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the expected dictionary</typeparam>
    /// <param name="target">The expected dictionary</param>
    /// <returns>An expectation applied to <paramref name="target"/></returns>
    public static ExpectMany<TKey, TValue> ExpectManyNot<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> target) =>
      Green.ExpectMany.Not(target);
  }
}