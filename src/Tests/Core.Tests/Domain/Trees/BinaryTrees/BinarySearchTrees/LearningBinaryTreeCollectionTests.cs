using System.Linq;
using Core.Domain.Trees.BinaryTrees;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Trees.BinaryTrees.BinarySearchTrees
{
	[TestClass]
	public class LearningBinaryTreeCollectionTests
	{
		[TestClass]
		public class TheAddRecursivelyMethod
		{
			[TestMethod]
			public void It_should_add_an_item_keeping_the_tree_sorted_using_recursion()
			{
				int[] source;
				IBinaryTreeNode<int> res;
				var sut = new LearningBinaryTreeCollection<int>();

				source = new[] { 4, 8, 2, 8, 9, 4, 1, 2, 9 };
				source.ToList().ForEach(x => sut.AddRecursively(x));
				res = sut.FindRecursively(9);
				res.Should().NotBeNull();
				res.Item.Should().Be(9);
			}
		}

		[TestClass]
		public class TheMinimumRecursivelyMethod
		{
			[TestMethod]
			public void It_should_find_the_minimum_value_in_the_binary_search_tree()
			{
				int[] source;
				IBinaryTreeNode<int> res;
				var sut = new LearningBinaryTreeCollection<int>();

				source = new[] { 4, 8, 2, 8, 9, 4, 1, 2, 9 };
				source.ToList().ForEach(x => sut.AddRecursively(x));
				res = sut.MinimumRecursively();
				res.Should().NotBeNull();
				res.Item.Should().Be(1);
			}
		}

		[TestClass]
		public class TheMaximumRecursivelyMethod
		{
			[TestMethod]
			public void It_should_find_the_maximum_value_in_the_binary_search_tree()
			{
				int[] source;
				IBinaryTreeNode<int> res;
				var sut = new LearningBinaryTreeCollection<int>();

				source = new[] { 4, 8, 2, 8, 9, 4, 1, 2, 9 };
				source.ToList().ForEach(x => sut.AddRecursively(x));
				res = sut.MaximumRecursively();
				res.Should().NotBeNull();
				res.Item.Should().Be(9);
			}
		}

		[TestClass]
		public class TheMinimumIterativelyMethod
		{
			[TestMethod]
			public void It_should_find_the_maximum_value_in_the_binary_search_tree()
			{
				int[] source;
				IBinaryTreeNode<int> res;
				var sut = new LearningBinaryTreeCollection<int>();

				source = new[] { 4, 8, 2, 8, 9, 4, 1, 2, 9 };
				source.ToList().ForEach(x => sut.AddRecursively(x));
				res = sut.MinimumIteratively();
				res.Should().NotBeNull();
				res.Item.Should().Be(1);
			}
		}

		[TestClass]
		public class TheMaximumIterativelyMethod
		{
			[TestMethod]
			public void It_should_find_the_maximum_value_in_the_binary_search_tree()
			{
				int[] source;
				IBinaryTreeNode<int> res;
				var sut = new LearningBinaryTreeCollection<int>();

				source = new[] { 4, 8, 2, 8, 9, 4, 1, 2, 9 };
				source.ToList().ForEach(x => sut.AddRecursively(x));
				res = sut.MaximumIteratively();
				res.Should().NotBeNull();
				res.Item.Should().Be(9);
			}
		}
	}
}
