using System;
using System.Linq;

namespace Core.Domain.Arrays
{
	public static class MaxStockProfitExtensions
	{
		public static (int, int)? GetMaxProfit(
			this ILearningCollection<int> source)
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			int[] a = source.ToArray();

			if (a.Length < 2)
			{
				return null;
			}

			int buy = a[0];
			int sell = a[1];
			int profit = sell - buy;

			for (int i = 1; i < a.Length; i++)
			{
				int currentProfit = a[i] - buy;

				if (currentProfit > profit)
				{
					sell = a[i];
					profit = currentProfit;
				}

				if (a[i] < buy)
				{
					buy = a[i];
				}
			}

			return (sell - profit, sell);
		}
	}
}
