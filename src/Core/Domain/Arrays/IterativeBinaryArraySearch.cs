using System;

namespace Core.Domain.Arrays
{
	public class IterativeBinaryArraySearch : IArraySearch
	{
		public int Search<T>(T[] source, T key)
			where T : IComparable<T>
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			int min = 0;
			int max = source.Length - 1;

			while (min <= max && min >= 0 && max < source.Length)
			{
				int mid = (max + min) / 2;

				if (source[mid].Equals(key))
				{
					return mid;
				}

#pragma warning disable S3900 // Arguments of public methods should be validated against null
				if (key.CompareTo(source[mid]) < 0)
#pragma warning restore S3900 // Arguments of public methods should be validated against null
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
	}
}
