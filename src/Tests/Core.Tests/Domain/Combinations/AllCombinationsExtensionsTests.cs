using System.Linq;
using Core.Domain;
using Core.Domain.Combinations;
using Core.Domain.Extensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Combinations
{
	[TestClass]
	public class AllCombinationsExtensionsTests
	{
		private static int GetFactorial(int n)
		{
			int res = 1;

			for (int i = 0; i < n; i++)
			{
				res *= n - i;
			}

			return res;
		}

		[TestClass]
		public class TheGetAllCombinationsUsingRecursionOptimizedForDuplicatesMethod
		{
			[TestMethod]
			public void It_should_get_all_combinations()
			{
				int[] source;
				int[][] res;
				ILearningCollection<int> sut;

				source = new[] { 1, 2, 3 };
				sut = source.AsLearningCollection();
				res = sut.GetAllCombinationsUsingRecursionOptimizedForDuplicates()
					.Select(x => x.ToArray()).ToArray();

				////int n = source.Length;
				////const int k = 3;
				////int numberOfCombinations = GetFactorial(n) / (GetFactorial(k) * GetFactorial(n - k));

				////res.Length.Should().Be(numberOfCombinations + 1);
				res.Length.Should().Be(8);
				res[0].Should().BeEmpty();
				res[1].Should().ContainInOrder(new[] { 1 });
				res[2].Should().ContainInOrder(new[] { 1, 2 });
				res[3].Should().ContainInOrder(new[] { 1, 2, 3 });
				res[4].Should().ContainInOrder(new[] { 1, 3 });
				res[5].Should().ContainInOrder(new[] { 2 });
				res[6].Should().ContainInOrder(new[] { 2, 3 });
				res[7].Should().ContainInOrder(new[] { 3 });
			}

			[TestMethod]
			public void It_should_get_all_combinations_with_duplicates()
			{
				int[] source;
				int[][] res;
				ILearningCollection<int> sut;

				source = new[] { 1, 3, 3 };
				sut = source.AsLearningCollection();
				res = sut.GetAllCombinationsUsingRecursionOptimizedForDuplicates()
					.Select(x => x.ToArray()).ToArray();

				////int n = source.Length;
				////const int k = 3;
				////int numberOfCombinations = GetFactorial(n) / (GetFactorial(k) * GetFactorial(n - k));

				////res.Length.Should().Be(numberOfCombinations + 1);
				res.Length.Should().Be(6);
				res[0].Should().BeEmpty();
				res[1].Should().ContainInOrder(new[] { 1 });
				res[2].Should().ContainInOrder(new[] { 1, 3 });
				res[3].Should().ContainInOrder(new[] { 1, 3, 3 });
				res[4].Should().ContainInOrder(new[] { 3 });
				res[5].Should().ContainInOrder(new[] { 3, 3 });
			}
		}

		[TestClass]
		public class TheGetAllCombinationsUsingBinaryMethodMethod
		{
			[TestMethod]
			public void It_should_return_all_the_combinations_using_binary_method()
			{
				int[] source;
				int[][] res;
				ILearningCollection<int> sut;

				source = new[] { 1, 2, 3 };
				sut = source.AsLearningCollection();
				res = sut.GetAllCombinationsUsingBinaryMethod()
					.Select(x => x.ToArray()).ToArray();
				res.Length.Should().Be(8);
				res[0].Should().BeEmpty();
				res[1].Should().ContainInOrder(new[] { 1 });
				res[2].Should().ContainInOrder(new[] { 2 });
				res[3].Should().ContainInOrder(new[] { 1, 2 });
				res[4].Should().ContainInOrder(new[] { 3 });
				res[5].Should().ContainInOrder(new[] { 1, 3 });
				res[6].Should().ContainInOrder(new[] { 2, 3 });
				res[7].Should().ContainInOrder(new[] { 1, 2, 3 });
			}
		}
	}
}
