using System;
using System.Text;

namespace Green
{
  /// <summary>
  /// The result of applying an issue to a target value
  /// </summary>
  public class IssueResult
  {
    IssueResult(string message, string stackTrace, IssueMethod? method = null, IssueResult? outer = null) =>
      (Message, StackTrace, Method, Outer) = (message ?? "", stackTrace ?? "", method, outer);

    /// <summary>
    /// Gets the message that replaces the default "Unexpected value", if any
    /// </summary>
    public string Message { get; }

    /// <summary>
    /// Gets the stack trace where the issue occurred
    /// </summary>
    public string StackTrace { get; }

    /// <summary>
    /// Gets the operator method corresponding to the issue, or <see langword="null"/> if not found
    /// </summary>
    public IssueMethod? Method { get; }

    /// <summary>
    /// Gets the outer result that provides context for this result
    /// </summary>
    public IssueResult? Outer { get; }

    /// <summary>
    /// Creates an instance of <see cref="ExpectException"/> representing this result
    /// </summary>
    /// <param name="target">The target value with the issue</param>
    /// <param name="expectedResult">The expected outcome that did not occur</param>
    /// <param name="inner">The exception that caused the issue, if any</param>
    /// <returns>An instance of <see cref="ExpectException"/> representing this result</returns>
    public ExpectException ToException(string target, bool expectedResult = true, Exception? inner = null) =>
      ToExceptionCore(target, inner, new StringBuilder()
        .Append(Message != "" ? Message : "Unexpected value")
        .Append(": ")
        .Append(Method?.FormatCall(target, expectedResult) ?? target)
        .ToString());

    /// <summary>
    /// Creates an instance of <see cref="ExpectException"/> for an exception that did not occur
    /// </summary>
    /// <param name="target">The target value with the issue</param>
    /// <param name="exceptionType">The type of exception that did not occur</param>
    /// <param name="inner">The exception that caused the issue, if any</param>
    /// <returns>An instance of <see cref="ExpectException"/> representing this result</returns>
    public ExpectException ToThrowsException(string target, Type exceptionType, Exception? inner = null) =>
      ToExceptionCore(target, inner, $"Unexpected success: ExpectThrows<{exceptionType?.Name}>({target})");

    /// <summary>
    /// Creates an instance of <see cref="ExpectException"/> for an exception that did not occur
    /// </summary>
    /// <param name="target">The target value with the issue</param>
    /// <param name="exceptionType">The type of exception that did not occur</param>
    /// <param name="inner">The exception that caused the issue, if any</param>
    /// <returns>An instance of <see cref="ExpectException"/> representing this result</returns>
    public ExpectException ToThrowsAsyncException(string target, Type exceptionType, Exception? inner = null) =>
      ToExceptionCore(target, inner, $"Unexpected success: ExpectThrowsAsync<{exceptionType?.Name}>({target})");

    ExpectException ToExceptionCore(string target, Exception? inner, string message)
    {
      var exception = new ExpectException(message, StackTrace, inner);

      return Outer?.ToException(target, true, exception) ?? exception;
    }

    //
    // Factory
    //

    /// <summary>
    /// Implicitly converts a user message to an instance of <see cref="IssueResult"/>
    /// </summary>
    /// <param name="userMessage">The result representing the message</param>
    public static implicit operator IssueResult(string userMessage) =>
      new IssueResult(userMessage, Issuable.GetCallerStackTrace());

    /// <summary>
    /// Gets a result that shows a default message and the current stack trace
    /// </summary>
    /// <param name="outer">The outer result that provides context for the result, if any</param>
    /// <returns>A result that shows a default message</returns>
    public static IssueResult Default(IssueResult? outer = null) =>
      new IssueResult("", Issuable.GetCallerStackTrace(), outer: outer);

    /// <summary>
    /// Gets a result that shows a default message
    /// </summary>
    /// <param name="stackTrace">The stack trace where the issue occurred</param>
    /// <param name="outer">The outer result that provides context for the result, if any</param>
    /// <returns>A result that shows a default message</returns>
    public static IssueResult Default(string stackTrace, IssueResult? outer = null) =>
      new IssueResult("", stackTrace, outer: outer);

    /// <summary>
    /// Gets a result with a formatted call to an operator
    /// </summary>
    /// <param name="stackTrace">The stack trace where the issue occurred</param>
    /// <param name="method">The name of operator method corresponding to the issue</param>
    /// <param name="args">The arguments to the operator method corresponding to the issue</param>
    /// <param name="outer">The outer result that provides context for the result, if any</param>
    /// <returns>A result with a formatted call to an operator</returns>
    public static IssueResult Operator(string stackTrace, string method, string args, IssueResult? outer = null) =>
      new IssueResult("", stackTrace, new IssueMethod(method, args, isMany: false), outer);

    /// <summary>
    /// Gets a result with a formatted call to a many operator
    /// </summary>
    /// <param name="stackTrace">The stack trace where the issue occurred</param>
    /// <param name="method">The name of operator method corresponding to the issue</param>
    /// <param name="args">The arguments to the operator method corresponding to the issue</param>
    /// <param name="outer">The outer result that provides context for the result, if any</param>
    /// <returns>A result with a formatted call to a many operator</returns>
    public static IssueResult OperatorMany(string stackTrace, string method, string args, IssueResult? outer = null) =>
      new IssueResult("", stackTrace, new IssueMethod(method, args, isMany: true), outer);

    //
    // Types
    //

    /// <summary>
    /// The operator method corresponding to an issue
    /// </summary>
    public class IssueMethod
    {
      internal IssueMethod(string name, string args, bool isMany) =>
        (Name, Args, IsMany) = (name ?? "", args ?? "", isMany);

      /// <summary>
      /// Gets the name of the operator method
      /// </summary>
      public string Name { get; }

      /// <summary>
      /// Gets the arguments to the operator method
      /// </summary>
      public string Args { get; }

      /// <summary>
      /// Gets whether the method is a many operator
      /// </summary>
      public bool IsMany { get; }

      /// <summary>
      /// Formats a call to this method
      /// </summary>
      /// <param name="target">The target value with the issue</param>
      /// <param name="expectedResult">The expected outcome that did not occur</param>
      /// <returns>A formatted call to this method</returns>
      public string FormatCall(string target, bool expectedResult) =>
        new StringBuilder("Expect")
          .Append(IsMany ? "Many" : "")
          .Append(expectedResult ? "" : "Not")
          .Append($"({target}).{Name}({Args})")
          .ToString();
    }
  }
}