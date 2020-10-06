using System;
using System.Collections.Generic;
using Xunit;

namespace Green
{
  public class IssuableTests
  {
    readonly int _target = 1;
    readonly int[] _targetItems = new[] { 1, 2 };
    readonly KeyValuePair<int, string>[] _targetPairs = new[]
    {
      KeyValuePair.Create(1, "A"),
      KeyValuePair.Create(2, "B")
    };
    readonly string _targetText = "1";
    readonly string _targetItemsText = "[1, 2]";
    readonly string _targetPairsText = @"{
  [1] = ""A"",
  [2] = ""B""
}";
    readonly Exception _inner = new Exception();

    [Fact]
    public void ToException()
    {
      // Arrange
      var issue = default(Issue<int>);

      // Act
      var exception = issue.ToException(_target);

      // Assert
      Assert.Equal($@"Unexpected value: {_targetText}", exception.Message);
      Assert.False(string.IsNullOrEmpty(exception.StackTrace));
      Assert.Null(exception.InnerException);
    }

    [Fact]
    public void ToException_ExpectedFalse()
    {
      // Arrange
      var issue = default(Issue<int>);

      // Act
      var exception = issue.ToException(_target, false);

      // Assert
      Assert.Equal($@"Unexpected value: {_targetText}", exception.Message);
      Assert.False(string.IsNullOrEmpty(exception.StackTrace));
      Assert.Null(exception.InnerException);
    }

    [Fact]
    public void ToException_WithInner()
    {
      // Arrange
      var issue = default(Issue<int>);

      // Act
      var exception = issue.ToException(_target, inner: _inner);

      // Assert
      Assert.Equal($@"Unexpected value: {_targetText}", exception.Message);
      Assert.False(string.IsNullOrEmpty(exception.StackTrace));
      Assert.Equal(_inner, exception.InnerException);
    }

    //
    // ToException (items)
    //

    [Fact]
    public void ToException_Items()
    {
      // Arrange
      var issue = default(IssueMany<int>);

      // Act
      var exception = issue.ToException(_targetItems);

      // Assert
      Assert.Equal($@"Unexpected value: {_targetItemsText}", exception.Message);
      Assert.False(string.IsNullOrEmpty(exception.StackTrace));
      Assert.Null(exception.InnerException);
    }

    [Fact]
    public void ToException_Items_ExpectedFalse()
    {
      // Arrange
      var issue = default(IssueMany<int>);

      // Act
      var exception = issue.ToException(_targetItems, false);

      // Assert
      Assert.Equal($@"Unexpected value: {_targetItemsText}", exception.Message);
      Assert.False(string.IsNullOrEmpty(exception.StackTrace));
      Assert.Null(exception.InnerException);
    }

    [Fact]
    public void ToException_Items_WithInner()
    {
      // Arrange
      var issue = default(IssueMany<int>);

      // Act
      var exception = issue.ToException(_targetItems, inner: _inner);

      // Assert
      Assert.Equal($@"Unexpected value: {_targetItemsText}", exception.Message);
      Assert.False(string.IsNullOrEmpty(exception.StackTrace));
      Assert.Equal(_inner, exception.InnerException);
    }

    //
    // ToException (pairs)
    //

    [Fact]
    public void ToException_Pairs()
    {
      // Arrange
      var issue = default(IssueMany<int, string>);

      // Act
      var exception = issue.ToException(_targetPairs);

      // Assert
      Assert.Equal($@"Unexpected value: {_targetPairsText}", exception.Message);
      Assert.False(string.IsNullOrEmpty(exception.StackTrace));
      Assert.Null(exception.InnerException);
    }

    [Fact]
    public void ToException_Pairs_ExpectedFalse()
    {
      // Arrange
      var issue = default(IssueMany<int, string>);

      // Act
      var exception = issue.ToException(_targetPairs, false);

      // Assert
      Assert.Equal($@"Unexpected value: {_targetPairsText}", exception.Message);
      Assert.False(string.IsNullOrEmpty(exception.StackTrace));
      Assert.Null(exception.InnerException);
    }

    [Fact]
    public void ToException_Pairs_WithInner()
    {
      // Arrange
      var issue = default(IssueMany<int, string>);

      // Act
      var exception = issue.ToException(_targetPairs, inner: _inner);

      // Assert
      Assert.Equal($@"Unexpected value: {_targetPairsText}", exception.Message);
      Assert.False(string.IsNullOrEmpty(exception.StackTrace));
      Assert.Equal(_inner, exception.InnerException);
    }

    //
    // Operators
    //

    [Fact]
    public void Operator()
    {
      // Arrange
      var exception = default(Exception);

      // Act
      try
      {
        Expect.That(_target).Test();
      }
      catch(Exception x)
      {
        exception = x;
      }

      // Assert
      Assert.NotNull(exception);
      Assert.Equal($@"Unexpected value: Expect(1).Test()", exception!.Message);
    }

    [Fact]
    public void Operator_WithArg()
    {
      // Arrange
      var exception = default(Exception);

      // Act
      try
      {
        Expect.That(_target).TestWithArg(2);
      }
      catch(Exception x)
      {
        exception = x;
      }

      // Assert
      Assert.NotNull(exception);
      Assert.Equal($@"Unexpected value: Expect({_targetText}).TestWithArg(arg: 2)", exception!.Message);
    }

    [Fact]
    public void Operator_WithArgs()
    {
      // Arrange
      var exception = default(Exception);

      // Act
      try
      {
        Expect.That(_target).TestWithArgs(10, 20);
      }
      catch(Exception x)
      {
        exception = x;
      }

      // Assert
      Assert.NotNull(exception);
      Assert.Equal(@"Unexpected value: Expect(1).TestWithArgs(arg0: 10, arg1: 20)", exception!.Message);
    }

    //
    // Operators (items)
    //

    [Fact]
    public void OperatorMany_Items()
    {
      // Arrange
      var exception = default(Exception);

      // Act
      try
      {
        Expect.Many(_targetItems).Test();
      }
      catch(Exception x)
      {
        exception = x;
      }

      // Assert
      Assert.NotNull(exception);
      Assert.Equal(@"Unexpected value: ExpectMany([1, 2]).Test()", exception!.Message);
    }

    [Fact]
    public void OperatorMany_Items_WithArg()
    {
      // Arrange
      var exception = default(Exception);

      // Act
      try
      {
        Expect.Many(_targetItems).TestWithArg(2);
      }
      catch(Exception x)
      {
        exception = x;
      }

      // Assert
      Assert.NotNull(exception);
      Assert.Equal(@"Unexpected value: ExpectMany([1, 2]).TestWithArg(arg: 2)", exception!.Message);
    }

    [Fact]
    public void OperatorMany_Items_WithArgs()
    {
      // Arrange
      var exception = default(Exception);

      // Act
      try
      {
        Expect.Many(_targetItems).TestWithArgs(10, 20);
      }
      catch(Exception x)
      {
        exception = x;
      }

      // Assert
      Assert.NotNull(exception);
      Assert.Equal(@"Unexpected value: ExpectMany([1, 2]).TestWithArgs(arg0: 10, arg1: 20)", exception!.Message);
    }

    //
    // Operators (pairs)
    //

    [Fact]
    public void OperatorMany_Pairs()
    {
      // Arrange
      var exception = default(Exception);

      // Act
      try
      {
        Expect.Many(_targetPairs).Test();
      }
      catch(Exception x)
      {
        exception = x;
      }

      // Assert
      Assert.NotNull(exception);
      Assert.Equal(@"Unexpected value: ExpectMany({
  [1] = ""A"",
  [2] = ""B""
}).Test()", exception!.Message);
    }

    [Fact]
    public void OperatorMany_Pairs_WithArg()
    {
      // Arrange
      var exception = default(Exception);

      // Act
      try
      {
        Expect.Many(_targetPairs).TestWithArg(2);
      }
      catch(Exception x)
      {
        exception = x;
      }

      // Assert
      Assert.NotNull(exception);
      Assert.Equal(@"Unexpected value: ExpectMany({
  [1] = ""A"",
  [2] = ""B""
}).TestWithArg(arg: 2)", exception!.Message);
    }

    [Fact]
    public void OperatorMany_Pairs_WithArgs()
    {
      // Arrange
      var exception = default(Exception);

      // Act
      try
      {
        Expect.Many(_targetPairs).TestWithArgs(10, 20);
      }
      catch(Exception x)
      {
        exception = x;
      }

      // Assert
      Assert.NotNull(exception);
      Assert.Equal(@"Unexpected value: ExpectMany({
  [1] = ""A"",
  [2] = ""B""
}).TestWithArgs(arg0: 10, arg1: 20)", exception!.Message);
    }
  }
}