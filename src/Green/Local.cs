using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
      Green.Check.Many(target);

    /// <summary>
    /// Starts a <see langword="bool"/>-valued query of <paramref name="target"/> that returns
    /// <see langword="true"/> if all subsequent operators return <see langword="false"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="target">The sequence to which the check applies</param>
    /// <returns>A <see langword="bool"/>-valued query applied to <paramref name="target"/></returns>
    public static CheckMany<T> CheckManyNot<T>(IEnumerable<T> target) =>
      Green.Check.ManyNot(target);

    /// <summary>
    /// Starts a <see langword="bool"/>-valued query of <paramref name="target"/> that returns
    /// <see langword="true"/> if all subsequent operators return <see langword="true"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="target">The dictionary to which the check applies</param>
    /// <returns>A <see langword="bool"/>-valued query applied to <paramref name="target"/></returns>
    public static CheckMany<TKey, TValue> CheckMany<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> target) =>
      Green.Check.Many(target);

    /// <summary>
    /// Starts a <see langword="bool"/>-valued query of <paramref name="target"/> that returns
    /// <see langword="true"/> if all subsequent operators are <see langword="false"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the target dictionary</typeparam>
    /// <param name="target">The dictionary to which the check applies</param>
    /// <returns>A <see langword="bool"/>-valued query applied to <paramref name="target"/></returns>
    public static CheckMany<TKey, TValue> CheckManyNot<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> target) =>
      Green.Check.ManyNot(target);

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
      Green.Expect.Many(target);

    /// <summary>
    /// Starts a query of <paramref name="target"/> that throws <see cref="ExpectException"/> if any subseqeuent
    /// operator returns <see langword="true"/>
    /// </summary>
    /// <typeparam name="T">The type of expected sequence</typeparam>
    /// <param name="target">The expected sequence</param>
    /// <returns>An expectation applied to <paramref name="target"/></returns>
    public static ExpectMany<T> ExpectManyNot<T>(IEnumerable<T> target) =>
      Green.Expect.ManyNot(target);

    /// <summary>
    /// Starts a query of <paramref name="target"/> that throws <see cref="ExpectException"/> if any subseqeuent
    /// operator returns <see langword="false"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the expected dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the expected dictionary</typeparam>
    /// <param name="target">The expected dictionary</param>
    /// <returns>An expectation applied to <paramref name="target"/></returns>
    public static ExpectMany<TKey, TValue> ExpectMany<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> target) =>
      Green.Expect.Many(target);

    /// <summary>
    /// Starts a query of <paramref name="target"/> that throws <see cref="ExpectException"/> if any subseqeuent
    /// operator returns <see langword="true"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the expected dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the expected dictionary</typeparam>
    /// <param name="target">The expected dictionary</param>
    /// <returns>An expectation applied to <paramref name="target"/></returns>
    public static ExpectMany<TKey, TValue> ExpectManyNot<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> target) =>
      Green.Expect.ManyNot(target);

    //
    // Throws
    //

    /// <summary>
    /// Throws <see cref="ExpectException"/> if <paramref name="target"/> does not throw <typeparamref name="TException"/>
    /// </summary>
    /// <typeparam name="TException">The type of exception to expect</typeparam>
    /// <param name="target">The action that is expected to throw <typeparamref name="TException"/></param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <exception cref="ExpectException">Thrown if <paramref name="target"/> does not throw <typeparamref name="TException"/></exception>
    public static void Throws<TException>(Action target, Issue<Action>? issue = null) where TException : Exception =>
      Green.Expect.Throws<TException>(target, issue);

    /// <summary>
    /// Throws <see cref="ExpectException"/> if <paramref name="target"/> does not throw <typeparamref name="TException"/>
    /// </summary>
    /// <typeparam name="TException">The type of exception to expect</typeparam>
    /// <param name="target">The function that is expected to throw <typeparamref name="TException"/></param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <exception cref="ExpectException">Thrown if <paramref name="target"/> does not throw <typeparamref name="TException"/></exception>
    public static void Throws<TException>(Func<object> target, Issue<Func<object>>? issue = null) where TException : Exception =>
      Green.Expect.Throws<TException>(target, issue);

    /// <summary>
    /// Throws <see cref="ExpectException"/> if <paramref name="target"/> does not throw <typeparamref name="TException"/>
    /// </summary>
    /// <typeparam name="TException">The type of exception to expect</typeparam>
    /// <param name="target">The function that is expected to throw <typeparamref name="TException"/></param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <exception cref="ExpectException">Thrown if <paramref name="target"/> does not throw <typeparamref name="TException"/></exception>
    /// <returns>An asynchronous invocation of <paramref name="target"/></returns>
    public static Task ThrowsAsync<TException>(Func<Task> target, Issue<Func<Task>>? issue = null) where TException : Exception =>
      Green.Expect.ThrowsAsync<TException>(target, issue);

    /// <summary>
    /// Throws <see cref="ExpectException"/> if <paramref name="target"/> does not throw an exception
    /// </summary>
    /// <param name="target">The action that is expected to throw an exception</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <exception cref="ExpectException">Thrown if <paramref name="target"/> does not throw an exception</exception>
    public static void Throws(Action target, Issue<Action>? issue = null) =>
      Green.Expect.Throws(target, issue);

    /// <summary>
    /// Throws <see cref="ExpectException"/> if <paramref name="target"/> does not throw an exception
    /// </summary>
    /// <param name="target">The function that is expected to throw an exception</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <exception cref="ExpectException">Thrown if <paramref name="target"/> does not throw an exception</exception>
    public static void Throws(Func<object> target, Issue<Func<object>>? issue = null) =>
      Green.Expect.Throws(target, issue);

    /// <summary>
    /// Throws <see cref="ExpectException"/> if <paramref name="target"/> does not throw an exception
    /// </summary>
    /// <param name="target">The function that is expected to throw an exception</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <exception cref="ExpectException">Thrown if <paramref name="target"/> does not throw an exception</exception>
    /// <returns>An asynchronous invocation of <paramref name="target"/></returns>
    public static Task ThrowsAsync(Func<Task> target, Issue<Func<Task>>? issue = null) =>
      Green.Expect.ThrowsAsync(target, issue);
  }
}