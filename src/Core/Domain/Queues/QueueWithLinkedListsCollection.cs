using System;
using System.Collections;
using System.Collections.Generic;
using Core.Domain.LinkedLists;

namespace Core.Domain.Queues
{
	public class QueueWithLinkedListsCollection<T> : IEnumerable<T>
	{
		private SingleLinkedListNode<T> _head;
		private SingleLinkedListNode<T> _rear;

		public bool IsEmpty()
		{
			return _head == null;
		}

		public void Enqueue(T item)
		{
			var newItem = new SingleLinkedListNode<T>(item);

			if (_head == null && _rear == null)
			{
				_head = newItem;
				_rear = newItem;

				return;
			}

			_rear.Next = newItem;
			_rear = newItem;
		}

		public T Dequeue()
		{
			if (_head == null)
			{
				throw new Exception("Queue is empty");
			}

			if (_rear == _head)
			{
				_rear = null;
			}

			T tmp = _head.Item;

			_head = _head.Next;

			return tmp;
		}

		public T Peek()
		{
			if (_head == null)
			{
				throw new Exception("Queue is empty");
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
