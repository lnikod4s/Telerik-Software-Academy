namespace RotatingMatrixWalk
{
    public static class MatrixGenerator
    {
        public static int[,] Generate(int size)
        {
            var matrix = new int[size, size];

            var startupCell = MatrixTraversal.FindFirstAvailableCell(matrix);
            if (startupCell != null)
            {
                MatrixTraversal.FillMatrix(matrix, startupCell);
            }

            return matrix;
        }
    }
}