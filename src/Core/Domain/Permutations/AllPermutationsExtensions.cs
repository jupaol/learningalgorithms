using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Core.Domain.Permutations
{
	/// <summary>
	/// Permutations formula:
	/// nPk = n! / (n-k)!
	/// </summary>
	public static class AllPermutationsExtensions
	{
		public static string[] GetAllStringPermutationsUsingRecursion(
			this string source)
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			var list = new List<string>();

			GetAllStringPermutationsUsingRecursion(string.Empty, source, list);

			return list.ToArray();
		}

		public static IEnumerable<IEnumerable<T>> GetAllPermutationsNotInLexOrderUsingRecursion<T>(
			this ILearningCollection<T> source)
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			T[] a = source.ToArray();
			var list = new List<T[]>();

			GetAllPermutationsNotInLexOrder(a, 0, list);

			return list;
		}

		public static IEnumerable<IEnumerable<T>> GetAllPermutationsUsingRecursion<T>(
			this ILearningCollection<T> source)
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			var list = new List<T[]>();

			GetAllPermutationsUsingRecursion(new List<T>(), source.ToList(), list);

			return list;
		}

		public static IEnumerable<IEnumerable<T>> GetAllPermutationsOptimizedForDuplicatesUsingRecursion<T>(
			this ILearningCollection<T> source)
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			var res = new List<ICollection<T>>();
			IDictionary<T, int> counts = new Dictionary<T, int>();

			for (int i = 0; source.Skip(i).Any(); i++)
			{
				if (counts.ContainsKey(source.ElementAt(i)))
				{
					counts[source.ElementAt(i)]++;
				}
				else
				{
					counts.Add(source.ElementAt(i), 1);
				}
			}

			GetAllPermutationsOptimizedForDuplicatesUsingRecursion(
				new T[source.Count()],
				counts.Keys.ToArray(),
				counts.Values.ToArray(),
				0,
				res);

			return res;
		}

		private static void GetAllPermutationsOptimizedForDuplicatesUsingRecursion<T>(
			T[] currentPermutation,
			T[] choices,
			int[] counts,
			int level,
			ICollection<ICollection<T>> res)
		{
			if (level == currentPermutation.Length)
			{
				res.Add((T[])currentPermutation.ToArray().Clone());

				return;
			}

			for (int i = 0; i < choices.Length; i++)
			{
				if (counts[i] == 0)
				{
					continue;
				}

				counts[i]--;
				currentPermutation[level] = choices[i];

				GetAllPermutationsOptimizedForDuplicatesUsingRecursion(
					currentPermutation,
					choices,
					counts,
					level + 1,
					res);

				counts[i]++;
			}
		}

		private static void GetAllPermutationsUsingRecursion<T>(
			IList<T> set, ICollection<T> choices, ICollection<T[]> list)
		{
			if (choices.Count == 0)
			{
				list.Add(set.ToArray());

				return;
			}

			for (int i = 0; i < choices.Count; i++)
			{
				ICollection<T> tmpChoices = choices.Where((_, index) => index != i).ToList();

				set.Add(choices.ElementAt(i));

				GetAllPermutationsUsingRecursion(
					set,
					tmpChoices,
					list);

				set.RemoveAt(set.Count - 1);
			}
		}

		private static void GetAllPermutationsNotInLexOrder<T>(T[] a, int start, ICollection<T[]> list)
		{
			if (start >= a.Length)
			{
				list.Add((T[])a.Clone());

				return;
			}

			for (int i = start; i < a.Length; i++)
			{
				Swap(a, i, start);
				GetAllPermutationsNotInLexOrder(a, start + 1, list);
				Swap(a, i, start);
			}
		}

		private static void GetAllStringPermutationsUsingRecursion(string prefix, string suffix, IList<string> list)
		{
			if (string.IsNullOrWhiteSpace(suffix))
			{
				list.Add(prefix);
				return;
			}

			for (int i = 0; i < suffix.Length; i++)
			{
				GetAllStringPermutationsUsingRecursion(
					prefix + suffix[i].ToString(CultureInfo.InvariantCulture),
					suffix.Substring(0, 0 + i) + suffix.Substring(i + 1),
					list);
			}
		}

		private static void Swap<T>(T[] a, int i1, int i2)
		{
			T tmp = a[i1];

			a[i1] = a[i2];
			a[i2] = tmp;
		}
	}
}
