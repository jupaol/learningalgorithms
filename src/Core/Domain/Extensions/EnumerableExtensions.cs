using System;
using System.Collections.Generic;

namespace Core.Domain.Extensions
{
	public static class EnumerableExtensions
	{
		public static ILearningCollection<T> AsLearningCollection<T>(this IEnumerable<T> source)
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			return new LearningCollection<T>(source);
		}
	}
}
