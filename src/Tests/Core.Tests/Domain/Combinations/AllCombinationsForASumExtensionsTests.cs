using System.Collections.Generic;
using System.Linq;
using Core.Domain.Combinations;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Combinations
{
	[TestClass]
	public class AllCombinationsForASumExtensionsTests
	{
		[TestClass]
		public class TheAllCombinationsForASumUsingRecursionMethod
		{
			[TestMethod]
			public void It_should_get_all_combinations_giving_a_specific_sum()
			{
				int sum;
				IEnumerable<int>[] res;

				sum = 4;
				res = sum.AllCombinationsForASumUsingRecursion().ToArray();
				res.Length.Should().Be(4);
				res[0].Should().ContainInOrder(1, 1, 1, 1);
				res[1].Should().ContainInOrder(1, 1, 2);
				res[2].Should().ContainInOrder(1, 3);
				res[3].Should().ContainInOrder(2, 2);
			}
		}
	}
}
