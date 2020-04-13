using Core.Domain.LinkedLists;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.LinkedLists
{
	[TestClass]
	public class MergeListsTests
	{
		[TestClass]
		public class TheMergeMethod
		{
			[TestMethod]
			public void It_should_merge_two_lists()
			{
				var l1 = new SingleLinkedListCollection<int>();
				var l2 = new SingleLinkedListCollection<int>();
				SingleLinkedListNode<int> res;
				int[] source1;
				int[] source2;

				source1 = new[] { 4, 8, 9 };
				l1.Clear();
				l1.AddManyAtEnd(source1);

				source2 = new[] { 1, 2, 8, 9, 45, 300 };
				l2.Clear();
				l2.AddManyAtEnd(source2);

				res = l1.Merge(l2);
				l1.ToArray(res).Should().ContainInOrder(1, 2, 4, 8, 8, 9, 9, 45, 300);
			}
		}
	}
}
