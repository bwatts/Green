using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Green
{
  /// <summary>
  /// Extends <see cref="Issue{T}"/>, <see cref="IssueMany{T}"/>, and <see cref="IssueMany{TKey, TValue}"/>
  /// with methods to build messages for unmet expectations
  /// </summary>
  public static class Issuable
  {
    internal static string ToStackTrace(this IEnumerable<StackFrame> frames) =>
      string.Join(Environment.NewLine, frames.Select(x => new StackTrace(x).ToString()));

    internal static string GetCallerStackTrace() =>
      new StackTrace(fNeedFileInfo: true).GetFrames().Where(IsCaller).ToStackTrace();

    internal static bool IsCaller(this StackFrame frame) =>
      frame?.GetMethod()?.DeclaringType.FullName.StartsWith("Green.") is false;

    //
    // Exceptions
    //

    /// <summary>
    /// Creates an instance of <see cref="ExpectException"/> with the result of applying <paramref name="issue"/> to <paramref name="target"/>
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="issue">The issue to apply to the target value</param>
    /// <param name="target">The target value with the issue</param>
    /// <param name="expectedResult">The expected outcome that did not occur</param>
    /// <param name="inner">The exception that caused the issue, if any</param>
    /// <returns>An instance of <see cref="ExpectException"/> with the result of applying <paramref name="issue"/> to <paramref name="target"/></returns>
    public static ExpectException ToException<T>(this Issue<T>? issue, T target, bool expectedResult = true, Exception? inner = null) =>
      (issue?.Invoke(target) ?? IssueResult.Default()).ToException(
        $@"Unexpected value of type {target?.GetType() ?? typeof(T)}",
        Text.Of(target),
        expectedResult,
        inner);

    /// <summary>
    /// Creates an instance of <see cref="ExpectException"/> with the result of applying <paramref name="issue"/> to <paramref name="target"/>
    /// </summary>
    /// <typeparam name="T">The type of items in the target sequence</typeparam>
    /// <param name="issue">The issue to apply to the target sequence</param>
    /// <param name="target">The target sequence with the issue</param>
    /// <param name="expectedResult">The expected outcome that did not occur</param>
    /// <param name="inner">The exception that caused the issue, if any</param>
    /// <returns>An instance of <see cref="ExpectException"/> with the result of applying <paramref name="issue"/> to <paramref name="target"/></returns>
    public static ExpectException ToException<T>(this IssueMany<T>? issue, IEnumerable<T> target, bool expectedResult = true, Exception? inner = null) =>
      (issue?.Invoke(target) ?? IssueResult.Default()).ToException(
        $@"Unexpected sequence of type {target?.GetType() ?? typeof(IEnumerable<T>)} with items of type {typeof(T)}",
        Text.Many(target),
        expectedResult,
        inner);

    /// <summary>
    /// Creates an instance of <see cref="ExpectException"/> with the result of applying <paramref name="issue"/> to <paramref name="target"/>
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of valuesin the target dictionary</typeparam>
    /// <param name="issue">The issue to apply to the target dictionary</param>
    /// <param name="target">The target dictionary with the issue</param>
    /// <param name="expectedResult">The expected outcome that did not occur</param>
    /// <param name="inner">The exception that caused the issue, if any</param>
    /// <returns>An instance of <see cref="ExpectException"/> with the result of applying <paramref name="issue"/> to <paramref name="target"/></returns>
    public static ExpectException ToException<TKey, TValue>(this IssueMany<TKey, TValue>? issue, IEnumerable<KeyValuePair<TKey, TValue>> target, bool expectedResult = true, Exception? inner = null) =>
      (issue?.Invoke(target) ?? IssueResult.Default()).ToException(
        $@"Unexpected dictionary of type {target?.GetType() ?? typeof(IEnumerable<KeyValuePair<TKey, TValue>>)} with keys of type {typeof(TKey)} and values of type {typeof(TValue)}",
        Text.Many(target),
        expectedResult,
        inner);

    /// <summary>
    /// Creates an instance of <see cref="ExpectException"/> with the result of applying <paramref name="issue"/> to <paramref name="target"/>
    /// </summary>
    /// <typeparam name="TDelegate">The type of delegate expected to throw an exception</typeparam>
    /// <param name="issue">The issue to apply to the target delegate</param>
    /// <param name="target">The target value with the issue</param>
    /// <param name="expectedExceptionType">The type of exception that <paramref name="target"/> was expected to throw</param>
    /// <param name="inner">The exception that caused the issue, if any</param>
    /// <returns>An instance of <see cref="ExpectException"/> with the result of applying <paramref name="issue"/> to <paramref name="target"/></returns>
    public static ExpectException ToThrowsException<TDelegate>(this Issue<TDelegate>? issue, TDelegate target, Type expectedExceptionType, Exception? inner = null) =>
      (issue?.Invoke(target) ?? IssueResult.Default()).ToException(
        $@"Expected delegate of type {target?.GetType() ?? typeof(TDelegate)} to throw an exception of type {expectedExceptionType}",
        Text.Of(target),
        true,
        inner);

    //
    // Operators
    //

    /// <summary>
    /// Gets an issue that describes the current operator method and with <paramref name="issue"/> as the outer issue
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="issue">The outer issue of the operator issue, if any</param>
    /// <returns>An issue that describes the current operator method and with <paramref name="issue"/> as the outer issue</returns>
    public static Issue<T> Operator<T>(this Issue<T>? issue) =>
      issue.ToOperator(IssueArgs.None);

    /// <summary>
    /// Gets an issue that describes the current operator method and with <paramref name="issue"/> as the outer issue
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <typeparam name="TArg">The type of argument 0 in the operator method signature</typeparam>
    /// <param name="issue">The outer issue of the operator issue, if any</param>
    /// <param name="arg">Argument 0 in the operator method signature</param>
    /// <returns>An issue that describes the current operator method and with <paramref name="issue"/> as the outer issue</returns>
    public static Issue<T> Operator<T, TArg>(this Issue<T>? issue, TArg arg) =>
      issue.ToOperator(IssueArgs.Of(arg));

    /// <summary>
    /// Gets an issue that describes the current operator method and with <paramref name="issue"/> as the outer issue
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <typeparam name="TArg0">The type of argument 0 in the operator method signature</typeparam>
    /// <typeparam name="TArg1">The type of argument 1 in the operator method signature</typeparam>
    /// <param name="issue">The outer issue of the operator issue, if any</param>
    /// <param name="arg0">Argument 0 in the operator method signature</param>
    /// <param name="arg1">Argument 1 in the operator method signature</param>
    /// <returns>An issue that describes the current operator method and with <paramref name="issue"/> as the outer issue</returns>
    public static Issue<T> Operator<T, TArg0, TArg1>(this Issue<T>? issue, TArg0 arg0, TArg1 arg1) =>
      issue.ToOperator(IssueArgs.Of(arg0, arg1));

    /// <summary>
    /// Gets an issue that describes the current operator method and with <paramref name="issue"/> as the outer issue
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <typeparam name="TArg0">The type of argument 0 in the operator method signature</typeparam>
    /// <typeparam name="TArg1">The type of argument 1 in the operator method signature</typeparam>
    /// <typeparam name="TArg2">The type of argument 2 in the operator method signature</typeparam>
    /// <param name="issue">The outer issue of the operator issue, if any</param>
    /// <param name="arg0">Argument 0 in the operator method signature</param>
    /// <param name="arg1">Argument 1 in the operator method signature</param>
    /// <param name="arg2">Argument 2 in the operator method signature</param>
    /// <returns>An issue that describes the current operator method and with <paramref name="issue"/> as the outer issue</returns>
    public static Issue<T> Operator<T, TArg0, TArg1, TArg2>(this Issue<T>? issue, TArg0 arg0, TArg1 arg1, TArg2 arg2) =>
      issue.ToOperator(IssueArgs.Of(arg0, arg1, arg2));

    /// <summary>
    /// Gets an issue that describes the current operator method and with <paramref name="issue"/> as the outer issue
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <typeparam name="TArg0">The type of argument 0 in the operator method signature</typeparam>
    /// <typeparam name="TArg1">The type of argument 1 in the operator method signature</typeparam>
    /// <typeparam name="TArg2">The type of argument 2 in the operator method signature</typeparam>
    /// <typeparam name="TArg3">The type of argument 3 in the operator method signature</typeparam>
    /// <param name="issue">The outer issue of the operator issue, if any</param>
    /// <param name="arg0">Argument 0 in the operator method signature</param>
    /// <param name="arg1">Argument 1 in the operator method signature</param>
    /// <param name="arg2">Argument 2 in the operator method signature</param>
    /// <param name="arg3">Argument 3 in the operator method signature</param>
    /// <returns>An issue that describes the current operator method and with <paramref name="issue"/> as the outer issue</returns>
    public static Issue<T> Operator<T, TArg0, TArg1, TArg2, TArg3>(this Issue<T>? issue, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3) =>
      issue.ToOperator(IssueArgs.Of(arg0, arg1, arg2, arg3));

    /// <summary>
    /// Gets an issue that describes the current operator method and with <paramref name="issue"/> as the outer issue
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <typeparam name="TArg0">The type of argument 0 in the operator method signature</typeparam>
    /// <typeparam name="TArg1">The type of argument 1 in the operator method signature</typeparam>
    /// <typeparam name="TArg2">The type of argument 2 in the operator method signature</typeparam>
    /// <typeparam name="TArg3">The type of argument 3 in the operator method signature</typeparam>
    /// <typeparam name="TArg4">The type of argument 4 in the operator method signature</typeparam>
    /// <param name="issue">The outer issue of the operator issue, if any</param>
    /// <param name="arg0">Argument 0 in the operator method signature</param>
    /// <param name="arg1">Argument 1 in the operator method signature</param>
    /// <param name="arg2">Argument 2 in the operator method signature</param>
    /// <param name="arg3">Argument 3 in the operator method signature</param>
    /// <param name="arg4">Argument 4 in the operator method signature</param>
    /// <returns>An issue that describes the current operator method and with <paramref name="issue"/> as the outer issue</returns>
    public static Issue<T> Operator<T, TArg0, TArg1, TArg2, TArg3, TArg4>(this Issue<T>? issue, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4) =>
      issue.ToOperator(IssueArgs.Of(arg0, arg1, arg2, arg3, arg4));

    /// <summary>
    /// Gets an issue that describes the current operator method and with <paramref name="issue"/> as the outer issue
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <typeparam name="TArg0">The type of argument 0 in the operator method signature</typeparam>
    /// <typeparam name="TArg1">The type of argument 1 in the operator method signature</typeparam>
    /// <typeparam name="TArg2">The type of argument 2 in the operator method signature</typeparam>
    /// <typeparam name="TArg3">The type of argument 3 in the operator method signature</typeparam>
    /// <typeparam name="TArg4">The type of argument 4 in the operator method signature</typeparam>
    /// <typeparam name="TArg5">The type of argument 5 in the operator method signature</typeparam>
    /// <param name="issue">The outer issue of the operator issue, if any</param>
    /// <param name="arg0">Argument 0 in the operator method signature</param>
    /// <param name="arg1">Argument 1 in the operator method signature</param>
    /// <param name="arg2">Argument 2 in the operator method signature</param>
    /// <param name="arg3">Argument 3 in the operator method signature</param>
    /// <param name="arg4">Argument 4 in the operator method signature</param>
    /// <param name="arg5">Argument 5 in the operator method signature</param>
    /// <returns>An issue that describes the current operator method and with <paramref name="issue"/> as the outer issue</returns>
    public static Issue<T> Operator<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Issue<T>? issue, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5) =>
      issue.ToOperator(IssueArgs.Of(arg0, arg1, arg2, arg3, arg4, arg5));

    /// <summary>
    /// Gets an issue that describes the current operator method and with <paramref name="issue"/> as the outer issue
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <typeparam name="TArg0">The type of argument 0 in the operator method signature</typeparam>
    /// <typeparam name="TArg1">The type of argument 1 in the operator method signature</typeparam>
    /// <typeparam name="TArg2">The type of argument 2 in the operator method signature</typeparam>
    /// <typeparam name="TArg3">The type of argument 3 in the operator method signature</typeparam>
    /// <typeparam name="TArg4">The type of argument 4 in the operator method signature</typeparam>
    /// <typeparam name="TArg5">The type of argument 5 in the operator method signature</typeparam>
    /// <typeparam name="TArg6">The type of argument 6 in the operator method signature</typeparam>
    /// <param name="issue">The outer issue of the operator issue, if any</param>
    /// <param name="arg0">Argument 0 in the operator method signature</param>
    /// <param name="arg1">Argument 1 in the operator method signature</param>
    /// <param name="arg2">Argument 2 in the operator method signature</param>
    /// <param name="arg3">Argument 3 in the operator method signature</param>
    /// <param name="arg4">Argument 4 in the operator method signature</param>
    /// <param name="arg5">Argument 5 in the operator method signature</param>
    /// <param name="arg6">Argument 6 in the operator method signature</param>
    /// <returns>An issue that describes the current operator method and with <paramref name="issue"/> as the outer issue</returns>
    public static Issue<T> Operator<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Issue<T>? issue, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6) =>
      issue.ToOperator(IssueArgs.Of(arg0, arg1, arg2, arg3, arg4, arg5, arg6));

    /// <summary>
    /// Gets an issue that describes the current operator method and with <paramref name="issue"/> as the outer issue
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <typeparam name="TArg0">The type of argument 0 in the operator method signature</typeparam>
    /// <typeparam name="TArg1">The type of argument 1 in the operator method signature</typeparam>
    /// <typeparam name="TArg2">The type of argument 2 in the operator method signature</typeparam>
    /// <typeparam name="TArg3">The type of argument 3 in the operator method signature</typeparam>
    /// <typeparam name="TArg4">The type of argument 4 in the operator method signature</typeparam>
    /// <typeparam name="TArg5">The type of argument 5 in the operator method signature</typeparam>
    /// <typeparam name="TArg6">The type of argument 6 in the operator method signature</typeparam>
    /// <typeparam name="TArg7">The type of argument 7 in the operator method signature</typeparam>
    /// <param name="issue">The outer issue of the operator issue, if any</param>
    /// <param name="arg0">Argument 0 in the operator method signature</param>
    /// <param name="arg1">Argument 1 in the operator method signature</param>
    /// <param name="arg2">Argument 2 in the operator method signature</param>
    /// <param name="arg3">Argument 3 in the operator method signature</param>
    /// <param name="arg4">Argument 4 in the operator method signature</param>
    /// <param name="arg5">Argument 5 in the operator method signature</param>
    /// <param name="arg6">Argument 6 in the operator method signature</param>
    /// <param name="arg7">Argument 7 in the operator method signature</param>
    /// <returns>An issue that describes the current operator method and with <paramref name="issue"/> as the outer issue</returns>
    public static Issue<T> Operator<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Issue<T>? issue, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7) =>
      issue.ToOperator(IssueArgs.Of(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7));

    static Issue<T> ToOperator<T>(this Issue<T>? issue, IssueArgs args) =>
      target => args.ToResult(
        issue?.Invoke(target),
        typeof(Expect<T>),
        typeof(Issue<T>),
        new[] { typeof(T) },
        isMany: false);

    //
    // Operators (items)
    //

    /// <summary>
    /// Gets an issue that describes the current operator method and with <paramref name="issue"/> as the outer issue
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <param name="issue">The outer issue of the operator issue, if any</param>
    /// <returns>An issue that describes the current operator method and with <paramref name="issue"/> as the outer issue</returns>
    public static IssueMany<T> Operator<T>(this IssueMany<T>? issue) =>
      issue.ToOperator(IssueArgs.None);

    /// <summary>
    /// Gets an issue that describes the current operator method and with <paramref name="issue"/> as the outer issue
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <typeparam name="TArg">The type of argument 0 in the operator method signature</typeparam>
    /// <param name="issue">The outer issue of the operator issue, if any</param>
    /// <param name="arg">Argument 0 in the operator method signature</param>
    /// <returns>An issue that describes the current operator method and with <paramref name="issue"/> as the outer issue</returns>
    public static IssueMany<T> Operator<T, TArg>(this IssueMany<T>? issue, TArg arg) =>
      issue.ToOperator(IssueArgs.Of(arg));

    /// <summary>
    /// Gets an issue that describes the current operator method and with <paramref name="issue"/> as the outer issue
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <typeparam name="TArg0">The type of argument 0 in the operator method signature</typeparam>
    /// <typeparam name="TArg1">The type of argument 1 in the operator method signature</typeparam>
    /// <param name="issue">The outer issue of the operator issue, if any</param>
    /// <param name="arg0">Argument 0 in the operator method signature</param>
    /// <param name="arg1">Argument 1 in the operator method signature</param>
    /// <returns>An issue that describes the current operator method and with <paramref name="issue"/> as the outer issue</returns>
    public static IssueMany<T> Operator<T, TArg0, TArg1>(this IssueMany<T>? issue, TArg0 arg0, TArg1 arg1) =>
      issue.ToOperator(IssueArgs.Of(arg0, arg1));

    /// <summary>
    /// Gets an issue that describes the current operator method and with <paramref name="issue"/> as the outer issue
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <typeparam name="TArg0">The type of argument 0 in the operator method signature</typeparam>
    /// <typeparam name="TArg1">The type of argument 1 in the operator method signature</typeparam>
    /// <typeparam name="TArg2">The type of argument 2 in the operator method signature</typeparam>
    /// <param name="issue">The outer issue of the operator issue, if any</param>
    /// <param name="arg0">Argument 0 in the operator method signature</param>
    /// <param name="arg1">Argument 1 in the operator method signature</param>
    /// <param name="arg2">Argument 2 in the operator method signature</param>
    /// <returns>An issue that describes the current operator method and with <paramref name="issue"/> as the outer issue</returns>
    public static IssueMany<T> Operator<T, TArg0, TArg1, TArg2>(this IssueMany<T>? issue, TArg0 arg0, TArg1 arg1, TArg2 arg2) =>
      issue.ToOperator(IssueArgs.Of(arg0, arg1, arg2));

    /// <summary>
    /// Gets an issue that describes the current operator method and with <paramref name="issue"/> as the outer issue
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <typeparam name="TArg0">The type of argument 0 in the operator method signature</typeparam>
    /// <typeparam name="TArg1">The type of argument 1 in the operator method signature</typeparam>
    /// <typeparam name="TArg2">The type of argument 2 in the operator method signature</typeparam>
    /// <typeparam name="TArg3">The type of argument 3 in the operator method signature</typeparam>
    /// <param name="issue">The outer issue of the operator issue, if any</param>
    /// <param name="arg0">Argument 0 in the operator method signature</param>
    /// <param name="arg1">Argument 1 in the operator method signature</param>
    /// <param name="arg2">Argument 2 in the operator method signature</param>
    /// <param name="arg3">Argument 3 in the operator method signature</param>
    /// <returns>An issue that describes the current operator method and with <paramref name="issue"/> as the outer issue</returns>
    public static IssueMany<T> Operator<T, TArg0, TArg1, TArg2, TArg3>(this IssueMany<T>? issue, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3) =>
      issue.ToOperator(IssueArgs.Of(arg0, arg1, arg2, arg3));

    /// <summary>
    /// Gets an issue that describes the current operator method and with <paramref name="issue"/> as the outer issue
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <typeparam name="TArg0">The type of argument 0 in the operator method signature</typeparam>
    /// <typeparam name="TArg1">The type of argument 1 in the operator method signature</typeparam>
    /// <typeparam name="TArg2">The type of argument 2 in the operator method signature</typeparam>
    /// <typeparam name="TArg3">The type of argument 3 in the operator method signature</typeparam>
    /// <typeparam name="TArg4">The type of argument 4 in the operator method signature</typeparam>
    /// <param name="issue">The outer issue of the operator issue, if any</param>
    /// <param name="arg0">Argument 0 in the operator method signature</param>
    /// <param name="arg1">Argument 1 in the operator method signature</param>
    /// <param name="arg2">Argument 2 in the operator method signature</param>
    /// <param name="arg3">Argument 3 in the operator method signature</param>
    /// <param name="arg4">Argument 4 in the operator method signature</param>
    /// <returns>An issue that describes the current operator method and with <paramref name="issue"/> as the outer issue</returns>
    public static IssueMany<T> Operator<T, TArg0, TArg1, TArg2, TArg3, TArg4>(this IssueMany<T>? issue, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4) =>
      issue.ToOperator(IssueArgs.Of(arg0, arg1, arg2, arg3, arg4));

    /// <summary>
    /// Gets an issue that describes the current operator method and with <paramref name="issue"/> as the outer issue
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <typeparam name="TArg0">The type of argument 0 in the operator method signature</typeparam>
    /// <typeparam name="TArg1">The type of argument 1 in the operator method signature</typeparam>
    /// <typeparam name="TArg2">The type of argument 2 in the operator method signature</typeparam>
    /// <typeparam name="TArg3">The type of argument 3 in the operator method signature</typeparam>
    /// <typeparam name="TArg4">The type of argument 4 in the operator method signature</typeparam>
    /// <typeparam name="TArg5">The type of argument 5 in the operator method signature</typeparam>
    /// <param name="issue">The outer issue of the operator issue, if any</param>
    /// <param name="arg0">Argument 0 in the operator method signature</param>
    /// <param name="arg1">Argument 1 in the operator method signature</param>
    /// <param name="arg2">Argument 2 in the operator method signature</param>
    /// <param name="arg3">Argument 3 in the operator method signature</param>
    /// <param name="arg4">Argument 4 in the operator method signature</param>
    /// <param name="arg5">Argument 5 in the operator method signature</param>
    /// <returns>An issue that describes the current operator method and with <paramref name="issue"/> as the outer issue</returns>
    public static IssueMany<T> Operator<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this IssueMany<T>? issue, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5) =>
      issue.ToOperator(IssueArgs.Of(arg0, arg1, arg2, arg3, arg4, arg5));

    /// <summary>
    /// Gets an issue that describes the current operator method and with <paramref name="issue"/> as the outer issue
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <typeparam name="TArg0">The type of argument 0 in the operator method signature</typeparam>
    /// <typeparam name="TArg1">The type of argument 1 in the operator method signature</typeparam>
    /// <typeparam name="TArg2">The type of argument 2 in the operator method signature</typeparam>
    /// <typeparam name="TArg3">The type of argument 3 in the operator method signature</typeparam>
    /// <typeparam name="TArg4">The type of argument 4 in the operator method signature</typeparam>
    /// <typeparam name="TArg5">The type of argument 5 in the operator method signature</typeparam>
    /// <typeparam name="TArg6">The type of argument 6 in the operator method signature</typeparam>
    /// <param name="issue">The outer issue of the operator issue, if any</param>
    /// <param name="arg0">Argument 0 in the operator method signature</param>
    /// <param name="arg1">Argument 1 in the operator method signature</param>
    /// <param name="arg2">Argument 2 in the operator method signature</param>
    /// <param name="arg3">Argument 3 in the operator method signature</param>
    /// <param name="arg4">Argument 4 in the operator method signature</param>
    /// <param name="arg5">Argument 5 in the operator method signature</param>
    /// <param name="arg6">Argument 6 in the operator method signature</param>
    /// <returns>An issue that describes the current operator method and with <paramref name="issue"/> as the outer issue</returns>
    public static IssueMany<T> Operator<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this IssueMany<T>? issue, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6) =>
      issue.ToOperator(IssueArgs.Of(arg0, arg1, arg2, arg3, arg4, arg5, arg6));

    /// <summary>
    /// Gets an issue that describes the current operator method and with <paramref name="issue"/> as the outer issue
    /// </summary>
    /// <typeparam name="T">The type of target value</typeparam>
    /// <typeparam name="TArg0">The type of argument 0 in the operator method signature</typeparam>
    /// <typeparam name="TArg1">The type of argument 1 in the operator method signature</typeparam>
    /// <typeparam name="TArg2">The type of argument 2 in the operator method signature</typeparam>
    /// <typeparam name="TArg3">The type of argument 3 in the operator method signature</typeparam>
    /// <typeparam name="TArg4">The type of argument 4 in the operator method signature</typeparam>
    /// <typeparam name="TArg5">The type of argument 5 in the operator method signature</typeparam>
    /// <typeparam name="TArg6">The type of argument 6 in the operator method signature</typeparam>
    /// <typeparam name="TArg7">The type of argument 7 in the operator method signature</typeparam>
    /// <param name="issue">The outer issue of the operator issue, if any</param>
    /// <param name="arg0">Argument 0 in the operator method signature</param>
    /// <param name="arg1">Argument 1 in the operator method signature</param>
    /// <param name="arg2">Argument 2 in the operator method signature</param>
    /// <param name="arg3">Argument 3 in the operator method signature</param>
    /// <param name="arg4">Argument 4 in the operator method signature</param>
    /// <param name="arg5">Argument 5 in the operator method signature</param>
    /// <param name="arg6">Argument 6 in the operator method signature</param>
    /// <param name="arg7">Argument 7 in the operator method signature</param>
    /// <returns>An issue that describes the current operator method and with <paramref name="issue"/> as the outer issue</returns>
    public static IssueMany<T> Operator<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this IssueMany<T>? issue, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7) =>
      issue.ToOperator(IssueArgs.Of(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7));

    static IssueMany<T> ToOperator<T>(this IssueMany<T>? issue, IssueArgs args) =>
      target => args.ToResult(
        issue?.Invoke(target),
        typeof(ExpectMany<T>),
        typeof(IssueMany<T>),
        new[] { typeof(T) },
        isMany: true);

    //
    // Operators (pairs)
    //

    /// <summary>
    /// Gets an issue that describes the current operator method and with <paramref name="issue"/> as the outer issue
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of valuesin the target dictionary</typeparam>
    /// <param name="issue">The outer issue of the operator issue, if any</param>
    /// <returns>An issue that describes the current operator method and with <paramref name="issue"/> as the outer issue</returns>
    public static IssueMany<TKey, TValue> Operator<TKey, TValue>(this IssueMany<TKey, TValue>? issue) =>
      issue.ToOperator(IssueArgs.None);

    /// <summary>
    /// Gets an issue that describes the current operator method and with <paramref name="issue"/> as the outer issue
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of valuesin the target dictionary</typeparam>
    /// <typeparam name="TArg">The type of argument 0 in the operator method signature</typeparam>
    /// <param name="issue">The outer issue of the operator issue, if any</param>
    /// <param name="arg">Argument 0 in the operator method signature</param>
    /// <returns>An issue that describes the current operator method and with <paramref name="issue"/> as the outer issue</returns>
    public static IssueMany<TKey, TValue> Operator<TKey, TValue, TArg>(this IssueMany<TKey, TValue>? issue, TArg arg) =>
      issue.ToOperator(IssueArgs.Of(arg));

    /// <summary>
    /// Gets an issue that describes the current operator method and with <paramref name="issue"/> as the outer issue
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of valuesin the target dictionary</typeparam>
    /// <typeparam name="TArg0">The type of argument 0 in the operator method signature</typeparam>
    /// <typeparam name="TArg1">The type of argument 1 in the operator method signature</typeparam>
    /// <param name="issue">The outer issue of the operator issue, if any</param>
    /// <param name="arg0">Argument 0 in the operator method signature</param>
    /// <param name="arg1">Argument 1 in the operator method signature</param>
    /// <returns>An issue that describes the current operator method and with <paramref name="issue"/> as the outer issue</returns>
    public static IssueMany<TKey, TValue> Operator<TKey, TValue, TArg0, TArg1>(this IssueMany<TKey, TValue>? issue, TArg0 arg0, TArg1 arg1) =>
      issue.ToOperator(IssueArgs.Of(arg0, arg1));

    /// <summary>
    /// Gets an issue that describes the current operator method and with <paramref name="issue"/> as the outer issue
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of valuesin the target dictionary</typeparam>
    /// <typeparam name="TArg0">The type of argument 0 in the operator method signature</typeparam>
    /// <typeparam name="TArg1">The type of argument 1 in the operator method signature</typeparam>
    /// <typeparam name="TArg2">The type of argument 2 in the operator method signature</typeparam>
    /// <param name="issue">The outer issue of the operator issue, if any</param>
    /// <param name="arg0">Argument 0 in the operator method signature</param>
    /// <param name="arg1">Argument 1 in the operator method signature</param>
    /// <param name="arg2">Argument 2 in the operator method signature</param>
    /// <returns>An issue that describes the current operator method and with <paramref name="issue"/> as the outer issue</returns>
    public static IssueMany<TKey, TValue> Operator<TKey, TValue, TArg0, TArg1, TArg2>(this IssueMany<TKey, TValue>? issue, TArg0 arg0, TArg1 arg1, TArg2 arg2) =>
      issue.ToOperator(IssueArgs.Of(arg0, arg1, arg2));

    /// <summary>
    /// Gets an issue that describes the current operator method and with <paramref name="issue"/> as the outer issue
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of valuesin the target dictionary</typeparam>
    /// <typeparam name="TArg0">The type of argument 0 in the operator method signature</typeparam>
    /// <typeparam name="TArg1">The type of argument 1 in the operator method signature</typeparam>
    /// <typeparam name="TArg2">The type of argument 2 in the operator method signature</typeparam>
    /// <typeparam name="TArg3">The type of argument 3 in the operator method signature</typeparam>
    /// <param name="issue">The outer issue of the operator issue, if any</param>
    /// <param name="arg0">Argument 0 in the operator method signature</param>
    /// <param name="arg1">Argument 1 in the operator method signature</param>
    /// <param name="arg2">Argument 2 in the operator method signature</param>
    /// <param name="arg3">Argument 3 in the operator method signature</param>
    /// <returns>An issue that describes the current operator method and with <paramref name="issue"/> as the outer issue</returns>
    public static IssueMany<TKey, TValue> Operator<TKey, TValue, TArg0, TArg1, TArg2, TArg3>(this IssueMany<TKey, TValue>? issue, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3) =>
      issue.ToOperator(IssueArgs.Of(arg0, arg1, arg2, arg3));

    /// <summary>
    /// Gets an issue that describes the current operator method and with <paramref name="issue"/> as the outer issue
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of valuesin the target dictionary</typeparam>
    /// <typeparam name="TArg0">The type of argument 0 in the operator method signature</typeparam>
    /// <typeparam name="TArg1">The type of argument 1 in the operator method signature</typeparam>
    /// <typeparam name="TArg2">The type of argument 2 in the operator method signature</typeparam>
    /// <typeparam name="TArg3">The type of argument 3 in the operator method signature</typeparam>
    /// <typeparam name="TArg4">The type of argument 4 in the operator method signature</typeparam>
    /// <param name="issue">The outer issue of the operator issue, if any</param>
    /// <param name="arg0">Argument 0 in the operator method signature</param>
    /// <param name="arg1">Argument 1 in the operator method signature</param>
    /// <param name="arg2">Argument 2 in the operator method signature</param>
    /// <param name="arg3">Argument 3 in the operator method signature</param>
    /// <param name="arg4">Argument 4 in the operator method signature</param>
    /// <returns>An issue that describes the current operator method and with <paramref name="issue"/> as the outer issue</returns>
    public static IssueMany<TKey, TValue> Operator<TKey, TValue, TArg0, TArg1, TArg2, TArg3, TArg4>(this IssueMany<TKey, TValue>? issue, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4) =>
      issue.ToOperator(IssueArgs.Of(arg0, arg1, arg2, arg3, arg4));

    /// <summary>
    /// Gets an issue that describes the current operator method and with <paramref name="issue"/> as the outer issue
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of valuesin the target dictionary</typeparam>
    /// <typeparam name="TArg0">The type of argument 0 in the operator method signature</typeparam>
    /// <typeparam name="TArg1">The type of argument 1 in the operator method signature</typeparam>
    /// <typeparam name="TArg2">The type of argument 2 in the operator method signature</typeparam>
    /// <typeparam name="TArg3">The type of argument 3 in the operator method signature</typeparam>
    /// <typeparam name="TArg4">The type of argument 4 in the operator method signature</typeparam>
    /// <typeparam name="TArg5">The type of argument 5 in the operator method signature</typeparam>
    /// <param name="issue">The outer issue of the operator issue, if any</param>
    /// <param name="arg0">Argument 0 in the operator method signature</param>
    /// <param name="arg1">Argument 1 in the operator method signature</param>
    /// <param name="arg2">Argument 2 in the operator method signature</param>
    /// <param name="arg3">Argument 3 in the operator method signature</param>
    /// <param name="arg4">Argument 4 in the operator method signature</param>
    /// <param name="arg5">Argument 5 in the operator method signature</param>
    /// <returns>An issue that describes the current operator method and with <paramref name="issue"/> as the outer issue</returns>
    public static IssueMany<TKey, TValue> Operator<TKey, TValue, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this IssueMany<TKey, TValue>? issue, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5) =>
      issue.ToOperator(IssueArgs.Of(arg0, arg1, arg2, arg3, arg4, arg5));

    /// <summary>
    /// Gets an issue that describes the current operator method and with <paramref name="issue"/> as the outer issue
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of valuesin the target dictionary</typeparam>
    /// <typeparam name="TArg0">The type of argument 0 in the operator method signature</typeparam>
    /// <typeparam name="TArg1">The type of argument 1 in the operator method signature</typeparam>
    /// <typeparam name="TArg2">The type of argument 2 in the operator method signature</typeparam>
    /// <typeparam name="TArg3">The type of argument 3 in the operator method signature</typeparam>
    /// <typeparam name="TArg4">The type of argument 4 in the operator method signature</typeparam>
    /// <typeparam name="TArg5">The type of argument 5 in the operator method signature</typeparam>
    /// <typeparam name="TArg6">The type of argument 6 in the operator method signature</typeparam>
    /// <param name="issue">The outer issue of the operator issue, if any</param>
    /// <param name="arg0">Argument 0 in the operator method signature</param>
    /// <param name="arg1">Argument 1 in the operator method signature</param>
    /// <param name="arg2">Argument 2 in the operator method signature</param>
    /// <param name="arg3">Argument 3 in the operator method signature</param>
    /// <param name="arg4">Argument 4 in the operator method signature</param>
    /// <param name="arg5">Argument 5 in the operator method signature</param>
    /// <param name="arg6">Argument 6 in the operator method signature</param>
    /// <returns>An issue that describes the current operator method and with <paramref name="issue"/> as the outer issue</returns>
    public static IssueMany<TKey, TValue> Operator<TKey, TValue, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this IssueMany<TKey, TValue>? issue, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6) =>
      issue.ToOperator(IssueArgs.Of(arg0, arg1, arg2, arg3, arg4, arg5, arg6));

    /// <summary>
    /// Gets an issue that describes the current operator method and with <paramref name="issue"/> as the outer issue
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the target dictionary</typeparam>
    /// <typeparam name="TValue">The type of valuesin the target dictionary</typeparam>
    /// <typeparam name="TArg0">The type of argument 0 in the operator method signature</typeparam>
    /// <typeparam name="TArg1">The type of argument 1 in the operator method signature</typeparam>
    /// <typeparam name="TArg2">The type of argument 2 in the operator method signature</typeparam>
    /// <typeparam name="TArg3">The type of argument 3 in the operator method signature</typeparam>
    /// <typeparam name="TArg4">The type of argument 4 in the operator method signature</typeparam>
    /// <typeparam name="TArg5">The type of argument 5 in the operator method signature</typeparam>
    /// <typeparam name="TArg6">The type of argument 6 in the operator method signature</typeparam>
    /// <typeparam name="TArg7">The type of argument 7 in the operator method signature</typeparam>
    /// <param name="issue">The outer issue of the operator issue, if any</param>
    /// <param name="arg0">Argument 0 in the operator method signature</param>
    /// <param name="arg1">Argument 1 in the operator method signature</param>
    /// <param name="arg2">Argument 2 in the operator method signature</param>
    /// <param name="arg3">Argument 3 in the operator method signature</param>
    /// <param name="arg4">Argument 4 in the operator method signature</param>
    /// <param name="arg5">Argument 5 in the operator method signature</param>
    /// <param name="arg6">Argument 6 in the operator method signature</param>
    /// <param name="arg7">Argument 7 in the operator method signature</param>
    /// <returns>An issue that describes the current operator method and with <paramref name="issue"/> as the outer issue</returns>
    public static IssueMany<TKey, TValue> Operator<TKey, TValue, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this IssueMany<TKey, TValue>? issue, TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7) =>
      issue.ToOperator(IssueArgs.Of(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7));

    static IssueMany<TKey, TValue> ToOperator<TKey, TValue>(this IssueMany<TKey, TValue>? issue, IssueArgs args) =>
      target => args.ToResult(
        issue?.Invoke(target),
        typeof(ExpectMany<TKey, TValue>),
        typeof(IssueMany<TKey, TValue>),
        new[] { typeof(TKey), typeof(TValue) },
        isMany: true);

    //
    // Results
    //

    static IssueResult ToResult(this IssueArgs args, IssueResult? outer, Type expectType, Type issueType, Type[] typeArgs, bool isMany)
    {
      var method = default(MethodBase);
      var parameters = default(ParameterInfo[]);
      var callerFrames = new List<StackFrame>();

      foreach(var frame in new StackTrace(skipFrames: 2, fNeedFileInfo: true).GetFrames())
      {
        if(method == null && frame.TryGetOperator(expectType, issueType, args, typeArgs, out method, out parameters))
        {
          callerFrames.Add(frame);
        }
        else
        {
          if(frame.IsCaller())
          {
            callerFrames.Add(frame);
          }
        }
      }

      var stackTrace = callerFrames.ToStackTrace();

      if(method == null)
      {
        return IssueResult.Default(stackTrace, outer);
      }
      else if(isMany)
      {
        return IssueResult.OperatorMany(stackTrace, method.Name, args.ToOperatorString(parameters!), outer);
      }
      else
      {
        return IssueResult.Operator(stackTrace, method.Name, args.ToOperatorString(parameters!), outer);
      }
    }

    static bool TryGetOperator(
      this StackFrame frame,
      Type expectType,
      Type issueType,
      IssueArgs args,
      Type[] typeArgs,
      out MethodBase? method,
      out ParameterInfo[]? parameters)
    {
      var frameMethod = frame.GetMethod() as MethodInfo;

      if(frameMethod != null
        && frameMethod.DeclaringType != typeof(Issuable)
        && frameMethod?.GetCustomAttribute<ExtensionAttribute>() != null)
      {
        if(frameMethod.ContainsGenericParameters)
        {
          var genericArgs = frameMethod.GetGenericArguments();

          if(genericArgs.Length == typeArgs.Length)
          {
            frameMethod = frameMethod.MakeGenericMethod(typeArgs.ToArray());
          }
        }

        var frameParameters = frameMethod.GetParameters();

        if(frameParameters.Length > 0 && frameParameters[0].ParameterType == expectType)
        {
          var argParameters = frameParameters.Skip(1).Where(x => x.ParameterType != issueType).ToArray();

          if(argParameters.Select(x => x.ParameterType).SequenceEqual(args.Types))
          {
            method = frameMethod;
            parameters = argParameters;
            return true;
          }
        }
      }

      method = null;
      parameters = null;
      return false;
    }

    static string ToOperatorString(this IssueArgs args, ParameterInfo[] parameters)
    {
      var builder = new StringBuilder();
      var values = args.Values.GetEnumerator();

      foreach(var parameter in parameters!)
      {
        values.MoveNext();

        if(builder.Length > 0)
        {
          builder.Append(", ");
        }

        builder.Append(parameter.Name).Append(": ").Append(Text.Of(values.Current));
      }

      return builder.ToString();
    }
  }
}