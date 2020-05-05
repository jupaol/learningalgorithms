using System.Collections.Generic;
using System.Linq;

namespace Core.Domain.General
{
	public static class FrequencyQueriesExtensions
	{
		public static IEnumerable<int> GetFrequency(
			this IEnumerable<int[]> source)
		{
			int[][] queries = source.ToArray();
			var numbers = new Dictionary<int, int>(queries.Length);
			var list = new List<int>(queries.Length);
			var counts = new Dictionary<int, int>(queries.Length);

			foreach (int[] query in queries)
			{
				int operation = query[0];
				int number = query[1];

				if (operation == 1)
				{
					if (numbers.ContainsKey(number))
					{
						counts[numbers[number]]--;

						if (counts[numbers[number]] <= 0)
						{
							counts.Remove(numbers[number]);
						}

						numbers[number]++;

						if (counts.ContainsKey(numbers[number]))
						{
							counts[numbers[number]]++;
						}
						else
						{
							counts.Add(numbers[number], 1);
						}
					}
					else
					{
						numbers.Add(number, 1);

						if (counts.ContainsKey(1))
						{
							counts[1]++;
						}
						else
						{
							counts.Add(1, 1);
						}
					}
				}
				else if (operation == 2)
				{
					if (numbers.ContainsKey(number))
					{
						counts[numbers[number]]--;

						if (counts[numbers[number]] <= 0)
						{
							counts.Remove(numbers[number]);
						}

						numbers[number]--;

						int tmp = numbers[number];

						if (numbers[number] <= 0)
						{
							numbers.Remove(number);
						}

						if (tmp > 0)
						{
							if (counts.ContainsKey(tmp))
							{
								counts[tmp]++;
							}
							else
							{
								counts.Add(tmp, 1);
							}
						}
					}
				}
				else
				{
					list.Add(counts.ContainsKey(number) ? 1 : 0);
				}
			}

			return list;
		}
	}
}
