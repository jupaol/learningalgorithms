using System;
using System.Collections.Generic;

namespace Core.Domain.Arrays
{
	public class ArrayMaxInWindow : IArrayMaxInWindow
	{
#pragma warning disable S1541 // Methods and properties should not be too complex
#pragma warning disable S3776 // Cognitive Complexity of methods should not be too high
		public T[] MaximumInWindow<T>(T[] source, int windowSize)
#pragma warning restore S3776 // Cognitive Complexity of methods should not be too high
#pragma warning restore S1541 // Methods and properties should not be too complex
			where T : IComparable<T>
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			if (windowSize <= 0 || windowSize > source.Length || source.Length == 0)
			{
				return Array.Empty<T>();
			}

			if (windowSize == 1)
			{
				return source;
			}

			var maximums = new List<T>();

			for (int i = 0; i <= source.Length - windowSize; i++)
			{
				T maxPerWindow = default;
				bool maxSet = false;

				for (int j = i; j < (windowSize + i) - 1; j++)
				{
					T currentMax = source[j].CompareTo(source[j + 1]) > 0 ? source[j] : source[j + 1];

					// if it's first iteration for the "window" we don't take into consideration the
					// current value of the variable "max"
					if (!maxSet)
					{
						maxPerWindow = currentMax;
						maxSet = true;

						continue;
					}

					if (currentMax.CompareTo(maxPerWindow) > 0)
					{
						maxPerWindow = currentMax;
					}
				}

				maximums.Add(maxPerWindow);
			}

			return maximums.ToArray();
		}
	}
}
