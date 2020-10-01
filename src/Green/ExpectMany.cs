using System;
using System.Collections.Generic;

namespace Green
{
  /// <summary>
  /// A query targeting a sequence with items of type <typeparamref name="T"/> that throws <see cref="ExpectException"/> if not met
  /// </summary>
  /// <typeparam name="T">The type of items in the target sequence</typeparam>
  public struct ExpectMany<T>
  {
    readonly bool _expectedResult;

    internal ExpectMany(IEnumerable<T> target, bool expectedResult)
    {
      Target = target;
      _expectedResult = expectedResult;
    }

    /// <summary>
    /// The sequence to which this expectation applies
    /// </summary>
    public IEnumerable<T> Target { get; }

    /// <summary>
    /// Throws <see cref="ExpectException"/> if <paramref name="check"/> returns <see langword="false"/>
    /// </summary>
    /// <param name="check">The function to apply to the target sequence</param>
    /// <param name="issue">A message describing the issue if the expectation is not met</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if <paramref name="check"/> returns <see langword="false"/></exception>
    public ExpectMany<T> That(Func<IEnumerable<T>, bool> check, IssueMany<T>? issue = null)
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
    /// Returns <see langword="true"/> to enable further expectations
    /// </summary>
    public static implicit operator bool(ExpectMany<T> _) =>
      true;

    /// <summary>
    /// Returns <see langword="true"/> to enable further expectations
    /// </summary>
    public static implicit operator bool?(ExpectMany<T> _) =>
      true;
  }

  /// <summary>
  /// A query targeting a dictionary with pairs of type <typeparamref name="TKey"/> and
  /// <typeparamref name="TValue"/> that throws <see cref="ExpectException"/> if not met
  /// </summary>
  /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
  /// <typeparam name="TValue">The type of values in the target sequence</typeparam>
  public struct ExpectMany<TKey, TValue>
  {
    readonly bool _expectedResult;

    internal ExpectMany(IEnumerable<KeyValuePair<TKey, TValue>> target, bool expectedResult)
    {
      Target = target;
      _expectedResult = expectedResult;
    }

    /// <summary>
    /// The dictionary to which this expectation applies
    /// </summary>
    public IEnumerable<KeyValuePair<TKey, TValue>> Target { get; }

    /// <summary>
    /// Throws <see cref="ExpectException"/> if <paramref name="check"/> returns <see langword="false"/>
    /// </summary>
    /// <param name="check">The function to apply to the target value</param>
    /// <param name="issue">A message describing the issue if the expectation is not met</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    public ExpectMany<TKey, TValue> That(Func<IEnumerable<KeyValuePair<TKey, TValue>>, bool> check, IssueMany<TKey, TValue>? issue = null) =>
      Is(true, check, issue);

    /// <summary>
    /// Throws <see cref="ExpectException"/> if <paramref name="check"/> returns <see langword="true"/>
    /// </summary>
    /// <param name="check">The function to apply to the target value</param>
    /// <param name="issue">A message describing the issue if the expectation is not met</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if <paramref name="check"/> returns <see langword="false"/></exception>
    public ExpectMany<TKey, TValue> Not(Func<IEnumerable<KeyValuePair<TKey, TValue>>, bool> check, IssueMany<TKey, TValue>? issue = null) =>
      Is(false, check, issue);

    ExpectMany<TKey, TValue> Is(bool expectedCheckResult, Func<IEnumerable<KeyValuePair<TKey, TValue>>, bool> check, IssueMany<TKey, TValue>? issue)
    {
      if(check != null)
      {
        var result = false;

        try
        {
          result = check(Target) == expectedCheckResult;
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
    /// Returns <see langword="true"/> to enable further expectations
    /// </summary>
    public static implicit operator bool(ExpectMany<TKey, TValue> _) =>
      true;

    /// <summary>
    /// Returns <see langword="true"/> to enable further expectations
    /// </summary>
    public static implicit operator bool?(ExpectMany<TKey, TValue> _) =>
      true;
  }
}