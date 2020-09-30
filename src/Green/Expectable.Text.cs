using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Green
{
  public static partial class Expectable
  {
    /// <summary>
    /// Expects the target equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<string> Is(this Expect<string> expect, string value, Issue<string>? issue = null) =>
      expect.That(t => string.Equals(t, value), issue.Operator(value));

    /// <summary>
    /// Expects the target equals <paramref name="value"/> using <paramref name="comparison"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare using <paramref name="comparison"/></param>
    /// <param name="comparison">The type of comparison to perform</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<string> Is(this Expect<string> expect, string value, StringComparison comparison, Issue<string>? issue = null) =>
      expect.That(t => string.Equals(t, value, comparison), issue.Operator(value, comparison));

    /// <summary>
    /// Expects the target equals the empty string ("")
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<string> IsEmpty(this Expect<string> expect, Issue<string>? issue = null) =>
      expect.That(t => t == "", issue.Operator());

    /// <summary>
    /// Expects the target is whitespace only
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<string> IsWhiteSpace(this Expect<string> expect, Issue<string>? issue = null) =>
      expect.That(t => t != null && string.IsNullOrWhiteSpace(t), issue.Operator());

    /// <summary>
    /// Expects the target is <see langword="null"/> or the empty string ("")
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<string> IsNullOrEmpty(this Expect<string> expect, Issue<string>? issue = null) =>
      expect.That(string.IsNullOrEmpty, issue.Operator());

    /// <summary>
    /// Expects the target is <see langword="null"/> or whitespace only
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<string> IsNullOrWhiteSpace(this Expect<string> expect, Issue<string>? issue = null) =>
      expect.That(string.IsNullOrWhiteSpace, issue.Operator());

    //
    // Is not
    //

    /// <summary>
    /// Expects the target does not equal <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<string> IsNot(this Expect<string> expect, string value, Issue<string>? issue = null) =>
      expect.That(t => !string.Equals(t, value), issue.Operator(value));

    /// <summary>
    /// Expects the target equals <paramref name="value"/> using <paramref name="comparison"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare using <paramref name="comparison"/></param>
    /// <param name="comparison">The type of comparison to perform</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<string> IsNot(this Expect<string> expect, string value, StringComparison comparison, Issue<string>? issue = null) =>
      expect.That(t => !string.Equals(t, value, comparison), issue.Operator(value, comparison));

    /// <summary>
    /// Expects the target does not equal the empty string ("")
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<string> IsNotEmpty(this Expect<string> expect, Issue<string>? issue = null) =>
      expect.That(t => t != "", issue.Operator());

    /// <summary>
    /// Expects the target is not whitespace only
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<string> IsNotWhiteSpace(this Expect<string> expect, Issue<string>? issue = null) =>
      expect.That(t => !string.IsNullOrWhiteSpace(t), issue.Operator());

    /// <summary>
    /// Expects the target is <see langword="null"/> or the empty string ("")
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<string> IsNotNullOrEmpty(this Expect<string> expect, Issue<string>? issue = null) =>
      expect.That(t => !string.IsNullOrEmpty(t), issue.Operator());

    /// <summary>
    /// Expects the target is <see langword="null"/> or whitespace only
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<string> IsNotNullOrWhiteSpace(this Expect<string> expect, Issue<string>? issue = null) =>
      expect.That(t => !string.IsNullOrWhiteSpace(t), issue.Operator());

    //
    // Has
    //

    /// <summary>
    /// Expects the target's <see cref="string.Length"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The length to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<string> HasLength(this Expect<string> expect, int value, Issue<string>? issue = null) =>
      expect.That(t => t?.Length == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="string.Length"/> to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<string> HasLength(this Expect<string> expect, Action<Expect<int>> expectValue) =>
      expect.That(t => t != null && expectValue.Invoke(t.Length));

    /// <summary>
    /// Expects the target's character at <paramref name="index"/> equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="index">The index of the character to compare</param>
    /// <param name="value">The character to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<string> HasChar(this Expect<string> expect, int index, char value, Issue<string>? issue = null) =>
      expect.That(t => t != null && index < t.Length && t[index] == value, issue.Operator(index, value));

    /// <summary>
    /// Expects the target's character at <paramref name="index"/> to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="index">The index of the character to compare</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<string> HasChar(this Expect<string> expect, int index, Action<Expect<char>> expectValue) =>
      expect.That(t => t != null && index < t.Length && expectValue.Invoke(t[index]));

    //
    // Content
    //

    /// <summary>
    /// Expects the target starts with <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<string> StartsWith(this Expect<string> expect, string value, Issue<string>? issue = null) =>
      expect.That(t => t != null && t.StartsWith(value), issue.Operator(value));

    /// <summary>
    /// Expects the target starts with <paramref name="value"/> using <paramref name="comparison"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="comparison">The object that performs the comparison</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<string> StartsWith(this Expect<string> expect, string value, StringComparison comparison, Issue<string>? issue = null) =>
      expect.That(t => t != null && t.StartsWith(value, comparison), issue.Operator(value, comparison));

    /// <summary>
    /// Expects the target starts with <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="ignoreCase">Whether to perform a case-insensitive comparison</param>
    /// <param name="culture">Cultural information to use when comparing</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<string> StartsWith(this Expect<string> expect, string value, bool ignoreCase, CultureInfo culture, Issue<string>? issue = null) =>
      expect.That(t => t != null && t.StartsWith(value, ignoreCase, culture), issue.Operator(value, ignoreCase, culture));

    /// <summary>
    /// Expects the target ends with <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<string> EndsWith(this Expect<string> expect, string value, Issue<string>? issue = null) =>
      expect.That(t => t != null && t.EndsWith(value), issue.Operator(value));

    /// <summary>
    /// Expects the target ends with <paramref name="value"/> using <paramref name="comparison"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="comparison">The object that performs the comparison</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<string> EndsWith(this Expect<string> expect, string value, StringComparison comparison, Issue<string>? issue = null) =>
      expect.That(t => t != null && t.EndsWith(value, comparison), issue.Operator(value, comparison));

    /// <summary>
    /// Expects the target ends with <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="ignoreCase">Whether to perform a case-insensitive comparison</param>
    /// <param name="culture">Cultural information to use when comparing</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<string> EndsWith(this Expect<string> expect, string value, bool ignoreCase, CultureInfo culture, Issue<string>? issue = null) =>
      expect.That(t => t != null && t.EndsWith(value, ignoreCase, culture), issue.Operator(value, ignoreCase, culture));

    /// <summary>
    /// Expects the target contains <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<string> Contains(this Expect<string> expect, string value, Issue<string>? issue = null) =>
      expect.That(t => t != null && t.Contains(value), issue.Operator(value));

    /// <summary>
    /// Expects the target contains <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<string> Contains(this Expect<string> expect, char value, Issue<string>? issue = null) =>
      expect.That(t => t != null && t.Contains(value), issue.Operator(value));

    /// <summary>
    /// Expects the target contains <paramref name="value"/> using <paramref name="comparer"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<string> Contains(this Expect<string> expect, char value, IEqualityComparer<char> comparer, Issue<string>? issue = null) =>
      expect.That(t => t != null && t.Contains(value, comparer), issue.Operator(value, comparer));

    //
    // Content (not)
    //

    /// <summary>
    /// Expects the target does not start with <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<string> DoesNotStartWith(this Expect<string> expect, string value, Issue<string>? issue = null) =>
      expect.That(t => t == null || !t.StartsWith(value), issue.Operator(value));

    /// <summary>
    /// Expects the target does not start with <paramref name="value"/> using <paramref name="comparison"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="comparison">The object that performs the comparison</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<string> DoesNotStartWith(this Expect<string> expect, string value, StringComparison comparison, Issue<string>? issue = null) =>
      expect.That(t => t == null || !t.StartsWith(value, comparison), issue.Operator(value, comparison));

    /// <summary>
    /// Expects the target does not start with <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="ignoreCase">Whether to perform a case-insensitive comparison</param>
    /// <param name="culture">Cultural information to use when comparing</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<string> DoesNotStartWith(this Expect<string> expect, string value, bool ignoreCase, CultureInfo culture, Issue<string>? issue = null) =>
      expect.That(t => t == null || !t.StartsWith(value, ignoreCase, culture), issue.Operator(value, ignoreCase, culture));

    /// <summary>
    /// Expects the target does not end with <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<string> DoesNotEndWith(this Expect<string> expect, string value, Issue<string>? issue = null) =>
      expect.That(t => t == null || !t.EndsWith(value), issue.Operator(value));

    /// <summary>
    /// Expects the target does not end with <paramref name="value"/> using <paramref name="comparison"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="comparison">The object that performs the comparison</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<string> DoesNotEndWith(this Expect<string> expect, string value, StringComparison comparison, Issue<string>? issue = null) =>
      expect.That(t => t == null || !t.EndsWith(value, comparison), issue.Operator(value, comparison));

    /// <summary>
    /// Expects the target does not end with <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="ignoreCase">Whether to perform a case-insensitive comparison</param>
    /// <param name="culture">Cultural information to use when comparing</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<string> DoesNotEndWith(this Expect<string> expect, string value, bool ignoreCase, CultureInfo culture, Issue<string>? issue = null) =>
      expect.That(t => t == null || !t.EndsWith(value, ignoreCase, culture), issue.Operator(value, ignoreCase, culture));

    /// <summary>
    /// Expects the target does not contain <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<string> DoesNotContain(this Expect<string> expect, string value, Issue<string>? issue = null) =>
      expect.That(t => t == null || !t.Contains(value), issue.Operator(value));

    /// <summary>
    /// Expects the target does not contain <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<string> DoesNotContain(this Expect<string> expect, char value, Issue<string>? issue = null) =>
      expect.That(t => t == null || !t.Contains(value), issue.Operator(value));

    /// <summary>
    /// Expects the target does not contain <paramref name="value"/> using <paramref name="comparer"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="comparer">The object that performs the comparison</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<string> DoesNotContain(this Expect<string> expect, char value, IEqualityComparer<char> comparer, Issue<string>? issue = null) =>
      expect.That(t => t == null || !t.Contains(value, comparer), issue.Operator(value, comparer));

    //
    // Matches
    //

    /// <summary>
    /// Expects the target matches <paramref name="regex"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="regex">The regular expression to match</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<string> Matches(this Expect<string> expect, Regex regex, Issue<string>? issue = null) =>
      expect.That(t => t != null && regex != null && regex.IsMatch(t), issue.Operator(regex));

    /// <summary>
    /// Expects the target matches <paramref name="regex"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="regex">The regular expression to match</param>
    /// <param name="options">The options to use for the match</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<string> Matches(this Expect<string> expect, string regex, RegexOptions options, Issue<string>? issue = null) =>
      expect.That(t => t != null && regex != null && Regex.IsMatch(t, regex, options), issue.Operator(regex, options));

    /// <summary>
    /// Expects the target matches <paramref name="regex"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="regex">The regular expression to match</param>
    /// <param name="options">The options to use for the match</param>
    /// <param name="matchTimeout">The maximum time to wait before throwing <see cref="RegexMatchTimeoutException"/></param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    /// <exception cref="RegexMatchTimeoutException">Thrown if the match times out</exception>
    public static Expect<string> Matches(this Expect<string> expect, string regex, RegexOptions options, TimeSpan matchTimeout, Issue<string>? issue = null) =>
      expect.That(t => t != null && regex != null && Regex.IsMatch(t, regex, options, matchTimeout), issue.Operator(regex, options, matchTimeout));

    /// <summary>
    /// Expects the target matches <paramref name="regex"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="regex">The regular expression to match</param>
    /// <param name="ignoreCase">Whether to perform a case-insensitive match</param>
    /// <param name="singleline">Whether to use single-line mode, where the period (.) matches every character (instead of every character except \n)</param>
    /// <param name="multiline">Whether to use multi-line mode, where ^ and $ match the beginning and end of each line (instead of the beginning and end of the input string)</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<string> Matches(this Expect<string> expect, string regex, bool ignoreCase = false, bool singleline = false, bool multiline = false) =>
      expect.That(t => t != null && regex != null && Regex.IsMatch(t, regex, ToOptions(ignoreCase, singleline, multiline)), default(Issue<string>).Operator(regex, ignoreCase, singleline, multiline));

    /// <summary>
    /// Expects the target matches <paramref name="regex"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="regex">The regular expression to match</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="ignoreCase">Whether to perform a case-insensitive match</param>
    /// <param name="singleline">Whether to use single-line mode, where the period (.) matches every character (instead of every character except \n)</param>
    /// <param name="multiline">Whether to use multi-line mode, where ^ and $ match the beginning and end of each line (instead of the beginning and end of the input string)</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<string> Matches(this Expect<string> expect, string regex, Issue<string> issue, bool ignoreCase = false, bool singleline = false, bool multiline = false) =>
      expect.That(t => t != null && regex != null && Regex.IsMatch(t, regex, ToOptions(ignoreCase, singleline, multiline)), issue.Operator(regex, ignoreCase, singleline, multiline));

    /// <summary>
    /// Expects the target matches <paramref name="regex"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="regex">The regular expression to match</param>
    /// <param name="matchTimeout">The maximum time to wait before throwing <see cref="RegexMatchTimeoutException"/></param>
    /// <param name="ignoreCase">Whether to perform a case-insensitive match</param>
    /// <param name="singleline">Whether to use single-line mode, where the period (.) matches every character (instead of every character except \n)</param>
    /// <param name="multiline">Whether to use multi-line mode, where ^ and $ match the beginning and end of each line (instead of the beginning and end of the input string)</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    /// <exception cref="RegexMatchTimeoutException">Thrown if the match times out</exception>
    public static Expect<string> Matches(this Expect<string> expect, string regex, TimeSpan matchTimeout, bool ignoreCase = false, bool singleline = false, bool multiline = false) =>
      expect.That(t => t != null && regex != null && Regex.IsMatch(t, regex, ToOptions(ignoreCase, singleline, multiline), matchTimeout), default(Issue<string>).Operator(regex, ignoreCase, singleline, multiline));

    /// <summary>
    /// Expects the target matches <paramref name="regex"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="regex">The regular expression to match</param>
    /// <param name="matchTimeout">The maximum time to wait before throwing <see cref="RegexMatchTimeoutException"/></param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="ignoreCase">Whether to perform a case-insensitive match</param>
    /// <param name="singleline">Whether to use single-line mode, where the period (.) matches every character (instead of every character except \n)</param>
    /// <param name="multiline">Whether to use multi-line mode, where ^ and $ match the beginning and end of each line (instead of the beginning and end of the input string)</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    /// <exception cref="RegexMatchTimeoutException">Thrown if the match times out</exception>
    public static Expect<string> Matches(this Expect<string> expect, string regex, TimeSpan matchTimeout, Issue<string> issue, bool ignoreCase = false, bool singleline = false, bool multiline = false) =>
      expect.That(t => t != null && regex != null && Regex.IsMatch(t, regex, ToOptions(ignoreCase, singleline, multiline), matchTimeout), issue.Operator(regex, ignoreCase, singleline, multiline));

    /// <summary>
    /// Expects the target matches <paramref name="wildcardPattern"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="wildcardPattern">The pattern to match, where * matches zero or more times and ? matches zero or one time</param>
    /// <param name="ignoreCase">Whether to perform a case-insensitive match</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<string> MatchesWildcard(this Expect<string> expect, string wildcardPattern, bool ignoreCase = false) =>
      expect.That(t => t != null && wildcardPattern != null && Regex.IsMatch(t, ToRegex(wildcardPattern), ToOptions(ignoreCase, singleline: true, multiline: false)), default(Issue<string>).Operator(wildcardPattern, ignoreCase));

    /// <summary>
    /// Expects the target matches <paramref name="wildcardPattern"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="wildcardPattern">The pattern to match, where * matches zero or more times and ? matches zero or one time</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="ignoreCase">Whether to perform a case-insensitive match</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<string> MatchesWildcard(this Expect<string> expect, string wildcardPattern, Issue<string> issue, bool ignoreCase = false) =>
      expect.That(t => t != null && wildcardPattern != null && Regex.IsMatch(t, ToRegex(wildcardPattern), ToOptions(ignoreCase, singleline: true, multiline: false)), issue.Operator(wildcardPattern, ignoreCase));

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
    /// Expects the target does not match <paramref name="regex"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="regex">The regular expression to match</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<string> DoesNotMatch(this Expect<string> expect, Regex regex, Issue<string>? issue = null) =>
      expect.That(t => t == null || regex == null || !regex.IsMatch(t), issue.Operator(regex));

    /// <summary>
    /// Expects the target does not match <paramref name="regex"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="regex">The regular expression to match</param>
    /// <param name="options">The options to use for the match</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<string> DoesNotMatch(this Expect<string> expect, string regex, RegexOptions options, Issue<string>? issue = null) =>
      expect.That(t => t == null || regex == null || !Regex.IsMatch(t, regex, options), issue.Operator(regex, options));

    /// <summary>
    /// Expects the target does not match <paramref name="regex"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="regex">The regular expression to match</param>
    /// <param name="options">The options to use for the match</param>
    /// <param name="matchTimeout">The maximum time to wait before throwing <see cref="RegexMatchTimeoutException"/></param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    /// <exception cref="RegexMatchTimeoutException">Thrown if the match times out</exception>
    public static Expect<string> DoesNotMatch(this Expect<string> expect, string regex, RegexOptions options, TimeSpan matchTimeout, Issue<string>? issue = null) =>
      expect.That(t => t == null || regex == null || !Regex.IsMatch(t, regex, options, matchTimeout), issue.Operator(regex, options, matchTimeout));

    /// <summary>
    /// Expects the target does not match <paramref name="regex"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="regex">The regular expression to match</param>
    /// <param name="ignoreCase">Whether to perform a case-insensitive match</param>
    /// <param name="singleline">Whether to use single-line mode, where the period (.) matches every character (instead of every character except \n)</param>
    /// <param name="multiline">Whether to use multi-line mode, where ^ and $ match the beginning and end of each line (instead of the beginning and end of the input string)</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<string> DoesNotMatch(this Expect<string> expect, string regex, bool ignoreCase = false, bool singleline = false, bool multiline = false) =>
      expect.That(t => t == null || regex == null || !Regex.IsMatch(t, regex, ToOptions(ignoreCase, singleline, multiline)), default(Issue<string>).Operator(regex, ignoreCase, singleline, multiline));

    /// <summary>
    /// Expects the target does not match <paramref name="regex"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="regex">The regular expression to match</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="ignoreCase">Whether to perform a case-insensitive match</param>
    /// <param name="singleline">Whether to use single-line mode, where the period (.) matches every character (instead of every character except \n)</param>
    /// <param name="multiline">Whether to use multi-line mode, where ^ and $ match the beginning and end of each line (instead of the beginning and end of the input string)</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<string> DoesNotMatch(this Expect<string> expect, string regex, Issue<string> issue, bool ignoreCase = false, bool singleline = false, bool multiline = false) =>
      expect.That(t => t == null || regex == null || !Regex.IsMatch(t, regex, ToOptions(ignoreCase, singleline, multiline)), issue.Operator(regex, ignoreCase, singleline, multiline));

    /// <summary>
    /// Expects the target does not match <paramref name="regex"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="regex">The regular expression to match</param>
    /// <param name="matchTimeout">The maximum time to wait before throwing <see cref="RegexMatchTimeoutException"/></param>
    /// <param name="ignoreCase">Whether to perform a case-insensitive match</param>
    /// <param name="singleline">Whether to use single-line mode, where the period (.) matches every character (instead of every character except \n)</param>
    /// <param name="multiline">Whether to use multi-line mode, where ^ and $ match the beginning and end of each line (instead of the beginning and end of the input string)</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    /// <exception cref="RegexMatchTimeoutException">Thrown if the match times out</exception>
    public static Expect<string> DoesNotMatch(this Expect<string> expect, string regex, TimeSpan matchTimeout, bool ignoreCase = false, bool singleline = false, bool multiline = false) =>
      expect.That(t => t == null || regex == null || !Regex.IsMatch(t, regex, ToOptions(ignoreCase, singleline, multiline), matchTimeout), default(Issue<string>).Operator(regex, ignoreCase, singleline, multiline));

    /// <summary>
    /// Expects the target does not match <paramref name="regex"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="regex">The regular expression to match</param>
    /// <param name="matchTimeout">The maximum time to wait before throwing <see cref="RegexMatchTimeoutException"/></param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="ignoreCase">Whether to perform a case-insensitive match</param>
    /// <param name="singleline">Whether to use single-line mode, where the period (.) matches every character (instead of every character except \n)</param>
    /// <param name="multiline">Whether to use multi-line mode, where ^ and $ match the beginning and end of each line (instead of the beginning and end of the input string)</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    /// <exception cref="RegexMatchTimeoutException">Thrown if the match times out</exception>
    public static Expect<string> DoesNotMatch(this Expect<string> expect, string regex, TimeSpan matchTimeout, Issue<string> issue, bool ignoreCase = false, bool singleline = false, bool multiline = false) =>
      expect.That(t => t == null || regex == null || !Regex.IsMatch(t, regex, ToOptions(ignoreCase, singleline, multiline), matchTimeout), issue.Operator(regex, ignoreCase, singleline, multiline));

    /// <summary>
    /// Expects the target does not match <paramref name="wildcardPattern"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="wildcardPattern">The pattern to match, where * matches zero or more times and ? matches zero or one time</param>
    /// <param name="ignoreCase">Whether to perform a case-insensitive match</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<string> DoesNotMatchWildcard(this Expect<string> expect, string wildcardPattern, bool ignoreCase = false) =>
      expect.That(t => t == null || wildcardPattern == null || !Regex.IsMatch(t, ToRegex(wildcardPattern), ToOptions(ignoreCase, singleline: true, multiline: false)), default(Issue<string>).Operator(wildcardPattern, ignoreCase));

    /// <summary>
    /// Expects the target does not match <paramref name="wildcardPattern"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="wildcardPattern">The pattern to match, where * matches zero or more times and ? matches zero or one time</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <param name="ignoreCase">Whether to perform a case-insensitive match</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<string> DoesNotMatchWildcard(this Expect<string> expect, string wildcardPattern, Issue<string> issue, bool ignoreCase = false) =>
      expect.That(t => t == null || wildcardPattern == null || !Regex.IsMatch(t, ToRegex(wildcardPattern), ToOptions(ignoreCase, singleline: true, multiline: false)), issue.Operator(wildcardPattern, ignoreCase));

    //
    // Char
    //

    /// <summary>
    /// Expects the target is categorized as a Unicode control character
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<char> IsControl(this Expect<char> expect, Issue<char>? issue = null) =>
      expect.That(char.IsControl, issue.Operator());

    /// <summary>
    /// Expects the target is categorized as a digit
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<char> IsDigit(this Expect<char> expect, Issue<char>? issue = null) =>
      expect.That(char.IsDigit, issue.Operator());

    /// <summary>
    /// Expects the target is categorized as a Unicode high surrogate
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<char> IsHighSurrogate(this Expect<char> expect, Issue<char>? issue = null) =>
      expect.That(char.IsHighSurrogate, issue.Operator());

    /// <summary>
    /// Expects the target is categorized as a Unicode high surrogate pair with <paramref name="lowSurrogate"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="lowSurrogate">The character to pair with the target</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<char> IsHighSurrogatePair(this Expect<char> expect, char lowSurrogate, Issue<char>? issue = null) =>
      expect.That(t => char.IsSurrogatePair(t, lowSurrogate), issue.Operator(lowSurrogate));

    /// <summary>
    /// Expects the target is categorized as a letter
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<char> IsLetter(this Expect<char> expect, Issue<char>? issue = null) =>
      expect.That(char.IsLetter, issue.Operator());

    /// <summary>
    /// Expects the target is categorized as a letter or digit
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<char> IsLetterOrDigit(this Expect<char> expect, Issue<char>? issue = null) =>
      expect.That(char.IsLetterOrDigit, issue.Operator());

    /// <summary>
    /// Expects the target is categorized as lowercase
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<char> IsLower(this Expect<char> expect, Issue<char>? issue = null) =>
      expect.That(char.IsLower, issue.Operator());

    /// <summary>
    /// Expects the target is categorized as a Unicode low surrogate
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<char> IsLowSurrogate(this Expect<char> expect, Issue<char>? issue = null) =>
      expect.That(char.IsLowSurrogate, issue.Operator());

    /// <summary>
    /// Expects the target is categorized as a low high surrogate pair with <paramref name="highSurrogate"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="highSurrogate">The character to pair with the target</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<char> IsLowSurrogatePair(this Expect<char> expect, char highSurrogate, Issue<char>? issue = null) =>
      expect.That(t => char.IsSurrogatePair(highSurrogate, t), issue.Operator(highSurrogate));

    /// <summary>
    /// Expects the target is categorized as a number
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<char> IsNumber(this Expect<char> expect, Issue<char>? issue = null) =>
      expect.That(char.IsNumber, issue.Operator());

    /// <summary>
    /// Expects the target is categorized as punctuation
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<char> IsPunctuation(this Expect<char> expect, Issue<char>? issue = null) =>
      expect.That(char.IsPunctuation, issue.Operator());

    /// <summary>
    /// Expects the target is categorized as a separator
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<char> IsSeparator(this Expect<char> expect, Issue<char>? issue = null) =>
      expect.That(char.IsSeparator, issue.Operator());

    /// <summary>
    /// Expects the target has a surrogate code unit
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<char> IsSurrogate(this Expect<char> expect, Issue<char>? issue = null) =>
      expect.That(char.IsSurrogate, issue.Operator());

    /// <summary>
    /// Expects the target is categorized as a symbol
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<char> IsSymbol(this Expect<char> expect, Issue<char>? issue = null) =>
      expect.That(char.IsSymbol, issue.Operator());

    /// <summary>
    /// Expects the target is categorized as uppercase
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<char> IsUpper(this Expect<char> expect, Issue<char>? issue = null) =>
      expect.That(char.IsUpper, issue.Operator());

    /// <summary>
    /// Expects the target is categorized as white space
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<char> IsWhiteSpace(this Expect<char> expect, Issue<char>? issue = null) =>
      expect.That(char.IsWhiteSpace, issue.Operator());

    //
    // Char (not)
    //

    /// <summary>
    /// Expects the target is not categorized as a Unicode control character
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<char> IsNotControl(this Expect<char> expect, Issue<char>? issue = null) =>
      expect.That(t => !char.IsControl(t), issue.Operator());

    /// <summary>
    /// Expects the target is not categorized as a digit
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<char> IsNotDigit(this Expect<char> expect, Issue<char>? issue = null) =>
      expect.That(t => !char.IsDigit(t), issue.Operator());

    /// <summary>
    /// Expects the target is not categorized as a Unicode high surrogate
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<char> IsNotHighSurrogate(this Expect<char> expect, Issue<char>? issue = null) =>
      expect.That(t => !char.IsHighSurrogate(t), issue.Operator());

    /// <summary>
    /// Expects the target is not categorized as a Unicode high surrogate pair with <paramref name="lowSurrogate"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="lowSurrogate">The character to pair with the target</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<char> IsNotHighSurrogatePair(this Expect<char> expect, char lowSurrogate, Issue<char>? issue = null) =>
      expect.That(t => !char.IsSurrogatePair(t, lowSurrogate), issue.Operator(lowSurrogate));

    /// <summary>
    /// Expects the target is not categorized as a letter
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<char> IsNotLetter(this Expect<char> expect, Issue<char>? issue = null) =>
      expect.That(t => !char.IsLetter(t), issue.Operator());

    /// <summary>
    /// Expects the target is not categorized as a letter or digit
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<char> IsNotLetterOrDigit(this Expect<char> expect, Issue<char>? issue = null) =>
      expect.That(t => !char.IsLetterOrDigit(t), issue.Operator());

    /// <summary>
    /// Expects the target is not categorized as lowercase
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<char> IsNotLower(this Expect<char> expect, Issue<char>? issue = null) =>
      expect.That(t => !char.IsLower(t), issue.Operator());

    /// <summary>
    /// Expects the target is not categorized as a Unicode low surrogate
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<char> IsNotLowSurrogate(this Expect<char> expect, Issue<char>? issue = null) =>
      expect.That(t => !char.IsLowSurrogate(t), issue.Operator());

    /// <summary>
    /// Expects the target is not categorized as a low high surrogate pair with <paramref name="highSurrogate"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="highSurrogate">The character to pair with the target</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<char> IsNotLowSurrogatePair(this Expect<char> expect, char highSurrogate, Issue<char>? issue = null) =>
      expect.That(t => !char.IsSurrogatePair(highSurrogate, t), issue.Operator(highSurrogate));

    /// <summary>
    /// Expects the target is not categorized as a number
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<char> IsNotNumber(this Expect<char> expect, Issue<char>? issue = null) =>
      expect.That(t => !char.IsNumber(t), issue.Operator());

    /// <summary>
    /// Expects the target is not categorized as punctuation
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<char> IsNotPunctuation(this Expect<char> expect, Issue<char>? issue = null) =>
      expect.That(t => !char.IsPunctuation(t), issue.Operator());

    /// <summary>
    /// Expects the target is not categorized as a separator
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<char> IsNotSeparator(this Expect<char> expect, Issue<char>? issue = null) =>
      expect.That(t => !char.IsSeparator(t), issue.Operator());

    /// <summary>
    /// Expects the target does not have surrogate code unit
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<char> IsNotSurrogate(this Expect<char> expect, Issue<char>? issue = null) =>
      expect.That(t => !char.IsSurrogate(t), issue.Operator());

    /// <summary>
    /// Expects the target is not categorized as a symbol
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<char> IsNotSymbol(this Expect<char> expect, Issue<char>? issue = null) =>
      expect.That(t => !char.IsSymbol(t), issue.Operator());

    /// <summary>
    /// Expects the target is not categorized as uppercase
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<char> IsNotUpper(this Expect<char> expect, Issue<char>? issue = null) =>
      expect.That(t => !char.IsUpper(t), issue.Operator());

    /// <summary>
    /// Expects the target is not categorized as white space
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<char> IsNotWhiteSpace(this Expect<char> expect, Issue<char>? issue = null) =>
      expect.That(t => !char.IsWhiteSpace(t), issue.Operator());

    //
    // Uri
    //

    /// <summary>
    /// Expects the target's <see cref="Uri.AbsolutePath"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<Uri> HasAbsolutePath(this Expect<Uri> expect, string value, Issue<Uri>? issue = null) =>
      expect.That(t => t?.AbsolutePath == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="Uri.AbsoluteUri"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<Uri> HasAbsoluteUri(this Expect<Uri> expect, string value, Issue<Uri>? issue = null) =>
      expect.That(t => t?.AbsoluteUri == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="Uri.Authority"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<Uri> HasAuthority(this Expect<Uri> expect, string value, Issue<Uri>? issue = null) =>
      expect.That(t => t?.Authority == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="Uri.AbsolutePath"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<Uri> HasDnsSafeHost(this Expect<Uri> expect, string value, Issue<Uri>? issue = null) =>
      expect.That(t => t?.DnsSafeHost == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="Uri.Fragment"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<Uri> HasFragment(this Expect<Uri> expect, string value, Issue<Uri>? issue = null) =>
      expect.That(t => t?.Fragment == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="Uri.Host"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<Uri> HasHost(this Expect<Uri> expect, string value, Issue<Uri>? issue = null) =>
      expect.That(t => t?.Host == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="Uri.HostNameType"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<Uri> HasHostNameType(this Expect<Uri> expect, UriHostNameType value, Issue<Uri>? issue = null) =>
      expect.That(t => t?.HostNameType == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="Uri.IdnHost"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<Uri> HasIdnHost(this Expect<Uri> expect, string value, Issue<Uri>? issue = null) =>
      expect.That(t => t?.IdnHost == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="Uri.LocalPath"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<Uri> HasLocalPath(this Expect<Uri> expect, string value, Issue<Uri>? issue = null) =>
      expect.That(t => t?.LocalPath == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="Uri.OriginalString"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<Uri> HasOriginalString(this Expect<Uri> expect, string value, Issue<Uri>? issue = null) =>
      expect.That(t => t?.OriginalString == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="Uri.PathAndQuery"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<Uri> HasPathAndQuery(this Expect<Uri> expect, string value, Issue<Uri>? issue = null) =>
      expect.That(t => t?.PathAndQuery == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="Uri.Port"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<Uri> HasPort(this Expect<Uri> expect, int value, Issue<Uri>? issue = null) =>
      expect.That(t => t?.Port == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="Uri.Query"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<Uri> HasQuery(this Expect<Uri> expect, string value, Issue<Uri>? issue = null) =>
      expect.That(t => t?.Query == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="Uri.Scheme"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<Uri> HasScheme(this Expect<Uri> expect, string value, Issue<Uri>? issue = null) =>
      expect.That(t => t?.Scheme == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="Uri.Segments"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<Uri> HasSegments(this Expect<Uri> expect, IEnumerable<string> value, Issue<Uri>? issue = null) =>
      expect.That(t => ExpectMany.That(t.Segments).HasSameInOrder(value), issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="Uri.UserInfo"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<Uri> HasUserInfo(this Expect<Uri> expect, string value, Issue<Uri>? issue = null) =>
      expect.That(t => t?.UserInfo == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="Uri.IsAbsoluteUri"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<Uri> IsAbsoluteUri(this Expect<Uri> expect, bool value, Issue<Uri>? issue = null) =>
      expect.That(t => t?.IsAbsoluteUri == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="Uri.IsFile"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<Uri> IsFile(this Expect<Uri> expect, bool value, Issue<Uri>? issue = null) =>
      expect.That(t => t?.IsFile == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="Uri.IsUnc"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<Uri> IsUnc(this Expect<Uri> expect, bool value, Issue<Uri>? issue = null) =>
      expect.That(t => t?.IsUnc == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="Uri.IsLoopback"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<Uri> IsLoopback(this Expect<Uri> expect, bool value, Issue<Uri>? issue = null) =>
      expect.That(t => t?.IsLoopback == value, issue.Operator(value));

    /// <summary>
    /// Expects the target's <see cref="Uri.UserEscaped"/> property equals <paramref name="value"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="value">The value to compare</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<Uri> IsUserEscaped(this Expect<Uri> expect, bool value, Issue<Uri>? issue = null) =>
      expect.That(t => t?.UserEscaped == value, issue.Operator(value));

    //
    // Uri (values)
    //

    /// <summary>
    /// Expects the target's <see cref="Uri.AbsolutePath"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<Uri> HasAbsolutePath(this Expect<Uri> expect, Action<Expect<string>> expectValue, Issue<Uri>? issue = null) =>
      expect.That(t => t != null && expectValue.Invoke(t.AbsolutePath), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="Uri.AbsoluteUri"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<Uri> HasAbsoluteUri(this Expect<Uri> expect, Action<Expect<string>> expectValue, Issue<Uri>? issue = null) =>
      expect.That(t => t != null && expectValue.Invoke(t.AbsoluteUri), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="Uri.Authority"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<Uri> HasAuthority(this Expect<Uri> expect, Action<Expect<string>> expectValue, Issue<Uri>? issue = null) =>
      expect.That(t => t != null && expectValue.Invoke(t.Authority), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="Uri.DnsSafeHost"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<Uri> HasDnsSafeHost(this Expect<Uri> expect, Action<Expect<string>> expectValue, Issue<Uri>? issue = null) =>
      expect.That(t => t != null && expectValue.Invoke(t.DnsSafeHost), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="Uri.Fragment"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<Uri> HasFragment(this Expect<Uri> expect, Action<Expect<string>> expectValue, Issue<Uri>? issue = null) =>
      expect.That(t => t != null && expectValue.Invoke(t.Fragment), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="Uri.Host"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<Uri> HasHost(this Expect<Uri> expect, Action<Expect<string>> expectValue, Issue<Uri>? issue = null) =>
      expect.That(t => t != null && expectValue.Invoke(t.Host), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="Uri.HostNameType"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<Uri> HasHostNameType(this Expect<Uri> expect, Action<Expect<UriHostNameType>> expectValue, Issue<Uri>? issue = null) =>
      expect.That(t => t != null && expectValue.Invoke(t.HostNameType), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="Uri.IdnHost"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<Uri> HasIdnHost(this Expect<Uri> expect, Action<Expect<string>> expectValue, Issue<Uri>? issue = null) =>
      expect.That(t => t != null && expectValue.Invoke(t.IdnHost), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="Uri.LocalPath"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<Uri> HasLocalPath(this Expect<Uri> expect, Action<Expect<string>> expectValue, Issue<Uri>? issue = null) =>
      expect.That(t => t != null && expectValue.Invoke(t.LocalPath), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="Uri.OriginalString"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<Uri> HasOriginalString(this Expect<Uri> expect, Action<Expect<string>> expectValue, Issue<Uri>? issue = null) =>
      expect.That(t => t != null && expectValue.Invoke(t.OriginalString), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="Uri.PathAndQuery"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<Uri> HasPathAndQuery(this Expect<Uri> expect, Action<Expect<string>> expectValue, Issue<Uri>? issue = null) =>
      expect.That(t => t != null && expectValue.Invoke(t.PathAndQuery), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="Uri.Port"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<Uri> HasPort(this Expect<Uri> expect, Action<Expect<int>> expectValue, Issue<Uri>? issue = null) =>
      expect.That(t => t != null && expectValue.Invoke(t.Port), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="Uri.Query"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<Uri> HasQuery(this Expect<Uri> expect, Action<Expect<string>> expectValue, Issue<Uri>? issue = null) =>
      expect.That(t => t != null && expectValue.Invoke(t.Query), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="Uri.Scheme"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<Uri> HasScheme(this Expect<Uri> expect, Action<Expect<string>> expectValue, Issue<Uri>? issue = null) =>
      expect.That(t => t != null && expectValue.Invoke(t.Scheme), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="Uri.Segments"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<Uri> HasSegments(this Expect<Uri> expect, Action<ExpectMany<string>> expectValue, Issue<Uri>? issue = null) =>
      expect.That(t => t != null && expectValue.Invoke(t.Segments), issue.Operator(expectValue));

    /// <summary>
    /// Expects the target's <see cref="Uri.UserInfo"/> property to meet <paramref name="expectValue"/>
    /// </summary>
    /// <param name="expect">The query that throws <see cref="ExpectException"/> if not met</param>
    /// <param name="expectValue">The function to invoke with an expected argument</param>
    /// <param name="issue">The function that provides a message if the expectation is not met, else <see langword="null"/> for the default format</param>
    /// <returns><see langword="this"/> to enable further expectations</returns>
    /// <exception cref="ExpectException">Thrown if the expectation is not met</exception>
    public static Expect<Uri> HasUserInfo(this Expect<Uri> expect, Action<Expect<string>> expectValue, Issue<Uri>? issue = null) =>
      expect.That(t => t != null && expectValue.Invoke(t.UserInfo), issue.Operator(expectValue));
  }
}