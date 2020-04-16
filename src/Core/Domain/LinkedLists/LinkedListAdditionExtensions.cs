namespace Core.Domain.LinkedLists
{
	public static class LinkedListAdditionExtensions
	{
		public static SingleLinkedListNode<int> AddTwoListsWithNumbersInverted(
			this ISingleLinkedListCollection<int> list1,
			ISingleLinkedListCollection<int> list2)
		{
			SingleLinkedListNode<int> head1 = list1?.Head;
			SingleLinkedListNode<int> head2 = list2?.Head;

			if (head1 == null && head2 == null)
			{
				return null;
			}

			if (head1 != null && head2 == null)
			{
				return head1;
			}

			if (head1 == null)
			{
				return list2.Head;
			}

			SingleLinkedListNode<int> c1 = head1;
			SingleLinkedListNode<int> c2 = head2;
			SingleLinkedListNode<int> result = null;
			SingleLinkedListNode<int> prev = null;
			int carry = 0;

			while (c1 != null || c2 != null)
			{
				int sum = carry;

				if (c1 != null)
				{
					sum += c1.Item;
				}

				if (c2 != null)
				{
					sum += c2.Item;
				}

				var node = new SingleLinkedListNode<int>(sum % 10);

				carry = sum / 10;

				result ??= node;

				if (prev != null)
				{
					prev.Next = node;
				}

				prev = node;

				c1 = c1?.Next;
				c2 = c2?.Next;
			}

			if (carry > 0)
			{
				prev.Next = new SingleLinkedListNode<int>(carry);
			}

			return result;
		}
	}
}
