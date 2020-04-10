using System;

namespace Core.Domain.Arrays
{
	public class RotateArrayInPlace : IRotateArray
	{
		public T[] Rotate<T>(T[] source, int positions, RotationType rotationType)
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			if (source.Length == 0)
			{
				return Array.Empty<T>();
			}

			int offset = positions % source.Length;

			if (offset == 0)
			{
				return source;
			}

			SwapAll(source, 0, source.Length - 1);

			if (rotationType == RotationType.Left)
			{
				offset = source.Length - offset;
			}

			SwapAll(source, 0, offset - 1);
			SwapAll(source, offset, source.Length - 1);

			return source;
		}

		private void SwapAll<T>(T[] source, int left, int right)
		{
			while (left < right)
			{
				Swap(source, left++, right--);
			}
		}

		private void Swap<T>(T[] source, int index1, int index2)
		{
			T item = source[index1];

			source[index1] = source[index2];
			source[index2] = item;
		}
	}
}
