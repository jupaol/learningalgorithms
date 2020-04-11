using AutoFixture;
using AutoFixture.AutoMoq;
using Core.Domain.Arrays.Sort;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Arrays.Sort
{
	[TestClass]
	public class SelectSortTests
	{
		[TestClass]
		public class TheSortMethod
		{
			[TestMethod]
			public void It_should_sort_an_array_using_select_sort()
			{
				IFixture fixture = new Fixture().Customize(new AutoMoqCustomization());
				var sut = fixture.Create<SelectSort>();
				int[] res;
				int[] source;

				source = new[] { 5, 3, 9, 2, 0, -3, 5 };
				res = sut.Sort(source);
				res.Should().ContainInOrder(-3, 0, 2, 3, 5, 5, 9);

				source = new[] { -3, 0, 2, 3, 5, 5, 9 };
				res = sut.Sort(source);
				res.Should().ContainInOrder(-3, 0, 2, 3, 5, 5, 9);
			}
		}
	}
}
