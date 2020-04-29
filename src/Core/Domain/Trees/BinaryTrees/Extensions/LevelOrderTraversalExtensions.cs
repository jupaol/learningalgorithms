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

			var stack = new Stack<IBinaryTreeNode<T>>();
			var list = new List<T>();

			stack.Push(source.Root);

			while (stack.Count > 0)
			{
				int size = stack.Count;

				while (size > 0)
				{
					IBinaryTreeNode<T> current = stack.Pop();

					list.Add(current.Item);

					if (current.Right != null)
					{
						stack.Push(current.Right);
					}

					if (current.Left != null)
					{
						stack.Push(current.Left);
					}

					size--;
				}
			}

			return list;
		}
	}
}
