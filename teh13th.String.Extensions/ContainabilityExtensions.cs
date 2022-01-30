using System.Diagnostics.Contracts;

namespace teh13th.String.Extensions
{
	/// <summary>
	/// Useful extensions for <see cref="string"/> to check if one contains another.
	/// </summary>
	public static class ContainabilityExtensions
	{
		/// <summary>
		/// Determines whether the beginning of this string instance matches the specified string (ignore case).
		/// </summary>
		/// <param name="str">The string to check.</param>
		/// <param name="value">The string to compare.</param>
		/// <returns>true if this instance begins with <paramref name="value"/>; otherwise, false.</returns>
		[Pure]
		public static bool StartsWithI(this string? str, string? value)
			=> str is null
					? false
					: value is null || str.StartsWith(value, StringComparison.OrdinalIgnoreCase);

		/// <summary>
		/// Determines whether the end of this string instance matches the specified string (ignore case).
		/// </summary>
		/// <param name="str">The string to check.</param>
		/// <param name="value">The string to compare.</param>
		/// <returns>true if this instance ends with <paramref name="value"/>; otherwise, false.</returns>
		[Pure]
		public static bool EndsWithI(this string? str, string? value)
			=> str is null
					? false
					: value is null || str.EndsWith(value, StringComparison.OrdinalIgnoreCase);

		/// <summary>
		/// Reports the zero-based index of the first occurrence of the specified string in the current <see cref="T:System.String"></see> object (ignore case).
		/// </summary>
		/// <param name="str">The string to check.</param>
		/// <param name="value">The string to seek.</param>
		/// <returns>The index position of the <paramref name="value"/> parameter if that string is found, or -1 if it is not. If <paramref name="value"/> is <see cref="F:System.String.Empty"></see>, the return value is 0.</returns>
		[Pure]
		public static int IndexOfI(this string? str, string? value)
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
		[Pure]
		public static bool ContainsI(this string? str, string? value) => str?.IndexOfI(value) >= 0;

		/// <summary>
		/// Returns a value indicating whether a specified string occurs in <paramref name="values"/> (ignore case).
		/// </summary>
		/// <param name="str">The string to check.</param>
		/// <param name="values">Values to check for <paramref name="str"/>.</param>
		/// <returns>true if the value of the <paramref name="str"/> parameter contains one of values of the <paramref name="values"/> parameter; otherwise, false.</returns>
		[Pure]
		public static bool ContainsAnyI(this string? str, params string?[]? values)
			=> values?.Any(str.ContainsI) ?? false;

		/// <summary>
		/// Determines whether a sequence contains a specified element (ignore case).
		/// </summary>
		/// <param name="strings">A sequence in which to locate a value.</param>
		/// <param name="value">The value to locate in the sequence.</param>
		/// <returns>true if the source sequence contains an element that has the specified value; otherwise, false.</returns>
		[Pure]
		public static bool ContainsI(this IEnumerable<string?>? strings, string? value)
			=> strings?.Contains(value, StringComparer.OrdinalIgnoreCase) ?? false;
	}
}