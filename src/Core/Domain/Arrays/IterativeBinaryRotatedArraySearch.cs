﻿using System;

namespace Core.Domain.Arrays
{
	public class IterativeBinaryRotatedArraySearch : IRotatedArraySearch
	{
#pragma warning disable S3900 // Arguments of public methods should be validated against null
		public int Search<T>(T[] source, T key, int rotatedPositions, RotationType rotationType)
			where T : IComparable<T>
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			if (source.Length == 0)
			{
				return -1;
			}

			int offset = rotatedPositions % source.Length;

			if (offset == 0)
			{
				return DoSearch(source, key, 0, source.Length - 1);
			}

			switch (rotationType)
			{
				case RotationType.Right:
				{
					// searches the second half of the array
					int res = DoSearch(source, key, offset, source.Length - 1);

					// searches the first half
					return res == -1 ? DoSearch(source, key, 0, offset - 1) : res;
				}

				case RotationType.Left:
				{
					// searches the second half of the array
					int res = DoSearch(source, key, source.Length - offset, source.Length - 1);

					// searches the first half
					return res == -1 ? DoSearch(source, key, 0, source.Length - offset - 1) : res;
				}

				default:
					throw new ArgumentOutOfRangeException(nameof(rotationType), rotationType, null);
			}
		}
#pragma warning restore S3900 // Arguments of public methods should be validated against null

		private int DoSearch<T>(T[] source, T key, int min, int max)
			where T : IComparable<T>
		{
			while (min <= max && min >= 0 && max < source.Length)
			{
				int mid = (min + max) / 2;
				int comparisonResult = key.CompareTo(source[mid]);

				if (comparisonResult == 0)
				{
					return mid;
				}

				if (comparisonResult < 0)
				{
					max = mid - 1;
				}

				if (comparisonResult > 0)
				{
					min = mid + 1;
				}
			}

			return -1;
		}
	}
}
