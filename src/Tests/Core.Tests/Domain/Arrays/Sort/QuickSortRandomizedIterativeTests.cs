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
	public class QuickSortRandomizedIterativeTests
	{
		[TestClass]
		public class TheSortUsingQuickSortRandomizedIterativeMethod
		{
			[TestMethod]
			public void It_should_sort_an_array_using_randomized_quick_sort()
			{
				ILearningCollection<int> sut;
				ILearningCollection<int> res;
				int[] source;

				source = new[] { 5, 3, 9, 2, 0, -3, 5 };
				sut = source.AsLearningCollection();
				res = sut.SortUsingQuickSortRandomizedIterative();
				res.Should().ContainInOrder(source.OrderBy(x => x));

				source = new[] { -3, 0, 2, 3, 5, 5, 9 };
				sut = source.AsLearningCollection();
				res = sut.SortUsingQuickSortRandomizedIterative();
				res.Should().ContainInOrder(source.OrderBy(x => x));
			}
		}
	}
}
