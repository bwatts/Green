using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Green
{
  public class CheckManyItemsTests
  {
    readonly IEnumerable<int> _target = Enumerable.Empty<int>();

    [Fact]
    public void StaticThat_SetsTarget()
    {
      // Act
      var check = CheckMany.That(_target);

      // Assert
      Assert.Equal(_target, check.Target);
    }

    [Fact]
    public void StaticThat_DefaultsToTrue()
    {
      // Arrage
      var check = CheckMany.That(_target);

      // Act
      var result = check.Apply();

      // Assert
      Assert.True(result);
    }

    [Fact]
    public void StaticNot_SetsTarget()
    {
      // Act
      var check = CheckMany.That(_target);

      // Assert
      Assert.Equal(_target, check.Target);
    }

    [Fact]
    public void StaticNot_DefaultsToTrue()
    {
      // Arrage
      var check = CheckMany.Not(_target);

      // Act
      var result = check.Apply();

      // Assert
      Assert.True(result);
    }

    [Fact]
    public void Converts_ToBoolean()
    {
      // Arrage
      var applied = false;
      var check = CheckMany.That(_target).That(_ => applied = true);

      // Act
      bool result = check;

      // Assert
      Assert.True(applied);
      Assert.True(result);
    }

    [Fact]
    public void Converts_ToBoolean_Nullable()
    {
      // Arrage
      var applied = false;
      var check = CheckMany.That(_target).That(_ => applied = true);

      // Act
      bool? result = check;

      // Assert
      Assert.True(applied);
      Assert.True(result);
    }

    //
    // That
    //

    [Fact]
    public void That_PassesTarget()
    {
      // Arrange
      var check = CheckMany.That(_target);

      // Act
      var nextCheck = check.That(_ => true);

      // Assert
      Assert.Equal(_target, nextCheck.Target);
    }

    [Fact]
    public void That_AppliesNext()
    {
      // Arrange
      var applied = false;
      var check = CheckMany.That(_target).That(_ => { applied = true; return true; });

      // Act
      check.Apply();

      // Assert
      Assert.True(applied);
    }

    [Fact]
    public void That_AppliesPrevious_ThenNext()
    {
      // Arrange
      var previousApplied = false;
      var nextApplied = false;
      var check = CheckMany.That(_target)
        .That(_ => { previousApplied = !nextApplied; return true; })
        .That(_ => { nextApplied = true; return true; });

      // Act
      check.Apply();

      // Assert
      Assert.True(previousApplied);
      Assert.True(nextApplied);
    }

    [Fact]
    public void That_ShortCircuitsNext()
    {
      // Arrange
      var previousApplied = false;
      var nextApplied = false;
      var check = CheckMany.That(_target)
        .That(_ => { previousApplied = !nextApplied; return false; })
        .That(_ => { nextApplied = true; return true; });

      // Act
      check.Apply();

      // Assert
      Assert.True(previousApplied);
      Assert.False(nextApplied);
    }

    //
    // Not
    //

    [Fact]
    public void Not_PassesTarget()
    {
      // Arrange
      var check = CheckMany.That(_target);

      // Act
      var nextCheck = check.Not(_ => true);

      // Assert
      Assert.Equal(_target, nextCheck.Target);
    }

    [Fact]
    public void Not_AppliesNext()
    {
      // Arrange
      var applied = false;
      var check = CheckMany.That(_target).Not(_ => { applied = true; return true; });

      // Act
      check.Apply();

      // Assert
      Assert.True(applied);
    }

    [Fact]
    public void Not_AppliesPrevious_ThenNext()
    {
      // Arrange
      var previousApplied = false;
      var nextApplied = false;
      var check = CheckMany.That(_target)
        .Not(_ => { previousApplied = !nextApplied; return false; })
        .Not(_ => { nextApplied = true; return false; });

      // Act
      check.Apply();

      // Assert
      Assert.True(previousApplied);
      Assert.True(nextApplied);
    }

    [Fact]
    public void Not_ShortCircuitsNext()
    {
      // Arrange
      var previousApplied = false;
      var nextApplied = false;
      var check = CheckMany.That(_target)
        .Not(_ => { previousApplied = !nextApplied; return true; })
        .Not(_ => { nextApplied = true; return false; });

      // Act
      check.Apply();

      // Assert
      Assert.True(previousApplied);
      Assert.False(nextApplied);
    }

    [Fact]
    public void UnaryNot_PassesTarget()
    {
      // Arrange
      var check = CheckMany.That(_target);

      // Act
      var nextCheck = check.Not();

      // Assert
      Assert.Equal(_target, nextCheck.Target);
    }

    [Fact]
    public void UnaryNot_DefaultsToTrue()
    {
      // Arrange
      var check = CheckMany.That(_target).Not();

      // Act
      var result = check.Apply();

      // Assert
      Assert.True(result);
    }

    [Fact]
    public void UnaryNot_NegatesResult()
    {
      // Arrange
      var check = CheckMany.That(_target).That(_ => true).Not();

      // Act
      var result = check.Apply();

      // Assert
      Assert.False(result);
    }
  }
}