namespace RotatingMatrixWalk
{
    internal class MatrixCell
    {
        public MatrixCell()
        {
        }

        public MatrixCell(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.Value = 1;
        }

        internal int X { get; set; }
        internal int Y { get; set; }
        internal int Value { get; set; }
    }
}