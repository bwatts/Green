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
    /// Checks if the target equals <paramref name="value"/> using <paramref name="comparison"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare using <paramref name="comparison"/></param>
    /// <param name="comparison">The type of comparison to perform</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> Is(this Check<string> check, string value, StringComparison comparison) =>
      check.That(t => string.Equals(t, value, comparison));

    /// <summary>
    /// Checks if the target equals the empty string
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> IsEmpty(this Check<string> check) =>
      check.That(t => t == "");

    /// <summary>
    /// Checks if the target is only whitespace
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> IsWhiteSpace(this Check<string> check) =>
      check.That(t => t != null && string.IsNullOrWhiteSpace(t));

    /// <summary>
    /// Checks if the target is <see langword="null"/> or the empty string
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> IsNullOrEmpty(this Check<string> check) =>
      check.That(string.IsNullOrEmpty);

    /// <summary>
    /// Checks if the target is <see langword="null"/> or only whitespace
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> IsNullOrWhiteSpace(this Check<string> check) =>
      check.That(string.IsNullOrWhiteSpace);

    /// <summary>
    /// Checks if the target is not equal to <paramref name="value"/> using <paramref name="comparison"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare using <paramref name="comparison"/></param>
    /// <param name="comparison">The type of comparison to perform</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> IsNot(this Check<string> check, string value, StringComparison comparison) =>
      check.Not(t => string.Equals(t, value, comparison));

    /// <summary>
    /// Checks if the target is not equal to the empty string
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> IsNotEmpty(this Check<string> check) =>
      check.That(t => t != "");

    /// <summary>
    /// Checks if the target is not only whitespace
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> IsNotWhiteSpace(this Check<string> check) =>
      check.Not(t => t != null && string.IsNullOrWhiteSpace(t));

    /// <summary>
    /// Checks if the target is not <see langword="null"/> or the empty string
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> IsNotNullOrEmpty(this Check<string> check) =>
      check.Not(string.IsNullOrEmpty);

    /// <summary>
    /// Checks if the target is <see langword="null"/> or only whitespace
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> IsNotNullOrWhiteSpace(this Check<string> check) =>
      check.Not(string.IsNullOrWhiteSpace);

    //
    // Has
    //

    /// <summary>
    /// Checks if the <see cref="string.Length"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The length to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> HasLength(this Check<string> check, int value) =>
      check.That(t => t?.Length == value);

    /// <summary>
    /// Checks if the <see cref="string.Length"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> HasLength(this Check<string> check, Func<Check<int>, bool> checkValue) =>
      check.That(t => t != null && checkValue.Invoke(t.Length));

    /// <summary>
    /// Checks if the character at <paramref name="index"/> in the target equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="index">The index of the character in the string</param>
    /// <param name="value">The character to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    /// <exception cref="IndexOutOfRangeException">Thrown if <paramref name="index"/> is greater than or equal to the string's length</exception>
    public static Check<string> HasChar(this Check<string> check, int index, char value) =>
      check.That(t => t != null && index < t.Length && t[index] == value);

    /// <summary>
    /// Checks if the character at <paramref name="index"/> in the target results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="index">The index of the character in the string</param>
    /// <param name="checkValue">The function that checks the character</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> HasChar(this Check<string> check, int index, Func<Check<char>, bool> checkValue) =>
      check.That(t => t != null && index < t.Length && checkValue.Invoke(t[index]));

    //
    // Content
    //

    /// <summary>
    /// Checks if the target starts with <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare at the start</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> StartsWith(this Check<string> check, string value) =>
      check.That(t => t != null && t.StartsWith(value));

    /// <summary>
    /// Checks if the target starts with <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare at the start</param>
    /// <param name="ignoreCase">Whether to ignore case when comparing</param>
    /// <param name="culture">Cultural information to use when comparing</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> StartsWith(this Check<string> check, string value, bool ignoreCase, CultureInfo culture) =>
      check.That(t => t != null && t.StartsWith(value, ignoreCase, culture));

    /// <summary>
    /// Checks if the target starts with <paramref name="value"/> using <paramref name="comparison"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare at the start</param>
    /// <param name="comparison">The type of comparison to perform</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> StartsWith(this Check<string> check, string value, StringComparison comparison) =>
      check.That(t => t != null && t.StartsWith(value, comparison));

    /// <summary>
    /// Checks if the target ends with <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare at the end</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> EndsWith(this Check<string> check, string value) =>
      check.That(t => t != null && t.EndsWith(value));

    /// <summary>
    /// Checks if the target ends with <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare at the end</param>
    /// <param name="ignoreCase">Whether to ignore case when comparing</param>
    /// <param name="culture">Cultural information to use when comparing</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> EndsWith(this Check<string> check, string value, bool ignoreCase, CultureInfo culture) =>
      check.That(t => t != null && t.EndsWith(value, ignoreCase, culture));

    /// <summary>
    /// Checks if the target ends with <paramref name="value"/> using <paramref name="comparison"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare at the end</param>
    /// <param name="comparison">The type of comparison to perform</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> EndsWith(this Check<string> check, string value, StringComparison comparison) =>
      check.That(t => t != null && t.EndsWith(value, comparison));

    /// <summary>
    /// Checks if the target contains <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> Contains(this Check<string> check, string value) =>
      check.That(t => t != null && t.Contains(value));

    /// <summary>
    /// Checks if the target contains <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> Contains(this Check<string> check, char value) =>
      check.That(t => t != null && t.Contains(value));

    /// <summary>
    /// Checks if the target contains <paramref name="value"/> using <paramref name="comparer"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare using <paramref name="comparer"/></param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> Contains(this Check<string> check, char value, IEqualityComparer<char> comparer) =>
      check.That(t => t != null && t.Contains(value, comparer));

    //
    // Content (not)
    //

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
    /// <param name="ignoreCase">Whether to ignore case when comparing</param>
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
    /// <param name="ignoreCase">Whether to ignore case when comparing</param>
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
    /// Checks if the target does not contain <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> DoesNotContain(this Check<string> check, string value) =>
      check.Not(t => t != null && t.Contains(value));

    /// <summary>
    /// Checks if the target does not contain <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> DoesNotContain(this Check<string> check, char value) =>
      check.Not(t => t != null && t.Contains(value));

    /// <summary>
    /// Checks if the target does not contain <paramref name="value"/> using <paramref name="comparer"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare using <paramref name="comparer"/></param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<string> DoesNotContain(this Check<string> check, char value, IEqualityComparer<char> comparer) =>
      check.Not(t => t != null && t.Contains(value, comparer));

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
    /// <param name="ignoreCase">Whether to ignore case when matching</param>
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
    /// <param name="ignoreCase">Whether to ignore case when matching</param>
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
    /// <param name="wildcardPattern">The pattern to match, where * matches zero or more times and ? matches zero or one time.</param>
    /// <param name="ignoreCase">Whether to ignore case when matching</param>
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
    /// <param name="ignoreCase">Whether to ignore case when matching</param>
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
    /// <param name="ignoreCase">Whether to ignore case when matching</param>
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
    /// <param name="ignoreCase">Whether to ignore case when matching</param>
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
    public static Check<char> IsControl(this Check<char> check) =>
      check.That(char.IsControl);

    /// <summary>
    /// Checks if the target is categorized as a digit
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> IsDigit(this Check<char> check) =>
      check.That(char.IsDigit);

    /// <summary>
    /// Checks if the target is categorized as a Unicode high surrogate
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> IsHighSurrogate(this Check<char> check) =>
      check.That(char.IsHighSurrogate);

    /// <summary>
    /// Checks if the target is categorized as a Unicode high surrogate pair with <paramref name="lowSurrogate"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="lowSurrogate">The character to pair with the target</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> IsHighSurrogatePair(this Check<char> check, char lowSurrogate) =>
      check.That(t => char.IsSurrogatePair(t, lowSurrogate));

    /// <summary>
    /// Checks if the target is categorized as a letter
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> IsLetter(this Check<char> check) =>
      check.That(char.IsLetter);

    /// <summary>
    /// Checks if the target is categorized as a letter or digit
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> IsLetterOrDigit(this Check<char> check) =>
      check.That(char.IsLetterOrDigit);

    /// <summary>
    /// Checks if the target is categorized as lowercase
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> IsLower(this Check<char> check) =>
      check.That(char.IsLower);

    /// <summary>
    /// Checks if the target is categorized as a Unicode low surrogate
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> IsLowSurrogate(this Check<char> check) =>
      check.That(char.IsLowSurrogate);

    /// <summary>
    /// Checks if the target is categorized as a Unicode low surrogate pair with <paramref name="highSurrogate"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="highSurrogate">The character to pair with the target</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> IsLowSurrogatePair(this Check<char> check, char highSurrogate) =>
      check.That(t => char.IsSurrogatePair(highSurrogate, t));

    /// <summary>
    /// Checks if the target is categorized as a number
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> IsNumber(this Check<char> check) =>
      check.That(char.IsNumber);

    /// <summary>
    /// Checks if the target is categorized as punctuation
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> IsPunctuation(this Check<char> check) =>
      check.That(char.IsPunctuation);

    /// <summary>
    /// Checks if the target is categorized as a separator
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> IsSeparator(this Check<char> check) =>
      check.That(char.IsSeparator);

    /// <summary>
    /// Checks if the target has a surrogate code unit
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> IsSurrogate(this Check<char> check) =>
      check.That(char.IsSurrogate);

    /// <summary>
    /// Checks if the target is categorized as a symbol
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> IsSymbol(this Check<char> check) =>
      check.That(char.IsSymbol);

    /// <summary>
    /// Checks if the target is categorized as uppercase
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> IsUpper(this Check<char> check) =>
      check.That(char.IsUpper);

    /// <summary>
    /// Checks if the target is categorized as white space
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> IsWhiteSpace(this Check<char> check) =>
      check.That(char.IsWhiteSpace);

    //
    // Char (not)
    //

    /// <summary>
    /// Checks if the target is not categorized as a Unicode control character
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> IsNotControl(this Check<char> check) =>
      check.Not(char.IsControl);

    /// <summary>
    /// Checks if the target is not categorized as a digit
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> IsNotDigit(this Check<char> check) =>
      check.Not(char.IsDigit);

    /// <summary>
    /// Checks if the target is not categorized as a Unicode high surrogate
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> IsNotHighSurrogate(this Check<char> check) =>
      check.Not(char.IsHighSurrogate);

    /// <summary>
    /// Checks if the target is not categorized as a Unicode high surrogate pair with <paramref name="lowSurrogate"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="lowSurrogate">The character to pair with the target</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> IsNotHighSurrogatePair(this Check<char> check, char lowSurrogate) =>
      check.Not(t => char.IsSurrogatePair(t, lowSurrogate));

    /// <summary>
    /// Checks if the target is not categorized as a letter
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> IsNotLetter(this Check<char> check) =>
      check.Not(char.IsLetter);

    /// <summary>
    /// Checks if the target is not categorized as a letter or digit
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> IsNotLetterOrDigit(this Check<char> check) =>
      check.Not(char.IsLetterOrDigit);

    /// <summary>
    /// Checks if the target is not categorized as lowercase
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> IsNotLower(this Check<char> check) =>
      check.Not(char.IsLower);

    /// <summary>
    /// Checks if the target is not categorized as a Unicode low surrogate
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> IsNotLowSurrogate(this Check<char> check) =>
      check.Not(char.IsLowSurrogate);

    /// <summary>
    /// Checks if the target is not categorized as a Unicode low surrogate pair with <paramref name="highSurrogate"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="highSurrogate">The character to pair with the target</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> IsNotLowSurrogatePair(this Check<char> check, char highSurrogate) =>
      check.Not(t => char.IsSurrogatePair(highSurrogate, t));

    /// <summary>
    /// Checks if the target is not categorized as a number
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> IsNotNumber(this Check<char> check) =>
      check.Not(char.IsNumber);

    /// <summary>
    /// Checks if the target is not categorized as punctuation
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> IsNotPunctuation(this Check<char> check) =>
      check.Not(char.IsPunctuation);

    /// <summary>
    /// Checks if the target is not categorized as a separator
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> IsNotSeparator(this Check<char> check) =>
      check.Not(char.IsSeparator);

    /// <summary>
    /// Checks if the target has a surrogate code unit
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> IsNotSurrogate(this Check<char> check) =>
      check.Not(char.IsSurrogate);

    /// <summary>
    /// Checks if the target is not categorized as a symbol
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> IsNotSymbol(this Check<char> check) =>
      check.Not(char.IsSymbol);

    /// <summary>
    /// Checks if the target is not categorized as uppercase
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> IsNotUpper(this Check<char> check) =>
      check.Not(char.IsUpper);

    /// <summary>
    /// Checks if the target is not categorized as white space
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<char> IsNotWhiteSpace(this Check<char> check) =>
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
    public static Check<Uri> HasAbsolutePath(this Check<Uri> check, string value) =>
      check.That(t => t?.AbsolutePath == value);

    /// <summary>
    /// Checks if the target's <see cref="Uri.AbsoluteUri"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> HasAbsoluteUri(this Check<Uri> check, string value) =>
      check.That(t => t?.AbsoluteUri == value);

    /// <summary>
    /// Checks if the target's <see cref="Uri.Authority"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> HasAuthority(this Check<Uri> check, string value) =>
      check.That(t => t?.Authority == value);

    /// <summary>
    /// Checks if the target's <see cref="Uri.DnsSafeHost"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> HasDnsSafeHost(this Check<Uri> check, string value) =>
      check.That(t => t?.DnsSafeHost == value);

    /// <summary>
    /// Checks if the target's <see cref="Uri.Fragment"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> HasFragment(this Check<Uri> check, string value) =>
      check.That(t => t?.Fragment == value);

    /// <summary>
    /// Checks if the target's <see cref="Uri.Host"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> HasHost(this Check<Uri> check, string value) =>
      check.That(t => t?.Host == value);

    /// <summary>
    /// Checks if the target's <see cref="Uri.HostNameType"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> HasHostNameType(this Check<Uri> check, UriHostNameType value) =>
      check.That(t => t?.HostNameType == value);

    /// <summary>
    /// Checks if the target's <see cref="Uri.IdnHost"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> HasIdnHost(this Check<Uri> check, string value) =>
      check.That(t => t?.IdnHost == value);

    /// <summary>
    /// Checks if the target's <see cref="Uri.LocalPath"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> HasLocalPath(this Check<Uri> check, string value) =>
      check.That(t => t?.LocalPath == value);

    /// <summary>
    /// Checks if the target's <see cref="Uri.OriginalString"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> HasOriginalString(this Check<Uri> check, string value) =>
      check.That(t => t?.OriginalString == value);

    /// <summary>
    /// Checks if the target's <see cref="Uri.PathAndQuery"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> HasPathAndQuery(this Check<Uri> check, string value) =>
      check.That(t => t?.PathAndQuery == value);

    /// <summary>
    /// Checks if the target's <see cref="Uri.Port"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> HasPort(this Check<Uri> check, int value) =>
      check.That(t => t?.Port == value);

    /// <summary>
    /// Checks if the target's <see cref="Uri.Query"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> HasQuery(this Check<Uri> check, string value) =>
      check.That(t => t?.Query == value);

    /// <summary>
    /// Checks if the target's <see cref="Uri.Scheme"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> HasScheme(this Check<Uri> check, string value) =>
      check.That(t => t?.Scheme == value);

    /// <summary>
    /// Checks if the target's <see cref="Uri.Segments"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> HasSegments(this Check<Uri> check, string[] value) =>
      check.That(t => CheckMany.That(t.Segments).HasSameInOrder(value));

    /// <summary>
    /// Checks if the target's <see cref="Uri.UserInfo"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> HasUserInfo(this Check<Uri> check, string value) =>
      check.That(t => t?.UserInfo == value);

    /// <summary>
    /// Checks if the target's <see cref="Uri.IsAbsoluteUri"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> IsAbsoluteUri(this Check<Uri> check, bool value) =>
      check.That(t => t?.IsAbsoluteUri == value);

    /// <summary>
    /// Checks if the target's <see cref="Uri.IsFile"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> IsFile(this Check<Uri> check, bool value) =>
      check.That(t => t?.IsFile == value);

    /// <summary>
    /// Checks if the target's <see cref="Uri.AbsolutePath"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> IsUnc(this Check<Uri> check, bool value) =>
      check.That(t => t?.IsUnc == value);

    /// <summary>
    /// Checks if the target's <see cref="Uri.IsLoopback"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> IsLoopback(this Check<Uri> check, bool value) =>
      check.That(t => t?.IsLoopback == value);

    /// <summary>
    /// Checks if the target's <see cref="Uri.UserEscaped"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="value">The value to compare</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> IsUserEscaped(this Check<Uri> check, bool value) =>
      check.That(t => t?.UserEscaped == value);

    //
    // Uri (values)
    //

    /// <summary>
    /// Checks if the target's <see cref="Uri.AbsolutePath"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> HasAbsolutePath(this Check<Uri> check, Func<Check<string>, bool> checkValue) =>
      check.That(t => t != null && checkValue.Invoke(t.AbsolutePath));

    /// <summary>
    /// Checks if the target's <see cref="Uri.AbsoluteUri"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> HasAbsoluteUri(this Check<Uri> check, Func<Check<string>, bool> checkValue) =>
      check.That(t => t != null && checkValue.Invoke(t.AbsoluteUri));

    /// <summary>
    /// Checks if the target's <see cref="Uri.Authority"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> HasAuthority(this Check<Uri> check, Func<Check<string>, bool> checkValue) =>
      check.That(t => t != null && checkValue.Invoke(t.Authority));

    /// <summary>
    /// Checks if the target's <see cref="Uri.DnsSafeHost"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> HasDnsSafeHost(this Check<Uri> check, Func<Check<string>, bool> checkValue) =>
      check.That(t => t != null && checkValue.Invoke(t.DnsSafeHost));

    /// <summary>
    /// Checks if the target's <see cref="Uri.Fragment"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> HasFragment(this Check<Uri> check, Func<Check<string>, bool> checkValue) =>
      check.That(t => t != null && checkValue.Invoke(t.Fragment));

    /// <summary>
    /// Checks if the target's <see cref="Uri.Host"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> HasHost(this Check<Uri> check, Func<Check<string>, bool> checkValue) =>
      check.That(t => t != null && checkValue.Invoke(t.Host));

    /// <summary>
    /// Checks if the target's <see cref="Uri.HostNameType"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> HasHostNameType(this Check<Uri> check, Func<Check<UriHostNameType>, bool> checkValue) =>
      check.That(t => t != null && checkValue.Invoke(t.HostNameType));

    /// <summary>
    /// Checks if the target's <see cref="Uri.IdnHost"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> HasIdnHost(this Check<Uri> check, Func<Check<string>, bool> checkValue) =>
      check.That(t => t != null && checkValue.Invoke(t.IdnHost));

    /// <summary>
    /// Checks if the target's <see cref="Uri.LocalPath"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> HasLocalPath(this Check<Uri> check, Func<Check<string>, bool> checkValue) =>
      check.That(t => t != null && checkValue.Invoke(t.LocalPath));

    /// <summary>
    /// Checks if the target's <see cref="Uri.OriginalString"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> HasOriginalString(this Check<Uri> check, Func<Check<string>, bool> checkValue) =>
      check.That(t => t != null && checkValue.Invoke(t.OriginalString));

    /// <summary>
    /// Checks if the target's <see cref="Uri.PathAndQuery"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> HasPathAndQuery(this Check<Uri> check, Func<Check<string>, bool> checkValue) =>
      check.That(t => t != null && checkValue.Invoke(t.PathAndQuery));

    /// <summary>
    /// Checks if the target's <see cref="Uri.Port"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> HasPort(this Check<Uri> check, Func<Check<int>, bool> checkValue) =>
      check.That(t => t != null && checkValue.Invoke(t.Port));

    /// <summary>
    /// Checks if the target's <see cref="Uri.Query"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> HasQuery(this Check<Uri> check, Func<Check<string>, bool> checkValue) =>
      check.That(t => t != null && checkValue.Invoke(t.Query));

    /// <summary>
    /// Checks if the target's <see cref="Uri.Scheme"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> HasScheme(this Check<Uri> check, Func<Check<string>, bool> checkValue) =>
      check.That(t => t != null && checkValue.Invoke(t.Scheme));

    /// <summary>
    /// Checks if the target's <see cref="Uri.Segments"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> HasSegments(this Check<Uri> check, Func<CheckMany<string>, bool> checkValue) =>
      check.That(t => t != null && checkValue.Invoke(t.Segments));

    /// <summary>
    /// Checks if the target's <see cref="Uri.UserInfo"/> property results in <see langword="true"/> from <paramref name="checkValue"/>
    /// </summary>
    /// <param name="check">The <see langword="bool"/>-valued query being continued</param>
    /// <param name="checkValue">The function that checks the property value</param>
    /// <returns>A continuation of <paramref name="check"/> applying this operator. Implicitly converts to <see langword="bool"/>.</returns>
    public static Check<Uri> HasUserInfo(this Check<Uri> check, Func<Check<string>, bool> checkValue) =>
      check.That(t => t != null && checkValue.Invoke(t.UserInfo));
  }
}