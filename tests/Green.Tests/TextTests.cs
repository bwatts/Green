using System;
using System.Collections.Generic;
using Xunit;

namespace Green
{
  public class TextTests
  {
    [Fact]
    public void Of_Null_IsNullText() =>
      Assert.Equal("<null>", Text.Of(null));

    [Fact]
    public void Of_String_HasQuotes() =>
      Assert.Equal("\"value\"", Text.Of("value"));

    [Fact]
    public void Of_ControlChar_IsCode() =>
      Assert.Equal(@"\u0008", Text.Of((char) 8));

    [Fact]
    public void Of_Char_HasQuotes() =>
      Assert.Equal("'A'", Text.Of('A'));

    [Fact]
    public void Of_Boolean_IsLowercase() =>
      Assert.Equal("true", Text.Of(true));

    [Fact]
    public void Of_Delegate_UsesQualifiedName()
    {
      // Arrange
      Action action = Of_Delegate_UsesQualifiedName;

      // Act
      var result = Text.Of(action);

      // Assert
      Assert.Equal($"{nameof(TextTests)}.{action.Method.Name}", result);
    }

    [Fact]
    public void Of_Delegate_SkipsLambdaTypeName()
    {
      // Arrange
      Action action = () => {};

      // Act
      var result = Text.Of(action);

      // Assert
      Assert.Equal(action.Method.Name, result);
    }

    [Fact]
    public void Of_Pair()
    {
      // Arrange
      var pair = KeyValuePair.Create("key", 'v');

      // Act
      var result = Text.Of(pair);

      // Assert
      Assert.Equal("[\"key\"] = 'v'", result);
    }

    [Fact]
    public void Of_Pairs_DefaultsToEmpty()
    {
      // Arrange
      var pairs = new Dictionary<string, char>();

      // Act
      var result = Text.Of(pairs);

      // Assert
      Assert.Equal("{}", result);
    }

    [Fact]
    public void Of_Pairs()
    {
      // Arrange
      var pairs = new Dictionary<string, char>
      {
        ["A"] = '+',
        ["B"] = '-'
      };

      // Act
      var result = Text.Of(pairs);

      // Assert
      Assert.Equal(@"{
  [""A""] = '+',
  [""B""] = '-'
}", result);
    }

    [Fact]
    public void Of_Items_DefaultsToEmpty()
    {
      // Arrange
      var items = new int[0];

      // Act
      var result = Text.Of(items);

      // Assert
      Assert.Equal("[]", result);
    }

    [Fact]
    public void Of_Items_LessThan60Chars_IsSingleLine()
    {
      // Arrange
      var items = new[] { 1, 2, 3 };

      // Act
      var result = Text.Of(items);

      // Assert
      Assert.Equal("[1, 2, 3]", result);
    }

    [Fact]
    public void Of_Items_MoreThan60Chars_IsMultiLine()
    {
      // Arrange
      var items = new[]
      {
        "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
        "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
        "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
      };

      // Act
      var result = Text.Of(items);

      // Assert
      Assert.Equal(@"[
  ""ABCDEFGHIJKLMNOPQRSTUVWXYZ"",
  ""ABCDEFGHIJKLMNOPQRSTUVWXYZ"",
  ""ABCDEFGHIJKLMNOPQRSTUVWXYZ""
]", result);
    }

    [Fact]
    public void Of_Other_IsExact() =>
      Assert.Equal("123", Text.Of(123));
  }
}