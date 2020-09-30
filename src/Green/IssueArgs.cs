using System;
using System.Collections.Generic;
using System.Linq;

namespace Green
{
  internal class IssueArgs
  {
    internal virtual int Count => 0;
    internal virtual IEnumerable<Type> Types => Enumerable.Empty<Type>();
    internal virtual IEnumerable<object> Values => Enumerable.Empty<object>();

    internal static readonly IssueArgs None = new IssueArgs();

    internal static IssueArgs Of<TArg>(TArg arg) =>
      new IssueArgs<TArg>(arg);

    internal static IssueArgs Of<TArg0, TArg1>(TArg0 arg0, TArg1 arg1) =>
      new IssueArgs<TArg0, TArg1>(arg0, arg1);

    internal static IssueArgs Of<TArg0, TArg1, TArg2>(TArg0 arg0, TArg1 arg1, TArg2 arg2) =>
      new IssueArgs<TArg0, TArg1, TArg2>(arg0, arg1, arg2);

    internal static IssueArgs Of<TArg0, TArg1, TArg2, TArg3>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3) =>
      new IssueArgs<TArg0, TArg1, TArg2, TArg3>(arg0, arg1, arg2, arg3);

    internal static IssueArgs Of<TArg0, TArg1, TArg2, TArg3, TArg4>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4) =>
      new IssueArgs<TArg0, TArg1, TArg2, TArg3, TArg4>(arg0, arg1, arg2, arg3, arg4);

    internal static IssueArgs Of<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5) =>
      new IssueArgs<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(arg0, arg1, arg2, arg3, arg4, arg5);

    internal static IssueArgs Of<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6) =>
      new IssueArgs<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(arg0, arg1, arg2, arg3, arg4, arg5, arg6);

    internal static IssueArgs Of<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7) =>
      new IssueArgs<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
  }

  internal sealed class IssueArgs<TArg> : IssueArgs
  {
    readonly TArg _arg;

    internal IssueArgs(TArg arg) => _arg = arg;

    internal override int Count => 1;

    internal override IEnumerable<Type> Types
    {
      get { yield return typeof(TArg); }
    }

    internal override IEnumerable<object> Values
    {
      get { yield return _arg!; }
    }
  }

  internal sealed class IssueArgs<T0, T1> : IssueArgs
  {
    readonly T0 _arg0;
    readonly T1 _arg1;

    internal IssueArgs(T0 arg0, T1 arg1) =>
      (_arg0, _arg1) = (arg0, arg1);

    internal override int Count => 2;

    internal override IEnumerable<Type> Types
    {
      get
      {
        yield return typeof(T0);
        yield return typeof(T1);
      }
    }

    internal override IEnumerable<object> Values
    {
      get
      {
        yield return _arg0!;
        yield return _arg1!;
      }
    }
  }

  internal sealed class IssueArgs<T0, T1, T2> : IssueArgs
  {
    readonly T0 _arg0;
    readonly T1 _arg1;
    readonly T2 _arg2;

    internal IssueArgs(T0 arg0, T1 arg1, T2 arg2) =>
      (_arg0, _arg1, _arg2) = (arg0, arg1, arg2);

    internal override int Count => 3;

    internal override IEnumerable<Type> Types
    {
      get
      {
        yield return typeof(T0);
        yield return typeof(T1);
        yield return typeof(T2);
      }
    }

    internal override IEnumerable<object> Values
    {
      get
      {
        yield return _arg0!;
        yield return _arg1!;
        yield return _arg2!;
      }
    }
  }

  internal sealed class IssueArgs<T0, T1, T2, T3> : IssueArgs
  {
    readonly T0 _arg0;
    readonly T1 _arg1;
    readonly T2 _arg2;
    readonly T3 _arg3;

    internal IssueArgs(T0 arg0, T1 arg1, T2 arg2, T3 arg3) =>
      (_arg0, _arg1, _arg2, _arg3) = (arg0, arg1, arg2, arg3);

    internal override int Count => 4;

    internal override IEnumerable<Type> Types
    {
      get
      {
        yield return typeof(T0);
        yield return typeof(T1);
        yield return typeof(T2);
        yield return typeof(T3);
      }
    }

    internal override IEnumerable<object> Values
    {
      get
      {
        yield return _arg0!;
        yield return _arg1!;
        yield return _arg2!;
        yield return _arg3!;
      }
    }
  }

  internal sealed class IssueArgs<T0, T1, T2, T3, T4> : IssueArgs
  {
    readonly T0 _arg0;
    readonly T1 _arg1;
    readonly T2 _arg2;
    readonly T3 _arg3;
    readonly T4 _arg4;

    internal IssueArgs(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4) =>
      (_arg0, _arg1, _arg2, _arg3, _arg4) = (arg0, arg1, arg2, arg3, arg4);

    internal override int Count => 5;

    internal override IEnumerable<Type> Types
    {
      get
      {
        yield return typeof(T0);
        yield return typeof(T1);
        yield return typeof(T2);
        yield return typeof(T3);
        yield return typeof(T4);
      }
    }

    internal override IEnumerable<object> Values
    {
      get
      {
        yield return _arg0!;
        yield return _arg1!;
        yield return _arg2!;
        yield return _arg3!;
        yield return _arg4!;
      }
    }
  }

  internal sealed class IssueArgs<T0, T1, T2, T3, T4, T5> : IssueArgs
  {
    readonly T0 _arg0;
    readonly T1 _arg1;
    readonly T2 _arg2;
    readonly T3 _arg3;
    readonly T4 _arg4;
    readonly T5 _arg5;

    internal IssueArgs(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) =>
      (_arg0, _arg1, _arg2, _arg3, _arg4, _arg5) = (arg0, arg1, arg2, arg3, arg4, arg5);

    internal override int Count => 5;

    internal override IEnumerable<Type> Types
    {
      get
      {
        yield return typeof(T0);
        yield return typeof(T1);
        yield return typeof(T2);
        yield return typeof(T3);
        yield return typeof(T4);
        yield return typeof(T5);
      }
    }

    internal override IEnumerable<object> Values
    {
      get
      {
        yield return _arg0!;
        yield return _arg1!;
        yield return _arg2!;
        yield return _arg3!;
        yield return _arg4!;
        yield return _arg5!;
      }
    }
  }

  internal sealed class IssueArgs<T0, T1, T2, T3, T4, T5, T6> : IssueArgs
  {
    readonly T0 _arg0;
    readonly T1 _arg1;
    readonly T2 _arg2;
    readonly T3 _arg3;
    readonly T4 _arg4;
    readonly T5 _arg5;
    readonly T6 _arg6;

    internal IssueArgs(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) =>
      (_arg0, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6) = (arg0, arg1, arg2, arg3, arg4, arg5, arg6);

    internal override int Count => 5;

    internal override IEnumerable<Type> Types
    {
      get
      {
        yield return typeof(T0);
        yield return typeof(T1);
        yield return typeof(T2);
        yield return typeof(T3);
        yield return typeof(T4);
        yield return typeof(T5);
        yield return typeof(T6);
      }
    }

    internal override IEnumerable<object> Values
    {
      get
      {
        yield return _arg0!;
        yield return _arg1!;
        yield return _arg2!;
        yield return _arg3!;
        yield return _arg4!;
        yield return _arg5!;
        yield return _arg6!;
      }
    }
  }

  internal sealed class IssueArgs<T0, T1, T2, T3, T4, T5, T6, T7> : IssueArgs
  {
    readonly T0 _arg0;
    readonly T1 _arg1;
    readonly T2 _arg2;
    readonly T3 _arg3;
    readonly T4 _arg4;
    readonly T5 _arg5;
    readonly T6 _arg6;
    readonly T7 _arg7;

    internal IssueArgs(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) =>
      (_arg0, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7) = (arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);

    internal override int Count => 5;

    internal override IEnumerable<Type> Types
    {
      get
      {
        yield return typeof(T0);
        yield return typeof(T1);
        yield return typeof(T2);
        yield return typeof(T3);
        yield return typeof(T4);
        yield return typeof(T5);
        yield return typeof(T6);
        yield return typeof(T7);
      }
    }

    internal override IEnumerable<object> Values
    {
      get
      {
        yield return _arg0!;
        yield return _arg1!;
        yield return _arg2!;
        yield return _arg3!;
        yield return _arg4!;
        yield return _arg5!;
        yield return _arg6!;
        yield return _arg7!;
      }
    }
  }
}