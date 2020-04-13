using System;

namespace Core.Domain.Arrays.Search
{
	public class BinarySearchRotatedRecursive
	{
#pragma warning disable S3900 // Arguments of public methods should be validated against null
		public int Search<T>(T[] source, T key, int rotatedPositions, Direction direction)
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

			int offset = rotatedPositions % source.Length;

			if (offset == 0)
			{
				return DoSearch(source, key, 0, source.Length - 1);
			}

			switch (direction)
			{
				case Direction.Right:
				{
					// searches the second half of the array
					int res = DoSearch(source, key, offset, source.Length - 1);

					// searches the first half
					return res == -1 ? DoSearch(source, key, 0, offset - 1) : res;
				}

				case Direction.Left:
				{
					// searches the second half of the array
					int res = DoSearch(source, key, source.Length - offset, source.Length - 1);

					// searches the first half
					return res == -1 ? DoSearch(source, key, 0, source.Length - offset - 1) : res;
				}

				default:
					throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
			}
		}
#pragma warning restore S3900 // Arguments of public methods should be validated against null

		private int DoSearch<T>(T[] source, T key, int min, int max)
			where T : IComparable<T>
		{
			if (min > max || min < 0 || max >= source.Length)
			{
				return -1;
			}

			int mid = (min + max) / 2;
			int comparisonResult = key.CompareTo(source[mid]);

			if (comparisonResult == 0)
			{
				return mid;
			}

			if (comparisonResult < 0)
			{
				return DoSearch<T>(source, key, min, mid - 1);
			}

			// This searches on the right side, when comparisonResult > 0
			return DoSearch<T>(source, key, mid + 1, max);
		}
	}
}
