using System;
using System.Collections;
using System.Collections.Generic;

namespace Core.Domain
{
	public class LearningCollection<T> : ILearningCollection<T>
	{
		private readonly IEnumerable<T> _source;

		public LearningCollection(IEnumerable<T> source)
		{
			_source = source ?? throw new ArgumentNullException(nameof(source));
		}

		public IEnumerator<T> GetEnumerator()
		{
			return _source.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
