using System;
using System.Text;

namespace Green
{
  /// <summary>
  /// The result of applying an issue to a target value
  /// </summary>
  public class IssueResult
  {
    IssueResult(string userMessage, string stackTrace, IssueMethod? method = null, IssueResult? outer = null) =>
      (UserMessage, StackTrace, Method, Outer) = (userMessage ?? "", stackTrace ?? "", method, outer);

    /// <summary>
    /// Gets the message specified at the point of use, or an empty string if not specified
    /// </summary>
    public string UserMessage { get; }

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
    /// <param name="title">The first part of the exception message</param>
    /// <param name="target">The target value with the issue</param>
    /// <param name="expectedResult">The expected outcome that did not occur</param>
    /// <param name="inner">The exception that caused the issue, if any</param>
    /// <returns>An instance of <see cref="ExpectException"/> representing this result</returns>
    public ExpectException ToException(string title, string target, bool expectedResult = true, Exception? inner = null)
    {
      var message = BuildMessage(title, target, expectedResult);

      var exception = new ExpectException(message, StackTrace, inner);

      return Outer?.ToException(title, target, expectedResult, exception) ?? exception;
    }

    string BuildMessage(string title, string target, bool expectedResult)
    {
      var message = new StringBuilder(title);

      if(UserMessage != "")
      {
        message.Append(": ").Append(UserMessage);
      }

      return message
        .AppendLine()
        .AppendLine()
        .Append(">> ")
        .Append(Method?.FormatCall(target, expectedResult) ?? target)
        .ToString();
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
    /// Gets a result that shows a default message
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
    /// Gets a result that shows a formatted call to an operator
    /// </summary>
    /// <param name="stackTrace">The stack trace where the issue occurred</param>
    /// <param name="method">The name of operator method corresponding to the issue</param>
    /// <param name="args">The arguments to the operator method corresponding to the issue</param>
    /// <param name="outer">The outer result that provides context for the result, if any</param>
    /// <returns>A result that shows a formatted call to an operator</returns>
    public static IssueResult Operator(string stackTrace, string method, string args, IssueResult? outer = null) =>
      new IssueResult("", stackTrace, new IssueMethod(method, args, isMany: false), outer);

    /// <summary>
    /// Gets a result that shows a formatted call to a many operator
    /// </summary>
    /// <param name="stackTrace">The stack trace where the issue occurred</param>
    /// <param name="method">The name of operator method corresponding to the issue</param>
    /// <param name="args">The arguments to the operator method corresponding to the issue</param>
    /// <param name="outer">The outer result that provides context for the result, if any</param>
    /// <returns>A result that shows a formatted call to a many operator</returns>
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