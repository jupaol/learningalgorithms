using AutoFixture;
using AutoFixture.AutoMoq;
using Core.Domain;
using Core.Domain.Arrays.Search;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Arrays.Search
{
	[TestClass]
	public class BinarySearchIndexesSimplifiedTests
	{
		[TestClass]
		public class TheSearchMethod
		{
			[TestMethod]
			public void It_should_find_the_minimum_index_with_duplicates_using_binary_search()
			{
				var fixture = new Fixture().Customize(new AutoMoqCustomization());
				var sut = fixture.Create<BinarySearchIndexesSimplified>();
				var source =
					new[] { 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 6, 6, 6, 6, 6, 6 };
				int res;

				res = sut.Search(source, 1, OccurrenceType.First);
				res.Should().Be(0);

				res = sut.Search(source, 2, OccurrenceType.First);
				res.Should().Be(3);

				res = sut.Search(source, 3, OccurrenceType.First);
				res.Should().Be(8);

				res = sut.Search(source, 4, OccurrenceType.First);
				res.Should().Be(11);

				res = sut.Search(source, 5, OccurrenceType.First);
				res.Should().Be(15);

				res = sut.Search(source, 6, OccurrenceType.First);
				res.Should().Be(18);

				res = sut.Search(source, -8, OccurrenceType.First);
				res.Should().Be(-1);

				res = sut.Search(source, 100, OccurrenceType.First);
				res.Should().Be(-1);
			}

			[TestMethod]
			public void It_should_find_the_maximum_index_with_duplicates_using_binary_search()
			{
				var fixture = new Fixture().Customize(new AutoMoqCustomization());
				var sut = fixture.Create<BinarySearchIndexesSimplified>();
				var source =
					new[] { 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 6, 6, 6, 6, 6, 6 };
				int res;

				res = sut.Search(source, 1, OccurrenceType.Last);
				res.Should().Be(2);

				res = sut.Search(source, 2, OccurrenceType.Last);
				res.Should().Be(7);

				res = sut.Search(source, 3, OccurrenceType.Last);
				res.Should().Be(10);

				res = sut.Search(source, 4, OccurrenceType.Last);
				res.Should().Be(14);

				res = sut.Search(source, 5, OccurrenceType.Last);
				res.Should().Be(17);

				res = sut.Search(source, 6, OccurrenceType.Last);
				res.Should().Be(23);

				res = sut.Search(source, -8, OccurrenceType.Last);
				res.Should().Be(-1);

				res = sut.Search(source, 100, OccurrenceType.Last);
				res.Should().Be(-1);
			}
		}
	}
}
