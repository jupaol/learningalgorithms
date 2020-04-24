using System;
using System.Linq;

namespace Core.Domain.General
{
	public static class FraudulentActivityNotificationsCountingSort
	{
		public static int ActivityNotificationsUsingCountingSort(this int[] expenditure, int d)
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
			int[] counts = new int[expenditure.Max() + 1];

			for (int i = 0; i < d; i++)
			{
				counts[expenditure[i]]++;
			}

			for (int i = d; i < expenditure.Length; i++)
			{
				int prevItem = i - d - 1;
				int newItem = i - 1;

				if (i != d && expenditure[prevItem] != expenditure[newItem])
				{
					counts[expenditure[prevItem]]--;
					counts[expenditure[newItem]]++;
				}

				if (expenditure[i] >= GetMedian(counts, d) * 2f)
				{
					alerts++;
				}
			}

			return alerts;
		}

		private static float GetMedian(int[] counts, int d)
		{
			int sum = 0;
			int mid;
			int i = 0;

			if (d % 2 != 0)
			{
				mid = d / 2;

				while (i < counts.Length)
				{
					sum += counts[i];

					if (sum > mid)
					{
						break;
					}

					i++;
				}

				return i;
			}

			mid = (d - 1) / 2;

			while (i < counts.Length)
			{
				sum += counts[i];

				if (sum > mid)
				{
					break;
				}

				i++;
			}

			if (sum - 1 > mid && counts[i] > 1)
			{
				return i;
			}

			int j = i + 1;

			while (j < counts.Length && counts[j] == 0)
			{
				j++;
			}

			return (i + j) / 2f;
		}
	}
}
