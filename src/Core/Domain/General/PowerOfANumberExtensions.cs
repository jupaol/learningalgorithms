namespace Core.Domain.General
{
	public static class PowerOfANumberExtensions
	{
		public static double GetPowerUsingIteration(this int n, int exponent)
		{
			if (exponent == 0)
			{
				return 1;
			}

			if (exponent == 1)
			{
				return n;
			}

			bool isNegative = exponent < 0;
			double tmp = 1;

			if (isNegative)
			{
				exponent *= -1;
			}

			for (int i = 0; i < exponent; i++)
			{
				tmp *= n;
			}

			if (isNegative)
			{
				tmp = 1D / tmp;
			}

			return tmp;
		}

		public static double GetPowerUsingRecursion(this int n, int exponent)
		{
			if (exponent == 0)
			{
				return 1;
			}

			if (exponent == 1)
			{
				return n;
			}

			bool isNegative = exponent < 0;

			if (isNegative)
			{
				exponent *= -1;
			}

			double tmp = GetPowerUsingRecursionRec(n, exponent);

			if (isNegative)
			{
				tmp = 1D / tmp;
			}

			return tmp;
		}

		private static double GetPowerUsingRecursionRec(in int n, in int exponent)
		{
			if (exponent == 0)
			{
				return 1;
			}

			if (exponent == 1)
			{
				return n;
			}

			double tmp = GetPowerUsingRecursionRec(n, exponent / 2);

			if (exponent % 2 == 0)
			{
				return tmp * tmp;
			}

			return exponent * tmp * tmp;
		}
	}
}
