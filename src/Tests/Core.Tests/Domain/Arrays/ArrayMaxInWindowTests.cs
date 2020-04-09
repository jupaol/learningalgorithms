using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using Core.Domain.Arrays;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Arrays
{
	[TestClass]
	public class ArrayMaxInWindowTests
	{
		[TestClass]
		public class TheMaximumInWindowMethod
		{
			[TestMethod]
			public void It_should_validate_parameters()
			{
				var fixture = new Fixture().Customize(new AutoMoqCustomization());
				var sut = fixture.Create<ArrayMaxInWindow>();
				Action calling = () => sut.MaximumInWindow<int>(null, 3);

				calling.Should().Throw<ArgumentNullException>();
			}

			[TestMethod]
			public void It_should_return_empty_when_window_is_not_valid()
			{
				var fixture = new Fixture().Customize(new AutoMoqCustomization());
				var sut = fixture.Create<ArrayMaxInWindow>();
				int[] res;

				res = sut.MaximumInWindow(new[] { 4, 5, 6 }, 0);
				res.Should().BeEmpty();

				res = sut.MaximumInWindow(new[] { 4, 5, 6 }, 4);
				res.Should().BeEmpty();

				res = sut.MaximumInWindow(Array.Empty<int>(), 4);
				res.Should().BeEmpty();
			}

			[TestMethod]
			public void It_should_find_all_maximums_in_the_array_windows()
			{
				var fixture = new Fixture().Customize(new AutoMoqCustomization());
				var sut = fixture.Create<ArrayMaxInWindow>();
				int[] res;
				int[] source = { 8, 98, 100, -4, -6, 0, 4, 20, 56, 2 };

				res = sut.MaximumInWindow(source, 3);
				res.Should().ContainInOrder(100, 100, 100, 0, 4, 20, 56, 56);

				res = sut.MaximumInWindow(source, 10);
				res.Should().ContainInOrder(100);
			}
		}
	}
}
