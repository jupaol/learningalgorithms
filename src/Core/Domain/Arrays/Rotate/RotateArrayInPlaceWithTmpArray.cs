using System;

namespace Core.Domain.Arrays.Rotate
{
	public class RotateArrayInPlaceWithTmpArray
	{
		public T[] Rotate<T>(T[] source, int positions, RotationType rotationType)
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			int offset = positions % source.Length;

			if (offset == 0)
			{
				return source;
			}

			if (rotationType == RotationType.Right)
			{
				offset = source.Length - offset;
			}

			T[] tmp = new T[source.Length - offset];

			// We'll copy from offset to the end of the array in the tmp array
			for (int i = offset, j = 0; i < source.Length; i++, j++)
			{
				tmp[j] = source[i];
			}

			// we shift the original array, the first part of the array will be moved as it is to the end
			for (int i = offset - 1, j = source.Length - 1; i >= 0; i--, j--)
			{
				source[j] = source[i];
			}

			// we copy back the tmp array into the original array starting at position 0
			for (int i = 0; i < tmp.Length; i++)
			{
				source[i] = tmp[i];
			}

			return source;
		}
	}
}
