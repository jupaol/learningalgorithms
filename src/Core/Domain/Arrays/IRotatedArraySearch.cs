using System;

namespace Core.Domain.Arrays
{
	public interface IRotatedArraySearch
	{
		int Search<T>(T[] source, T key, int rotatedPositions, RotationType rotationType)
			where T : IComparable<T>;
	}
}
