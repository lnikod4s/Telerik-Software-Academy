namespace RotatingWalkInMatrix
{
    public class MatrixGeneratorLogic
    {
        private static readonly int[] MovementsByX = { 1, 1, 1, 0, -1, -1, -1, 0 };
        private static readonly int[] MovementsByY = { 1, 0, -1, -1, -1, 0, 1, 1 };
        private static int _directionIndex;
        private static int _nextAvailableValue;

        internal static void SetMatrixValues(int[,] matrix)
        {
            _directionIndex = 0;
            _nextAvailableValue = 0;
            FillMatrix(matrix);
        }

        private static void FillMatrix(int[,] matrix)
        {
            var nextAvailableRow = 0;
            var nextAvailableCol = 0;

            while (_nextAvailableValue < matrix.GetLength(0) * matrix.GetLength(1))
            {
                matrix[nextAvailableRow, nextAvailableCol] = ++_nextAvailableValue;

                if (NextDirectionIsAvailable(matrix, nextAvailableRow, nextAvailableCol))
                {
                    nextAvailableRow += MovementsByX[_directionIndex];
                    nextAvailableCol += MovementsByY[_directionIndex];
                }

                else
                {
                    FindFirstEmptyCell(matrix, out nextAvailableRow, out nextAvailableCol);
                }
            }
        }

        private static void FindFirstEmptyCell(int[,] matrix, out int availableRow, out int availableCol)
        {
            for (var row = 0; row < matrix.GetLength(0); row++)
            {
                for (var col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 0)
                    {
                        availableRow = row;
                        availableCol = col;
                        ChangeDirection();
                        return;
                    }
                }
            }

            availableRow = 0;
            availableCol = 0;
        }

        private static void ChangeDirection()
        {
            _directionIndex++;
            if (_directionIndex == MovementsByX.Length)
            {
                _directionIndex = 0;
            }
        }

        private static bool CanContinueInCurrentDirection(int[,] matrix, int row, int col)
        {
            var canContinueInCurrentDirection = row + MovementsByX[_directionIndex] < 0 ||
                                                row + MovementsByX[_directionIndex] >= matrix.GetLength(0)
                                                || col + MovementsByY[_directionIndex] < 0 ||
                                                col + MovementsByY[_directionIndex] >= matrix.GetLength(1)
                                                ||
                                                matrix[
                                                    row + MovementsByX[_directionIndex],
                                                    col + MovementsByY[_directionIndex]] != 0;

            return canContinueInCurrentDirection;
        }

        private static bool NextDirectionIsAvailable(int[,] matrix, int row, int col)
        {
            var changeDirectionCounter = 0;
            while (CanContinueInCurrentDirection(matrix, row, col))
            {
                ChangeDirection();
                changeDirectionCounter++;

                if (changeDirectionCounter == MovementsByX.Length)
                {
                    return false;
                }
            }

            return true;
        }
    }
}