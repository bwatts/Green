using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Green
{
  /// <summary>
  /// An error describing a failed expectation
  /// </summary>
  public class ExpectException : Exception
  {
    readonly Lazy<string> _stackTrace;

    /// <summary>
    /// Initializes an instance of <see cref="ExpectException"/>
    /// </summary>
    /// <param name="message">The message describing an issue with the target value</param>
    public ExpectException(string message) : base(message) =>
      _stackTrace = new Lazy<string>(FilterStackTrace);

    /// <summary>
    /// Initializes an instance of <see cref="ExpectException"/>
    /// </summary>
    /// <param name="message">The message describing an issue with the target value</param>
    /// <param name="inner">The exception that caused this exception</param>
    public ExpectException(string message, Exception inner) : base(message, inner) =>
      _stackTrace = new Lazy<string>(FilterStackTrace);

    /// <summary>
    /// Gets text with the immediate frames of the call stack. Ignores Green implementation details.
    /// </summary>
    public override string StackTrace => _stackTrace.Value;

    string FilterStackTrace()
    {
      var builder = new StringBuilder();
      var expectableLine = default(string);

      foreach(var line in ReadStackTraceLines())
      {
        var trimmed = line.TrimStart();

        if(trimmed.StartsWith("at Green.Expect`1")
          || trimmed.StartsWith("at Green.ExpectMany`1")
          || trimmed.StartsWith("at Green.ExpectMany`2"))
        {
          continue;
        }

        if(trimmed.StartsWith("at Green.Expectable."))
        {
          expectableLine = line;
        }
        else
        {
          if(expectableLine != null)
          {
            builder.AppendLine(expectableLine);
            expectableLine = null;
          }

          builder.AppendLine(line);
        }
      }

      return builder.ToString();
    }

    IEnumerable<string> ReadStackTraceLines()
    {
      using var reader = new StringReader(base.StackTrace);
      string line;

      while((line = reader.ReadLine()) != null)
      {
        yield return line;
      }
    }
  }
}