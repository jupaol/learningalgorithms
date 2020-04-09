namespace Core.Domain.Arrays
{
	public interface IRotateArray
	{
		T[] Rotate<T>(T[] source, int positions, RotationType rotationType);
	}
}
