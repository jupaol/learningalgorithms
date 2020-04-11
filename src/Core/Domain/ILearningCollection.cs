using System.Collections.Generic;

namespace Core.Domain
{
	public interface ILearningCollection<out T> : IEnumerable<T>
	{
	}
}
