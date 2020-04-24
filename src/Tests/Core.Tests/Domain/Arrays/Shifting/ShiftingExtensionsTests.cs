using Core.Domain.Arrays.Shifting;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Arrays.Shifting
{
	[TestClass]
	public class ShiftingExtensionsTests
	{
		[TestClass]
		public class TheShiftLeftInSortedArrayMethod
		{
			[TestMethod]
			public void It_should_shift_array_left()
			{
				int[] source;

				source = new[] { 0, 2, 4, 15, 8, 10 };
				source.ShiftLeftInSortedArray(3);
				source.Should().ContainInOrder(0, 2, 4, 8, 10, 15);
			}
		}

		[TestClass]
		public class TheShiftRightInSortedArrayMethod
		{
			[TestMethod]
			public void It_should_shift_array_right()
			{
				int[] source;

				source = new[] { 0, 2, 4, 0, 8, 10 };
				source.ShiftRightInSortedArray(3);
				source.Should().ContainInOrder(0, 0, 2, 4, 8, 10);
			}
		}
	}
}
