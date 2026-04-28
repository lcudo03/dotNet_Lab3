using System;
using System.Diagnostics;

namespace MatrixLab
{
    public static class MatrixBenchmark
    {
        public static void Run()
        {
            int[] sizes = { 100, 150, 200, 300 };
            int[] threads = { 1, 2, 4, 8, 16, 32 };
            int repetitions = 5;

            Console.WriteLine("Rozmiar | Wątki | Parallel avg [ms] | Thread avg [ms] | SpeedUp Parallel | SpeedUp Thread | Poprawny");
            Console.WriteLine("------------------------------------------------------------------------------------------------------");

            foreach (int size in sizes)
            {
                Matrix a = Matrix.Random(size, size);
                Matrix b = Matrix.Random(size, size);

                double parallelOneThread = AverageParallelTime(a, b, 1, repetitions);
                double threadOneThread = AverageThreadTime(a, b, 1, repetitions);

                foreach (int threadCount in threads)
                {
                    double parallelTime = AverageParallelTime(a, b, threadCount, repetitions);
                    double threadTime = AverageThreadTime(a, b, threadCount, repetitions);

                    double parallelSpeedUp = parallelOneThread / parallelTime;
                    double threadSpeedUp = threadOneThread / threadTime;

                    Matrix parallelResult = MatrixMultiplier.MultiplyParallel(a, b, threadCount);
                    Matrix threadResult = MatrixMultiplier.MultiplyThread(a, b, threadCount);

                    bool correct = AreEqual(parallelResult, threadResult);

                    Console.WriteLine(
                        $"{size,7} | {threadCount,5} | {parallelTime,17:F2} | {threadTime,15:F2} | {parallelSpeedUp,16:F2} | {threadSpeedUp,13:F2} | {correct}"
                    );
                }

                Console.WriteLine();
            }
        }

        private static double AverageParallelTime(Matrix a, Matrix b, int threads, int repetitions)
        {
            double total = 0;

            for (int i = 0; i < repetitions; i++)
            {
                Stopwatch sw = Stopwatch.StartNew();
                MatrixMultiplier.MultiplyParallel(a, b, threads);
                sw.Stop();

                total += sw.ElapsedMilliseconds;
            }

            return total / repetitions;
        }

        private static double AverageThreadTime(Matrix a, Matrix b, int threads, int repetitions)
        {
            double total = 0;

            for (int i = 0; i < repetitions; i++)
            {
                Stopwatch sw = Stopwatch.StartNew();
                MatrixMultiplier.MultiplyThread(a, b, threads);
                sw.Stop();

                total += sw.ElapsedMilliseconds;
            }

            return total / repetitions;
        }

        private static bool AreEqual(Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows || a.Columns != b.Columns)
                return false;

            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Columns; j++)
                {
                    if (Math.Abs(a.Data[i, j] - b.Data[i, j]) > 0.00001)
                        return false;
                }
            }

            return true;
        }
    }
}