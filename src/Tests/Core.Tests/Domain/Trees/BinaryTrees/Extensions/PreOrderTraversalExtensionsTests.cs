using System.Collections.Generic;
using Core.Domain.Trees.BinaryTrees;
using Core.Domain.Trees.BinaryTrees.Extensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Trees.BinaryTrees.Extensions
{
	[TestClass]
	public class PreOrderTraversalExtensionsTests
	{
		[TestClass]
		public class TheGetInPreOrderTraversalRecursivelyMethod
		{
			[TestMethod]
			public void It_should_get_all_the_items_in_pre_order_traversal_using_recursion()
			{
				int[] source;
				IEnumerable<int> res;
				var sut = new LearningBinaryTreeCollection<int>();

				source = new[] { 4, 8, 2, 8, 9, 4, 1, 2, 9 };
				sut.AddManyRecursively(source);
				res = sut.GetInPreOrderTraversalRecursively();
				res.Should().ContainInOrder(4, 2, 1, 2, 4, 8, 8, 9, 9);
			}
		}

		[TestClass]
		public class TheGetInPreOrderTraversalIterativelyMethod
		{
			[TestMethod]
			public void It_should_get_all_the_items_in_pre_order_traversal_using_iteration()
			{
				int[] source;
				IEnumerable<int> res;
				var sut = new LearningBinaryTreeCollection<int>();

				source = new[] { 4, 8, 2, 8, 9, 4, 1, 2, 9 };
				sut.AddManyRecursively(source);
				res = sut.GetInPreOrderTraversalIteratively();
				res.Should().ContainInOrder(4, 2, 1, 2, 4, 8, 8, 9, 9);
			}
		}
	}
}
