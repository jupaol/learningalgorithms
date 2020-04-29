using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Domain.Trees.BinaryTrees.Extensions
{
	public static class PreOrderTraversalExtensions
	{
		public static IEnumerable<T> GetInPreOrderTraversalRecursively<T>(
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

			GetInPreOrderTraversalUsingRecursion(source.Root, list);

			return list;
		}

		private static void GetInPreOrderTraversalUsingRecursion<T>(
			IBinaryTreeNode<T> node, ICollection<T> list)
			where T : IComparable<T>
		{
			if (node == null)
			{
				return;
			}

			list.Add(node.Item);

			if (node.Left != null)
			{
				GetInPreOrderTraversalUsingRecursion(node.Left, list);
			}

			if (node.Right != null)
			{
				GetInPreOrderTraversalUsingRecursion(node.Right, list);
			}
		}
	}
}
