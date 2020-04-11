using AutoFixture;
using AutoFixture.AutoMoq;
using Core.Domain.Arrays;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Arrays
{
	[TestClass]
	public class MoveItemsInArrayTests
	{
		[TestClass]
		public class TheMoveLeftMethod
		{
			[TestMethod]
			public void It_should_move_the_key_elements_to_the_start_of_the_array()
			{
				var fixture = new Fixture().Customize(new AutoMoqCustomization());
				var sut = fixture.Create<MoveItemsInArray>();
				int[] source;
				int[] res;

				source = new[] { 1, 10, 20, 0, 59, 63, 0, 88, 0 };
				res = sut.MoveLeft(source, 0);
				res.Should().ContainInOrder(0, 0, 0, 1, 10, 20, 59, 63, 88);

				source = new[] { 1, 10, 20, 0, 59, 63, 0, 88, 0, 99 };
				res = sut.MoveLeft(source, 0);
				res.Should().ContainInOrder(0, 0, 0, 1, 10, 20, 59, 63, 88, 99);
			}
		}

		[TestClass]
		public class TheMoveRightMethod
		{
			[TestMethod]
			public void It_should_move_the_key_elements_to_the_end_of_the_array()
			{
				var fixture = new Fixture().Customize(new AutoMoqCustomization());
				var sut = fixture.Create<MoveItemsInArray>();
				int[] source;
				int[] res;

				source = new[] { 1, 10, 20, 0, 59, 63, 0, 88, 0 };
				res = sut.MoveRight(source, 0);
				res.Should().ContainInOrder(1, 10, 20, 59, 63, 88, 0, 0, 0);

				source = new[] { 1, 10, 20, 0, 59, 63, 0, 88, 0, 99 };
				res = sut.MoveRight(source, 0);
				res.Should().ContainInOrder(1, 10, 20, 59, 63, 88, 99, 0, 0, 0);
			}
		}
	}
}
