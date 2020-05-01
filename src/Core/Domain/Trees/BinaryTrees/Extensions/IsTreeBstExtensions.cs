using System;
using System.Collections.Generic;

namespace Core.Domain.Trees.BinaryTrees.Extensions
{
	public static class IsTreeBstExtensions
	{
		public static bool IsTreeBstRecursively<T>(
			this ILearningBinaryTreeCollection<T> source)
			where T : IComparable<T>
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			return IsTreeBstUsingRecursion(source.Root);
		}

		public static bool IsTreeBstUsingMinMaxRecursively<T>(
			this ILearningBinaryTreeCollection<T> source, T min, T max)
			where T : IComparable<T>
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			return
				IsTreeBstUsingMinMaxUsingRecursion(source.Root, min, true, max, true);
		}

		public static bool IsTreeBstUsingInOrderTraversalIteratively<T>(
			this ILearningBinaryTreeCollection<T> source)
			where T : IComparable<T>
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			var stack = new Stack<IBinaryTreeNode<T>>();
			IBinaryTreeNode<T> current = source.Root;
			T prev = default;
			bool firstTime = true;

			while (stack.Count > 0 || current != null)
			{
				if (current != null)
				{
					stack.Push(current);
					current = current.Left;
				}
				else
				{
					current = stack.Pop();

#pragma warning disable S2583 // Conditionally executed code should be reachable
					if (firstTime)
#pragma warning restore S2583 // Conditionally executed code should be reachable
					{
						prev = current.Item;
						firstTime = false;
					}
					else if (current.Item.CompareTo(prev) < 0)
					{
						return false;
					}
					else
					{
						prev = current.Item;
					}

					current = current.Right;
				}
			}

			return true;
		}

		private static bool IsTreeBstUsingRecursion<T>(IBinaryTreeNode<T> root)
			where T : IComparable<T>
		{
			if (root == null)
			{
				return true;
			}

			return
				IsTreeBstUsingRecursion(root.Left) &&
				IsTreeBstUsingRecursion(root.Right) &&
				AreLeftChildNodesLesser(root.Left, root.Item) &&
				AreRightChildNodesGrater(root.Right, root.Item);
		}

		private static bool AreRightChildNodesGrater<T>(IBinaryTreeNode<T> root, T item)
			where T : IComparable<T>
		{
			if (root == null)
			{
				return true;
			}

			return
				root.Item.CompareTo(item) > 0
				&& AreRightChildNodesGrater(root.Right, item)
				&& AreRightChildNodesGrater(root.Left, item);
		}

		private static bool AreLeftChildNodesLesser<T>(IBinaryTreeNode<T> root, T item)
			where T : IComparable<T>
		{
			if (root == null)
			{
				return true;
			}

			return
				root.Item.CompareTo(item) <= 0
				&& AreLeftChildNodesLesser(root.Left, item)
				&& AreLeftChildNodesLesser(root.Right, item);
		}

		private static bool IsTreeBstUsingMinMaxUsingRecursion<T>(
			IBinaryTreeNode<T> root, T min, bool minInclusive, T max, bool maxInclusive)
			where T : IComparable<T>
		{
			if (root == null)
			{
				return true;
			}

			bool minComp = minInclusive
				? root.Item.CompareTo(min) >= 0
				: root.Item.CompareTo(min) > 0;

			bool maxComp = maxInclusive
				? root.Item.CompareTo(max) <= 0
				: root.Item.CompareTo(max) < 0;

			return
				minComp &&
				maxComp &&
				IsTreeBstUsingMinMaxUsingRecursion(
					root.Left, min, false, root.Item, true) &&
				IsTreeBstUsingMinMaxUsingRecursion(
					root.Right, root.Item, false, max, false);
		}
	}
}
