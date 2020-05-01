using Core.Domain.Trees.BinaryTrees;
using Core.Domain.Trees.BinaryTrees.Extensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Trees.BinaryTrees.Extensions
{
	[TestClass]
	public class InOrderSuccessorExtensionsTests
	{
		[TestClass]
		public class TheGetNextSuccessorMethod
		{
			[TestMethod]
			public void It_should_get_the_next_successor()
			{
				var sut = new LearningBinaryTreeCollection<int>();
				int[] source;
				int res;

				source = new[] { 4, 8, 2, 8, 9, 4, 1, 2, 9 };
				sut.AddManyRecursively(source);

				res = sut.GetNextInOrderSuccessor(1);
				res.Should().Be(2);

				res = sut.GetNextInOrderSuccessor(2);
				res.Should().Be(4);

				res = sut.GetNextInOrderSuccessor(4);
				res.Should().Be(8);

				res = sut.GetNextInOrderSuccessor(8);
				res.Should().Be(9);

				res = sut.GetNextInOrderSuccessor(9);
				res.Should().Be(0);
			}
		}
	}
}
