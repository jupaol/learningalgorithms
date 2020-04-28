using System.Linq;
using Core.Domain.Queues;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Queues
{
	[TestClass]
	public class QueueWithCircularArraysCollectionTests
	{
		[TestMethod]
		public void It_should_perform_basic_operations_on_the_queue_implemented_with_circular_arrays()
		{
			int[] source;
			var sut = new QueueWithCircularArraysCollection<int>();

			sut.IsEmpty().Should().BeTrue();
			sut.IsFull().Should().BeFalse();
			source = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			source.ToList().ForEach(sut.Enqueue);
			sut.IsEmpty().Should().BeFalse();
			sut.IsFull().Should().BeTrue();

			foreach (int item in source.Take(source.Length - 1))
			{
				sut.Dequeue().Should().Be(item);
				sut.IsEmpty().Should().BeFalse();
				sut.IsFull().Should().BeFalse();
			}

			sut.Dequeue().Should().Be(source.Last());
			sut.IsEmpty().Should().BeTrue();
			sut.IsFull().Should().BeFalse();

			// ** again
			sut.IsEmpty().Should().BeTrue();
			sut.IsFull().Should().BeFalse();
			source = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			source.ToList().ForEach(sut.Enqueue);
			sut.IsEmpty().Should().BeFalse();
			sut.IsFull().Should().BeTrue();

			foreach (int item in source.Take(source.Length - 1))
			{
				sut.Dequeue().Should().Be(item);
				sut.IsEmpty().Should().BeFalse();
				sut.IsFull().Should().BeFalse();
			}

			sut.Dequeue().Should().Be(source.Last());
			sut.IsEmpty().Should().BeTrue();
			sut.IsFull().Should().BeFalse();
		}
	}
}
