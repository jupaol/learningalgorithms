namespace Core.Domain.Trees.BinaryTrees
{
	public interface IBinaryTreeNode<T> : ITreeNode<T>
	{
		IBinaryTreeNode<T> Left { get; set; }

		IBinaryTreeNode<T> Right { get; set; }

#pragma warning disable CA1716 // Identifiers should not match keywords
		IBinaryTreeNode<T> Next { get; set; }
#pragma warning restore CA1716 // Identifiers should not match keywords
	}
}
