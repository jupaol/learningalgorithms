using Core.Domain.LinkedLists;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.LinkedLists
{
	[TestClass]
	public class IntersectListsTests
	{
		[TestClass]
		public class TheIntersectMethod
		{
			[TestMethod]
			public void It_should_return_the_intersected_element_from_two_linked_lists()
			{
				var list1 = new SingleLinkedListCollection<int>();
				var list2 = new SingleLinkedListCollection<int>();
				int[] source;

				source = new[] { 3, 5, 6 };
				list1.Clear();
				list1.AddManyAtEnd(source);

				source = new[] { 4 };
				list2.Clear();
				list2.AddManyAtEnd(source);

				var item1 = list1.GetAtIndex(1);
				var item2 = list2.GetAtIndex(0);

				item2.Next = item1;

				var res = list1.Intersect(list2);
				res.Should().NotBeNull();
				res.Item.Should().Be(5);
				res.Should().Be(item1);
			}
		}
	}
}
