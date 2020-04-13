using System;
using System.Collections;
using System.Collections.Generic;

namespace Core.Domain.LinkedLists
{
	public class SingleLinkedListCollection<T> : ISingleLinkedListCollection<T>
	{
		public SingleLinkedListNode<T> Head { get; set; }

		public SingleLinkedListNode<T> AddLast(T item)
		{
			if (Head == null)
			{
				Head = new SingleLinkedListNode<T>(item);

				return Head;
			}

			SingleLinkedListNode<T> current = Head;

			while (current.Next != null)
			{
				current = current.Next;
			}

			current.Next = new SingleLinkedListNode<T>(item);

			return current.Next;
		}

		public void AddManyAtEnd(params T[] items)
		{
			if (items == null)
			{
				throw new ArgumentNullException(nameof(items));
			}

			for (int i = 0; i < items.Length; i++)
			{
				AddLast(items[i]);
			}
		}

		public SingleLinkedListNode<T> AddFirst(T item)
		{
			var node = new SingleLinkedListNode<T>(item);

			if (Head == null)
			{
				Head = node;

				return Head;
			}

			node.Next = Head.Next;
			Head = node;

			return Head;
		}

		public void AddManyAtStart(params T[] items)
		{
			if (items == null)
			{
				throw new ArgumentNullException(nameof(items));
			}

			for (int i = 0; i < items.Length; i++)
			{
				AddFirst(items[i]);
			}
		}

		public void Clear()
		{
			Head = null;
		}

		public SingleLinkedListNode<T> GetAtIndex(int index)
		{
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(index));
			}

			if (Head == null)
			{
				return null;
			}

			int count = 0;
			SingleLinkedListNode<T> current = Head;

			while (current != null && count < index)
			{
				count++;
				current = current.Next;
			}

			return current;
		}

		public SingleLinkedListNode<T> GetAtIndexFromTail(int index)
		{
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(index));
			}

			if (Head == null)
			{
				return null;
			}

			int count = 0;
			SingleLinkedListNode<T> current = Head;
			SingleLinkedListNode<T> prev = Head;

			while (current != null && count <= index)
			{
				count++;
				current = current.Next;
			}

			if (count <= index)
			{
				// index grater than list size
				return null;
			}

			while (current != null)
			{
				current = current.Next;
				prev = prev.Next;
			}

			return prev;
		}

		public T[] ToArray()
		{
			return ToArray(Head);
		}

		public T[] ToArray(SingleLinkedListNode<T> head)
		{
			SingleLinkedListNode<T> current = head;
			var list = new List<T>();

			while (current != null)
			{
				list.Add(current.Item);

				current = current.Next;
			}

			return list.ToArray();
		}

		public IEnumerator<SingleLinkedListNode<T>> GetEnumerator()
		{
			SingleLinkedListNode<T> current = Head;

			while (current != null)
			{
				yield return current;

				current = current.Next;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
