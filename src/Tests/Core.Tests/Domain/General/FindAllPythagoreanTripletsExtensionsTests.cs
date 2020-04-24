using System.Collections.Generic;
using System.Linq;
using Core.Domain.Extensions;
using Core.Domain.General;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.General
{
	[TestClass]
	public class FindAllPythagoreanTripletsExtensionsTests
	{
		[TestClass]
		public class TheFindAllPythagoreanTripletsMethod
		{
			[TestMethod]
			public void It_should_find_all_pythagorean_triplets_in_an_array()
			{
				int[] source;
				IEnumerable<int>[] res;

				source = new[] { 4, 16, 1, 2, 3, 5, 6, 8, 25, 10 };
				res = source.AsLearningCollection().FindAllPythagoreanTriplets().ToArray();
				res.Should().HaveCount(2);
				res.ToArray()[0].Should().ContainInOrder(6, 8, 10);
				res.ToArray()[1].Should().ContainInOrder(3, 4, 5);
			}
		}
	}
}
