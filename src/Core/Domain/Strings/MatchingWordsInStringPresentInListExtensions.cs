using System;
using System.Collections.Generic;

namespace Core.Domain.Strings
{
	public static class MatchingWordsInStringPresentInListExtensions
	{
		public static bool ContainsAllWordsInList(
			this string source, HashSet<string> hash)
		{
			if (string.IsNullOrWhiteSpace(source))
			{
				throw new ArgumentNullException(nameof(source));
			}

			if (hash == null)
			{
				throw new ArgumentNullException(nameof(hash));
			}

			if (hash.Count == 0)
			{
				return false;
			}

			if (hash.Contains(source))
			{
				return true;
			}

			return ContainsAllWordsInListRec(source, hash);
		}

		private static bool ContainsAllWordsInListRec(
			string choices, HashSet<string> hash)
		{
			for (int i = 0; i < choices.Length; i++)
			{
				string s1 = choices.Substring(0, i + 1);
				bool isS1Contained = hash.Contains(s1);

				if (isS1Contained)
				{
					string s2 = choices.Substring(i + 1);

					if (
						string.IsNullOrWhiteSpace(s2) ||
						hash.Contains(s2) ||
						ContainsAllWordsInListRec(s2, hash))
					{
						return true;
					}
				}
			}

			return false;
		}
	}
}
