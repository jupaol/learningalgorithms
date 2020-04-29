using System;

namespace Core.Domain.Trees.BinaryTrees.Extensions
{
	public static class LearningBinaryTreeFindExtensions
	{
		public static IBinaryTreeNode<T> FindRecursively<T>(
			this ILearningBinaryTreeCollection<T> source, T item)
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

#pragma warning disable S3900 // Arguments of public methods should be validated against null
			if (item.CompareTo(source.Root.Item) == 0)
#pragma warning restore S3900 // Arguments of public methods should be validated against null
			{
				return source.Root;
			}

			return FindUsingRecursion(source.Root, item);
		}

		private static IBinaryTreeNode<T> FindUsingRecursion<T>(IBinaryTreeNode<T> root, T item)
			where T : IComparable<T>
		{
			if (root == null)
			{
				return null;
			}

			if (item.CompareTo(root.Item) == 0)
			{
				return root;
			}

			if (item.CompareTo(root.Item) < 0)
			{
				return FindUsingRecursion(root.Left, item);
			}

			return FindUsingRecursion(root.Right, item);
		}
	}
}
