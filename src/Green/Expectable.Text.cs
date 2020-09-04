using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Green.Messages;
using static Green.Messages.Local;

namespace Green
{
  public static partial class Expectable
  {
    public static Expect<string> Is(this Expect<string> expect, string value, Issue<string> issue = null) =>
      expect.That(t => string.Equals(t, value), issue.ElseExpected(Text(value)));

    public static Expect<string> Is(this Expect<string> expect, string value, StringComparison comparison, Issue<string> issue = null) =>
      expect.That(t => string.Equals(t, value, comparison), issue.ElseExpected($"{Text(value)} (comparison = {comparison})"));

    public static Expect<string> IsEmpty(this Expect<string> expect, Issue<string> issue = null) =>
      expect.That(t => t == "", issue.ElseExpected(Text("")));

    public static Expect<string> IsWhiteSpace(this Expect<string> expect, Issue<string> issue = null) =>
      expect.That(t => t != null && string.IsNullOrWhiteSpace(t), issue.ElseExpected("whitespace"));

    public static Expect<string> IsNullOrEmpty(this Expect<string> expect, Issue<string> issue = null) =>
      expect.That(string.IsNullOrEmpty, issue.ElseExpected($"{NullText} or {EmptyText}"));

    public static Expect<string> IsNullOrWhiteSpace(this Expect<string> expect, Issue<string> issue = null) =>
      expect.That(string.IsNullOrWhiteSpace, issue.ElseExpected($"{NullText} or whitespace"));

    public static Expect<string> IsNot(this Expect<string> expect, string value, Issue<string> issue = null) =>
      expect.Not(t => string.Equals(t, value), issue.ElseExpected($"not {Text(value)}"));

    public static Expect<string> IsNot(this Expect<string> expect, string value, StringComparison comparison, Issue<string> issue = null) =>
      expect.Not(t => string.Equals(t, value, comparison), issue.ElseExpected($"not {Text(value)} (comparison = {comparison})"));

    public static Expect<string> IsNotEmpty(this Expect<string> expect, Issue<string> issue = null) =>
      expect.That(t => t != "", issue.ElseExpected($"not {EmptyText}"));

    public static Expect<string> IsNotWhiteSpace(this Expect<string> expect, Issue<string> issue = null) =>
      expect.Not(string.IsNullOrWhiteSpace, issue.ElseExpected("not whitespace"));

    public static Expect<string> IsNotNullOrEmpty(this Expect<string> expect, Issue<string> issue = null) =>
      expect.Not(string.IsNullOrEmpty, issue.ElseExpected($"not {NullText} or {EmptyText}"));

    public static Expect<string> IsNotNullOrWhiteSpace(this Expect<string> expect, Issue<string> issue = null) =>
      expect.Not(string.IsNullOrWhiteSpace, issue.ElseExpected($"not {NullText} or whitespace"));

    //
    // Has
    //

    public static Expect<string> HasLength(this Expect<string> expect, int value, Issue<string> issue = null) =>
      expect.That(t => t?.Length == value, issue.ElseExpectedHas(nameof(string.Length), value, t => t.Length));

    public static Expect<string> HasLength(this Expect<string> expect, Action<Expect<int>> expectLength) =>
      expect.That(t => t != null && expectLength.Invoke(t.Length));

    public static Expect<string> HasChar(this Expect<string> expect, int index, char value, Issue<string> issue = null) =>
      expect.That(t => t != null && index < t.Length && t[index] == value, issue.ElseExpectedHas($"[{index}]", value, t => t[index]));

    public static Expect<string> HasChar(this Expect<string> expect, int index, Action<Expect<char>> expectValue) =>
      expect.That(t => t != null && index < t.Length && expectValue.Invoke(t[index]));

    //
    // Content
    //

    public static Expect<string> StartsWith(this Expect<string> expect, string value, Issue<string> issue = null) =>
      expect.That(t => t != null && t.StartsWith(value), issue.ElseExpected($"starts with {Text(value)}"));

    public static Expect<string> StartsWith(this Expect<string> expect, string value, StringComparison comparison, Issue<string> issue = null) =>
      expect.That(t => t != null && t.StartsWith(value, comparison), issue.ElseExpected($"starts with {Text(value)} (comparison = {comparison})"));

    public static Expect<string> StartsWith(this Expect<string> expect, string value, bool ignoreCase, CultureInfo culture, Issue<string> issue = null) =>
      expect.That(t => t != null && t.StartsWith(value, ignoreCase, culture), issue.ElseExpected($"starts with {Text(value)} (ignore case = {ignoreCase}, culture = {culture})"));

    public static Expect<string> EndsWith(this Expect<string> expect, string value, Issue<string> issue = null) =>
      expect.That(t => t != null && t.EndsWith(value), issue.ElseExpected($"ends with {Text(value)}"));

    public static Expect<string> EndsWith(this Expect<string> expect, string value, StringComparison comparison, Issue<string> issue = null) =>
      expect.That(t => t != null && t.EndsWith(value, comparison), issue.ElseExpected($"ends with {Text(value)} (comparison = {comparison})"));

    public static Expect<string> EndsWith(this Expect<string> expect, string value, bool ignoreCase, CultureInfo culture, Issue<string> issue = null) =>
      expect.That(t => t != null && t.EndsWith(value, ignoreCase, culture), issue.ElseExpected($"ends with {Text(value)} (ignore case = {ignoreCase}, culture = {culture})"));

    public static Expect<string> Contains(this Expect<string> expect, string value, Issue<string> issue = null) =>
      expect.That(t => t != null && t.Contains(value), issue.ElseExpected($"contains {Text(value)}"));

    public static Expect<string> Contains(this Expect<string> expect, char value, Issue<string> issue = null) =>
      expect.That(t => t != null && t.Contains(value), issue.ElseExpected($"contains {Text(value)}"));

    public static Expect<string> Contains(this Expect<string> expect, char value, IEqualityComparer<char> comparer, Issue<string> issue = null) =>
      expect.That(t => t != null && t.Contains(value, comparer), issue.ElseExpected($"contains {Text(value)} (comparer = {comparer})"));

    //
    // Content (not)
    //

    public static Expect<string> DoesNotStartWith(this Expect<string> expect, string value, Issue<string> issue = null) =>
      expect.Not(t => t != null && t.StartsWith(value), issue.ElseExpected($"does not start with {Text(value)}"));

    public static Expect<string> DoesNotStartWith(this Expect<string> expect, string value, StringComparison comparison, Issue<string> issue = null) =>
      expect.Not(t => t != null && t.StartsWith(value, comparison), issue.ElseExpected($"does not start with {Text(value)} (comparison = {comparison})"));

    public static Expect<string> DoesNotStartWith(this Expect<string> expect, string value, bool ignoreCase, CultureInfo culture, Issue<string> issue = null) =>
      expect.Not(t => t != null && t.StartsWith(value, ignoreCase, culture), issue.ElseExpected($"does not start with {Text(value)} (ignore case = {ignoreCase}, culture = {culture})"));

    public static Expect<string> DoesNotEndWith(this Expect<string> expect, string value, Issue<string> issue = null) =>
      expect.Not(t => t != null && t.EndsWith(value), issue.ElseExpected($"does not end with {Text(value)}"));

    public static Expect<string> DoesNotEndWith(this Expect<string> expect, string value, StringComparison comparison, Issue<string> issue = null) =>
      expect.Not(t => t != null && t.EndsWith(value, comparison), issue.ElseExpected($"does not end with {Text(value)} (comparison = {comparison})"));

    public static Expect<string> DoesNotEndWith(this Expect<string> expect, string value, bool ignoreCase, CultureInfo culture, Issue<string> issue = null) =>
      expect.Not(t => t != null && t.EndsWith(value, ignoreCase, culture), issue.ElseExpected($"does not end with {Text(value)} (ignore case = {ignoreCase}, culture = {culture})"));

    public static Expect<string> DoesNotContain(this Expect<string> expect, string value, Issue<string> issue = null) =>
      expect.Not(t => t != null && t.Contains(value), issue.ElseExpected($"does not contain {Text(value)}"));

    public static Expect<string> DoesNotContain(this Expect<string> expect, char value, Issue<string> issue = null) =>
      expect.Not(t => t != null && t.Contains(value), issue.ElseExpected($"does not contain {Text(value)}"));

    public static Expect<string> DoesNotContain(this Expect<string> expect, char value, IEqualityComparer<char> comparer, Issue<string> issue = null) =>
      expect.Not(t => t != null && t.Contains(value, comparer), issue.ElseExpected($"does not contain {Text(value)}{comparer.ToSuffix()}"));

    //
    // Matches
    //

    public static Expect<string> Matches(this Expect<string> expect, Regex regex, Issue<string> issue = null) =>
      expect.That(t => t != null && regex != null && regex.IsMatch(t), issue.ElseExpected($"matches {regex} (options = {regex.Options})"));

    public static Expect<string> Matches(this Expect<string> expect, string regex, RegexOptions options, Issue<string> issue = null) =>
      expect.That(t => t != null && regex != null && Regex.IsMatch(t, regex, options), issue.ElseExpected($"matches {regex} (options = {options})"));

    public static Expect<string> Matches(this Expect<string> expect, string regex, RegexOptions options, TimeSpan matchTimeout, Issue<string> issue = null) =>
      expect.That(t => t != null && regex != null && Regex.IsMatch(t, regex, options, matchTimeout), issue.ElseExpected($"matches {regex} (options = {options}, match timeout = {matchTimeout})"));

    public static Expect<string> Matches(this Expect<string> expect, string regex, bool ignoreCase = false, bool singleline = false, bool multiline = false) =>
      expect.Matches(regex, ToOptions(ignoreCase, singleline, multiline));

    public static Expect<string> Matches(this Expect<string> expect, string regex, Issue<string> issue, bool ignoreCase = false, bool singleline = false, bool multiline = false) =>
      expect.Matches(regex, ToOptions(ignoreCase, singleline, multiline), issue);

    public static Expect<string> Matches(this Expect<string> expect, string regex, TimeSpan matchTimeout, bool ignoreCase = false, bool singleline = false, bool multiline = false) =>
      expect.Matches(regex, ToOptions(ignoreCase, singleline, multiline), matchTimeout);

    public static Expect<string> Matches(this Expect<string> expect, string regex, TimeSpan matchTimeout, Issue<string> issue, bool ignoreCase = false, bool singleline = false, bool multiline = false) =>
      expect.Matches(regex, ToOptions(ignoreCase, singleline, multiline), matchTimeout, issue);

    public static Expect<string> MatchesWildcard(this Expect<string> expect, string wildcardPattern, bool ignoreCase = false) =>
      expect.Matches(ToRegex(wildcardPattern), ToOptions(ignoreCase, singleline: true, multiline: false), t => $"matches wildcard {wildcardPattern}");

    public static Expect<string> MatchesWildcard(this Expect<string> expect, string wildcardPattern, Issue<string> issue, bool ignoreCase = false) =>
      expect.Matches(ToRegex(wildcardPattern), ToOptions(ignoreCase, singleline: true, multiline: false), issue.ElseExpected($"matches wildcard {wildcardPattern}"));

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

    public static Expect<string> DoesNotMatch(this Expect<string> expect, Regex regex, Issue<string> issue = null) =>
      expect.Not(t => t != null && regex != null && regex.IsMatch(t), issue.ElseExpected($"does not match {regex} (options = {regex.Options})"));

    public static Expect<string> DoesNotMatch(this Expect<string> expect, string regex, RegexOptions options, Issue<string> issue = null) =>
      expect.Not(t => t != null && regex != null && Regex.IsMatch(t, regex, options), issue.ElseExpected($"does not match {regex} (options = {options})"));

    public static Expect<string> DoesNotMatch(this Expect<string> expect, string regex, RegexOptions options, TimeSpan matchTimeout, Issue<string> issue = null) =>
      expect.Not(t => t != null && regex != null && Regex.IsMatch(t, regex, options, matchTimeout), issue.ElseExpected($"does not match {regex} (options = {options}, match timeout = {matchTimeout})"));

    public static Expect<string> DoesNotMatch(this Expect<string> expect, string regex, bool ignoreCase = false, bool singleline = false, bool multiline = false) =>
      expect.DoesNotMatch(regex, ToOptions(ignoreCase, singleline, multiline));

    public static Expect<string> DoesNotMatch(this Expect<string> expect, string regex, Issue<string> issue, bool ignoreCase = false, bool singleline = false, bool multiline = false) =>
      expect.DoesNotMatch(regex, ToOptions(ignoreCase, singleline, multiline), issue);

    public static Expect<string> DoesNotMatch(this Expect<string> expect, string regex, TimeSpan matchTimeout, bool ignoreCase = false, bool singleline = false, bool multiline = false) =>
      expect.DoesNotMatch(regex, ToOptions(ignoreCase, singleline, multiline), matchTimeout);

    public static Expect<string> DoesNotMatch(this Expect<string> expect, string regex, TimeSpan matchTimeout, Issue<string> issue, bool ignoreCase = false, bool singleline = false, bool multiline = false) =>
      expect.DoesNotMatch(regex, ToOptions(ignoreCase, singleline, multiline), matchTimeout, issue);

    public static Expect<string> DoesNotMatchWildcard(this Expect<string> expect, string wildcardPattern, bool ignoreCase = false) =>
      expect.DoesNotMatch(ToRegex(wildcardPattern), ToOptions(ignoreCase, singleline: true, multiline: false), t => $"does not match wildcard {wildcardPattern}");

    public static Expect<string> DoesNotMatchWildcard(this Expect<string> expect, string wildcardPattern, Issue<string> issue, bool ignoreCase = false) =>
      expect.DoesNotMatch(ToRegex(wildcardPattern), ToOptions(ignoreCase, singleline: true, multiline: false), issue.ElseExpected($"does not match wildcard {wildcardPattern}"));

    //
    // Char
    //

    public static Expect<char> IsControl(this Expect<char> expect, Issue<char> issue = null) =>
      expect.That(char.IsControl, issue.ElseExpected("control character"));

    public static Expect<char> IsDigit(this Expect<char> expect, Issue<char> issue = null) =>
      expect.That(char.IsDigit, issue.ElseExpected("digit"));

    public static Expect<char> IsHighSurrogate(this Expect<char> expect, Issue<char> issue = null) =>
      expect.That(char.IsHighSurrogate, issue.ElseExpected("high surrogate"));

    public static Expect<char> IsHighSurrogatePair(this Expect<char> expect, char lowSurrogate, Issue<char> issue = null) =>
      expect.That(t => char.IsSurrogatePair(t, lowSurrogate), issue.ElseExpected($"high surrogate pair with {Text(lowSurrogate)}"));

    public static Expect<char> IsLetter(this Expect<char> expect, Issue<char> issue = null) =>
      expect.That(char.IsLetter, issue.ElseExpected("letter"));

    public static Expect<char> IsLetterOrDigit(this Expect<char> expect, Issue<char> issue = null) =>
      expect.That(char.IsLetterOrDigit, issue.ElseExpected("letter or digit"));

    public static Expect<char> IsLower(this Expect<char> expect, Issue<char> issue = null) =>
      expect.That(char.IsLower, issue.ElseExpected("lowercase"));

    public static Expect<char> IsLowSurrogate(this Expect<char> expect, Issue<char> issue = null) =>
      expect.That(char.IsLowSurrogate, issue.ElseExpected("low surrogate"));

    public static Expect<char> IsNumber(this Expect<char> expect, Issue<char> issue = null) =>
      expect.That(char.IsNumber, issue.ElseExpected("number"));

    public static Expect<char> IsPunctuation(this Expect<char> expect, Issue<char> issue = null) =>
      expect.That(char.IsPunctuation, issue.ElseExpected("punctuation"));

    public static Expect<char> IsSeparator(this Expect<char> expect, Issue<char> issue = null) =>
      expect.That(char.IsSeparator, issue.ElseExpected("separator"));

    public static Expect<char> IsSurrogate(this Expect<char> expect, Issue<char> issue = null) =>
      expect.That(char.IsSurrogate, issue.ElseExpected("surrogate"));

    public static Expect<char> IsLowSurrogatePair(this Expect<char> expect, char highSurrogate, Issue<char> issue = null) =>
      expect.That(t => char.IsSurrogatePair(highSurrogate, t), issue.ElseExpected($"low surrogate pair with {Text(highSurrogate)}"));

    public static Expect<char> IsSymbol(this Expect<char> expect, Issue<char> issue = null) =>
      expect.That(char.IsSymbol, issue.ElseExpected("symbol"));

    public static Expect<char> IsUpper(this Expect<char> expect, Issue<char> issue = null) =>
      expect.That(char.IsUpper, issue.ElseExpected("uppercase"));

    public static Expect<char> IsWhiteSpace(this Expect<char> expect, Issue<char> issue = null) =>
      expect.That(char.IsWhiteSpace, issue.ElseExpected("whitespace"));

    //
    // Char (not)
    //

    public static Expect<char> IsNotControl(this Expect<char> expect, Issue<char> issue = null) =>
      expect.Not(char.IsControl, issue.ElseExpected("not control character"));

    public static Expect<char> IsNotDigit(this Expect<char> expect, Issue<char> issue = null) =>
      expect.Not(char.IsDigit, issue.ElseExpected("not digit"));

    public static Expect<char> IsNotHighSurrogate(this Expect<char> expect, Issue<char> issue = null) =>
      expect.Not(char.IsHighSurrogate, issue.ElseExpected("not high surrogate"));

    public static Expect<char> IsNotHighSurrogatePair(this Expect<char> expect, char lowSurrogate, Issue<char> issue = null) =>
      expect.Not(t => char.IsSurrogatePair(t, lowSurrogate), issue.ElseExpected($"not high surrogate pair with {Text(lowSurrogate)}"));

    public static Expect<char> IsNotLetter(this Expect<char> expect, Issue<char> issue = null) =>
      expect.Not(char.IsLetter, issue.ElseExpected("not letter"));

    public static Expect<char> IsNotLetterOrDigit(this Expect<char> expect, Issue<char> issue = null) =>
      expect.Not(char.IsLetterOrDigit, issue.ElseExpected("not letter or digit"));

    public static Expect<char> IsNotLower(this Expect<char> expect, Issue<char> issue = null) =>
      expect.Not(char.IsLower, issue.ElseExpected("not lowercase"));

    public static Expect<char> IsNotLowSurrogate(this Expect<char> expect, Issue<char> issue = null) =>
      expect.Not(char.IsLowSurrogate, issue.ElseExpected("not low surrogate"));

    public static Expect<char> IsNotNumber(this Expect<char> expect, Issue<char> issue = null) =>
      expect.Not(char.IsNumber, issue.ElseExpected("not number"));

    public static Expect<char> IsNotPunctuation(this Expect<char> expect, Issue<char> issue = null) =>
      expect.Not(char.IsPunctuation, issue.ElseExpected("not punctuation"));

    public static Expect<char> IsNotSeparator(this Expect<char> expect, Issue<char> issue = null) =>
      expect.Not(char.IsSeparator, issue.ElseExpected("not separator"));

    public static Expect<char> IsNotSurrogate(this Expect<char> expect, Issue<char> issue = null) =>
      expect.Not(char.IsSurrogate, issue.ElseExpected("not surrogate"));

    public static Expect<char> IsNotLowSurrogatePair(this Expect<char> expect, char highSurrogate, Issue<char> issue = null) =>
      expect.Not(t => char.IsSurrogatePair(highSurrogate, t), issue.ElseExpected($"not low surrogate pair with {Text(highSurrogate)}"));

    public static Expect<char> IsNotSymbol(this Expect<char> expect, Issue<char> issue = null) =>
      expect.Not(char.IsSymbol, issue.ElseExpected("not symbol"));

    public static Expect<char> IsNotUpper(this Expect<char> expect, Issue<char> issue = null) =>
      expect.Not(char.IsUpper, issue.ElseExpected("not uppercase"));

    public static Expect<char> IsNotWhiteSpace(this Expect<char> expect, Issue<char> issue = null) =>
      expect.Not(char.IsWhiteSpace, issue.ElseExpected("not whitespace"));

    //
    // Uri
    //

    public static Expect<Uri> HasAbsolutePath(this Expect<Uri> expect, string value, Issue<Uri> issue = null) =>
      expect.That(t => t?.AbsolutePath == value, issue.ElseExpectedHas(nameof(Uri.AbsolutePath), value, t => t.AbsolutePath));

    public static Expect<Uri> HasAbsoluteUri(this Expect<Uri> expect, string value, Issue<Uri> issue = null) =>
      expect.That(t => t?.AbsoluteUri == value, issue.ElseExpectedHas(nameof(Uri.AbsoluteUri), value, t => t.AbsoluteUri));

    public static Expect<Uri> HasAuthority(this Expect<Uri> expect, string value, Issue<Uri> issue = null) =>
      expect.That(t => t?.Authority == value, issue.ElseExpectedHas(nameof(Uri.Authority), value, t => t.Authority));

    public static Expect<Uri> HasDnsSafeHost(this Expect<Uri> expect, string value, Issue<Uri> issue = null) =>
      expect.That(t => t?.DnsSafeHost == value, issue.ElseExpectedHas(nameof(Uri.DnsSafeHost), value, t => t.DnsSafeHost));

    public static Expect<Uri> HasFragment(this Expect<Uri> expect, string value, Issue<Uri> issue = null) =>
      expect.That(t => t?.Fragment == value, issue.ElseExpectedHas(nameof(Uri.Fragment), value, t => t.Fragment));

    public static Expect<Uri> HasHost(this Expect<Uri> expect, string value, Issue<Uri> issue = null) =>
      expect.That(t => t?.Host == value, issue.ElseExpectedHas(nameof(Uri.Host), value, t => t.Host));

    public static Expect<Uri> HasHostNameType(this Expect<Uri> expect, UriHostNameType value, Issue<Uri> issue = null) =>
      expect.That(t => t?.HostNameType == value, issue.ElseExpectedHas(nameof(Uri.HostNameType), value, t => t.HostNameType));

    public static Expect<Uri> HasIdnHost(this Expect<Uri> expect, string value, Issue<Uri> issue = null) =>
      expect.That(t => t?.IdnHost == value, issue.ElseExpectedHas(nameof(Uri.IdnHost), value, t => t.IdnHost));

    public static Expect<Uri> HasLocalPath(this Expect<Uri> expect, string value, Issue<Uri> issue = null) =>
      expect.That(t => t?.LocalPath == value, issue.ElseExpectedHas(nameof(Uri.LocalPath), value, t => t.LocalPath));

    public static Expect<Uri> HasOriginalString(this Expect<Uri> expect, string value, Issue<Uri> issue = null) =>
      expect.That(t => t?.OriginalString == value, issue.ElseExpectedHas(nameof(Uri.OriginalString), value, t => t.OriginalString));

    public static Expect<Uri> HasPathAndQuery(this Expect<Uri> expect, string value, Issue<Uri> issue = null) =>
      expect.That(t => t?.PathAndQuery == value, issue.ElseExpectedHas(nameof(Uri.PathAndQuery), value, t => t.PathAndQuery));

    public static Expect<Uri> HasPort(this Expect<Uri> expect, int value, Issue<Uri> issue = null) =>
      expect.That(t => t?.Port == value, issue.ElseExpectedHas(nameof(Uri.Port), value, t => t.Port));

    public static Expect<Uri> HasQuery(this Expect<Uri> expect, string value, Issue<Uri> issue = null) =>
      expect.That(t => t?.Query == value, issue.ElseExpectedHas(nameof(Uri.Query), value, t => t.Query));

    public static Expect<Uri> HasScheme(this Expect<Uri> expect, string value, Issue<Uri> issue = null) =>
      expect.That(t => t?.Scheme == value, issue.ElseExpectedHas(nameof(Uri.Scheme), value, t => t.Scheme));





    // TODO: Determine the relationship between nested expectations



    //public static Expect<Uri> HasSegments(this Expect<Uri> expect, IEnumerable<string> value, Issue<Uri> issue = null) =>
    //  expect.That(t => ExpectMany.That(t.Segments).HasSameInOrder(value));





    public static Expect<Uri> HasUserInfo(this Expect<Uri> expect, string value, Issue<Uri> issue = null) =>
      expect.That(t => t?.UserInfo == value, issue.ElseExpectedHas(nameof(Uri.UserInfo), value, t => t.UserInfo));

    public static Expect<Uri> IsAbsoluteUri(this Expect<Uri> expect, bool value, Issue<Uri> issue = null) =>
      expect.That(t => t?.IsAbsoluteUri == value, issue.ElseExpectedHas(nameof(Uri.IsAbsoluteUri), value, t => t.IsAbsoluteUri));

    public static Expect<Uri> IsFile(this Expect<Uri> expect, bool value, Issue<Uri> issue = null) =>
      expect.That(t => t?.IsFile == value, issue.ElseExpectedHas(nameof(Uri.IsFile), value, t => t.IsFile));

    public static Expect<Uri> IsUnc(this Expect<Uri> expect, bool value, Issue<Uri> issue = null) =>
      expect.That(t => t?.IsUnc == value, issue.ElseExpectedHas(nameof(Uri.IsUnc), value, t => t.IsUnc));

    public static Expect<Uri> IsLoopback(this Expect<Uri> expect, bool value, Issue<Uri> issue = null) =>
      expect.That(t => t?.IsLoopback == value, issue.ElseExpectedHas(nameof(Uri.IsLoopback), value, t => t.IsLoopback));

    public static Expect<Uri> IsUserEscaped(this Expect<Uri> expect, bool value, Issue<Uri> issue = null) =>
      expect.That(t => t?.UserEscaped == value, issue.ElseExpectedHas(nameof(Uri.UserEscaped), value, t => t.UserEscaped));

    //
    // Uri (values)
    //

    public static Expect<Uri> HasAbsolutePath(this Expect<Uri> expect, Action<Expect<string>> expectValue) =>
      expect.That(t => t != null && expectValue.Invoke(t.AbsolutePath));

    public static Expect<Uri> HasAbsoluteUri(this Expect<Uri> expect, Action<Expect<string>> expectValue) =>
      expect.That(t => t != null && expectValue.Invoke(t.AbsoluteUri));

    public static Expect<Uri> HasAuthority(this Expect<Uri> expect, Action<Expect<string>> expectValue) =>
      expect.That(t => t != null && expectValue.Invoke(t.Authority));

    public static Expect<Uri> HasDnsSafeHost(this Expect<Uri> expect, Action<Expect<string>> expectValue) =>
      expect.That(t => t != null && expectValue.Invoke(t.DnsSafeHost));

    public static Expect<Uri> HasFragment(this Expect<Uri> expect, Action<Expect<string>> expectValue) =>
      expect.That(t => t != null && expectValue.Invoke(t.Fragment));

    public static Expect<Uri> HasHost(this Expect<Uri> expect, Action<Expect<string>> expectValue) =>
      expect.That(t => t != null && expectValue.Invoke(t.Host));

    public static Expect<Uri> HasHostNameType(this Expect<Uri> expect, Action<Expect<UriHostNameType>> expectValue) =>
      expect.That(t => t != null && expectValue.Invoke(t.HostNameType));

    public static Expect<Uri> HasIdnHost(this Expect<Uri> expect, Action<Expect<string>> expectValue) =>
      expect.That(t => t != null && expectValue.Invoke(t.IdnHost));

    public static Expect<Uri> HasLocalPath(this Expect<Uri> expect, Action<Expect<string>> expectValue) =>
      expect.That(t => t != null && expectValue.Invoke(t.LocalPath));

    public static Expect<Uri> HasOriginalString(this Expect<Uri> expect, Action<Expect<string>> expectValue) =>
      expect.That(t => t != null && expectValue.Invoke(t.OriginalString));

    public static Expect<Uri> HasPathAndQuery(this Expect<Uri> expect, Action<Expect<string>> expectValue) =>
      expect.That(t => t != null && expectValue.Invoke(t.PathAndQuery));

    public static Expect<Uri> HasPort(this Expect<Uri> expect, Action<Expect<int>> expectValue) =>
      expect.That(t => t != null && expectValue.Invoke(t.Port));

    public static Expect<Uri> HasQuery(this Expect<Uri> expect, Action<Expect<string>> expectValue) =>
      expect.That(t => t != null && expectValue.Invoke(t.Query));

    public static Expect<Uri> HasScheme(this Expect<Uri> expect, Action<Expect<string>> expectValue) =>
      expect.That(t => t != null && expectValue.Invoke(t.Scheme));







    //public static Expect<Uri> HasSegments(this Expect<Uri> expect, Action<ExpectMany<string>> expectValue) =>
    //  expect.That(t => t != null && expectValue.Invoke(t.Segments));







    public static Expect<Uri> HasUserInfo(this Expect<Uri> expect, Action<Expect<string>> expectValue) =>
      expect.That(t => t != null && expectValue.Invoke(t.UserInfo));

    public static Expect<Uri> IsAbsoluteUri(this Expect<Uri> expect, Action<Expect<bool>> expectValue) =>
      expect.That(t => t != null && expectValue.Invoke(t.IsAbsoluteUri));

    public static Expect<Uri> IsFile(this Expect<Uri> expect, Action<Expect<bool>> expectValue) =>
      expect.That(t => t != null && expectValue.Invoke(t.IsFile));

    public static Expect<Uri> IsUnc(this Expect<Uri> expect, Action<Expect<bool>> expectValue) =>
      expect.That(t => t != null && expectValue.Invoke(t.IsUnc));

    public static Expect<Uri> IsLoopback(this Expect<Uri> expect, Action<Expect<bool>> expectValue) =>
      expect.That(t => t != null && expectValue.Invoke(t.IsLoopback));

    public static Expect<Uri> IsUserEscaped(this Expect<Uri> expect, Action<Expect<bool>> expectValue) =>
      expect.That(t => t != null && expectValue.Invoke(t.UserEscaped));
  }
}