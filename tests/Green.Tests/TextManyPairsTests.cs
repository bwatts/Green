using System.Collections.Generic;
using Xunit;

namespace Green
{
  public class TextManyPairsTests
  {
    [Fact]
    public void ToString_DefaultsToEmpty()
    {
      // Arrange
      var text = default(TextMany<string, int>);

      // Act
      var result = text.ToString();

      // Assert
      Assert.Equal("{}", result);
    }

    [Fact]
    public void ToString_GetsPairs()
    {
      // Arrange
      var text = Text.Many(new Dictionary<string, char>
      {
        ["A"] = '+',
        ["B"] = '-'
      });

      // Act
      var result = text.ToString();

      // Assert
      Assert.Equal(@"{
  [""A""] = '+',
  [""B""] = '-'
}", result);
    }
  }
}