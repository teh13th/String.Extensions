using System;
using System.Diagnostics;
using System.IO;
using System.Net.Mail;

namespace teh13th.String.Extensions;

/// <summary>
/// Useful extensions for <see cref="string"/> validation.
/// </summary>
public static class ValidationExtensions
{
	/// <summary>
	/// Validates that <paramref name="str">string</paramref> is not null or empty or whitespace.
	/// </summary>
	/// <param name="str">String to validate.</param>
	/// <param name="variableName">Name of tested variable.</param>
	/// <returns>Original string.</returns>
	[DebuggerStepThrough]
	public static string Validate(this string? str, string? variableName = null)
	{
		variableName ??= nameof(str);

		if (str is null)
		{
			throw new ArgumentNullException(variableName);
		}

		return string.IsNullOrWhiteSpace(str)
					? throw new ArgumentException("Value cannot be empty or whitespace.", variableName)
					: str;
	}

	/// <summary>
	/// Validates <paramref name="filePath">file path</paramref> string.
	/// </summary>
	/// <param name="filePath">File path string.</param>
	/// <returns>Original file path.</returns>
	[DebuggerStepThrough]
	public static string ValidateFilePath(this string? filePath)
	{
		filePath.Validate();

		return !File.Exists(filePath)
					? throw new FileNotFoundException("Failed to find file.", filePath)
					: filePath!;
	}

	/// <summary>
	/// Validates <paramref name="directoryPath">directory path</paramref> string.
	/// </summary>
	/// <param name="directoryPath">Directory path string.</param>
	/// <returns>Original directory path.</returns>
	[DebuggerStepThrough]
	public static string ValidateDirectoryPath(this string? directoryPath)
	{
		directoryPath.Validate();

		return !Directory.Exists(directoryPath)
					? throw new DirectoryNotFoundException($"Failed to find directory '{directoryPath}'.")
					: directoryPath!;
	}

	/// <summary>
	/// Validates that <paramref name="uriString">string</paramref> is valid URI.
	/// </summary>
	/// <param name="uriString">URI string.</param>
	/// <returns>URI.</returns>
	[DebuggerStepThrough]
	public static Uri ValidateUri(this string? uriString)
	{
		uriString.Validate();

		return !Uri.TryCreate(uriString, UriKind.Absolute, out var uri)
					? throw new FormatException($"URI '{uriString}' isn't valid")
					: uri;
	}

	/// <summary>
	/// Validates that <paramref name="emailString">string</paramref> is valid E-Mail.
	/// </summary>
	/// <param name="emailString">E-Mail string.</param>
	/// <returns>E-Mail.</returns>
	[DebuggerStepThrough]
	public static MailAddress ValidateEmail(this string? emailString)
	{
		emailString.Validate();

		try
		{
			return new MailAddress(emailString!);
		}
		catch (FormatException)
		{
			throw new FormatException($"E-Mail '{emailString}' isn't valid");
		}
	}
}