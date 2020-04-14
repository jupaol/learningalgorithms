using System.Linq;
using Core.Domain.LinkedLists;
using Core.Domain.LinkedLists.Sort;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.LinkedLists.Sort
{
	[TestClass]
	public class MergeSortingTests
	{
		[TestClass]
		public class TheSortUsingMergeMethod
		{
			[TestMethod]
			public void It_should_sort_using_merge()
			{
				int[] source;
				var sut = new SingleLinkedListCollection<int>();
				SingleLinkedListNode<int> res;

				source = new[] { 5, 9, 7, 4, 1, 9, 0 };
				sut.Clear();
				sut.AddManyAtEnd(source);
				res = sut.SortUsingMerge();
				sut.ToArray(res).Should().ContainInOrder(source.OrderBy(x => x));
			}
		}
	}
}
