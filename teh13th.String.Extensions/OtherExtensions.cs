using System;

namespace teh13th.String.Extensions;

/// <summary>
/// Useful extensions.
/// </summary>
public static class OtherExtensions
{
	/// <summary>
	/// Validates that <paramref name="obj">object</paramref> is not null.
	/// </summary>
	/// <param name="obj">Object to test.</param>
	/// <param name="variableName">Name of tested variable.</param>
	/// <returns>Original object.</returns>
	public static object ValidateNotNull(this object? obj, string? variableName = null)
		=> obj is null
				? throw new ArgumentNullException(variableName ?? nameof(obj))
				: obj;

	/// <summary>
	/// Validates that <paramref name="i">number</paramref> is positive.
	/// </summary>
	/// <param name="i">Number to test.</param>
	/// <param name="variableName">Name of tested variable.</param>
	public static void ValidatePosititve(this long i, string? variableName = null)
	{
		if (i <= 0)
		{
			throw new ArgumentOutOfRangeException(variableName ?? nameof(i), i, "Value must be greater than zero.");
		}
	}

	/// <summary>
	/// Validates that <paramref name="timeSpan">time span</paramref> is positive.
	/// </summary>
	/// <param name="timeSpan">Time span to test.</param>
	/// <param name="variableName">Name of tested variable.</param>
	/// <returns>Original time span.</returns>
	public static TimeSpan ValidatePosititve(this TimeSpan timeSpan, string? variableName = null)
		=> timeSpan <= TimeSpan.Zero
				? throw new ArgumentOutOfRangeException(variableName ?? nameof(timeSpan),
														timeSpan,
														"Value must be greater than zero.")
				: timeSpan;

	/// <summary>
	/// Validates that <paramref name="i">number</paramref> is non-negative.
	/// </summary>
	/// <param name="i">Number to test.</param>
	/// <param name="variableName">Name of tested variable.</param>
	public static void ValidateNonNegative(this long i, string? variableName = null)
	{
		if (i < 0)
		{
			throw new ArgumentOutOfRangeException(variableName ?? nameof(i), i, "Value must be not lower than zero.");
		}
	}

	/// <summary>
	/// Validates that <paramref name="timeSpan">time span</paramref> is non-negative.
	/// </summary>
	/// <param name="timeSpan">Time span to test.</param>
	/// <param name="variableName">Name of tested variable.</param>
	/// <returns>Original time span.</returns>
	public static TimeSpan ValidateNonNegative(this TimeSpan timeSpan, string? variableName = null)
		=> timeSpan < TimeSpan.Zero
				? throw new ArgumentOutOfRangeException(variableName ?? nameof(timeSpan),
														timeSpan,
														"Value must be not lower than zero.")
				: timeSpan;

#if NETCOREAPP2_1_OR_GREATER
	/// <summary>
	/// Returns a new string in which all occurrences of a specified string in the current
	/// instance are replaced with another specified string (ignore case).
	/// </summary>
	/// <param name="str">The original string.</param>
	/// <param name="oldValue">The string to be replaced.</param>
	/// <param name="newValue">The string to replace all occurrences of oldValue.</param>
	/// <returns>
	/// A string that is equivalent to the current string except that all instances of
	/// oldValue are replaced with newValue. If oldValue is not found in the current
	/// instance, the method returns the current instance unchanged.
	/// </returns>
	public static string? ReplaceI(this string? str, string oldValue, string newValue)
	{
		return str?.Replace(oldValue, newValue, StringComparison.OrdinalIgnoreCase);
	}
#endif
}