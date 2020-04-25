using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Domain.Permutations
{
	public static class AllPermutationsOfBalancedBracersExtensions
	{
		public static IEnumerable<IEnumerable<char>> GetAllBalancedBracersPermutations(
			this int n)
		{
			var res = new List<char[]>();

			GetAllBalancedBracersPermutationsRec(
				0,
				0,
				n,
				'{',
				'}',
				new List<char>(),
				res);

			return res;
		}

		public static IEnumerable<IEnumerable<char>> GetAllBalancedBracersPermutationsUsingCounts(
			this int n)
		{
			var res = new List<char[]>();
			char[] choices = new char[2];
			int[] counts = new int[2];

			choices[0] = '{';
			choices[1] = '}';

			counts[0] = n;
			counts[1] = n;

			GetAllBalancedBracersPermutationsUsingCountsRec(
				choices, counts, new List<char>(), res);

			return res;
		}

		private static void GetAllBalancedBracersPermutationsRec(
			int leftCount,
			int rightCount,
			in int n,
			char openBracer,
			char closeBracer,
			IList<char> currentCombination,
			ICollection<char[]> res)
		{
			if (leftCount >= n && rightCount >= n)
			{
				res.Add(currentCombination.ToArray());
			}

			if (leftCount < n)
			{
				currentCombination.Add(openBracer);
				GetAllBalancedBracersPermutationsRec(
					leftCount + 1, rightCount, n, openBracer, closeBracer, currentCombination, res);
				currentCombination.RemoveAt(currentCombination.Count - 1);
			}

			if (rightCount < leftCount)
			{
				currentCombination.Add(closeBracer);
				GetAllBalancedBracersPermutationsRec(
					leftCount, rightCount + 1, n, openBracer, closeBracer, currentCombination, res);
				currentCombination.RemoveAt(currentCombination.Count - 1);
			}
		}

		private static void GetAllBalancedBracersPermutationsUsingCountsRec(
			char[] choices,
			int[] counts,
			IList<char> currentPermutation,
			ICollection<char[]> res)
		{
			if (counts.All(x => x == 0) && AreBracersBalanced(currentPermutation))
			{
				res.Add(currentPermutation.ToArray());
			}

			for (int i = 0; i < choices.Length; i++)
			{
				if (counts[i] == 0)
				{
					continue;
				}

				counts[i]--;
				currentPermutation.Add(choices[i]);

				GetAllBalancedBracersPermutationsUsingCountsRec(
					choices, counts, currentPermutation, res);

				counts[i]++;
				currentPermutation.RemoveAt(currentPermutation.Count - 1);
			}
		}

		private static bool AreBracersBalanced(IEnumerable<char> bracers)
		{
			if (!bracers.Any() || bracers.Count() % 2 != 0)
			{
				return false;
			}

			var stack = new Stack<char>();

			foreach (char c in bracers)
			{
				if (IsOpenedBracer(c))
				{
					stack.Push(c);
				}
				else if (IsClosedBracer(c))
				{
					if (stack.Count == 0)
					{
						return false;
					}

					if (IsBracerMatch(stack.Peek(), c))
					{
						stack.Pop();
					}
					else
					{
						stack.Push(c);
					}
				}
				else
				{
					throw new Exception("Invalid character found");
				}
			}

			return stack.Count == 0;
		}

		private static bool IsOpenedBracer(char c)
		{
			return new[] { '{', '(', '[' }.Contains(c);
		}

		private static bool IsClosedBracer(char c)
		{
			return new[] { '}', '(', ']' }.Contains(c);
		}

		private static bool IsBracerMatch(char open, char close)
		{
			var dic = new Dictionary<char, char>
			{
				{ '{', '}' },
				{ '(', ')' },
				{ '[', ']' }
			};

			return
				IsOpenedBracer(open)
				&& IsClosedBracer(close)
				&& dic[open] == close;
		}
	}
}
