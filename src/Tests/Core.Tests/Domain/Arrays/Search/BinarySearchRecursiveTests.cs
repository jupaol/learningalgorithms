using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using Core.Domain.Arrays.Search;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Arrays.Search
{
	[TestClass]
	public class BinarySearchRecursiveTests
	{
		[TestMethod]
		public void It_should_search_the_array_using_binary_recursive_algorithm()
		{
			var fixture = new Fixture().Customize(new AutoMoqCustomization());
			var sut = fixture.Create<BinarySearchRecursive>();
			var source = new[] { 1, 2, 4, 7, 8, 12, 15, 19, 24, 50, 69, 80, 100 };
			int res;

			for (int i = 0; i < source.Length; i++)
			{
				res = sut.Search(source, source[i]);

				res.Should().Be(i);
			}

			res = sut.Search(source, 1000);
			res.Should().Be(-1);

			res = sut.Search(source, -111);
			res.Should().Be(-1);

			res = sut.Search(Array.Empty<int>(), 5);
			res.Should().Be(-1);
		}
	}
}
