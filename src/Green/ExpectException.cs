using System;

namespace Green
{
  /// <summary>
  /// An error describing a failed expectation
  /// </summary>
  public class ExpectException : Exception
  {
    readonly string _stackTrace;

    /// <summary>
    /// Initializes an <see cref="ExpectException"/>
    /// </summary>
    /// <param name="message">The message describing the unmet expectation</param>
    /// <param name="stackTrace">The filtered stack trace describing where the error occurred</param>
    /// <param name="inner">The exception that caused this exception, if any</param>
    public ExpectException(string message, string stackTrace, Exception? inner = null) : base(message, inner) =>
      _stackTrace = stackTrace ?? "";

    /// <summary>
    /// Gets text with the immediate frames of the call stack
    /// </summary>
    public override string StackTrace => _stackTrace;

    /// <summary>
    /// Gets text describing this exception
    /// </summary>
    /// <returns>Text describing this exception</returns>
    public override string ToString() =>
      $"{Message}{Environment.NewLine}{StackTrace}";
  }
}