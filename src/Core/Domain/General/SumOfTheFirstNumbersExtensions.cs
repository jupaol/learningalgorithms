namespace Core.Domain.General
{
	public static class SumOfTheFirstNumbersExtensions
	{
		public static int GetSumOfTheFirstNaturalNumbers(
			this int target)
		{
			return (target * (target + 1)) / 2;
		}
	}
}
