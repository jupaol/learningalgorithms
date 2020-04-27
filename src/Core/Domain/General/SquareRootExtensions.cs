using System;

namespace Core.Domain.General
{
	public static class SquareRootExtensions
	{
		public static double CalculateSquareRootUsingBinarySearch(this double n)
		{
			if (n.Equals(0))
			{
				return 0;
			}

			double min = 0D;
			double max = 1 + (n / 2);
			const double epsilon = 0.000000000000001;

			while (min < max)
			{
				double mid = (min + max) / 2;
				double square = mid * mid;
				double dif = Math.Abs(n - square);

				if (dif <= epsilon)
				{
					return mid;
				}

				if (square > n)
				{
					max = mid;
				}

				if (square < n)
				{
					min = mid;
				}
			}

			throw new Exception("Can't calculate the square root");
		}
	}
}
