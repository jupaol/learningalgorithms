namespace Core.Domain.Trees.BinaryTrees
{
	public class BinaryTreeNode<T> : IBinaryTreeNode<T>
	{
		public BinaryTreeNode()
		{
		}

		public BinaryTreeNode(T item)
		{
			Item = item;
			Left = null;
			Right = null;
		}

		public T Item { get; set; }

		public IBinaryTreeNode<T> Left { get; set; }

		public IBinaryTreeNode<T> Right { get; set; }
	}
}
