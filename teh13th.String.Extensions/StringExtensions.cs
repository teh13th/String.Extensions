using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace teh13th.String.Extensions
{
	/// <summary>
	/// Some useful extension for work with strings.
	/// </summary>
	[PublicAPI]
	public static class StringExtensions
	{
		/// <summary>
		/// Splits a string into substrings based on the <paramref name="separator"/>. You can specify whether the substrings include empty array elements, removing extra whitespaces.
		/// </summary>
		/// <param name="str">The string to split.</param>
		/// <param name="separator">A character that delimits the substrings in this string, an empty array that contains no delimiters, or null.</param>
		/// <returns>Substrings.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), NotNull, ItemNotNull, Pure]
		public static IList<string> SplitBy([CanBeNull] this string str, char separator)
		{
			return str?.Trim()
					  .Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries)
					  .Select(p => p.Trim())
					  .ToArray()
				   ?? Array.Empty<string>();
		}

		/// <summary>
		/// Splits a string into a maximum number of substrings based on the <paramref name="separator"/>, removing extra whitespaces.
		/// </summary>
		/// <param name="str">The string to split.</param>
		/// <param name="separator">A character that delimits the substrings in this string, an empty array that contains no delimiters, or null.</param>
		/// <param name="count">The maximum number of substrings to return.</param>
		/// <returns>An array whose elements contain the substrings in this string that are delimited by one or more characters in <paramref name="separator"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), NotNull, ItemNotNull, Pure]
		public static IList<string> SplitBy([CanBeNull] this string str, char separator, int count)
		{
			return str?.Trim()
					  .Split(new[] { separator }, count, StringSplitOptions.RemoveEmptyEntries)
					  .Select(p => p.Trim())
					  .ToArray()
				   ?? Array.Empty<string>();
		}

		/// <summary>
		/// Splits a string into substrings based on the <paramref name="separator"/>. You can specify whether the substrings include empty array elements, removing extra whitespaces.
		/// </summary>
		/// <param name="str">The string to split.</param>
		/// <param name="separator">A string that delimits the substrings in this string, an empty array that contains no delimiters, or null.</param>
		/// <returns>Substrings.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), NotNull, ItemNotNull, Pure]
		public static IList<string> SplitBy([CanBeNull] this string str, [CanBeNull] string separator)
		{
			return str?.Trim()
					  .Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries)
					  .Select(p => p.Trim())
					  .ToArray()
				   ?? Array.Empty<string>();
		}

		/// <summary>
		/// Splits a string into a maximum number of substrings based on the <paramref name="separator"/>, removing extra whitespaces.
		/// </summary>
		/// <param name="str">The string to split.</param>
		/// <param name="separator">A string that delimits the substrings in this string, an empty array that contains no delimiters, or null.</param>
		/// <param name="count">The maximum number of substrings to return.</param>
		/// <returns>An array whose elements contain the substrings in this string that are delimited by one or more characters in <paramref name="separator"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), NotNull, ItemNotNull, Pure]
		public static IList<string> SplitBy([CanBeNull] this string str, [CanBeNull] string separator, int count)
		{
			return str?.Trim()
					  .Split(new[] { separator }, count, StringSplitOptions.RemoveEmptyEntries)
					  .Select(p => p.Trim())
					  .ToArray()
				   ?? Array.Empty<string>();
		}

		/// <summary>
		/// Determines whether two specified <see cref="T:System.String"></see> objects have the same value (ignore case).
		/// </summary>
		/// <param name="str">The first string to compare, or null.</param>
		/// <param name="value">The second string to compare, or null.</param>
		/// <returns>true if the value of the <paramref name="str"/> parameter is equal to the value of the <paramref name="value"/> parameter; otherwise, false.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		[ContractAnnotation("str:null, value:null => true")]
		[ContractAnnotation("str:null, value:notnull => false")]
		[ContractAnnotation("str:notnull, value:null => false")]
		public static bool EqualsI([CanBeNull] this string str, [CanBeNull] string value)
		{
			return string.Equals(str, value, StringComparison.OrdinalIgnoreCase);
		}

		/// <summary>
		/// Determines whether specified <see cref="T:System.String"></see> object have on of values from <paramref name="values">strings</paramref> (ignore case).
		/// </summary>
		/// <param name="str">The string to compare, or null.</param>
		/// <param name="values">Possible values for <paramref name="str"/>.</param>
		/// <returns>true if the value of the <paramref name="str"/> parameter is equal to one of values of the <paramref name="values"/> parameter; otherwise, false.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		[ContractAnnotation("values:null => false")]
		public static bool EqualsOrI([CanBeNull] this string str, [CanBeNull, ItemCanBeNull] params string[] values)
		{
			return values != null && values.Any(str.EqualsI);
		}

		/// <summary>
		/// Determines whether the beginning of this string instance matches the specified string (ignore case).
		/// </summary>
		/// <param name="str">The string to check.</param>
		/// <param name="value">The string to compare.</param>
		/// <returns>true if this instance begins with <paramref name="value"/>; otherwise, false.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		[ContractAnnotation("str:null => false; str:notnull, value:null => true")]
		public static bool StartsWithI([CanBeNull] this string str, [CanBeNull] string value)
		{
			if (str is null)
			{
				return false;
			}

			return value is null || str.StartsWith(value, StringComparison.OrdinalIgnoreCase);
		}

		/// <summary>
		/// Determines whether the end of this string instance matches the specified string (ignore case).
		/// </summary>
		/// <param name="str">The string to check.</param>
		/// <param name="value">The string to compare.</param>
		/// <returns>true if this instance ends with <paramref name="value"/>; otherwise, false.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		[ContractAnnotation("str:null => false; str:notnull, value:null => true")]
		public static bool EndsWithI([CanBeNull] this string str, [CanBeNull] string value)
		{
			if (str is null)
			{
				return false;
			}

			return value is null || str.EndsWith(value, StringComparison.OrdinalIgnoreCase);
		}

		/// <summary>
		/// Reports the zero-based index of the first occurrence of the specified string in the current <see cref="T:System.String"></see> object (ignore case).
		/// </summary>
		/// <param name="str">The string to check.</param>
		/// <param name="value">The string to seek.</param>
		/// <returns>The index position of the <paramref name="value"/> parameter if that string is found, or -1 if it is not. If <paramref name="value"/> is <see cref="F:System.String.Empty"></see>, the return value is 0.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static int IndexOfI([CanBeNull] this string str, [CanBeNull] string value)
		{
			if (str is null)
			{
				return -1;
			}

			if (value is null)
			{
				return -1;
			}

			return str.IndexOf(value, StringComparison.OrdinalIgnoreCase);
		}

		/// <summary>
		/// Returns a value indicating whether a specified substring occurs within this string (ignore case).
		/// </summary>
		/// <param name="str">The string to check.</param>
		/// <param name="value">The string to seek.</param>
		/// <returns>true if the <paramref name="value"/> parameter occurs within this string, or if <paramref name="value"/> is the empty string (""); otherwise, false.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		[ContractAnnotation("str:null => false; str:notnull, value:null => false")]
		public static bool ContainsI([CanBeNull] this string str, [CanBeNull] string value)
		{
			return str?.IndexOfI(value) >= 0;
		}

		/// <summary>
		/// Returns a value indicating whether a specified string occurs in <paramref name="values"/> (ignore case).
		/// </summary>
		/// <param name="str">The string to check.</param>
		/// <param name="values">Values to check for <paramref name="str"/>.</param>
		/// <returns>true if the value of the <paramref name="str"/> parameter contains one of values of the <paramref name="values"/> parameter; otherwise, false.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		[ContractAnnotation("str:null, values:notnull => false; values:null => false")]
		public static bool ContainsAnyI([CanBeNull] this string str, [CanBeNull, ItemCanBeNull] params string[] values)
		{
			return values?.Any(str.ContainsI) ?? false;
		}

		/// <summary>
		/// Determines whether a sequence contains a specified element (ignore case).
		/// </summary>
		/// <param name="strings">A sequence in which to locate a value.</param>
		/// <param name="value">The value to locate in the sequence.</param>
		/// <returns>true if the source sequence contains an element that has the specified value; otherwise, false.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		[ContractAnnotation("strings:null => false")]
		public static bool ContainsI([CanBeNull, ItemCanBeNull, InstantHandle] this IEnumerable<string> strings, [CanBeNull] string value)
		{
			return strings?.Contains(value, StringComparer.OrdinalIgnoreCase) ?? false;
		}

		/// <summary>
		/// Validates that string is not null or empty or whitespace.
		/// </summary>
		/// <param name="str">String to validate.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining), AssertionMethod]
		public static void Validate([CanBeNull, AssertionCondition(AssertionConditionType.IS_NOT_NULL)] this string str)
		{
			if (str is null)
			{
				throw new ArgumentNullException(nameof(str));
			}

			if (string.IsNullOrWhiteSpace(str))
			{
				throw new ArgumentException("Value cannot be empty or whitespace.", nameof(str));
			}
		}

		/// <summary>
		/// Validates file path string.
		/// </summary>
		/// <param name="filePath">File path string.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining), AssertionMethod]
		public static void ValidateFilePath([CanBeNull, AssertionCondition(AssertionConditionType.IS_NOT_NULL)] this string filePath)
		{
			filePath.Validate();

			if (!File.Exists(filePath))
			{
				throw new FileNotFoundException("Failed to find file.", filePath);
			}
		}

		/// <summary>
		/// Validates directory path string.
		/// </summary>
		/// <param name="directoryPath">Directory path string.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining), AssertionMethod]
		public static void ValidateDirectoryPath([CanBeNull, AssertionCondition(AssertionConditionType.IS_NOT_NULL)] this string directoryPath)
		{
			directoryPath.Validate();

			if (!Directory.Exists(directoryPath))
			{
				throw new DirectoryNotFoundException("Failed to find directory.");
			}
		}

		/// <summary>
		/// Parses <paramref name="enumString">string</paramref> to enum of type <typeparamref name="TEnum"/>.
		/// </summary>
		/// <param name="enumString">Enum's string representation.</param>
		/// <typeparam name="TEnum">Enum type.</typeparam>
		/// <returns>Enum.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		[ContractAnnotation("null => halt")]
		public static TEnum ToEnum<TEnum>([CanBeNull] this string enumString)
			where TEnum : struct
		{
			enumString.Validate();

			var enumType = typeof(TEnum);

			if (!Enum.TryParse(enumString, true, out TEnum enumResult))
			{
				throw new ArgumentOutOfRangeException(nameof(enumString),
													  $"Failed to parse {nameof(enumString)} to {enumType.Name} enum.");
			}

			if (!Enum.IsDefined(enumType, enumResult))
			{
				throw new InvalidEnumArgumentException(nameof(enumString),
													   int.Parse(enumString),
													   enumType);
			}

			return enumResult;
		}

		/// <summary>
		/// Parses <paramref name="uriString">string</paramref> to URI.
		/// </summary>
		/// <param name="uriString">URI string.</param>
		/// <returns>URI.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining), NotNull, Pure]
		[ContractAnnotation("null => halt")]
		public static Uri ToUri([CanBeNull] this string uriString)
		{
			uriString.Validate();

			if (!Uri.TryCreate(uriString, UriKind.Absolute, out var uri))
			{
				throw new FormatException($"URI '{uriString}' isn't valid");
			}

			return uri;
		}
	}
}