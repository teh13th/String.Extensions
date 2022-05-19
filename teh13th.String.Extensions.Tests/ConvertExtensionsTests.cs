using System;
using System.ComponentModel;
using System.Net.Mail;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace teh13th.String.Extensions.Tests
{
	[TestClass]
	public sealed class ConvertExtensionsTests : TestBase
	{
		public enum Test : byte
		{
			Zero = 0,
			Two = 2
		}

		[DataTestMethod, Timeout(DefaultTimeout)]
		[DataRow("0", Test.Zero)]
		[DataRow("2", Test.Two)]
		[DataRow("000", Test.Zero)]
		[DataRow("002", Test.Two)]
		[DataRow("Zero", Test.Zero)]
		[DataRow("Two", Test.Two)]
		[DataRow("zero", Test.Zero)]
		[DataRow("two", Test.Two)]
		[DataRow("ze-ro", Test.Zero)]
		public void ToEnum_Success_WhenValidStringGiven(string str, Test result)
		{
			str.ToEnum<Test>(("-", string.Empty)).Should().Be(result);
		}

		[DataTestMethod, Timeout(DefaultTimeout)]
		[DataRow("One")]
		[DataRow("Invalid")]
		public void ToEnum_ThrowsException_WhenInvalidStringGiven1(string str)
		{
			Action act = () => _ = str.ToEnum<Test>();
			act.Should().ThrowExactly<ArgumentOutOfRangeException>();
		}

		[DataTestMethod, Timeout(DefaultTimeout)]
		[DataRow("1")]
		[DataRow("3")]
		public void ToEnum_ThrowsException_WhenInvalidStringGiven2(string str)
		{
			Action act = () => _ = str.ToEnum<Test>();
			act.Should().ThrowExactly<InvalidEnumArgumentException>();
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void ToUri_Success_WhenValidStringGiven()
		{
			"http://example.com".ToUri().Should().Be(new Uri("http://example.com"));
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void ToUri_ThrowsException_WhenInvalidStringGiven()
		{
			Action act = () => _ = "Invalid".ToUri();
			act.Should().ThrowExactly<FormatException>();
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void ToEmail_Success_WhenValidStringGiven()
		{
			"a@a.com".ToEmail().Should().Be(new MailAddress("a@a.com"));
		}

		[DataTestMethod, Timeout(DefaultTimeout)]
		[DataRow("ab"), DataRow("ab@"), DataRow("@c.d"), DataRow("@")]
		public void ToEmail_ThrowsException_WhenInvalidStringGiven(string email)
		{
			Action act = () => _ = email.ToEmail();
			act.Should().ThrowExactly<FormatException>();
		}

		[DataTestMethod, Timeout(DefaultTimeout)]
		[DataRow("", "")]
		[DataRow("  ", "  ")]
		[DataRow("test", "test")]
		[DataRow("Test", "test")]
		[DataRow("tEst", "tEst")]
		[DataRow("tesT", "tesT")]
		[DataRow("test_String", "testString")]
		[DataRow("test_string", "testString")]
		[DataRow("Test_String", "testString")]
		[DataRow("Test_string", "testString")]
		[DataRow("test_StrinG", "testStrinG")]
		[DataRow("test_strinG", "testStrinG")]
		[DataRow("test__String", "testString")]
		[DataRow("_Test_String", "testString")]
		[DataRow("__Test_String", "testString")]
		[DataRow("_Test_String_", "testString")]
		[DataRow("_Test_String__", "testString")]
		[DataRow("testString", "testString")]
		[DataRow("TestString", "testString")]
		[DataRow("testStrinG", "testStrinG")]
		[DataRow("_t", "t")]
		public void ToCamelCase_Correct_WhenNotNullStringGiven(string original, string result)
		{
			original.ToCamelCase().Should().Be(result);
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void ToCamelCase_ThrowsException_WhenNullStringGiven()
		{
			Action act = () => _ = ((string?)null).ToCamelCase();
			act.Should().ThrowExactly<ArgumentNullException>();
		}

		[DataTestMethod, Timeout(DefaultTimeout)]
		[DataRow("", "")]
		[DataRow("  ", "  ")]
		[DataRow("teststring", "teststring")]
		[DataRow("testString", "test_string")]
		[DataRow("TestString", "test_string")]
		[DataRow("testSString", "test_s_string")]
		[DataRow("test_string", "test_string")]
		[DataRow("test_String", "test_string")]
		[DataRow("testString_a", "test_string_a")]
		[DataRow("_test_string", "_test_string")]
		[DataRow("test_s_string", "test_s_string")]
		[DataRow("test_string_a", "test_string_a")]
		public void ToSnakeCase_Correct_WhenNotNullStringGiven(string original, string result)
		{
			original.ToSnakeCase().Should().Be(result);
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void ToSnakeCase_ThrowsException_WhenNullStringGiven()
		{
			Action act = () => _ = ((string?)null).ToSnakeCase();
			act.Should().ThrowExactly<ArgumentNullException>();
		}
	}
}