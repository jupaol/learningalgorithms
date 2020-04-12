using System;
using System.Linq;

namespace Core.Domain.Arrays.Search
{
	public static class BinarySearchRotatedUnknownSeedSimplifiedRecursive
	{
		public static int SearchRotatedSimplifiedRecursive<T>(this ILearningCollection<T> source, T key)
			where T : IComparable<T>
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			T[] arr = source.ToArray();

			return DoSearch(arr, key, 0, arr.Length - 1);
		}

		private static int DoSearch<T>(T[] arr, T key, int left, int right)
			where T : IComparable<T>
		{
			if (left > right)
			{
				return -1;
			}

			int mid = (left + right) / 2;

			if (arr[mid].Equals(key))
			{
				return mid;
			}

			bool isLeftSorted = arr[left].CompareTo(arr[mid]) <= 0;
			bool isKeyOnLeftRange =
				key.CompareTo(arr[left]) >= 0 && key.CompareTo(arr[mid]) <= 0;
			bool isKeyOnRightRange =
				key.CompareTo(arr[mid]) >= 0 && key.CompareTo(arr[right]) <= 0;

			if (isLeftSorted)
			{
				if (isKeyOnLeftRange)
				{
					return DoSearch(arr, key, left, mid - 1);
				}

				return DoSearch(arr, key, mid + 1, right);
			}

			if (isKeyOnRightRange)
			{
				return DoSearch(arr, key, mid + 1, right);
			}

			return DoSearch(arr, key, left, mid - 1);
		}
	}
}
