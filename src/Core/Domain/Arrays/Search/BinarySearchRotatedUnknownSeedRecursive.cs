using System;

namespace Core.Domain.Arrays.Search
{
	public class BinarySearchRotatedUnknownSeedRecursive
	{
#pragma warning disable S3900 // Arguments of public methods should be validated against null
		public int Search<T>(T[] source, T key)
			where T : IComparable<T>
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			if (source.Length == 0)
			{
				return -1;
			}

			return DoSearch(source, key, 0, source.Length - 1);
		}

		private int DoSearch<T>(T[] source, T key, int left, int right)
			where T : IComparable<T>
		{
			if (left > right || left < 0 || right >= source.Length)
			{
				return -1;
			}

			int mid = (left + right) / 2;
			int midComparisonResult = key.CompareTo(source[mid]);

			if (midComparisonResult == 0)
			{
				return mid;
			}

			if (key.CompareTo(source[left]) == 0)
			{
				return left;
			}

			if (key.CompareTo(source[right]) == 0)
			{
				return right;
			}

			bool isLeftSorted = source[left].CompareTo(source[mid]) <= 0;
			bool isRightSorted = source[mid].CompareTo(source[right]) <= 0;
			bool isKeyOnLeftSideIfSorted =
				key.CompareTo(source[left]) >= 0 && key.CompareTo(source[mid]) <= 0;
			bool isKeyOnRightSideIfSorted =
				key.CompareTo(source[mid]) >= 0 && key.CompareTo(source[right]) <= 0;

			if (isLeftSorted && isKeyOnLeftSideIfSorted)
			{
				return DoSearch(source, key, left, mid - 1);
			}

			if (isRightSorted && isKeyOnRightSideIfSorted)
			{
				return DoSearch(source, key, mid + 1, right);
			}

			if (!isLeftSorted && isRightSorted)
			{
				return DoSearch(source, key, left, mid - 1);
			}

			if (!isRightSorted && isLeftSorted)
			{
				return DoSearch(source, key, mid + 1, right);
			}

			return DoSearch(source, key, left + 1, right - 1);
		}
#pragma warning restore S3900 // Arguments of public methods should be validated against null
	}
}
