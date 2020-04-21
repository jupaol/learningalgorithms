using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Domain.Arrays
{
	public static class CharacterFrequenciesExtensions
	{
		/// <summary>
		/// A string is considered to be valid if all characters appear the same number of times.
		/// You are allowed to remove only one character from the string
		/// </summary>
		/// <param name="s">The string to validate</param>
		/// <example>
		/// String: abc is valid since a: 1, b: 1 and c: 1
		/// </example>
		/// <example>
		/// String: abcc is valid since a: 1, b: 1 and c: 2, however we are allowed to remove one character
		/// so we can remove a 'c' and then the 'c' count will be: c: 1 making them all even.
		/// </example>
		/// <example>
		/// String: abccc is not valid since even after removing one character (a 'c') the letter count
		/// wouldn't be the same
		/// </example>
		/// <returns>
		/// Returns <c>true</c> if all characters of the string have the same count, otherwise <c>false</c>
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// Thrown when the string is null or empty
		/// </exception>
		public static bool IsStringValid(this string s)
		{
			if (string.IsNullOrWhiteSpace(s))
			{
				throw new ArgumentNullException(nameof(s));
			}

			var hash = new Dictionary<char, int>();

			for (int i = 0; i < s.Length; i++)
			{
				if (!hash.ContainsKey(s[i]))
				{
					hash.Add(s[i], 1);
				}
				else
				{
					hash[s[i]]++;
				}
			}

			var counts = new Dictionary<int, int>();

			foreach (KeyValuePair<char, int> item in hash)
			{
				if (!counts.ContainsKey(item.Value))
				{
					if (counts.Count == 2)
					{
						return false;
					}

					counts.Add(item.Value, 1);
				}
				else
				{
					counts[item.Value]++;
				}
			}

			if (counts.Count == 2)
			{
				KeyValuePair<int, int> first = counts.First();
				KeyValuePair<int, int> last = counts.Last();

				if (first.Value > 1 && last.Value > 1)
				{
					return false;
				}

				if (first.Value == 1)
				{
					return first.Key - 1 == 0 || first.Key - 1 == last.Key;
				}

				if (last.Value == 1)
				{
					return last.Key - 1 == 0 || last.Key - 1 == first.Key;
				}
			}

			return true;
		}
	}
}
