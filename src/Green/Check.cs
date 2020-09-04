using System;

namespace Green
{
  /// <summary>
  /// Applies <see langword="bool"/>-valued queries to target data
  /// </summary>
  public static class Check
  {
    /// <summary>
    /// Starts a <see langword="bool"/>-valued query of <paramref name="target"/>.
    /// Returns <see langword="true"/> if all subsequent operators return <see langword="true"/>.
    /// </summary>
    /// <typeparam name="T">The type of checked value</typeparam>
    /// <param name="target">The checked value</param>
    /// <returns>A <see langword="bool"/>-valued query applied to <paramref name="target"/></returns>
    public static Check<T> That<T>(T target) =>
      new Check<T>(target, true);

    /// <summary>
    /// Starts a <see langword="bool"/>-valued query of <paramref name="target"/>.
    /// Returns <see langword="true"/> if all subsequent operators return <see langword="false"/>.
    /// </summary>
    /// <typeparam name="T">The type of checked value</typeparam>
    /// <param name="target">The checked value</param>
    /// <returns>A <see langword="bool"/>-valued query applied to <paramref name="target"/></returns>
    public static Check<T> Not<T>(T target) =>
      new Check<T>(target, false);

    internal interface ICheck<T>
    {
      T Target { get; }

      Check<T> That(Func<T, bool> next);
      Check<T> Not(Func<T, bool> next);

      bool Apply();
    }
  }

  /// <summary>
  /// A <see langword="bool"/>-valued query targeting a value of type <typeparamref name="T"/>. Implicitly converts to <see langword="bool"/>.
  /// </summary>
  /// <typeparam name="T">The type of checked value</typeparam>
  public struct Check<T> : Check.ICheck<T>
  {
    readonly bool _expectedResult;
    readonly Check.ICheck<T> _previous;
    readonly Func<T, bool> _next;
    readonly bool _expectedNext;

    internal Check(T target, bool expectedResult)
    {
      Target = target;
      _expectedResult = expectedResult;
      _previous = null;
      _next = null;
      _expectedNext = false;
    }

    Check(T target, bool expectedResult, Func<T, bool> next, bool expectedNext)
    {
      Target = target;
      _expectedResult = expectedResult;
      _previous = null;
      _next = next;
      _expectedNext = expectedNext;
    }

    Check(Check<T> previous, Func<T, bool> next, bool expectedNext)
    {
      Target = previous.Target;
      _expectedResult = previous._expectedResult;
      _previous = previous;
      _next = next;
      _expectedNext = expectedNext;
    }

    Check(Check<T> notted)
    {
      Target = notted.Target;
      _expectedResult = !notted._expectedResult;
      _previous = notted._previous;
      _next = notted._next;
      _expectedNext = notted._expectedNext;
    }

    /// <summary>
    /// The value to which this check applies
    /// </summary>
    public T Target { get; }

    /// <summary>
    /// Continues this <see langword="bool"/>-valued query. Returns <see langword="true"/> if
    /// <paramref name="next"/> returns <see langword="true"/>.
    /// </summary>
    /// <param name="next">The next function to apply when applying this check</param>
    /// <returns>A continuation of this check that applies <paramref name="next"/></returns>
    public Check<T> That(Func<T, bool> next) =>
      Is(true, next);

    /// <summary>
    /// Continues this <see langword="bool"/>-valued query. Returns <see langword="true"/> if
    /// <paramref name="next"/> returns <see langword="false"/>.
    /// </summary>
    /// <param name="next">The next function to apply when applying this check</param>
    /// <returns>A continuation of this check that applies <paramref name="next"/></returns>
    public Check<T> Not(Func<T, bool> next) =>
      Is(false, next);

    /// <summary>
    /// Negates this this <see langword="bool"/>-valued query. Returns <see langword="true"/> if
    /// this check returns <see langword="false"/>.
    /// </summary>
    /// <returns>A negation of this check</returns>
    public Check<T> Not() =>
      new Check<T>(this);

    Check<T> Is(bool expected, Func<T, bool> next) =>
      _next != null
        ? new Check<T>(this, next, expected)
        : new Check<T>(Target, _expectedResult, next, expected);

    /// <summary>
    /// Applies this check to the target value
    /// </summary>
    /// <returns>The result of applying this check to the target value</returns>
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
    public static implicit operator bool(Check<T> check) => check.Apply();

    /// <summary>
    /// Implicitly applies <paramref name="check"/> and returns the result
    /// </summary>
    /// <param name="check">The check to implicitly apply</param>
    public static implicit operator bool?(Check<T> check) => check.Apply();
  }
}