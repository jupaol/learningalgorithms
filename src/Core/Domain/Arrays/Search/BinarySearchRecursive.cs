using System;

namespace Core.Domain.Arrays.Search
{
	public class BinarySearchRecursive
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

			if (key.CompareTo(source[0]) < 0 || key.CompareTo(source[^1]) > 0)
			{
				return -1;
			}

			return DoSearch(source, key, 0, source.Length - 1);
		}
#pragma warning restore S3900 // Arguments of public methods should be validated against null

		private int DoSearch<T>(T[] source, T key, int min, int max)
			where T : IComparable<T>
		{
			if (min > max)
			{
				return -1;
			}

			int mid = (min + max) / 2;

			if (source[mid].Equals(key))
			{
				return mid;
			}

			return key.CompareTo(source[mid]) < 0
				? DoSearch(source, key, min, mid - 1)
				: DoSearch(source, key, mid + 1, max);
		}
	}
}
