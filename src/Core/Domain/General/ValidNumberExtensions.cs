using System;

namespace Core.Domain.General
{
	public static class ValidNumberExtensions
	{
		public static bool IsValidNumber(this string source)
		{
			if (string.IsNullOrWhiteSpace(source))
			{
				throw new ArgumentNullException(nameof(source));
			}

			return false;
		}
	}
}
