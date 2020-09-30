using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Green
{
  public class ExpectManyItemsTests
  {
    readonly IEnumerable<int> _target = Enumerable.Empty<int>();

    [Fact]
    public void StaticThat_SetsTarget()
    {
      // Act
      var expect = ExpectMany.That(_target);

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
      var check = ExpectMany.Not(_target);

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
      var expect = ExpectMany.That(_target);

      // Act
      bool result = expect;

      // Assert
      Assert.True(result);
    }

    [Fact]
    public void Converts_ToBoolean_Nullable()
    {
      // Arrage
      var expect = ExpectMany.That(_target);

      // Act
      bool? result = expect;

      // Assert
      Assert.True(result);
    }

    [Fact]
    public void That_ReturnsSame()
    {
      // Arrange
      var expect = ExpectMany.That(_target);

      // Act
      var nextExpect = expect.That(_ => true);

      // Assert
      Assert.Equal(expect, nextExpect);
    }

    [Fact]
    public void That_Throws_IfFalse()
    {
      // Arrange
      var expect = ExpectMany.That(_target);

      // Act
      Assert.Throws<ExpectException>(() => expect.That(_ => false));
    }
  }
}