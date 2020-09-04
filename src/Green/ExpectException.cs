using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace Green
{
  public class ExpectException : Exception
  {
    readonly Lazy<string> _stackTrace;

    public ExpectException(string message) : base(message)
    {
      _stackTrace = new Lazy<string>(FilterStackTrace);
    }

    public ExpectException(string message, Exception inner) : base(message, inner)
    {
      _stackTrace = new Lazy<string>(FilterStackTrace);
    }

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