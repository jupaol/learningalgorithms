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
				res[0].Should().BeEmpty();
				////res[1].Should().ContainInOrder(new[] { 1, 3, 2 });
				////res[2].Should().ContainInOrder(new[] { 2, 1, 3 });
				////res[3].Should().ContainInOrder(new[] { 2, 3, 1 });
				////res[4].Should().ContainInOrder(new[] { 3, 2, 1 });
				////res[5].Should().ContainInOrder(new[] { 3, 1, 2 });
			}
		}
	}
}
