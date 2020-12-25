using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace teh13th.String.Extensions.Tests
{
	[TestClass]
	public sealed class EqualityExtensionsTests : TestBase
	{
		[TestMethod, Timeout(DefaultTimeout)]
		public void EqualsI_True_IfDifferentCase()
		{
			const string str1 = "Aaaaa";
			const string str2 = "aAaAa";
			str1.EqualsI(str2).Should().BeTrue($"strings with different case ('{str1}' and '{str2}') should be considered equal");
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void EqualsI_True_IfSameCase()
		{
			const string str1 = "Aaaaa";
			const string str2 = "Aaaaa";
			str1.EqualsI(str2).Should().BeTrue($"strings with same case ('{str1}' and '{str2}') should be considered equal");
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void EqualsI_False_IfDifferentStrings()
		{
			const string str1 = "Aaaaa";
			const string str2 = "BBBBB";
			str1.EqualsI(str2).Should().BeFalse($"strings ('{str1}' and '{str2}') are different");
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void EqualsOrI_True_IfDifferentCase()
		{
			const string str = "Aaaaa";
			var array = new[] { "aaaaA", "bbbb" };
			str.EqualsOrI(array).Should().BeTrue($"{nameof(array)} [{string.Join(", ", array)}] contains a string that equals to {nameof(str)} '{str}', but has different case");
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void EqualsOrI_True_IfSameCase()
		{
			const string str = "Aaaaa";
			var array = new[] { "aaaaA", "bbbb" };
			str.EqualsOrI(array).Should().BeTrue($"{nameof(array)} [{string.Join(", ", array)}] contains a string that equals to {nameof(str)} '{str}' with the same case");
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void EqualsOrI_False_IfArrayDoesNotContainString()
		{
			const string str = "Aaaaa";
			var array = new[] { "qqq", "bbbb" };
			str.EqualsOrI(array).Should().BeFalse($"{nameof(array)} [{string.Join(", ", array)}] doesn't contain a string that equals to {nameof(str)} '{str}'");
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void EqualsOrI_False_IfNullArray()
		{
			const string str = "Aaaaa";
			str.EqualsOrI(null).Should().BeFalse("array of strings is null");
		}
	}
}
