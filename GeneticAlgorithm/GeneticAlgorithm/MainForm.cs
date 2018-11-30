using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GeneticAlgorithm
{
    public partial class MainForm : Form
    {
        Tsp tsp = new Tsp();
        public MainForm()
        {
            InitializeComponent();
            #region Visibility Checker
            List<Label> labels = this.Controls.OfType<Label>().ToList();
            List<TextBox> textBoxes = this.Controls.OfType<TextBox>().ToList();
            List<Button> buttons = this.Controls.OfType<Button>().ToList();
            List<HScrollBar> hScrollBars = this.Controls.OfType<HScrollBar>().ToList();
            foreach (var label in labels)
            {
                label.Visible = false;
            }
            foreach (var textBox in textBoxes)
            {
                textBox.Visible = false;
            }
            foreach (var button in buttons)
            {
                button.Visible = false;
            }
            foreach (var hScrollBar in hScrollBars)
            {
                hScrollBar.Visible = false;
            }
            takeATspFile.Visible = true;
            #endregion
        }
        #region hScrollBars
        private void hScrollBar2_ValueChanged(object sender, EventArgs e)
        {
            if (hScrollBar2.Value == 0) label7.Text = "Single Point Crossover";
            else if (hScrollBar2.Value == 1) label7.Text = "Double Point Crossover";
            else if (hScrollBar2.Value == 2) label7.Text = "Sequential Constructive Crossover";
        }

        private void hScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            if (hScrollBar1.Value == 0) label6.Text = "Fitness Ratio Base Roulette Wheel Selection";
            else if (hScrollBar1.Value == 1) label6.Text = "Fitness Rank Base Roulette Wheel Selection";
        }

        private void hScrollBar3_ValueChanged(object sender, EventArgs e)
        {
            if (hScrollBar3.Value == 0) label9.Text = "Twors Mutation";
            else if (hScrollBar3.Value == 1) label9.Text = "Reverse Sequence Mutation";
        }
        #endregion       
        #region Value Checker
        private void crossoverRatio_TextChanged(object sender, EventArgs e)
        {
            double sonuc;
            double.TryParse(crossoverRatio.Text, out sonuc);
            if (sonuc > 0 && sonuc <= 1) runGeneticAlgorithm.Visible = true;
            else runGeneticAlgorithm.Visible = false;
        }

        private void mutationRatio_TextChanged(object sender, EventArgs e)
        {
            double sonuc;
            if (double.TryParse(mutationRatio.Text, out sonuc))
            {
                if (sonuc >= 0 && sonuc <= 1) runGeneticAlgorithm.Visible = true;
                else runGeneticAlgorithm.Visible = false;
            }
            else runGeneticAlgorithm.Visible = false;
        }

        private void elitistCount_TextChanged(object sender, EventArgs e)
        {
            double sonuc;
            if (double.TryParse(elitismRatio.Text, out sonuc))
            {
                if (sonuc >= 0 && sonuc <= 1) runGeneticAlgorithm.Visible = true;
                else runGeneticAlgorithm.Visible = false;
            }
            else runGeneticAlgorithm.Visible = false;
        }

        private void iterationCount_TextChanged(object sender, EventArgs e)
        {
            int sonuc;
            if (int.TryParse(iterationCount.Text, out sonuc))
            {
                if (sonuc >= 0) runGeneticAlgorithm.Visible = true;
                else runGeneticAlgorithm.Visible = false;
            }
            else runGeneticAlgorithm.Visible = false;
        }

        private void populationCount_TextChanged(object sender, EventArgs e)
        {
            int sonuc;
            int.TryParse(populationCount.Text, out sonuc);
            if (sonuc >= 2) runGeneticAlgorithm.Visible = true;
            else runGeneticAlgorithm.Visible = false;
        }

        #endregion
        #region Buttons
        private void takeATspFile_Click(object sender, EventArgs e)
        {
            bool flag;
            tsp = new Tsp();
            flag = tsp.takeAFile();
            if (flag)
            {
                #region Visibility Checker
                List<Label> labels = this.Controls.OfType<Label>().ToList();
                List<TextBox> textBoxes = this.Controls.OfType<TextBox>().ToList();
                List<HScrollBar> hScrollBars = this.Controls.OfType<HScrollBar>().ToList();
                foreach (var label in labels)
                {
                    label.Visible = true;
                }
                foreach (var textBox in textBoxes)
                {
                    textBox.Visible = true;
                }
                foreach (var hScrollBar in hScrollBars)
                {
                    hScrollBar.Visible = true;
                }
                runGeneticAlgorithm.Visible = true;
                writeTheOptimalSolutionFile.Visible = false;
                viewGraphic.Visible = false;
                viewMap.Visible = false;
                #endregion
                takeATspFile.Size = new System.Drawing.Size(330, 25);
                MessageBox.Show("Veri Başarı İle Alındı..");

            }
            else
            {
                MessageBox.Show("Lütfen İşlenebilir Veri Örneği Seçiniz..");
                Application.Restart();
            }
        }

        private void runGeneticAlgorithm_Click(object sender, EventArgs e)
        {
            #region Enabled False
            List<TextBox> textBoxes = this.Controls.OfType<TextBox>().ToList();
            List<Button> buttons = this.Controls.OfType<Button>().ToList();
            List<HScrollBar> hScrollBars = this.Controls.OfType<HScrollBar>().ToList();
            foreach (var textBox in textBoxes)
            {
                textBox.Enabled = false;
            }
            foreach (var hScrollBar in hScrollBars)
            {
                hScrollBar.Enabled = false;
            }
            runGeneticAlgorithm.Enabled = false;
            writeTheOptimalSolutionFile.Enabled = false;
            takeATspFile.Enabled = false;
            #endregion
            string selectionMethod = label6.Text, crossoverOperator = label7.Text, mutationOperator = label9.Text; toolStripProgressBar1.Minimum = 0; toolStripProgressBar1.Maximum = Convert.ToInt32(iterationCount.Text); toolStripProgressBar1.Value = 0;
            tsp.Fillİnfo(Convert.ToInt32(populationCount.Text), Convert.ToDouble(mutationRatio.Text), Convert.ToDouble(crossoverRatio.Text), Convert.ToInt32(iterationCount.Text), Convert.ToDouble(elitismRatio.Text), selectionMethod, crossoverOperator, mutationOperator);
            viewGraphic.Visible = true;
            viewMap.Visible = true;
            tsp.Run(toolStripProgressBar1, toolStripStatusLabel1);
            #region Enabled True
            writeTheOptimalSolutionFile.Visible = true;
            runGeneticAlgorithm.Enabled = true;
            writeTheOptimalSolutionFile.Enabled = true;
            takeATspFile.Enabled = true;
            foreach (var textBox in textBoxes)
            {
                textBox.Enabled = true;
            }
            foreach (var hScrollBar in hScrollBars)
            {
                hScrollBar.Enabled = true;
            }
            #endregion
        }

        private void viewGraphic_Click(object sender, EventArgs e)
        {
            ViewGraphic viewGraphic = new ViewGraphic(tsp.variablesValue[0], tsp.bestList, tsp.averageList);
            viewGraphic.ShowDialog();

        }

        private void viewMap_Click(object sender, EventArgs e)
        {
            ViewGraphic viewGraphic = new ViewGraphic(tsp.variablesValue[0], tsp.bestTour, tsp.cities);
            viewGraphic.ShowDialog();
        }

        private void writeTheOptimalSolutionFolder_Click(object sender, EventArgs e)
        {
            tsp.writeFile();
        }
        #endregion
    }
}
