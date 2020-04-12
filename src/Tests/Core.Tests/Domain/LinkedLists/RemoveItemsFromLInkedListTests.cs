using System.Linq;
using Core.Domain.LinkedLists;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.LinkedLists
{
	[TestClass]
	public class RemoveItemsFromLInkedListTests
	{
		[TestClass]
		public class TheRemoveDuplicatesMethod
		{
			[TestMethod]
			public void It_should_remove_duplicates_from_a_linked_list()
			{
				var source = new[] { 3, 2, 9, 6, 3, 0, 7, 5, 6, 9, 5, 2, 1, 3, 5 };
				var expected = source.Distinct();
				var sut = new SingleLinkedListCollection<int>();

				sut.AddManyAtEnd(source);
				sut.RemoveDuplicates();
				sut.ToArray().Should().ContainInOrder(expected);

				sut.Clear();
				sut.RemoveDuplicates();
				sut.ToArray().Should().BeEmpty();
			}
		}

		[TestClass]
		public class TheRemoveItemsMethod
		{
			[TestMethod]
			public void It_should_remove_all_matching_items_from_a_linked_list()
			{
				var source = new[] { 3, 2, 9, 6, 3, 0, 7, 5, 6, 9, 5, 2, 1, 3, 5 };
				var sut = new SingleLinkedListCollection<int>();

				sut.Clear();
				sut.AddManyAtEnd(source);
				sut.RemoveItems(3);
				sut.ToArray().Should().ContainInOrder(source.Where(x => x != 3));

				sut.Clear();
				sut.AddManyAtEnd(source);
				sut.RemoveItems(9);
				sut.ToArray().Should().ContainInOrder(source.Where(x => x != 9));

				sut.Clear();
				sut.AddManyAtEnd(source);
				sut.RemoveItems(20);
				sut.ToArray().Should().ContainInOrder(source);
			}
		}
	}
}
