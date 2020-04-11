using System.Linq;
using AutoFixture;
using AutoFixture.AutoMoq;
using Core.Domain.Arrays;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Arrays
{
	[TestClass]
	public class CountItemTests
	{
		[TestClass]
		public class TheCountMethod
		{
			[TestMethod]
			public void It_should_count_the_number_of_elements()
			{
				IFixture fixture = new Fixture().Customize(new AutoMoqCustomization());
				var sut = fixture.Create<CountItem>();
				var source = new[] { 4, 6, 6, 6, 8, 9, 9, 9, 10, 10, 11 };
				int res;

				foreach (var item in source)
				{
					res = sut.Count(source, item);
					res.Should().Be(source.Count(x => x == item));
				}

				res = sut.Count(source, -2);
				res.Should().Be(0);

				res = sut.Count(source, 300);
				res.Should().Be(0);

				res = sut.Count(source, 5);
				res.Should().Be(0);
			}
		}
	}
}
