namespace Core.Domain.LinkedLists
{
	public static class RotateLinkedList
	{
		public static SingleLinkedListNode<T> Rotate<T>(
			this ISingleLinkedListCollection<T> source, int positions)
		{
			if (source?.Head == null)
			{
				return null;
			}

			if (positions == 0)
			{
				return source.Head;
			}

			int length = GetListLength(source.Head);
			int offset = positions % length;

			if (offset == 0)
			{
				return source.Head;
			}

			if (offset < 0)
			{
				offset += length;
			}

			int maxRotationsCount = length - offset - 1;
			SingleLinkedListNode<T> current = source.Head;

			while (maxRotationsCount > 0)
			{
				current = current.Next;
				maxRotationsCount--;
			}

			SingleLinkedListNode<T> newHead = current.Next;

			current.Next = null;
			current = newHead;

			while (current.Next != null)
			{
				current = current.Next;
			}

			current.Next = source.Head;

			return newHead;
		}

		private static int GetListLength<T>(SingleLinkedListNode<T> head)
		{
			int count = 0;
			SingleLinkedListNode<T> current = head;

			while (current != null)
			{
				count++;
				current = current.Next;
			}

			return count;
		}
	}
}
