using System;
using System.Collections.Generic;

namespace Core.Domain.Trees.BinaryTrees.Extensions
{
	public static class CheckTreesAreTheSameExtensions
	{
		public static bool AreTreesTheSameRecursively<T>(
			this ILearningBinaryTreeCollection<T> tree1, ILearningBinaryTreeCollection<T> tree2)
			where T : IComparable<T>
		{
			if (tree1 == null)
			{
				throw new ArgumentNullException(nameof(tree1));
			}

			if (tree2 == null)
			{
				throw new ArgumentNullException(nameof(tree2));
			}

			return AreTreesTheSameRec(tree1.Root, tree2.Root);
		}

		public static bool AreTreesTheSameIteratively<T>(
			this ILearningBinaryTreeCollection<T> tree1, ILearningBinaryTreeCollection<T> tree2)
			where T : IComparable<T>
		{
			if (tree1 == null)
			{
				throw new ArgumentNullException(nameof(tree1));
			}

			if (tree2 == null)
			{
				throw new ArgumentNullException(nameof(tree2));
			}

			IBinaryTreeNode<T> root1 = tree1.Root;
			IBinaryTreeNode<T> root2 = tree2.Root;
			var stack1 = new Stack<IBinaryTreeNode<T>>();
			var stack2 = new Stack<IBinaryTreeNode<T>>();

			stack1.Push(root1);
			stack2.Push(root2);

			while (stack1.Count > 0 && stack2.Count > 0)
			{
				int size1 = stack1.Count;
				int size2 = stack2.Count;

				while (size2 > 0 && size1 > 0)
				{
					size2--;
					size1--;
				}
			}

			return stack2.Count <= 0 && stack1.Count <= 0;
		}

		private static bool AreTreesTheSameRec<T>(IBinaryTreeNode<T> root1, IBinaryTreeNode<T> root2)
			where T : IComparable<T>
		{
			if (root1 == null && root2 == null)
			{
				return true;
			}

			if (root1 != null && root2 != null)
			{
				return
					root1.Item.Equals(root2.Item) &&
					AreTreesTheSameRec(root1.Left, root2.Left) &&
					AreTreesTheSameRec(root1.Right, root2.Right);
			}

			return false;
		}
	}
}
