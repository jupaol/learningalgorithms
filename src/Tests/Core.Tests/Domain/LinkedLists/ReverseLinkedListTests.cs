using System.Linq;
using Core.Domain.LinkedLists;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.LinkedLists
{
	[TestClass]
	public class ReverseLinkedListTests
	{
		[TestClass]
		public class TheReverseMethod
		{
			[TestMethod]
			public void It_should_reverse_the_linked_list()
			{
				var source = new[] { 1, 2, 3, 4, 5, 6 };
				var expected = source.Reverse();
				var sut = new SingleLinkedListCollection<int>();

				sut.AddManyAtEnd(source);
				sut.ToArray().Should().ContainInOrder(source);
				sut.Reverse();
				sut.ToArray().Should().ContainInOrder(expected);

				sut.Clear();
				sut.Reverse();
				sut.ToArray().Should().BeEmpty();
			}
		}

		[TestClass]
		public class TheReverseRecursiveMethod
		{
			[TestMethod]
			public void It_should_reverse_the_linked_list()
			{
				var source = new[] { 1, 2, 3, 4, 5, 6 };
				var expected = source.Reverse();
				var sut = new SingleLinkedListCollection<int>();

				sut.AddManyAtEnd(source);
				sut.ToArray().Should().ContainInOrder(source);
				sut.ReverseRecursive();
				sut.ToArray().Should().ContainInOrder(expected);

				sut.Clear();
				sut.ReverseRecursive();
				sut.ToArray().Should().BeEmpty();
			}
		}

		[TestClass]
		public class TheReverseEvenNodesMethod
		{
			[TestMethod]
			public void It_should_reverse_even_nodes()
			{
				var sut = new SingleLinkedListCollection<int>();
				int[] source;
				SingleLinkedListNode<int> res;

				source = new[] { 1, 2, 3, 4, 5 };
				sut.Clear();
				sut.AddManyAtEnd(source);
				res = sut.ReverseEvenNodes();
				sut.ToArray(res).Should().ContainInOrder(1, 4, 3, 2, 5);

				source = new[] { 1, 2, 3, 4 };
				sut.Clear();
				sut.AddManyAtEnd(source);
				res = sut.ReverseEvenNodes();
				sut.ToArray(res).Should().ContainInOrder(1, 4, 3, 2);

				source = new[] { 1, 2 };
				sut.Clear();
				sut.AddManyAtEnd(source);
				res = sut.ReverseEvenNodes();
				sut.ToArray(res).Should().ContainInOrder(1, 2);

				source = new[] { 1 };
				sut.Clear();
				sut.AddManyAtEnd(source);
				res = sut.ReverseEvenNodes();
				sut.ToArray(res).Should().ContainInOrder(1);
			}
		}

		[TestClass]
		public class TheReverseOddsNodesMethod
		{
			[TestMethod]
			public void It_should_reverse_odd_nodes()
			{
				var sut = new SingleLinkedListCollection<int>();
				int[] source;
				SingleLinkedListNode<int> res;

				source = new[] { 1, 2, 3, 4, 5 };
				sut.Clear();
				sut.AddManyAtEnd(source);
				res = sut.ReverseOddNodes();
				sut.ToArray(res).Should().ContainInOrder(5, 2, 3, 4, 1);

				source = new[] { 1, 2, 3, 4 };
				sut.Clear();
				sut.AddManyAtEnd(source);
				res = sut.ReverseOddNodes();
				sut.ToArray(res).Should().ContainInOrder(3, 2, 1, 4);

				source = new[] { 1, 2 };
				sut.Clear();
				sut.AddManyAtEnd(source);
				res = sut.ReverseOddNodes();
				sut.ToArray(res).Should().ContainInOrder(1, 2);

				source = new[] { 1, 2 };
				sut.Clear();
				sut.AddManyAtEnd(source);
				res = sut.ReverseOddNodes();
				sut.ToArray(res).Should().ContainInOrder(1);
			}
		}

		[TestClass]
		public class TheReverseNodesInRangeMethod
		{
			[TestMethod]
			public void It_should_reverse_the_nodes_by_the_specified_range()
			{
				var sut = new SingleLinkedListCollection<int>();
				int[] source;
				SingleLinkedListNode<int> res;

				source = new[] { 1, 2, 3, 4, 5 };
				sut.Clear();
				sut.AddManyAtEnd(source);
				res = sut.ReverseNodesInRange(3);
				sut.ToArray(res).Should().ContainInOrder(3, 2, 1, 5, 4);

				source = new[] { 1, 2, 3, 4, 5 };
				sut.Clear();
				sut.AddManyAtEnd(source);
				res = sut.ReverseNodesInRange(8);
				sut.ToArray(res).Should().ContainInOrder(5, 4, 3, 2, 1);

				source = new[] { 1, 2, 3, 4, 5 };
				sut.Clear();
				sut.AddManyAtEnd(source);
				res = sut.ReverseNodesInRange(5);
				sut.ToArray(res).Should().ContainInOrder(5, 4, 3, 2, 1);

				source = new[] { 1, 2, 3 };
				sut.Clear();
				sut.AddManyAtEnd(source);
				res = sut.ReverseNodesInRange(2);
				sut.ToArray(res).Should().ContainInOrder(2, 1, 3);
			}
		}
	}
}
