using System;
using System.Collections;
using System.Collections.Generic;

namespace Core.Domain.Trees.BinaryTrees
{
	public class LearningBinaryTreeCollection<T> : ILearningBinaryTreeCollection<T>
		where T : IComparable<T>
	{
		private readonly Stack<IBinaryTreeNode<T>> _stack = new Stack<IBinaryTreeNode<T>>();

		private IBinaryTreeNode<T> _current;

		private bool _isFirstTimeIterating = true;

		public IBinaryTreeNode<T> Root { get; set; }

		public void Clear()
		{
			Root = null;
		}

		public bool HasNext()
		{
			return (_stack.Count > 0 || _current != null) && !_isFirstTimeIterating;
		}

		public void ResetIteration()
		{
			_isFirstTimeIterating = true;
		}

		public IBinaryTreeNode<T> GetNext()
		{
			if (_isFirstTimeIterating)
			{
				_current = Root;
				_isFirstTimeIterating = false;
			}

			IBinaryTreeNode<T> tmp;

			if (_current != null)
			{
				while (_current != null)
				{
					_stack.Push(_current);
					_current = _current.Left;
				}

				tmp = _stack.Pop();

				_current = tmp.Right;

				return tmp;
			}

			tmp = _stack.Pop();

			_current = tmp.Right;

			return tmp;
		}

		public IEnumerator<T> GetEnumerator()
		{
			throw new NotImplementedException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
