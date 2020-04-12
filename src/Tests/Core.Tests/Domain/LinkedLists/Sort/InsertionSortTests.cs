using System;
using System.Linq;
using Core.Domain.LinkedLists;
using Core.Domain.LinkedLists.Sort;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.LinkedLists.Sort
{
	[TestClass]
	public class InsertionSortTests
	{
		[TestClass]
		public class TheSortMethod
		{
			[TestMethod]
			public void It_should_sort_the_linked_list_using_insertion_sort()
			{
				var sut = new SingleLinkedListCollection<int>();
				int[] source;

				source = new[] { 3, 4, 1, 0, 6, 2 };
				sut.Clear();
				sut.AddManyAtEnd(source);
				sut.Sort();
				sut.ToArray().Should().ContainInOrder(source.OrderBy(x => x));

				source = new[] { 1 };
				sut.Clear();
				sut.AddManyAtEnd(source);
				sut.Sort();
				sut.ToArray().Should().ContainInOrder(source.OrderBy(x => x));

				source = Array.Empty<int>();
				sut.Clear();
				sut.AddManyAtEnd(source);
				sut.Sort();
				sut.ToArray().Should().BeEmpty();
			}
		}
	}
}
