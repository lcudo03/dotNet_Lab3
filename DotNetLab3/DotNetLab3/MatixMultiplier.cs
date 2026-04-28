using System;
using System.Threading;
using System.Threading.Tasks;

namespace MatrixLab
{
    public static class MatrixMultiplier
    {
        // Parallel
        public static Matrix MultiplyParallel(Matrix a, Matrix b, int threads)
        {
            Matrix result = new Matrix(a.Rows, b.Columns);

            ParallelOptions opt = new ParallelOptions()
            {
                MaxDegreeOfParallelism = threads
            };

            Parallel.For(0, a.Rows, opt, i =>
            {
                for (int j = 0; j < b.Columns; j++)
                {
                    double sum = 0;

                    for (int k = 0; k < a.Columns; k++)
                        sum += a.Data[i, k] * b.Data[k, j];

                    result.Data[i, j] = sum;
                }
            });

            return result;
        }

        // Thread
        public static Matrix MultiplyThread(Matrix a, Matrix b, int threads)
        {
            Matrix result = new Matrix(a.Rows, b.Columns);
            Thread[] t = new Thread[threads];

            int rowsPerThread = a.Rows / threads;
            int start = 0;

            for (int i = 0; i < threads; i++)
            {
                int s = start;
                int e = (i == threads - 1) ? a.Rows : s + rowsPerThread;

                t[i] = new Thread(() =>
                {
                    for (int r = s; r < e; r++)
                    {
                        for (int c = 0; c < b.Columns; c++)
                        {
                            double sum = 0;
                            for (int k = 0; k < a.Columns; k++)
                                sum += a.Data[r, k] * b.Data[k, c];

                            result.Data[r, c] = sum;
                        }
                    }
                });

                start = e;
            }

            foreach (var thread in t) thread.Start();
            foreach (var thread in t) thread.Join();

            return result;
        }
    }
}