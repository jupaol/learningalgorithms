using System;
using Core.Domain.Arrays.Search;

namespace Core.Domain.Arrays
{
	public class CountItem
	{
		private readonly BinarySearchIndexesSimplified _binarySearchIndexesSimplified;

		public CountItem(BinarySearchIndexesSimplified binarySearchIndexesSimplified)
		{
			_binarySearchIndexesSimplified = binarySearchIndexesSimplified;
		}

#pragma warning disable S3900 // Arguments of public methods should be validated against null
		public int Count<T>(T[] source, T key)
			where T : IComparable<T>
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			if (source.Length == 0)
			{
				return 0;
			}

			int min = _binarySearchIndexesSimplified.Search(source, key, OccurrenceType.First);

			if (min == -1)
			{
				return 0;
			}

			int max = _binarySearchIndexesSimplified.Search(source, key, OccurrenceType.Last);

			return max - min + 1;
		}
#pragma warning restore S3900 // Arguments of public methods should be validated against null
	}
}
