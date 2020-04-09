using System;

namespace Core.Domain.Arrays
{
	public interface IArrayMaxInWindow
	{
		T[] MaximumInWindow<T>(T[] source, int windowSize)
			where T : IComparable<T>;
	}
}
