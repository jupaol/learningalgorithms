﻿using System;
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
	}
}