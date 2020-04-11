using AutoFixture;
using AutoFixture.AutoMoq;
using Core.Domain.Arrays.Rotate;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Arrays.Rotate
{
	[TestClass]
	public class RotateArrayInPlaceWithTmpArrayTests
	{
		[TestClass]
		public class TheRotateMethod
		{
			[TestMethod]
			public void It_should_rotate_the_array_to_the_right()
			{
				var fixture = new Fixture().Customize(new AutoMoqCustomization());
				var sut = fixture.Create<RotateArrayInPlaceWithTmpArray>();
				int[] source = { 1, 2, 4, 7, 8, 12, 15, 19, 24, 50, 69, 80, 100 };
				int[] res;

				res = sut.Rotate(source, 13, RotationType.Right);
				res.Should().ContainInOrder(1, 2, 4, 7, 8, 12, 15, 19, 24, 50, 69, 80, 100);

				res = sut.Rotate(source, 39, RotationType.Right);
				res.Should().ContainInOrder(1, 2, 4, 7, 8, 12, 15, 19, 24, 50, 69, 80, 100);

				res = sut.Rotate(source, 3, RotationType.Right);
				res.Should().ContainInOrder(69, 80, 100, 1, 2, 4, 7, 8, 12, 15, 19, 24, 50);

				source = new[] { 4, 6, 1, 0, -1 };
				res = sut.Rotate(source, 7, RotationType.Right);
				res.Should().ContainInOrder(0, -1, 4, 6, 1);

				source = new[] { 4, 6, 1, 0, -1 };
				res = sut.Rotate(source, 1, RotationType.Right);
				res.Should().ContainInOrder(-1, 4, 6, 1, 0);

				source = new[] { 4 };
				res = sut.Rotate(source, 7, RotationType.Right);
				res.Should().ContainInOrder(4);

				source = new[] { 4, 5 };
				res = sut.Rotate(source, 7, RotationType.Right);
				res.Should().ContainInOrder(5, 4);

				source = new[] { 4, 5, 8 };
				res = sut.Rotate(source, 7, RotationType.Right);
				res.Should().ContainInOrder(8, 4, 5);
			}

			[TestMethod]
			public void It_should_rotate_the_array_to_the_left()
			{
				var fixture = new Fixture().Customize(new AutoMoqCustomization());
				var sut = fixture.Create<RotateArrayInPlaceWithTmpArray>();
				int[] source = { 1, 2, 4, 7, 8, 12, 15, 19, 24, 50, 69, 80, 100 };
				int[] res;

				res = sut.Rotate(source, 13, RotationType.Left);
				res.Should().ContainInOrder(1, 2, 4, 7, 8, 12, 15, 19, 24, 50, 69, 80, 100);

				res = sut.Rotate(source, 39, RotationType.Left);
				res.Should().ContainInOrder(1, 2, 4, 7, 8, 12, 15, 19, 24, 50, 69, 80, 100);

				res = sut.Rotate(source, 3, RotationType.Left);
				res.Should().ContainInOrder(7, 8, 12, 15, 19, 24, 50, 69, 80, 100, 1, 2, 4);

				source = new[] { 4, 6, 1, 0, -1 };
				res = sut.Rotate(source, 7, RotationType.Left);
				res.Should().ContainInOrder(1, 0, -1, 4, 6);

				source = new[] { 4, 6, 1, 0, -1 };
				res = sut.Rotate(source, 1, RotationType.Left);
				res.Should().ContainInOrder(6, 1, 0, -1, 4);

				source = new[] { 4 };
				res = sut.Rotate(source, 7, RotationType.Left);
				res.Should().ContainInOrder(4);

				source = new[] { 4, 5 };
				res = sut.Rotate(source, 7, RotationType.Left);
				res.Should().ContainInOrder(5, 4);

				source = new[] { 4, 5, 8 };
				res = sut.Rotate(source, 7, RotationType.Left);
				res.Should().ContainInOrder(5, 8, 4);
			}
		}
	}
}
