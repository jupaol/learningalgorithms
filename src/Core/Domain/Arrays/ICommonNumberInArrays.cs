using System;

namespace Core.Domain.Arrays
{
	public interface ICommonNumberInArrays
	{
		T FindMinimum<T>(T[] source1, T[] source2, T[] source3, T defaultIfNotFound)
			where T : IComparable<T>;
	}
}
