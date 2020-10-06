using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Green
{
  /// <summary>
  /// Applies queries to target values that throw <see cref="ExpectException"/> if not met
  /// </summary>
  public static class Expect
  {
    /// <summary>
    /// Starts a query of <paramref name="target"/> that throws <see cref="ExpectException"/> if any subsequent operator returns <see langword="false"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="target">The value to which the expectation applies</param>
    /// <returns>An expectation applied to <paramref name="target"/></returns>
    public static Expect<T> That<T>(T target) =>
      new Expect<T>(target, true);

    /// <summary>
    /// Starts a query of <paramref name="target"/> that throws <see cref="ExpectException"/> if any subsequent operator returns <see langword="true"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="target">The value to which the expectation applies</param>
    /// <returns>An expectation applied to <paramref name="target"/></returns>
    public static Expect<T> Not<T>(T target) =>
      new Expect<T>(target, false);

    /// <summary>
    /// Starts a query of <paramref name="target"/> that throws <see cref="ExpectException"/> if any subseqeuent operator returns <see langword="false"/>
    /// </summary>
    /// <typeparam name="T">The type of expected sequence</typeparam>
    /// <param name="target">The expected sequence</param>
    /// <returns>An expectation applied to <paramref name="target"/></returns>
    public static ExpectMany<T> Many<T>(IEnumerable<T> target) =>
      new ExpectMany<T>(target, true);

    /// <summary>
    /// Starts a query of <paramref name="target"/> that throws <see cref="ExpectException"/> if any subseqeuent operator returns <see langword="true"/>
    /// </summary>
    /// <typeparam name="T">The type of expected sequence</typeparam>
    /// <param name="target">The expected sequence</param>
    /// <returns>An expectation applied to <paramref name="target"/></returns>
    public static ExpectMany<T> ManyNot<T>(IEnumerable<T> target) =>
      new ExpectMany<T>(target, false);

    /// <summary>
    /// Starts a query of <paramref name="target"/> that throws <see cref="ExpectException"/> if any subseqeuent operator returns <see langword="false"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the expected dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the expected dictionary</typeparam>
    /// <param name="target">The expected dictionary</param>
    /// <returns>An expectation applied to <paramref name="target"/></returns>
    public static ExpectMany<TKey, TValue> Many<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> target) =>
      new ExpectMany<TKey, TValue>(target, true);

    /// <summary>
    /// Starts a query of <paramref name="target"/> that throws <see cref="ExpectException"/> if any subseqeuent operator returns <see langword="true"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the expected dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the expected dictionary</typeparam>
    /// <param name="target">The expected dictionary</param>
    /// <returns>An expectation applied to <paramref name="target"/></returns>
    public static ExpectMany<TKey, TValue> ManyNot<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> target) =>
      new ExpectMany<TKey, TValue>(target, false);

    /// <summary>
    /// Throws <see cref="ExpectException"/> if <paramref name="target"/> does not throw <typeparamref name="TException"/>
    /// </summary>
    /// <typeparam name="TException">The type of exception to expect</typeparam>
    /// <param name="target">The action that is expected to throw <typeparamref name="TException"/></param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <exception cref="ExpectException">Thrown if <paramref name="target"/> does not throw <typeparamref name="TException"/></exception>
    public static void Throws<TException>(Action target, Issue<Action>? issue = null) where TException : Exception
    {
      try
      {
        target.Invoke();
      }
      catch(TException)
      {
        return;
      }
      catch(Exception inner)
      {
        throw issue.ToThrowsException(target, typeof(TException), inner);
      }

      throw issue.ToThrowsException(target, typeof(TException));
    }

    /// <summary>
    /// Throws <see cref="ExpectException"/> if <paramref name="target"/> does not throw <typeparamref name="TException"/>
    /// </summary>
    /// <typeparam name="TException">The type of exception to expect</typeparam>
    /// <param name="target">The function that is expected to throw <typeparamref name="TException"/></param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <exception cref="ExpectException">Thrown if <paramref name="target"/> does not throw <typeparamref name="TException"/></exception>
    public static void Throws<TException>(Func<object> target, Issue<Func<object>>? issue = null) where TException : Exception
    {
      try
      {
        target.Invoke();
      }
      catch(TException)
      {
        return;
      }
      catch(Exception inner)
      {
        throw issue.ToThrowsException(target, typeof(TException), inner);
      }

      throw issue.ToThrowsException(target, typeof(TException));
    }

    /// <summary>
    /// Throws <see cref="ExpectException"/> if <paramref name="target"/> does not throw <typeparamref name="TException"/>
    /// </summary>
    /// <typeparam name="TException">The type of exception to expect</typeparam>
    /// <param name="target">The function that is expected to throw <typeparamref name="TException"/></param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <exception cref="ExpectException">Thrown if <paramref name="target"/> does not throw <typeparamref name="TException"/></exception>
    /// <returns>An asynchronous invocation of <paramref name="target"/></returns>
    public static async Task ThrowsAsync<TException>(Func<Task> target, Issue<Func<Task>>? issue = null) where TException : Exception
    {
      try
      {
        await target.Invoke();
      }
      catch(TException)
      {
        return;
      }
      catch(Exception inner)
      {
        throw issue.ToThrowsAsyncException(target, typeof(TException), inner);
      }

      throw issue.ToThrowsAsyncException(target, typeof(TException));
    }

    /// <summary>
    /// Throws <see cref="ExpectException"/> if <paramref name="target"/> does not throw an exception
    /// </summary>
    /// <param name="target">The action that is expected to throw an exception</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <exception cref="ExpectException">Thrown if <paramref name="target"/> does not throw an exception</exception>
    public static void Throws(Action target, Issue<Action>? issue = null) =>
      Throws<Exception>(target, issue);

    /// <summary>
    /// Throws <see cref="ExpectException"/> if <paramref name="target"/> does not throw an exception
    /// </summary>
    /// <param name="target">The function that is expected to throw an exception</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <exception cref="ExpectException">Thrown if <paramref name="target"/> does not throw an exception</exception>
    public static void Throws(Func<object> target, Issue<Func<object>>? issue = null) =>
      Throws<Exception>(target, issue);

    /// <summary>
    /// Throws <see cref="ExpectException"/> if <paramref name="target"/> does not throw an exception
    /// </summary>
    /// <param name="target">The function that is expected to throw an exception</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <exception cref="ExpectException">Thrown if <paramref name="target"/> does not throw an exception</exception>
    /// <returns>An asynchronous invocation of <paramref name="target"/></returns>
    public static Task ThrowsAsync(Func<Task> target, Issue<Func<Task>>? issue = null) =>
      ThrowsAsync<Exception>(target, issue);
  }

  /// <summary>
  /// A query targeting a value of type <typeparamref name="T"/> that throws <see cref="ExpectException"/> if not met
  /// </summary>
  /// <typeparam name="T">The type of target value</typeparam>
  public struct Expect<T>
  {
    readonly bool _expectedResult;

    internal Expect(T target, bool expectedResult)
    {
      Target = target;
      _expectedResult = expectedResult;
    }

    /// <summary>
    /// The value to which this expectation applies
    /// </summary>
    public T Target { get; }

    /// <summary>
    /// Throws <see cref="ExpectException"/> if <paramref name="check"/> returns <see langword="false"/>
    /// </summary>
    /// <param name="check">The function to apply to the target value</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if <paramref name="check"/> returns <see langword="false"/></exception>
    public Expect<T> That(Func<T, bool> check, Issue<T>? issue = null)
    {
      if(check != null)
      {
        var result = false;

        try
        {
          result = check(Target);
        }
        catch(Exception inner)
        {
          throw issue.ToException(Target, _expectedResult, inner);
        }

        if(result != _expectedResult)
        {
          throw issue.ToException(Target, _expectedResult);
        }
      }

      return this;
    }

    /// <summary>
    /// Returns <see langword="true"/> to enable further expectations in expressions
    /// </summary>
    public static implicit operator bool(Expect<T> _) =>
      true;

    /// <summary>
    /// Returns <see langword="true"/> to enable further expectations in expressions
    /// </summary>
    public static implicit operator bool?(Expect<T> _) =>
      true;
  }
}