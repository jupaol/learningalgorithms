using System.Collections.Generic;
using System.Linq;
using Core.Domain.Permutations;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Permutations
{
	[TestClass]
	public class AllPermutationsOfBalancedBracersExtensionsTests
	{
		[TestClass]
		public class TheGetAllBalancedBracersPermutationsMethod
		{
			[TestMethod]
			public void It_should_get_all_the_balanced_bracers_permutations()
			{
				int source;
				IEnumerable<char>[] res;

				source = 3;
				res = source.GetAllBalancedBracersPermutations().ToArray();
				res.Should().HaveCount(5);
				res[0].Should().ContainInOrder('{', '{', '{', '}', '}', '}');
				res[1].Should().ContainInOrder('{', '{', '}', '{', '}', '}');
				res[2].Should().ContainInOrder('{', '{', '}', '}', '{', '}');
				res[3].Should().ContainInOrder('{', '}', '{', '{', '}', '}');
				res[4].Should().ContainInOrder('{', '}', '{', '}', '{', '}');
			}
		}

		[TestClass]
		public class TheGetAllBalancedBracersPermutationsUsingCountsMethod
		{
			[TestMethod]
			public void It_should_get_all_the_balanced_bracers_permutations()
			{
				int source;
				IEnumerable<char>[] res;

				source = 3;
				res = source.GetAllBalancedBracersPermutationsUsingCounts().ToArray();
				res.Should().HaveCount(5);
				res[0].Should().ContainInOrder('{', '{', '{', '}', '}', '}');
				res[1].Should().ContainInOrder('{', '{', '}', '{', '}', '}');
				res[2].Should().ContainInOrder('{', '{', '}', '}', '{', '}');
				res[3].Should().ContainInOrder('{', '}', '{', '{', '}', '}');
				res[4].Should().ContainInOrder('{', '}', '{', '}', '{', '}');
			}
		}
	}
}
