using System.Collections.Generic;

namespace Green
{
  /// <summary>
  /// Applies this issue to <paramref name="target"/>
  /// </summary>
  /// <typeparam name="T">The type of items in the sequence with the issue</typeparam>
  /// <param name="target">The sequence with the issue</param>
  /// <returns>The result of applying this issue to <paramref name="target"/></returns>
  public delegate IssueResult IssueMany<T>(IEnumerable<T> target);

  /// <summary>
  /// Applies this issue to <paramref name="target"/>
  /// </summary>
  /// <typeparam name="TKey">The type of keys in the dictionary with the issue</typeparam>
  /// <typeparam name="TValue">The type of values in the dictionary with the issue</typeparam>
  /// <param name="target">The dictionary with the issue</param>
  /// <returns>The result of applying this issue to <paramref name="target"/></returns>
  public delegate IssueResult IssueMany<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> target);
}