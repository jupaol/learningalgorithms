using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Domain.Combinations
{
	/// <summary>
	/// Combinations formula:
	/// nCk = n! / k!(n -k)!
	/// </summary>
	public static class AllCombinationsExtensions
	{
		public static IEnumerable<IEnumerable<T>> GetAllCombinationsUsingRecursionOptimizedForDuplicates<T>(
			this ILearningCollection<T> source)
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			var res = new List<ICollection<T>>();
			var dictionary = new Dictionary<T, int>();

			foreach (T item in source)
			{
				if (dictionary.ContainsKey(item))
				{
					dictionary[item]++;
				}
				else
				{
					dictionary.Add(item, 1);
				}
			}

			GetAllCombinationsUsingRecursionOptimizedForDuplicates(
				new List<T>(),
				dictionary.Keys.ToArray(),
				dictionary.Values.ToArray(),
				0,
				res);

			return res;
		}

		private static void GetAllCombinationsUsingRecursionOptimizedForDuplicates<T>(
			IList<T> currentCombination, T[] choices, int[] counts, int index, List<ICollection<T>> res)
		{
			res.Add((T[])currentCombination.ToArray().Clone());

			for (int i = index; i < choices.Length && counts[i] != 0; i++)
			{
				counts[i]--;
				currentCombination.Add(choices[i]);

				GetAllCombinationsUsingRecursionOptimizedForDuplicates(
					currentCombination,
					choices,
					counts,
					index + 1,
					res);

				counts[i]++;
				currentCombination.RemoveAt(currentCombination.Count - 1);
			}
		}
	}
}
