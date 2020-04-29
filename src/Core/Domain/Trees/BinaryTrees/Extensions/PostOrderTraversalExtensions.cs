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
