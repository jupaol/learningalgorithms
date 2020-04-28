using System;
using System.Collections;
using System.Collections.Generic;
using Core.Domain.LinkedLists;

namespace Core.Domain.Stacks
{
	public class StackWithLinkedListsCollection<T> : IEnumerable<T>
	{
		private SingleLinkedListNode<T> _head;

		public bool IsEmpty()
		{
			return _head == null;
		}

		public void Push(T item)
		{
			var newItem = new SingleLinkedListNode<T>(item);

			if (_head == null)
			{
				_head = newItem;

				return;
			}

			newItem.Next = _head;
			_head = newItem;
		}

		public T Pop()
		{
			if (_head == null)
			{
				throw new Exception("Stack is empty");
			}

			T tmp = _head.Item;

			_head = _head.Next;

			return tmp;
		}

		public T Peek()
		{
			if (_head == null)
			{
				throw new Exception("Stack is empty");
			}

			return _head.Item;
		}

		public IEnumerator<T> GetEnumerator()
		{
			throw new System.NotImplementedException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
