using System;

namespace Core.Domain.Arrays
{
	public class MaxItem
	{
		public T Maximum<T>(T[] source)
			where T : IComparable<T>
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			if (source.Length == 0)
			{
				throw new ArgumentException("Empty array", nameof(source));
			}

			T max = source[0];

			for (int i = 1; i < source.Length; i++)
			{
				if (source[i].CompareTo(max) > 0)
				{
					max = source[i];
				}
			}

			return max;
		}
	}
}
