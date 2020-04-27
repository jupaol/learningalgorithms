namespace Core.Domain.Trees.BinaryTrees
{
	public interface IBinaryTreeNode<T> : ITreeNode<T>
	{
		IBinaryTreeNode<T> Left { get; set; }

		IBinaryTreeNode<T> Right { get; set; }
	}
}
