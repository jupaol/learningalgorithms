using System;
using System.Collections;
using System.Collections.Generic;

namespace Core.Domain.Queues
{
	public class QueueWithCircularArraysCollection<T> : IEnumerable<T>
	{
		private readonly T[] _storage = new T[10];
		private int _front = -1;
		private int _rear = -1;

		public bool IsEmpty()
		{
			return _front == -1 && _rear == -1;
		}

		public void Enqueue(T item)
		{
			if (IsFull())
			{
				throw new Exception("Queue is full");
			}

			if (IsEmpty())
			{
				_storage[0] = item;
				_front = 0;
				_rear = 0;

				return;
			}

			_rear = NextIndex(_rear);
			_storage[_rear] = item;
		}

		public T Dequeue()
		{
			if (IsEmpty())
			{
				throw new Exception("Queue is empty");
			}

			T tmp = _storage[_front];

			if (_front == _rear)
			{
				_front = -1;
				_rear = -1;
			}
			else
			{
				_front = NextIndex(_front);
			}

			return tmp;
		}

		public T Peek()
		{
			if (IsEmpty())
			{
				throw new Exception("Queue is empty");
			}

			return _storage[_front];
		}

		public bool IsFull()
		{
			if (IsEmpty())
			{
				return false;
			}

			return NextIndex(_rear) == _front;
		}

		public int NextIndex(int i)
		{
			// (i + 1) % n
			return (i + 1) % _storage.Length;
		}

		public int PrevIndex(int i)
		{
			// (i + n - 1) % n
			return (i + _storage.Length - 1) % _storage.Length;
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
