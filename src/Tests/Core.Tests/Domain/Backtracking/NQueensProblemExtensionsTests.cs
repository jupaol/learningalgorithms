using System.Collections.Generic;
using System.Linq;
using Core.Domain.Backtracking;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests.Domain.Backtracking
{
	[TestClass]
	public class NQueensProblemExtensionsTests
	{
		private static bool IsMatrixValid(bool[][] source)
		{
			for (int i = 0; i < source.Length; i++)
			{
				int count = 0;

				for (int j = 0; j < source[i].Length; j++)
				{
					if (source[i][j])
					{
						count++;
					}

					if (source[j][i])
					{
						count++;
					}
				}

				if (count != 2)
				{
					return false;
				}
			}

			return true;
		}

		[TestClass]
		public class TheFindAllNQueensSolutionsMethod
		{
			[TestMethod]
			public void It_should_return_all_solutions_for_the_n_queens_problem()
			{
				int matrixSize;
				IList<bool[][]> res;

				matrixSize = 4;
				res = matrixSize.FindAllNQueensSolutions().ToList();
				res.Should().NotBeNull();
				res.Count.Should().BePositive();
				res.Count.Should().Be(2);
				IsMatrixValid(res[0]).Should().BeTrue();
			}
		}
	}
}
