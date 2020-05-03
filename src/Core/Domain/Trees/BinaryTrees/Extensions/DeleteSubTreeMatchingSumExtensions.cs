using System;

namespace Core.Domain.Trees.BinaryTrees.Extensions
{
	public static class DeleteSubTreeMatchingSumExtensions
	{
		public static void DeleteSubTreeMatchingSumRecursively(
			this ILearningBinaryTreeCollection<int> source, int sum)
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			if (source.Root == null)
			{
				return;
			}

			DeleteSubTreeMatchingSumUsingRecursion(source, source.Root, null, true, sum);
		}

		private static int DeleteSubTreeMatchingSumUsingRecursion(
			ILearningBinaryTreeCollection<int> source,
			IBinaryTreeNode<int> root,
			IBinaryTreeNode<int> parent,
			bool leftDirection,
			in int targetSum)
		{
			if (root == null)
			{
				return 0;
			}

			int lefSum = DeleteSubTreeMatchingSumUsingRecursion(
				source, root.Left, root, true, targetSum);

			int rightSum = DeleteSubTreeMatchingSumUsingRecursion(
				source, root.Right, root, false, targetSum);

			int nodeSum = lefSum + rightSum + root.Item;

			if (nodeSum != targetSum)
			{
				return nodeSum;
			}

			if (parent == null)
			{
				source.Root = null;

				return nodeSum;
			}

			if (leftDirection)
			{
				parent.Left = null;
			}
			else
			{
				parent.Right = null;
			}

			return nodeSum;
		}
	}
}
