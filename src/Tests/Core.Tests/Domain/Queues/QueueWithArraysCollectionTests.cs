using System.Linq;
using Core.Domain.Queues;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Queues
{
	[TestClass]
	public class QueueWithArraysCollectionTests
	{
		[TestMethod]
		public void It_should_perform_basic_operations_on_the_queue_implemented_with_arrays()
		{
			int[] source;
			var sut = new QueueWithArraysCollection<int>();

			sut.IsEmpty().Should().BeTrue();
			source = new[] { 3, 4, 55, 98, 8, 8, 3, 1, 8 };
			source.ToList().ForEach(sut.Enqueue);
			sut.IsEmpty().Should().BeFalse();
			sut.Peek().Should().Be(3);

			foreach (int item in source)
			{
				sut.Dequeue().Should().Be(item);
			}

			sut.IsEmpty().Should().BeTrue();
			source = new[] { 3, 4, 55, 98, 8, 8, 3, 1, 8 };
			source.ToList().ForEach(sut.Enqueue);
			sut.IsEmpty().Should().BeFalse();
			sut.Peek().Should().Be(3);

			foreach (int item in source)
			{
				sut.Dequeue().Should().Be(item);
			}

			sut.IsEmpty().Should().BeTrue();
		}
	}
}
