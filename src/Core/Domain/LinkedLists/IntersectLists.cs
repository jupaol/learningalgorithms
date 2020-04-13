using System;

namespace Core.Domain.LinkedLists
{
	public static class IntersectLists
	{
		public static SingleLinkedListNode<T> Intersect<T>(
			this ISingleLinkedListCollection<T> list1,
			ISingleLinkedListCollection<T> list2)
		{
			if (list1 == null || list2 == null)
			{
				return null;
			}

			int l1 = GetListLength(list1);
			int l2 = GetListLength(list2);
			int dif = Math.Abs(l1 - l2);

			SingleLinkedListNode<T> c1 = list1.Head;
			SingleLinkedListNode<T> c2 = list2.Head;

			if (l1 != l2)
			{
				int count = 0;

				if (l1 > l2)
				{
					while (c1 != null && count < dif)
					{
						count++;
						c1 = c1.Next;
					}
				}
				else
				{
					while (c2 != null && count < dif)
					{
						count++;
						c2 = c2.Next;
					}
				}
			}

			while (c1 != null && c2 != null)
			{
				if (c1 == c2 && c1.Item.Equals(c2.Item))
				{
					return c1;
				}

				c1 = c1.Next;
				c2 = c2.Next;
			}

			return null;
		}

		private static int GetListLength<T>(ISingleLinkedListCollection<T> source)
		{
			int count = 0;
			SingleLinkedListNode<T> current = source.Head;

			while (current != null)
			{
				count++;
				current = current.Next;
			}

			return count;
		}
	}
}
