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

		public T[] ToArray()
		{
			SingleLinkedListNode<T> current = Head;
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
