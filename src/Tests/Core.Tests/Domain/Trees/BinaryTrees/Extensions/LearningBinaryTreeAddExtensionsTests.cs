using System.Linq;
using Core.Domain.Trees.BinaryTrees;
using Core.Domain.Trees.BinaryTrees.Extensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Trees.BinaryTrees.Extensions
{
	[TestClass]
	public class LearningBinaryTreeAddExtensionsTests
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
	}
}
