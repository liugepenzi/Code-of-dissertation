
using MathNet.Numerics.IntegralTransforms;
using System;
using System.Windows.Forms;
using System.Numerics;
using org.matheval;
using MathNet.Numerics.LinearAlgebra;
using System.IO;

namespace Program5
{
    public class SimulationHelper
    {

        public double[,] GetPlotData(SimulationParameters parameters)
        {
            int N = parameters.N;
            double tmax = parameters.Tmax;
            double timeStep = parameters.TimeStep;
            int plotScale = parameters.PlotScale;
            string coffA = parameters.CoffA;
            string coffB = parameters.CoffB;
            string uRead = parameters.URead;
                    
            double L = 2 * 40;
            double dx = L / N;
            double[] x = CalculateX(L, dx);
            double[] kappa = CalculateKappa(L, N);
            
            double[] u = new double[N];
            double[] A = new double[N];
            double[] B = new double[N];
            double[,] data =new double[40001,N];

            // Mathematical parse
            for (int i = 0; i < N; i++)
            {
                double xi = x[i];

                Expression coffAExpression = new Expression(coffA);
                Expression coffBExpression = new Expression(coffB);
                Expression uReadExpression = new Expression(uRead);
                try
                {
                    uReadExpression.Bind("x", xi);
                    double uValue = uReadExpression.Eval<double>();
                    u[i] = uValue;

                    coffAExpression.Bind("x", xi).Bind("u", 1);
                    double coffAValue = coffAExpression.Eval<double>();
                    A[i] = coffAValue;

                    coffBExpression.Bind("x", xi).Bind("u", uValue);
                    double coffBValue = coffBExpression.Eval<double>();
                    B[i] = coffBValue;
                }
                catch (Exception ex)
                {
                    // Show a pop-up window with the message "illegal syntax"
                    MessageBox.Show("Illegal syntax: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                    
                    return new double[0,0];
                }
                
            }
            // Define the differential function
            Func<double, MathNet.Numerics.LinearAlgebra.Vector<double>, MathNet.Numerics.LinearAlgebra.Vector<double>> f = (time, u0) =>
            {
                double[] uold = u0.AsArray();
                Complex[] uhat = FFT(uold);

                Complex li = Complex.ImaginaryOne;
                Complex[] duhat = new Complex[N];
                Complex[] dduhat = new Complex[N];
                Complex[] K = new Complex[N];

                // Calculate duhat, dduhat, and K using the provided code               
                for (int j = 0; j < N; j++)
                {
                    duhat[j] = li * kappa[j] * uhat[j];
                    dduhat[j] = -(kappa[j] * kappa[j]) * uhat[j];
                    K[j] = -li * (kappa[j] * kappa[j] * kappa[j]) * uhat[j];
                }

                double[] du = IFFT(duhat);
                double[] ddu = IFFT(dduhat);
                double[] k = IFFT(K); // third order differentiation

                double[] dudt = new double[N];
                for (int i = 0; i < N; i++)
                {
                    dudt[i] = -k[i] + A[i] * uold[i] * du[i] + B[i] * ddu[i];
                }
                MathNet.Numerics.LinearAlgebra.Vector<double> dudtRes = CreateVector.Dense(dudt);
                return dudtRes;
            };
            
            // Initial condition u(x,0)
            MathNet.Numerics.LinearAlgebra.Vector<double> uZero = CreateVector.Dense(u);
            // steps of time
            int tsteps = (int)(tmax / timeStep) + 1;
            MathNet.Numerics.LinearAlgebra.Vector<double>[] plotdata = FourthOrder(uZero, 0, tmax, tsteps, f);
            double[,] result = ConvertTo2DArray(plotdata);
            string csvFilePath = "D:\\program\\result.csv"; // Path of saving file
            SaveResultToCsv(result, csvFilePath);
            // Scaling plot
            double[,] plotResult = ScalePlot(result, plotScale);
            return plotResult;
        }
        // Scale drawing
        static double[,] ScalePlot(double[,] result, int stride)
        {
            int numRows = result.GetLength(0);

            int newRowCount = (numRows + stride - 1) / stride; // Calculate the number of rows in the new array
            double[,] sampledData = new double[newRowCount, result.GetLength(1)];

            for (int i = 0, j = 0; i < numRows; i += stride, j++)
            {
                if (i < numRows) // Check if the index is within the valid range
                {
                    for (int col = 0; col < result.GetLength(1); col++)
                    {
                        sampledData[j, col] = result[i, col];
                    }
                }
            }

            return sampledData;
        }
        // Convert vector[] to array[][]
        static double[,] ConvertTo2DArray(MathNet.Numerics.LinearAlgebra.Vector<double>[] vectorArray)
        {
            int rowCount = vectorArray.Length;
            int colCount = vectorArray[0].Count;

            double[,] result = new double[rowCount, colCount];

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    result[i, j] = vectorArray[i][j];
                }
            }

            return result;
        }
        //4th Order RungerKutta
        public static MathNet.Numerics.LinearAlgebra.Vector<double>[] FourthOrder(MathNet.Numerics.LinearAlgebra.Vector<double> y0, double start, double end, int N, Func<double, MathNet.Numerics.LinearAlgebra.Vector<double>, MathNet.Numerics.LinearAlgebra.Vector<double>> f)
        {
            double h = (end - start) / (double)(N - 1);
            MathNet.Numerics.LinearAlgebra.Vector<double>[] array = new MathNet.Numerics.LinearAlgebra.Vector<double>[N];
            double t = start;
            array[0] = y0;
            for (int i = 1; i < N; i++)
            {
                MathNet.Numerics.LinearAlgebra.Vector<double> k1 = f(t, y0);
                MathNet.Numerics.LinearAlgebra.Vector<double> k2 = f(t + h / 2.0, y0 + k1 * h / 2.0);
                MathNet.Numerics.LinearAlgebra.Vector<double> k3 = f(t + h / 2.0, y0 + k2 * h / 2.0);
                MathNet.Numerics.LinearAlgebra.Vector<double> k4 = f(t + h, y0 + k3 * h);
                MathNet.Numerics.LinearAlgebra.Vector<double> y = y0 + h / 6.0 * (k1 + 2.0 * k2 + 2.0 * k3 + k4);
                array[i] = y;
                t += h;
                y0 = y;
            }

            return array;
        }
        // Set grid
        static double[] CalculateX(double L, double dx)
        {
            int N = (int)Math.Floor(L / dx);
            double[] x = new double[N];

            double offset = -L / 2.0;

            for (int i = 0; i < N; i++)
            {
                x[i] = offset + i * dx;
            }

            return x;
        }
        // Calculate wavenumber k
        static double[] CalculateKappa(double L, int N)
        {
            double[] kappa = new double[N];
            double[] originalKappa = new double[N];

            double deltaKappa = (2 * Math.PI / L);
            double offset = -N / 2.0;

            for (int i = 0; i < N; i++)
            {
                originalKappa[i] = deltaKappa * (i + offset);
            }

            // Apply FFT shift
            int halfN = N / 2;
            Array.Copy(originalKappa, halfN, kappa, 0, halfN);
            Array.Copy(originalKappa, 0, kappa, halfN, halfN);

            return kappa;
        }

        static Complex[] FFT(double[] input)
        {
            // Create a copy of the input array
            double[] inputCopy = new double[input.Length];
            Array.Copy(input, inputCopy, input.Length);

            // Convert the input array to complex format
            Complex[] complexInput = new Complex[inputCopy.Length];
            for (int i = 0; i < inputCopy.Length; i++)
            {
                complexInput[i] = new Complex(inputCopy[i], 0);
            }

            // Perform the forward FFT on the copied complex array
            Fourier.Forward(complexInput, FourierOptions.Matlab);

            return complexInput;
        }

        static double[] IFFT(Complex[] input)
        {
            // Create a copy of the input array
            Complex[] inputCopy = new Complex[input.Length];
            Array.Copy(input, inputCopy, input.Length);

            // Perform the inverse FFT on the copied array
            Fourier.Inverse(inputCopy, FourierOptions.Matlab);

            // Convert the result to a double array
            double[] doubleOutput = new double[inputCopy.Length];
            for (int i = 0; i < inputCopy.Length; i++)
            {
                doubleOutput[i] = inputCopy[i].Real;
            }

            return doubleOutput;
        }
        //write the data in .csv file
        static void SaveResultToCsv(double[,] result, string filePath)
        {
            int numRows = result.GetLength(0);
            int numCols = result.GetLength(1);

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                for (int i = 0; i < numRows; i++)
                {
                    for (int j = 0; j < numCols; j++)
                    {
                        writer.Write(result[i, j]);

                        if (j < numCols - 1)
                        {
                            writer.Write(",");
                        }
                    }

                    writer.WriteLine();
                }
            }
        }

    }
}
