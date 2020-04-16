using Core.Domain.LinkedLists;
using Core.Domain.LinkedLists.Search;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.LinkedLists.Search
{
	[TestClass]
	public class LinearSearchTests
	{
		[TestClass]
		public class TheSearchUsingLinearMethod
		{
			[TestMethod]
			public void It_should_search_a_linked_list_using_linear_search()
			{
				int[] source;
				var sut = new SingleLinkedListCollection<int>();
				SingleLinkedListNode<int> res;

				source = new[] { 4, 8, 0, 4, 2, 4 };
				sut.Clear();
				sut.AddManyAtEnd(source);

				foreach (int item in source)
				{
					res = sut.SearchUsingLinear(item);
					res.Item.Should().Be(item);
				}

				res = sut.SearchUsingLinear(88);
				res.Should().BeNull();
			}
		}
	}
}
