using System;
using System.IO;
using System.Linq;
using Core.Domain.General;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.General
{
	[TestClass]
	public class IceCreamParlorExtensionsTests
	{
		[TestClass]
		public class TheGetIceCreamChoicesMethod
		{
			public TestContext TestContext { get; set; }

			[TestMethod]
			public void It_should_get_the_ice_cream_indices()
			{
				var lines = File.ReadAllLines(@$"{TestContext.TestDeploymentDir}\Domain\General\input00.txt");
				int money = int.Parse(lines[1]);
				int q = int.Parse(lines[2]);
				int[] costs = Array.ConvertAll(lines[3].TrimEnd().Split(' '), Convert.ToInt32);

				var expected = Array
					.ConvertAll(
						File
							.ReadAllLines(@$"{TestContext.TestDeploymentDir}\Domain\General\output00.txt")
							.First().TrimEnd().Split(' '),
						Convert.ToInt32);

				var res = costs.GetIceCreamChoices(money);

				res.First.Should().Be(expected[0]);
				res.Second.Should().Be(expected[1]);
			}
		}
	}
}
