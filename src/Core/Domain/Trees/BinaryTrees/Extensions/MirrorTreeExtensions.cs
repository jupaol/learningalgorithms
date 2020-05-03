using System;
using System.Collections.Generic;

namespace Core.Domain.Trees.BinaryTrees.Extensions
{
	public static class MirrorTreeExtensions
	{
		public static void MirrorTreeInPostOrderRecursively<T>(
			this ILearningBinaryTreeCollection<T> source)
			where T : IComparable<T>
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			MirrorTreeInPostOrderUsingRecursion(source.Root);
		}

		public static void MirrorTreeInPostOrderIteratively<T>(
			this ILearningBinaryTreeCollection<T> source)
			where T : IComparable<T>
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			if (source.Root == null)
			{
				return;
			}

			var stack = new Stack<IBinaryTreeNode<T>>();
			IBinaryTreeNode<T> current = source.Root;

			while (stack.Count > 0 || current != null)
			{
				if (current != null)
				{
					stack.Push(current);
					current = current.Left;
				}
				else
				{
					IBinaryTreeNode<T> right = stack.Peek().Right;

					if (right != null)
					{
						current = right;
					}
					else
					{
						right = stack.Pop();

						IBinaryTreeNode<T> tmpLeft = right.Left;

						right.Left = right.Right;
						right.Right = tmpLeft;

						while (stack.Count > 0 && stack.Peek().Right == right)
						{
							right = stack.Pop();

							tmpLeft = right.Left;
							right.Left = right.Right;
							right.Right = tmpLeft;
						}
					}
				}
			}
		}

		private static void MirrorTreeInPostOrderUsingRecursion<T>(IBinaryTreeNode<T> root)
			where T : IComparable<T>
		{
			if (root == null)
			{
				return;
			}

			IBinaryTreeNode<T> right = root.Right;
			IBinaryTreeNode<T> left = root.Left;

			MirrorTreeInPostOrderUsingRecursion(right);

			IBinaryTreeNode<T> tmp = left;

			root.Left = right;
			root.Right = tmp;

			MirrorTreeInPostOrderUsingRecursion(left);
		}
	}
}
