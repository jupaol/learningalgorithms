using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Domain.Combinations
{
	/// <summary>
	/// Combinations formula:
	/// nCk = n! / k!(n -k)!
	///
	/// Another formula for the combinations is: 2^n, so for an array of three elements, we have:
	/// 2^3 = 8
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

		public static IEnumerable<IEnumerable<T>> GetAllCombinationsUsingBinaryMethod<T>(
			this ILearningCollection<T> source)
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			int max = CalculateExponentialBase2(source.Count());
			var res = new List<ICollection<T>> { Array.Empty<T>() };

			for (int i = 1; i < max; i++)
			{
				int[] indexAsBinary = ToBinary(i).ToArray();
				var currentCombination = new List<T>();

				for (int j = indexAsBinary.Length - 1, tmp = 0; j >= 0; j--, tmp++)
				{
					if (indexAsBinary[j] == 1)
					{
						currentCombination.Add(source.ElementAt(tmp));
					}
				}

				res.Add(currentCombination);
			}

			return res;
		}

		private static void GetAllCombinationsUsingRecursionOptimizedForDuplicates<T>(
			IList<T> currentCombination, T[] choices, int[] counts, int index, List<ICollection<T>> res)
		{
			res.Add((T[])currentCombination.ToArray().Clone());

			for (int i = index; i < choices.Length; i++)
			{
				if (counts[i] == 0)
				{
					continue;
				}

				counts[i]--;
				currentCombination.Add(choices[i]);

				GetAllCombinationsUsingRecursionOptimizedForDuplicates(
					currentCombination,
					choices,
					counts,
					i,
					res);

				counts[i]++;
				currentCombination.RemoveAt(currentCombination.Count - 1);
			}
		}

		private static int CalculateExponentialBase2(int n)
		{
			if (n == 0)
			{
				return 1;
			}

			int tmp = 1;

			for (int i = 1; i <= n; i++)
			{
				tmp *= 2;
			}

			return tmp;
		}

		private static IEnumerable<int> ToBinary(int n)
		{
			if (n == 0)
			{
				return new[] { 0 };
			}

			if (n == 1)
			{
				return new[] { 1 };
			}

			var res = new List<int>();
			int tmp = n;

			while (tmp >= 1)
			{
				res.Add(tmp);

				tmp /= 2;
			}

			for (int i = 0; i < res.Count; i++)
			{
				res[i] = res[i] % 2 == 0 ? 0 : 1;
			}

			res.Reverse();

			return res;
		}
	}
}
