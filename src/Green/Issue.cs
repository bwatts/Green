namespace Green
{
  /// <summary>
  /// Applies this issue to <paramref name="target"/>
  /// </summary>
  /// <typeparam name="T">The type of value with the issue</typeparam>
  /// <param name="target">The value with the issue</param>
  /// <returns>The result of applying this issue to <paramref name="target"/></returns>
  public delegate IssueResult Issue<T>(T target);
}