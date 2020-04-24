using Core.Domain.General;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.General
{
	[TestClass]
	public class SumOfTheFirstNumbersExtensionsTests
	{
		[TestClass]
		public class TheGetSumOfTheFirstNaturalNumbersMethod
		{
			[TestMethod]
			public void It_should_calculate_the_sum_of_the_first_numbers()
			{
				int source;
				int res;

				source = 5;
				res = source.GetSumOfTheFirstNaturalNumbers();
				res.Should().Be(15);

				source = 0;
				res = source.GetSumOfTheFirstNaturalNumbers();
				res.Should().Be(0);

				source = 1;
				res = source.GetSumOfTheFirstNaturalNumbers();
				res.Should().Be(1);
			}
		}
	}
}
