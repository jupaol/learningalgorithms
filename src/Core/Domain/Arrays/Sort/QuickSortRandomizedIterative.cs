using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Domain.Arrays.Sort
{
	public static class QuickSortRandomizedIterative
	{
		public static ILearningCollection<T> SortUsingQuickSortRandomizedIterative<T>(
			this ILearningCollection<T> source)
			where T : IComparable<T>
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			T[] arr = source.ToArray();

			DoSort(arr, 0, arr.Length - 1);

			return new LearningCollection<T>(arr);
		}

		private static void DoSort<T>(T[] arr, int min, int max)
			where T : IComparable<T>
		{
			var stack = new Stack<int>();

			stack.Push(min);
			stack.Push(max);

			while (stack.Count > 0)
			{
				int right = stack.Pop();
				int left = stack.Pop();

				int pivot = GetPivot(arr, left, right);

				if (pivot - 1 > left)
				{
					stack.Push(left);
					stack.Push(pivot - 1);
				}

				if (pivot + 1 < right)
				{
					stack.Push(pivot + 1);
					stack.Push(right);
				}
			}
		}

		private static int GetPivot<T>(T[] arr, in int min, in int max)
			where T : IComparable<T>
		{
			int index = min;
			T pivot = arr[max];

			for (int i = min; i < max; i++)
			{
				if (arr[i].CompareTo(pivot) <= 0)
				{
					Swap(arr, i, index);
					index++;
				}
			}

			Swap(arr, index, max);

			return index;
		}

		private static void Swap<T>(T[] arr, in int i1, in int i2)
			where T : IComparable<T>
		{
			T tmp = arr[i1];

			arr[i1] = arr[i2];
			arr[i2] = tmp;
		}
	}
}
