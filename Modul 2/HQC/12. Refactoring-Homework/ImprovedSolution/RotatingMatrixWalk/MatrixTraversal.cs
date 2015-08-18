namespace RotatingMatrixWalk
{
    public class MatrixTraversal
    {
        private static readonly int[] DirX = { 1, 0, -1, -1, 0, 1, -1, 0 };
        private static readonly int[] DirY = { 1, -1, 0, 1, 1, 0, -1, 1 };

        internal static void FillMatrix(int[,] matrix, MatrixCell startupCell)
        {
            var currentCell = startupCell;
            var dirIndex = 0;

            while (IsCellPassable(matrix, currentCell))
            {
                matrix[currentCell.X, currentCell.Y] = currentCell.Value;

                while (!IsNextCellPassable(matrix, currentCell, dirIndex) &&
                       CanCellMoveSomewhere(matrix, currentCell, dirIndex))
                {
                    dirIndex = (dirIndex + 1) % DirX.Length;
                }

                currentCell.X += DirX[dirIndex];
                currentCell.Y += DirY[dirIndex];
                currentCell.Value++;
            }

            var nextStartupCell = FindFirstAvailableCell(matrix);
            if (nextStartupCell == null)
            {
                return;
            }

            nextStartupCell.Value = currentCell.Value;
            FillMatrix(matrix, nextStartupCell);
        }

        internal static MatrixCell FindFirstAvailableCell(int[,] matrix)
        {
            for (var row = 0; row < matrix.GetLength(0); row++)
            {
                for (var col = 0; col < matrix.GetLength(0); col++)
                {
                    if (matrix[row, col] == 0)
                    {
                        var firstEmptyCell = new MatrixCell(row, col);
                        return firstEmptyCell;
                    }
                }
            }

            return null;
        }

        private static bool IsCellPassable(int[,] matrix, MatrixCell currentCell)
        {
            var isCellPassable = currentCell.X >= 0 && currentCell.X < matrix.GetLongLength(0) &&
                                 currentCell.Y >= 0 && currentCell.Y < matrix.GetLongLength(1) &&
                                 matrix[currentCell.X, currentCell.Y] == 0;

            return isCellPassable;
        }

        private static bool IsNextCellPassable(int[,] matrix, MatrixCell currentCell, int dirIndex)
        {
            var nextCell = new MatrixCell
            {
                X = currentCell.X + DirX[dirIndex],
                Y = currentCell.Y + DirY[dirIndex]
            };

            return IsCellPassable(matrix, nextCell);
        }

        private static bool CanCellMoveSomewhere(int[,] matrix, MatrixCell currentCell, int dirIndex)
        {
            for (var i = 0; i < DirX.Length; i++)
            {
                dirIndex = (dirIndex + 1) % DirX.Length;

                if (IsNextCellPassable(matrix, currentCell, dirIndex))
                {
                    return true;
                }
            }

            return false;
        }
    }
}