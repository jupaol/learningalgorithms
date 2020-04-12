using System;

namespace Core.Domain.LinkedLists
{
	public static class ReverseLinkedList
	{
		public static SingleLinkedListNode<T> Reverse<T>(this ISingleLinkedListCollection<T> source)
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			SingleLinkedListNode<T> current = source.Head;
			SingleLinkedListNode<T> prev = null;

			while (current != null)
			{
				SingleLinkedListNode<T> next = current.Next;

				current.Next = prev;
				prev = current;

				current = next;
			}

			source.Head = prev;

			return prev;
		}

		public static SingleLinkedListNode<T> ReverseRecursive<T>(this ISingleLinkedListCollection<T> source)
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			if (source.Head == null)
			{
				return null;
			}

			source.Head = DoReverseRecursive(source, source.Head);

			return source.Head;
		}

		private static SingleLinkedListNode<T> DoReverseRecursive<T>(
			ISingleLinkedListCollection<T> source, SingleLinkedListNode<T> current)
		{
			if (current.Next == null)
			{
				source.Head = current;
				return current;
			}

			SingleLinkedListNode<T> newHead = DoReverseRecursive(source, current.Next);

			SingleLinkedListNode<T> next = current.Next;

			next.Next = current;
			current.Next = null;

			return newHead;
		}
	}
}
