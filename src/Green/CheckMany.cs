using System;
using System.Collections.Generic;

namespace Green
{
  /// <summary>
  /// Applies <see langword="bool"/>-valued queries to sequences of target data
  /// </summary>
  public static class CheckMany
  {
    /// <summary>
    /// Starts a <see langword="bool"/>-valued query of <paramref name="target"/>.
    /// Returns <see langword="true"/> if all subsequent operators return <see langword="true"/>.
    /// </summary>
    /// <typeparam name="T">The type of items in the checked sequence</typeparam>
    /// <param name="target">The checked sequence</param>
    /// <returns>A <see langword="bool"/>-valued query applied to <paramref name="target"/></returns>
    public static CheckMany<T> That<T>(IEnumerable<T> target) =>
      new CheckMany<T>(target, true);

    /// <summary>
    /// Starts a <see langword="bool"/>-valued query of <paramref name="target"/>.
    /// Returns <see langword="true"/> if all subsequent operators return <see langword="false"/>.
    /// </summary>
    /// <typeparam name="T">The type of items in the checked sequence</typeparam>
    /// <param name="target">The checked sequence</param>
    /// <returns>A <see langword="bool"/>-valued query applied to <paramref name="target"/></returns>
    public static CheckMany<T> Not<T>(IEnumerable<T> target) =>
      new CheckMany<T>(target, false);

    /// <summary>
    /// Starts a <see langword="bool"/>-valued query of <paramref name="target"/>.
    /// Returns <see langword="true"/> if all subsequent operators return <see langword="true"/>.
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the checked dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the checked dictionary</typeparam>
    /// <param name="target">The checked dictionary</param>
    /// <returns>A <see langword="bool"/>-valued query applied to <paramref name="target"/></returns>
    public static CheckMany<TKey, TValue> That<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> target) =>
      new CheckMany<TKey, TValue>(target, true);

    /// <summary>
    /// Starts a <see langword="bool"/>-valued query of <paramref name="target"/>.
    /// Evaluates to <see langword="true"/> if all subsequent operators are <see langword="false"/>.
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the checked dictionary</typeparam>
    /// <typeparam name="TValue">The type of values in the checked dictionary</typeparam>
    /// <param name="target">The checked dictionary</param>
    /// <returns>A <see langword="bool"/>-valued query applied to <paramref name="target"/></returns>
    public static CheckMany<TKey, TValue> Not<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> target) =>
      new CheckMany<TKey, TValue>(target, false);

    internal interface ICheckMany<T>
    {
      IEnumerable<T> Target { get; }

      CheckMany<T> That(Func<IEnumerable<T>, bool> next);
      CheckMany<T> Not(Func<IEnumerable<T>, bool> next);

      bool Apply();
    }

    internal interface ICheckMany<TKey, TValue>
    {
      IEnumerable<KeyValuePair<TKey, TValue>> Target { get; }

      CheckMany<TKey, TValue> That(Func<IEnumerable<KeyValuePair<TKey, TValue>>, bool> next);
      CheckMany<TKey, TValue> Not(Func<IEnumerable<KeyValuePair<TKey, TValue>>, bool> next);

      bool Apply();
    }
  }

  /// <summary>
  /// A <see langword="bool"/>-valued query targeting a sequence with items of type <typeparamref name="T"/>. Implicitly converts to <see langword="bool"/>.
  /// </summary>
  /// <typeparam name="T">The type of items in the checked sequence</typeparam>
  public struct CheckMany<T> : CheckMany.ICheckMany<T>
  {
    readonly bool _expectedResult;
    readonly CheckMany.ICheckMany<T> _previous;
    readonly Func<IEnumerable<T>, bool> _next;
    readonly bool _expectedNext;

    internal CheckMany(IEnumerable<T> target, bool expectedResult)
    {
      Target = target;
      _expectedResult = expectedResult;
      _previous = null;
      _next = null;
      _expectedNext = false;
    }

    CheckMany(IEnumerable<T> target, bool expectedResult, Func<IEnumerable<T>, bool> next, bool expectedNext)
    {
      Target = target;
      _expectedResult = expectedResult;
      _previous = null;
      _next = next;
      _expectedNext = expectedNext;
    }

    CheckMany(CheckMany<T> previous, Func<IEnumerable<T>, bool> next, bool expectedNext)
    {
      Target = previous.Target;
      _expectedResult = previous._expectedResult;
      _previous = previous;
      _next = next;
      _expectedNext = expectedNext;
    }

    CheckMany(CheckMany<T> notted)
    {
      Target = notted.Target;
      _expectedResult = !notted._expectedResult;
      _previous = notted._previous;
      _next = notted._next;
      _expectedNext = notted._expectedNext;
    }

    /// <summary>
    /// The sequence to which this check applies
    /// </summary>
    public IEnumerable<T> Target { get; }

    /// <summary>
    /// Continues this <see langword="bool"/>-valued query. Returns <see langword="true"/> if
    /// <paramref name="next"/> returns <see langword="true"/>.
    /// </summary>
    /// <param name="next">The next function to apply when applying this check</param>
    /// <returns>A continuation of this check that applies <paramref name="next"/></returns>
    public CheckMany<T> That(Func<IEnumerable<T>, bool> next) => Is(true, next);

    /// <summary>
    /// Continues this <see langword="bool"/>-valued query. Returns <see langword="true"/> if
    /// <paramref name="next"/> returns <see langword="false"/>.
    /// </summary>
    /// <param name="next">The next function to apply when applying this check</param>
    /// <returns>A continuation of this check that applies <paramref name="next"/></returns>
    public CheckMany<T> Not(Func<IEnumerable<T>, bool> next) => Is(false, next);

    /// <summary>
    /// Negates this this <see langword="bool"/>-valued query. Returns <see langword="true"/> if
    /// this check returns <see langword="false"/>.
    /// </summary>
    /// <returns>A negation of this check</returns>
    public CheckMany<T> Not() => new CheckMany<T>(this);

    CheckMany<T> Is(bool expected, Func<IEnumerable<T>, bool> next) =>
      _next != null
        ? new CheckMany<T>(this, next, expected)
        : new CheckMany<T>(Target, _expectedResult, next, expected);

    /// <summary>
    /// Applies this check to the target sequence
    /// </summary>
    /// <returns>The result of applying this check to the target sequence</returns>
    public bool Apply()
    {
      if(_previous != null && _next != null)
      {
        return _previous.Apply() && (_next(Target) == _expectedNext) == _expectedResult;
      }
      else if(_previous != null)
      {
        return _previous.Apply() == _expectedResult;
      }
      else if(_next != null)
      {
        return (_next(Target) == _expectedNext) == _expectedResult;
      }
      else
      {
        return true;
      }
    }

    /// <summary>
    /// Implicitly applies <paramref name="check"/> and returns the result
    /// </summary>
    /// <param name="check">The check to implicitly apply</param>
    public static implicit operator bool(CheckMany<T> check) => check.Apply();

    /// <summary>
    /// Implicitly applies <paramref name="check"/> and returns the result
    /// </summary>
    /// <param name="check">The check to implicitly apply</param>
    public static implicit operator bool?(CheckMany<T> check) => check.Apply();
  }

  /// <summary>
  /// A <see langword="bool"/>-valued query targeting a dictionary with keys of type <typeparamref name="TKey"/>
  /// and values of type <typeparamref name="TValue"/>. Implicitly converts to <see langword="bool"/>.
  /// </summary>
  /// <typeparam name="TKey">The type of keys in the checked dictionary</typeparam>
  /// <typeparam name="TValue">The type of values in the checked dictionary</typeparam>
  public struct CheckMany<TKey, TValue> : CheckMany.ICheckMany<TKey, TValue>
  {
    readonly bool _expectedResult;
    readonly CheckMany.ICheckMany<TKey, TValue> _previous;
    readonly Func<IEnumerable<KeyValuePair<TKey, TValue>>, bool> _next;
    readonly bool _expectedNext;

    internal CheckMany(IEnumerable<KeyValuePair<TKey, TValue>> target, bool expectedResult)
    {
      Target = target;
      _expectedResult = expectedResult;
      _previous = null;
      _next = null;
      _expectedNext = false;
    }

    CheckMany(IEnumerable<KeyValuePair<TKey, TValue>> target, bool expectedResult, Func<IEnumerable<KeyValuePair<TKey, TValue>>, bool> next, bool expectedNext)
    {
      Target = target;
      _expectedResult = expectedResult;
      _previous = null;
      _next = next;
      _expectedNext = expectedNext;
    }

    CheckMany(CheckMany<TKey, TValue> previous, Func<IEnumerable<KeyValuePair<TKey, TValue>>, bool> next, bool expectedNext)
    {
      Target = previous.Target;
      _expectedResult = previous._expectedResult;
      _previous = previous;
      _next = next;
      _expectedNext = expectedNext;
    }

    CheckMany(CheckMany<TKey, TValue> notted)
    {
      Target = notted.Target;
      _expectedResult = !notted._expectedResult;
      _previous = notted._previous;
      _next = notted._next;
      _expectedNext = notted._expectedNext;
    }

    /// <summary>
    /// The dictionary to which this check applies
    /// </summary>
    public IEnumerable<KeyValuePair<TKey, TValue>> Target { get; }

    /// <summary>
    /// Continues this <see langword="bool"/>-valued query. Returns <see langword="true"/> if
    /// <paramref name="next"/> returns <see langword="true"/>.
    /// </summary>
    /// <param name="next">The next function to apply when applying this check</param>
    /// <returns>A continuation of this check that applies <paramref name="next"/></returns>
    public CheckMany<TKey, TValue> That(Func<IEnumerable<KeyValuePair<TKey, TValue>>, bool> next) => Is(true, next);

    /// <summary>
    /// Continues this <see langword="bool"/>-valued query. Returns <see langword="true"/> if
    /// <paramref name="next"/> returns <see langword="false"/>.
    /// </summary>
    /// <param name="next">The next function to apply when applying this check</param>
    /// <returns>A continuation of this check that applies <paramref name="next"/></returns>
    public CheckMany<TKey, TValue> Not(Func<IEnumerable<KeyValuePair<TKey, TValue>>, bool> next) => Is(false, next);

    /// <summary>
    /// Negates this this <see langword="bool"/>-valued query. Returns <see langword="true"/> if
    /// this check returns <see langword="false"/>.
    /// </summary>
    /// <returns>A negation of this check</returns>
    public CheckMany<TKey, TValue> Not() => new CheckMany<TKey, TValue>(this);

    CheckMany<TKey, TValue> Is(bool expected, Func<IEnumerable<KeyValuePair<TKey, TValue>>, bool> next) =>
      _next != null
        ? new CheckMany<TKey, TValue>(this, next, expected)
        : new CheckMany<TKey, TValue>(Target, _expectedResult, next, expected);

    /// <summary>
    /// Applies this check to the target dictionary
    /// </summary>
    /// <returns>The result of applying this check to the target dictionary</returns>
    public bool Apply()
    {
      if(_previous != null && _next != null)
      {
        return _previous.Apply() && (_next(Target) == _expectedNext) == _expectedResult;
      }
      else if(_previous != null)
      {
        return _previous.Apply() == _expectedResult;
      }
      else if(_next != null)
      {
        return (_next(Target) == _expectedNext) == _expectedResult;
      }
      else
      {
        return true;
      }
    }

    /// <summary>
    /// Implicitly applies <paramref name="check"/> and returns the result
    /// </summary>
    /// <param name="check">The check to implicitly apply</param>
    public static implicit operator bool(CheckMany<TKey, TValue> check) => check.Apply();

    /// <summary>
    /// Implicitly applies <paramref name="check"/> and returns the result
    /// </summary>
    /// <param name="check">The check to implicitly apply</param>
    public static implicit operator bool?(CheckMany<TKey, TValue> check) => check.Apply();
  }
}