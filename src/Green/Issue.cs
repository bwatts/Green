using System.Collections.Generic;

namespace Green
{
  public delegate string Issue<T>(T target);
  public delegate string IssueMany<T>(IEnumerable<T> target);
  public delegate string IssueMany<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> target);
}