using System.Collections.Generic;

namespace Green.Messages
{
  /// <summary>
  /// Brings text-related Green methods into the local scope:
  /// <code>NullText</code>
  /// <code>EmptyText</code>
  /// <code>Text</code>
  /// <code>TextMany</code>
  /// <code>Expected</code>
  /// </summary>
  public static class Local
  {
    /// <summary>
    /// Text describing the <see langword="null"/> reference
    /// </summary>
    public const string NullText = Messages.Text.Null;

    /// <summary>
    /// Text describing the empty string ("")
    /// </summary>
    public const string EmptyText = Messages.Text.Empty;

    /// <summary>
    /// Gets text for <paramref name="value"/> that defers formatting until requested
    /// </summary>
    /// <typeparam name="T">The type of value to format</typeparam>
    /// <param name="value">The value to format</param>
    /// <returns>Text for <paramref name="value"/> that defers formatting until requested</returns>
    public static Text<T> Text<T>(T value) =>
      Messages.Text.Of(value);

    /// <summary>
    /// Gets text for <paramref name="pair"/> that defers formatting until requested
    /// </summary>
    /// <typeparam name="TKey">The type of key in the pair to format</typeparam>
    /// <typeparam name="TValue">The type of value in the pair to format</typeparam>
    /// <param name="pair">The pair to format</param>
    /// <returns>Text for <paramref name="pair"/> that defers formatting until requested</returns>
    public static Text<TKey, TValue> Text<TKey, TValue>(KeyValuePair<TKey, TValue> pair) =>
      Messages.Text.Of(pair);

    /// <summary>
    /// Gets text for <paramref name="items"/> that defers formatting until requested
    /// </summary>
    /// <typeparam name="T">The type of items in the sequence to format</typeparam>
    /// <param name="items">The sequence to format</param>
    /// <returns>Text for <paramref name="items"/> that defers formatting until requested</returns>
    public static TextMany<T> TextMany<T>(IEnumerable<T> items) =>
      Messages.Text.Many(items);

    /// <summary>
    /// Gets text for <paramref name="pairs"/> that defers formatting until requested
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the dictionary to format</typeparam>
    /// <typeparam name="TValue">The type of values in the dictionary to format</typeparam>
    /// <returns>Text for <paramref name="pairs"/> that defers formatting until requested</returns>
    public static TextMany<TKey, TValue> TextMany<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> pairs) =>
      Messages.Text.Many(pairs);

    /// <summary>
    /// Formats a message for <paramref name="target"/> with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="T">The type of value to format</typeparam>
    /// <param name="target">The value to format</param>
    /// <param name="expected">The section describing the expected value</param>
    /// <param name="received">The section describing the received value</param>
    public static string Expected<T>(T target, string expected, string received) =>
      Messages.Text.Expected(target, expected, received);

    /// <summary>
    /// Formats a message for <paramref name="target"/> with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="T">The type of items in the sequence to format</typeparam>
    /// <param name="target">The sequence to format</param>
    /// <param name="expected">The section describing the expected sequence</param>
    /// <param name="received">The section describing the received sequence</param>
    /// <returns>The formatted message</returns>
    public static string Expected<T>(IEnumerable<T> target, string expected, string received) =>
      Messages.Text.Expected(target, expected, received);

    /// <summary>
    /// Formats a message for <paramref name="target"/> with <paramref name="expected"/> and <paramref name="received"/> sections
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the dictionary to format</typeparam>
    /// <typeparam name="TValue">The type of values in the dictionary to format</typeparam>
    /// <param name="target">The dictionary to format</param>
    /// <param name="expected">The section describing the expected dictionary</param>
    /// <param name="received">The section describing the received dictionary</param>
    /// <returns>The formatted message</returns>
    public static string Expected<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> target, string expected, string received) =>
      Messages.Text.Expected(target, expected, received);

    /// <summary>
    /// Formats a message for <paramref name="target"/> with <paramref name="expected"/> and received sections
    /// </summary>
    /// <typeparam name="T">The type of value to format</typeparam>
    /// <param name="target">The value to format</param>
    /// <param name="expected">The section describing the expected value</param>
    /// <returns>The formatted message</returns>
    public static string Expected<T>(T target, string expected) =>
      Messages.Text.Expected(target, expected);

    /// <summary>
    /// Formats a message for <paramref name="target"/> with <paramref name="expected"/> and received sections
    /// </summary>
    /// <typeparam name="T">The type of items in the sequence to format</typeparam>
    /// <param name="target">The sequence to format</param>
    /// <param name="expected">The section describing the expected sequence</param>
    /// <returns>The formatted message</returns>
    public static string Expected<T>(IEnumerable<T> target, string expected) =>
      Messages.Text.Expected(target, expected);

    /// <summary>
    /// Formats a message for <paramref name="target"/> with <paramref name="expected"/> and received sections
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the dictionary to format</typeparam>
    /// <typeparam name="TValue">The type of values in the dictionary to format</typeparam>
    /// <param name="target">The dictionary to format</param>
    /// <param name="expected">The section describing the expected dictionary</param>
    /// <returns>The formatted message</returns>
    public static string Expected<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> target, string expected) =>
      Messages.Text.Expected(target, expected);
  }
}