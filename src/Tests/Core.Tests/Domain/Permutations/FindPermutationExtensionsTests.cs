using Core.Domain.Permutations;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Permutations
{
	[TestClass]
	public class FindPermutationExtensionsTests
	{
		[TestClass]
		public class TheFindPermutationUsingRecursionMethod
		{
			[TestMethod]
			public void It_should_find_the_specified_permutation_using_recursion()
			{
				string res;
				string source;

				source = "123";
				res = source.FindPermutationUsingRecursion(4);
				res.Should().Be("231");
			}
		}
	}
}
