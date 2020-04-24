using System;
using System.Linq;

namespace Core.Domain.General
{
	public static class FraudulentActivityNotifications
	{
		public static int ActivityNotifications(this int[] expenditure, int d)
		{
			if (expenditure == null)
			{
				throw new ArgumentNullException(nameof(expenditure));
			}

			if (d >= expenditure.Length)
			{
				return 0;
			}

			int alerts = 0;
			int[] list = expenditure.Skip(0).Take(d).OrderBy(x => x).ToArray();

			for (int i = d; i < expenditure.Length; i++)
			{
				int min = i - d;
				int max = i - 1;

				if (i != d && expenditure[min - 1] != expenditure[max])
				{
					InsertAndRemove(list, expenditure[min - 1], expenditure[max]);
				}

				////list.Should().ContainInOrder(expenditure.Skip(i - d).Take(d).OrderBy(x => x));

				double medianThreshold = GetMedianFromSortedArray(list) * 2;

				if (expenditure[i] >= medianThreshold)
				{
					alerts++;
				}
			}

			return alerts;
		}

		private static void ShiftRight(int[] list, int targetIndex)
		{
			int hole = targetIndex;
			int value = list[hole];
			int i = hole - 1;

			while (i >= 0 && value < list[i])
			{
				list[hole--] = list[i--];
			}

			list[hole] = value;
		}

		private static void ShiftLeft(int[] list, int targetIndex)
		{
			int hole = targetIndex;
			int value = list[hole];
			int i = hole + 1;

			while (i < list.Length && value > list[i])
			{
				list[hole++] = list[i++];
			}

			list[hole] = value;
		}

		private static void InsertAndRemove(int[] list, int remove, int insert)
		{
			// remove expenditure[min - 1] and insert expenditure[max] from list
			int targetIndex;

			if (list[0] == remove)
			{
				list[0] = insert;
				targetIndex = 0;

				if (list[0] <= list[1])
				{
					return;
				}

				ShiftLeft(list, targetIndex);
				return;
			}

			if (list[^1] == remove)
			{
				list[^1] = insert;
				targetIndex = list.Length - 1;

				if (list[^1] >= list[^2])
				{
					return;
				}

				ShiftRight(list, targetIndex);
				return;
			}

			targetIndex = Array.BinarySearch(list, remove);

			list[targetIndex] = insert;

			if (list[targetIndex] >= list[targetIndex - 1] && list[targetIndex] <= list[targetIndex + 1])
			{
				return;
			}

			if (list[targetIndex] < list[targetIndex - 1])
			{
				ShiftRight(list, targetIndex);
			}
			else
			{
				ShiftLeft(list, targetIndex);
			}
		}

		private static double GetMedianFromSortedArray(int[] tmp)
		{
			if (tmp.Length % 2 == 0)
			{
				int mid1 = tmp[tmp.Length / 2];
				int mid2 = tmp[(tmp.Length / 2) - 1];

				return (mid1 + mid2) / 2D;
			}

			return tmp[tmp.Length / 2] + 0D;
		}
	}
}
