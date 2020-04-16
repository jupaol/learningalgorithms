using System;
using System.Collections.Generic;

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

		public static SingleLinkedListNode<T> ReverseEvenNodes<T>(
			this ISingleLinkedListCollection<T> source)
		{
			if (source?.Head == null)
			{
				return null;
			}

			SingleLinkedListNode<T> odd = source.Head;
			SingleLinkedListNode<T> evens = null;

			while (odd?.Next != null)
			{
				SingleLinkedListNode<T> even = odd.Next;

				odd.Next = even.Next;
				odd = even.Next;

				even.Next = evens;
				evens = even;
			}

			odd = source.Head;
			SingleLinkedListNode<T> e = evens;

			while (odd != null && e != null)
			{
				SingleLinkedListNode<T> tmpOdd = odd.Next;
				SingleLinkedListNode<T> tmpEven = e.Next;

				odd.Next = e;
				e.Next = tmpOdd;

				odd = tmpOdd;
				e = tmpEven;
			}

			return source.Head;
		}

		public static SingleLinkedListNode<T> ReverseOddNodes<T>(
			this ISingleLinkedListCollection<T> source)
		{
			if (source?.Head == null)
			{
				return null;
			}

			SingleLinkedListNode<T> tmp = source.Head.Next;

			source.Head.Next = null;

			SingleLinkedListNode<T> odds = source.Head;
			SingleLinkedListNode<T> evens = null;
			SingleLinkedListNode<T> even = tmp;

			while (even != null)
			{
				evens ??= even;

				SingleLinkedListNode<T> odd = even.Next;

				if (odd == null)
				{
					even.Next = null;
					even = null;
				}
				else
				{
					even.Next = odd.Next;
					even = odd.Next;

					odd.Next = odds;
					odds = odd;
				}
			}

			SingleLinkedListNode<T> o = odds;
			SingleLinkedListNode<T> e = evens;

			while (o != null && e != null)
			{
				SingleLinkedListNode<T> tmpO = o.Next;
				SingleLinkedListNode<T> tmpE = e.Next;

				o.Next = e;
				e.Next = tmpO;

				o = tmpO;
				e = tmpE;
			}

			return odds;
		}

		public static SingleLinkedListNode<T> ReverseNodesInRange<T>(
			this ISingleLinkedListCollection<T> source, int groupBy)
		{
			if (source?.Head == null)
			{
				return null;
			}

			if (groupBy <= 1)
			{
				return source.Head;
			}

			SingleLinkedListNode<T> current = source.Head;
			SingleLinkedListNode<T> newHead = null;
			SingleLinkedListNode<T> prevTail = null;

			while (current != null)
			{
				SingleLinkedListNode<T> currentHead = null;
				SingleLinkedListNode<T> currentTail = current;
				int count = groupBy;

				while (current != null && count > 0)
				{
					SingleLinkedListNode<T> tmp = current.Next;

					current.Next = currentHead;
					currentHead = current;

					count--;
					current = tmp;
				}

#pragma warning disable S2589 // Boolean expressions should not be gratuitous
				newHead ??= currentHead;
#pragma warning restore S2589 // Boolean expressions should not be gratuitous

				if (prevTail != null)
				{
					prevTail.Next = currentHead;
				}

				prevTail = currentTail;
			}

			return newHead;
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
