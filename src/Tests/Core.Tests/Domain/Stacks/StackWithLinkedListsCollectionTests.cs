using System.Linq;
using Core.Domain.Stacks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Stacks
{
	[TestClass]
	public class StackWithLinkedListsCollectionTests
	{
		[TestMethod]
		public void It_should_perform_basic_operations()
		{
			int[] source;
			var sut = new StackWithLinkedListsCollection<int>();

			source = new[] { 3, 87, 2, 9, 4, 7 };
			source.ToList().ForEach(sut.Push);
			sut.IsEmpty().Should().BeFalse();

			sut.Peek().Should().Be(7);

			foreach (int item in source.Reverse())
			{
				sut.Pop().Should().Be(item);
			}

			sut.IsEmpty().Should().BeTrue();
		}
	}
}
