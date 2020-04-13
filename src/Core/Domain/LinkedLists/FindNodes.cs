using System;

namespace Core.Domain.LinkedLists
{
	public static class FindNodes
	{
		public static SingleLinkedListNode<T> FindNthNodeFromTail<T>(
			this ISingleLinkedListCollection<T> source, int position)
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			if (source.Head == null)
			{
				return null;
			}

			if (position <= 0)
			{
				return null;
			}

			int i = 1;
			SingleLinkedListNode<T> current = source.Head;
			SingleLinkedListNode<T> target = source.Head;

			while (current != null && i <= position)
			{
				i++;
				current = current.Next;
			}

			if (i <= position)
			{
				return null;
			}

			while (current != null)
			{
				current = current.Next;
				target = target.Next;
			}

			return target;
		}
	}
}
