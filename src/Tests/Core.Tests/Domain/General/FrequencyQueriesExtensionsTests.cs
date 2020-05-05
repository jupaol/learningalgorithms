using System;
using System.IO;
using Core.Domain.General;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.General
{
	[TestClass]
	public class FrequencyQueriesExtensionsTests
	{
		[TestClass]
		public class TheGetFrequencyMethod
		{
			public TestContext TestContext { get; set; }

			[TestMethod]
			public void It_should_get_the_frequencies()
			{
				var lines = File.ReadAllLines(@$"{TestContext.TestDeploymentDir}\Domain\General\input08.txt");
				int q = int.Parse(lines[0]);
				int[][] queries = new int[q][];

				for (int i = 0; i < q; i++)
				{
					queries[i] = Array.ConvertAll(
						lines[i + 1].TrimEnd().Split(' '),
						Convert.ToInt32);
				}

				var expected = Array
					.ConvertAll(
						File
							.ReadAllLines(@$"{TestContext.TestDeploymentDir}\Domain\General\output08.txt"),
						Convert.ToInt32);

				var res = queries.GetFrequency();

				res.Should().NotBeNull().And.NotBeEmpty().And
					.ContainInOrder(expected);
			}
		}
	}
}
