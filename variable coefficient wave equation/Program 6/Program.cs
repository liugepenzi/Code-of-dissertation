using MathNet.Numerics.IntegralTransforms;
using System.Numerics;

class WaveEquation
{
    static void Main()
    {
        int N = 128;
        double h = 2 * Math.PI / N;
        double[] x = new double[N];
        for (int i = 0; i < N; i++)
        {
            x[i] = h * (i + 1);
        }

        double t = 0;
        double dt = h / 4;
        double[] c = new double[N];
        double[] v = new double[N];
        double[] vold = new double[N];

        for (int i = 0; i < N; i++)
        {
            double xi = x[i];
            c[i] = 0.2 + Math.Sin(xi - 1) * Math.Sin(xi - 1);
            v[i] = Math.Exp(-100 * (xi - 1) * (xi - 1));
            vold[i] = Math.Exp(-100 * (xi - 0.2 * dt - 1) * (xi - 0.2 * dt - 1));
        }

        double tmax = 8;
        double tplot = 0.15;
        int plotgap = (int)Math.Round(tplot / dt);
        dt = tplot / plotgap;
        int nplots = (int)Math.Round(tmax / tplot);
        double[,] data = new double[nplots + 1, N];
        for (int i = 0; i < N; i++) {
            data[0,i] = v[i];
        }
        double[] tdata = new double[nplots + 1];
        tdata[0] = t;
        for (int i = 0; i < nplots; i++)
        {
            for (int n = 0; n < plotgap; n++)
            {
                t += dt;
                Complex[] v_hat = FFT(v);
                Complex li = Complex.ImaginaryOne;
                Complex[] w_hat = new Complex[N];
                for (int k = 0; k < N; k++)
                {
                    int index = (k < N / 2) ? k : (k - N);
                    if (k == N / 2)
                    {
                        index = 0;
                    }
                    w_hat[k] = li * index * v_hat[k];
                }

                double[] w = IFFT(w_hat);
                double[] vnew = new double[N];
                for (int j = 0; j < N; j++)
                {
                    vnew[j] = vold[j] - 2 * dt * c[j] * w[j];
                    vold[j] = v[j];
                    v[j] = vnew[j];
                }
            }

            for (int j = 0; j < N; j++)
            {
                data[i+1, j] = v[j];
            }
            tdata[i+1] = t;
        }

        SaveDataToCSV(data);
    }

    static Complex[] FFT(double[] input)
    {
        Complex[] complexInput = new Complex[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            complexInput[i] = new Complex(input[i], 0);
        }
        Fourier.Forward(complexInput, FourierOptions.Matlab);
        return complexInput;
    }

    static double[] IFFT(Complex[] input)
    {
        Fourier.Inverse(input, FourierOptions.Matlab);
        double[] doubleOutput = new double[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            doubleOutput[i] = input[i].Real;
        }
        return doubleOutput;
    }

    static void SaveDataToCSV(double[,] data)
    {
        string filePath = "D:\\program\\Program 6\\Program 6\\wave_equation_data.csv";

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            // Write the data rows
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    writer.Write(data[i, j]);

                    if (j < data.GetLength(1) - 1)
                    {
                        writer.Write(", ");
                    }
                }
                writer.WriteLine();
            }
        }

        Console.WriteLine("Data saved to " + filePath);
    }

}
