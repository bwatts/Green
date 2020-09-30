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
    readonly string _targetTitle = "Unexpected value of type System.Int32";
    readonly string _targetItemsTitle = "Unexpected sequence of type System.Int32[] with items of type System.Int32";
    readonly string _targetPairsTitle = "Unexpected dictionary of type System.Collections.Generic.KeyValuePair`2[System.Int32,System.String][] with keys of type System.Int32 and values of type System.String";
    readonly Exception _inner = new Exception();

    [Fact]
    public void ToException()
    {
      // Arrange
      var issue = default(Issue<int>);

      // Act
      var exception = issue.ToException(_target);

      // Assert
      Assert.Equal($@"{_targetTitle}

>> {_targetText}", exception.Message);
      Assert.True(!string.IsNullOrEmpty(exception.StackTrace));
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
      Assert.Equal($@"{_targetTitle}

>> {_targetText}", exception.Message);
      Assert.True(!string.IsNullOrEmpty(exception.StackTrace));
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
      Assert.Equal($@"{_targetTitle}

>> {_targetText}", exception.Message);
      Assert.True(!string.IsNullOrEmpty(exception.StackTrace));
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
      Assert.Equal($@"{_targetItemsTitle}

>> {_targetItemsText}", exception.Message);
      Assert.True(!string.IsNullOrEmpty(exception.StackTrace));
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
      Assert.Equal($@"{_targetItemsTitle}

>> {_targetItemsText}", exception.Message);
      Assert.True(!string.IsNullOrEmpty(exception.StackTrace));
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
      Assert.Equal($@"{_targetItemsTitle}

>> {_targetItemsText}", exception.Message);
      Assert.True(!string.IsNullOrEmpty(exception.StackTrace));
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
      Assert.Equal($@"{_targetPairsTitle}

>> {_targetPairsText}", exception.Message);
      Assert.True(!string.IsNullOrEmpty(exception.StackTrace));
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
      Assert.Equal($@"{_targetPairsTitle}

>> {_targetPairsText}", exception.Message);
      Assert.True(!string.IsNullOrEmpty(exception.StackTrace));
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
      Assert.Equal($@"{_targetPairsTitle}

>> {_targetPairsText}", exception.Message);
      Assert.True(!string.IsNullOrEmpty(exception.StackTrace));
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
      Assert.Equal($@"Unexpected value of type System.Int32

>> Expect(1).Test()", exception!.Message);
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
      Assert.Equal($@"Unexpected value of type System.Int32

>> Expect({_targetText}).TestWithArg(arg: 2)", exception!.Message);
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
      Assert.Equal(@"Unexpected value of type System.Int32

>> Expect(1).TestWithArgs(arg0: 10, arg1: 20)", exception!.Message);
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
        ExpectMany.That(_targetItems).Test();
      }
      catch(Exception x)
      {
        exception = x;
      }

      // Assert
      Assert.NotNull(exception);
      Assert.Equal(@"Unexpected sequence of type System.Int32[] with items of type System.Int32

>> ExpectMany([1, 2]).Test()", exception!.Message);
    }

    [Fact]
    public void OperatorMany_Items_WithArg()
    {
      // Arrange
      var exception = default(Exception);

      // Act
      try
      {
        ExpectMany.That(_targetItems).TestWithArg(2);
      }
      catch(Exception x)
      {
        exception = x;
      }

      // Assert
      Assert.NotNull(exception);
      Assert.Equal(@"Unexpected sequence of type System.Int32[] with items of type System.Int32

>> ExpectMany([1, 2]).TestWithArg(arg: 2)", exception!.Message);
    }

    [Fact]
    public void OperatorMany_Items_WithArgs()
    {
      // Arrange
      var exception = default(Exception);

      // Act
      try
      {
        ExpectMany.That(_targetItems).TestWithArgs(10, 20);
      }
      catch(Exception x)
      {
        exception = x;
      }

      // Assert
      Assert.NotNull(exception);
      Assert.Equal(@"Unexpected sequence of type System.Int32[] with items of type System.Int32

>> ExpectMany([1, 2]).TestWithArgs(arg0: 10, arg1: 20)", exception!.Message);
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
        ExpectMany.That(_targetPairs).Test();
      }
      catch(Exception x)
      {
        exception = x;
      }

      // Assert
      Assert.NotNull(exception);
      Assert.Equal(@"Unexpected dictionary of type System.Collections.Generic.KeyValuePair`2[System.Int32,System.String][] with keys of type System.Int32 and values of type System.String

>> ExpectMany({
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
        ExpectMany.That(_targetPairs).TestWithArg(2);
      }
      catch(Exception x)
      {
        exception = x;
      }

      // Assert
      Assert.NotNull(exception);
      Assert.Equal(@"Unexpected dictionary of type System.Collections.Generic.KeyValuePair`2[System.Int32,System.String][] with keys of type System.Int32 and values of type System.String

>> ExpectMany({
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
        ExpectMany.That(_targetPairs).TestWithArgs(10, 20);
      }
      catch(Exception x)
      {
        exception = x;
      }

      // Assert
      Assert.NotNull(exception);
      Assert.Equal(@"Unexpected dictionary of type System.Collections.Generic.KeyValuePair`2[System.Int32,System.String][] with keys of type System.Int32 and values of type System.String

>> ExpectMany({
  [1] = ""A"",
  [2] = ""B""
}).TestWithArgs(arg0: 10, arg1: 20)", exception!.Message);
    }
  }
}