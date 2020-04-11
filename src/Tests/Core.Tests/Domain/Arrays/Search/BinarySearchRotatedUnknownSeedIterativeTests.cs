using AutoFixture;
using AutoFixture.AutoMoq;
using Core.Domain.Arrays.Search;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Arrays.Search
{
	[TestClass]
	public class BinarySearchRotatedUnknownSeedIterativeTests
	{
		[TestClass]
		public class TheSearchMethod
		{
			[TestMethod]
			public void It_should_search_a_value_in_a_right_rotated_array_using_binary_search()
			{
				var fixture = new Fixture().Customize(new AutoMoqCustomization());
				var sut = fixture.Create<BinarySearchRotatedUnknownSeedIterative>();
				int res;
				var source = new[] { 69, 80, 100, 1, 2, 4, 7, 8, 12, 15, 19, 24, 50 };

				for (int i = 0; i < source.Length; i++)
				{
					res = sut.Search(source, source[i]);
					res.Should().Be(i);
				}

				res = sut.Search(source, -4);
				res.Should().Be(-1);

				res = sut.Search(source, 400);
				res.Should().Be(-1);

				res = sut.Search(source, 6);
				res.Should().Be(-1);
			}

			[TestMethod]
			public void It_should_search_a_value_in_a_right_rotated_array_using_binary_search_with_duplicates()
			{
				var fixture = new Fixture().Customize(new AutoMoqCustomization());
				var sut = fixture.Create<BinarySearchRotatedUnknownSeedIterative>();
				int res;
				var source = new[]
				{
					69, 80, 100, 100, 100, 100, 100, 1, 2, 4, 7, 7,
					8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 12, 15, 19, 24, 50, 50
				};

				for (int i = 0; i < source.Length; i++)
				{
					res = sut.Search(source, source[i]);
					source[res].Should().Be(source[i]);
				}

				res = sut.Search(source, -4);
				res.Should().Be(-1);

				res = sut.Search(source, 400);
				res.Should().Be(-1);

				res = sut.Search(source, 6);
				res.Should().Be(-1);
			}
		}
	}
}
