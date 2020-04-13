using Core.Domain.LinkedLists;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.LinkedLists
{
	[TestClass]
	public class FindNodesTests
	{
		[TestClass]
		public class TheFindNthNodeFromTailMethod
		{
			[TestMethod]
			public void It_should_find_the_nth_node_from_tail()
			{
				int[] source;
				var sut = new SingleLinkedListCollection<int>();
				SingleLinkedListNode<int> res;

				source = new[] { 3, 54, 2, 0, 8, 1 };
				sut.Clear();
				sut.AddManyAtEnd(source);

				for (int i = source.Length - 1, j = 1; i >= 0; i--, j++)
				{
					res = sut.FindNthNodeFromTail(j);
					res.Item.Should().Be(source[i]);
				}

				res = sut.FindNthNodeFromTail(0);
				res.Should().BeNull();

				res = sut.FindNthNodeFromTail(source.Length + 1);
				res.Should().BeNull();
			}
		}
	}
}
