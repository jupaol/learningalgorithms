using System;
using System.Collections.Generic;

namespace Core.Domain.Trees.BinaryTrees.Extensions
{
	public static class InOrderReversalTraversalExtensions
	{
		public static IEnumerable<T> GetInOrderReversalTraversalRecursively<T>(
			this ILearningBinaryTreeCollection<T> source)
			where T : IComparable<T>
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			var list = new List<T>();

			GetInOrderReversalTraversalUsingRecursion(source.Root, list);

			return list;
		}

		public static IEnumerable<T> GetInOrderReversalTraversalIteratively<T>(
			this ILearningBinaryTreeCollection<T> source)
			where T : IComparable<T>
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			var list = new List<T>();
			var stack = new Stack<IBinaryTreeNode<T>>();
			IBinaryTreeNode<T> current = source.Root;

			while (stack.Count > 0 || current != null)
			{
				if (current != null)
				{
					stack.Push(current);
					current = current.Right;
				}
				else
				{
					current = stack.Pop();
					list.Add(current.Item);
					current = current.Left;
				}
			}

			return list;
		}

		private static void GetInOrderReversalTraversalUsingRecursion<T>(
			IBinaryTreeNode<T> root, ICollection<T> list)
			where T : IComparable<T>
		{
			if (root == null)
			{
				return;
			}

			GetInOrderReversalTraversalUsingRecursion(root.Right, list);
			list.Add(root.Item);
			GetInOrderReversalTraversalUsingRecursion(root.Left, list);
		}
	}
}
