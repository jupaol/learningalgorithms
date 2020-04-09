using AutoFixture;
using AutoFixture.AutoMoq;
using Core.Domain.Arrays;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Arrays
{
	[TestClass]
	public class IterativeArrayMaxTests
	{
		[TestMethod]
		public void It_should_find_the_maximum_item_iteratively()
		{
			var fixture = new Fixture().Customize(new AutoMoqCustomization());
			var sut = fixture.Create<IterativeArrayMax>();
			var source = new[] { 8, 98, 100, -4, -6, 0, 4, 20, 56, 2 };

			int res = sut.Maximum(source);

			res.Should().Be(100);
		}
	}
}
