namespace MLImageProcessing
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox pictureBoxOriginal;
        private System.Windows.Forms.PictureBox pictureBoxProcessed;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.Button btnGrayscale;
        private System.Windows.Forms.Button btnEdgeDetection;
        private System.Windows.Forms.Button btnBlur;
        private System.Windows.Forms.Button btnSharpen;
        private System.Windows.Forms.Button btnBrightness;
        private System.Windows.Forms.Button btnContrast;
        private System.Windows.Forms.Button btnMLProcess;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblOriginal;
        private System.Windows.Forms.Label lblProcessed;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtMLResults;
        private System.Windows.Forms.Label lblMLResults;
        private System.Windows.Forms.NumericUpDown nudBlurRadius;
        private System.Windows.Forms.NumericUpDown nudBrightness;
        private System.Windows.Forms.NumericUpDown nudContrast;
        private System.Windows.Forms.Label lblBlurRadius;
        private System.Windows.Forms.Label lblBrightness;
        private System.Windows.Forms.Label lblContrast;
        private System.Windows.Forms.GroupBox groupBoxFilters;
        private System.Windows.Forms.GroupBox groupBoxAdjustments;
        private System.Windows.Forms.GroupBox groupBoxML;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pictureBoxOriginal = new System.Windows.Forms.PictureBox();
            this.pictureBoxProcessed = new System.Windows.Forms.PictureBox();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.btnGrayscale = new System.Windows.Forms.Button();
            this.btnEdgeDetection = new System.Windows.Forms.Button();
            this.btnBlur = new System.Windows.Forms.Button();
            this.btnSharpen = new System.Windows.Forms.Button();
            this.btnBrightness = new System.Windows.Forms.Button();
            this.btnContrast = new System.Windows.Forms.Button();
            this.btnMLProcess = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblOriginal = new System.Windows.Forms.Label();
            this.lblProcessed = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtMLResults = new System.Windows.Forms.TextBox();
            this.lblMLResults = new System.Windows.Forms.Label();
            this.nudBlurRadius = new System.Windows.Forms.NumericUpDown();
            this.nudBrightness = new System.Windows.Forms.NumericUpDown();
            this.nudContrast = new System.Windows.Forms.NumericUpDown();
            this.lblBlurRadius = new System.Windows.Forms.Label();
            this.lblBrightness = new System.Windows.Forms.Label();
            this.lblContrast = new System.Windows.Forms.Label();
            this.groupBoxFilters = new System.Windows.Forms.GroupBox();
            this.groupBoxAdjustments = new System.Windows.Forms.GroupBox();
            this.groupBoxML = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProcessed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlurRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudContrast)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxOriginal
            // 
            this.pictureBoxOriginal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxOriginal.Location = new System.Drawing.Point(12, 40);
            this.pictureBoxOriginal.Name = "pictureBoxOriginal";
            this.pictureBoxOriginal.Size = new System.Drawing.Size(400, 300);
            this.pictureBoxOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxOriginal.TabIndex = 0;
            this.pictureBoxOriginal.TabStop = false;
            // 
            // pictureBoxProcessed
            // 
            this.pictureBoxProcessed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxProcessed.Location = new System.Drawing.Point(430, 40);
            this.pictureBoxProcessed.Name = "pictureBoxProcessed";
            this.pictureBoxProcessed.Size = new System.Drawing.Size(400, 300);
            this.pictureBoxProcessed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxProcessed.TabIndex = 1;
            this.pictureBoxProcessed.TabStop = false;
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Location = new System.Drawing.Point(12, 12);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(120, 30);
            this.btnLoadImage.TabIndex = 2;
            this.btnLoadImage.Text = "Görüntü Yükle";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // btnGrayscale
            // 
            this.btnGrayscale.Location = new System.Drawing.Point(6, 22);
            this.btnGrayscale.Name = "btnGrayscale";
            this.btnGrayscale.Size = new System.Drawing.Size(100, 30);
            this.btnGrayscale.TabIndex = 3;
            this.btnGrayscale.Text = "Gri Tonlama";
            this.btnGrayscale.UseVisualStyleBackColor = true;
            this.btnGrayscale.Click += new System.EventHandler(this.btnGrayscale_Click);
            // 
            // btnEdgeDetection
            // 
            this.btnEdgeDetection.Location = new System.Drawing.Point(112, 22);
            this.btnEdgeDetection.Name = "btnEdgeDetection";
            this.btnEdgeDetection.Size = new System.Drawing.Size(100, 30);
            this.btnEdgeDetection.TabIndex = 4;
            this.btnEdgeDetection.Text = "Kenar Tespiti";
            this.btnEdgeDetection.UseVisualStyleBackColor = true;
            this.btnEdgeDetection.Click += new System.EventHandler(this.btnEdgeDetection_Click);
            // 
            // btnBlur
            // 
            this.btnBlur.Location = new System.Drawing.Point(218, 22);
            this.btnBlur.Name = "btnBlur";
            this.btnBlur.Size = new System.Drawing.Size(100, 30);
            this.btnBlur.TabIndex = 5;
            this.btnBlur.Text = "Blur";
            this.btnBlur.UseVisualStyleBackColor = true;
            this.btnBlur.Click += new System.EventHandler(this.btnBlur_Click);
            // 
            // btnSharpen
            // 
            this.btnSharpen.Location = new System.Drawing.Point(324, 22);
            this.btnSharpen.Name = "btnSharpen";
            this.btnSharpen.Size = new System.Drawing.Size(100, 30);
            this.btnSharpen.TabIndex = 6;
            this.btnSharpen.Text = "Keskinleştir";
            this.btnSharpen.UseVisualStyleBackColor = true;
            this.btnSharpen.Click += new System.EventHandler(this.btnSharpen_Click);
            // 
            // btnBrightness
            // 
            this.btnBrightness.Location = new System.Drawing.Point(6, 22);
            this.btnBrightness.Name = "btnBrightness";
            this.btnBrightness.Size = new System.Drawing.Size(100, 30);
            this.btnBrightness.TabIndex = 7;
            this.btnBrightness.Text = "Parlaklık";
            this.btnBrightness.UseVisualStyleBackColor = true;
            this.btnBrightness.Click += new System.EventHandler(this.btnBrightness_Click);
            // 
            // btnContrast
            // 
            this.btnContrast.Location = new System.Drawing.Point(112, 22);
            this.btnContrast.Name = "btnContrast";
            this.btnContrast.Size = new System.Drawing.Size(100, 30);
            this.btnContrast.TabIndex = 8;
            this.btnContrast.Text = "Kontrast";
            this.btnContrast.UseVisualStyleBackColor = true;
            this.btnContrast.Click += new System.EventHandler(this.btnContrast_Click);
            // 
            // btnMLProcess
            // 
            this.btnMLProcess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnMLProcess.ForeColor = System.Drawing.Color.White;
            this.btnMLProcess.Location = new System.Drawing.Point(6, 22);
            this.btnMLProcess.Name = "btnMLProcess";
            this.btnMLProcess.Size = new System.Drawing.Size(150, 40);
            this.btnMLProcess.TabIndex = 9;
            this.btnMLProcess.Text = "ML İşlemi Uygula";
            this.btnMLProcess.UseVisualStyleBackColor = false;
            this.btnMLProcess.Click += new System.EventHandler(this.btnMLProcess_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(138, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 30);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Kaydet";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(264, 12);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(120, 30);
            this.btnReset.TabIndex = 11;
            this.btnReset.Text = "Sıfırla";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblOriginal
            // 
            this.lblOriginal.AutoSize = true;
            this.lblOriginal.Location = new System.Drawing.Point(12, 343);
            this.lblOriginal.Name = "lblOriginal";
            this.lblOriginal.Size = new System.Drawing.Size(60, 15);
            this.lblOriginal.TabIndex = 12;
            this.lblOriginal.Text = "Orijinal:";
            // 
            // lblProcessed
            // 
            this.lblProcessed.AutoSize = true;
            this.lblProcessed.Location = new System.Drawing.Point(430, 343);
            this.lblProcessed.Name = "lblProcessed";
            this.lblProcessed.Size = new System.Drawing.Size(67, 15);
            this.lblProcessed.TabIndex = 13;
            this.lblProcessed.Text = "İşlenmiş:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 500);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(42, 15);
            this.lblStatus.TabIndex = 14;
            this.lblStatus.Text = "Durum:";
            // 
            // txtMLResults
            // 
            this.txtMLResults.Location = new System.Drawing.Point(6, 68);
            this.txtMLResults.Multiline = true;
            this.txtMLResults.Name = "txtMLResults";
            this.txtMLResults.ReadOnly = true;
            this.txtMLResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMLResults.Size = new System.Drawing.Size(300, 100);
            this.txtMLResults.TabIndex = 15;
            // 
            // lblMLResults
            // 
            this.lblMLResults.AutoSize = true;
            this.lblMLResults.Location = new System.Drawing.Point(6, 50);
            this.lblMLResults.Name = "lblMLResults";
            this.lblMLResults.Size = new System.Drawing.Size(78, 15);
            this.lblMLResults.TabIndex = 16;
            this.lblMLResults.Text = "ML Sonuçları:";
            // 
            // nudBlurRadius
            // 
            this.nudBlurRadius.Location = new System.Drawing.Point(218, 58);
            this.nudBlurRadius.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudBlurRadius.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBlurRadius.Name = "nudBlurRadius";
            this.nudBlurRadius.Size = new System.Drawing.Size(100, 23);
            this.nudBlurRadius.TabIndex = 17;
            this.nudBlurRadius.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // nudBrightness
            // 
            this.nudBrightness.DecimalPlaces = 0;
            this.nudBrightness.Location = new System.Drawing.Point(218, 58);
            this.nudBrightness.Maximum = new decimal(100);
            this.nudBrightness.Minimum = new decimal(-100);
            this.nudBrightness.Name = "nudBrightness";
            this.nudBrightness.Size = new System.Drawing.Size(100, 23);
            this.nudBrightness.TabIndex = 18;
            this.nudBrightness.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // nudContrast
            // 
            this.nudContrast.DecimalPlaces = 2;
            this.nudContrast.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudContrast.Location = new System.Drawing.Point(218, 58);
            this.nudContrast.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudContrast.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudContrast.Name = "nudContrast";
            this.nudContrast.Size = new System.Drawing.Size(100, 23);
            this.nudContrast.TabIndex = 19;
            this.nudContrast.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblBlurRadius
            // 
            this.lblBlurRadius.AutoSize = true;
            this.lblBlurRadius.Location = new System.Drawing.Point(218, 40);
            this.lblBlurRadius.Name = "lblBlurRadius";
            this.lblBlurRadius.Size = new System.Drawing.Size(68, 15);
            this.lblBlurRadius.TabIndex = 20;
            this.lblBlurRadius.Text = "Blur Radius:";
            // 
            // lblBrightness
            // 
            this.lblBrightness.AutoSize = true;
            this.lblBrightness.Location = new System.Drawing.Point(218, 40);
            this.lblBrightness.Name = "lblBrightness";
            this.lblBrightness.Size = new System.Drawing.Size(60, 15);
            this.lblBrightness.TabIndex = 21;
            this.lblBrightness.Text = "Parlaklık:";
            // 
            // lblContrast
            // 
            this.lblContrast.AutoSize = true;
            this.lblContrast.Location = new System.Drawing.Point(218, 40);
            this.lblContrast.Name = "lblContrast";
            this.lblContrast.Size = new System.Drawing.Size(56, 15);
            this.lblContrast.TabIndex = 22;
            this.lblContrast.Text = "Kontrast:";
            // 
            // groupBoxFilters
            // 
            this.groupBoxFilters.Controls.Add(this.btnGrayscale);
            this.groupBoxFilters.Controls.Add(this.btnEdgeDetection);
            this.groupBoxFilters.Controls.Add(this.btnBlur);
            this.groupBoxFilters.Controls.Add(this.btnSharpen);
            this.groupBoxFilters.Controls.Add(this.nudBlurRadius);
            this.groupBoxFilters.Controls.Add(this.lblBlurRadius);
            this.groupBoxFilters.Location = new System.Drawing.Point(12, 360);
            this.groupBoxFilters.Name = "groupBoxFilters";
            this.groupBoxFilters.Size = new System.Drawing.Size(430, 90);
            this.groupBoxFilters.TabIndex = 23;
            this.groupBoxFilters.TabStop = false;
            this.groupBoxFilters.Text = "Filtreler";
            // 
            // groupBoxAdjustments
            // 
            this.groupBoxAdjustments.Controls.Add(this.btnBrightness);
            this.groupBoxAdjustments.Controls.Add(this.btnContrast);
            this.groupBoxAdjustments.Controls.Add(this.nudBrightness);
            this.groupBoxAdjustments.Controls.Add(this.nudContrast);
            this.groupBoxAdjustments.Controls.Add(this.lblBrightness);
            this.groupBoxAdjustments.Controls.Add(this.lblContrast);
            this.groupBoxAdjustments.Location = new System.Drawing.Point(448, 360);
            this.groupBoxAdjustments.Name = "groupBoxAdjustments";
            this.groupBoxAdjustments.Size = new System.Drawing.Size(382, 90);
            this.groupBoxAdjustments.TabIndex = 24;
            this.groupBoxAdjustments.TabStop = false;
            this.groupBoxAdjustments.Text = "Ayarlamalar";
            // 
            // groupBoxML
            // 
            this.groupBoxML.Controls.Add(this.btnMLProcess);
            this.groupBoxML.Controls.Add(this.lblMLResults);
            this.groupBoxML.Controls.Add(this.txtMLResults);
            this.groupBoxML.Location = new System.Drawing.Point(12, 456);
            this.groupBoxML.Name = "groupBoxML";
            this.groupBoxML.Size = new System.Drawing.Size(818, 180);
            this.groupBoxML.TabIndex = 25;
            this.groupBoxML.TabStop = false;
            this.groupBoxML.Text = "Machine Learning İşlemleri";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 648);
            this.Controls.Add(this.groupBoxML);
            this.Controls.Add(this.groupBoxAdjustments);
            this.Controls.Add(this.groupBoxFilters);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblProcessed);
            this.Controls.Add(this.lblOriginal);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLoadImage);
            this.Controls.Add(this.pictureBoxProcessed);
            this.Controls.Add(this.pictureBoxOriginal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ML Matematik Görüntü İşleme Uygulaması";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProcessed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlurRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudContrast)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

