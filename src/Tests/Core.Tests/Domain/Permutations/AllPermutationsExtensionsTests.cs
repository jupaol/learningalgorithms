using System.Linq;
using Core.Domain;
using Core.Domain.Extensions;
using Core.Domain.Permutations;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Permutations
{
	[TestClass]
	public class AllPermutationsExtensionsTests
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
		public class TheGetAllStringPermutationsUsingRecursionMethod
		{
			[TestMethod]
			public void It_should_get_all_permutations_from_a_string()
			{
				string source;
				string[] res;

				source = "bad";
				res = source.GetAllStringPermutationsUsingRecursion();
				res.Length.Should().Be(GetFactorial(source.Length));
				res.Should().ContainInOrder("bad", "bda", "abd", "adb", "dba", "dab");

				source = "123";
				res = source.GetAllStringPermutationsUsingRecursion();
				res.Length.Should().Be(GetFactorial(source.Length));
				res.Should().ContainInOrder("123", "132", "213", "231", "312", "321");
			}
		}

		[TestClass]
		public class TheGetAllPermutationsNotInLexOrderUsingRecursionMethod
		{
			[TestMethod]
			public void It_should_get_all_permutations_from_an_array()
			{
				int[] source;
				int[][] res;
				ILearningCollection<int> sut;

				source = new[] { 1, 2, 3 };
				sut = source.AsLearningCollection();
				res = sut.GetAllPermutationsNotInLexOrderUsingRecursion().Select(x => x.ToArray()).ToArray();
				res.Length.Should().Be(GetFactorial(source.Length));
				res[0].Should().ContainInOrder(new[] { 1, 2, 3 });
				res[1].Should().ContainInOrder(new[] { 1, 3, 2 });
				res[2].Should().ContainInOrder(new[] { 2, 1, 3 });
				res[3].Should().ContainInOrder(new[] { 2, 3, 1 });
				res[4].Should().ContainInOrder(new[] { 3, 2, 1 });
				res[5].Should().ContainInOrder(new[] { 3, 1, 2 });
			}
		}

		[TestClass]
		public class TheGetAllPermutationsUsingRecursionMethod
		{
			[TestMethod]
			public void It_should_get_all_permutations_from_an_array_in_lex_order()
			{
				int[] source;
				int[][] res;
				ILearningCollection<int> sut;

				source = new[] { 1, 2, 3 };
				sut = source.AsLearningCollection();
				res = sut.GetAllPermutationsUsingRecursion().Select(x => x.ToArray()).ToArray();
				res.Length.Should().Be(GetFactorial(source.Length));
				res[0].Should().ContainInOrder(new[] { 1, 2, 3 });
				res[1].Should().ContainInOrder(new[] { 1, 3, 2 });
				res[2].Should().ContainInOrder(new[] { 2, 1, 3 });
				res[3].Should().ContainInOrder(new[] { 2, 3, 1 });
				res[4].Should().ContainInOrder(new[] { 3, 1, 2 });
				res[5].Should().ContainInOrder(new[] { 3, 2, 1 });
			}
		}

		[TestClass]
		public class TheGetAllPermutationsOptimizedForDuplicatesUsingRecursionMethod
		{
			[TestMethod]
			public void It_should_get_all_permutations_from_an_array_with_duplicates()
			{
				int[] source;
				int[][] res;
				ILearningCollection<int> sut;

				source = new[] { 1, 2, 3 };
				sut = source.AsLearningCollection();
				res = sut.GetAllPermutationsOptimizedForDuplicatesUsingRecursion().Select(
					x => x.ToArray()).ToArray();
				res.Length.Should().Be(GetFactorial(source.Length));
				res[0].Should().ContainInOrder(new[] { 1, 2, 3 });
				res[1].Should().ContainInOrder(new[] { 1, 3, 2 });
				res[2].Should().ContainInOrder(new[] { 2, 1, 3 });
				res[3].Should().ContainInOrder(new[] { 2, 3, 1 });
				res[4].Should().ContainInOrder(new[] { 3, 1, 2 });
				res[5].Should().ContainInOrder(new[] { 3, 2, 1 });

				source = new[] { 1, 3, 3 };
				sut = source.AsLearningCollection();
				res = sut.GetAllPermutationsOptimizedForDuplicatesUsingRecursion().Select(
					x => x.ToArray()).ToArray();
				res.Length.Should().Be(3); // 3! / 2! (2 because there are two duplicates)
				res[0].Should().ContainInOrder(new[] { 1, 3, 3 });
				res[1].Should().ContainInOrder(new[] { 3, 1, 3 });
				res[2].Should().ContainInOrder(new[] { 3, 3, 1 });

				source = new[] { 1, 2, 3, 4, 5 };
				sut = source.AsLearningCollection();
				res = sut.GetAllPermutationsOptimizedForDuplicatesUsingRecursion().Select(
					x => x.ToArray()).ToArray();
				res.Length.Should().Be(GetFactorial(source.Length));
			}
		}
	}
}
