using System;

namespace Core.Domain.Trees.BinaryTrees.Extensions
{
	public static class InOrderSuccessorExtensions
	{
		public static T GetNextInOrderSuccessor<T>(
			this ILearningBinaryTreeCollection<T> source, T target)
			where T : IComparable<T>
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			IBinaryTreeNode<T> res = FindNodeWithSuccessorRec(source.Root, target, null);

			return res == null ? default : res.Item;
		}

		private static IBinaryTreeNode<T> FindNodeWithSuccessorRec<T>(
			IBinaryTreeNode<T> root, T target, IBinaryTreeNode<T> prev)
			where T : IComparable<T>
		{
			if (root == null)
			{
				return null;
			}

			if (root.Item.Equals(target))
			{
				if (root.Right == null)
				{
					return prev;
				}

				IBinaryTreeNode<T> current = root.Right;

				while (current.Left != null)
				{
					current = current.Left;
				}

				return current;
			}

			if (root.Item.CompareTo(target) > 0)
			{
#pragma warning disable S1226 // Method parameters, caught exceptions and foreach variables' initial values should not be ignored
				prev = root;
#pragma warning restore S1226 // Method parameters, caught exceptions and foreach variables' initial values should not be ignored
			}

			if (target.CompareTo(root.Item) <= 0)
			{
				return FindNodeWithSuccessorRec(root.Left, target, prev);
			}

			return FindNodeWithSuccessorRec(root.Right, target, prev);
		}
	}
}
