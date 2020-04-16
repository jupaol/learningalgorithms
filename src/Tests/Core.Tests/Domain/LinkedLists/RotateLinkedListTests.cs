using Core.Domain.LinkedLists;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.LinkedLists
{
	[TestClass]
	public static class RotateLinkedListTests
	{
		[TestClass]
		public class TheRotateMethod
		{
			[TestMethod]
			public void It_should_rotate_the_linked_list_to_the_right()
			{
				SingleLinkedListCollection<int> sut = new SingleLinkedListCollection<int>();
				int[] source;
				SingleLinkedListNode<int> res;

				source = new[] { 1, 2, 4, 7, 8, 12, 15, 19, 24, 50, 69, 80, 100 };
				sut.Clear();
				sut.AddManyAtEnd(source);
				res = sut.Rotate(13);
				sut.ToArray(res).Should().ContainInOrder(1, 2, 4, 7, 8, 12, 15, 19, 24, 50, 69, 80, 100);

				sut.Clear();
				sut.AddManyAtEnd(source);
				res = sut.Rotate(39);
				sut.ToArray(res).Should().ContainInOrder(1, 2, 4, 7, 8, 12, 15, 19, 24, 50, 69, 80, 100);

				sut.Clear();
				sut.AddManyAtEnd(source);
				res = sut.Rotate(3);
				sut.ToArray(res).Should().ContainInOrder(69, 80, 100, 1, 2, 4, 7, 8, 12, 15, 19, 24, 50);

				source = new[] { 4, 6, 1, 0, -1 };
				sut.Clear();
				sut.AddManyAtEnd(source);
				res = sut.Rotate(7);
				sut.ToArray(res).Should().ContainInOrder(0, -1, 4, 6, 1);

				source = new[] { 4, 6, 1, 0, -1 };
				sut.Clear();
				sut.AddManyAtEnd(source);
				res = sut.Rotate(1);
				sut.ToArray(res).Should().ContainInOrder(-1, 4, 6, 1, 0);

				source = new[] { 4 };
				sut.Clear();
				sut.AddManyAtEnd(source);
				res = sut.Rotate(7);
				sut.ToArray(res).Should().ContainInOrder(4);

				source = new[] { 4, 5 };
				sut.Clear();
				sut.AddManyAtEnd(source);
				res = sut.Rotate(7);
				sut.ToArray(res).Should().ContainInOrder(5, 4);

				source = new[] { 4, 5, 8 };
				sut.Clear();
				sut.AddManyAtEnd(source);
				res = sut.Rotate(7);
				sut.ToArray(res).Should().ContainInOrder(8, 4, 5);
			}

			[TestMethod]
			public void It_should_rotate_the_linked_list_to_the_left()
			{
				SingleLinkedListCollection<int> sut = new SingleLinkedListCollection<int>();
				int[] source;
				SingleLinkedListNode<int> res;

				source = new[] { 1, 2, 4, 7, 8, 12, 15, 19, 24, 50, 69, 80, 100 };
				sut.Clear();
				sut.AddManyAtEnd(source);
				res = sut.Rotate(-13);
				sut.ToArray(res).Should().ContainInOrder(1, 2, 4, 7, 8, 12, 15, 19, 24, 50, 69, 80, 100);

				sut.Clear();
				sut.AddManyAtEnd(source);
				res = sut.Rotate(-39);
				sut.ToArray(res).Should().ContainInOrder(1, 2, 4, 7, 8, 12, 15, 19, 24, 50, 69, 80, 100);

				sut.Clear();
				sut.AddManyAtEnd(source);
				res = sut.Rotate(-3);
				sut.ToArray(res).Should().ContainInOrder(7, 8, 12, 15, 19, 24, 50, 69, 80, 100, 1, 2, 4);

				source = new[] { 4, 6, 1, 0, -1 };
				sut.Clear();
				sut.AddManyAtEnd(source);
				res = sut.Rotate(-7);
				sut.ToArray(res).Should().ContainInOrder(1, 0, -1, 4, 6);

				source = new[] { 4, 6, 1, 0, -1 };
				sut.Clear();
				sut.AddManyAtEnd(source);
				res = sut.Rotate(-1);
				sut.ToArray(res).Should().ContainInOrder(6, 1, 0, -1, 4);

				source = new[] { 4 };
				sut.Clear();
				sut.AddManyAtEnd(source);
				res = sut.Rotate(-7);
				sut.ToArray(res).Should().ContainInOrder(4);

				source = new[] { 4, 5 };
				sut.Clear();
				sut.AddManyAtEnd(source);
				res = sut.Rotate(-7);
				sut.ToArray(res).Should().ContainInOrder(5, 4);

				source = new[] { 4, 5, 8 };
				sut.Clear();
				sut.AddManyAtEnd(source);
				res = sut.Rotate(-7);
				sut.ToArray(res).Should().ContainInOrder(5, 8, 4);
			}
		}
	}
}
