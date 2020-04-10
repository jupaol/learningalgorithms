using System;

namespace Core.Domain.Arrays
{
	public class CommonNumberInArrays : ICommonNumberInArrays
	{
		public T FindMinimum<T>(T[] source1, T[] source2, T[] source3, T defaultIfNotFound)
			where T : IComparable<T>
		{
			if (source1 == null || source2 == null || source3 == null)
			{
				return defaultIfNotFound;
			}

			int i = 0;
			int j = 0;
			int k = 0;

			while (i < source1.Length && j < source2.Length && k < source3.Length)
			{
				if (source1[i].Equals(source2[j]) && source1[i].Equals(source3[k]))
				{
					return source1[i];
				}

				if (source1[i].CompareTo(source2[j]) <= 0 && source1[i].CompareTo(source3[k]) <= 0)
				{
					i++;

					continue;
				}

				if (source2[j].CompareTo(source1[i]) <= 0 && source2[j].CompareTo(source3[k]) <= 0)
				{
					j++;

					continue;
				}

				if (source3[k].CompareTo(source1[i]) <= 0 && source3[k].CompareTo(source2[j]) <= 0)
				{
					k++;
				}
			}

			return defaultIfNotFound;
		}
	}
}
