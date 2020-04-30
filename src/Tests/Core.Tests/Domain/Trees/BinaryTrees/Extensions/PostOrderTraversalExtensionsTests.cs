using System.Collections.Generic;
using Core.Domain.Trees.BinaryTrees;
using Core.Domain.Trees.BinaryTrees.Extensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Trees.BinaryTrees.Extensions
{
	[TestClass]
	public class PostOrderTraversalExtensionsTests
	{
		[TestClass]
		public class TheGetInPostOrderTraversalRecursivelyMethod
		{
			[TestMethod]
			public void It_should_get_all_the_items_in_post_order_traversal_using_recursion()
			{
				int[] source;
				IEnumerable<int> res;
				var sut = new LearningBinaryTreeCollection<int>();

				source = new[] { 4, 8, 2, 8, 9, 4, 1, 2, 9 };
				sut.AddManyRecursively(source);
				res = sut.GetInPostOrderTraversalRecursively();
				res.Should().ContainInOrder(2, 1, 4, 2, 8, 9, 9, 8, 4);
			}
		}

		[TestClass]
		public class TheGetInPostOrderTraversalIterativelyMethod
		{
			[TestMethod]
			public void It_should_get_all_the_items_in_post_order_traversal_using_recursion()
			{
				int[] source;
				IEnumerable<int> res;
				var sut = new LearningBinaryTreeCollection<int>();

				source = new[] { 4, 8, 2, 8, 9, 4, 1, 2, 9 };
				sut.AddManyRecursively(source);
				res = sut.GetInPostOrderTraversalIteratively();
				res.Should().ContainInOrder(2, 1, 4, 2, 8, 9, 9, 8, 4);
			}
		}
	}
}
