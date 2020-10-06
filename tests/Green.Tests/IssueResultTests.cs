using System;
using Xunit;

namespace Green
{
  public class IssueResultTests
  {
    readonly string _message = "Message";
    readonly string _target = "Target";
    readonly bool _expectedResult = true;
    readonly string _stackTrace = "at ABC.cs line 7";
    readonly string _method = "IsInRange";
    readonly string _args = "5, 10";
    readonly Exception _inner = new Exception();

    [Fact]
    public void Implicit()
    {
      // Act
      IssueResult result = _message;

      // Assert
      Assert.Equal(_message, result.Message);
      Assert.False(string.IsNullOrEmpty(result.StackTrace));
      Assert.Null(result.Method);
      Assert.Null(result.Outer);
    }

    [Fact]
    public void Implicit_ToException()
    {
      // Arrange
      IssueResult result = _message;

      // Act
      var exception = result.ToException(_target, _expectedResult);

      // Assert
      Assert.Equal($"{_message}: {_target}", exception.Message);
      Assert.False(string.IsNullOrEmpty(result.StackTrace));
    }

    [Fact]
    public void Implicit_ToException_ExpectedFalse()
    {
      // Arrange
      IssueResult result = _message;

      // Act
      var exception = result.ToException(_target, false, _inner);

      // Assert
      Assert.Equal($"{_message}: {_target}", exception.Message);
      Assert.False(string.IsNullOrEmpty(result.StackTrace));
      Assert.Equal(_inner, exception.InnerException);
    }

    [Fact]
    public void Implicit_ToException_WithInner()
    {
      // Arrange
      IssueResult result = _message;

      // Act
      var exception = result.ToException(_target, _expectedResult, _inner);

      // Assert
      Assert.Equal($"{_message}: {_target}", exception.Message);
      Assert.False(string.IsNullOrEmpty(result.StackTrace));
      Assert.Equal(_inner, exception.InnerException);
    }

    //
    // Default
    //

    [Fact]
    public void Default()
    {
      // Act
      var result = IssueResult.Default();

      // Assert
      Assert.Equal("", result.Message);
      Assert.False(string.IsNullOrEmpty(result.StackTrace));
      Assert.Null(result.Method);
      Assert.Null(result.Outer);
    }

    [Fact]
    public void Default_WithOuter()
    {
      // Arrange
      var outer = IssueResult.Default();

      // Act
      var result = IssueResult.Default(outer);

      // Assert
      Assert.Equal("", result.Message);
      Assert.False(string.IsNullOrEmpty(result.StackTrace));
      Assert.Null(result.Method);
      Assert.Equal(outer, result.Outer);
    }

    [Fact]
    public void Default_WithStackTrace()
    {
      // Act
      var result = IssueResult.Default(_stackTrace);

      // Assert
      Assert.Equal("", result.Message);
      Assert.Equal(_stackTrace, result.StackTrace);
      Assert.Null(result.Method);
      Assert.Null(result.Outer);
    }

    [Fact]
    public void Default_WithStackTrace_WithOuter()
    {
      // Arrange
      var outer = IssueResult.Default();

      // Act
      var result = IssueResult.Default(_stackTrace, outer);

      // Assert
      Assert.Equal("", result.Message);
      Assert.Equal(_stackTrace, result.StackTrace);
      Assert.Null(result.Method);
      Assert.Equal(outer, result.Outer);
    }

    [Fact]
    public void Default_ToException()
    {
      // Arrange
      var result = IssueResult.Default();

      // Act
      var exception = result.ToException(_target, _expectedResult);

      // Assert
      Assert.Equal($"Unexpected value: {_target}", exception.Message);
      Assert.False(string.IsNullOrEmpty(result.StackTrace));
      Assert.Null(exception.InnerException);
    }

    [Fact]
    public void Default_ToException_ExpectedFalse()
    {
      // Arrange
      var result = IssueResult.Default();

      // Act
      var exception = result.ToException(_target, false);

      // Assert
      Assert.Equal($"Unexpected value: {_target}", exception.Message);
      Assert.False(string.IsNullOrEmpty(result.StackTrace));
      Assert.Null(exception.InnerException);
    }

    [Fact]
    public void Default_ToException_WithInner()
    {
      // Arrange
      var result = IssueResult.Default();

      // Act
      var exception = result.ToException(_target, _expectedResult, _inner);

      // Assert
      Assert.Equal($"Unexpected value: {_target}", exception.Message);
      Assert.False(string.IsNullOrEmpty(result.StackTrace));
      Assert.Equal(_inner, exception.InnerException);
    }

    [Fact]
    public void Default_ToException_WithStackTrace()
    {
      // Arrange
      var result = IssueResult.Default(_stackTrace);

      // Act
      var exception = result.ToException(_target, true);

      // Assert
      Assert.Equal($"Unexpected value: {_target}", exception.Message);
      Assert.Equal(_stackTrace, exception.StackTrace);
      Assert.Null(exception.InnerException);
    }

    [Fact]
    public void Default_ToException_WithInner_WithStackTrace()
    {
      // Arrange
      var result = IssueResult.Default(_stackTrace);

      // Act
      var exception = result.ToException(_target, _expectedResult, _inner);

      // Assert
      Assert.Equal($"Unexpected value: {_target}", exception.Message);
      Assert.Equal(_stackTrace, exception.StackTrace);
      Assert.Equal(_inner, exception.InnerException);
    }

    [Fact]
    public void Default_ToException_WithInner_WithOuter()
    {
      // Arrange
      var outer = "Outer";
      var result = IssueResult.Default((IssueResult) outer);

      // Act
      var exception = result.ToException(_target, _expectedResult, _inner);

      // Assert
      Assert.Equal($"Outer: {_target}", exception.Message);
      Assert.False(string.IsNullOrEmpty(exception.StackTrace));

      var inner = exception.InnerException;
      Assert.NotNull(inner);
      Assert.Equal($"Unexpected value: {_target}", inner!.Message);
      Assert.False(string.IsNullOrEmpty(inner!.StackTrace));
      Assert.Equal(_inner, inner!.InnerException);
    }

    [Fact]
    public void Default_ToException_WithStackTrace_WithOuter()
    {
      // Arrange
      var outer = "Outer";
      var result = IssueResult.Default(_stackTrace, outer);

      // Act
      var exception = result.ToException(_target, _expectedResult);

      // Assert
      Assert.Equal($"Outer: {_target}", exception.Message);
      Assert.False(string.IsNullOrEmpty(exception!.StackTrace));

      var inner = exception.InnerException;
      Assert.NotNull(inner);
      Assert.Equal($"Unexpected value: {_target}", inner!.Message);
      Assert.Equal(_stackTrace, inner!.StackTrace);
      Assert.Null(inner!.InnerException);
    }

    [Fact]
    public void Default_ToException_WithInner_WithStackTrace_WithOuter()
    {
      // Arrange
      var outer = "Outer";
      var result = IssueResult.Default(_stackTrace, outer);

      // Act
      var exception = result.ToException(_target, _expectedResult, _inner);

      // Assert
      Assert.Equal($"Outer: {_target}", exception.Message);
      Assert.False(string.IsNullOrEmpty(exception!.StackTrace));

      var inner = exception.InnerException;
      Assert.NotNull(inner);
      Assert.Equal($"Unexpected value: {_target}", inner!.Message);
      Assert.Equal(_stackTrace, inner!.StackTrace);
      Assert.Equal(_inner, inner!.InnerException);
    }

    //
    // Operator
    //

    [Fact]
    public void Operator()
    {
      // Act
      var result = IssueResult.Operator(_stackTrace, _method, _args);

      // Assert
      Assert.Equal("", result.Message);
      Assert.Equal(_stackTrace, result.StackTrace);
      Assert.NotNull(result.Method);
      Assert.Equal(_method, result.Method!.Name);
      Assert.Equal(_args, result.Method!.Args);
      Assert.False(result.Method.IsMany);
      Assert.Null(result.Outer);
    }

    [Fact]
    public void Operator_WithOuter()
    {
      // Act
      var outer = IssueResult.Default();
      var result = IssueResult.Operator(_stackTrace, _method, _args, outer);

      // Assert
      Assert.Equal("", result.Message);
      Assert.Equal(_stackTrace, result.StackTrace);
      Assert.NotNull(result.Method);
      Assert.Equal(_method, result.Method!.Name);
      Assert.Equal(_args, result.Method!.Args);
      Assert.False(result.Method.IsMany);
      Assert.Equal(outer, result.Outer);
    }

    [Fact]
    public void Operator_ToException()
    {
      // Arrange
      var result = IssueResult.Operator(_stackTrace, _method, _args);

      // Act
      var exception = result.ToException(_target, _expectedResult);

      // Assert
      Assert.Equal($"Unexpected value: Expect({_target}).{_method}({_args})", exception.Message);
      Assert.Equal(_stackTrace, exception.StackTrace);
      Assert.Null(exception.InnerException);
    }

    [Fact]
    public void Operator_ToException_ExpectedFalse()
    {
      // Arrange
      var result = IssueResult.Operator(_stackTrace, _method, _args);

      // Act
      var exception = result.ToException(_target, false);

      // Assert
      Assert.Equal($"Unexpected value: ExpectNot({_target}).{_method}({_args})", exception.Message);
      Assert.Equal(_stackTrace, exception.StackTrace);
      Assert.Null(exception.InnerException);
    }

    [Fact]
    public void Operator_ToException_WithInner()
    {
      // Arrange
      var result = IssueResult.Operator(_stackTrace, _method, _args);

      // Act
      var exception = result.ToException(_target, _expectedResult, _inner);

      // Assert
      Assert.Equal($"Unexpected value: Expect({_target}).{_method}({_args})", exception.Message);
      Assert.Equal(_stackTrace, exception.StackTrace);
      Assert.Equal(_inner, exception.InnerException);
    }

    //
    // OperatorMany
    //

    [Fact]
    public void OperatorMany()
    {
      // Act
      var result = IssueResult.OperatorMany(_stackTrace, _method, _args);

      // Assert
      Assert.Equal("", result.Message);
      Assert.Equal(_stackTrace, result.StackTrace);
      Assert.NotNull(result.Method);
      Assert.Equal(_method, result.Method!.Name);
      Assert.Equal(_args, result.Method!.Args);
      Assert.True(result.Method.IsMany);
      Assert.Null(result.Outer);
    }

    [Fact]
    public void OperatorMany_WithOuter()
    {
      // Act
      var outer = IssueResult.Default();
      var result = IssueResult.OperatorMany(_stackTrace, _method, _args, outer);

      // Assert
      Assert.Equal("", result.Message);
      Assert.Equal(_stackTrace, result.StackTrace);
      Assert.NotNull(result.Method);
      Assert.Equal(_method, result.Method!.Name);
      Assert.Equal(_args, result.Method!.Args);
      Assert.True(result.Method.IsMany);
      Assert.Equal(outer, result.Outer);
    }

    [Fact]
    public void OperatorMany_ToException()
    {
      // Arrange
      var result = IssueResult.OperatorMany(_stackTrace, _method, _args);

      // Act
      var exception = result.ToException(_target, _expectedResult);

      // Assert
      Assert.Equal($"Unexpected value: ExpectMany({_target}).{_method}({_args})", exception.Message);
      Assert.Equal(_stackTrace, exception.StackTrace);
      Assert.Null(exception.InnerException);
    }

    [Fact]
    public void OperatorMany_ToException_ExpectedFalse()
    {
      // Arrange
      var result = IssueResult.OperatorMany(_stackTrace, _method, _args);

      // Act
      var exception = result.ToException(_target, false);

      // Assert
      Assert.Equal($"Unexpected value: ExpectManyNot({_target}).{_method}({_args})", exception.Message);
      Assert.Equal(_stackTrace, exception.StackTrace);
      Assert.Null(exception.InnerException);
    }

    [Fact]
    public void OperatorMany_ToException_WithInner()
    {
      // Arrange
      var result = IssueResult.OperatorMany(_stackTrace, _method, _args);

      // Act
      var exception = result.ToException(_target, _expectedResult, _inner);

      // Assert
      Assert.Equal($"Unexpected value: ExpectMany({_target}).{_method}({_args})", exception.Message);
      Assert.Equal(_stackTrace, exception.StackTrace);
      Assert.Equal(_inner, exception.InnerException);
    }
  }
}