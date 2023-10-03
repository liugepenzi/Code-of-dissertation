using ILNumerics;
using ILNumerics.Drawing;
using ILNumerics.Drawing.Plotting;
using System;
using System.Windows.Forms;

namespace Program5
{
    public partial class Form1 : Form
    {
        ILNumerics.Drawing.Panel panel;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Submit_Click(object sender, EventArgs e)
        {
            var parameters = GetSimulationParameters();
            if (parameters != null)
            {
                SimulationHelper simulationHelper = new SimulationHelper();
                double[,] data = simulationHelper.GetPlotData(parameters);
                Array<float> A = data;
                Controls.Remove(panel);
                panel = new ILNumerics.Drawing.Panel();
                panel.Dock = DockStyle.Right;
                panel.Width = 450; // Adjust the width as desired           
                Controls.Add(panel);
                panel.Scene.Add(
                    new PlotCube(twoDMode: false)
                    {
                    new Surface(A, colormap: Colormaps.Hot)
                    {
                        new Colorbar()
                    }
                    });
            }
        }


        private SimulationParameters GetSimulationParameters()
        {
            var parameters = new SimulationParameters();

            if (int.TryParse(N_textBox.Text, out int N))
            {
                parameters.N = N;
            }
            else
            {
                MessageBox.Show("Invalid value for N!");
                return null;
            }
            if (int.TryParse(PloteScale_textBox.Text, out int PlotScale))
            {
                parameters.PlotScale = PlotScale;
            }
            else
            {
                MessageBox.Show("Invalid value for PlotScale!");
                return null;
            }
            if (double.TryParse(tmax_textBox.Text, out double tmax))
            {
                parameters.Tmax = tmax;
            }
            else
            {
                MessageBox.Show("Invalid value for tmax!");
                return null;
            }
            if (double.TryParse(TimeStep_textBox.Text, out double timeStep))
            {
                parameters.TimeStep = timeStep;
            }
            else
            {
                MessageBox.Show("Invalid value for timeStep!");
                return null;
            }
            parameters.CoffA = coffA_textBox.Text;
            parameters.CoffB = coffB_textBox.Text;
            parameters.URead = uRead_textBox.Text;

            return parameters;
        }

        private void N_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void tmax_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void tplot_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void coffA_TextChanged(object sender, EventArgs e)
        {

        }

        private void coffB_TextChanged(object sender, EventArgs e)
        {

        }

        private void uRead_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }

}
