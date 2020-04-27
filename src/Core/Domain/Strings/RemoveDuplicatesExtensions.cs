using System;
using System.Collections.Generic;

namespace Core.Domain.Strings
{
	public static class RemoveDuplicatesExtensions
	{
		public static void RemoveDuplicateCharacters(this char[] source)
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			var hash = new HashSet<char>();
			int writingIndex = -1;

			for (int readingIndex = 0; readingIndex < source.Length; readingIndex++)
			{
				if (hash.Contains(source[readingIndex]))
				{
					if (writingIndex == -1)
					{
						writingIndex = readingIndex;
					}
				}
				else
				{
					hash.Add(source[readingIndex]);

					if (writingIndex != -1)
					{
						source[writingIndex] = source[readingIndex];
						writingIndex++;
					}
				}
			}

			source[writingIndex] = '\0';
		}
	}
}
