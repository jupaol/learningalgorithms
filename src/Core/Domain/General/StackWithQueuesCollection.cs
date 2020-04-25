using System;
using System.Collections;
using System.Collections.Generic;

namespace Core.Domain.General
{
	public class StackWithQueuesCollection<T> : IEnumerable<T>
	{
		private Queue<T> _reading = new Queue<T>();

		private Queue<T> _writing = new Queue<T>();

		public void PushOptimizedWrites(T item)
		{
			_writing.Enqueue(item);
		}

		public T PopOptimizedWrites()
		{
			if (_writing.Count == 0)
			{
				throw new Exception("Stack empty");
			}

			if (_writing.Count == 1)
			{
				return _writing.Dequeue();
			}

			while (_writing.Count > 1)
			{
				_reading.Enqueue(_writing.Dequeue());
			}

			Queue<T> tmp = _reading;

			_reading = _writing;
			_writing = tmp;

			return _reading.Dequeue();
		}

		public void PushOptimizedReads(T item)
		{
			if (_reading.Count == 0)
			{
				_reading.Enqueue(item);
			}
			else
			{
				_writing.Enqueue(item);
				Move(_reading, _writing);
				Swap(ref _reading, ref _writing);
			}
		}

		public T PopOptimizedReads()
		{
			if (_reading.Count > 0)
			{
				return _reading.Dequeue();
			}

			throw new Exception("Empty stack");
		}

		public IEnumerator<T> GetEnumerator()
		{
			return _reading.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		private void Move(Queue<T> source, Queue<T> target)
		{
			while (source.Count > 0)
			{
				target.Enqueue(source.Dequeue());
			}
		}

		private void Swap(ref Queue<T> source, ref Queue<T> target)
		{
			Queue<T> tmp = source;

			source = target;
			target = tmp;
		}
	}
}
