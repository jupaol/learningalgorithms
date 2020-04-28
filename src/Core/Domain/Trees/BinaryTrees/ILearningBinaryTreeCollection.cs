using System;
using System.Collections.Generic;

namespace Core.Domain.Trees.BinaryTrees
{
	public interface ILearningBinaryTreeCollection<T> : ILearningTreeCollection<T>
		where T : IComparable<T>
	{
		IBinaryTreeNode<T> Root { get; set; }

		IBinaryTreeNode<T> AddRecursively(T item);

		void AddManyRecursively(IEnumerable<T> items);

		void RemoveRecursively(T item);

		IBinaryTreeNode<T> MinimumRecursively();

		IBinaryTreeNode<T> MinimumIteratively();

		IBinaryTreeNode<T> MaximumRecursively();

		IBinaryTreeNode<T> MaximumIteratively();

		int CalculateHeightRecursively();

		int CalculateHeightIteratively();

		IBinaryTreeNode<T> FindRecursively(T item);
	}
}
