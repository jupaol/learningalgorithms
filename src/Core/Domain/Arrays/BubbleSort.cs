using System;

namespace Core.Domain.Arrays
{
	public class BubbleSort : ISortArray
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

			for (int i = 0; i < source.Length - 1; i++)
			{
				for (int j = 0; j < source.Length - i - 1; j++)
				{
					if (source[j].CompareTo(source[j + 1]) > 0)
					{
						Swap(source, j, j + 1);
					}
				}
			}

			return source;
		}

		private void Swap<T>(T[] source, int index1, int index2)
			where T : IComparable<T>
		{
			T item = source[index1];

			source[index1] = source[index2];
			source[index2] = item;
		}
	}
}
