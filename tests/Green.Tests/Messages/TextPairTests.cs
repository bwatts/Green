using System.Collections.Generic;
using Xunit;

namespace Green.Messages
{
  public class TextPairTests
  {
    [Fact]
    public void ToString_DefaultsKeyAndValue()
    {
      // Arrange
      var text = default(Text<string, int>);

      // Act
      var result = text.ToString();

      // Assert
      Assert.Equal("[<null>] = 0", result);
    }

    [Fact]
    public void ToString_GetsPair()
    {
      // Arrange
      var text = Text.Pair("key", 'v');

      // Act
      var result = text.ToString();

      // Assert
      Assert.Equal("[\"key\"] = 'v'", result);
    }

    [Fact]
    public void Converts_ToText()
    {
      // Arrange
      var text = Text.Pair(1, true);

      // Act
      Text result = text;

      // Assert
      Assert.Equal("[1] = true", result.ToString());
    }

    [Fact]
    public void Converts_ToString()
    {
      // Arrange
      var text = Text.Pair(1, true);

      // Act
      string result = text;

      // Assert
      Assert.Equal("[1] = true", result.ToString());
    }
  }
}