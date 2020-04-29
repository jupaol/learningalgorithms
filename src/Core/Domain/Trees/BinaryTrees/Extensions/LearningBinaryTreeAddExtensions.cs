using System;
using System.Collections.Generic;

namespace Core.Domain.Trees.BinaryTrees.Extensions
{
	public static class LearningBinaryTreeAddExtensions
	{
		public static IBinaryTreeNode<T> AddRecursively<T>(
			this ILearningBinaryTreeCollection<T> source, T item)
			where T : IComparable<T>
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			if (source.Root == null)
			{
				source.Root = CreateNode(item);

				return source.Root;
			}

			return AddItemUsingRecursion(source.Root, item);
		}

		public static void AddManyRecursively<T>(
			this ILearningBinaryTreeCollection<T> source, IEnumerable<T> items)
			where T : IComparable<T>
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			if (items == null)
			{
				throw new ArgumentNullException(nameof(items));
			}

			foreach (T item in items)
			{
				AddRecursively(source, item);
			}
		}

		private static IBinaryTreeNode<T> CreateNode<T>(T item)
			where T : IComparable<T>
		{
			return new BinaryTreeNode<T>(item);
		}

		private static IBinaryTreeNode<T> AddItemUsingRecursion<T>(IBinaryTreeNode<T> root, T item)
			where T : IComparable<T>
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
	}
}
