using AutoFixture;
using AutoFixture.AutoMoq;
using Core.Domain;
using Core.Domain.Arrays;
using Core.Domain.Arrays.Rotate;
using Core.Domain.Arrays.Search;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Arrays.Search
{
	[TestClass]
	public class BinarySearchRotatedRecursiveTests
	{
		[TestClass]
		public class TheSearchMethod
		{
			[TestMethod]
			public void It_should_search_a_value_in_a_right_rotated_array_using_binary_search()
			{
				var fixture = new Fixture().Customize(new AutoMoqCustomization());
				var sut = fixture.Create<BinarySearchRotatedRecursive>();
				int res;
				var source = new[] { 69, 80, 100, 1, 2, 4, 7, 8, 12, 15, 19, 24, 50 };

				for (int i = 0; i < source.Length; i++)
				{
					res = sut.Search(source, source[i], 3, RotationType.Right);
					res.Should().Be(i);
				}

				res = sut.Search(source, -4, 3, RotationType.Right);
				res.Should().Be(-1);

				res = sut.Search(source, 400, 3, RotationType.Right);
				res.Should().Be(-1);

				res = sut.Search(source, 6, 3, RotationType.Right);
				res.Should().Be(-1);
			}

			[TestMethod]
			public void It_should_search_a_value_in_a_left_rotated_array_using_binary_search()
			{
				var fixture = new Fixture().Customize(new AutoMoqCustomization());
				var sut = fixture.Create<BinarySearchRotatedRecursive>();
				int res;
				var source = new[] { 7, 8, 12, 15, 19, 24, 50, 69, 80, 100, 1, 2, 4 };

				for (int i = 0; i < source.Length; i++)
				{
					res = sut.Search(source, source[i], 3, RotationType.Left);
					res.Should().Be(i);
				}

				res = sut.Search(source, -4, 3, RotationType.Left);
				res.Should().Be(-1);

				res = sut.Search(source, 400, 3, RotationType.Left);
				res.Should().Be(-1);

				res = sut.Search(source, 6, 3, RotationType.Left);
				res.Should().Be(-1);
			}
		}
	}
}
