using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Domain.Arrays
{
	public static class SumContainedInArray
	{
		public static bool IsSumContained(this ILearningCollection<int> source, int sum)
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			int[] arr = source.ToArray();
			var hash = new HashSet<int>();

			for (int i = 0; i < arr.Length; i++)
			{
				if (hash.Contains(sum - arr[i]))
				{
					// the two elements that their sum equals "sum" are:
					// arr[i] and (sum - arr[i])
					return true;
				}

				hash.Add(arr[i]);
			}

			return false;
		}

		public static bool IsSumContainedInSortedCollection(this ILearningCollection<int> source, int sum)
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			int[] arr = source.ToArray();
			int min = 0;
			int max = arr.Length - 1;

			while (min < max)
			{
				int currentSum = min + max;

				if (currentSum == sum)
				{
					return true;
				}

				if (currentSum > sum)
				{
					max--;
				}
				else
				{
					min++;
				}
			}

			return false;
		}
	}
}
