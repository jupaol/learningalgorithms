using System;

namespace Core.Domain.Arrays
{
	public interface IMoveItemsInArray
	{
		T[] MoveLeft<T>(T[] source, T key)
			where T : IComparable<T>;

		T[] MoveRight<T>(T[] source, T key)
			where T : IComparable<T>;
	}
}
