namespace Green
{
  public static class IssuableTestsOperators
  {
    public static Expect<int> Test(this Expect<int> expect, Issue<int>? issue = null) =>
      expect.That(t => false, issue.Operator());

    public static ExpectMany<int> Test(this ExpectMany<int> expect, IssueMany<int>? issue = null) =>
      expect.That(t => false, issue.Operator());

    public static ExpectMany<int, string> Test(this ExpectMany<int, string> expect, IssueMany<int, string>? issue = null) =>
      expect.That(t => false, issue.Operator());

    //
    // TestWithArg
    //

    public static Expect<int> TestWithArg(this Expect<int> expect, int arg, Issue<int>? issue = null) =>
      expect.That(t => false, issue.Operator(arg));

    public static ExpectMany<int> TestWithArg(this ExpectMany<int> expect, int arg, IssueMany<int>? issue = null) =>
      expect.That(t => false, issue.Operator(arg));

    public static ExpectMany<int, string> TestWithArg(this ExpectMany<int, string> expect, int arg, IssueMany<int, string>? issue = null) =>
      expect.That(t => false, issue.Operator(arg));

    //
    // TestWithArgs
    //

    public static Expect<int> TestWithArgs(this Expect<int> expect, int arg0, int arg1, Issue<int>? issue = null) =>
      expect.That(t => false, issue.Operator(arg0, arg1));

    public static ExpectMany<int> TestWithArgs(this ExpectMany<int> expect, int arg0, int arg1, IssueMany<int>? issue = null) =>
      expect.That(t => false, issue.Operator(arg0, arg1));

    public static ExpectMany<int, string> TestWithArgs(this ExpectMany<int, string> expect, int arg0, int arg1, IssueMany<int, string>? issue = null) =>
      expect.That(t => false, issue.Operator(arg0, arg1));
  }
}