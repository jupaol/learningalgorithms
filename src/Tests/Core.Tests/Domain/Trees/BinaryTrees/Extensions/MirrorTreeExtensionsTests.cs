using System.Linq;
using Core.Domain.Trees.BinaryTrees;
using Core.Domain.Trees.BinaryTrees.Extensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Trees.BinaryTrees.Extensions
{
	[TestClass]
	public class MirrorTreeExtensionsTests
	{
		[TestClass]
		public class TheMirrorTreeInPostOrderRecursivelyMethod
		{
			[TestMethod]
			public void It_should_mirror_the_tree_using_post_order_recursively()
			{
				int[] source;
				var sut = new LearningBinaryTreeCollection<int>();

				source = new[] { 4, 8, 2, 8, 9, 4, 1, 2, 9 };
				source.ToList().ForEach(x => sut.AddRecursively(x));
				sut.MirrorTreeInPostOrderRecursively();

				sut.Root.Item.Should().Be(4);

				sut.Root.Left.Item.Should().Be(8);
				sut.Root.Right.Item.Should().Be(2);

				sut.Root.Left.Left.Item.Should().Be(9);
				sut.Root.Left.Right.Item.Should().Be(8);
				sut.Root.Right.Left.Item.Should().Be(4);
				sut.Root.Right.Right.Item.Should().Be(1);

				sut.Root.Left.Left.Right.Item.Should().Be(9);
				sut.Root.Right.Right.Left.Item.Should().Be(2);
			}
		}

		[TestClass]
		public class TheMirrorTreeInPostOrderIterativelyMethod
		{
			[TestMethod]
			public void It_should_mirror_the_tree_using_post_order_iteratively()
			{
				int[] source;
				var sut = new LearningBinaryTreeCollection<int>();

				source = new[] { 4, 8, 2, 8, 9, 4, 1, 2, 9 };
				source.ToList().ForEach(x => sut.AddRecursively(x));
				sut.MirrorTreeInPostOrderIteratively();

				sut.Root.Item.Should().Be(4);

				sut.Root.Left.Item.Should().Be(8);
				sut.Root.Right.Item.Should().Be(2);

				sut.Root.Left.Left.Item.Should().Be(9);
				sut.Root.Left.Right.Item.Should().Be(8);
				sut.Root.Right.Left.Item.Should().Be(4);
				sut.Root.Right.Right.Item.Should().Be(1);

				sut.Root.Left.Left.Right.Item.Should().Be(9);
				sut.Root.Right.Right.Left.Item.Should().Be(2);
			}
		}
	}
}
