using System;
using System.Globalization;
using Xunit;

namespace Green.Messages
{
  public class TextValueTests
  {
    [Fact]
    public void ToString_Defaults()
    {
      // Arrange
      var text = default(Text<int>);

      // Act
      var result = text.ToString();

      // Assert
      Assert.Equal("0", result);
    }

    [Fact]
    public void ToString_Null_IsNullText()
    {
      // Arrange
      var text = default(Text<string>);

      // Act
      var result = text.ToString();

      // Assert
      Assert.Equal("<null>", result);
    }

    [Fact]
    public void ToString_String_HasQuotes()
    {
      // Arrange
      var text = Text.Of("value");

      // Act
      var result = text.ToString();

      // Assert
      Assert.Equal("\"value\"", result);
    }

    [Fact]
    public void ToString_ControlChar_IsCode()
    {
      // Arrange
      var text = Text.Of((char) 8);

      // Act
      var result = text.ToString();

      // Assert
      Assert.Equal(@"\u0008", result);
    }

    [Fact]
    public void ToString_Char_HasQuotes()
    {
      // Arrange
      var text = Text.Of('A');

      // Act
      var result = text.ToString();

      // Assert
      Assert.Equal("'A'", result);
    }

    [Fact]
    public void ToString_Boolean_IsLowercase()
    {
      // Arrange
      var text = Text.Of(true);

      // Act
      var result = text.ToString();

      // Assert
      Assert.Equal("true", result);
    }

    [Fact]
    public void ToString_Formattable_PassesFormatAndProvider()
    {
      // Arrange
      var format = "format";
      var formatProvider = CultureInfo.CurrentCulture;
      var formattable = new FakeFormattable();
      var text = Text.Of(formattable);

      // Act
      text.ToString(format, formatProvider);

      // Assert
      Assert.Equal(format, formattable.Format);
      Assert.Equal(formatProvider, formattable.Provider);
    }

    [Fact]
    public void ToString_Other_IsExact()
    {
      // Arrange
      var text = Text.Of(0);

      // Act
      var result = text.ToString();

      // Assert
      Assert.Equal("0", result);
    }

    [Fact]
    public void Converts_ToText()
    {
      // Arrange
      var text = Text.Of(0);

      // Act
      Text result = text;

      // Assert
      Assert.Equal("0", result.ToString());
    }

    [Fact]
    public void Converts_ToString()
    {
      // Arrange
      var text = Text.Of(0);

      // Act
      string result = text;

      // Assert
      Assert.Equal("0", result);
    }

    //
    // Details
    //

    class FakeFormattable : IFormattable
    {
      internal string Format;
      internal IFormatProvider Provider;

      public string ToString(string format, IFormatProvider formatProvider)
      {
        Format = format;
        Provider = formatProvider;

        return "";
      }
    }
  }
}