using System;
using System.Collections.Generic;

namespace Core.Domain.Trees.BinaryTrees.Extensions
{
	public static class LinkSiblingsExtensions
	{
		public static void LinkSiblingsInLevelTraversal<T>(
			this ILearningBinaryTreeCollection<T> source)
			where T : IComparable<T>
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			if (source.Root == null)
			{
				return;
			}

			var queue = new Queue<IBinaryTreeNode<T>>();

			queue.Enqueue(source.Root);

			while (queue.Count > 0)
			{
				int size = queue.Count;
				IBinaryTreeNode<T> prev = null;

				while (size > 0)
				{
					IBinaryTreeNode<T> current = queue.Dequeue();

					if (current.Left != null)
					{
						queue.Enqueue(current.Left);
					}

					if (current.Right != null)
					{
						queue.Enqueue(current.Right);
					}

					if (prev != null)
					{
						prev.Next = current;
					}

					prev = current;

					size--;
				}
			}
		}

		public static void LinkSiblingsContinuouslyInLevelTraversal<T>(
			this ILearningBinaryTreeCollection<T> source)
			where T : IComparable<T>
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			if (source.Root == null)
			{
				return;
			}

			var queue = new Queue<IBinaryTreeNode<T>>();
			IBinaryTreeNode<T> prev = null;

			queue.Enqueue(source.Root);

			while (queue.Count > 0)
			{
				int size = queue.Count;

				while (size > 0)
				{
					IBinaryTreeNode<T> current = queue.Dequeue();

					if (current.Left != null)
					{
						queue.Enqueue(current.Left);
					}

					if (current.Right != null)
					{
						queue.Enqueue(current.Right);
					}

					if (prev != null)
					{
						prev.Next = current;
					}
					else
					{
						source.Root.Next = current;
					}

					prev = current;

					size--;
				}
			}
		}
	}
}
