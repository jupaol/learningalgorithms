using System.Collections.Generic;
using Core.Domain.Trees.BinaryTrees;
using Core.Domain.Trees.BinaryTrees.Extensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Trees.BinaryTrees.Extensions
{
	[TestClass]
	public class LevelOrderTraversalExtensionsTests
	{
		[TestClass]
		public class TheGetInLevelOrderTraversalMethod
		{
			[TestMethod]
			public void It_should_get_the_items_in_level_order_traversal()
			{
				int[] source;
				IEnumerable<int> res;
				var sut = new LearningBinaryTreeCollection<int>();

				source = new[] { 4, 8, 2, 8, 9, 4, 1, 2, 9 };
				sut.AddManyRecursively(source);
				res = sut.GetInLevelOrderTraversal();
				res.Should().ContainInOrder(4, 2, 8, 1, 4, 8, 9, 2, 9);
			}
		}
	}
}
