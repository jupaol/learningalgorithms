using System;
using Core.Domain.LinkedLists;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.LinkedLists
{
	[TestClass]
	public class LinkedListAdditionExtensionsTests
	{
		[TestClass]
		public class TheAddTwoListsWithNumbersInvertedMethod
		{
			[TestMethod]
			public void It_shold_add_two_numbers_represented_by_two_linked_lists()
			{
				int[] s1;
				int[] s2;
				var l1 = new SingleLinkedListCollection<int>();
				var l2 = new SingleLinkedListCollection<int>();
				SingleLinkedListNode<int> res;

				s1 = new[] { 3, 4, 5 }; // 543
				s2 = new[] { 4, 5, 6 }; // 654
				l1.Clear();
				l1.AddManyAtEnd(s1);
				l2.Clear();
				l2.AddManyAtEnd(s2);
				res = l1.AddTwoListsWithNumbersInverted(l2);
				l1.ToArray(res).Should().ContainInOrder(7, 9, 1, 1);

				s1 = new[] { 3, 4, 5 }; // 543
				s2 = Array.Empty<int>();
				l1.Clear();
				l1.AddManyAtEnd(s1);
				l2.Clear();
				l2.AddManyAtEnd(s2);
				res = l1.AddTwoListsWithNumbersInverted(l2);
				l1.ToArray(res).Should().ContainInOrder(3, 4, 5);

				s1 = Array.Empty<int>();
				s2 = new[] { 4, 5, 6 }; // 654
				l1.Clear();
				l1.AddManyAtEnd(s1);
				l2.Clear();
				l2.AddManyAtEnd(s2);
				res = l1.AddTwoListsWithNumbersInverted(l2);
				l1.ToArray(res).Should().ContainInOrder(4, 5, 6);

				s1 = new[] { 3 }; // 3
				s2 = new[] { 4 }; // 4
				l1.Clear();
				l1.AddManyAtEnd(s1);
				l2.Clear();
				l2.AddManyAtEnd(s2);
				res = l1.AddTwoListsWithNumbersInverted(l2);
				l1.ToArray(res).Should().ContainInOrder(7);

				s1 = new[] { 3, 4, 5 }; // 543
				s2 = new[] { 9 }; // 9
				l1.Clear();
				l1.AddManyAtEnd(s1);
				l2.Clear();
				l2.AddManyAtEnd(s2);
				res = l1.AddTwoListsWithNumbersInverted(l2);
				l1.ToArray(res).Should().ContainInOrder(2, 5, 5);
			}
		}
	}
}
