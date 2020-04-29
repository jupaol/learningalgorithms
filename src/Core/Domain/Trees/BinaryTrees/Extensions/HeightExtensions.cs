using System;
using System.Collections.Generic;

namespace Core.Domain.Trees.BinaryTrees.Extensions
{
	public static class HeightExtensions
	{
		public static int CalculateHeightRecursively<T>(this ILearningBinaryTreeCollection<T> source)
			where T : IComparable<T>
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			if (source.Root == null)
			{
				return -1;
			}

			return CalculateHeightUsingRec(source.Root);
		}

		// Counting levels in a level order traversal will give us the height
		public static int CalculateHeightIteratively<T>(this ILearningBinaryTreeCollection<T> source)
			where T : IComparable<T>
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			if (source.Root == null)
			{
				return -1;
			}

			int height = -1;
			var nodes = new Queue<IBinaryTreeNode<T>>();

			nodes.Enqueue(source.Root);

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

		private static int CalculateHeightUsingRec<T>(IBinaryTreeNode<T> root)
			where T : IComparable<T>
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
