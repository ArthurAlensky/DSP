namespace PictureProcessUI
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbSource = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbTransformed = new System.Windows.Forms.PictureBox();
            this.chHistogram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnProcess = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbThreshold = new System.Windows.Forms.TextBox();
            this.tbAdditions = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMultiplications = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDivirgations = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSource)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTransformed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chHistogram)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Controls.Add(this.pbSource);
            this.panel1.Location = new System.Drawing.Point(12, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(346, 304);
            this.panel1.TabIndex = 1;
            // 
            // pbSource
            // 
            this.pbSource.BackColor = System.Drawing.Color.White;
            this.pbSource.Image = ((System.Drawing.Image)(resources.GetObject("pbSource.Image")));
            this.pbSource.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbSource.InitialImage")));
            this.pbSource.Location = new System.Drawing.Point(3, 3);
            this.pbSource.Name = "pbSource";
            this.pbSource.Size = new System.Drawing.Size(340, 298);
            this.pbSource.TabIndex = 0;
            this.pbSource.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1154, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem1.Text = "Open";
            this.openToolStripMenuItem1.Click += new System.EventHandler(this.openToolStripMenuItem1_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Red;
            this.panel2.Controls.Add(this.pbTransformed);
            this.panel2.Location = new System.Drawing.Point(799, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(346, 304);
            this.panel2.TabIndex = 3;
            // 
            // pbTransformed
            // 
            this.pbTransformed.BackColor = System.Drawing.Color.White;
            this.pbTransformed.Image = ((System.Drawing.Image)(resources.GetObject("pbTransformed.Image")));
            this.pbTransformed.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbTransformed.InitialImage")));
            this.pbTransformed.Location = new System.Drawing.Point(3, 3);
            this.pbTransformed.Name = "pbTransformed";
            this.pbTransformed.Size = new System.Drawing.Size(340, 298);
            this.pbTransformed.TabIndex = 0;
            this.pbTransformed.TabStop = false;
            // 
            // chHistogram
            // 
            this.chHistogram.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chHistogram.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chHistogram.Legends.Add(legend1);
            this.chHistogram.Location = new System.Drawing.Point(364, 38);
            this.chHistogram.Name = "chHistogram";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "TransformedPicture";
            this.chHistogram.Series.Add(series1);
            this.chHistogram.Size = new System.Drawing.Size(429, 304);
            this.chHistogram.TabIndex = 4;
            this.chHistogram.Text = "Histogram";
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcess.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnProcess.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnProcess.Location = new System.Drawing.Point(12, 418);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(1130, 23);
            this.btnProcess.TabIndex = 5;
            this.btnProcess.Text = "Start Process";
            this.btnProcess.UseVisualStyleBackColor = false;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbThreshold);
            this.groupBox1.Location = new System.Drawing.Point(15, 345);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(237, 67);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // tbThreshold
            // 
            this.tbThreshold.Location = new System.Drawing.Point(131, 19);
            this.tbThreshold.Name = "tbThreshold";
            this.tbThreshold.Size = new System.Drawing.Size(100, 20);
            this.tbThreshold.TabIndex = 0;
            this.tbThreshold.Text = "0.9";
            // 
            // tbAdditions
            // 
            this.tbAdditions.Location = new System.Drawing.Point(123, 448);
            this.tbAdditions.Name = "tbAdditions";
            this.tbAdditions.ReadOnly = true;
            this.tbAdditions.Size = new System.Drawing.Size(100, 20);
            this.tbAdditions.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(67, 451);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Additions";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(49, 477);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Multiplications";
            // 
            // tbMultiplications
            // 
            this.tbMultiplications.Location = new System.Drawing.Point(123, 474);
            this.tbMultiplications.Name = "tbMultiplications";
            this.tbMultiplications.ReadOnly = true;
            this.tbMultiplications.Size = new System.Drawing.Size(100, 20);
            this.tbMultiplications.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(49, 505);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Divirgations";
            // 
            // tbDivirgations
            // 
            this.tbDivirgations.Location = new System.Drawing.Point(123, 502);
            this.tbDivirgations.Name = "tbDivirgations";
            this.tbDivirgations.ReadOnly = true;
            this.tbDivirgations.Size = new System.Drawing.Size(100, 20);
            this.tbDivirgations.TabIndex = 14;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(402, 78);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(1154, 555);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbDivirgations);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbMultiplications);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbAdditions);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.chHistogram);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSource)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbTransformed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chHistogram)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbSource;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pbTransformed;
        private System.Windows.Forms.DataVisualization.Charting.Chart chHistogram;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbAdditions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbMultiplications;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDivirgations;
        private System.Windows.Forms.TextBox tbThreshold;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

