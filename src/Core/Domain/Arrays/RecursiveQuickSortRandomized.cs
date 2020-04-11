using System;

namespace Core.Domain.Arrays
{
	public class RecursiveQuickSortRandomized
	{
		private readonly Random _random = new Random((int)DateTime.Now.Ticks);

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

		private void DoSort<T>(T[] source, in int min, in int max)
			where T : IComparable<T>
		{
			if (min >= max)
			{
				return;
			}

			int randomIndex = _random.Next(min, max);

			Swap(source, randomIndex, max);

			int pivotIndex = GetPivot(source, min, max);

			DoSort(source, min, pivotIndex - 1);
			DoSort(source, pivotIndex + 1, max);
		}

		private int GetPivot<T>(T[] source, in int min, in int max)
			where T : IComparable<T>
		{
			int pivotIndex = min;
			T pivot = source[max];

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

		private void Swap<T>(T[] source, in int index1, in int index2)
			where T : IComparable<T>
		{
			T item = source[index1];

			source[index1] = source[index2];
			source[index2] = item;
		}
	}
}
