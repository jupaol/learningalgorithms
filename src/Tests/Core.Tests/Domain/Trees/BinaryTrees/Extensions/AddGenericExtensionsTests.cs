using Core.Domain.Trees.BinaryTrees;
using Core.Domain.Trees.BinaryTrees.Extensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Trees.BinaryTrees.Extensions
{
	[TestClass]
	public class AddGenericExtensionsTests
	{
		[TestClass]
		public class TheAddFrontLeftMethod
		{
			[TestMethod]
			public void It_should_add_an_item_keeping_the_tree_sorted_using_recursion()
			{
				var sut = new LearningBinaryTreeCollection<int>();

				sut.AddFrontLeft(3);
				sut.Root.Item.Should().Be(3);
				sut.AddFrontLeft(2);
				sut.Root.Item.Should().Be(2);
				sut.Root.Left.Item.Should().Be(3);
			}
		}

		[TestClass]
		public class TheAddFrontRightMethod
		{
			[TestMethod]
			public void It_should_add_an_item_keeping_the_tree_sorted_using_recursion()
			{
				var sut = new LearningBinaryTreeCollection<int>();

				sut.AddFrontRight(3);
				sut.Root.Item.Should().Be(3);
				sut.AddFrontRight(2);
				sut.Root.Item.Should().Be(2);
				sut.Root.Right.Item.Should().Be(3);
			}
		}
	}
}
