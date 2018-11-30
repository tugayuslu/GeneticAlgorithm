namespace GeneticAlgorithm
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.takeATspFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.populationCount = new System.Windows.Forms.TextBox();
            this.mutationRatio = new System.Windows.Forms.TextBox();
            this.iterationCount = new System.Windows.Forms.TextBox();
            this.elitismRatio = new System.Windows.Forms.TextBox();
            this.runGeneticAlgorithm = new System.Windows.Forms.Button();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.hScrollBar2 = new System.Windows.Forms.HScrollBar();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.hScrollBar3 = new System.Windows.Forms.HScrollBar();
            this.crossoverRatio = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.writeTheOptimalSolutionFile = new System.Windows.Forms.Button();
            this.viewGraphic = new System.Windows.Forms.Button();
            this.viewMap = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // takeATspFile
            // 
            this.takeATspFile.Location = new System.Drawing.Point(13, 12);
            this.takeATspFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.takeATspFile.Name = "takeATspFile";
            this.takeATspFile.Size = new System.Drawing.Size(440, 537);
            this.takeATspFile.TabIndex = 0;
            this.takeATspFile.Text = "Take A Tsp File";
            this.takeATspFile.UseVisualStyleBackColor = true;
            this.takeATspFile.Click += new System.EventHandler(this.takeATspFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Population Count     :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mutation Ratio         :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "İteration Count         :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Elitism Ratio             :";
            // 
            // populationCount
            // 
            this.populationCount.Location = new System.Drawing.Point(349, 52);
            this.populationCount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.populationCount.Name = "populationCount";
            this.populationCount.Size = new System.Drawing.Size(100, 22);
            this.populationCount.TabIndex = 1;
            this.populationCount.Text = "50";
            this.populationCount.TextChanged += new System.EventHandler(this.populationCount_TextChanged);
            // 
            // mutationRatio
            // 
            this.mutationRatio.Location = new System.Drawing.Point(349, 144);
            this.mutationRatio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mutationRatio.Name = "mutationRatio";
            this.mutationRatio.Size = new System.Drawing.Size(100, 22);
            this.mutationRatio.TabIndex = 4;
            this.mutationRatio.Text = "0.07";
            this.mutationRatio.TextChanged += new System.EventHandler(this.mutationRatio_TextChanged);
            // 
            // iterationCount
            // 
            this.iterationCount.Location = new System.Drawing.Point(349, 82);
            this.iterationCount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.iterationCount.Name = "iterationCount";
            this.iterationCount.Size = new System.Drawing.Size(100, 22);
            this.iterationCount.TabIndex = 2;
            this.iterationCount.Text = "200";
            this.iterationCount.TextChanged += new System.EventHandler(this.iterationCount_TextChanged);
            // 
            // elitismRatio
            // 
            this.elitismRatio.Location = new System.Drawing.Point(349, 113);
            this.elitismRatio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.elitismRatio.Name = "elitismRatio";
            this.elitismRatio.Size = new System.Drawing.Size(100, 22);
            this.elitismRatio.TabIndex = 3;
            this.elitismRatio.Text = "0.07";
            this.elitismRatio.TextChanged += new System.EventHandler(this.elitistCount_TextChanged);
            // 
            // runGeneticAlgorithm
            // 
            this.runGeneticAlgorithm.Location = new System.Drawing.Point(13, 406);
            this.runGeneticAlgorithm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.runGeneticAlgorithm.Name = "runGeneticAlgorithm";
            this.runGeneticAlgorithm.Size = new System.Drawing.Size(440, 31);
            this.runGeneticAlgorithm.TabIndex = 9;
            this.runGeneticAlgorithm.Text = "Run Genetic Algorithm";
            this.runGeneticAlgorithm.UseVisualStyleBackColor = true;
            this.runGeneticAlgorithm.Click += new System.EventHandler(this.runGeneticAlgorithm_Click);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.LargeChange = 1;
            this.hScrollBar1.Location = new System.Drawing.Point(13, 234);
            this.hScrollBar1.Maximum = 1;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(440, 21);
            this.hScrollBar1.TabIndex = 6;
            this.hScrollBar1.TabStop = true;
            this.hScrollBar1.ValueChanged += new System.EventHandler(this.hScrollBar1_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Selection Method    :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(152, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(289, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "Fitness Ratio Base Roulette Wheel Selection";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(155, 277);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(151, 17);
            this.label7.TabIndex = 18;
            this.label7.Text = "Single Point Crossover";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 277);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(145, 17);
            this.label8.TabIndex = 17;
            this.label8.Text = "Crossover Operator  :";
            // 
            // hScrollBar2
            // 
            this.hScrollBar2.LargeChange = 1;
            this.hScrollBar2.Location = new System.Drawing.Point(13, 302);
            this.hScrollBar2.Maximum = 2;
            this.hScrollBar2.Name = "hScrollBar2";
            this.hScrollBar2.Size = new System.Drawing.Size(440, 21);
            this.hScrollBar2.TabIndex = 7;
            this.hScrollBar2.TabStop = true;
            this.hScrollBar2.ValueChanged += new System.EventHandler(this.hScrollBar2_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(159, 345);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 17);
            this.label9.TabIndex = 21;
            this.label9.Text = "Twors Mutation";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 345);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(139, 17);
            this.label10.TabIndex = 20;
            this.label10.Text = "Mutation Operator   :";
            // 
            // hScrollBar3
            // 
            this.hScrollBar3.LargeChange = 1;
            this.hScrollBar3.Location = new System.Drawing.Point(13, 369);
            this.hScrollBar3.Maximum = 1;
            this.hScrollBar3.Name = "hScrollBar3";
            this.hScrollBar3.Size = new System.Drawing.Size(440, 21);
            this.hScrollBar3.TabIndex = 8;
            this.hScrollBar3.TabStop = true;
            this.hScrollBar3.ValueChanged += new System.EventHandler(this.hScrollBar3_ValueChanged);
            // 
            // crossoverRatio
            // 
            this.crossoverRatio.Location = new System.Drawing.Point(349, 175);
            this.crossoverRatio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.crossoverRatio.Name = "crossoverRatio";
            this.crossoverRatio.Size = new System.Drawing.Size(100, 22);
            this.crossoverRatio.TabIndex = 5;
            this.crossoverRatio.Text = "0.95";
            this.crossoverRatio.TextChanged += new System.EventHandler(this.crossoverRatio_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 178);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(141, 17);
            this.label11.TabIndex = 22;
            this.label11.Text = "Crossover Ratio       :";
            // 
            // writeTheOptimalSolutionFile
            // 
            this.writeTheOptimalSolutionFile.Location = new System.Drawing.Point(13, 517);
            this.writeTheOptimalSolutionFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.writeTheOptimalSolutionFile.Name = "writeTheOptimalSolutionFile";
            this.writeTheOptimalSolutionFile.Size = new System.Drawing.Size(440, 31);
            this.writeTheOptimalSolutionFile.TabIndex = 12;
            this.writeTheOptimalSolutionFile.Text = "Write The Optimal Solution File";
            this.writeTheOptimalSolutionFile.UseVisualStyleBackColor = true;
            this.writeTheOptimalSolutionFile.Click += new System.EventHandler(this.writeTheOptimalSolutionFolder_Click);
            // 
            // viewGraphic
            // 
            this.viewGraphic.Location = new System.Drawing.Point(13, 443);
            this.viewGraphic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.viewGraphic.Name = "viewGraphic";
            this.viewGraphic.Size = new System.Drawing.Size(440, 31);
            this.viewGraphic.TabIndex = 10;
            this.viewGraphic.Text = "View Graphic";
            this.viewGraphic.UseVisualStyleBackColor = true;
            this.viewGraphic.Click += new System.EventHandler(this.viewGraphic_Click);
            // 
            // viewMap
            // 
            this.viewMap.Location = new System.Drawing.Point(13, 480);
            this.viewMap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.viewMap.Name = "viewMap";
            this.viewMap.Size = new System.Drawing.Size(440, 31);
            this.viewMap.TabIndex = 11;
            this.viewMap.Text = "View Map";
            this.viewMap.UseVisualStyleBackColor = true;
            this.viewMap.Click += new System.EventHandler(this.viewMap_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 557);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(465, 25);
            this.statusStrip1.TabIndex = 23;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Margin = new System.Windows.Forms.Padding(17, 3, 1, 3);
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(350, 19);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(3, 3, 0, 2);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(63, 20);
            this.toolStripStatusLabel1.Text = "00:00.00";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 582);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.viewMap);
            this.Controls.Add(this.viewGraphic);
            this.Controls.Add(this.writeTheOptimalSolutionFile);
            this.Controls.Add(this.crossoverRatio);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.hScrollBar3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.hScrollBar2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.runGeneticAlgorithm);
            this.Controls.Add(this.elitismRatio);
            this.Controls.Add(this.iterationCount);
            this.Controls.Add(this.mutationRatio);
            this.Controls.Add(this.populationCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.takeATspFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TSP with Genetic Algorithm";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button takeATspFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox populationCount;
        private System.Windows.Forms.TextBox mutationRatio;
        private System.Windows.Forms.TextBox iterationCount;
        private System.Windows.Forms.TextBox elitismRatio;
        private System.Windows.Forms.Button runGeneticAlgorithm;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.HScrollBar hScrollBar2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.HScrollBar hScrollBar3;
        private System.Windows.Forms.TextBox crossoverRatio;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button writeTheOptimalSolutionFile;
        private System.Windows.Forms.Button viewGraphic;
        private System.Windows.Forms.Button viewMap;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}

