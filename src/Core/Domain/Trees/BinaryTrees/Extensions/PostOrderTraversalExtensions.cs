using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Domain.Trees.BinaryTrees.Extensions
{
	public static class PostOrderTraversalExtensions
	{
		public static IEnumerable<T> GetInPostOrderTraversalRecursively<T>(
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

			GetInPostOrderTraversalUsingRecursion(source.Root, list);

			return list;
		}

		public static IEnumerable<T> GetInPostOrderTraversalIteratively<T>(
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
			IBinaryTreeNode<T> current = source.Root;

			while (stack.Count > 0 || current != null)
			{
				if (current != null)
				{
					stack.Push(current);
					current = current.Left;
				}
				else
				{
					IBinaryTreeNode<T> right = stack.Peek().Right;

					if (right != null)
					{
						current = right;
					}
					else
					{
						right = stack.Pop();
						list.Add(right.Item);

						while (stack.Count > 0 && stack.Peek().Right == right)
						{
							right = stack.Pop();
							list.Add(right.Item);
						}
					}
				}
			}

			return list;
		}

		private static void GetInPostOrderTraversalUsingRecursion<T>(
			IBinaryTreeNode<T> node, ICollection<T> list)
			where T : IComparable<T>
		{
			if (node == null)
			{
				return;
			}

			if (node.Left != null)
			{
				GetInPostOrderTraversalUsingRecursion(node.Left, list);
			}

			if (node.Right != null)
			{
				GetInPostOrderTraversalUsingRecursion(node.Right, list);
			}

			list.Add(node.Item);
		}
	}
}
