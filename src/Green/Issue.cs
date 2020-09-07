using System.Collections.Generic;

namespace Green
{
  /// <summary>
  /// Builds a message describing an issue with <paramref name="target"/>
  /// </summary>
  /// <typeparam name="T">The type of value with the issue</typeparam>
  /// <param name="target">The value with the issue</param>
  /// <returns>A message describing an issue with <paramref name="target"/></returns>
  public delegate string Issue<T>(T target);

  /// <summary>
  /// Builds a message describing an issue with <paramref name="target"/>
  /// </summary>
  /// <typeparam name="T">The type of items in the sequence with the issue</typeparam>
  /// <param name="target">The sequence with the issue</param>
  /// <returns>A message describing an issue with <paramref name="target"/></returns>
  public delegate string IssueMany<T>(IEnumerable<T> target);

  /// <summary>
  /// Builds a message describing an issue with <paramref name="target"/>
  /// </summary>
  /// <typeparam name="TKey">The type of keys in the dictionary with the issue</typeparam>
  /// <typeparam name="TValue">The type of values in the dictionary with the issue</typeparam>
  /// <param name="target">The dictionary with the issue</param>
  /// <returns>A message describing an issue with <paramref name="target"/></returns>
  public delegate string IssueMany<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> target);
}