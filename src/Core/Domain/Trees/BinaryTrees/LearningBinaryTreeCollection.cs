using System;
using System.Collections;
using System.Collections.Generic;

namespace Core.Domain.Trees.BinaryTrees
{
	public class LearningBinaryTreeCollection<T> : ILearningBinaryTreeCollection<T>
		where T : IComparable<T>
	{
		public IBinaryTreeNode<T> Root { get; set; }

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
