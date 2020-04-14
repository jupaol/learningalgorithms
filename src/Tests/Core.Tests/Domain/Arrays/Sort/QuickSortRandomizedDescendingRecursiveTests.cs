using System.Linq;
using AutoFixture;
using AutoFixture.AutoMoq;
using Core.Domain;
using Core.Domain.Arrays.Sort;
using Core.Domain.Extensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Arrays.Sort
{
	[TestClass]
	public class QuickSortRandomizedDescendingRecursiveTests
	{
		[TestClass]
		public class TheSortUsingQuickSortRandomizedDescendingRecursiveMethod
		{
			[TestMethod]
			public void It_should_sort_an_array_using_randomized_quick_sort()
			{
				ILearningCollection<int> res;
				int[] source;
				ILearningCollection<int> sut;

				source = new[] { 5, 3, 9, 2, 0, -3, 5 };
				sut = source.AsLearningCollection();
				res = sut.SortUsingQuickSortRandomizedDescendingRecursive();
				res.Should().ContainInOrder(source.OrderByDescending(x => x));

				source = new[] { -3, 0, 2, 3, 5, 5, 9 };
				sut = source.AsLearningCollection();
				res = sut.SortUsingQuickSortRandomizedDescendingRecursive();
				res.Should().ContainInOrder(source.OrderByDescending(x => x));
			}
		}
	}
}
