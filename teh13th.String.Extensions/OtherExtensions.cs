namespace teh13th.String.Extensions
{
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
		{
			if (obj is null)
			{
				throw new ArgumentNullException(variableName ?? nameof(obj));
			}

			return obj;
		}

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
		/// Validates that <paramref name="timeSpan">time span</paramref> is positive.
		/// </summary>
		/// <param name="timeSpan">Time span to test.</param>
		/// <param name="variableName">Name of tested variable.</param>
		/// <returns>Original time span.</returns>
		public static TimeSpan ValidatePosititve(this TimeSpan timeSpan, string? variableName = null)
		{
			if (timeSpan <= TimeSpan.Zero)
			{
				throw new ArgumentOutOfRangeException(variableName ?? nameof(timeSpan),
													  timeSpan,
													  "Value must be greater than zero.");
			}

			return timeSpan;
		}

		/// <summary>
		/// Validates that <paramref name="timeSpan">time span</paramref> is non-negative.
		/// </summary>
		/// <param name="timeSpan">Time span to test.</param>
		/// <param name="variableName">Name of tested variable.</param>
		/// <returns>Original time span.</returns>
		public static TimeSpan ValidateNonNegative(this TimeSpan timeSpan, string? variableName = null)
		{
			if (timeSpan < TimeSpan.Zero)
			{
				throw new ArgumentOutOfRangeException(variableName ?? nameof(timeSpan),
													  timeSpan,
													  "Value must be not lower than zero.");
			}

			return timeSpan;
		}
	}
}