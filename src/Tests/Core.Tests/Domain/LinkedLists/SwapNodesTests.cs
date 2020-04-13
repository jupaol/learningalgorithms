using Core.Domain.LinkedLists;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.LinkedLists
{
	[TestClass]
	public class SwapNodesTests
	{
		[TestClass]
		public class TheSwapNthNodeWithHeadMethod
		{
			[TestMethod]
			public void It_should_swap_head_with_nth_node()
			{
				int[] source;
				var sut = new SingleLinkedListCollection<int>();
				SingleLinkedListNode<int> res;

				source = new[] { 7, 14, 21, 28, 35, 42 };
				sut.Clear();
				sut.AddManyAtEnd(source);
				sut.SwapNthNodeWithHead(4);
				sut.ToArray().Should().ContainInOrder(28, 14, 21, 7, 35, 42);

				source = new[] { 7, 14, 21, 28, 35, 42 };
				sut.Clear();
				sut.AddManyAtEnd(source);
				sut.SwapNthNodeWithHead(3);
				sut.ToArray().Should().ContainInOrder(21, 14, 7, 28, 35, 42);

				source = new[] { 7, 14, 21, 28, 35, 42 };
				sut.Clear();
				sut.AddManyAtEnd(source);
				sut.SwapNthNodeWithHead(5);
				sut.ToArray().Should().ContainInOrder(35, 14, 21, 28, 7, 42);

				source = new[] { 7, 14, 21, 28, 35, 42 };
				sut.Clear();
				sut.AddManyAtEnd(source);
				sut.SwapNthNodeWithHead(1);
				sut.ToArray().Should().ContainInOrder(7, 14, 21, 28, 35, 42);

				source = new[] { 7, 14, 21, 28, 35, 42 };
				sut.Clear();
				sut.AddManyAtEnd(source);
				sut.SwapNthNodeWithHead(7);
				sut.ToArray().Should().ContainInOrder(7, 14, 21, 28, 35, 42);

				source = new[] { 7, 14, 21, 28, 35, 42 };
				sut.Clear();
				sut.AddManyAtEnd(source);
				sut.SwapNthNodeWithHead(2);
				sut.ToArray().Should().ContainInOrder(14, 7, 21, 28, 35, 42);

				source = new[] { 7, 14, 21, 28, 35, 42 };
				sut.Clear();
				sut.AddManyAtEnd(source);
				sut.SwapNthNodeWithHead(6);
				sut.ToArray().Should().ContainInOrder(42, 14, 21, 28, 35, 7);
			}
		}
	}
}
