using System;

namespace Core.Domain.Trees.BinaryTrees.Extensions
{
	public static class MinMaxExtensions
	{
		public static IBinaryTreeNode<T> MinimumRecursively<T>(this ILearningBinaryTreeCollection<T> source)
			where T : IComparable<T>
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			if (source.Root == null)
			{
				return null;
			}

			return MinimumUsingRecursion(source.Root);
		}

		public static IBinaryTreeNode<T> MinimumIteratively<T>(this ILearningBinaryTreeCollection<T> source)
			where T : IComparable<T>
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			if (source.Root == null)
			{
				return null;
			}

			IBinaryTreeNode<T> current = source.Root;

			while (current.Left != null)
			{
				current = current.Left;
			}

			return current;
		}

		public static IBinaryTreeNode<T> MaximumRecursively<T>(this ILearningBinaryTreeCollection<T> source)
			where T : IComparable<T>
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			if (source.Root == null)
			{
				return null;
			}

			return MaximumUsingRecursion(source.Root);
		}

		public static IBinaryTreeNode<T> MaximumIteratively<T>(this ILearningBinaryTreeCollection<T> source)
			where T : IComparable<T>
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			if (source.Root == null)
			{
				return null;
			}

			IBinaryTreeNode<T> current = source.Root;

			while (current.Right != null)
			{
				current = current.Right;
			}

			return current;
		}

		private static IBinaryTreeNode<T> MinimumUsingRecursion<T>(IBinaryTreeNode<T> root)
			where T : IComparable<T>
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

		private static IBinaryTreeNode<T> MaximumUsingRecursion<T>(IBinaryTreeNode<T> root)
			where T : IComparable<T>
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
	}
}
