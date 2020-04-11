using System;

namespace Core.Domain.Arrays.Sort
{
	public class QuickSortTraditionalRecursive
	{
		public T[] Sort<T>(T[] source)
			where T : IComparable<T>
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			if (source.Length == 0)
			{
				return Array.Empty<T>();
			}

			DoSort(source, 0, source.Length - 1);

			return source;
		}

		private void DoSort<T>(T[] source, int min, int max)
			where T : IComparable<T>
		{
			if (min >= max)
			{
				return;
			}

			int pivotIndex = PivotArray(source, min, max);

			DoSort(source, min, pivotIndex - 1);
			DoSort(source, pivotIndex + 1, max);
		}

		private int PivotArray<T>(T[] source, int min, int max)
			where T : IComparable<T>
		{
			T pivot = source[max];
			int pivotIndex = min;

			for (int i = min; i < max; i++)
			{
				if (source[i].CompareTo(pivot) <= 0)
				{
					Swap(source, i, pivotIndex);
					pivotIndex++;
				}
			}

			Swap(source, pivotIndex, max);

			return pivotIndex;
		}

		private void Swap<T>(T[] source, int index1, int index2)
			where T : IComparable<T>
		{
			T tmp = source[index1];

			source[index1] = source[index2];
			source[index2] = tmp;
		}
	}
}
