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
        private System.Windows.Forms.Button btnThemeToggle;
        private System.Windows.Forms.GroupBox groupBoxGeometric;
        private System.Windows.Forms.Button btnRotate;
        private System.Windows.Forms.Button btnFlipHorizontal;
        private System.Windows.Forms.Button btnFlipVertical;
        private System.Windows.Forms.Button btnCrop;
        private System.Windows.Forms.NumericUpDown nudRotationAngle;
        private System.Windows.Forms.Label lblRotationAngle;

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
            this.btnThemeToggle = new System.Windows.Forms.Button();
            this.groupBoxGeometric = new System.Windows.Forms.GroupBox();
            this.btnRotate = new System.Windows.Forms.Button();
            this.btnFlipHorizontal = new System.Windows.Forms.Button();
            this.btnFlipVertical = new System.Windows.Forms.Button();
            this.btnCrop = new System.Windows.Forms.Button();
            this.nudRotationAngle = new System.Windows.Forms.NumericUpDown();
            this.lblRotationAngle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProcessed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlurRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRotationAngle)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxOriginal
            // 
            this.pictureBoxOriginal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxOriginal.Location = new System.Drawing.Point(15, 55);
            this.pictureBoxOriginal.Name = "pictureBoxOriginal";
            this.pictureBoxOriginal.Size = new System.Drawing.Size(400, 320);
            this.pictureBoxOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxOriginal.TabIndex = 0;
            this.pictureBoxOriginal.TabStop = false;
            // 
            // pictureBoxProcessed
            // 
            this.pictureBoxProcessed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxProcessed.Location = new System.Drawing.Point(430, 55);
            this.pictureBoxProcessed.Name = "pictureBoxProcessed";
            this.pictureBoxProcessed.Size = new System.Drawing.Size(400, 320);
            this.pictureBoxProcessed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxProcessed.TabIndex = 1;
            this.pictureBoxProcessed.TabStop = false;
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Location = new System.Drawing.Point(15, 15);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(130, 35);
            this.btnLoadImage.TabIndex = 2;
            this.btnLoadImage.Text = "📷 Görüntü Yükle";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // btnGrayscale
            // 
            this.btnGrayscale.Location = new System.Drawing.Point(10, 25);
            this.btnGrayscale.Name = "btnGrayscale";
            this.btnGrayscale.Size = new System.Drawing.Size(110, 35);
            this.btnGrayscale.TabIndex = 3;
            this.btnGrayscale.Text = "Gri Tonlama";
            this.btnGrayscale.UseVisualStyleBackColor = true;
            this.btnGrayscale.Click += new System.EventHandler(this.btnGrayscale_Click);
            // 
            // btnEdgeDetection
            // 
            this.btnEdgeDetection.Location = new System.Drawing.Point(130, 25);
            this.btnEdgeDetection.Name = "btnEdgeDetection";
            this.btnEdgeDetection.Size = new System.Drawing.Size(110, 35);
            this.btnEdgeDetection.TabIndex = 4;
            this.btnEdgeDetection.Text = "Kenar Tespiti";
            this.btnEdgeDetection.UseVisualStyleBackColor = true;
            this.btnEdgeDetection.Click += new System.EventHandler(this.btnEdgeDetection_Click);
            // 
            // btnBlur
            // 
            this.btnBlur.Location = new System.Drawing.Point(250, 25);
            this.btnBlur.Name = "btnBlur";
            this.btnBlur.Size = new System.Drawing.Size(110, 35);
            this.btnBlur.TabIndex = 5;
            this.btnBlur.Text = "Blur";
            this.btnBlur.UseVisualStyleBackColor = true;
            this.btnBlur.Click += new System.EventHandler(this.btnBlur_Click);
            // 
            // btnSharpen
            // 
            this.btnSharpen.Location = new System.Drawing.Point(370, 25);
            this.btnSharpen.Name = "btnSharpen";
            this.btnSharpen.Size = new System.Drawing.Size(110, 35);
            this.btnSharpen.TabIndex = 6;
            this.btnSharpen.Text = "Keskinleştir";
            this.btnSharpen.UseVisualStyleBackColor = true;
            this.btnSharpen.Click += new System.EventHandler(this.btnSharpen_Click);
            // 
            // btnBrightness
            // 
            this.btnBrightness.Location = new System.Drawing.Point(10, 25);
            this.btnBrightness.Name = "btnBrightness";
            this.btnBrightness.Size = new System.Drawing.Size(110, 35);
            this.btnBrightness.TabIndex = 7;
            this.btnBrightness.Text = "Parlaklık";
            this.btnBrightness.UseVisualStyleBackColor = true;
            this.btnBrightness.Click += new System.EventHandler(this.btnBrightness_Click);
            // 
            // btnContrast
            // 
            this.btnContrast.Location = new System.Drawing.Point(130, 25);
            this.btnContrast.Name = "btnContrast";
            this.btnContrast.Size = new System.Drawing.Size(110, 35);
            this.btnContrast.TabIndex = 8;
            this.btnContrast.Text = "Kontrast";
            this.btnContrast.UseVisualStyleBackColor = true;
            this.btnContrast.Click += new System.EventHandler(this.btnContrast_Click);
            // 
            // btnMLProcess
            // 
            this.btnMLProcess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnMLProcess.ForeColor = System.Drawing.Color.White;
            this.btnMLProcess.Location = new System.Drawing.Point(10, 25);
            this.btnMLProcess.Name = "btnMLProcess";
            this.btnMLProcess.Size = new System.Drawing.Size(160, 45);
            this.btnMLProcess.TabIndex = 9;
            this.btnMLProcess.Text = "🤖 ML İşlemi Uygula";
            this.btnMLProcess.UseVisualStyleBackColor = false;
            this.btnMLProcess.Click += new System.EventHandler(this.btnMLProcess_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(155, 15);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(130, 35);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "💾 Kaydet";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(295, 15);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(130, 35);
            this.btnReset.TabIndex = 11;
            this.btnReset.Text = "🔄 Sıfırla";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnThemeToggle
            // 
            this.btnThemeToggle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnThemeToggle.ForeColor = System.Drawing.Color.White;
            this.btnThemeToggle.Location = new System.Drawing.Point(700, 15);
            this.btnThemeToggle.Name = "btnThemeToggle";
            this.btnThemeToggle.Size = new System.Drawing.Size(130, 35);
            this.btnThemeToggle.TabIndex = 26;
            this.btnThemeToggle.Text = "🌙 Koyu Tema";
            this.btnThemeToggle.UseVisualStyleBackColor = false;
            this.btnThemeToggle.Click += new System.EventHandler(this.btnThemeToggle_Click);
            // 
            // lblOriginal
            // 
            this.lblOriginal.AutoSize = true;
            this.lblOriginal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblOriginal.Location = new System.Drawing.Point(15, 380);
            this.lblOriginal.Name = "lblOriginal";
            this.lblOriginal.Size = new System.Drawing.Size(58, 15);
            this.lblOriginal.TabIndex = 12;
            this.lblOriginal.Text = "Orijinal:";
            // 
            // lblProcessed
            // 
            this.lblProcessed.AutoSize = true;
            this.lblProcessed.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblProcessed.Location = new System.Drawing.Point(430, 380);
            this.lblProcessed.Name = "lblProcessed";
            this.lblProcessed.Size = new System.Drawing.Size(65, 15);
            this.lblProcessed.TabIndex = 13;
            this.lblProcessed.Text = "İşlenmiş:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStatus.Location = new System.Drawing.Point(15, 850);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(50, 15);
            this.lblStatus.TabIndex = 14;
            this.lblStatus.Text = "Durum:";
            // 
            // txtMLResults
            // 
            this.txtMLResults.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtMLResults.Location = new System.Drawing.Point(10, 80);
            this.txtMLResults.Multiline = true;
            this.txtMLResults.Name = "txtMLResults";
            this.txtMLResults.ReadOnly = true;
            this.txtMLResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMLResults.Size = new System.Drawing.Size(320, 110);
            this.txtMLResults.TabIndex = 15;
            // 
            // lblMLResults
            // 
            this.lblMLResults.AutoSize = true;
            this.lblMLResults.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMLResults.Location = new System.Drawing.Point(10, 60);
            this.lblMLResults.Name = "lblMLResults";
            this.lblMLResults.Size = new System.Drawing.Size(78, 15);
            this.lblMLResults.TabIndex = 16;
            this.lblMLResults.Text = "ML Sonuçları:";
            this.lblMLResults.Visible = false;
            // 
            // nudBlurRadius
            // 
            this.nudBlurRadius.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nudBlurRadius.Location = new System.Drawing.Point(250, 68);
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
            this.nudBlurRadius.Size = new System.Drawing.Size(110, 23);
            this.nudBlurRadius.TabIndex = 20;
            this.nudBlurRadius.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // nudBrightness
            // 
            this.nudBrightness.DecimalPlaces = 0;
            this.nudBrightness.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nudBrightness.Location = new System.Drawing.Point(10, 68);
            this.nudBrightness.Maximum = new decimal(100);
            this.nudBrightness.Minimum = new decimal(-100);
            this.nudBrightness.Name = "nudBrightness";
            this.nudBrightness.Size = new System.Drawing.Size(110, 23);
            this.nudBrightness.TabIndex = 19;
            this.nudBrightness.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // nudContrast
            // 
            this.nudContrast.DecimalPlaces = 2;
            this.nudContrast.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nudContrast.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudContrast.Location = new System.Drawing.Point(130, 68);
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
            this.nudContrast.Size = new System.Drawing.Size(110, 23);
            this.nudContrast.TabIndex = 21;
            this.nudContrast.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblBlurRadius
            // 
            this.lblBlurRadius.AutoSize = true;
            this.lblBlurRadius.BackColor = System.Drawing.Color.Transparent;
            this.lblBlurRadius.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblBlurRadius.Location = new System.Drawing.Point(250, 50);
            this.lblBlurRadius.Name = "lblBlurRadius";
            this.lblBlurRadius.Size = new System.Drawing.Size(75, 15);
            this.lblBlurRadius.TabIndex = 16;
            this.lblBlurRadius.Text = "Blur Radius:";
            this.lblBlurRadius.Visible = false;
            // 
            // lblBrightness
            // 
            this.lblBrightness.AutoSize = true;
            this.lblBrightness.BackColor = System.Drawing.Color.Transparent;
            this.lblBrightness.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblBrightness.Location = new System.Drawing.Point(10, 50);
            this.lblBrightness.Name = "lblBrightness";
            this.lblBrightness.Size = new System.Drawing.Size(60, 15);
            this.lblBrightness.TabIndex = 17;
            this.lblBrightness.Text = "Parlaklık:";
            this.lblBrightness.Visible = false;
            // 
            // lblContrast
            // 
            this.lblContrast.AutoSize = true;
            this.lblContrast.BackColor = System.Drawing.Color.Transparent;
            this.lblContrast.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblContrast.Location = new System.Drawing.Point(130, 50);
            this.lblContrast.Name = "lblContrast";
            this.lblContrast.Size = new System.Drawing.Size(56, 15);
            this.lblContrast.TabIndex = 18;
            this.lblContrast.Text = "Kontrast:";
            this.lblContrast.Visible = false;
            // 
            // groupBoxFilters
            // 
            this.groupBoxFilters.Controls.Add(this.btnGrayscale);
            this.groupBoxFilters.Controls.Add(this.btnEdgeDetection);
            this.groupBoxFilters.Controls.Add(this.btnBlur);
            this.groupBoxFilters.Controls.Add(this.btnSharpen);
            this.groupBoxFilters.Controls.Add(this.nudBlurRadius);
            this.groupBoxFilters.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBoxFilters.Location = new System.Drawing.Point(15, 400);
            this.groupBoxFilters.Name = "groupBoxFilters";
            this.groupBoxFilters.Size = new System.Drawing.Size(490, 110);
            this.groupBoxFilters.TabIndex = 23;
            this.groupBoxFilters.TabStop = false;
            this.groupBoxFilters.Text = "🎨 Filtreler";
            // 
            // groupBoxAdjustments
            // 
            this.groupBoxAdjustments.Controls.Add(this.btnBrightness);
            this.groupBoxAdjustments.Controls.Add(this.btnContrast);
            this.groupBoxAdjustments.Controls.Add(this.nudBrightness);
            this.groupBoxAdjustments.Controls.Add(this.nudContrast);
            this.groupBoxAdjustments.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBoxAdjustments.Location = new System.Drawing.Point(515, 400);
            this.groupBoxAdjustments.Name = "groupBoxAdjustments";
            this.groupBoxAdjustments.Size = new System.Drawing.Size(375, 110);
            this.groupBoxAdjustments.TabIndex = 24;
            this.groupBoxAdjustments.TabStop = false;
            this.groupBoxAdjustments.Text = "⚙️ Ayarlamalar";
            // 
            // groupBoxML
            // 
            this.groupBoxML.Controls.Add(this.btnMLProcess);
            this.groupBoxML.Controls.Add(this.txtMLResults);
            this.groupBoxML.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBoxML.Location = new System.Drawing.Point(15, 630);
            this.groupBoxML.Name = "groupBoxML";
            this.groupBoxML.Size = new System.Drawing.Size(875, 210);
            this.groupBoxML.TabIndex = 25;
            this.groupBoxML.TabStop = false;
            this.groupBoxML.Text = "🤖 Machine Learning İşlemleri";
            // 
            // groupBoxGeometric
            // 
            this.groupBoxGeometric.Controls.Add(this.btnRotate);
            this.groupBoxGeometric.Controls.Add(this.btnFlipHorizontal);
            this.groupBoxGeometric.Controls.Add(this.btnFlipVertical);
            this.groupBoxGeometric.Controls.Add(this.btnCrop);
            this.groupBoxGeometric.Controls.Add(this.nudRotationAngle);
            this.groupBoxGeometric.Controls.Add(this.lblRotationAngle);
            this.groupBoxGeometric.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBoxGeometric.Location = new System.Drawing.Point(15, 520);
            this.groupBoxGeometric.Name = "groupBoxGeometric";
            this.groupBoxGeometric.Size = new System.Drawing.Size(875, 100);
            this.groupBoxGeometric.TabIndex = 27;
            this.groupBoxGeometric.TabStop = false;
            this.groupBoxGeometric.Text = "📐 Geometrik Dönüşümler";
            // 
            // btnRotate
            // 
            this.btnRotate.Location = new System.Drawing.Point(10, 25);
            this.btnRotate.Name = "btnRotate";
            this.btnRotate.Size = new System.Drawing.Size(110, 35);
            this.btnRotate.TabIndex = 0;
            this.btnRotate.Text = "🔄 Döndür";
            this.btnRotate.UseVisualStyleBackColor = true;
            this.btnRotate.Click += new System.EventHandler(this.btnRotate_Click);
            // 
            // 
            // btnFlipHorizontal
            // 
            this.btnFlipHorizontal.Location = new System.Drawing.Point(130, 25);
            this.btnFlipHorizontal.Name = "btnFlipHorizontal";
            this.btnFlipHorizontal.Size = new System.Drawing.Size(110, 35);
            this.btnFlipHorizontal.TabIndex = 2;
            this.btnFlipHorizontal.Text = "↔️ Yatay Yansıt";
            this.btnFlipHorizontal.UseVisualStyleBackColor = true;
            this.btnFlipHorizontal.Click += new System.EventHandler(this.btnFlipHorizontal_Click);
            // 
            // btnFlipVertical
            // 
            this.btnFlipVertical.Location = new System.Drawing.Point(250, 25);
            this.btnFlipVertical.Name = "btnFlipVertical";
            this.btnFlipVertical.Size = new System.Drawing.Size(110, 35);
            this.btnFlipVertical.TabIndex = 3;
            this.btnFlipVertical.Text = "↕️ Dikey Yansıt";
            this.btnFlipVertical.UseVisualStyleBackColor = true;
            this.btnFlipVertical.Click += new System.EventHandler(this.btnFlipVertical_Click);
            // 
            // btnCrop
            // 
            this.btnCrop.Location = new System.Drawing.Point(370, 25);
            this.btnCrop.Name = "btnCrop";
            this.btnCrop.Size = new System.Drawing.Size(110, 35);
            this.btnCrop.TabIndex = 4;
            this.btnCrop.Text = "✂️ Kırp";
            this.btnCrop.UseVisualStyleBackColor = true;
            this.btnCrop.Click += new System.EventHandler(this.btnCrop_Click);
            // 
            // nudRotationAngle
            // 
            this.nudRotationAngle.DecimalPlaces = 1;
            this.nudRotationAngle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nudRotationAngle.Location = new System.Drawing.Point(10, 68);
            this.nudRotationAngle.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nudRotationAngle.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.nudRotationAngle.Name = "nudRotationAngle";
            this.nudRotationAngle.Size = new System.Drawing.Size(110, 23);
            this.nudRotationAngle.TabIndex = 5;
            this.nudRotationAngle.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // lblRotationAngle
            // 
            this.lblRotationAngle.AutoSize = true;
            this.lblRotationAngle.BackColor = System.Drawing.Color.Transparent;
            this.lblRotationAngle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRotationAngle.Location = new System.Drawing.Point(10, 50);
            this.lblRotationAngle.Name = "lblRotationAngle";
            this.lblRotationAngle.Size = new System.Drawing.Size(70, 15);
            this.lblRotationAngle.TabIndex = 7;
            this.lblRotationAngle.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 860);
            this.Controls.Add(this.btnThemeToggle);
            this.Controls.Add(this.groupBoxGeometric);
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
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
            ((System.ComponentModel.ISupportInitialize)(this.nudRotationAngle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

