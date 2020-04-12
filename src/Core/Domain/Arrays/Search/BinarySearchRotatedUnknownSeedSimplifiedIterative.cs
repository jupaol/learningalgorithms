using System;
using System.Linq;

namespace Core.Domain.Arrays.Search
{
	public static class BinarySearchRotatedUnknownSeedSimplifiedIterative
	{
#pragma warning disable S3900 // Arguments of public methods should be validated against null
		public static int SearchRotatedSimplifiedIterative<T>(this ILearningCollection<T> source, T key)
			where T : IComparable<T>
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			T[] arr = source.ToArray();
			int left = 0;
			int right = arr.Length - 1;

			while (left <= right)
			{
				int mid = (left + right) / 2;

				if (arr[mid].Equals(key))
				{
					return mid;
				}

				bool isLeftSorted = arr[left].CompareTo(arr[mid]) <= 0;
				bool isKeyBetweenLeftRange =
					key.CompareTo(arr[left]) >= 0 && key.CompareTo(arr[mid]) <= 0;
				bool isKeyBetweenRightRange =
					key.CompareTo(arr[mid]) >= 0 && key.CompareTo(arr[right]) <= 0;

				if (isLeftSorted)
				{
					if (isKeyBetweenLeftRange)
					{
						right = mid - 1;
					}
					else
					{
						left = mid + 1;
					}
				}
				else if (isKeyBetweenRightRange)
				{
					left = mid + 1;
				}
				else
				{
					right = mid - 1;
				}
			}

			return -1;
		}
#pragma warning restore S3900 // Arguments of public methods should be validated against null
	}
}
