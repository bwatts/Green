using System;
using System.Threading.Tasks;
using Green.Messages;

namespace Green
{
  public static class Expect
  {
    public static Expect<T> That<T>(T target) => new Expect<T>(target, true);
    public static Expect<T> Not<T>(T target) => new Expect<T>(target, false);

    public static void Throws<TException>(Action target, Issue<Action>? issue = null) where TException : Exception
    {
      try
      {
        target?.Invoke();
      }
      catch(TException)
      {
        return;
      }
      catch(Exception exception)
      {
        issue = issue.ElseExpected($"Exception of type {typeof(TException)}", received: exception.GetType().ToString());

        throw new ExpectException(issue(target), exception);
      }
    }

    public static void Throws<TException>(Func<object> target, Issue<Func<object>>? issue = null) where TException : Exception =>
      Throws<TException>(() => target(), issue);

    public static void Throws(Action target, Issue<Action>? issue = null) =>
      Throws<Exception>(target, issue);

    public static void Throws(Func<object> target, Issue<Func<object>>? issue = null) =>
      Throws<Exception>(target, issue);

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
      catch(Exception exception)
      {
        issue = issue.ElseExpected($"Exception of type {typeof(TException)}", received: exception.GetType().ToString());

        throw new ExpectException(issue(target), exception);
      }
    }

    public static Task ThrowsAsync(Func<Task> target, Issue<Func<Task>>? issue = null) =>
      ThrowsAsync<Exception>(target, issue);
  }

  public struct Expect<T>
  {
    readonly bool _expectedResult;

    internal Expect(T target, bool expectedResult)
    {
      Target = target;
      _expectedResult = expectedResult;
    }

    public T Target { get; }

    public Expect<T> That(Func<T, bool> check, Issue<T>? issue = null) => Is(true, check, issue);
    public Expect<T> Not(Func<T, bool> check, Issue<T>? issue = null) => Is(false, check, issue);

    Expect<T> Is(bool expectedCheckResult, Func<T, bool> check, Issue<T>? issue)
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

    public static implicit operator bool(Expect<T> _) => true;
    public static implicit operator bool?(Expect<T> _) => true;
  }
}