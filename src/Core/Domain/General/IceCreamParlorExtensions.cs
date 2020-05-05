using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Domain.General
{
	public static class IceCreamParlorExtensions
	{
		public static (int First, int Second) GetIceCreamChoices(
			this IEnumerable<int> costs,
			int money)
		{
			if (costs == null)
			{
				throw new ArgumentNullException(nameof(costs));
			}

			var hash = new Dictionary<int, int>();

			for (int i = 0; costs.Skip(i).Any(); i++)
			{
				int cost = costs.ElementAt(i);

				if (hash.ContainsKey(cost))
				{
					return (hash[cost], i + 1);
				}

				if (!hash.ContainsKey(money - cost))
				{
					hash.Add(money - cost, i + 1);
				}
			}

			return (-1, -1);
		}
	}
}
