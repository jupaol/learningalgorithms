using System.Linq;
using Core.Domain.Trees.BinaryTrees;
using Core.Domain.Trees.BinaryTrees.Extensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Trees.BinaryTrees.Extensions
{
	[TestClass]
	public class DeleteSubTreeMatchingSumExtensionsTests
	{
		[TestClass]
		public class TheDeleteSubTreeMatchingSumRecursivelyMethod
		{
			[TestMethod]
			public void It_should_delete_the_subtree_matching_the_given_sum()
			{
				int[] source;
				var sut = new LearningBinaryTreeCollection<int>();

				source = new[] { 5, 3, -3, 8, 6 };
				source.ToList().ForEach(x => sut.AddRecursively(x));

				sut.Root.Item.Should().Be(5);

				sut.Root.Left.Item.Should().Be(3);
				sut.Root.Left.Left.Item.Should().Be(-3);

				sut.Root.Right.Item.Should().Be(8);
				sut.Root.Right.Left.Item.Should().Be(6);

				sut.DeleteSubTreeMatchingSumRecursively(0);

				sut.Root.Item.Should().Be(5);

				sut.Root.Left.Should().BeNull();

				sut.Root.Right.Item.Should().Be(8);
				sut.Root.Right.Left.Item.Should().Be(6);
			}

			[TestMethod]
			public void It_should_delete_the_root_matching_the_given_sum()
			{
				int[] source;
				var sut = new LearningBinaryTreeCollection<int>();

				source = new[] { 5, -6, -15, -7, 8, 6, 9 };
				source.ToList().ForEach(x => sut.AddRecursively(x));

				sut.Root.Item.Should().Be(5);

				sut.Root.Left.Item.Should().Be(-6);
				sut.Root.Left.Left.Item.Should().Be(-15);
				sut.Root.Left.Left.Right.Item.Should().Be(-7);

				sut.Root.Right.Item.Should().Be(8);
				sut.Root.Right.Left.Item.Should().Be(6);
				sut.Root.Right.Right.Item.Should().Be(9);

				sut.DeleteSubTreeMatchingSumRecursively(0);

				sut.Root.Should().BeNull();
			}
		}
	}
}
