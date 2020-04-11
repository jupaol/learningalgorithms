using System;

namespace Core.Domain.Arrays.Sort
{
	public class SelectSort
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
				int minimumIndex = i;

				for (int j = i + 1; j < source.Length; j++)
				{
					if (source[j].CompareTo(source[minimumIndex]) < 0)
					{
						minimumIndex = j;
					}
				}

				Swap(source, i, minimumIndex);
			}

			return source;
		}

		private void Swap<T>(T[] source, in int index1, in int index2)
			where T : IComparable<T>
		{
			T item = source[index1];

			source[index1] = source[index2];
			source[index2] = item;
		}
	}
}
