using System;
using Core.Domain.General;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.General
{
	[TestClass]
	public class SquareRootExtensionsTests
	{
		[TestClass]
		public class TheCalculateSquareRootUsingBinarySearchMethod
		{
			[TestMethod]
			public void It_should_calculate_the_square_root_of_a_number()
			{
				double source;
				double res;

				source = 9;
				res = source.CalculateSquareRootUsingBinarySearch();
				res.Should().Be(Math.Sqrt(source));

				source = 4.5;
				res = source.CalculateSquareRootUsingBinarySearch();
				Math.Round(res, MidpointRounding.AwayFromZero)
					.Should()
					.Be(Math.Round(Math.Sqrt(source), MidpointRounding.AwayFromZero));

				source = 0.1;
				res = source.CalculateSquareRootUsingBinarySearch();
				Math.Round(res, MidpointRounding.AwayFromZero)
					.Should()
					.Be(Math.Round(Math.Sqrt(source), MidpointRounding.AwayFromZero));
			}
		}
	}
}
