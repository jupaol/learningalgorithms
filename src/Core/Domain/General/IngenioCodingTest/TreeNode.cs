namespace Core.Domain.General.IngenioCodingTest
{
	public class TreeNode<T>
	{
		public TreeNode()
		{
		}

		public TreeNode(T item)
		{
			Item = item;
		}

		public T Item { get; set; }

		public TreeNode<T> Left { get; set; }

		public TreeNode<T> Right { get; set; }
	}
}
