using System.Collections.Generic;

namespace Core.Domain.Trees
{
	public interface ILearningTreeCollection<out T> : IEnumerable<T>
	{
	}
}
