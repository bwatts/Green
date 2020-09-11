using System;
using System.Threading.Tasks;
using Xunit;

namespace Green
{
  public class ExpectTests
  {
    readonly int _target = 1;

    [Fact]
    public void StaticThat_SetsTarget()
    {
      // Act
      var expect = Expect.That(_target);

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
      var check = Expect.Not(_target);

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
      var expect = Expect.That(_target);

      // Act
      bool result = expect;

      // Assert
      Assert.True(result);
    }

    [Fact]
    public void Converts_ToBoolean_Nullable()
    {
      // Arrage
      var expect = Expect.That(_target);

      // Act
      bool? result = expect;

      // Assert
      Assert.True(result);
    }

    [Fact]
    public void That_ReturnsSame()
    {
      // Arrange
      var expect = Expect.That(_target);

      // Act
      var nextExpect = expect.That(_ => true);

      // Assert
      Assert.Equal(expect, nextExpect);
    }

    [Fact]
    public void That_Throws_IfFalse()
    {
      // Arrange
      var expect = Expect.That(_target);

      // Act
      Assert.Throws<ExpectException>(() => expect.That(_ => false));
    }

    [Fact]
    public void Not_ReturnsSame()
    {
      // Arrange
      var expect = Expect.That(_target);

      // Act
      var nextExpect = expect.Not(_ => false);

      // Assert
      Assert.Equal(expect, nextExpect);
    }

    [Fact]
    public void Not_Throws_IfTrue()
    {
      // Arrange
      var expect = Expect.That(_target);

      // Act
      Assert.Throws<ExpectException>(() => expect.Not(_ => true));
    }

    //
    // Throws
    //

    [Fact]
    public void Throws_Action_IgnoresExpectedType()
    {
      // Arrange
      static void Target() => throw new ArgumentNullException();

      // Act
      Expect.Throws<ArgumentNullException>(Target);
    }

    [Fact]
    public void Throws_Action_ThrowsForUnexpectedType()
    {
      // Arrange
      static void Target() => throw new FormatException();

      // Act
      Assert.Throws<ExpectException>(() =>
      {
        Expect.Throws<ArgumentNullException>(Target);
      });
    }

    [Fact]
    public void Throws_Action_ThrowsIfNoException()
    {
      // Arrange
      static void Target() { }

      // Act
      Assert.Throws<ExpectException>(() =>
      {
        Expect.Throws<ArgumentNullException>(Target);
      });
    }

    [Fact]
    public void Throws_Func_IgnoresExpectedType()
    {
      // Arrange
      static object Target() => throw new ArgumentNullException();

      // Act
      Expect.Throws<ArgumentNullException>(Target);
    }

    [Fact]
    public void Throws_Func_ThrowsForUnexpectedType()
    {
      // Arrange
      static object Target() => throw new FormatException();

      // Act
      Assert.Throws<ExpectException>(() =>
      {
        Expect.Throws<ArgumentNullException>(Target);
      });
    }

    [Fact]
    public void Throws_Func_ThrowsIfNoException()
    {
      // Arrange
      static object Target() => null;

      // Act
      Assert.Throws<ExpectException>(() =>
      {
        Expect.Throws<ArgumentNullException>(Target);
      });
    }

    [Fact]
    public async Task ThrowsAsync_IgnoresExpectedType()
    {
      // Arrange
      static Task Target() => throw new ArgumentNullException();

      // Act
      await Expect.ThrowsAsync<ArgumentNullException>(Target);
    }

    [Fact]
    public async Task ThrowsAsync_ThrowsForUnexpectedType()
    {
      // Arrange
      static Task Target() => throw new FormatException();

      // Act
      await Assert.ThrowsAsync<ExpectException>(async () =>
      {
        await Expect.ThrowsAsync<ArgumentNullException>(Target);
      });
    }

    [Fact]
    public async Task ThrowsAsync_ThrowsIfNoException()
    {
      // Arrange
      static Task Target() => Task.CompletedTask;

      // Act
      await Assert.ThrowsAsync<ExpectException>(async () =>
      {
        await Expect.ThrowsAsync<ArgumentNullException>(Target);
      });
    }
  }
}