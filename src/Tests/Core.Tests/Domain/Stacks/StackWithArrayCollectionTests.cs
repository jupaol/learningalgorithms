using System.Linq;
using Core.Domain.Stacks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Stacks
{
	[TestClass]
	public class StackWithArrayCollectionTests
	{
		[TestMethod]
		public void It_should_perform_basic_operations_on_the_stack()
		{
			int[] source;
			var sut = new StackWithArrayCollection<int>();

			sut.IsEmpty().Should().BeTrue();
			source = new[] { 3, 10, 8, 9, 1, 4, 9 };
			source.ToList().ForEach(sut.Push);
			sut.IsEmpty().Should().BeFalse();

			sut.Peek().Should().Be(9);

			foreach (int item in source.Reverse())
			{
				sut.Pop().Should().Be(item);
			}

			sut.IsEmpty().Should().BeTrue();
		}
	}
}
