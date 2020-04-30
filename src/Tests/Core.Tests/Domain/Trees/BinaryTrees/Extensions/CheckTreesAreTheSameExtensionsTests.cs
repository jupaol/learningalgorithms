using Core.Domain.Trees.BinaryTrees;
using Core.Domain.Trees.BinaryTrees.Extensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Trees.BinaryTrees.Extensions
{
	[TestClass]
	public class CheckTreesAreTheSameExtensionsTests
	{
		[TestClass]
		public class TheAreTreesTheSameRecursivelyMethod
		{
			[TestMethod]
			public void It_should_check_if_two_trees_are_the_same()
			{
				var sut1 = new LearningBinaryTreeCollection<int>();
				var sut2 = new LearningBinaryTreeCollection<int>();
				int[] source;
				bool res;

				source = new[] { 4, 8, 2, 8, 9, 4, 1, 2, 9 };
				sut1.AddManyRecursively(source);
				sut2.AddManyRecursively(source);
				res = sut1.AreTreesTheSameRecursively(sut2);
				res.Should().BeTrue();

				sut1.Clear();
				sut2.Clear();
				source = new[] { 4, 8, 2, 8, 9, 4, 1, 2, 9 };
				sut1.AddManyRecursively(source);
				source = new[] { 4, 8, 2, 8, 9, 4, 1, 2 };
				sut2.AddManyRecursively(source);
				res = sut1.AreTreesTheSameRecursively(sut2);
				res.Should().BeFalse();
			}
		}
	}
}
