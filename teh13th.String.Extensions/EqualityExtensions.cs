using System;
using System.Diagnostics.Contracts;
using System.Linq;

namespace teh13th.String.Extensions;

/// <summary>
/// Useful extensions for <see cref="string"/> equalizing.
/// </summary>
public static class EqualityExtensions
{
	/// <summary>
	/// Determines whether two specified <see cref="T:System.String"></see> objects have the same value (ignore case).
	/// </summary>
	/// <param name="str">The first string to compare, or null.</param>
	/// <param name="value">The second string to compare, or null.</param>
	/// <returns>true if the value of the <paramref name="str"/> parameter is equal to the value of the <paramref name="value"/> parameter; otherwise, false.</returns>
	[Pure]
	public static bool EqualsI(this string? str, string? value)
		=> string.Equals(str, value, StringComparison.OrdinalIgnoreCase);

	/// <summary>
	/// Determines whether specified <see cref="T:System.String"></see> object have on of values from <paramref name="values">strings</paramref> (ignore case).
	/// </summary>
	/// <param name="str">The string to compare, or null.</param>
	/// <param name="values">Possible values for <paramref name="str"/>.</param>
	/// <returns>true if the value of the <paramref name="str"/> parameter is equal to one of values of the <paramref name="values"/> parameter; otherwise, false.</returns>
	[Pure]
	public static bool EqualsOrI(this string? str, params string?[]? values)
		=> values is not null && values.Any(str.EqualsI);
}