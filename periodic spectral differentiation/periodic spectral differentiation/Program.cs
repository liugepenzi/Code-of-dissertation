using System;
using System.IO;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

class Program
{
    static void Main(string[] args)
    {
        int N = 24;
        double h = 2 * Math.PI / N;
        double[] x = new double[N];
        double[] vhat = new double[N];
        double[] vexpSinX = new double[N];
        double[] vprime = new double[N];

        string outputDirectory = @"D:\program\periodic spectral differentiation\periodic spectral differentiation";

        for (int i = 0; i < N; i++)
        {
            x[i] = h * (i + 1);
            vhat[i] = Math.Max(0, 1 - Math.Abs(x[i] - Math.PI) / 2);
            vexpSinX[i] = Math.Exp(Math.Sin(x[i]));
            vprime[i] = Math.Cos(x[i]) * vexpSinX[i];
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

        Vector<double> vhatVector = Vector<double>.Build.Dense(vhat);
        Vector<double> vexpSinXVector = Vector<double>.Build.Dense(vexpSinX);
        Vector<double> vprimeVector = Vector<double>.Build.Dense(vprime);
        Vector<double> computedvhatVector = D.Multiply(vhatVector);
        Vector<double> computedvexpSinXVector = D.Multiply(vexpSinXVector);

        // Output data to files
        string vhatFile = Path.Combine(outputDirectory, "vhat.txt");
        string computedvhatFile = Path.Combine(outputDirectory, "computedvhat.txt");
        string vexpSinXFile = Path.Combine(outputDirectory, "vexpSinX.txt");
        string computedvexpSinXFile = Path.Combine(outputDirectory, "computedvexpSinX.txt");

        File.WriteAllLines(vhatFile, FormatData(x, vhat));
        File.WriteAllLines(computedvhatFile, FormatData(x, computedvhatVector.ToArray()));
        File.WriteAllLines(vexpSinXFile, FormatData(x, vexpSinX));
        File.WriteAllLines(computedvexpSinXFile, FormatData(x, computedvexpSinXVector.ToArray()));

        // Max error calculation
        Vector<double> diff = computedvexpSinXVector - vprimeVector;
        double error = diff.InfinityNorm();

        Console.WriteLine($"Max error = {error}");
    }

    static string[] FormatData(double[] x, double[] values)
    {
        string[] lines = new string[x.Length];
        for (int i = 0; i < x.Length; i++)
        {
            lines[i] = $"{x[i]}\t{values[i]}";
        }
        return lines;
    }
}
