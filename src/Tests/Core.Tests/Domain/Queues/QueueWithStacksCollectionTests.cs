using Core.Domain.Queues;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Queues
{
	[TestClass]
	public class QueueWithStacksCollectionTests
	{
		[TestClass]
		public class TheEnqueueWriteOptimizedMethod
		{
			[TestMethod]
			public void It_should_queue_an_item_to_the_queue_using_stacks_with_writes_optimized()
			{
				int[] source;
				var sut = new QueueWithStacksCollection<int>();
				int res;

				source = new[] { 1, 2, 3, 4, 5 };

				foreach (int item in source)
				{
					sut.EnqueueWriteOptimized(item);
				}

				foreach (int item in source)
				{
					res = sut.DequeueWriteOptimized();
					res.Should().Be(item);
				}
			}
		}

		[TestClass]
		public class TheEnqueueReadOptimizedMethod
		{
			[TestMethod]
			public void It_should_queue_an_item_to_the_queue_using_stacks_with_reads_optimized()
			{
				int[] source;
				var sut = new QueueWithStacksCollection<int>();
				int res;

				source = new[] { 1, 2, 3, 4, 5 };

				foreach (int item in source)
				{
					sut.EnqueueReadOptimized(item);
				}

				foreach (int item in source)
				{
					res = sut.DequeueReadOptimized();
					res.Should().Be(item);
				}
			}
		}
	}
}
