using System.Linq;
using Core.Domain.Trees.BinaryTrees;
using Core.Domain.Trees.BinaryTrees.Extensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Trees.BinaryTrees
{
	[TestClass]
	public class LearningBinaryTreeCollectionTests
	{
		[TestClass]
		public class TheGetNextMethod
		{
			[TestMethod]
			public void It_should_get_the_next_item_using_an_iterator()
			{
				var sut = new LearningBinaryTreeCollection<int>();
				int[] source;
				int i = 0;

				source = new[] { 4, 8, 2, 8, 9, 4, 1, 2, 9 };
				sut.AddManyRecursively(source);

				int[] sortedSource = source.OrderBy(x => x).ToArray();

				while (sut.HasNext())
				{
					sut.GetNext().Should().Be(sortedSource[i++]);
				}
			}
		}
	}
}
