using System.Linq;
using Core.Domain.Trees.BinaryTrees;
using Core.Domain.Trees.BinaryTrees.Extensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Trees.BinaryTrees.Extensions
{
	[TestClass]
	public class HeightExtensionsTests
	{
		[TestClass]
		public class TheCalculateHeightRecursivelyMethod
		{
			[TestMethod]
			public void It_should_return_the_tree_height()
			{
				int[] source;
				int res;
				var sut = new LearningBinaryTreeCollection<int>();

				source = new[] { 4, 8, 2, 8, 9, 4, 1, 2, 9 };
				sut.AddManyRecursively(source);
				res = sut.CalculateHeightRecursively();
				res.Should().Be(3);
			}
		}

		[TestClass]
		public class TheCalculateHeightIterativelyMethod
		{
			[TestMethod]
			public void It_should_return_the_tree_height()
			{
				int[] source;
				int res;
				var sut = new LearningBinaryTreeCollection<int>();

				source = new[] { 4, 8, 2, 8, 9, 4, 1, 2, 9 };
				source.ToList().ForEach(x => sut.AddRecursively(x));
				res = sut.CalculateHeightIteratively();
				res.Should().Be(3);
			}
		}
	}
}
