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

			T max = default;

			for (int i = 0; i < source.Length - 1; i++)
			{
				if (i == 0)
				{
					max = source[i].CompareTo(source[i + 1]) > 0 ? source[i] : source[i + 1];

					continue;
				}

				if (source[i].CompareTo(source[i + 1]) > 0 && source[i].CompareTo(max) > 0)
				{
					max = source[i];
				}
			}

			return max;
		}
	}
}
