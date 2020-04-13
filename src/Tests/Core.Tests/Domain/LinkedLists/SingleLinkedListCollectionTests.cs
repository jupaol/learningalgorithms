using Core.Domain.LinkedLists;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.LinkedLists
{
	[TestClass]
	public class SingleLinkedListCollectionTests
	{
		[TestClass]
		public class TheGetAtIndexMethod
		{
			[TestMethod]
			public void It_should_get_the_node_at_the_specified_index()
			{
				var sut = new SingleLinkedListCollection<int>();
				int[] source;
				SingleLinkedListNode<int> res;

				source = new[] { 3, 6, 1, 3, 8 };
				sut.Clear();
				sut.AddManyAtEnd(source);

				for (int i = 0; i < source.Length; i++)
				{
					res = sut.GetAtIndex(i);
					res.Item.Should().Be(source[i]);
				}

				res = sut.GetAtIndex(source.Length);
				res.Should().Be(null);
			}
		}

		[TestClass]
		public class TheGetAtIndexFromTailMethod
		{
			[TestMethod]
			public void It_should_get_the_node_at_the_specified_index()
			{
				var sut = new SingleLinkedListCollection<int>();
				int[] source;
				SingleLinkedListNode<int> res;

				source = new[] { 3, 6, 1, 3, 8 };
				sut.Clear();
				sut.AddManyAtEnd(source);

				for (int i = 0, j = source.Length - 1; i < source.Length; i++, j--)
				{
					res = sut.GetAtIndexFromTail(i);
					res.Item.Should().Be(source[j]);
				}

				res = sut.GetAtIndexFromTail(source.Length);
				res.Should().Be(null);
			}
		}
	}
}
