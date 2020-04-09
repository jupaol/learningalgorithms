using System;

namespace Core.Domain.Arrays
{
	public interface IArrayMax
	{
		T Maximum<T>(T[] source)
			where T : IComparable<T>;
	}
}
