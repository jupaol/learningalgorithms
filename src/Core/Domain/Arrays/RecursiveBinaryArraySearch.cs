using System;

namespace Core.Domain.Arrays
{
	public class RecursiveBinaryArraySearch : IArraySearch
	{
		public int Search<T>(T[] source, T key)
			where T : IComparable<T>
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			return DoSearch(source, key, 0, source.Length - 1);
		}

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
