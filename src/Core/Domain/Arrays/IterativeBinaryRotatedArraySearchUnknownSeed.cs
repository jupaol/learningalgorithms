using System;

namespace Core.Domain.Arrays
{
	public class IterativeBinaryRotatedArraySearchUnknownSeed : IArraySearch
	{
#pragma warning disable S3900 // Arguments of public methods should be validated against null
#pragma warning disable S3776 // Cognitive Complexity of methods should not be too high
#pragma warning disable S1541 // Methods and properties should not be too complex
		public int Search<T>(T[] source, T key)
			where T : IComparable<T>
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			if (source.Length == 0)
			{
				return -1;
			}

			int left = 0;
			int right = source.Length - 1;

			while (left <= right && left >= 0 && right < source.Length)
			{
				int mid = (left + right) / 2;
				int comparison = key.CompareTo(source[mid]);

				if (comparison == 0)
				{
					return mid;
				}

				if (key.CompareTo(source[left]) == 0)
				{
					return left;
				}

				if (key.CompareTo(source[right]) == 0)
				{
					return right;
				}

				bool isLeftSorted = source[left].CompareTo(source[mid]) <= 0;
				bool isRightSorted = source[mid].CompareTo(source[right]) <= 0;
				bool isKeyOnLeftSide =
					key.CompareTo(source[left]) >= 0 && key.CompareTo(source[mid]) <= 0;
				bool isKeyOnRightSide =
					key.CompareTo(source[mid]) >= 0 && key.CompareTo(source[right]) <= 0;

				if (isLeftSorted && isKeyOnLeftSide)
				{
					right = mid - 1;
				}
				else if (isRightSorted && isKeyOnRightSide)
				{
					left = mid + 1;
				}
				else if (!isRightSorted && isLeftSorted)
				{
					left = mid + 1;
				}
				else if (!isLeftSorted && isRightSorted)
				{
					right = mid - 1;
				}
				else
				{
					left++;
					right--;
				}
			}

			return -1;
		}
#pragma warning restore S3900 // Arguments of public methods should be validated against null
#pragma warning restore S1541 // Methods and properties should not be too complex
#pragma warning restore S3776 // Cognitive Complexity of methods should not be too high
	}
}
