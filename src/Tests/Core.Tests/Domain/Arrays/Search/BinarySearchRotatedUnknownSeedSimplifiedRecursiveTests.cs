using Core.Domain.Arrays.Search;
using Core.Domain.Extensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Arrays.Search
{
	[TestClass]
	public class BinarySearchRotatedUnknownSeedSimplifiedRecursiveTests
	{
		[TestClass]
		public class TheSearchRotatedSimplifiedRecursiveMethod
		{
			[TestMethod]
			public void It_should_search_a_value_in_a_right_rotated_array_using_binary_search()
			{
				int res;
				var source = new[] { 69, 80, 100, 1, 2, 4, 7, 8, 12, 15, 19, 24, 50 };
				var sut = source.AsLearningCollection();

				for (int i = 0; i < source.Length; i++)
				{
					res = sut.SearchRotatedSimplifiedRecursive(source[i]);
					res.Should().Be(i);
				}

				res = sut.SearchRotatedSimplifiedRecursive(-4);
				res.Should().Be(-1);

				res = sut.SearchRotatedSimplifiedRecursive(400);
				res.Should().Be(-1);

				res = sut.SearchRotatedSimplifiedRecursive(6);
				res.Should().Be(-1);
			}

			[TestMethod]
			public void It_should_search_a_value_in_a_right_rotated_array_using_binary_search_with_duplicates()
			{
				int res;
				var source = new[]
				{
					69, 80, 100, 100, 100, 100, 100, 1, 2, 4, 7, 7, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 12, 15, 19,
					24, 50, 50
				};
				var sut = source.AsLearningCollection();

				for (int i = 0; i < source.Length; i++)
				{
					res = sut.SearchRotatedSimplifiedRecursive(source[i]);
					source[res].Should().Be(source[i]);
				}

				res = sut.SearchRotatedSimplifiedRecursive(-4);
				res.Should().Be(-1);

				res = sut.SearchRotatedSimplifiedRecursive(400);
				res.Should().Be(-1);

				res = sut.SearchRotatedSimplifiedRecursive(6);
				res.Should().Be(-1);
			}
		}
	}
}
