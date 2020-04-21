using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Core.Domain.Permutations
{
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
