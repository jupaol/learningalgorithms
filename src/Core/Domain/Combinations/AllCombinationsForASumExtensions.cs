using System.Collections.Generic;
using System.Linq;

namespace Core.Domain.Combinations
{
	public static class AllCombinationsForASumExtensions
	{
		public static IEnumerable<IEnumerable<int>> AllCombinationsForASumUsingRecursion(
			this int sum)
		{
			List<int> arr = Enumerable.Range(1, sum - 1).ToList();
			var res = new List<ICollection<int>>();
			IDictionary<int, int> dictionary = new Dictionary<int, int>();

			foreach (int item in arr)
			{
				dictionary.Add(item, sum);
			}

			AllCombinationsForASumUsingRecursion(
				dictionary.Keys.ToArray(),
				dictionary.Values.ToArray(),
				new List<int>(),
				0,
				res,
				sum,
				0);

			return res;
		}

		private static void AllCombinationsForASumUsingRecursion(
			int[] choices,
			int[] counts,
			IList<int> currentCombination,
			int index,
			ICollection<ICollection<int>> res,
			int targetSum,
			int currentSum)
		{
			if (currentSum == targetSum)
			{
				res.Add((int[])currentCombination.ToArray().Clone());

				return;
			}

			for (int i = index; i < choices.Length; i++)
			{
				if (counts[i] == 0)
				{
					continue;
				}

				currentCombination.Add(choices[i]);
				counts[i]--;

				AllCombinationsForASumUsingRecursion(
					choices,
					counts,
					currentCombination,
					i,
					res,
					targetSum,
					currentSum + choices[i]);

				counts[i]++;
				currentCombination.RemoveAt(currentCombination.Count - 1);
			}
		}
	}
}
