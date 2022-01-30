using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace teh13th.String.Extensions.Tests
{
	[TestClass]
	public sealed class ContainabilityExtensionsTests : TestBase
	{
		[TestMethod, Timeout(DefaultTimeout)]
		public void StartsWithI_False_IfNullStr()
		{
			const string? str1 = null;
			const string str2 = "Aaaaa";
			str1.StartsWithI(str2).Should().BeFalse("given string is null");
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void StartsWithI_True_IfNullSecondStr()
		{
			const string str1 = "Aaaaa";
			const string? str2 = null;
			str1.StartsWithI(str2).Should().BeTrue("second string is null");
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void StartsWithI_True_IfDifferentCase()
		{
			const string str1 = "AAaBcd";
			const string str2 = "Aaa";
			str1.StartsWithI(str2).Should().BeTrue($"string '{str1}' starts with '{str2}' with different case");
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void StartsWithI_True_IfSameCase()
		{
			const string str1 = "AAaBcd";
			const string str2 = "AAa";
			str1.StartsWithI(str2).Should().BeTrue($"string '{str1}' starts with '{str2}' with same case");
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void StartsWithI_False_IfDifferentStrings()
		{
			const string str1 = "AAaBcd";
			const string str2 = "bcd";
			str1.StartsWithI(str2).Should().BeFalse($"string '{str1}' doesn't start with '{str2}'");
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void EndsWithI_False_IfNullStr()
		{
			const string? str1 = null;
			const string str2 = "Aaaaa";
			str1.EndsWithI(str2).Should().BeFalse("given string is null");
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void EndsWithI_True_IfNullSecondStr()
		{
			const string str1 = "Aaaaa";
			const string? str2 = null;
			str1.EndsWithI(str2).Should().BeTrue("second string is null");
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void EndsWithI_True_IfDifferentCase()
		{
			const string str1 = "AAaBcd";
			const string str2 = "bCD";
			str1.EndsWithI(str2).Should().BeTrue($"string '{str1}' ends with '{str2}' with different case");
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void EndsWithI_True_IfSameCase()
		{
			const string str1 = "AAaBcd";
			const string str2 = "Bcd";
			str1.EndsWithI(str2).Should().BeTrue($"string '{str1}' ends with '{str2}' with same case");
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void EndsWithI_False_IfDifferentStrings()
		{
			const string str1 = "AAaBcd";
			const string str2 = "AAa";
			str1.EndsWithI(str2).Should().BeFalse($"string '{str1}' doesn't end with '{str2}'");
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void IndexOfI_MinusOne_IfNullStr()
		{
			const string? str1 = null;
			const string str2 = "Aaaa";
			str1.IndexOfI(str2).Should().Be(-1, "given string is null");
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void IndexOfI_MinusOne_IfNullValue()
		{
			const string str1 = "Aaaa";
			const string? str2 = null;
			str1.IndexOfI(str2).Should().Be(-1, "given value is null");
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void IndexOfI_Correct_IfDifferentCase()
		{
			const string str1 = "AAaBcd";
			const string str2 = "bCD";
			str1.IndexOfI(str2).Should().Be(3, $"string '{str1}' has a substring '{str2}' with different case");
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void IndexOfI_Correct_IfSameCase()
		{
			const string str1 = "AAaBcd";
			const string str2 = "Bcd";
			str1.IndexOfI(str2).Should().Be(3, $"string '{str1}' has a substring '{str2}' with same case");
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void IndexOfI_Correct_IfDifferentStrings()
		{
			const string str1 = "AAaBcd";
			const string str2 = "Qrw";
			str1.IndexOfI(str2).Should().Be(-1, $"string '{str1}' doesn't have a substring '{str2}'");
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void ContainsI_False_IfNullStr()
		{
			const string? str1 = null;
			const string str2 = "Aaaa";
			str1.ContainsI(str2).Should().BeFalse("given string is null");
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void ContainsI_Correct_IfDifferentCase()
		{
			const string str1 = "AAaBcde";
			const string str2 = "bCD";
			str1.ContainsI(str2).Should().BeTrue($"string '{str1}' has a substring '{str2}' with different case");
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void ContainsI_Correct_IfSameCase()
		{
			const string str1 = "AAaBcde";
			const string str2 = "Bcd";
			str1.ContainsI(str2).Should().BeTrue($"string '{str1}' has a substring '{str2}' with same case");
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void ContainsI_Correct_IfDifferentStrings()
		{
			const string str1 = "AAaBcde";
			const string str2 = "Qrw";
			str1.ContainsI(str2).Should().BeFalse($"string '{str1}' doesn't have a substring '{str2}'");
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void ContainsAnyI_True_IfDifferentCase()
		{
			const string str = "AAaBcde";
			var array = new[] { "bCD", "bbbb", "AQE" };
			str.ContainsAnyI(array).Should().BeTrue($"{nameof(array)} [{string.Join(", ", array)}] contains a string that is a substring of {nameof(str)} '{str}' with different case");
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void ContainsAnyI_True_IfSameCase()
		{
			const string str = "AAaBcde";
			var array = new[] { "Bcd", "bbbb", "AQE" };
			str.ContainsAnyI(array).Should().BeTrue($"{nameof(array)} [{string.Join(", ", array)}] contains a string that is a substring of {nameof(str)} '{str}' with same case");
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void ContainsAnyI_False_IfNullArray()
		{
			const string str = "AAaBcde";
			str.ContainsAnyI(null).Should().BeFalse("array is null");
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void ContainsAnyI_False_IfArrayDoesNotContainString()
		{
			const string str = "AAaBcde";
			var array = new[] { "Qrw", "bbbb", "AQE" };
			str.ContainsAnyI(array).Should().BeFalse($"{nameof(array)} [{string.Join(", ", array)}] doesn't contain a string that is a substring of {nameof(str)} '{str}'");
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void ContainsI_True_IfDifferentCase()
		{
			const string str = "AAaaa";
			var array = new[] { "aaAaa", "bbbb", "AQE" };
			array.ContainsI(str).Should().BeTrue($"{nameof(array)} [{string.Join(", ", array)}] contains a string {nameof(str)} '{str}' with different case");
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void ContainsI_True_IfSameCase()
		{
			const string str = "aaAaa";
			var array = new[] { "aaAaa", "bbbb", "AQE" };
			array.ContainsI(str).Should().BeTrue($"{nameof(array)} [{string.Join(", ", array)}] contains a string {nameof(str)} '{str}' with same case");
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void ContainsI_False_IfNullArray()
		{
			const string str = "AAaBcde";
			((string[]?)null).ContainsI(str).Should().BeFalse("array is null");
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void ContainsI_False_IfArrayDoesNotContainString()
		{
			const string str = "AAaBcde";
			var array = new[] { "Qrw", "bbbb", "AQE" };
			array.ContainsI(str).Should().BeFalse($"{nameof(array)} [{string.Join(", ", array)}] doesn't contain {nameof(str)} '{str}'");
		}
	}
}