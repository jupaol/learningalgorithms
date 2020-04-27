using System.Collections.Generic;
using System.Linq;

namespace Core.Domain.Backtracking
{
	public static class NQueensProblemExtensions
	{
		public static IEnumerable<bool[][]> FindAllNQueensSolutions(this int matrixSize)
		{
			if (matrixSize <= 1)
			{
				return Enumerable.Empty<bool[][]>();
			}

			var res = new List<bool[][]>();
			bool[][] currentSolution = new bool[matrixSize][];

			for (int i = 0; i < matrixSize; i++)
			{
				currentSolution[i] = new bool[matrixSize];
			}

			FindAllNQueensSolutionsRec(res, currentSolution, 0);

			return res;
		}

		private static void FindAllNQueensSolutionsRec(
			ICollection<bool[][]> res, bool[][] currentSolution, int row)
		{
			if (row >= currentSolution.Length)
			{
				res.Add(currentSolution.Select(x => x.ToArray()).ToArray());

				return;
			}

			for (int col = 0; col < currentSolution[row].Length; col++)
			{
				if (IsValidCell(currentSolution, row, col))
				{
					currentSolution[row][col] = true;

					FindAllNQueensSolutionsRec(res, currentSolution, row + 1);

					currentSolution[row][col] = false;
				}
			}
		}

		private static bool IsValidCell(bool[][] currentSolution, in int row, in int col)
		{
			for (int i = 0; i < currentSolution.Length; i++)
			{
				if (currentSolution[row][i])
				{
					return false;
				}

				if (currentSolution[i][col])
				{
					return false;
				}
			}

			int tmpRow = row;
			int tmpCol = col;

			// Goes </
			while (tmpRow < currentSolution.Length && tmpCol >= 0)
			{
				if (currentSolution[tmpRow][tmpCol])
				{
					return false;
				}

				tmpCol--;
				tmpRow++;
			}

			tmpRow = row;
			tmpCol = col;

			// Goes ^\
			while (tmpRow >= 0 && tmpCol >= 0)
			{
				if (currentSolution[tmpRow][tmpCol])
				{
					return false;
				}

				tmpCol--;
				tmpRow--;
			}

			tmpRow = row;
			tmpCol = col;

			// Goes \>
			while (tmpRow < currentSolution.Length && tmpCol < currentSolution.Length)
			{
				if (currentSolution[tmpRow][tmpCol])
				{
					return false;
				}

				tmpCol++;
				tmpRow++;
			}

			tmpRow = row;
			tmpCol = col;

			// Goes /^
			while (tmpRow >= 0 && tmpCol < currentSolution.Length)
			{
				if (currentSolution[tmpRow][tmpCol])
				{
					return false;
				}

				tmpCol++;
				tmpRow--;
			}

			return true;
		}
	}
}
