namespace Core.Domain.LinkedLists
{
	public class SingleLinkedListNode<T>
	{
		public SingleLinkedListNode()
		{
		}

		public SingleLinkedListNode(T item)
		{
			Item = item;
		}

		public T Item { get; set; }

		public SingleLinkedListNode<T> Next { get; set; }
	}
}
