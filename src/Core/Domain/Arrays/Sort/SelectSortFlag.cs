using System;

namespace Core.Domain.Arrays.Sort
{
	public class SelectSortFlag
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
				bool wasThereSwap = false;

				for (int j = i + 1; j < source.Length; j++)
				{
					if (source[j].CompareTo(source[minimumIndex]) < 0)
					{
						minimumIndex = j;
						wasThereSwap = true;
					}
				}

				if (!wasThereSwap)
				{
#pragma warning disable S1227 // break statements should not be used except for switch cases
					break;
#pragma warning restore S1227 // break statements should not be used except for switch cases
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
