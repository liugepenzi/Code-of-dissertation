using System;
using System.IO;

namespace BandLimitedInterpolation
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputDirectory = @"D:\program\band-limited interpolation"; // Specify your desired output directory

            double h = 1;
            double xmax = 10;

            double[] x = GenerateGrid(-xmax, xmax, h);
            double[] xx = GenerateGrid(-xmax - h / 20, xmax + h / 20, h / 10);

            for (int plt = 1; plt <= 3; plt++)
            {
                double[] v;
                switch (plt)
                {
                    case 1:
                        v = DeltaFunction(x);
                        break;
                    case 2:
                        v = SquareWave(x);
                        break;
                    case 3:
                        v = HatFunction(x);
                        break;
                    default:
                        v = new double[0];
                        break;
                }

                double[] p = BandLimitedInterpolation(v, x, xx, h);

                // Save v values to a file
                string vFileName = Path.Combine(outputDirectory, $"v_values_{plt}.txt");
                SaveToTextFile(vFileName, x, v);


                // Save p values to a file
                string pFileName = Path.Combine(outputDirectory, $"p_values_{plt}.txt");
                SaveToTextFile(pFileName, xx, p);

            }
        }

        static double[] GenerateGrid(double start, double end, double step)
        {
            int size = (int)Math.Ceiling((end - start) / step) + 1;
            double[] grid = new double[size];
            for (int i = 0; i < size; i++)
            {
                grid[i] = start + i * step;
            }
            return grid;
        }

        static double[] DeltaFunction(double[] x)
        {
            double[] v = new double[x.Length];
            for (int i = 0; i < x.Length; i++)
            {
                v[i] = (x[i] == 0) ? 1 : 0;
            }
            return v;
        }

        static double[] SquareWave(double[] x)
        {
            double[] v = new double[x.Length];
            for (int i = 0; i < x.Length; i++)
            {
                v[i] = Math.Abs(x[i]) <= 3 ? 1 : 0;
            }
            return v;
        }

        static double[] HatFunction(double[] x)
        {
            double[] v = new double[x.Length];
            for (int i = 0; i < x.Length; i++)
            {
                v[i] = Math.Max(0, 1 - Math.Abs(x[i]) / 3);
            }
            return v;
        }

        static double[] BandLimitedInterpolation(double[] v, double[] x, double[] xx, double h)
        {
            double[] p = new double[xx.Length];
            for (int i = 0; i < x.Length; i++)
            {
                for (int j = 0; j < xx.Length; j++)
                {
                    double sinc = (xx[j] - x[i]) / h;
                    if (Math.Abs(sinc) < double.Epsilon)
                    {
                        p[j] += v[i] * h;
                    }
                    else
                    {
                        p[j] += v[i] * Math.Sin(Math.PI * sinc) / (Math.PI * sinc);
                    }
                }
            }
            return p;
        }

        static void SaveToTextFile(string fileName, double[] x, double[] values)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                for (int i = 0; i < x.Length; i++)
                {
                    writer.WriteLine($"{x[i]}\t{values[i]}");
                }
            }
        }
    }
}
