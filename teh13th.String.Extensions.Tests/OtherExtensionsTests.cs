using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace teh13th.String.Extensions.Tests
{
	[TestClass]
	public sealed class OtherExtensionsTests : TestBase
	{
		[TestMethod, Timeout(DefaultTimeout)]
		public void ValidateNotNull_Correct_WhenNotNullGiven()
		{
			var o = new object();

			o.ValidateNotNull().Should().Be(o);
		}

		[TestMethod, Timeout(DefaultTimeout)]
		public void ValidateNotNull_ThrowsException_WhenNullGiven()
		{
			object? o = null;

			Action act = () => o.ValidateNotNull(nameof(o));

			act.Should().ThrowExactly<ArgumentNullException>();
		}

		[DataTestMethod, Timeout(DefaultTimeout)]
		[DataRow(int.MaxValue), DataRow(12), DataRow(1)]
		public void ValidatePosititve_Correct_WhenPositiveNumberGiven(long number)
		{
			Action act = () => number.ValidatePosititve();

			act.Should().NotThrow();
		}

		[DataTestMethod, Timeout(DefaultTimeout)]
		[DataRow(int.MinValue), DataRow(-12), DataRow(0)]
		public void ValidatePosititve_ThrowsException_WhenNotPositiveNumberGiven(long number)
		{
			Action act = () => number.ValidatePosititve(nameof(number));

			act.Should().ThrowExactly<ArgumentOutOfRangeException>();
		}

		[DataTestMethod, Timeout(DefaultTimeout)]
		[DataRow(int.MaxValue), DataRow(12), DataRow(0)]
		public void ValidateNonNegative_Correct_WhenNonNegativeNumberGiven(long number)
		{
			Action act = () => number.ValidateNonNegative();

			act.Should().NotThrow();
		}

		[DataTestMethod, Timeout(DefaultTimeout)]
		[DataRow(int.MinValue), DataRow(-12), DataRow(-1)]
		public void ValidateNonNegative_ThrowsException_WhenNegativeNumberGiven(long number)
		{
			Action act = () => number.ValidateNonNegative(nameof(number));

			act.Should().ThrowExactly<ArgumentOutOfRangeException>();
		}

		[DataTestMethod, Timeout(DefaultTimeout)]
		[DataRow(int.MaxValue), DataRow(12), DataRow(1)]
		public void ValidatePosititve_Correct_WhenPositiveTimeSpanGiven(long number)
		{
			Action act = () => TimeSpan.FromSeconds(number).ValidatePosititve();

			act.Should().NotThrow();
		}

		[DataTestMethod, Timeout(DefaultTimeout)]
		[DataRow(int.MinValue), DataRow(-12), DataRow(0)]
		public void ValidatePosititve_ThrowsException_WhenNotPositiveTimeSpanGiven(long number)
		{
			Action act = () => TimeSpan.FromSeconds(number).ValidatePosititve(nameof(number));

			act.Should().ThrowExactly<ArgumentOutOfRangeException>();
		}

		[DataTestMethod, Timeout(DefaultTimeout)]
		[DataRow(int.MaxValue), DataRow(12), DataRow(0)]
		public void ValidateNonNegative_Correct_WhenNonNegativeTimeSpanGiven(long number)
		{
			Action act = () => TimeSpan.FromSeconds(number).ValidateNonNegative();

			act.Should().NotThrow();
		}

		[DataTestMethod, Timeout(DefaultTimeout)]
		[DataRow(int.MinValue), DataRow(-12), DataRow(-1)]
		public void ValidateNonNegative_ThrowsException_WhenNegativeTimeSpanGiven(long number)
		{
			Action act = () => TimeSpan.FromSeconds(number).ValidateNonNegative(nameof(number));

			act.Should().ThrowExactly<ArgumentOutOfRangeException>();
		}
	}
}
