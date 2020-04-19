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

			GetAllPermutations(string.Empty, source, list);

			return list.ToArray();
		}

		public static IEnumerable<IEnumerable<T>> GetAllPermutationsUsingRecursion<T>(
			this IEnumerable<T> source)
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			T[] a = source.ToArray();
			var list = new List<T[]>();

			GetAllPermutations(a, 0, list);

			return list;
		}

		private static void GetAllPermutations<T>(T[] a, int start, ICollection<T[]> list)
		{
			if (start >= a.Length)
			{
				list.Add((T[])a.Clone());

				return;
			}

			for (int i = start; i < a.Length; i++)
			{
				Swap(a, i, start);
				GetAllPermutations(a, start + 1, list);
				Swap(a, i, start);
			}
		}

		private static void GetAllPermutations(string prefix, string suffix, IList<string> list)
		{
			if (string.IsNullOrWhiteSpace(suffix))
			{
				list.Add(prefix);
				return;
			}

			for (int i = 0; i < suffix.Length; i++)
			{
				GetAllPermutations(
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
