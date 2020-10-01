using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Green
{
  public class ExpectManyPairsTests
  {
    readonly IEnumerable<KeyValuePair<int, string>> _target = Enumerable.Empty<KeyValuePair<int, string>>();

    [Fact]
    public void StaticThat_SetsTarget()
    {
      // Act
      var expect = Expect.Many(_target);

      // Assert
      Assert.Equal(_target, expect.Target);
    }

    [Fact]
    public void StaticThat_DoesNotThrow()
    {
      // Act
      Expect.That(_target);
    }

    [Fact]
    public void StaticNot_SetsTarget()
    {
      // Act
      var check = Expect.ManyNot(_target);

      // Assert
      Assert.Equal(_target, check.Target);
    }

    [Fact]
    public void StaticNot_DoesNotThrow()
    {
      // Act
      Expect.Not(_target);
    }

    [Fact]
    public void Converts_ToBoolean()
    {
      // Arrage
      var expect = Expect.Many(_target);

      // Act
      bool result = expect;

      // Assert
      Assert.True(result);
    }

    [Fact]
    public void Converts_ToBoolean_Nullable()
    {
      // Arrage
      var expect = Expect.Many(_target);

      // Act
      bool? result = expect;

      // Assert
      Assert.True(result);
    }

    [Fact]
    public void That_ReturnsSame()
    {
      // Arrange
      var expect = Expect.Many(_target);

      // Act
      var nextExpect = expect.That(_ => true);

      // Assert
      Assert.Equal(expect, nextExpect);
    }

    [Fact]
    public void That_Throws_IfFalse()
    {
      // Arrange
      var expect = Expect.Many(_target);

      // Act
      Assert.Throws<ExpectException>(() => expect.That(_ => false));
    }

    [Fact]
    public void Not_ReturnsSame()
    {
      // Arrange
      var expect = Expect.Many(_target);

      // Act
      var nextExpect = expect.Not(_ => false);

      // Assert
      Assert.Equal(expect, nextExpect);
    }

    [Fact]
    public void Not_Throws_IfTrue()
    {
      // Arrange
      var expect = Expect.Many(_target);

      // Act
      Assert.Throws<ExpectException>(() => expect.Not(_ => true));
    }
  }
}