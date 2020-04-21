using System;
using System.Text;

namespace Core.Domain.Permutations
{
	public static class FindPermutationExtensions
	{
		public static string FindPermutationUsingRecursion(
			this string source, int k)
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			var sb = new StringBuilder();

			FindPermutationUsingRecursion(source, k, sb);

			return sb.ToString();
		}

		private static void FindPermutationUsingRecursion(string source, int k, StringBuilder sb)
		{
			if (string.IsNullOrWhiteSpace(source))
			{
				return;
			}

			int n = source.Length;
			int nFac = GetFactorial(n - 1);
			int index = (k - 1) / nFac;
			sb.Append(source[index]);

			k -= nFac * index;

			FindPermutationUsingRecursion(source.Remove(index, 1), k, sb);
		}

		private static int GetFactorial(int n)
		{
			int res = 1;

			for (int i = 0; i < n; i++)
			{
				res *= n - i;
			}

			return res;
		}
	}
}
