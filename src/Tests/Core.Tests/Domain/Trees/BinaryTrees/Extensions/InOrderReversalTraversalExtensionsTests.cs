using System.Collections.Generic;
using System.Linq;
using Core.Domain.Trees.BinaryTrees;
using Core.Domain.Trees.BinaryTrees.Extensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Trees.BinaryTrees.Extensions
{
	[TestClass]
	public class InOrderReversalTraversalExtensionsTests
	{
		[TestClass]
		public class TheGetInOrderReversalTraversalRecursivelyMethod
		{
			[TestMethod]
			public void It_should_get_the_elements_in_in_order_reversal_using_recursion()
			{
				int[] source;
				IEnumerable<int> res;
				var sut = new LearningBinaryTreeCollection<int>();

				source = new[] { 4, 8, 2, 8, 9, 4, 1, 2, 9 };
				sut.AddManyRecursively(source);
				res = sut.GetInOrderReversalTraversalRecursively();
				res.Should().ContainInOrder(source.OrderByDescending(x => x));
			}
		}

		[TestClass]
		public class TheGetInOrderReversalTraversalIterativelyMethod
		{
			[TestMethod]
			public void It_should_get_the_elements_in_in_order_reversal_using_recursion()
			{
				int[] source;
				IEnumerable<int> res;
				var sut = new LearningBinaryTreeCollection<int>();

				source = new[] { 4, 8, 2, 8, 9, 4, 1, 2, 9 };
				sut.AddManyRecursively(source);
				res = sut.GetInOrderReversalTraversalIteratively();
				res.Should().ContainInOrder(source.OrderByDescending(x => x));
			}
		}
	}
}
