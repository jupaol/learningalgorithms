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
	}
}
