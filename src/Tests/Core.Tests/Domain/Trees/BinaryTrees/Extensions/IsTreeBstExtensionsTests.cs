using Core.Domain.Trees.BinaryTrees;
using Core.Domain.Trees.BinaryTrees.Extensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Trees.BinaryTrees.Extensions
{
	[TestClass]
	public class IsTreeBstExtensionsTests
	{
		[TestClass]
		public class TheIsTreeBstRecursivelyMethod
		{
			[TestMethod]
			public void It_should_detect_if_the_tree_is_bst_using_recursion()
			{
				int[] source;
				bool res;
				var sut = new LearningBinaryTreeCollection<int>();

				source = new[] { 4, 8, 2, 8, 9, 4, 1, 2, 9 };
				sut.AddManyRecursively(source);
				res = sut.IsTreeBstRecursively();
				res.Should().BeTrue();

				sut.AddFrontLeft(-1);
				res = sut.IsTreeBstRecursively();
				res.Should().BeFalse();
			}
		}

		[TestClass]
		public class TheIsTreeBstUsingInOrderTraversalIterativelyMethod
		{
			[TestMethod]
			public void It_should_detect_if_the_tree_is_bst_using_recursion_in_order_traversal()
			{
				int[] source;
				bool res;
				var sut = new LearningBinaryTreeCollection<int>();

				source = new[] { 4, 8, 2, 8, 9, 4, 1, 2, 9 };
				sut.AddManyRecursively(source);
				res = sut.IsTreeBstUsingInOrderTraversalIteratively();
				res.Should().BeTrue();

				sut.AddFrontLeft(-1);
				res = sut.IsTreeBstUsingInOrderTraversalIteratively();
				res.Should().BeFalse();
			}
		}

		[TestClass]
		public class TheIsTreeBstUsingMinMaxRecursivelyMethod
		{
			[TestMethod]
			public void It_should_detect_if_the_tree_is_bst_using_recursion_with_min_max()
			{
				int[] source;
				bool res;
				var sut = new LearningBinaryTreeCollection<int>();

				source = new[] { 4, 8, 2, 8, 9, 4, 1, 2, 9 };
				sut.AddManyRecursively(source);
				res = sut.IsTreeBstUsingMinMaxRecursively(int.MinValue, int.MaxValue);
				res.Should().BeTrue();

				sut.AddFrontLeft(-1);
				res = sut.IsTreeBstUsingMinMaxRecursively(int.MinValue, int.MaxValue);
				res.Should().BeFalse();
			}
		}
	}
}
