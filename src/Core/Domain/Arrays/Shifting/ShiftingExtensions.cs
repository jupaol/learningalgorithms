using System;

namespace Core.Domain.Arrays.Shifting
{
	public static class ShiftingExtensions
	{
		public static void ShiftLeftInSortedArray<T>(this T[] list, int targetIndex)
			where T : IComparable<T>
		{
			if (list == null)
			{
				throw new ArgumentNullException(nameof(list));
			}

			int hole = targetIndex;
			T value = list[hole];
			int i = hole + 1;

			while (i < list.Length && value.CompareTo(list[i]) > 0)
			{
				list[hole++] = list[i++];
			}

			list[hole] = value;
		}

		public static void ShiftRightInSortedArray<T>(this T[] list, int targetIndex)
			where T : IComparable<T>
		{
			if (list == null)
			{
				throw new ArgumentNullException(nameof(list));
			}

			int hole = targetIndex;
			T value = list[hole];
			int i = hole - 1;

			while (i >= 0 && value.CompareTo(list[i]) < 0)
			{
				list[hole--] = list[i--];
			}

			list[hole] = value;
		}
	}
}
