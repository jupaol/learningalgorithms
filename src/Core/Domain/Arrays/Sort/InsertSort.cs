using System;

namespace Core.Domain.Arrays.Sort
{
	public class InsertSort
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

			for (int i = 1; i < source.Length; i++)
			{
				T item = source[i];
				int hole = i;

				while (hole > 0 && source[hole - 1].CompareTo(item) > 0)
				{
					source[hole] = source[hole - 1];
					hole--;
				}

				source[hole] = item;
			}

			return source;
		}
	}
}
