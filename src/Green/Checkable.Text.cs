using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Green
{
  public static partial class Checkable
  {
    /// <summary>
    /// Checks if the target is equal to <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> EqualTo(this Check<string> check, string? value) =>
      check.That(t => string.Equals(t, value));

    /// <summary>
    /// Checks if the target is equal to <paramref name="value"/> using <paramref name="comparison"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare using <paramref name="comparison"/></param>
    /// <param name="comparison">The type of comparison to perform</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> EqualTo(this Check<string> check, string? value, StringComparison comparison) =>
      check.That(t => string.Equals(t, value, comparison));

    /// <summary>
    /// Checks if the target is equal to <paramref name="value"/> using <see cref="StringComparison.OrdinalIgnoreCase"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare using <paramref name="comparison"/></param>
    /// <param name="comparison">The type of comparison to perform</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> EquivalentTo(this Check<string> check, string? value) =>
      check.EqualTo(value, StringComparison.OrdinalIgnoreCase);

    /// <summary>
    /// Checks if the target is not equal to <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> NotEqualTo(this Check<string> check, string? value) =>
      check.Not(t => string.Equals(t, value));

    /// <summary>
    /// Checks if the target is not equal to <paramref name="value"/> using <paramref name="comparison"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare using <paramref name="comparison"/></param>
    /// <param name="comparison">The type of comparison to perform</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> NotEqualTo(this Check<string> check, string? value, StringComparison comparison) =>
      check.Not(t => string.Equals(t, value, comparison));

    /// <summary>
    /// Checks if the target is not equal to <paramref name="value"/> using <see cref="StringComparison.OrdinalIgnoreCase"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare using <paramref name="comparison"/></param>
    /// <param name="comparison">The type of comparison to perform</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> NotEquivalentTo(this Check<string> check, string? value) =>
      check.NotEqualTo(value, StringComparison.OrdinalIgnoreCase);

    //
    // Values
    //

    /// <summary>
    /// Checks if the target is equal to <see cref="string.Empty"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> Empty(this Check<string> check) =>
      check.That(t => t == "");

    /// <summary>
    /// Checks if the target is whitespace only
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> WhiteSpace(this Check<string> check) =>
      check.That(t => t != null && string.IsNullOrWhiteSpace(t));

    /// <summary>
    /// Checks if the target is <see langword="null"/> or <see cref="string.Empty"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> NullOrEmpty(this Check<string> check) =>
      check.That(string.IsNullOrEmpty);

    /// <summary>
    /// Checks if the target is <see langword="null"/> or whitespace only
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> NullOrWhiteSpace(this Check<string> check) =>
      check.That(string.IsNullOrWhiteSpace);

    /// <summary>
    /// Checks if the target is not equal to <see cref="string.Empty"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> NotEmpty(this Check<string> check) =>
      check.That(t => t != "");

    /// <summary>
    /// Checks if the target is not whitespace only
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> NotWhiteSpace(this Check<string> check) =>
      check.Not(t => t != null && string.IsNullOrWhiteSpace(t));

    /// <summary>
    /// Checks if the target is not <see langword="null"/> or the empty string
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> NotNullOrEmpty(this Check<string> check) =>
      check.Not(string.IsNullOrEmpty);

    /// <summary>
    /// Checks if the target is not <see langword="null"/> or whitespace only
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> NotNullOrWhiteSpace(this Check<string> check) =>
      check.Not(string.IsNullOrWhiteSpace);

    //
    // Length
    //

    /// <summary>
    /// Checks if the <see cref="string.Length"/> property is equal to <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The length to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> Length(this Check<string> check, int value) =>
      check.That(t => t?.Length == value);

    /// <summary>
    /// Checks if the <see cref="string.Length"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> Length(this Check<string> check, Func<Check<int>, bool> checkValue) =>
      check.That(t => t != null && checkValue.Invoke(t.Length));

    /// <summary>
    /// Checks if the <see cref="string.Length"/> property is not equal to <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The length to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> NotLength(this Check<string> check, int value) =>
      check.That(t => t?.Length != value);

    /// <summary>
    /// Checks if the <see cref="string.Length"/> property results in <see langword="false"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> NotLength(this Check<string> check, Func<Check<int>, bool> checkValue) =>
      check.Not(t => t != null && checkValue.Invoke(t.Length));

    //
    // Char
    //

    /// <summary>
    /// Checks if the character at <paramref name="index"/> in the target is equal to <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="index">The index of the character in the string</param>
    /// <param name="value">The character to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    /// <exception cref="IndexOutOfRangeException">Thrown if <paramref name="index"/>  greater than or equal to the string's length</exception>
    public static Check<string> Char(this Check<string> check, int index, char value) =>
      check.That(t => t != null && index < t.Length && t[index] == value);

    /// <summary>
    /// Checks if the character at <paramref name="index"/> in the target results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="index">The index of the character in the string</param>
    /// <param name="checkValue">The function that checks the character</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> Char(this Check<string> check, int index, Func<Check<char>, bool> checkValue) =>
      check.That(t => t != null && index < t.Length && checkValue.Invoke(t[index]));

    /// <summary>
    /// Checks if the character at <paramref name="index"/> in the target is not equal to <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="index">The index of the character in the string</param>
    /// <param name="value">The character to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    /// <exception cref="IndexOutOfRangeException">Thrown if <paramref name="index"/>  greater than or equal to the string's length</exception>
    public static Check<string> NotChar(this Check<string> check, int index, char value) =>
      check.Not(t => t != null && index < t.Length && t[index] == value);

    /// <summary>
    /// Checks if the character at <paramref name="index"/> in the target results in <see langword="false"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="index">The index of the character in the string</param>
    /// <param name="checkValue">The function that checks the character</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> NotChar(this Check<string> check, int index, Func<Check<char>, bool> checkValue) =>
      check.Not(t => t != null && index < t.Length && checkValue.Invoke(t[index]));

    //
    // StartsWith
    //

    /// <summary>
    /// Checks if the target starts with <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> StartsWith(this Check<string> check, string value) =>
      check.That(t => t != null && t.StartsWith(value));

    /// <summary>
    /// Checks if the target starts with <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <param name="ignoreCase">Whether to perform a case-insensitive comparison</param>
    /// <param name="culture">Cultural information to use when comparing</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> StartsWith(this Check<string> check, string value, bool ignoreCase, CultureInfo culture) =>
      check.That(t => t != null && t.StartsWith(value, ignoreCase, culture));

    /// <summary>
    /// Checks if the target starts with <paramref name="value"/> using <paramref name="comparison"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <param name="comparison">The type of comparison to perform</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> StartsWith(this Check<string> check, string value, StringComparison comparison) =>
      check.That(t => t != null && t.StartsWith(value, comparison));

    /// <summary>
    /// Checks if the target starts with <paramref name="value"/> using <see cref="StringComparison.OrdinalIgnoreCase"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> StartsWithEquivalent(this Check<string> check, string value) =>
      check.That(t => t != null && t.StartsWith(value));

    /// <summary>
    /// Checks if the target does not start with <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare at the start</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> DoesNotStartWith(this Check<string> check, string value) =>
      check.Not(t => t != null && t.StartsWith(value));

    /// <summary>
    /// Checks if the target does not start with <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare at the start</param>
    /// <param name="ignoreCase">Whether to perform a case-insensitive comparison</param>
    /// <param name="culture">Cultural information to use when comparing</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> DoesNotStartWith(this Check<string> check, string value, bool ignoreCase, CultureInfo culture) =>
      check.Not(t => t != null && t.StartsWith(value, ignoreCase, culture));

    /// <summary>
    /// Checks if the target does not start with <paramref name="value"/> using <paramref name="comparison"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare at the start</param>
    /// <param name="comparison">The type of comparison to perform</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> DoesNotStartWith(this Check<string> check, string value, StringComparison comparison) =>
      check.Not(t => t != null && t.StartsWith(value, comparison));

    /// <summary>
    /// Checks if the target does not start with <paramref name="value"/> using <see cref="StringComparison.OrdinalIgnoreCase"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare at the start</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> DoesNotStartWithEquivalent(this Check<string> check, string value) =>
      check.Not(t => t != null && t.StartsWith(value));

    //
    // EndsWith
    //

    /// <summary>
    /// Checks if the target ends with <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> EndsWith(this Check<string> check, string value) =>
      check.That(t => t != null && t.EndsWith(value));

    /// <summary>
    /// Checks if the target ends with <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <param name="ignoreCase">Whether to perform a case-insensitive comparison</param>
    /// <param name="culture">Cultural information to use when comparing</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> EndsWith(this Check<string> check, string value, bool ignoreCase, CultureInfo culture) =>
      check.That(t => t != null && t.EndsWith(value, ignoreCase, culture));

    /// <summary>
    /// Checks if the target ends with <paramref name="value"/> using <paramref name="comparison"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <param name="comparison">The type of comparison to perform</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> EndsWith(this Check<string> check, string value, StringComparison comparison) =>
      check.That(t => t != null && t.EndsWith(value, comparison));

    /// <summary>
    /// Checks if the target ends with <paramref name="value"/> using <see cref="StringComparison.OrdinalIgnoreCase"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> EndsWithEquivalent(this Check<string> check, string value) =>
      check.EndsWith(value, StringComparison.OrdinalIgnoreCase);

    /// <summary>
    /// Checks if the target does not end with <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare at the end</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> DoesNotEndWith(this Check<string> check, string value) =>
      check.Not(t => t != null && t.EndsWith(value));

    /// <summary>
    /// Checks if the target does not end with <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare at the end</param>
    /// <param name="ignoreCase">Whether to perform a case-insensitive comparison</param>
    /// <param name="culture">Cultural information to use when comparing</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> DoesNotEndWith(this Check<string> check, string value, bool ignoreCase, CultureInfo culture) =>
      check.Not(t => t != null && t.EndsWith(value, ignoreCase, culture));

    /// <summary>
    /// Checks if the target does not end with <paramref name="value"/> using <paramref name="comparison"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare at the end</param>
    /// <param name="comparison">The type of comparison to perform</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> DoesNotEndWith(this Check<string> check, string value, StringComparison comparison) =>
      check.Not(t => t != null && t.EndsWith(value, comparison));

    /// <summary>
    /// Checks if the target does not end with <paramref name="value"/> using <see cref="StringComparison.OrdinalIgnoreCase"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare at the end</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> DoesNotEndWithEquivalent(this Check<string> check, string value) =>
      check.DoesNotEndWith(value, StringComparison.OrdinalIgnoreCase);

    //
    // Contains
    //

    /// <summary>
    /// Checks if the target contains <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> Contains(this Check<string> check, string value) =>
      check.That(t => t != null && t.Contains(value));

    /// <summary>
    /// Checks if the target contains <paramref name="value"/> using <paramref name="comparison"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <param name="comparison">The type of comparison to perform</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> Contains(this Check<string> check, string value, StringComparison comparison) =>
      check.That(t => t != null && t.Contains(value, comparison));

    /// <summary>
    /// Checks if the target contains <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> Contains(this Check<string> check, char value, IEqualityComparer<char>? comparer = null) =>
      check.That(t => t != null && t.Contains(value, comparer));

    /// <summary>
    /// Checks if the target contains <paramref name="value"/> using <paramref name="comparer"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <param name="comparison">The object that performs the comparison</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> Contains(this Check<string> check, char value, StringComparison comparison) =>
      check.That(t => t != null && t.Contains(value, comparison));

    /// <summary>
    /// Checks if the target contains <paramref name="value"/> using <see cref="StringComparison.OrdinalIgnoreCase"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> ContainsEquivalent(this Check<string> check, string value) =>
      check.Contains(value, StringComparison.OrdinalIgnoreCase);

    /// <summary>
    /// Checks if the target contains <paramref name="value"/> using <see cref="StringComparison.OrdinalIgnoreCase"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <param name="comparison">The object that performs the comparison</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> ContainsEquivalent(this Check<string> check, char value) =>
      check.Contains(value, StringComparison.OrdinalIgnoreCase);

    /// <summary>
    /// Checks if the target does not contain <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> DoesNotContain(this Check<string> check, string value) =>
      check.Not(t => t != null && t.Contains(value));

    /// <summary>
    /// Checks if the target does not contain <paramref name="value"/> using <paramref name="comparison"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <param name="comparison">The type of comparison to perform</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> DoesNotContain(this Check<string> check, string value, StringComparison comparison) =>
      check.Not(t => t != null && t.Contains(value, comparison));

    /// <summary>
    /// Checks if the target does not contain <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> DoesNotContain(this Check<string> check, char value, IEqualityComparer<char>? comparer = null) =>
      check.Not(t => t != null && t.Contains(value, comparer));

    /// <summary>
    /// Checks if the target does not contain <paramref name="value"/> using <paramref name="comparer"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <param name="comparison">The object that performs the comparison</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> DoesNotContain(this Check<string> check, char value, StringComparison comparison) =>
      check.Not(t => t != null && t.Contains(value, comparison));

    /// <summary>
    /// Checks if the target does not contain <paramref name="value"/> using <see cref="StringComparison.OrdinalIgnoreCase"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> DoesNotContainEquivalent(this Check<string> check, string value) =>
      check.Contains(value, StringComparison.OrdinalIgnoreCase);

    /// <summary>
    /// Checks if the target does not contain <paramref name="value"/> using <see cref="StringComparison.OrdinalIgnoreCase"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <param name="comparison">The object that performs the comparison</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> DoesNotContainEquivalent(this Check<string> check, char value) =>
      check.Contains(value, StringComparison.OrdinalIgnoreCase);

    //
    // Matches
    //

    /// <summary>
    /// Checks if the target matches <paramref name="regex"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="regex">The regular expression to match</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> Matches(this Check<string> check, Regex regex) =>
      check.That(t => t != null && regex != null && regex.IsMatch(t));

    /// <summary>
    /// Checks if the target matches <paramref name="regex"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="regex">The regular expression to match</param>
    /// <param name="options">The options to use for the match</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> Matches(this Check<string> check, string regex, RegexOptions options) =>
      check.That(t => t != null && regex != null && Regex.IsMatch(t, regex, options));

    /// <summary>
    /// Checks if the target matches <paramref name="regex"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="regex">The regular expression to match</param>
    /// <param name="options">The options to use for the match</param>
    /// <param name="matchTimeout">The maximum time to wait before throwing <see cref="RegexMatchTimeoutException"/></param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    /// <exception cref="RegexMatchTimeoutException">Thrown if the match takes longer than <paramref name="matchTimeout"/></exception>
    public static Check<string> Matches(this Check<string> check, string regex, RegexOptions options, TimeSpan matchTimeout) =>
      check.That(t => t != null && regex != null && Regex.IsMatch(t, regex, options, matchTimeout));

    /// <summary>
    /// Checks if the target matches <paramref name="regex"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="regex">The regular expression to match</param>
    /// <param name="ignoreCase">Whether to perform a case-insensitive match</param>
    /// <param name="singleline">Whether to use single-line mode, where the period (.) matches every character (instead of every character except \n)</param>
    /// <param name="multiline">Whether to use multi-line mode, where ^ and $ match the beginning and end of each line (instead of the beginning and end of the input string)</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> Matches(this Check<string> check, string regex, bool ignoreCase = false, bool singleline = false, bool multiline = false) =>
      check.Matches(regex, ToOptions(ignoreCase, singleline, multiline));

    /// <summary>
    /// Checks if the target matches <paramref name="regex"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="regex">The regular expression to match</param>
    /// <param name="matchTimeout">The maximum time to wait before throwing <see cref="RegexMatchTimeoutException"/></param>
    /// <param name="ignoreCase">Whether to perform a case-insensitive match</param>
    /// <param name="singleline">Whether to use single-line mode, where the period (.) matches every character (instead of every character except \n)</param>
    /// <param name="multiline">Whether to use multi-line mode, where ^ and $ match the beginning and end of each line (instead of the beginning and end of the input string)</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    /// <exception cref="RegexMatchTimeoutException">Thrown if the match takes longer than <paramref name="matchTimeout"/></exception>
    public static Check<string> Matches(this Check<string> check, string regex, TimeSpan matchTimeout, bool ignoreCase = false, bool singleline = false, bool multiline = false) =>
      check.Matches(regex, ToOptions(ignoreCase, singleline, multiline), matchTimeout);

    /// <summary>
    /// Checks if the target matches <paramref name="wildcardPattern"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="wildcardPattern">The pattern to match, where * matches zero or more times and ? matches zero or one time</param>
    /// <param name="ignoreCase">Whether to perform a case-insensitive match</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> MatchesWildcard(this Check<string> check, string wildcardPattern, bool ignoreCase = false) =>
      check.Matches(ToRegex(wildcardPattern), ToOptions(ignoreCase, singleline: true, multiline: false));

    static RegexOptions ToOptions(bool ignoreCase, bool singleline, bool multiline) =>
      RegexOptions.None
      | (ignoreCase ? RegexOptions.IgnoreCase : default)
      | (singleline ? RegexOptions.Multiline : default)
      | (multiline ? RegexOptions.Singleline : default);

    static string ToRegex(string wildcardPattern) =>
      $"^{Regex.Escape(wildcardPattern).Replace("\\*", ".*").Replace("\\?", ".")}$";

    //
    // Matches (not)
    //

    /// <summary>
    /// Checks if the target does not match <paramref name="regex"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="regex">The regular expression to match</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> DoesNotMatch(this Check<string> check, Regex regex) =>
      check.Not(t => t != null && regex != null && regex.IsMatch(t));

    /// <summary>
    /// Checks if the target does not match <paramref name="regex"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="regex">The regular expression to match</param>
    /// <param name="options">The options to use for the match</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> DoesNotMatch(this Check<string> check, string regex, RegexOptions options) =>
      check.Not(t => t != null && regex != null && Regex.IsMatch(t, regex, options));

    /// <summary>
    /// Checks if the target does not match <paramref name="regex"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="regex">The regular expression to match</param>
    /// <param name="options">The options to use for the match</param>
    /// <param name="matchTimeout">The maximum time to wait before throwing <see cref="RegexMatchTimeoutException"/></param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    /// <exception cref="RegexMatchTimeoutException">Thrown if the match takes longer than <paramref name="matchTimeout"/></exception>
    public static Check<string> DoesNotMatch(this Check<string> check, string regex, RegexOptions options, TimeSpan matchTimeout) =>
      check.Not(t => t != null && regex != null && Regex.IsMatch(t, regex, options, matchTimeout));

    /// <summary>
    /// Checks if the target does not match <paramref name="regex"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="regex">The regular expression to match</param>
    /// <param name="ignoreCase">Whether to perform a case-insensitive match</param>
    /// <param name="singleline">Whether to use single-line mode, where the period (.) matches every character (instead of every character except \n)</param>
    /// <param name="multiline">Whether to use multi-line mode, where ^ and $ match the beginning and end of each line (instead of the beginning and end of the input string)</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> DoesNotMatch(this Check<string> check, string regex, bool ignoreCase = false, bool singleline = false, bool multiline = false) =>
      check.Matches(regex, ToOptions(ignoreCase, singleline, multiline));

    /// <summary>
    /// Checks if the target does not match <paramref name="regex"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="regex">The regular expression to match</param>
    /// <param name="matchTimeout">The maximum time to wait before throwing <see cref="RegexMatchTimeoutException"/></param>
    /// <param name="ignoreCase">Whether to perform a case-insensitive match</param>
    /// <param name="singleline">Whether to use single-line mode, where the period (.) matches every character (instead of every character except \n)</param>
    /// <param name="multiline">Whether to use multi-line mode, where ^ and $ match the beginning and end of each line (instead of the beginning and end of the input string)</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    /// <exception cref="RegexMatchTimeoutException">Thrown if the match takes longer than <paramref name="matchTimeout"/></exception>
    public static Check<string> DoesNotMatch(this Check<string> check, string regex, TimeSpan matchTimeout, bool ignoreCase = false, bool singleline = false, bool multiline = false) =>
      check.Matches(regex, ToOptions(ignoreCase, singleline, multiline), matchTimeout);

    /// <summary>
    /// Checks if the target does not match <paramref name="wildcardPattern"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="wildcardPattern">The pattern to match, where * matches zero or more times and ? matches zero or one time.</param>
    /// <param name="ignoreCase">Whether to perform a case-insensitive match</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> DoesNotMatchWildcard(this Check<string> check, string wildcardPattern, bool ignoreCase = false) =>
      check.Matches(ToRegex(wildcardPattern), ToOptions(ignoreCase, singleline: true, multiline: false));

    //
    // Char
    //

    /// <summary>
    /// Checks if the target is categorized as a Unicode control character
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> Control(this Check<char> check) =>
      check.That(char.IsControl);

    /// <summary>
    /// Checks if the target is categorized as a digit
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> Digit(this Check<char> check) =>
      check.That(char.IsDigit);

    /// <summary>
    /// Checks if the target is categorized as a Unicode high surrogate
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> HighSurrogate(this Check<char> check) =>
      check.That(char.IsHighSurrogate);

    /// <summary>
    /// Checks if the target is categorized as a Unicode high surrogate pair with <paramref name="lowSurrogate"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="lowSurrogate">The character to pair with the target</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> HighSurrogatePair(this Check<char> check, char lowSurrogate) =>
      check.That(t => char.IsSurrogatePair(t, lowSurrogate));

    /// <summary>
    /// Checks if the target is categorized as a letter
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> Letter(this Check<char> check) =>
      check.That(char.IsLetter);

    /// <summary>
    /// Checks if the target is categorized as a letter or digit
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> LetterOrDigit(this Check<char> check) =>
      check.That(char.IsLetterOrDigit);

    /// <summary>
    /// Checks if the target is categorized as lowercase
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> Lower(this Check<char> check) =>
      check.That(char.IsLower);

    /// <summary>
    /// Checks if the target is categorized as a Unicode low surrogate
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> LowSurrogate(this Check<char> check) =>
      check.That(char.IsLowSurrogate);

    /// <summary>
    /// Checks if the target is categorized as a Unicode low surrogate pair with <paramref name="highSurrogate"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="highSurrogate">The character to pair with the target</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> LowSurrogatePair(this Check<char> check, char highSurrogate) =>
      check.That(t => char.IsSurrogatePair(highSurrogate, t));

    /// <summary>
    /// Checks if the target is categorized as a number
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> Number(this Check<char> check) =>
      check.That(char.IsNumber);

    /// <summary>
    /// Checks if the target is categorized as punctuation
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> Punctuation(this Check<char> check) =>
      check.That(char.IsPunctuation);

    /// <summary>
    /// Checks if the target is categorized as a separator
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> Separator(this Check<char> check) =>
      check.That(char.IsSeparator);

    /// <summary>
    /// Checks if the target has a surrogate code unit
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> Surrogate(this Check<char> check) =>
      check.That(char.IsSurrogate);

    /// <summary>
    /// Checks if the target is categorized as a symbol
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> Symbol(this Check<char> check) =>
      check.That(char.IsSymbol);

    /// <summary>
    /// Checks if the target is categorized as uppercase
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> Upper(this Check<char> check) =>
      check.That(char.IsUpper);

    /// <summary>
    /// Checks if the target is categorized as white space
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> WhiteSpace(this Check<char> check) =>
      check.That(char.IsWhiteSpace);

    //
    // Char (not)
    //

    /// <summary>
    /// Checks if the target is not categorized as a Unicode control character
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> NotControl(this Check<char> check) =>
      check.Not(char.IsControl);

    /// <summary>
    /// Checks if the target is not categorized as a digit
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> NotDigit(this Check<char> check) =>
      check.Not(char.IsDigit);

    /// <summary>
    /// Checks if the target is not categorized as a Unicode high surrogate
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> NotHighSurrogate(this Check<char> check) =>
      check.Not(char.IsHighSurrogate);

    /// <summary>
    /// Checks if the target is not categorized as a Unicode high surrogate pair with <paramref name="lowSurrogate"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="lowSurrogate">The character to pair with the target</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> NotHighSurrogatePair(this Check<char> check, char lowSurrogate) =>
      check.Not(t => char.IsSurrogatePair(t, lowSurrogate));

    /// <summary>
    /// Checks if the target is not categorized as a letter
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> NotLetter(this Check<char> check) =>
      check.Not(char.IsLetter);

    /// <summary>
    /// Checks if the target is not categorized as a letter or digit
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> NotLetterOrDigit(this Check<char> check) =>
      check.Not(char.IsLetterOrDigit);

    /// <summary>
    /// Checks if the target is not categorized as lowercase
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> NotLower(this Check<char> check) =>
      check.Not(char.IsLower);

    /// <summary>
    /// Checks if the target is not categorized as a Unicode low surrogate
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> NotLowSurrogate(this Check<char> check) =>
      check.Not(char.IsLowSurrogate);

    /// <summary>
    /// Checks if the target is not categorized as a Unicode low surrogate pair with <paramref name="highSurrogate"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="highSurrogate">The character to pair with the target</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> NotLowSurrogatePair(this Check<char> check, char highSurrogate) =>
      check.Not(t => char.IsSurrogatePair(highSurrogate, t));

    /// <summary>
    /// Checks if the target is not categorized as a number
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> NotNumber(this Check<char> check) =>
      check.Not(char.IsNumber);

    /// <summary>
    /// Checks if the target is not categorized as punctuation
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> NotPunctuation(this Check<char> check) =>
      check.Not(char.IsPunctuation);

    /// <summary>
    /// Checks if the target is not categorized as a separator
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> NotSeparator(this Check<char> check) =>
      check.Not(char.IsSeparator);

    /// <summary>
    /// Checks if the target has a surrogate code unit
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> NotSurrogate(this Check<char> check) =>
      check.Not(char.IsSurrogate);

    /// <summary>
    /// Checks if the target is not categorized as a symbol
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> NotSymbol(this Check<char> check) =>
      check.Not(char.IsSymbol);

    /// <summary>
    /// Checks if the target is not categorized as uppercase
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> NotUpper(this Check<char> check) =>
      check.Not(char.IsUpper);

    /// <summary>
    /// Checks if the target is not categorized as white space
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> NotWhiteSpace(this Check<char> check) =>
      check.Not(char.IsWhiteSpace);

    //
    // Uri
    //

    /// <summary>
    /// Checks if the target's <see cref="Uri.AbsolutePath"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> AbsolutePath(this Check<Uri> check, string value) =>
      check.That(t => t?.AbsolutePath == value);

    /// <summary>
    /// Checks if the target's <see cref="Uri.AbsoluteUri"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> AbsoluteUri(this Check<Uri> check, string value) =>
      check.That(t => t?.AbsoluteUri == value);

    /// <summary>
    /// Checks if the target's <see cref="Uri.Authority"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> Authority(this Check<Uri> check, string value) =>
      check.That(t => t?.Authority == value);

    /// <summary>
    /// Checks if the target's <see cref="Uri.DnsSafeHost"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> DnsSafeHost(this Check<Uri> check, string value) =>
      check.That(t => t?.DnsSafeHost == value);

    /// <summary>
    /// Checks if the target's <see cref="Uri.Fragment"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> Fragment(this Check<Uri> check, string value) =>
      check.That(t => t?.Fragment == value);

    /// <summary>
    /// Checks if the target's <see cref="Uri.Host"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> Host(this Check<Uri> check, string value) =>
      check.That(t => t?.Host == value);

    /// <summary>
    /// Checks if the target's <see cref="Uri.HostNameType"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> HostNameType(this Check<Uri> check, UriHostNameType value) =>
      check.That(t => t?.HostNameType == value);

    /// <summary>
    /// Checks if the target's <see cref="Uri.IdnHost"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> IdnHost(this Check<Uri> check, string value) =>
      check.That(t => t?.IdnHost == value);

    /// <summary>
    /// Checks if the target's <see cref="Uri.LocalPath"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> LocalPath(this Check<Uri> check, string value) =>
      check.That(t => t?.LocalPath == value);

    /// <summary>
    /// Checks if the target's <see cref="Uri.OriginalString"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> OriginalString(this Check<Uri> check, string value) =>
      check.That(t => t?.OriginalString == value);

    /// <summary>
    /// Checks if the target's <see cref="Uri.PathAndQuery"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> PathAndQuery(this Check<Uri> check, string value) =>
      check.That(t => t?.PathAndQuery == value);

    /// <summary>
    /// Checks if the target's <see cref="Uri.Port"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> Port(this Check<Uri> check, int value) =>
      check.That(t => t?.Port == value);

    /// <summary>
    /// Checks if the target's <see cref="Uri.Query"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> Query(this Check<Uri> check, string value) =>
      check.That(t => t?.Query == value);

    /// <summary>
    /// Checks if the target's <see cref="Uri.Scheme"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> Scheme(this Check<Uri> check, string value) =>
      check.That(t => t?.Scheme == value);

    /// <summary>
    /// Checks if the target's <see cref="Uri.Segments"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> Segments(this Check<Uri> check, string[] value) =>
      check.That(t => Check.Many(t.Segments).HasSameInOrder(value));

    /// <summary>
    /// Checks if the target's <see cref="Uri.UserInfo"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> UserInfo(this Check<Uri> check, string value) =>
      check.That(t => t?.UserInfo == value);

    /// <summary>
    /// Checks if the target's <see cref="Uri.IsAbsoluteUri"/> property is <see langword="true"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> AbsoluteUri(this Check<Uri> check) =>
      check.That(t => t?.IsAbsoluteUri == true);

    /// <summary>
    /// Checks if the target's <see cref="Uri.IsFile"/> property is <see langword="true"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> File(this Check<Uri> check) =>
      check.That(t => t?.IsFile == true);

    /// <summary>
    /// Checks if the target's <see cref="Uri.AbsolutePath"/> property is <see langword="true"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> Unc(this Check<Uri> check) =>
      check.That(t => t?.IsUnc == true);

    /// <summary>
    /// Checks if the target's <see cref="Uri.IsLoopback"/> property is <see langword="true"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> Loopback(this Check<Uri> check) =>
      check.That(t => t?.IsLoopback == true);

    /// <summary>
    /// Checks if the target's <see cref="Uri.UserEscaped"/> property is <see langword="true"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> UserEscaped(this Check<Uri> check) =>
      check.That(t => t?.UserEscaped == true);

    /// <summary>
    /// Checks if the target's <see cref="Uri.IsAbsoluteUri"/> property is <see langword="true"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> NotAbsoluteUri(this Check<Uri> check) =>
      check.That(t => t?.IsAbsoluteUri == false);

    /// <summary>
    /// Checks if the target's <see cref="Uri.IsFile"/> property is <see langword="true"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> NotFile(this Check<Uri> check) =>
      check.That(t => t?.IsFile == false);

    /// <summary>
    /// Checks if the target's <see cref="Uri.AbsolutePath"/> property is <see langword="true"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> NotUnc(this Check<Uri> check) =>
      check.That(t => t?.IsUnc == false);

    /// <summary>
    /// Checks if the target's <see cref="Uri.IsLoopback"/> property is <see langword="true"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> NotLoopback(this Check<Uri> check) =>
      check.That(t => t?.IsLoopback == false);

    /// <summary>
    /// Checks if the target's <see cref="Uri.UserEscaped"/> property is <see langword="false"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> NotUserEscaped(this Check<Uri> check) =>
      check.That(t => t?.UserEscaped == false);

    //
    // Uri (values)
    //

    /// <summary>
    /// Checks if the target's <see cref="Uri.AbsolutePath"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> AbsolutePath(this Check<Uri> check, Func<Check<string>, bool> checkValue) =>
      check.That(t => t != null && checkValue.Invoke(t.AbsolutePath));

    /// <summary>
    /// Checks if the target's <see cref="Uri.AbsoluteUri"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> AbsoluteUri(this Check<Uri> check, Func<Check<string>, bool> checkValue) =>
      check.That(t => t != null && checkValue.Invoke(t.AbsoluteUri));

    /// <summary>
    /// Checks if the target's <see cref="Uri.Authority"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> Authority(this Check<Uri> check, Func<Check<string>, bool> checkValue) =>
      check.That(t => t != null && checkValue.Invoke(t.Authority));

    /// <summary>
    /// Checks if the target's <see cref="Uri.DnsSafeHost"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> DnsSafeHost(this Check<Uri> check, Func<Check<string>, bool> checkValue) =>
      check.That(t => t != null && checkValue.Invoke(t.DnsSafeHost));

    /// <summary>
    /// Checks if the target's <see cref="Uri.Fragment"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> Fragment(this Check<Uri> check, Func<Check<string>, bool> checkValue) =>
      check.That(t => t != null && checkValue.Invoke(t.Fragment));

    /// <summary>
    /// Checks if the target's <see cref="Uri.Host"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> Host(this Check<Uri> check, Func<Check<string>, bool> checkValue) =>
      check.That(t => t != null && checkValue.Invoke(t.Host));

    /// <summary>
    /// Checks if the target's <see cref="Uri.HostNameType"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> HostNameType(this Check<Uri> check, Func<Check<UriHostNameType>, bool> checkValue) =>
      check.That(t => t != null && checkValue.Invoke(t.HostNameType));

    /// <summary>
    /// Checks if the target's <see cref="Uri.IdnHost"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> IdnHost(this Check<Uri> check, Func<Check<string>, bool> checkValue) =>
      check.That(t => t != null && checkValue.Invoke(t.IdnHost));

    /// <summary>
    /// Checks if the target's <see cref="Uri.LocalPath"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> LocalPath(this Check<Uri> check, Func<Check<string>, bool> checkValue) =>
      check.That(t => t != null && checkValue.Invoke(t.LocalPath));

    /// <summary>
    /// Checks if the target's <see cref="Uri.OriginalString"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> OriginalString(this Check<Uri> check, Func<Check<string>, bool> checkValue) =>
      check.That(t => t != null && checkValue.Invoke(t.OriginalString));

    /// <summary>
    /// Checks if the target's <see cref="Uri.PathAndQuery"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> PathAndQuery(this Check<Uri> check, Func<Check<string>, bool> checkValue) =>
      check.That(t => t != null && checkValue.Invoke(t.PathAndQuery));

    /// <summary>
    /// Checks if the target's <see cref="Uri.Port"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> Port(this Check<Uri> check, Func<Check<int>, bool> checkValue) =>
      check.That(t => t != null && checkValue.Invoke(t.Port));

    /// <summary>
    /// Checks if the target's <see cref="Uri.Query"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> Query(this Check<Uri> check, Func<Check<string>, bool> checkValue) =>
      check.That(t => t != null && checkValue.Invoke(t.Query));

    /// <summary>
    /// Checks if the target's <see cref="Uri.Scheme"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> Scheme(this Check<Uri> check, Func<Check<string>, bool> checkValue) =>
      check.That(t => t != null && checkValue.Invoke(t.Scheme));

    /// <summary>
    /// Checks if the target's <see cref="Uri.Segments"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> Segments(this Check<Uri> check, Func<CheckMany<string>, bool> checkValue) =>
      check.That(t => t != null && checkValue.Invoke(t.Segments));

    /// <summary>
    /// Checks if the target's <see cref="Uri.UserInfo"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> UserInfo(this Check<Uri> check, Func<Check<string>, bool> checkValue) =>
      check.That(t => t != null && checkValue.Invoke(t.UserInfo));
  }
}