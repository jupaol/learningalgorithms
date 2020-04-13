using System.Collections.Generic;

namespace Core.Domain.LinkedLists
{
	public interface ISingleLinkedListCollection<T> : IEnumerable<SingleLinkedListNode<T>>
	{
		SingleLinkedListNode<T> Head { get; set; }

		SingleLinkedListNode<T> AddLast(T item);

		void AddManyAtEnd(params T[] items);

		SingleLinkedListNode<T> AddFirst(T item);

		void AddManyAtStart(params T[] items);

		void Clear();

		SingleLinkedListNode<T> GetAtIndex(int index);

		SingleLinkedListNode<T> GetAtIndexFromTail(int index);

		T[] ToArray();

		T[] ToArray(SingleLinkedListNode<T> head);
	}
}
