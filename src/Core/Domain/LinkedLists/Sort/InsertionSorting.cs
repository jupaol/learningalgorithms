using System;

namespace Core.Domain.LinkedLists.Sort
{
	public static class InsertionSorting
	{
		public static SingleLinkedListNode<T> SortUsingInsertion<T>(this ISingleLinkedListCollection<T> source)
			where T : IComparable<T>
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			if (source.Head == null)
			{
				return null;
			}

			SingleLinkedListNode<T> c = source.Head;
			SingleLinkedListNode<T> sortedHead = null;

			while (c != null)
			{
				SingleLinkedListNode<T> tmp = c.Next;

				sortedHead = InsertElement(c, sortedHead);

				c = tmp;
			}

			source.Head = sortedHead;

			return source.Head;
		}

		private static SingleLinkedListNode<T> InsertElement<T>(
			SingleLinkedListNode<T> incomingNode, SingleLinkedListNode<T> sortedHead)
			where T : IComparable<T>
		{
			incomingNode.Next = null;

			if (sortedHead == null)
			{
				return incomingNode;
			}

			SingleLinkedListNode<T> current = sortedHead;
			SingleLinkedListNode<T> prev = null;

			while (current?.Item.CompareTo(incomingNode.Item) <= 0)
			{
				prev = current;
				current = current.Next;
			}

			if (prev == null)
			{
				// head points to incoming node
				incomingNode.Next = sortedHead;
				sortedHead = incomingNode;
			}
			else if (prev.Next == null)
			{
				// new node goes at the end
				prev.Next = incomingNode;
			}
			else
			{
				// new node goes in the middle
				SingleLinkedListNode<T> tmp = prev.Next;

				prev.Next = incomingNode;
				incomingNode.Next = tmp;
			}

			return sortedHead;
		}
	}
}
