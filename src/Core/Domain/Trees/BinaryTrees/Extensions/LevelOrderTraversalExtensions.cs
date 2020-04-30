using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Domain.Trees.BinaryTrees.Extensions
{
	// AKA: Breadth level traversal
	public static class LevelOrderTraversalExtensions
	{
		public static IEnumerable<T> GetInLevelOrderTraversal<T>(
			this ILearningBinaryTreeCollection<T> source)
			where T : IComparable<T>
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			if (source.Root == null)
			{
				return Enumerable.Empty<T>();
			}

			var queue = new Queue<IBinaryTreeNode<T>>();
			var list = new List<T>();

			queue.Enqueue(source.Root);

			while (queue.Count > 0)
			{
				int size = queue.Count;

				while (size > 0)
				{
					IBinaryTreeNode<T> current = queue.Dequeue();

					list.Add(current.Item);

					if (current.Left != null)
					{
						queue.Enqueue(current.Left);
					}

					if (current.Right != null)
					{
						queue.Enqueue(current.Right);
					}

					size--;
				}
			}

			return list;
		}
	}
}
