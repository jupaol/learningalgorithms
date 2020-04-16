using Core.Domain.LinkedLists;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.LinkedLists
{
	[TestClass]
	public class DeepCloneListTests
	{
		[TestClass]
		public class TheDeepCloneMethod
		{
			[TestMethod]
			public void It_should_deep_clone_the_linked_list_including_the_arbitrary_link()
			{
				int[] source;
				var sut = new SingleLinkedListCollection<int>();
				SingleLinkedListNode<int> res;

				source = new[] { 1, 2, 3, 4, 5 };
				sut.Clear();
				sut.AddManyAtEnd(source);
				sut.SetArbitraryLinkByValue(2, 4);
				sut.SetArbitraryLinkByValue(3, 1);
				sut.SetArbitraryLinkByValue(4, 5);
				res = sut.DeepClone();
				sut.ToArray(res).Should().ContainInOrder(source);
				sut.ToArray().Should().ContainInOrder(source);
				sut.GetAtIndex(1).ArbitraryLink.Item.Should().Be(4);
				sut.GetAtIndex(2).ArbitraryLink.Item.Should().Be(1);
				sut.GetAtIndex(3).ArbitraryLink.Item.Should().Be(5);
				sut.GetAtIndex(0).ArbitraryLink.Should().BeNull();
			}
		}
	}
}
