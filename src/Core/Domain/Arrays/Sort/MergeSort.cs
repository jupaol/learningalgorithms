using System;

namespace Core.Domain.Arrays.Sort
{
	public class MergeSort
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

			DoSort(source);

			return source;
		}

		private void DoSort<T>(T[] source)
			where T : IComparable<T>
		{
			if (source.Length <= 1)
			{
				return;
			}

			int mid = source.Length / 2;

			T[] left = new T[mid];
			T[] right = new T[source.Length - mid];

			for (int i = 0; i < left.Length; i++)
			{
				left[i] = source[i];
			}

			for (int i = mid; i < source.Length; i++)
			{
				right[i - mid] = source[i];
			}

			DoSort(left);
			DoSort(right);

			Merge(left, right, source);
		}

		private void Merge<T>(T[] left, T[] right, T[] source)
			where T : IComparable<T>
		{
			int leftIndex = 0;
			int rightIndex = 0;
			int targetIndex = 0;

			while (leftIndex < left.Length && rightIndex < right.Length && targetIndex < source.Length)
			{
				if (left[leftIndex].CompareTo(right[rightIndex]) <= 0)
				{
					source[targetIndex] = left[leftIndex];
					targetIndex++;
					leftIndex++;
				}
				else
				{
					source[targetIndex] = right[rightIndex];
					targetIndex++;
					rightIndex++;
				}
			}

			while (leftIndex < left.Length)
			{
				source[targetIndex] = left[leftIndex];
				targetIndex++;
				leftIndex++;
			}

			while (rightIndex < right.Length)
			{
				source[targetIndex] = right[rightIndex];
				targetIndex++;
				rightIndex++;
			}
		}
	}
}
