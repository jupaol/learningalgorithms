using System;

namespace Core.Domain.Arrays.Search
{
	public class BinarySearchIterative
	{
#pragma warning disable S3900 // Arguments of public methods should be validated against null
		public int Search<T>(T[] source, T key)
			where T : IComparable<T>
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			int min = 0;
			int max = source.Length - 1;

			if (source.Length == 0)
			{
				return -1;
			}

			if (key.CompareTo(source[0]) < 0 || key.CompareTo(source[^1]) > 0)
			{
				return -1;
			}

			while (min <= max && min >= 0 && max < source.Length)
			{
				int mid = (max + min) / 2;

				if (source[mid].Equals(key))
				{
					return mid;
				}

				if (key.CompareTo(source[mid]) < 0)
				{
					max = mid - 1;
				}
				else
				{
					min = mid + 1;
				}
			}

			return -1;
		}
#pragma warning restore S3900 // Arguments of public methods should be validated against null
	}
}
