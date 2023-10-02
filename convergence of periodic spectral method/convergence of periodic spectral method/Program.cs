using System;
using System.IO;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

class Program
{
    static void Main(string[] args)
    {
        int index = 0;
        double[] errorVec = new double[50];

        string outputDirectory = @"D:\program\convergence of periodic spectral method\convergence of periodic spectral method";
        string outputFile = Path.Combine(outputDirectory, "convergence_data.txt");

        using (StreamWriter file = new StreamWriter(outputFile))
        {
            for (int N = 2; N <= 100; N += 2)
            {
                double h = 2 * Math.PI / N;
                double[] x = new double[N];
                double[] u = new double[N];
                double[] uprime = new double[N];

                for (int i = 0; i < N; i++)
                {
                    x[i] = -Math.PI + (i + 1) * h;
                    u[i] = Math.Exp(Math.Sin(x[i]));
                    uprime[i] = Math.Cos(x[i]) * u[i];
                }

                // Construct spectral differentiation matrix:
                double[] column = new double[N];
                column[0] = 0;
                for (int i = 1; i < N; i++)
                {
                    column[i] = 0.5 * Math.Pow(-1, i) * Math.Cos((i * h) / 2) / Math.Sin((i * h) / 2);
                }

                var D = SparseMatrix.Build.Sparse(N, N);
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        int k = i - j;
                        if (k < 0)
                            k += N;

                        D[i, j] = column[k];
                    }
                }

                // Compute the error
                Vector<double> uVector = Vector<double>.Build.Dense(u);
                Vector<double> uprimeVector = Vector<double>.Build.Dense(uprime);
                Vector<double> computedVector = D.Multiply(uVector);
                Vector<double> diff = computedVector - uprimeVector;
                double error = diff.InfinityNorm();
                errorVec[index] = error;
                file.WriteLine($"{N}\t{error}");

                Console.WriteLine($"N = {N}, Error = {error}");

                index++;
            }
        }
    }
}
