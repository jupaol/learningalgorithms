using System;
using Core.Domain;
using Core.Domain.Arrays;
using Core.Domain.Extensions;
using Core.Domain.LinkedLists;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Arrays
{
	[TestClass]
	public class MergeWithOverlappingExtensionsTests
	{
		[TestClass]
		public class TheMergeWithOverlappingMethod
		{
			[TestMethod]
			public void It_should_merge_the_overlapped_intervals()
			{
				ILearningCollection<(int, int)> sut;
				(int, int)[] res;
				(int, int)[] source;

				source = new[] { (1, 5), (3, 7), (4, 6), (6, 8) };
				sut = source.AsLearningCollection();
				res = sut.MergeWithOverlapping();
				res.Length.Should().Be(1);
				res.Should().ContainInOrder((1, 8));

				source = new[] { (1, 5) };
				sut = source.AsLearningCollection();
				res = sut.MergeWithOverlapping();
				res.Length.Should().Be(1);
				res.Should().ContainInOrder((1, 5));

				source = new[] { (1, 5), (3, 7), (4, 6), (6, 8), (10, 12) };
				sut = source.AsLearningCollection();
				res = sut.MergeWithOverlapping();
				res.Length.Should().Be(2);
				res.Should().ContainInOrder((1, 8), (10, 12));

				source = new[] { (1, 5), (5, 6) };
				sut = source.AsLearningCollection();
				res = sut.MergeWithOverlapping();
				res.Length.Should().Be(1);
				res.Should().ContainInOrder((1, 6));

				source = new[] { (1, 5), (3, 7), (4, 6), (6, 8), (10, 12), (10, 15) };
				sut = source.AsLearningCollection();
				res = sut.MergeWithOverlapping();
				res.Length.Should().Be(2);
				res.Should().ContainInOrder((1, 8), (10, 15));

				source = new[] { (1, 5), (3, 7), (4, 6), (6, 8), (10, 12), (10, 15), (16, 17) };
				sut = source.AsLearningCollection();
				res = sut.MergeWithOverlapping();
				res.Length.Should().Be(3);
				res.Should().ContainInOrder((1, 8), (10, 15), (16, 17));
			}
		}
	}
}
