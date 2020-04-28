using System;
using System.Collections;
using System.Collections.Generic;

namespace Core.Domain.Queues
{
	public class QueueWithArraysCollection<T> : IEnumerable<T>
	{
		private readonly T[] _storage = new T[1000];
		private int _front = -1;
		private int _rear = -1;

		public bool IsEmpty()
		{
			return _front == -1 && _rear == -1;
		}

		public void Enqueue(T item)
		{
			if (IsStorageFull())
			{
				throw new Exception("Queue is full");
			}

			if (IsEmpty())
			{
				_storage[0] = item;
				_front = 0;
				_rear = 0;
			}

			_storage[++_rear] = item;
		}

		public T Dequeue()
		{
			if (IsEmpty())
			{
				throw new Exception("Queue is full");
			}

			if (_front == _rear)
			{
				T tmp = _storage[_front];

				_front = -1;
				_rear = -1;

				return tmp;
			}

			return _storage[_front++];
		}

		public T Peek()
		{
			if (IsEmpty())
			{
				throw new Exception("Queue is empty");
			}

			return _storage[_front++];
		}

		public IEnumerator<T> GetEnumerator()
		{
			throw new System.NotImplementedException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		private bool IsStorageFull()
		{
			return _rear == _storage.Length - 1;
		}
	}
}
