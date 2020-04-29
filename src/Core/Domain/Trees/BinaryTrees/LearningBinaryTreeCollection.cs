using System;
using System.Collections;
using System.Collections.Generic;

namespace Core.Domain.Trees.BinaryTrees
{
	public class LearningBinaryTreeCollection<T> : ILearningBinaryTreeCollection<T>
		where T : IComparable<T>
	{
		public IBinaryTreeNode<T> Root { get; set; }

		public IBinaryTreeNode<T> AddRecursively(T item)
		{
			if (Root == null)
			{
				Root = CreateNode(item);

				return Root;
			}

			return AddItemUsingRecursion(Root, item);
		}

		public void AddManyRecursively(IEnumerable<T> items)
		{
			if (items == null)
			{
				throw new ArgumentNullException(nameof(items));
			}

			foreach (T item in items)
			{
				AddRecursively(item);
			}
		}

		public void RemoveRecursively(T item)
		{
			// TODO: implement
		}

		public IBinaryTreeNode<T> MinimumRecursively()
		{
			if (Root == null)
			{
				return null;
			}

			return MinimumUsingRecursion(Root);
		}

		public IBinaryTreeNode<T> MinimumIteratively()
		{
			if (Root == null)
			{
				return null;
			}

			IBinaryTreeNode<T> current = Root;

			while (current.Left != null)
			{
				current = current.Left;
			}

			return current;
		}

		public IBinaryTreeNode<T> MaximumRecursively()
		{
			if (Root == null)
			{
				return null;
			}

			return MaximumUsingRecursion(Root);
		}

		public IBinaryTreeNode<T> MaximumIteratively()
		{
			if (Root == null)
			{
				return null;
			}

			IBinaryTreeNode<T> current = Root;

			while (current.Right != null)
			{
				current = current.Right;
			}

			return current;
		}

		public int CalculateHeightRecursively()
		{
			if (Root == null)
			{
				return -1;
			}

			return CalculateHeightUsingRec(Root);
		}

		// Counting levels in a level order traversal will give us the height
		public int CalculateHeightIteratively()
		{
			if (Root == null)
			{
				return -1;
			}

			int height = -1;
			var nodes = new Queue<IBinaryTreeNode<T>>();

			nodes.Enqueue(Root);

			while (nodes.Count > 0)
			{
				int size = nodes.Count;

				while (size > 0)
				{
					IBinaryTreeNode<T> current = nodes.Dequeue();

					if (current.Left != null)
					{
						nodes.Enqueue(current.Left);
					}

					if (current.Right != null)
					{
						nodes.Enqueue(current.Right);
					}

					size--;
				}

				height++;
			}

			return height;
		}

		public IBinaryTreeNode<T> FindRecursively(T item)
		{
			if (Root == null)
			{
				return null;
			}

#pragma warning disable S3900 // Arguments of public methods should be validated against null
			if (item.CompareTo(Root.Item) == 0)
#pragma warning restore S3900 // Arguments of public methods should be validated against null
			{
				return Root;
			}

			return FindUsingRecursion(Root, item);
		}

		public IEnumerator<T> GetEnumerator()
		{
			throw new System.NotImplementedException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		private IBinaryTreeNode<T> CreateNode(T item)
		{
			return new BinaryTreeNode<T>(item);
		}

		private IBinaryTreeNode<T> AddItemUsingRecursion(IBinaryTreeNode<T> root, T item)
		{
			if (root == null)
			{
				root = CreateNode(item);
			}
			else if (item.CompareTo(root.Item) <= 0)
			{
				root.Left = AddItemUsingRecursion(root.Left, item);
			}
			else
			{
				root.Right = AddItemUsingRecursion(root.Right, item);
			}

			return root;
		}

		private IBinaryTreeNode<T> FindUsingRecursion(IBinaryTreeNode<T> root, T item)
		{
			if (root == null)
			{
				return null;
			}

			if (item.CompareTo(root.Item) == 0)
			{
				return root;
			}

			if (item.CompareTo(root.Item) < 0)
			{
				return FindUsingRecursion(root.Left, item);
			}

			return FindUsingRecursion(root.Right, item);
		}

		private IBinaryTreeNode<T> MinimumUsingRecursion(IBinaryTreeNode<T> root)
		{
			if (root == null)
			{
				return null;
			}

			if (root.Left != null)
			{
				return MinimumUsingRecursion(root.Left);
			}

			return root;
		}

		private IBinaryTreeNode<T> MaximumUsingRecursion(IBinaryTreeNode<T> root)
		{
			if (root == null)
			{
				return null;
			}

			if (root.Right != null)
			{
				return MaximumUsingRecursion(root.Right);
			}

			return root;
		}

		private int CalculateHeightUsingRec(IBinaryTreeNode<T> root)
		{
			if (root == null)
			{
				return -1;
			}

			return
				Math.Max(CalculateHeightUsingRec(root.Left), CalculateHeightUsingRec(root.Right)) + 1;
		}
	}
}
