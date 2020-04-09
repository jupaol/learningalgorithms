using System;

namespace Core.Domain.Arrays
{
	public class RotateArray : IRotateArray
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

			var res = new T[source.Length];

			if (rotationType == RotationType.Left)
			{
				for (int i = offset, j = 0; i < source.Length; i++, j++)
				{
					res[j] = source[i];
				}

				for (int i = 0, j = source.Length - offset; i < offset; i++, j++)
				{
					res[j] = source[i];
				}
			}

			if (rotationType == RotationType.Right)
			{
				for (int i = source.Length - offset, j = 0; i < source.Length; i++, j++)
				{
					res[j] = source[i];
				}

				for (int i = 0, j = offset; i < source.Length - offset; i++, j++)
				{
					res[j] = source[i];
				}
			}

			return res;
		}
	}
}
