namespace RotatingWalkInMatrix
{
    public class MainProgram
    {
        private static void Main()
        {
            var matrix = MatrixGenerator.GenerateMatrix();
            MatrixGeneratorLogic.SetMatrixValues(matrix);
            MatrixGenerator.PrintMatrix(matrix);
        }
    }
}