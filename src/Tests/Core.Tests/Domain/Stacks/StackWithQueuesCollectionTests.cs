using System.Linq;
using Core.Domain.Stacks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Stacks
{
	[TestClass]
	public class StackWithQueuesCollectionTests
	{
		[TestClass]
		public class ThePushOptimizedReadsMethod
		{
			[TestMethod]
			public void It_should_push_an_item_to_the_stack_using_queues_optimized_for_reads()
			{
				int[] source;
				var sut = new StackWithQueuesCollection<int>();
				int res;

				source = new[] { 1, 2, 3, 4, 5 };

				foreach (int item in source)
				{
					sut.PushOptimizedReads(item);
				}

				foreach (int item in source.Reverse())
				{
					res = sut.PopOptimizedReads();
					res.Should().Be(item);
				}
			}
		}

		[TestClass]
		public class ThePushOptimizedWritesMethod
		{
			[TestMethod]
			public void It_should_push_an_item_to_the_stack_using_queues_optimized_for_writes()
			{
				int[] source;
				var sut = new StackWithQueuesCollection<int>();
				int res;

				source = new[] { 1, 2, 3, 4, 5 };

				foreach (int item in source)
				{
					sut.PushOptimizedWrites(item);
				}

				foreach (int item in source.Reverse())
				{
					res = sut.PopOptimizedWrites();
					res.Should().Be(item);
				}
			}
		}
	}
}
