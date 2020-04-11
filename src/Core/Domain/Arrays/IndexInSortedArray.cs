using System;

namespace Core.Domain.Arrays
{
	public class IndexInSortedArray
	{
#pragma warning disable S3900 // Arguments of public methods should be validated against null
		public int FindMinimumIndex<T>(T[] source, T key)
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

			int left = 0;
			int right = source.Length - 1;
			int mid = (left + right) / 2;

			while (left <= right)
			{
				int midComparison = key.CompareTo(source[mid]);

				if (midComparison <= 0)
				{
					right = mid - 1;
				}
				else
				{
					left = mid + 1;
				}

				mid = left + ((right - left) / 2);
			}

			if (left >= 0 && left < source.Length && source[left].Equals(key))
			{
				return left;
			}

			return -1;
		}

		public int FindMaximumIndex<T>(T[] source, T key)
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

			int left = 0;
			int right = source.Length - 1;
			int mid = (left + right) / 2;

			while (left <= right)
			{
				int midComparisonResult = key.CompareTo(source[mid]);

				if (midComparisonResult >= 0)
				{
					left = mid + 1;
				}
				else
				{
					right = mid - 1;
				}

				mid = left + ((right - left) / 2);
			}

			if (right >= 0 && right < source.Length && key.Equals(source[right]))
			{
				return right;
			}

			return -1;
		}
#pragma warning restore S3900 // Arguments of public methods should be validated against null
	}
}
