using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GeneticAlgorithm
{
    public partial class ViewGraphic : Form
    {
        private string name;

        public ViewGraphic(string name, List<DataPoint> best, List<DataPoint> average)
        {
            this.name = name + "_graphic";
            InitializeComponent();
            this.Text += ": " + name;
            chart1.Series.Add("Result: " + best[best.Count - 1].YValues[0].ToString());
            double temp = best[0].YValues[0];
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = best.Count - 1;
            for (int i = 0; i < best.Count; i++)
            {
                chart1.Series[0].Points.Add(best[i]);
                chart1.Series[1].Points.Add(average[i]);
                if (best[i].YValues[0] != temp)
                {
                    temp = best[i].YValues[0];
                    chart1.Series[2].Points.Add(new DataPoint(i, temp));
                }
            }
        }

        public ViewGraphic(string name, List<int> bestTour, List<City> cities)
        {
            this.name = name + "_map";
            InitializeComponent();
            this.Text += ": " + name;
            chart1.Series.Clear();
            chart1.Series.Add("Map");
            chart1.Series[0].ChartType = SeriesChartType.FastLine;
            for (int i = 0; i < bestTour.Count; i++)
            {
                chart1.Series[0].Points.Add(new DataPoint(cities[bestTour[i]].x, cities[bestTour[i]].y));
            }
            chart1.Series[0].Points.Add(new DataPoint(cities[bestTour[0]].x, cities[bestTour[0]].y));
        }

        private void exportAsImage_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = name;
            sfd.Filter = "PNG |*.png";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                chart1.SaveImage(sfd.FileName, ChartImageFormat.Png);
        }
    }
}
