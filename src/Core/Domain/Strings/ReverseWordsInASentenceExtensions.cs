using System;

namespace Core.Domain.Strings
{
	public static class ReverseWordsInASentenceExtensions
	{
		public static string ReverseWordsInASentence(this string source)
		{
			if (string.IsNullOrWhiteSpace(source))
			{
				throw new ArgumentNullException(nameof(source));
			}

			char[] arr = source.ToCharArray();
			int start = -1;

			Reverse(arr, 0, arr.Length - 1);

			for (int i = 0; i < arr.Length; i++)
			{
				if (char.IsWhiteSpace(arr[i]))
				{
					if (start != -1)
					{
						Reverse(arr, start, i - 1);
						start = -1;
					}
				}
				else if (i == arr.Length - 1)
				{
					if (start != -1)
					{
						Reverse(arr, start, i);
					}
				}
#pragma warning disable S126 // "if ... else if" constructs should end with "else" clauses
				else if (start == -1)
#pragma warning restore S126 // "if ... else if" constructs should end with "else" clauses
				{
					start = i;
				}
			}

			return new string(arr);
		}

		private static void Reverse(char[] arr, int min, int max)
		{
			while (min < max)
			{
				Swap(arr, min, max);
				min++;
				max--;
			}
		}

		private static void Swap(char[] arr, int i1, int i2)
		{
			char tmp = arr[i1];

			arr[i1] = arr[i2];
			arr[i2] = tmp;
		}
	}
}
