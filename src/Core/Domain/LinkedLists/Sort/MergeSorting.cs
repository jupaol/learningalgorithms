using System;

namespace Core.Domain.LinkedLists.Sort
{
	public static class MergeSorting
	{
		public static SingleLinkedListNode<T> SortUsingMerge<T>(
			this ISingleLinkedListCollection<T> source)
			where T : IComparable<T>
		{
			if (source == null)
			{
				return null;
			}

			return DoMergeSort(source.Head);
		}

		private static SingleLinkedListNode<T> DoMergeSort<T>(SingleLinkedListNode<T> head)
			where T : IComparable<T>
		{
			if (head?.Next == null)
			{
				return head;
			}

			SingleLinkedListNode<T> fast = head.Next;
			SingleLinkedListNode<T> slow = head;

			while (fast != null)
			{
				fast = fast.Next;

				if (fast != null)
				{
					fast = fast.Next;
					slow = slow.Next;
				}
			}

			SingleLinkedListNode<T> l1 = head;
			SingleLinkedListNode<T> l2 = slow.Next;

			slow.Next = null;

			SingleLinkedListNode<T> first = DoMergeSort(l1);
			SingleLinkedListNode<T> second = DoMergeSort(l2);

			return Merge(first, second);
		}

		private static SingleLinkedListNode<T> Merge<T>(
			SingleLinkedListNode<T> head1,
			SingleLinkedListNode<T> head2)
			where T : IComparable<T>
		{
			if (head1 == null && head2 == null)
			{
				return null;
			}

			if (head1 != null && head2 == null)
			{
				return head1;
			}

			if (head1 == null)
			{
				return head2;
			}

			SingleLinkedListNode<T> c1 = head1;
			SingleLinkedListNode<T> c2 = head2;
			SingleLinkedListNode<T> sorted = null;
			SingleLinkedListNode<T> prev = null;

			while (c1 != null && c2 != null)
			{
				SingleLinkedListNode<T> tmp;

				if (c1.Item.CompareTo(c2.Item) <= 0)
				{
					tmp = c1;
					c1 = c1.Next;
				}
				else
				{
					tmp = c2;
					c2 = c2.Next;
				}

				if (sorted == null)
				{
					sorted = tmp;
					prev = tmp;
				}

				prev.Next = tmp;
				prev = tmp;
			}

			prev.Next = c1 ?? c2;

			return sorted;
		}
	}
}
