using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Domain.Trees.BinaryTrees.Extensions
{
	public static class InOrderTraversalExtensions
	{
		public static IEnumerable<T> GetInOrderTraversalRecursively<T>(
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

			var list = new List<T>();

			GetInOrderTraversalUsingRecursion(source.Root, list);

			return list;
		}

		public static IEnumerable<T> GetInOrderTraversalIteratively<T>(
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

			var list = new List<T>();
			var stack = new Stack<IBinaryTreeNode<T>>();

			stack.Push(source.Root);

			while (stack.Count > 0)
			{
				IBinaryTreeNode<T> current = stack.Pop();

				if (current != null)
				{
					stack.Push(current.Left);
				}
				else
				{
					current = stack.Pop();

					list.Add(current.Item);

					stack.Push(current.Right);
				}
			}

			return list;
		}

		private static void GetInOrderTraversalUsingRecursion<T>(
			IBinaryTreeNode<T> node, List<T> list)
			where T : IComparable<T>
		{
			if (node == null)
			{
				return;
			}

			if (node.Left != null)
			{
				GetInOrderTraversalUsingRecursion(node.Left, list);
			}

			list.Add(node.Item);

			if (node.Right != null)
			{
				GetInOrderTraversalUsingRecursion(node.Right, list);
			}
		}
	}
}
