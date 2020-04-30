using System;

namespace Core.Domain.Trees.BinaryTrees
{
	public interface ILearningBinaryTreeCollection<T> : ILearningTreeCollection<T>
		where T : IComparable<T>
	{
		IBinaryTreeNode<T> Root { get; set; }

		void Clear();
	}
}
