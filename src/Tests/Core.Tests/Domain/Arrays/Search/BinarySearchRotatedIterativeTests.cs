﻿using AutoFixture;
using AutoFixture.AutoMoq;
using Core.Domain;
using Core.Domain.Arrays.Search;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Arrays.Search
{
	[TestClass]
	public class BinarySearchRotatedIterativeTests
	{
		[TestClass]
		public class TheSearchMethod
		{
			[TestMethod]
			public void It_should_search_a_value_in_a_right_rotated_array_using_binary_search()
			{
				var fixture = new Fixture().Customize(new AutoMoqCustomization());
				var sut = fixture.Create<BinarySearchRotatedIterative>();
				int res;
				var source = new[] { 69, 80, 100, 1, 2, 4, 7, 8, 12, 15, 19, 24, 50 };

				for (int i = 0; i < source.Length; i++)
				{
					res = sut.Search(source, source[i], 3, Direction.Right);
					res.Should().Be(i);
				}

				res = sut.Search(source, -4, 3, Direction.Right);
				res.Should().Be(-1);

				res = sut.Search(source, 400, 3, Direction.Right);
				res.Should().Be(-1);

				res = sut.Search(source, 6, 3, Direction.Right);
				res.Should().Be(-1);
			}

			[TestMethod]
			public void It_should_search_a_value_in_a_left_rotated_array_using_binary_search()
			{
				var fixture = new Fixture().Customize(new AutoMoqCustomization());
				var sut = fixture.Create<BinarySearchRotatedIterative>();
				int res;
				var source = new[] { 7, 8, 12, 15, 19, 24, 50, 69, 80, 100, 1, 2, 4 };

				for (int i = 0; i < source.Length; i++)
				{
					res = sut.Search(source, source[i], 3, Direction.Left);
					res.Should().Be(i);
				}

				res = sut.Search(source, -4, 3, Direction.Left);
				res.Should().Be(-1);

				res = sut.Search(source, 400, 3, Direction.Left);
				res.Should().Be(-1);

				res = sut.Search(source, 6, 3, Direction.Left);
				res.Should().Be(-1);
			}
		}
	}
}
