using AutoFixture;
using AutoFixture.AutoMoq;
using Core.Domain.Arrays.Search;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Arrays.Search
{
	[TestClass]
	public class BinarySearchIndexesTests
	{
		[TestClass]
		public class TheFindMinimumIndexMethod
		{
			[TestMethod]
			public void It_should_find_the_minimum_index_with_duplicates_using_binary_search()
			{
				var fixture = new Fixture().Customize(new AutoMoqCustomization());
				var sut = fixture.Create<BinarySearchIndexes>();
				var source =
					new[] { 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 6, 6, 6, 6, 6, 6 };
				int res;

				res = sut.FindMinimumIndex(source, 1);
				res.Should().Be(0);

				res = sut.FindMinimumIndex(source, 2);
				res.Should().Be(3);

				res = sut.FindMinimumIndex(source, 3);
				res.Should().Be(8);

				res = sut.FindMinimumIndex(source, 4);
				res.Should().Be(11);

				res = sut.FindMinimumIndex(source, 5);
				res.Should().Be(15);

				res = sut.FindMinimumIndex(source, 6);
				res.Should().Be(18);

				res = sut.FindMinimumIndex(source, -8);
				res.Should().Be(-1);

				res = sut.FindMinimumIndex(source, 100);
				res.Should().Be(-1);
			}
		}

		[TestClass]
		public class TheFindMaximumIndexMethod
		{
			[TestMethod]
			public void It_should_find_the_maximum_index_with_duplicates_using_binary_search()
			{
				var fixture = new Fixture().Customize(new AutoMoqCustomization());
				var sut = fixture.Create<BinarySearchIndexes>();
				var source =
					new[] { 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 6, 6, 6, 6, 6, 6 };
				int res;

				res = sut.FindMaximumIndex(source, 1);
				res.Should().Be(2);

				res = sut.FindMaximumIndex(source, 2);
				res.Should().Be(7);

				res = sut.FindMaximumIndex(source, 3);
				res.Should().Be(10);

				res = sut.FindMaximumIndex(source, 4);
				res.Should().Be(14);

				res = sut.FindMaximumIndex(source, 5);
				res.Should().Be(17);

				res = sut.FindMaximumIndex(source, 6);
				res.Should().Be(23);

				res = sut.FindMaximumIndex(source, -8);
				res.Should().Be(-1);

				res = sut.FindMaximumIndex(source, 100);
				res.Should().Be(-1);
			}
		}
	}
}
