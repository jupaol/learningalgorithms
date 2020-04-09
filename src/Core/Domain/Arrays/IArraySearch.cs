using System;

namespace Core.Domain.Arrays
{
	public interface IArraySearch
	{
		int Search<T>(T[] source, T key)
			where T : IComparable<T>;
	}
}
