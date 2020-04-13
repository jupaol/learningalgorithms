using System;

namespace Core.Domain.LinkedLists
{
	public static class MergeLists
	{
		public static SingleLinkedListNode<T> Merge<T>(
			this ISingleLinkedListCollection<T> list1,
			ISingleLinkedListCollection<T> list2)
			where T : IComparable<T>
		{
			SingleLinkedListNode<T> h1 = list1?.Head;
			SingleLinkedListNode<T> h2 = list2?.Head;

			if (h1 == null && h2 == null)
			{
				return null;
			}

			if (h1 != null && h2 == null)
			{
				return h1;
			}

			if (h1 == null)
			{
				return h2;
			}

			SingleLinkedListNode<T> c1 = h1;
			SingleLinkedListNode<T> c2 = h2;
			SingleLinkedListNode<T> prev = null;
			SingleLinkedListNode<T> sorted = null;

			while (c1 != null && c2 != null)
			{
				if (c1.Item.CompareTo(c2.Item) <= 0)
				{
					if (sorted == null)
					{
						sorted = c1;
					}
					else
					{
						prev.Next = c1;
					}

					prev = c1;
					c1 = c1.Next;
				}
				else
				{
					if (sorted == null)
					{
						sorted = c2;
					}
					else
					{
						prev.Next = c2;
					}

					prev = c2;
					c2 = c2.Next;
				}
			}

			while (c1 != null)
			{
				prev.Next = c1;
				prev = c1;
				c1 = c1.Next;
			}

			while (c2 != null)
			{
				prev.Next = c2;
				prev = c2;
				c2 = c2.Next;
			}

			return sorted;
		}
	}
}
