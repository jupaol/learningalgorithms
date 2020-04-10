using AutoFixture;
using AutoFixture.AutoMoq;
using Core.Domain.Arrays;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Arrays
{
	[TestClass]
	public class CommonNumberInArraysTests
	{
		[TestClass]
		public class TheFindMinimumMethod
		{
			[TestMethod]
			public void It_should_find_the_minimum_common_numbers_in_three_arrays()
			{
				var fixture = new Fixture().Customize(new AutoMoqCustomization());
				var sut = fixture.Create<CommonNumberInArrays>();
				var source1 = new[] { 6, 7, 10, 25, 30, 63, 64 };
				var source2 = new[] { 1, 4, 5, 6, 7, 8, 50 };
				var source3 = new[] { 1, 6, 10, 14 };
				int res;

				res = sut.FindMinimum(source1, source2, source3, -1);
				res.Should().Be(6);

				source1 = new[] { 2, 7, 10, 25, 30, 63, 64 };
				res = sut.FindMinimum(source1, source2, source3, -1);
				res.Should().Be(-1);
			}
		}

		[TestClass]
		public class TheFindMaximumMethod
		{
			[TestMethod]
			public void It_should_find_the_maximum_common_numbers_in_three_arrays()
			{
				var fixture = new Fixture().Customize(new AutoMoqCustomization());
				var sut = fixture.Create<CommonNumberInArrays>();
				var source1 = new[] { 6, 7, 10, 25, 30, 63, 64 };
				var source2 = new[] { 1, 4, 5, 6, 7, 8, 10, 50 };
				var source3 = new[] { 1, 6, 10, 14 };
				int res;

				res = sut.FindMaximum(source1, source2, source3, -1);
				res.Should().Be(10);

				source1 = new[] { 2, 7, 9, 25, 30, 63, 64 };
				res = sut.FindMaximum(source1, source2, source3, -1);
				res.Should().Be(-1);
			}
		}
	}
}
