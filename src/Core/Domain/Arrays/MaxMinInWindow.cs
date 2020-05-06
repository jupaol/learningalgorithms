using System;
using System.Collections.Generic;

namespace Core.Domain.Arrays
{
	public class MaxMinInWindow
	{
		public T[] MaximumInWindow<T>(T[] source, int windowSize)
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

				for (int j = i; j < windowSize + i; j++)
				{
					// if it's first iteration for the "window" we don't take into consideration the
					// current value of the variable "max"
					if (!maxSet)
					{
						maxPerWindow = source[j];
						maxSet = true;

						continue;
					}

					if (source[j].CompareTo(maxPerWindow) > 0)
					{
						maxPerWindow = source[j];
					}
				}

				maximums.Add(maxPerWindow);
			}

			return maximums.ToArray();
		}

		public T[] MaximumInWindowUsingDequeue<T>(T[] source, int windowSize)
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
			var list = new LinkedList<int>();

			for (int i = 0; i < source.Length; i++)
			{
				if (list.Count > 0 && list.First.Value == i - windowSize)
				{
					list.RemoveFirst();
				}

				while (list.Count > 0 && source[list.Last.Value].CompareTo(source[i]) < 0)
				{
					list.RemoveLast();
				}

				list.AddLast(i);

				if (i >= windowSize - 1)
				{
					maximums.Add(source[list.First.Value]);
				}
			}

			return maximums.ToArray();
		}
	}
}
