using System;

namespace Core.Domain.Trees.BinaryTrees.Extensions
{
	public static class AddGenericExtensions
	{
		public static void AddFrontLeft<T>(this ILearningBinaryTreeCollection<T> source, T item)
			where T : IComparable<T>
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			var node = new BinaryTreeNode<T>(item);

			if (source.Root != null)
			{
				node.Left = source.Root;
			}

			source.Root = node;
		}

		public static void AddFrontRight<T>(this ILearningBinaryTreeCollection<T> source, T item)
			where T : IComparable<T>
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			var node = new BinaryTreeNode<T>(item);

			if (source.Root != null)
			{
				node.Right = source.Root;
			}

			source.Root = node;
		}
	}
}
