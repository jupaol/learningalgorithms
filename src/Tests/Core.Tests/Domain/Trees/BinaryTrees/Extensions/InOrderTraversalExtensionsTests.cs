using System.Collections.Generic;
using System.Linq;
using Core.Domain.Trees.BinaryTrees;
using Core.Domain.Trees.BinaryTrees.Extensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Trees.BinaryTrees.Extensions
{
	[TestClass]
	public class InOrderTraversalExtensionsTests
	{
		[TestClass]
		public class TheGetInOrderTraversalRecursivelyMethod
		{
			[TestMethod]
			public void It_should_get_the_items_in_order_traversal()
			{
				int[] source;
				IEnumerable<int> res;
				var sut = new LearningBinaryTreeCollection<int>();

				source = new[] { 4, 8, 2, 8, 9, 4, 1, 2, 9 };
				sut.AddManyRecursively(source);
				res = sut.GetInOrderTraversalRecursively();
				res.Should().ContainInOrder(source.OrderBy(x => x));
			}
		}

		[TestClass]
		public class TheGetInOrderTraversalIterativelyMethod
		{
			[TestMethod]
			public void It_should_get_all_items_in_order_traversal_using_iteration()
			{
				int[] source;
				IEnumerable<int> res;
				var sut = new LearningBinaryTreeCollection<int>();

				source = new[] { 4, 8, 2, 8, 9, 4, 1, 2, 9 };
				sut.AddManyRecursively(source);
				res = sut.GetInOrderTraversalIteratively();
				res.Should().ContainInOrder(source.OrderBy(x => x));
			}
		}
	}
}
