using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace teh13th.String.Extensions.Tests
{
	[TestClass]
	public sealed class StringExtensionsTests
	{
		private const int DefaultTimeout = 1000;

		public enum TestEnum : byte
		{
			Zero = 0,
			Two = 2
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void SplitBy_Correct_IfNoCountSet()
		{
			const string str = " a;   ;bcd;;eee; ";
			str.SplitBy(';').Should().Equal("a", string.Empty, "bcd", "eee");
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void SplitBy_Correct_IfCountSet()
		{
			const string str = " a;   ;bcd;;eee; ";
			str.SplitBy(';', 3).Should().Equal("a", string.Empty, "bcd;;eee;");
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void SplitBy_ReturnEmptyArray_IfStringIsNullAndNoCountSet()
		{
			const string str = null;
			str.SplitBy(';').Should().BeEmpty("null string should be splitted into empty array");
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void SplitBy_ReturnEmptyArray_IfStringIsNullAndCountSet()
		{
			const string str = null;
			str.SplitBy(';', 3).Should().BeEmpty("null string should be splitted into empty array");
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void SplitByString_Success_WhenValidSeparatorGiven()
		{
			" test  && to st  ".SplitBy("&&").Should().Equal("test", "to st");
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void SplitByString_Success_WhenNullSeparatorGiven()
		{
			" test  && to st  ".SplitBy(null).Should().Equal("test  && to st");
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void SplitByString_Success_WhenValidSeparatorAndCountGiven()
		{
			" test  && to st && three  ".SplitBy("&&", 2).Should().Equal("test", "to st && three");
		}

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

		[TestMethod, Timeout(DefaultTimeout)]
		public void StartsWithI_False_IfNullStr()
		{
			const string str1 = null;
			const string str2 = "Aaaaa";
			str1.StartsWithI(str2).Should().BeFalse("given string is null");
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void StartsWithI_True_IfNullSecondStr()
		{
			const string str1 = "Aaaaa";
			const string str2 = null;
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
			const string str1 = null;
			const string str2 = "Aaaaa";
			str1.EndsWithI(str2).Should().BeFalse("given string is null");
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void EndsWithI_True_IfNullSecondStr()
		{
			const string str1 = "Aaaaa";
			const string str2 = null;
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
			const string str1 = null;
			const string str2 = "Aaaa";
			str1.IndexOfI(str2).Should().Be(-1, "given string is null");
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void IndexOfI_MinusOne_IfNullValue()
		{
			const string str1 = "Aaaa";
			const string str2 = null;
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
			const string str1 = null;
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
			((string[])null).ContainsI(str).Should().BeFalse("array is null");
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void ContainsI_False_IfArrayDoesNotContainString()
		{
			const string str = "AAaBcde";
			var array = new[] { "Qrw", "bbbb", "AQE" };
			array.ContainsI(str).Should().BeFalse($"{nameof(array)} [{string.Join(", ", array)}] doesn't contain {nameof(str)} '{str}'");
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void Validate_Success_WhenValidStringGiven()
		{
			"test".Validate();
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void Validate_ThrowsException_WhenInvalidStringGiven1()
		{
			Action act = ((string)null).Validate;
			act.Should().ThrowExactly<ArgumentNullException>();
		}

		[DataTestMethod, Timeout(DefaultTimeout)]
		[DataRow("")]
		[DataRow("  ")]
		public void Validate_ThrowsException_WhenInvalidStringGiven2(string str)
		{
			Action act = str.Validate;
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
			Action act = "test".ValidateFilePath;
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
			Action act = "test".ValidateDirectoryPath;
			act.Should().ThrowExactly<DirectoryNotFoundException>();
		}

		[DataTestMethod, Timeout(DefaultTimeout)]
		[DataRow("0", TestEnum.Zero)]
		[DataRow("2", TestEnum.Two)]
		[DataRow("000", TestEnum.Zero)]
		[DataRow("002", TestEnum.Two)]
		[DataRow("Zero", TestEnum.Zero)]
		[DataRow("Two", TestEnum.Two)]
		[DataRow("zero", TestEnum.Zero)]
		[DataRow("two", TestEnum.Two)]
		public void ToEnum_Success_WhenValidStringGiven(string str, TestEnum result)
		{
			str.ToEnum<TestEnum>().Should().Be(result);
		}

		[DataTestMethod, Timeout(DefaultTimeout)]
		[DataRow("One")]
		[DataRow("Invalid")]
		public void ToEnum_ThrowsException_WhenInvalidStringGiven1(string str)
		{
			Action act = () => str.ToEnum<TestEnum>();
			act.Should().ThrowExactly<ArgumentOutOfRangeException>();
		}

		[DataTestMethod, Timeout(DefaultTimeout)]
		[DataRow("1")]
		[DataRow("3")]
		public void ToEnum_ThrowsException_WhenInvalidStringGiven2(string str)
		{
			Action act = () => str.ToEnum<TestEnum>();
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
			Action act = () => "Invalid".ToUri();
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
		public void ToCamelCase_Correct_WhenNotNullStringGiven(string original, string result)
		{
			original.ToCamelCase().Should().Be(result);
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void ToCamelCase_ThrowsException_WhenNullStringGiven()
		{
			Action act = () => ((string)null).ToCamelCase();
			act.Should().ThrowExactly<ArgumentNullException>();
		}

		[DataTestMethod, Timeout(DefaultTimeout)]
		[DataRow("", "")]
		[DataRow("  ", "  ")]
		[DataRow("teststring", "teststring")]
		[DataRow("testString", "test_string")]
		[DataRow("TestString", "_test_string")]
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
			Action act = () => ((string)null).ToSnakeCase();
			act.Should().ThrowExactly<ArgumentNullException>();
		}
	}
}