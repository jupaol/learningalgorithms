using System.Collections.Generic;

namespace Core.Domain.LinkedLists
{
	public static class DeepCloneList
	{
		public static SingleLinkedListNode<T> DeepClone<T>(
			this ISingleLinkedListCollection<T> source)
		{
			if (source?.Head == null)
			{
				return null;
			}

			SingleLinkedListNode<T> newHead = null;
			SingleLinkedListNode<T> newHeadCurrent = null;
			SingleLinkedListNode<T> current = source.Head;
			var dictionary = new Dictionary<SingleLinkedListNode<T>, SingleLinkedListNode<T>>(
				GetLength(source.Head));

			while (current != null)
			{
				var newNode = new SingleLinkedListNode<T>(current.Item)
				{
					ArbitraryLink = current.ArbitraryLink,
				};

				newHead ??= newNode;

				if (newHeadCurrent != null)
				{
					newHeadCurrent.Next = newNode;
				}

				newHeadCurrent = newNode;

				dictionary.Add(current, newNode);

				current = current.Next;
			}

			current = newHead;

			while (current != null)
			{
				if (current.ArbitraryLink != null)
				{
					current.ArbitraryLink = dictionary[current.ArbitraryLink];
				}

				current = current.Next;
			}

			return newHead;
		}

		private static int GetLength<T>(SingleLinkedListNode<T> head)
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
