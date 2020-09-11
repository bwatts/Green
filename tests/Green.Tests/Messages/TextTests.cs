using System;
using Xunit;

namespace Green.Messages
{
  public class TextTests
  {
    [Fact]
    public void ToString_DefaultsToEmpty()
    {
      // Arrange
      var text = default(Text);

      // Act
      var result = text.ToString();

      // Assert
      Assert.Equal("", result);
    }

    [Fact]
    public void ToString_GetsValue()
    {
      // Arrange
      var value = "value";
      var text = (Text) value;

      // Act
      var result = text.ToString();

      // Assert
      Assert.Equal(value, result);
    }

    [Fact]
    public void Converts_FromString()
    {
      // Arrange
      var value = "value";

      // Act
      Text result = value;

      // Assert
      Assert.Equal(value, result.ToString());
    }

    [Fact]
    public void Converts_FromFormattableString()
    {
      // Arrange
      FormattableString value = $"value";

      // Act
      Text result = value;

      // Assert
      Assert.Equal(value.ToString(), result.ToString());
    }

    [Fact]
    public void Converts_ToString()
    {
      // Arrange
      var value = Text.Of("value");

      // Act
      string result = value;

      // Assert
      Assert.Equal(value.ToString(), result);
    }
  }
}