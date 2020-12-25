using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace teh13th.String.Extensions.Tests
{
	[TestClass]
	public sealed class SplitExtensionsTests : TestBase
	{
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
			const string? str = null;
			str.SplitBy(';').Should().BeEmpty("null string should be splitted into empty array");
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void SplitBy_ReturnEmptyArray_IfStringIsNullAndCountSet()
		{
			const string? str = null;
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
	}
}