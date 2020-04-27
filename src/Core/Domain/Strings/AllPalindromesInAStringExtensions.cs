using System;
using System.Collections.Generic;

namespace Core.Domain.Strings
{
	public static class AllPalindromesInAStringExtensions
	{
		public static IEnumerable<string> FindAllPalindromes(this string source, int minSize)
		{
			if (string.IsNullOrWhiteSpace(source))
			{
				throw new ArgumentNullException(nameof(source));
			}

			var res = new List<string>();

			for (int i = 0; i < source.Length - 1; i++)
			{
				for (int j = i + 1; j < source.Length; j++)
				{
					if (j - i + 1 >= minSize && IsPalindrome(source, i, j))
					{
						res.Add(source.Substring(0, j - i + 1));
					}
				}
			}

			return res;
		}

		public static IEnumerable<string> FindAllPalindromesNSquareRuntime(this string source, int minSize)
		{
			if (string.IsNullOrWhiteSpace(source))
			{
				throw new ArgumentNullException(nameof(source));
			}

			var res = new List<string>();

			for (int i = 0; i < source.Length - 1; i++)
			{
				int left = i - 1;
				int right = i + 1;

				while (left < right && left >= 0 && right < source.Length)
				{
					if (source[left] == source[right] && right - left + 1 >= minSize)
					{
						res.Add(source.Substring(left, right - left + 1));
					}

					left--;
					right++;
				}

				if (source[i] == source[i + 1] && right - left + 1 >= minSize)
				{
					res.Add(source.Substring(i, 2));
				}
			}

			return res;
		}

		private static bool IsPalindrome(string source, int min, int max)
		{
			while (min < max)
			{
				if (source[min] != source[max])
				{
					return false;
				}

				min++;
				max--;
			}

			return true;
		}
	}
}
