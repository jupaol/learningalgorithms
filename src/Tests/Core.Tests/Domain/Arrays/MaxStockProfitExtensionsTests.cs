using Core.Domain;
using Core.Domain.Arrays;
using Core.Domain.Extensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Arrays
{
	[TestClass]
	public class MaxStockProfitExtensionsTests
	{
		[TestClass]
		public class TheGetMaxProfitMethod
		{
			[TestMethod]
			public void It_should_get_the_max_profit_from_an_array_containing_stock_prices()
			{
				int[] source;
				(int, int)? res;
				ILearningCollection<int> sut;

				source = new[] { 8, 5, 12, 9, 19, 1 };
				sut = source.AsLearningCollection();
				res = sut.GetMaxProfit();
				res.Value.Should().Be((5, 19));

				source = new[] { 21, 12, 11, 9, 6, 3 };
				sut = source.AsLearningCollection();
				res = sut.GetMaxProfit();
				res.Value.Should().Be((12, 11));

				source = new[] { 21, 12 };
				sut = source.AsLearningCollection();
				res = sut.GetMaxProfit();
				res.Value.Should().Be((21, 12));
			}
		}
	}
}
