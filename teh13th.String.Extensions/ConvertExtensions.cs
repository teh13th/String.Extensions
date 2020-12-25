using System;
using System.ComponentModel;
using System.Net.Mail;
using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace teh13th.String.Extensions
{
	/// <summary>
	/// Useful extensions for <see cref="string"/> conversion.
	/// </summary>
	[PublicAPI]
	public static class ConvertExtensions
	{
		private const char SnakeCaseSeparator = '_';

		private static readonly Regex UnderscoreRegex = new($"{SnakeCaseSeparator}+(?<char>.)", RegexOptions.Compiled);
		private static readonly Regex CapitalLetterRegex = new(@"[A-Z]", RegexOptions.Compiled);

		/// <summary>
		/// Parses <paramref name="enumString">string</paramref> to enum of type <typeparamref name="TEnum"/>.
		/// </summary>
		/// <param name="enumString">Enum's string representation.</param>
		/// <param name="replacements">Char replacements.</param>
		/// <typeparam name="TEnum">Enum type.</typeparam>
		/// <returns>Enum.</returns>
		[Pure]
		[ContractAnnotation("enumString:null => halt")]
		public static TEnum ToEnum<TEnum>(
			this string? enumString,
			params (string OldValue, string Replacement)[]? replacements)
			where TEnum : struct
		{
			enumString.Validate();

			if (replacements is not null)
			{
				foreach (var (oldValue, replacement) in replacements)
				{
					enumString = enumString!.Replace(oldValue, replacement);
				}
			}

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
													   int.Parse(enumString!),
													   enumType);
			}

			return enumResult;
		}

		/// <summary>
		/// Parses <paramref name="uriString">string</paramref> to URI.
		/// </summary>
		/// <param name="uriString">URI string.</param>
		/// <returns>URI.</returns>
		[NotNull, Pure]
		[ContractAnnotation("null => halt")]
		public static Uri ToUri(this string? uriString)
		{
			uriString.ValidateUri();

			return new Uri(uriString!, UriKind.Absolute);
		}

		/// <summary>
		/// Parses <paramref name="emailString">string</paramref> to E-Mail.
		/// </summary>
		/// <param name="emailString">E-Mail string.</param>
		/// <returns>E-Mail.</returns>
		[NotNull, Pure]
		[ContractAnnotation("null => halt")]
		public static MailAddress ToEmail(this string? emailString)
		{
			return new(emailString!);
		}

		/// <summary>
		/// Converts <paramref name="str">string</paramref> to camel case string.
		/// </summary>
		/// <param name="str">The string to convert.</param>
		/// <returns>Camel case string.</returns>
		[NotNull, Pure]
		[ContractAnnotation("null => halt")]
		public static string ToCamelCase(this string? str)
		{
			if (str is null)
			{
				throw new ArgumentNullException(nameof(str), "Can't convert null string to camel case.");
			}

			var result = UnderscoreRegex.Replace(str, x => x.Groups["char"].Value.ToUpper()).Trim(SnakeCaseSeparator);

			return result.Length switch
			{
				0 => result,
				1 => result.ToLower(),
				_ => char.ToLower(result[0]) + result.Substring(1)
			};
		}

		/// <summary>
		/// Converts <paramref name="str">string</paramref> to snake case string.
		/// </summary>
		/// <param name="str">The string to convert.</param>
		/// <returns>Snake case string.</returns>
		[NotNull, Pure]
		[ContractAnnotation("null => halt")]
		public static string ToSnakeCase(this string? str)
		{
			if (str is null)
			{
				throw new ArgumentNullException(nameof(str), "Can't convert null string to snake case.");
			}

			var result = CapitalLetterRegex.Replace(str, x => $"{SnakeCaseSeparator}{x.Value.ToLower()}")
										   .Replace($"{SnakeCaseSeparator}{SnakeCaseSeparator}", SnakeCaseSeparator.ToString());

			if (!str.StartsWith(SnakeCaseSeparator.ToString()))
			{
				result = result.TrimStart(SnakeCaseSeparator);
			}

			return result;
		}
	}
}
