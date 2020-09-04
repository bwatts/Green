using System.Collections.Generic;

namespace Green.Messages
{
  public static class Local
  {
    public const string NullText = Messages.Text.Null;
    public const string EmptyText = Messages.Text.Empty;

    public static Text<T> Text<T>(T value) =>
      Messages.Text.Of(value);

    public static Text<TKey, TValue> Text<TKey, TValue>(KeyValuePair<TKey, TValue> pairs) =>
      Messages.Text.Of(pairs);

    public static TextMany<T> TextMany<T>(IEnumerable<T> items) =>
      Messages.Text.Many(items);

    public static TextMany<TKey, TValue> TextMany<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> pairs) =>
      Messages.Text.Many(pairs);

    public static string Expected<T>(T target, string expected, string received) =>
      Messages.Text.Expected(target, expected, received);

    public static string Expected<T>(IEnumerable<T> target, string expected, string received) =>
      Messages.Text.Expected(target, expected, received);

    public static string Expected<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> target, string expected, string received) =>
      Messages.Text.Expected(target, expected, received);

    public static string Expected<T>(T target, string expected) =>
      Messages.Text.Expected(target, expected);

    public static string Expected<T>(IEnumerable<T> target, string expected) =>
      Messages.Text.Expected(target, expected);

    public static string Expected<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> target, string expected) =>
      Messages.Text.Expected(target, expected);
  }
}