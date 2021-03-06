﻿using System;
using System.Diagnostics;
using System.IO;
using System.Net.Mail;
using JetBrains.Annotations;

namespace teh13th.String.Extensions
{
	/// <summary>
	/// Useful extensions for <see cref="string"/> validation.
	/// </summary>
	[PublicAPI]
	public static class ValidationExtensions
	{
		/// <summary>
		/// Validates that <paramref name="str">string</paramref> is not null or empty or whitespace.
		/// </summary>
		/// <param name="str">String to validate.</param>
		/// <param name="variableName">Name of tested variable.</param>
		/// <returns>Original string.</returns>
		[NotNull, DebuggerStepThrough, AssertionMethod]
		[ContractAnnotation("str:null => halt")]
		public static string Validate(
			[AssertionCondition(AssertionConditionType.IS_NOT_NULL)] this string? str,
			string? variableName = null)
		{
			variableName ??= nameof(str);

			if (str is null)
			{
				throw new ArgumentNullException(variableName);
			}

			if (string.IsNullOrWhiteSpace(str))
			{
				throw new ArgumentException("Value cannot be empty or whitespace.", variableName);
			}

			return str;
		}

		/// <summary>
		/// Validates <paramref name="filePath">file path</paramref> string.
		/// </summary>
		/// <param name="filePath">File path string.</param>
		/// <returns>Original file path.</returns>
		[NotNull, DebuggerStepThrough, AssertionMethod]
		[ContractAnnotation("null => halt")]
		public static string ValidateFilePath([AssertionCondition(AssertionConditionType.IS_NOT_NULL)] this string? filePath)
		{
			filePath.Validate();

			if (!File.Exists(filePath))
			{
				throw new FileNotFoundException("Failed to find file.", filePath);
			}

			return filePath!;
		}

		/// <summary>
		/// Validates <paramref name="directoryPath">directory path</paramref> string.
		/// </summary>
		/// <param name="directoryPath">Directory path string.</param>
		/// <returns>Original directory path.</returns>
		[NotNull, DebuggerStepThrough, AssertionMethod]
		[ContractAnnotation("null => halt")]
		public static string ValidateDirectoryPath(
			[AssertionCondition(AssertionConditionType.IS_NOT_NULL)] this string? directoryPath)
		{
			directoryPath.Validate();

			if (!Directory.Exists(directoryPath))
			{
				throw new DirectoryNotFoundException($"Failed to find directory '{directoryPath}'.");
			}

			return directoryPath!;
		}

		/// <summary>
		/// Validates that <paramref name="uriString">string</paramref> is valid URI.
		/// </summary>
		/// <param name="uriString">URI string.</param>
		/// <returns>URI.</returns>
		[NotNull, DebuggerStepThrough, AssertionMethod]
		[ContractAnnotation("null => halt")]
		public static Uri ValidateUri([AssertionCondition(AssertionConditionType.IS_NOT_NULL)] this string? uriString)
		{
			uriString.Validate();

			if (!Uri.TryCreate(uriString, UriKind.Absolute, out var uri))
			{
				throw new FormatException($"URI '{uriString}' isn't valid");
			}

			return uri;
		}

		/// <summary>
		/// Validates that <paramref name="emailString">string</paramref> is valid E-Mail.
		/// </summary>
		/// <param name="emailString">E-Mail string.</param>
		/// <returns>E-Mail.</returns>
		[NotNull, DebuggerStepThrough, AssertionMethod]
		[ContractAnnotation("null => halt")]
		public static MailAddress ValidateEmail(
			[AssertionCondition(AssertionConditionType.IS_NOT_NULL)] this string? emailString)
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
}