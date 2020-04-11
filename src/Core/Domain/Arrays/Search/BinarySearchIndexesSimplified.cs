using System;

namespace Core.Domain.Arrays.Search
{
	public class BinarySearchIndexesSimplified
	{
#pragma warning disable S3900 // Arguments of public methods should be validated against null
		public int Search<T>(T[] source, T key, OccurrenceType occurrenceType)
			where T : IComparable<T>
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			int min = 0;
			int max = source.Length - 1;
			int result = -1;

			while (min <= max)
			{
				int mid = (min + max) / 2;
				int midComparisonResult = key.CompareTo(source[mid]);

				if (midComparisonResult == 0)
				{
					result = mid;

					if (occurrenceType == OccurrenceType.First)
					{
						max = mid - 1;
					}

					if (occurrenceType == OccurrenceType.Last)
					{
						min = mid + 1;
					}

					continue;
				}

				if (midComparisonResult < 0)
				{
					max = mid - 1;
				}
				else
				{
					min = mid + 1;
				}
			}

			return result;
		}
#pragma warning restore S3900 // Arguments of public methods should be validated against null
	}
}
