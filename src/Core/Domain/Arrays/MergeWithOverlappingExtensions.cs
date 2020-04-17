using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Domain.Arrays
{
	public static class MergeWithOverlappingExtensions
	{
		public static (T, T)[] MergeWithOverlapping<T>(
			this ILearningCollection<(T, T)> source)
			where T : IComparable<T>
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			(T, T)[] a = source.ToArray();

			if (a.Length == 0)
			{
				return Array.Empty<(T, T)>();
			}

			var res = new List<(T, T)> { a[0] };

			for (int i = 1; i < a.Length; i++)
			{
				(T, T) interval = res.Last();
				T x1 = interval.Item1;
				T y1 = interval.Item2;
				T x2 = a[i].Item1;
				T y2 = a[i].Item2;

				if ((x2.CompareTo(y1) > 0 && y2.CompareTo(y1) > 0) || (x2.CompareTo(x1) < 0 && y2.CompareTo(x1) < 0))
				{
					// not part of the current interval
					res.Add(a[i]);
				}
				else
				{
					res.RemoveAt(res.Count - 1);

					T min = x1.CompareTo(x2) <= 0 ? x1 : x2;
					T max = y1.CompareTo(y2) >= 0 ? y1 : y2;

					res.Add((min, max));
				}
			}

			return res.ToArray();
		}
	}
}
