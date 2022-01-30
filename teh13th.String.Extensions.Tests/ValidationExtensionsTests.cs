using System.Net.Mail;
using System.Reflection;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace teh13th.String.Extensions.Tests
{
	[TestClass]
	public sealed class ValidationExtensionsTests : TestBase
	{
		[TestMethod, Timeout(DefaultTimeout)]
		public void Validate_Success_WhenValidStringGiven()
		{
			"test".Validate().Should().Be("test");
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void Validate_ThrowsException_WhenInvalidStringGiven1()
		{
			Action act = () => ((string?)null).Validate("var");
			act.Should().ThrowExactly<ArgumentNullException>();
		}

		[DataTestMethod, Timeout(DefaultTimeout)]
		[DataRow("")]
		[DataRow("  ")]
		public void Validate_ThrowsException_WhenInvalidStringGiven2(string str)
		{
			Action act = () => str.Validate();
			act.Should().ThrowExactly<ArgumentException>();
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void ValidateFilePath_Success_WhenValidStringGiven()
		{
			Assembly.GetExecutingAssembly().Location.ValidateFilePath();
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void ValidateFilePath_ThrowsException_WhenInvalidStringGiven()
		{
			Func<string> act = "test".ValidateFilePath;
			act.Should().ThrowExactly<FileNotFoundException>();
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void ValidateDirectoryPath_Success_WhenValidStringGiven()
		{
			Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).ValidateDirectoryPath();
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void ValidateDirectoryPath_ThrowsException_WhenInvalidStringGiven()
		{
			Func<string> act = "test".ValidateDirectoryPath;
			act.Should().ThrowExactly<DirectoryNotFoundException>();
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void ValidateUri_Correct_WhenValidUriGiven()
		{
			"http://ya.ru".ValidateUri().Should().NotBeNull();
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void ValidateUri_ThrowsException_WhenInvalidUriGiven()
		{
			Action act = () => "as".ValidateUri();

			act.Should().ThrowExactly<FormatException>();
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void ValidateEmail_Success_WhenValidStringGiven()
		{
			"a@a.com".ValidateEmail().Should().Be(new MailAddress("a@a.com"));
		}

		[DataTestMethod, Timeout(DefaultTimeout)]
		[DataRow("ab"), DataRow("ab@"), DataRow("@c.d"), DataRow("@")]
		public void ValidateEmail_ThrowsException_WhenInvalidStringGiven(string email)
		{
			Action act = () => _ = email.ValidateEmail();
			act.Should().ThrowExactly<FormatException>();
		}
	}
}