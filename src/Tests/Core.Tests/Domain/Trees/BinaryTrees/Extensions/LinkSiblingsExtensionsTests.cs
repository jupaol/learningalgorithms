using Core.Domain.Trees.BinaryTrees;
using Core.Domain.Trees.BinaryTrees.Extensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Trees.BinaryTrees.Extensions
{
	[TestClass]
	public class LinkSiblingsExtensionsTests
	{
		[TestClass]
		public class TheLinkSiblingsInLevelTraversalMethod
		{
			[TestMethod]
			public void It_should_link_siblings_together()
			{
				int[] source;
				var sut = new LearningBinaryTreeCollection<int>();

				source = new[] { 4, 8, 2, 8, 9, 4, 1, 2, 9 };
				sut.AddManyRecursively(source);
				sut.LinkSiblingsInLevelTraversal();

				sut.Root.Item.Should().Be(4);
				sut.Root.Next.Should().BeNull();
				sut.Root.Left.Item.Should().Be(2);
				sut.Root.Left.Next.Item.Should().Be(8);
				sut.Root.Left.Left.Item.Should().Be(1);
				sut.Root.Left.Left.Next.Item.Should().Be(4);
				sut.Root.Left.Left.Next.Next.Item.Should().Be(8);
				sut.Root.Left.Left.Next.Next.Next.Item.Should().Be(9);
				sut.Root.Left.Left.Right.Item.Should().Be(2);
				sut.Root.Left.Left.Right.Next.Item.Should().Be(9);
			}
		}

		[TestClass]
		public class TheLinkSiblingsContinuouslyInLevelTraversalMethod
		{
			[TestMethod]
			public void It_should_link_siblings_together_continuously()
			{
				int[] source;
				var sut = new LearningBinaryTreeCollection<int>();

				source = new[] { 4, 8, 2, 8, 9, 4, 1, 2, 9 };
				sut.AddManyRecursively(source);
				sut.LinkSiblingsContinuouslyInLevelTraversal();

				sut.Root.Item.Should().Be(4);
				sut.Root.Next.Item.Should().Be(2);

				sut.Root.Left.Item.Should().Be(2);
				sut.Root.Left.Next.Item.Should().Be(8);
				sut.Root.Left.Next.Next.Item.Should().Be(1);

				sut.Root.Left.Left.Item.Should().Be(1);
				sut.Root.Left.Left.Next.Item.Should().Be(4);
				sut.Root.Left.Left.Next.Next.Item.Should().Be(8);
				sut.Root.Left.Left.Next.Next.Next.Item.Should().Be(9);
				sut.Root.Left.Left.Next.Next.Next.Next.Item.Should().Be(2);

				sut.Root.Left.Left.Right.Item.Should().Be(2);
				sut.Root.Left.Left.Right.Next.Item.Should().Be(9);
				sut.Root.Left.Left.Right.Next.Next.Should().BeNull();
			}
		}
	}
}
