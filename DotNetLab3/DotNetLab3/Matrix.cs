using System;

namespace MatrixLab
{
    public class Matrix
    {
        public int Rows { get; }
        public int Columns { get; }
        public double[,] Data { get; }

        public Matrix(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Data = new double[rows, columns];
        }

        public static Matrix Random(int rows, int columns)
        {
            Matrix m = new Matrix(rows, columns);
            Random rand = new Random();

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                    m.Data[i, j] = rand.Next(1, 10);

            return m;
        }
    }
}