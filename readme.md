![Green](logo.png)

<br/>

Green is a standalone [.NET Standard 2.1 library](https://www.nuget.org/packages/Green) focused on **applying Boolean functions to target data**.

Ask better questions with [checks](#21-checks) and [expectations](#22-expectations)!

## Purpose

Green is inspired by assertions in automated tests. Testing is fundamentally about asking questions, yet asking questions is not *only* for testing. We deserve to wield these concepts in shipped code.

That said, expectations are really useful in tests.

## Contents

* [1. Quick Start](#1-quick-start)
  * [1.1. Install](#11-install)
  * [1.2. Add to the local scope](#12-add-to-the-local-scope)
* [2. Core Features](#2-core-features)
  * [2.1. Checks](#21-checks)
  * [2.2. Expectations](#22-expectations)
  * [2.3. Collections](#23-collections)
  * [2.4. Not](#24-not)
  * [2.5. Extensibility](#25-extensibility)
* [3. Check Types](#3-check-tyeps)
  * [3.1. `Check`](#31-check)
  * [3.2. `Check<T>`](#32-check-t)
  * [3.3. `CheckMany<T>`](#33-checkmany-t)
  * [3.4. `CheckMany<TKey, TValue>`](#34-checkmany-tkey-tvalue)
* [4. Expect Types](#4-expect-types) 
  * [4.1. `Expect`](#41-expect)
  * [4.2. `Expect<T>`](#42-expect-t)
  * [4.3. `ExpectMany<T>`](#43-expectmany-t)
  * [4.4. `ExpectMany<TKey, TValue>`](#44-expectmany-tkey-tvalue)
* [5. Issue Types](#5-issue-tyeps) 
  * [5.1. `Issue<T>`](#51-issue-t)
  * [5.2. `IssueMany<T>`](#52-issuemany-t)
  * [5.3. `IssueMany<TKey, TValue>`](#53-issuemany-tkey-tvalue)
  * [5.4. `IssueResult`](#54-issueresult)
* [6. Operators](#6-operators)
  

## 1. Quick Start

### 1.1. Install

Green is a [.NET Standard 2.1 package](https://www.nuget.org/packages/Green) available on NuGet:

```bash
dotnet add package Green
```

It is under the [MIT license](license.txt) and, like knowledge, wants to be free.

### 1.2. Add to the local scope

```C#
using static Green.Local;
```

## 2. Core Features

### 2.1. Checks

A check applies a **Boolean function** to a target value:

```C#
if(Check(ch).IsDigit())
{
  // ...
}
```

Checks **compose and defer application** until evaluated:

```C#
Check<string> check = Check(str).StartsWith("A").HasLength(6);

if(-condition-)
{
  check = check.EndsWith("Z");
}

if(check)
{
  // ...
}
```

The `if` statement takes advantage of an **implicit conversion to Boolean:**

```C#
if(Check(n).IsPositive().IsEven() || Check(ch).IsLetter().IsLower())
```

### 2.2. Expectations

An expectation applies a **Boolean function** to a target value and **throws an exception** if not met:

```C#
try
{
  Expect("ABC").StartsWith("B");
}
catch(ExpectException x)
{
  Console.WriteLine(x);
}
```

Messages format **parameter names and runtime values** in both **debug and release** builds:

> ```
> Unexpected value: Expect("ABC").StartsWith(value: "B")
>
> at Green.Expectable.StartsWith(Expect`1 expect, String value, Issue`1 issue)
> at YourProject.BadCode() in C:\YourProject\BadCode.cs:line 91
> at YourProject.UsesBadCode() in C:\YourProject\UsesBadCode.cs:line 127
> at YourProject.Tests.FailingTest() in C:\YourProject\Tests.cs:line 42
> ```

Expectations **compose but run immediately:**

```C#
Expect("ABC").StartsWith("A").EndsWith("Z");
```

> `Unexpected value: Expect("ABC").EndsWith(value: "Z")`

They also support **custom messages**:

```C#
Expect(wakeupCall.Hours).IsAtLeast(acceptableTime, hours => $"{hours}am is too early")
```

> `6am is too early: Expect(6).IsAtLeast(minimum: 8)`

It is also possible to **expect exceptions:**

```C#
ExpectThrows<CustomException>(() => {});
```

> `Unexpected success: ExpectThrows<CustomException>(<BadCode>b__1_0)`

## 2.3. Collections

Assertion libraries struggle to ask questions of plural data. Sequences and dictionaries get some attention, but the operators and abstractions often feel superficial and of limited use. Workarounds generally involve breaking down the data structure and testing individual pieces.

Green provides **comprehensive checks and expectations for collections**. The *Many* suffix denotes API surfaces for sequences and dictionaries:

```C#
CheckMany(sequence).HasSameInOrder(other)
CheckMany(dictionary).HasKeys(keys).HasValues(values)
```

Particularly useful are `Has1` through `Has8`, which **pass corresponding items** for further inspection:

```C#
CheckMany(sequence).Has2((item0, item1) =>
  Check(item0).IsCloseTo(item1, precision: 0.01))
```

**Nested expectations** become inner exceptions:

```C#
ExpectMany(sequence).Has2((item0, item1) =>
{
  Expect(item0).IsGreaterThan(20);
  Expect(item1).IsNegative().IsNotMinValue();
});
```

> ```
> Unexpected value: ExpectMany([1, 5]).Has2(expectItems: <BadCode>b__2_0)
> ---- Unexpected value: Expect(1).IsGreaterThan(value: 20)
>    at Green.Expectable.IsGreaterThan[T](Expect`1 expect, T value, Issue`1 issue)
>    at YourProject.BadCode() in C:\YourProject\BadCode.cs:line 93
>    at YourProject.UsesBadCode() in C:\YourProject\UsesBadCode.cs:line 127
>    at YourProject.Tests.FailingTest() in C:\YourProject\Tests.cs:line 42
>
> --- End of inner exception stack trace ---
>    at Green.Expectable.Has2[T](ExpectMany`1 expect, Action`2 expectItems, IssueMany`1 issue)
>    at YourProject.BadCode() in C:\YourProject\BadCode.cs:line 91
>    at YourProject.UsesBadCode() in C:\YourProject\UsesBadCode.cs:line 127
>    at YourProject.Tests.FailingTest() in C:\YourProject\Tests.cs:line 42
> ```

## 2.4. Not

Thus far `true` has meant *success*. The *Not* suffix **expects false** from every operator:

```C#
CheckNot('A').IsDigit().IsUpper()
```

This is equivalent to `!(IsDigit || IsUpper)`. `'A'` is not a digit, but *is* uppercase, so the result is `false`.

Checks also support a unary `Not` which **flips the expected result:**

```C#
Check<char> lowercaseLetter = Check('A').IsLetter().IsLower();
Check<char> notLowercaseLetter = check.Not();

if(lowercaseLetter)    // false
if(notLowercaseLetter) // true
```

Expectations also work with *Not* suffix:

```C#
ExpectNot('A').IsDigit().IsUpper()
```

> `Unexpected value: ExpectNot('A').IsUpper()`

However, because expectations run immediately, there is no unary `Not`.

## 2.5. Extensibility

Green has extensibility **in its DNA**. All checks and expectations use the same mechanisms available to consumers.

For example, this is the definition of the [`IsNull`](src/Green/Checkable.cs) check:

```C#
public static Check<T> IsNull<T>(this Check<T> check) where T : class =>
  check.That(t => t == null);
```

The corresponding [`IsNull`](src/Green/Expectable.cs) expectation includes an optional [`Issue<T>`](#51-issue-t) delegate that provides a message:

```C#
public static Expect<T> IsNull<T>(this Expect<T> expect, Issue<T>? issue = null) where T : class =>
  expect.That(t => t == null, issue.Operator());
```

The [`Operator`](src/Green/Issuable.cs) extension method tells Green this stack frame is an operator, enabling the formatted messages.

Expectations with parameters provide the runtime arguments for formatting:

```C#
public static Expect<double> IsCloseTo(this Expect<double> expect, double value, double precision, Issue<double>? issue = null) =>
  expect.That(t => Math.Abs(t - value) <= precision, issue.Operator(value, precision));
```

*NOTE: Green opts into nullable reference types. This does not affect consumers but is valuable in other opted-in codebases.*

## 3. Check Types

### 3.1. [`Check`](src/Green/Check.cs)

This static class is the factory for all check types:

```C#
public static Check<T> That<T>(T target);
public static Check<T> Not<T>(T target);

public static CheckMany<T> Many<T>(IEnumerable<T> target)
public static CheckMany<T> ManyNot<T>(IEnumerable<T> target)

public static CheckMany<TKey, TValue> Many<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> target)
public static CheckMany<TKey, TValue> ManyNot<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> target)
```

Its methods are available in the [local scope](#12-add-to-the-local-scope):

| Static method | Local method   |
|---------------|:---------------|
| That          | Check          |
| Not           | CheckNot       |
| Many          | CheckMany      |
| ManyNot       | CheckManyNot   |

### 3.2. [`Check<T>`](src/Green/Check.cs)

Applies one or more checks to a target value:

```C#
public T Target { get; }
public Check<T> That(Func<T, bool> next)
public Check<T> Not(Func<T, bool> next)
public Check<T> Not()
public bool Apply()

public static implicit operator bool(Check<T> check)
public static implicit operator bool?(Check<T> check)
```

### 3.3. [`CheckMany<T>`](src/Green/CheckMany.cs)

Applies one or more checks to a target sequence:

```C#
public IEnumerable<T> Target { get; }
public CheckMany<T> That(Func<IEnumerable<T>, bool> next)
public CheckMany<T> Not(Func<IEnumerable<T>, bool> next)
public CheckMany<T> Not()
public bool Apply()

public static implicit operator bool(CheckMany<T> check)
public static implicit operator bool?(CheckMany<T> check)
```

### 3.4. [`CheckMany<TKey, TValue>`](src/Green/CheckMany.cs)

Applies one or more checks to a target dictionary:

```C#
public IEnumerable<KeyValuePair<TKey, TValue> Target { get; }
public CheckMany<TKey, TValue> That(Func<IEnumerable<KeyValuePair<TKey, TValue>>, bool> next)
public CheckMany<TKey, TValue> Not(Func<IEnumerable<KeyValuePair<TKey, TValue>>, bool> next)
public CheckMany<TKey, TValue> Not()
public bool Apply()

public static implicit operator bool(CheckMany<TKey, TValue> check)
public static implicit operator bool?(CheckMany<TKey, TValue> check)
```

## 4. Expectation Types

### 4.1. [`Expect`](src/Green/Expect.cs)

This static class is the factory for all expectation types:

```C#
public static Expect<T> That<T>(T target)
public static Expect<T> Not<T>(T target)

public static ExpectMany<T> Many<T>(IEnumerable<T> target)
public static ExpectMany<T> ManyNot<T>(IEnumerable<T> target)

public static ExpectMany<TKey, TValue> Many<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> target)
public static ExpectMany<TKey, TValue> ManyNot<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> target)

public static void Throws(Action target, Issue<Action>? issue = null)
public static void Throws(Func<object> target, Issue<Func<object>>? issue = null)

public static void Throws<TException>(Action target, Issue<Action>? issue = null) where TException : Exception
public static void Throws<TException>(Func<object> target, Issue<Func<object>>? issue = null) where TException : Exception

public static Task ThrowsAsync<TException>(Func<Task> target, Issue<Func<Task>>? issue = null) where TException : Exception
public static Task ThrowsAsync(Func<Task> target, Issue<Func<Task>>? issue = null)
```

Its methods are available in the [local scope](#12-add-to-the-local-scope):

| Static method | Local method      |
|---------------|:------------------|
| That          | Expect            |
| Not           | ExpectNot         |
| Many          | ExpectMany        |
| ManyNot       | ExpectManyNot     |
| Throws        | ExpectThrows      |
| ThrowsAsync   | ExpectThrowsAsync |

### 4.2. [`Expect<T>`](src/Green/Expect.cs)

Applies a check to a target value and throws [`ExpectException`](src/Green/ExpectException.cs) if not met:

```C#
public T Target { get; }
public Expect<T> That(Func<T, bool> check)

public static implicit operator bool(Expect<T> _) => true;
public static implicit operator bool?(Expect<T> _) => true;
```

*NOTES*
* The implicit operators return `true` for use in expressions as well as statements.
* Expectations lack a composable `Not` method. See the [Not](#24-not) section for more information.

### 4.4. [`ExpectMany<T>`](src/Green/ExpectMany.cs)

Applies a check to a target sequence and throws [`ExpectException`](src/Green/ExpectException.cs) if not met:

```C#
public IEnumerable<T> Target { get; }
public ExpectMany<T> That(Func<IEnumerable<T>, bool> check)

public static implicit operator bool(ExpectMany<T> _) => true;
public static implicit operator bool?(ExpectMany<T> _) => true;
```

*NOTES*
* The implicit operators return `true` for use in expressions as well as statements.
* Expectations lack a composable `Not` method. See the [Not](#24-not) section for more information.

### 4.5. [`ExpectMany<TKey, TValue>`](src/Green/ExpectMany.cs)

Applies a check to a target dictionary and throws [`ExpectException`](src/Green/ExpectException.cs) if not met:

```C#
public IEnumerable<KeyValuePair<TKey, TValue> Target { get; }
public ExpectMany<TKey, TValue> That(Func<IEnumerable<KeyValuePair<TKey, TValue>>, bool> next)

public static implicit operator bool(ExpectMany<TKey, TValue> _) => true;
public static implicit operator bool?(ExpectMany<TKey, TValue> _) => true;
```

*NOTES*
* The implicit operators return `true` for use in expressions as well as statements.
* Expectations lack a composable `Not` method. See the [Not](#24-not) section for more information.

## 5. Issue Types

### 5.1. [`Issue<T>`](src/Green/Issue.cs)

Formats a message for a target value that did not meet expectations:

```C#
public delegate IssueResult Issue<T>(T target);
```

### 5.2. [`IssueMany<T>`](src/Green/IssueMany.cs)

Formats a message for a target sequence that did not meet expectations:

```C#
public delegate IssueResult IssueMany<T>(IEnumerable<T> target);
```

### 5.3. [`IssueMany<TKey, TValue>`](src/Green/IssueMany.cs)

Formats a message for a target dictionary that did not meet expectations:

```C#
public delegate IssueResult IssueMany<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> target);
```

### 5.4. [`IssueResult`](src/Green/IssueResult.cs)

The result of formatting a message for a target value that did not meet expectations:

```C#
public string Message { get; }
public string StackTrace { get; }
public IssueMethod? Method { get; }
public IssueResult? Outer { get; }

public string ToMessage(string target, bool expectedResult)
public ExpectException ToException(string target, bool expectedResult = true, Exception? inner = null)
public ExpectException ToThrowsException(string target, Type exceptionType, Exception? inner = null)
public ExpectException ToThrowsAsyncException(string target, Type exceptionType, Exception? inner = null)

public static implicit operator IssueResult(string userMessage)

public static IssueResult Default(IssueResult? outer = null)
public static IssueResult Default(string stackTrace, IssueResult? outer = null)
public static IssueResult Operator(string stackTrace, string method, string args, IssueResult? outer = null)
public static IssueResult OperatorMany(string stackTrace, string method, string args, IssueResult? outer = null)

public class IssueMethod
{
  public string Name { get; }
  public string Args { get; }
  public bool IsMany { get; }

  public string FormatCall(string target, bool expectedResult)
}
```

## 6. Operators

See [operators.md](docs/operators.md) for a full list of check, expectation, and issue operators.