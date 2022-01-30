using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
#if !NET40
using System.Runtime.CompilerServices;
#endif

namespace teh13th.String.Extensions;

/// <summary>
/// Useful extensions for <see cref="string"/> splitting.
/// </summary>
public static class SplitExtensions
{
	/// <summary>
	/// Splits a string into substrings based on the <paramref name="separator"/>. You can specify whether the substrings include empty array elements, removing extra whitespaces.
	/// </summary>
	/// <param name="str">The string to split.</param>
	/// <param name="separator">A character that delimits the substrings in this string, an empty array that contains no delimiters, or null.</param>
	/// <returns>Substrings.</returns>
	[Pure]
#if !NET40
	public static IReadOnlyList<string> SplitBy(this string? str, char separator)
#else
	public static IList<string> SplitBy(this string? str, char separator)
#endif
		=> str?.Trim()
#if NET5_0_OR_GREATER
			   .Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
#else
			   .Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries)
			   .Where(p => !string.IsNullOrWhiteSpace(p))
#endif
			   .Select(p => p.Trim())
			   .ToArray()
			?? EmptyArray();

	/// <summary>
	/// Splits a string into a maximum number of substrings based on the <paramref name="separator"/>, removing extra whitespaces.
	/// </summary>
	/// <param name="str">The string to split.</param>
	/// <param name="separator">A character that delimits the substrings in this string, an empty array that contains no delimiters, or null.</param>
	/// <param name="count">The maximum number of substrings to return.</param>
	/// <returns>An array whose elements contain the substrings in this string that are delimited by one or more characters in <paramref name="separator"/>.</returns>
	[Pure]
#if !NET40
	public static IReadOnlyList<string> SplitBy(this string? str, char separator, int count)
#else
	public static IList<string> SplitBy(this string? str, char separator, int count)
#endif
		=> str?.Trim()
#if NET5_0_OR_GREATER
			   .Split(new[] { separator }, count, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
#else
			   .Split(new[] { separator }, count, StringSplitOptions.RemoveEmptyEntries)
			   .Where(p => !string.IsNullOrWhiteSpace(p))
#endif
			   .Select(p => p.Trim())
			   .ToArray()
			?? EmptyArray();

	/// <summary>
	/// Splits a string into substrings based on the <paramref name="separator"/>. You can specify whether the substrings include empty array elements, removing extra whitespaces.
	/// </summary>
	/// <param name="str">The string to split.</param>
	/// <param name="separator">A string that delimits the substrings in this string, an empty array that contains no delimiters, or null.</param>
	/// <returns>Substrings.</returns>
	[Pure]
#if !NET40
	public static IReadOnlyList<string> SplitBy(this string? str, string? separator)
#else
	public static IList<string> SplitBy(this string? str, string? separator)
#endif
		=> str?.Trim()
#if NET5_0_OR_GREATER
			   .Split(new[] { separator! }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
#else
			   .Split(new[] { separator! }, StringSplitOptions.RemoveEmptyEntries)
			   .Where(p => !string.IsNullOrWhiteSpace(p))
#endif
			   .Select(p => p.Trim())
			   .ToArray()
			?? EmptyArray();

	/// <summary>
	/// Splits a string into a maximum number of substrings based on the <paramref name="separator"/>, removing extra whitespaces.
	/// </summary>
	/// <param name="str">The string to split.</param>
	/// <param name="separator">A string that delimits the substrings in this string, an empty array that contains no delimiters, or null.</param>
	/// <param name="count">The maximum number of substrings to return.</param>
	/// <returns>An array whose elements contain the substrings in this string that are delimited by one or more characters in <paramref name="separator"/>.</returns>
	[Pure]
#if !NET40
	public static IReadOnlyList<string> SplitBy(this string? str, string? separator, int count)
#else
	public static IList<string> SplitBy(this string? str, string? separator, int count)
#endif
		=> str?.Trim()
#if NET5_0_OR_GREATER
			   .Split(new[] { separator! }, count, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
#else
			   .Split(new[] { separator! }, count, StringSplitOptions.RemoveEmptyEntries)
			   .Where(p => !string.IsNullOrWhiteSpace(p))
#endif
			   .Select(p => p.Trim())
			   .ToArray()
			?? EmptyArray();

	[Pure, DebuggerStepThrough]
#if !NET40
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static IReadOnlyList<string> EmptyArray() => Array.Empty<string>();
#else
	private static string[] EmptyArray() => new string[0];
#endif
}