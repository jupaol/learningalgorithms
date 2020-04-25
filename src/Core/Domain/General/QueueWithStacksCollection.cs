using System;
using System.Collections;
using System.Collections.Generic;

namespace Core.Domain.General
{
	public class QueueWithStacksCollection<T> : IEnumerable<T>
	{
		private readonly Stack<T> _reading = new Stack<T>();

		private readonly Stack<T> _writing = new Stack<T>();

		public void EnqueueReadOptimized(T item)
		{
			if (_reading.Count == 0)
			{
				_reading.Push(item);
			}
			else
			{
				Move(_reading, _writing);
				_writing.Push(item);
				Move(_writing, _reading);
			}
		}

		public T DequeueReadOptimized()
		{
			if (_reading.Count > 0)
			{
				return _reading.Pop();
			}

			throw new Exception("Queue is empty");
		}

		public void EnqueueWriteOptimized(T item)
		{
			_writing.Push(item);
		}

		public T DequeueWriteOptimized()
		{
			Move(_writing, _reading);

			if (_reading.Count > 0)
			{
				return _reading.Pop();
			}

			throw new Exception("Empty queue");
		}

		public IEnumerator<T> GetEnumerator()
		{
			Move(_writing, _reading);

			return _reading.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		private void Move(Stack<T> source, Stack<T> target)
		{
			while (source.Count > 0)
			{
				target.Push(source.Pop());
			}
		}
	}
}
