using Xunit;

namespace Green.Messages
{
  public class TextManyItemsTests
  {
    [Fact]
    public void ToString_DefaultsToEmpty()
    {
      // Arrange
      var text = default(TextMany<int>);

      // Act
      var result = text.ToString();

      // Assert
      Assert.Equal("[]", result);
    }

    [Fact]
    public void ToString_LessThan60Chars_IsSingleLine()
    {
      // Arrange
      var text = Text.Many(new[] { 1, 2, 3 });

      // Act
      var result = text.ToString();

      // Assert
      Assert.Equal("[1, 2, 3]", result);
    }

    [Fact]
    public void ToString_MoreThan60Chars_IsMultiLine()
    {
      // Arrange
      var text = Text.Many(new[]
      {
        "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
        "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
        "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
      });

      // Act
      var result = text.ToString();

      // Assert
      Assert.Equal(@"[
  ""ABCDEFGHIJKLMNOPQRSTUVWXYZ"",
  ""ABCDEFGHIJKLMNOPQRSTUVWXYZ"",
  ""ABCDEFGHIJKLMNOPQRSTUVWXYZ""
]", result);
    }
  }
}