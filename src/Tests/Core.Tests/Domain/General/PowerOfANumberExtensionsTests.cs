using System;
using Core.Domain.General;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.General
{
	[TestClass]
	public class PowerOfANumberExtensionsTests
	{
		[TestClass]
		public class TheGetPowerUsingIterationMethod
		{
			[TestMethod]
			public void It_should_calculate_the_exponent_of_a_number_iteratively()
			{
				int source;
				int exponent;
				double res;

				source = 3;
				exponent = 3;
				res = source.GetPowerUsingIteration(exponent);
				res.Should().Be(Math.Pow(source, exponent));

				source = 3;
				exponent = -3;
				res = source.GetPowerUsingIteration(exponent);
				res.Should().Be(Math.Pow(source, exponent));
			}
		}

		[TestClass]
		public class TheGetPowerUsingRecursionMethod
		{
			[TestMethod]
			public void It_should_calculate_the_exponent_of_a_number_iteratively()
			{
				int source;
				int exponent;
				double res;

				source = 3;
				exponent = 3;
				res = source.GetPowerUsingRecursion(exponent);
				res.Should().Be(Math.Pow(source, exponent));

				source = 3;
				exponent = -3;
				res = source.GetPowerUsingRecursion(exponent);
				res.Should().Be(Math.Pow(source, exponent));
			}
		}
	}
}
