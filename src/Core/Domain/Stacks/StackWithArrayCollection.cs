using System;
using System.Collections;
using System.Collections.Generic;

namespace Core.Domain.Stacks
{
	public class StackWithArrayCollection<T> : IEnumerable<T>
	{
		private readonly T[] _stackStorage = new T[1000];

		private int _currentIndex = -1;

		public bool IsEmpty()
		{
			return _currentIndex < 0;
		}

		public void Push(T item)
		{
			if (_currentIndex + 1 >= _stackStorage.Length)
			{
				throw new Exception("Stack is full");
			}

			_stackStorage[++_currentIndex] = item;
		}

		public T Pop()
		{
			if (_currentIndex < 0)
			{
				throw new Exception("Stack is empty");
			}

			return _stackStorage[_currentIndex--];
		}

		public T Peek()
		{
			if (_currentIndex < 0)
			{
				throw new Exception("Stack is empty");
			}

			return _stackStorage[_currentIndex];
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
