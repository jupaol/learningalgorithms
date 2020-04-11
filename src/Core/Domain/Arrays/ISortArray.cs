using System;

namespace Core.Domain.Arrays
{
	public interface ISortArray
	{
		T[] Sort<T>(T[] source)
			where T : IComparable<T>;
	}
}
