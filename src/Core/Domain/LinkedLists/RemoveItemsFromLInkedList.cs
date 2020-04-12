using System;
using System.Collections.Generic;

namespace Core.Domain.LinkedLists
{
	public static class RemoveItemsFromLInkedList
	{
		public static SingleLinkedListNode<T> RemoveDuplicates<T>(
			this ISingleLinkedListCollection<T> source)
			where T : IComparable<T>
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			var hashSet = new HashSet<T>();

			if (source.Head == null)
			{
				return null;
			}

			SingleLinkedListNode<T> current = source.Head;
			SingleLinkedListNode<T> prev = source.Head;

			while (current != null)
			{
				if (hashSet.Contains(current.Item))
				{
					prev.Next = current.Next;
				}
				else
				{
					hashSet.Add(current.Item);
				}

				prev = current;
				current = current.Next;
			}

			return source.Head;
		}

#pragma warning disable S3900 // Arguments of public methods should be validated against null
		public static SingleLinkedListNode<T> RemoveItems<T>(
			this ISingleLinkedListCollection<T> source, T key)
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

			SingleLinkedListNode<T> current = source.Head;
			SingleLinkedListNode<T> prev = null;
			SingleLinkedListNode<T> head = source.Head;

			while (current != null)
			{
				if (current.Item.Equals(key))
				{
					if (prev == null)
					{
						head = current.Next;
					}
					else
					{
						prev.Next = current.Next;
						prev = current;
					}
				}
				else
				{
					prev = current;
				}

				current = current.Next;
			}

			source.Head = head;

			return head;
		}
#pragma warning restore S3900 // Arguments of public methods should be validated against null
	}
}
