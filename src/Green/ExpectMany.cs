using System;
using System.Collections.Generic;
using Green.Messages;

namespace Green
{
  public static class ExpectMany
  {
    public static ExpectMany<T> That<T>(IEnumerable<T> target) => new ExpectMany<T>(target, true);
    public static ExpectMany<T> Not<T>(IEnumerable<T> target) => new ExpectMany<T>(target, false);

    public static ExpectMany<TKey, TValue> That<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> target) => new ExpectMany<TKey, TValue>(target, true);
    public static ExpectMany<TKey, TValue> Not<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> target) => new ExpectMany<TKey, TValue>(target, false);
  }

  public struct ExpectMany<T>
  {
    readonly bool _expectedResult;

    internal ExpectMany(IEnumerable<T> target, bool expectedResult)
    {
      Target = target;
      _expectedResult = expectedResult;
    }

    public IEnumerable<T> Target { get; }

    public ExpectMany<T> That(Func<IEnumerable<T>, bool> check, IssueMany<T>? issue = null) => Is(true, check, issue);
    public ExpectMany<T> Not(Func<IEnumerable<T>, bool> check, IssueMany<T>? issue = null) => Is(false, check, issue);

    ExpectMany<T> Is(bool expectedCheckResult, Func<IEnumerable<T>, bool> check, IssueMany<T>? issue)
    {
      if(check != null)
      {
        bool result;

        try
        {
          result = check(Target) == expectedCheckResult;
        }
        //catch(ExpectException error)
        //{
        //  
        //}
        catch(Exception error)
        {
          throw new ExpectException($"Failed to apply check to target value: {Text.Of(Target)}", error);
        }

        if(result != _expectedResult)
        {
          issue.Throw(Target);
        }
      }

      return this;
    }

    public static implicit operator bool(ExpectMany<T> _) => true;
    public static implicit operator bool?(ExpectMany<T> _) => true;
  }

  public struct ExpectMany<TKey, TValue>
  {
    readonly bool _expectedResult;

    internal ExpectMany(IEnumerable<KeyValuePair<TKey, TValue>> target, bool expectedResult)
    {
      Target = target;
      _expectedResult = expectedResult;
    }

    public IEnumerable<KeyValuePair<TKey, TValue>> Target { get; }

    public ExpectMany<TKey, TValue> That(Func<IEnumerable<KeyValuePair<TKey, TValue>>, bool> check, IssueMany<TKey, TValue>? issue = null) => Is(true, check, issue);
    public ExpectMany<TKey, TValue> Not(Func<IEnumerable<KeyValuePair<TKey, TValue>>, bool> check, IssueMany<TKey, TValue>? issue = null) => Is(false, check, issue);

    ExpectMany<TKey, TValue> Is(bool expectedCheckResult, Func<IEnumerable<KeyValuePair<TKey, TValue>>, bool> check, IssueMany<TKey, TValue>? issue)
    {
      if(check != null)
      {
        bool result;

        try
        {
          result = check(Target) == expectedCheckResult;
        }
        //catch(ExpectException error)
        //{
        //  
        //}
        catch(Exception error)
        {
          throw new ExpectException($"Failed to apply check to target value: {Text.Of(Target)}", error);
        }

        if(result != _expectedResult)
        {
          issue.Throw(Target);
        }
      }

      return this;
    }

    public static implicit operator bool(ExpectMany<TKey, TValue> _) => true;
    public static implicit operator bool?(ExpectMany<TKey, TValue> _) => true;
  }
}