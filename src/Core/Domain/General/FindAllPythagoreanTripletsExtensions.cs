using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Domain.General
{
	public static class FindAllPythagoreanTripletsExtensions
	{
		public static IEnumerable<IEnumerable<int>> FindAllPythagoreanTriplets(
			this ILearningCollection<int> source)
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			if (!source.Any())
			{
				return Enumerable.Empty<IEnumerable<int>>();
			}

			int[] arr = source.OrderBy(x => x).ToArray();
			var list = new List<int[]>();

			for (int i = arr.Length - 1; i >= 2; i--)
			{
				int left = 0;
				int right = i - 1;

				while (left < right)
				{
					int a = arr[left] * arr[left];
					int b = arr[right] * arr[right];
					int c = arr[i] * arr[i];

					if (a + b == c)
					{
						list.Add(new[] { arr[left], arr[right], arr[i] });
						left++;
					}
					else if (a + b < c)
					{
						left++;
					}
					else
					{
						right--;
					}
				}
			}

			return list;
		}
	}
}
