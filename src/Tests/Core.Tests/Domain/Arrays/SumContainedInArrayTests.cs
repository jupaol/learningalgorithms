using Core.Domain.Arrays;
using Core.Domain.Extensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Arrays
{
	[TestClass]
	public class SumContainedInArrayTests
	{
		[TestClass]
		public class TheIsSumContainedMethod
		{
			[TestMethod]
			public void It_should_indicate_if_two_elements_of_an_array_produce_the_expected_sum()
			{
				var source = new[] { 5, 8, 3, 9, 7, 2, 0, 8 };
				var sut = source.AsLearningCollection();

				bool res;

				res = sut.IsSumContained(10);
				res.Should().BeTrue();

				res = sut.IsSumContained(100);
				res.Should().BeFalse();
			}
		}

		[TestClass]
		public class TheIsSumContainedInSortedCollectionMethod
		{
			[TestMethod]
			public void It_should_indicate_if_two_elements_of_a_sorted_array_produce_the_expected_sum()
			{
				var source = new[] { 1, 3, 4, 5, 7, 14, 15 };
				var sut = source.AsLearningCollection();

				bool res;

				res = sut.IsSumContainedInSortedCollection(11);
				res.Should().BeTrue();

				res = sut.IsSumContainedInSortedCollection(100);
				res.Should().BeFalse();
			}
		}
	}
}
