using System;
using System.IO;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
namespace Finite_difference_method
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] Nvec = { 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096 };
            double[] errorVec = new double[Nvec.Length];

            // Create a StreamWriter to write to the CSV file
            using (StreamWriter writer = new StreamWriter("D:\\program\\Finite difference method\\error_data.csv"))
            {
                writer.WriteLine("N,Error"); // Write the header

                for (int i = 0; i < Nvec.Length; i++)
                {
                    int N = Nvec[i];
                    double h = 2 * Math.PI / N;
                    double[] x = new double[N];
                    double[] u = new double[N];
                    double[] uprime = new double[N];

                    for (int j = 0; j < N; j++)
                    {
                        x[j] = -Math.PI + (j + 1) * h;
                        u[j] = Math.Exp(Math.Sin(x[j]));
                        uprime[j] = Math.Cos(x[j]) * u[j];
                    }

                    // Construct sparse 4th-order differentiation matrix:
                    var D = SparseMatrix.Build.Sparse(N, N);

                    for (int row = 0; row < N; row++)
                    {
                        int col = row;
                        D[row, (col - 2 + N) % N] = 1.0 / 12.0;
                        D[row, (col - 1 + N) % N] = -2.0 / 3.0;
                        D[row, (col + 1) % N] = 2.0 / 3.0;
                        D[row, (col + 2) % N] = -1.0 / 12.0;
                    }

                    D = D / h;

                    // Compute the error
                    Vector<double> uVector = Vector<double>.Build.Dense(u);
                    Vector<double> uprimeVector = Vector<double>.Build.Dense(uprime);
                    Vector<double> computedVector = D.Multiply(uVector);
                    Vector<double> diff = computedVector - uprimeVector;
                    double error = diff.InfinityNorm();
                    errorVec[i] = error;
                    Console.WriteLine($"N = {N}, Error = {error}");

                    // Write N and error to the CSV file
                    writer.WriteLine($"{N},{error}");
                }
            }
        }
    }
}
