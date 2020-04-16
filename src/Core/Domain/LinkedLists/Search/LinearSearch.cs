namespace Core.Domain.LinkedLists.Search
{
	public static class LinearSearch
	{
		public static SingleLinkedListNode<T> SearchUsingLinear<T>(
			this ISingleLinkedListCollection<T> source, T item)
		{
			if (source?.Head == null)
			{
				return null;
			}

			SingleLinkedListNode<T> current = source.Head;

			while (current != null)
			{
				if (current.Item.Equals(item))
				{
					return current;
				}

				current = current.Next;
			}

			return null;
		}
	}
}
