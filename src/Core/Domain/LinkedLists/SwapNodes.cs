using System;

namespace Core.Domain.LinkedLists
{
	public static class SwapNodes
	{
		public static SingleLinkedListNode<T> SwapNthNodeWithHead<T>(
			this ISingleLinkedListCollection<T> source, int positions)
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			if (source.Head == null)
			{
				return null;
			}

			if (positions <= 1)
			{
				return source.Head;
			}

			SingleLinkedListNode<T> prev = null;
			SingleLinkedListNode<T> current = source.Head;

			for (int i = 1; i < positions && current != null; i++)
			{
				prev = current;
				current = current.Next;
			}

			if (prev == null || current == null)
			{
				return source.Head;
			}

			SingleLinkedListNode<T> head = source.Head;

			prev.Next = head;

			SingleLinkedListNode<T> tmp = head.Next;

			head.Next = current.Next;
			current.Next = tmp;

			source.Head = current;

			return source.Head;
		}
	}
}
