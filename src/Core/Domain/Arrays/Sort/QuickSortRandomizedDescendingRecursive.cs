using System;
using System.Linq;

namespace Core.Domain.Arrays.Sort
{
	public static class QuickSortRandomizedDescendingRecursive
	{
		private static readonly Random _random = new Random((int)DateTime.Now.Ticks);

		public static ILearningCollection<T> SortUsingQuickSortRandomizedDescendingRecursive<T>(
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
			if (min >= max)
			{
				return;
			}

			int randomIndex = _random.Next(min, max);

			Swap(arr, max, randomIndex);

			int pivotIndex = GetPivot(arr, min, max);

			DoSort(arr, min, pivotIndex - 1);
			DoSort(arr, pivotIndex + 1, max);
		}

		private static int GetPivot<T>(T[] arr, in int min, in int max)
			where T : IComparable<T>
		{
			int index = min;
			T pivot = arr[max];

			for (int i = min; i < max; i++)
			{
				if (arr[i].CompareTo(pivot) >= 0)
				{
					Swap(arr, i, index);
					index++;
				}
			}

			Swap(arr, index, max);

			return index;
		}

		private static void Swap<T>(T[] arr, in int index1, in int index2)
			where T : IComparable<T>
		{
			T tmp = arr[index1];

			arr[index1] = arr[index2];
			arr[index2] = tmp;
		}
	}
}
