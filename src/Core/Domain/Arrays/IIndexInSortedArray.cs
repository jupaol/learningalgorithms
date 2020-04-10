using System;

namespace Core.Domain.Arrays
{
	public interface IIndexInSortedArray
	{
		int FindMinimumIndex<T>(T[] source, T key)
			where T : IComparable<T>;

		int FindMaximumIndex<T>(T[] source, T key)
			where T : IComparable<T>;
	}
}
