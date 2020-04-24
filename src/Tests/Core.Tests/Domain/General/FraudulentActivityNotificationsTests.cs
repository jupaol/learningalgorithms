using System;
using System.IO;
using System.Linq;
using Core.Domain.General;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.General
{
	[TestClass]
	public class FraudulentActivityNotificationsTests
	{
		[TestClass]
		public class TheActivityNotificationsMethod
		{
			public TestContext TestContext { get; set; }

			[TestMethod]
			public void Test1()
			{
				int res;
				int[] source;

				source = new[] { 2, 3, 4, 15, 0, 6, 8, 7, 5 };
				res = source.ActivityNotifications(5);
				res.Should().Be(2);

				source = new[] { 2, 3, 4, 2, 3, 6, 8, 4, 5 };
				res = source.ActivityNotifications(5);
				res.Should().Be(2);

				source = new[] { 10, 20, 30, 40, 50 };
				res = source.ActivityNotifications(3);
				res.Should().Be(1);

				string l1 = File.ReadAllLines(@$"{TestContext.TestDeploymentDir}\Domain\General\input01.txt").First();
				var ns = Array.ConvertAll(l1.Split(" "), Convert.ToInt32);

				source = Array.ConvertAll(
					File
						.ReadAllLines(@$"{TestContext.TestDeploymentDir}\Domain\General\input01.txt")
						.Last()
						.Split(" "),
					Convert.ToInt32);
				res = source.ActivityNotifications(ns[1]);
				res.Should().Be(633);
			}
		}
	}
}
