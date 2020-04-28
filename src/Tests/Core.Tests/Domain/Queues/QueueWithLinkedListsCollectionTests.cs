using System.Linq;
using Core.Domain.Queues;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Queues
{
	[TestClass]
	public class QueueWithLinkedListsCollectionTests
	{
		[TestMethod]
		public void It_should_perform_basic_operations_on_the_queue()
		{
			int[] source;
			var sut = new QueueWithLinkedListsCollection<int>();

			sut.IsEmpty().Should().BeTrue();
			source = new[] { 3, 4, 4, 8, 1, 0, 5, 2 };
			source.ToList().ForEach(sut.Enqueue);
			sut.IsEmpty().Should().BeFalse();

			sut.Peek().Should().Be(3);

			foreach (var item in source)
			{
				sut.Dequeue().Should().Be(item);
			}

			sut.IsEmpty().Should().BeTrue();
			source = new[] { 3, 4, 4, 8, 1, 0, 5, 2 };
			source.ToList().ForEach(sut.Enqueue);
			sut.IsEmpty().Should().BeFalse();

			sut.Peek().Should().Be(3);

			foreach (var item in source)
			{
				sut.Dequeue().Should().Be(item);
			}

			sut.IsEmpty().Should().BeTrue();
		}
	}
}
