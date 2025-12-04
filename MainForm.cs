using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MLImageProcessing.Processors;

namespace MLImageProcessing
{
    public partial class MainForm : Form
    {
        private ImageProcessor imageProcessor;
        private MathMLProcessor mathMLProcessor;
        private Bitmap? originalImage;
        private Bitmap? processedImage;
        private ThemeManager themeManager;

        // İnteraktif dönüşümler için değişkenler
        private bool isCropMode = false;
        private bool isDrawingCrop = false;
        private Point cropStartPoint;
        private Rectangle cropRectangle;
        private float currentZoom = 1.0f;
        private Point zoomCenter = Point.Empty;

        public MainForm()
        {
            InitializeComponent();
            imageProcessor = new ImageProcessor();
            mathMLProcessor = new MathMLProcessor();
            themeManager = new ThemeManager();
            ApplyTheme();
            InitializeInteractiveFeatures();
        }

        private void InitializeInteractiveFeatures()
        {
            // PictureBox'lara mouse event'leri ekle
            pictureBoxOriginal.MouseDown += PictureBox_MouseDown;
            pictureBoxOriginal.MouseMove += PictureBox_MouseMove;
            pictureBoxOriginal.MouseUp += PictureBox_MouseUp;
            pictureBoxOriginal.Paint += PictureBox_Paint;
            pictureBoxOriginal.MouseWheel += PictureBox_MouseWheel;
            pictureBoxOriginal.MouseEnter += PictureBox_MouseEnter;
            pictureBoxOriginal.DoubleClick += PictureBox_DoubleClick;

            pictureBoxProcessed.MouseDown += PictureBox_MouseDown;
            pictureBoxProcessed.MouseMove += PictureBox_MouseMove;
            pictureBoxProcessed.MouseUp += PictureBox_MouseUp;
            pictureBoxProcessed.Paint += PictureBox_Paint;
            pictureBoxProcessed.MouseWheel += PictureBox_MouseWheel;
            pictureBoxProcessed.MouseEnter += PictureBox_MouseEnter;
            pictureBoxProcessed.DoubleClick += PictureBox_DoubleClick;
        }

        private void ApplyTheme()
        {
            themeManager.ApplyTheme(this);
            UpdateThemeButtonText();
        }

        private void UpdateThemeButtonText()
        {
            if (themeManager.CurrentTheme == Theme.Light)
            {
                btnThemeToggle.Text = "🌙 Koyu Tema";
            }
            else
            {
                btnThemeToggle.Text = "☀️ Açık Tema";
            }
        }

        private void btnThemeToggle_Click(object sender, EventArgs e)
        {
            themeManager.ToggleTheme();
            ApplyTheme();
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Eski zoomed görüntüleri temizle
                        if (pictureBoxOriginal.Image != null && pictureBoxOriginal.Image != originalImage)
                        {
                            pictureBoxOriginal.Image.Dispose();
                        }
                        if (pictureBoxProcessed.Image != null && pictureBoxProcessed.Image != processedImage)
                        {
                            pictureBoxProcessed.Image.Dispose();
                        }

                        originalImage = new Bitmap(openFileDialog.FileName);
                        pictureBoxOriginal.Image = originalImage;
                        pictureBoxProcessed.Image = null;
                        processedImage = null;
                        currentZoom = 1.0f;
                        isCropMode = false;
                        cropRectangle = Rectangle.Empty;
                        btnCrop.BackColor = Color.FromArgb(108, 117, 125);
                        btnCrop.Text = "✂️ Kırp";
                        lblStatus.Text = "Görüntü yüklendi: " + Path.GetFileName(openFileDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Görüntü yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private Bitmap GetSourceImage()
        {
            return processedImage ?? originalImage ?? throw new InvalidOperationException("Görüntü yüklenmemiş.");
        }

        private void btnGrayscale_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
            {
                MessageBox.Show("Lütfen önce bir görüntü yükleyin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Bitmap source = GetSourceImage();
            processedImage = imageProcessor.ConvertToGrayscale(source);
            pictureBoxProcessed.Image = processedImage;
            lblStatus.Text = "Gri tonlama uygulandı.";
        }

        private void btnEdgeDetection_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
            {
                MessageBox.Show("Lütfen önce bir görüntü yükleyin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Bitmap source = GetSourceImage();
            processedImage = imageProcessor.DetectEdges(source);
            pictureBoxProcessed.Image = processedImage;
            lblStatus.Text = "Kenar tespiti uygulandı.";
        }

        private void btnBlur_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
            {
                MessageBox.Show("Lütfen önce bir görüntü yükleyin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Bitmap source = GetSourceImage();
            int blurRadius = (int)nudBlurRadius.Value;
            processedImage = imageProcessor.ApplyBlur(source, blurRadius);
            pictureBoxProcessed.Image = processedImage;
            lblStatus.Text = $"Blur uygulandı (Radius: {blurRadius}).";
        }

        private void btnSharpen_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
            {
                MessageBox.Show("Lütfen önce bir görüntü yükleyin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Bitmap source = GetSourceImage();
            processedImage = imageProcessor.ApplySharpen(source);
            pictureBoxProcessed.Image = processedImage;
            lblStatus.Text = "Keskinleştirme uygulandı.";
        }

        private void btnBrightness_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
            {
                MessageBox.Show("Lütfen önce bir görüntü yükleyin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Bitmap source = GetSourceImage();
                decimal brightnessValue = nudBrightness.Value;
                // Değeri Int32 aralığına sınırla
                if (brightnessValue > int.MaxValue)
                    brightnessValue = int.MaxValue;
                else if (brightnessValue < int.MinValue)
                    brightnessValue = int.MinValue;

                int brightness = (int)brightnessValue;
                processedImage = imageProcessor.AdjustBrightness(source, brightness);
                pictureBoxProcessed.Image = processedImage;
                lblStatus.Text = $"Parlaklık ayarlandı: {brightness}.";
            }
            catch (OverflowException)
            {
                MessageBox.Show("Parlaklık değeri çok büyük veya çok küçük. Lütfen -100 ile 100 arasında bir değer girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnContrast_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
            {
                MessageBox.Show("Lütfen önce bir görüntü yükleyin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Bitmap source = GetSourceImage();
            float contrast = (float)nudContrast.Value;
            processedImage = imageProcessor.AdjustContrast(source, contrast);
            pictureBoxProcessed.Image = processedImage;
            lblStatus.Text = $"Kontrast ayarlandı: {contrast:F2}.";
        }

        private void btnMLProcess_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
            {
                MessageBox.Show("Lütfen önce bir görüntü yükleyin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                lblStatus.Text = "ML işlemi yapılıyor...";
                Application.DoEvents();

                Bitmap source = GetSourceImage();
                var result = mathMLProcessor.ProcessImageWithML(source);
                processedImage = result.ProcessedImage;
                pictureBoxProcessed.Image = processedImage;

                txtMLResults.Text = $"Ortalama Parlaklık: {result.AverageBrightness:F2}\r\n" +
                                   $"Standart Sapma: {result.StandardDeviation:F2}\r\n" +
                                   $"Entropi: {result.Entropy:F2}\r\n" +
                                   $"Kontrast Skoru: {result.ContrastScore:F2}\r\n" +
                                   $"Tahmin Edilen Sınıf: {result.PredictedClass}";

                lblStatus.Text = "ML işlemi tamamlandı.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("ML işlemi sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "ML işlemi başarısız.";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (processedImage == null)
            {
                MessageBox.Show("Kaydedilecek işlenmiş görüntü yok.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JPEG Image|*.jpg|PNG Image|*.png|Bitmap Image|*.bmp";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        processedImage.Save(saveFileDialog.FileName);
                        lblStatus.Text = "Görüntü kaydedildi: " + Path.GetFileName(saveFileDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Görüntü kaydedilirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // İşlenmiş görüntüyü temizle
            if (pictureBoxProcessed != null)
            {
                // Zoomed görüntüyü dispose et
                if (pictureBoxProcessed.Image != null && pictureBoxProcessed.Image != processedImage && pictureBoxProcessed.Image != originalImage)
                {
                    pictureBoxProcessed.Image.Dispose();
                }
                pictureBoxProcessed.Image = null;
            }
            
            // Orijinal görüntüde zoom varsa onu da temizle
            if (pictureBoxOriginal != null && pictureBoxOriginal.Image != null && pictureBoxOriginal.Image != originalImage)
            {
                pictureBoxOriginal.Image.Dispose();
                pictureBoxOriginal.Image = originalImage; // Orijinal görüntüyü geri yükle
            }
            
            processedImage = null;
            currentZoom = 1.0f;
            
            // ML sonuçlarını temizle
            if (txtMLResults != null)
                txtMLResults.Clear();
            
            // Kırpma modunu kapat
            if (isCropMode)
            {
                isCropMode = false;
                btnCrop.BackColor = Color.FromArgb(108, 117, 125);
                btnCrop.Text = "✂️ Kırp";
                cropRectangle = Rectangle.Empty;
                pictureBoxOriginal?.Invalidate();
                pictureBoxProcessed?.Invalidate();
            }
            
            lblStatus.Text = "Tüm işlemler sıfırlandı. İşlenmiş görüntü ve zoom ayarları temizlendi.";
        }

        // Geometrik Dönüşümler

        private void btnRotate_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
            {
                MessageBox.Show("Lütfen önce bir görüntü yükleyin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Bitmap source = GetSourceImage();
            float angle = (float)nudRotationAngle.Value;
            processedImage = imageProcessor.Rotate(source, angle);
            pictureBoxProcessed.Image = processedImage;
            lblStatus.Text = $"Görüntü {angle:F1} derece döndürüldü.";
        }


        private void btnFlipHorizontal_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
            {
                MessageBox.Show("Lütfen önce bir görüntü yükleyin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Bitmap source = GetSourceImage();
            processedImage = imageProcessor.Flip(source, horizontal: true, vertical: false);
            pictureBoxProcessed.Image = processedImage;
            lblStatus.Text = "Görüntü yatay olarak yansıtıldı.";
        }

        private void btnFlipVertical_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
            {
                MessageBox.Show("Lütfen önce bir görüntü yükleyin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Bitmap source = GetSourceImage();
            processedImage = imageProcessor.Flip(source, horizontal: false, vertical: true);
            pictureBoxProcessed.Image = processedImage;
            lblStatus.Text = "Görüntü dikey olarak yansıtıldı.";
        }

        private void btnCrop_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
            {
                MessageBox.Show("Lütfen önce bir görüntü yükleyin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kırpma modunu aktif/pasif yap
            isCropMode = !isCropMode;
            if (isCropMode)
            {
                btnCrop.BackColor = Color.Green;
                btnCrop.Text = "✂️ Kırpma Modu (Aktif)";
                lblStatus.Text = "Kırpma modu aktif. Görüntü üzerinde fare ile seçim yapın. Seçim yaptıktan sonra onay dialog'u açılacak.";
                cropRectangle = Rectangle.Empty;
                pictureBoxOriginal.Focus(); // Focus'u pictureBox'a ver ki Enter tuşu çalışsın
            }
            else
            {
                btnCrop.BackColor = Color.FromArgb(108, 117, 125);
                btnCrop.Text = "✂️ Kırp";
                lblStatus.Text = "Kırpma modu kapatıldı.";
                cropRectangle = Rectangle.Empty;
                pictureBoxOriginal.Invalidate();
                pictureBoxProcessed.Invalidate();
            }
        }

        private PictureBox? activePictureBox = null;

        private void ApplyCropFromSelection()
        {
            if (originalImage == null || cropRectangle.Width <= 0 || cropRectangle.Height <= 0 || activePictureBox == null)
                return;

            // PictureBox koordinatlarını görüntü koordinatlarına çevir
            Rectangle imageCropRect = ConvertPictureBoxToImageCoordinates(cropRectangle, activePictureBox);
            
            if (imageCropRect.Width > 0 && imageCropRect.Height > 0)
            {
                Bitmap sourceImage = activePictureBox == pictureBoxOriginal ? originalImage : (processedImage ?? originalImage);
                processedImage = imageProcessor.Crop(sourceImage, imageCropRect);
                pictureBoxProcessed.Image = processedImage;
                lblStatus.Text = $"Görüntü kırpıldı. Yeni boyut: {processedImage.Width}x{processedImage.Height}";
            }

            isCropMode = false;
            btnCrop.BackColor = Color.FromArgb(108, 117, 125);
            btnCrop.Text = "✂️ Kırp";
            cropRectangle = Rectangle.Empty;
            pictureBoxOriginal.Invalidate();
            pictureBoxProcessed.Invalidate();
            activePictureBox = null;
        }

        private Rectangle ConvertPictureBoxToImageCoordinates(Rectangle pictureBoxRect, PictureBox pictureBox)
        {
            if (pictureBox.Image == null || pictureBox.SizeMode != PictureBoxSizeMode.Zoom)
                return pictureBoxRect;

            // Zoom ve padding hesaplamaları
            float imageAspect = (float)pictureBox.Image.Width / pictureBox.Image.Height;
            float boxAspect = (float)pictureBox.Width / pictureBox.Height;

            int imageWidth, imageHeight;
            int offsetX = 0, offsetY = 0;

            if (imageAspect > boxAspect)
            {
                // Görüntü genişliği box'ı dolduruyor
                imageWidth = pictureBox.Width;
                imageHeight = (int)(pictureBox.Width / imageAspect);
                offsetY = (pictureBox.Height - imageHeight) / 2;
            }
            else
            {
                // Görüntü yüksekliği box'ı dolduruyor
                imageHeight = pictureBox.Height;
                imageWidth = (int)(pictureBox.Height * imageAspect);
                offsetX = (pictureBox.Width - imageWidth) / 2;
            }

            // PictureBox koordinatlarını görüntü koordinatlarına çevir
            float scaleX = (float)pictureBox.Image.Width / imageWidth;
            float scaleY = (float)pictureBox.Image.Height / imageHeight;

            int x = (int)((pictureBoxRect.X - offsetX) * scaleX);
            int y = (int)((pictureBoxRect.Y - offsetY) * scaleY);
            int width = (int)(pictureBoxRect.Width * scaleX);
            int height = (int)(pictureBoxRect.Height * scaleY);

            // Sınırları kontrol et
            x = Math.Max(0, Math.Min(x, pictureBox.Image.Width - 1));
            y = Math.Max(0, Math.Min(y, pictureBox.Image.Height - 1));
            width = Math.Min(width, pictureBox.Image.Width - x);
            height = Math.Min(height, pictureBox.Image.Height - y);

            return new Rectangle(x, y, width, height);
        }

        // Mouse Event Handlers
        private void PictureBox_MouseDown(object? sender, MouseEventArgs e)
        {
            if (sender is not PictureBox pb || pb.Image == null) return;

            activePictureBox = pb;

            if (isCropMode && e.Button == MouseButtons.Left)
            {
                isDrawingCrop = true;
                cropStartPoint = e.Location;
                cropRectangle = new Rectangle(cropStartPoint, Size.Empty);
            }
        }

        private void PictureBox_MouseMove(object? sender, MouseEventArgs e)
        {
            if (sender is not PictureBox pb || pb.Image == null) return;

            if (isCropMode && isDrawingCrop && e.Button == MouseButtons.Left)
            {
                int x = Math.Min(cropStartPoint.X, e.X);
                int y = Math.Min(cropStartPoint.Y, e.Y);
                int width = Math.Abs(e.X - cropStartPoint.X);
                int height = Math.Abs(e.Y - cropStartPoint.Y);

                cropRectangle = new Rectangle(x, y, width, height);
                pb.Invalidate();
            }
        }

        private void PictureBox_MouseUp(object? sender, MouseEventArgs e)
        {
            if (sender is not PictureBox pb || pb.Image == null) return;

            if (isCropMode && isDrawingCrop && e.Button == MouseButtons.Left)
            {
                isDrawingCrop = false;
                
                if (cropRectangle.Width > 10 && cropRectangle.Height > 10)
                {
                    // Seçim yapıldıktan sonra otomatik olarak onay dialog'u göster
                    DialogResult result = MessageBox.Show(
                        $"Seçilen alan: {cropRectangle.Width} x {cropRectangle.Height} piksel\n\nKırpma işlemini uygulamak istiyor musunuz?",
                        "Kırpma Onayı",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (result == DialogResult.Yes)
                    {
                        ApplyCropFromSelection();
                    }
                    else
                    {
                        lblStatus.Text = "Kırpma iptal edildi. Yeni bir seçim yapabilirsiniz.";
                        cropRectangle = Rectangle.Empty;
                        pb.Invalidate();
                    }
                }
            }
        }

        private void PictureBox_DoubleClick(object? sender, EventArgs e)
        {
            if (isCropMode && cropRectangle.Width > 10 && cropRectangle.Height > 10)
            {
                ApplyCropFromSelection();
            }
        }

        private void PictureBox_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is not PictureBox pb || !isCropMode) return;

            if (cropRectangle.Width > 0 && cropRectangle.Height > 0)
            {
                // Seçim dikdörtgenini çiz
                using (Pen pen = new Pen(Color.Red, 2))
                {
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    e.Graphics.DrawRectangle(pen, cropRectangle);
                }

                // Seçim alanını yarı saydam doldur
                using (Brush brush = new SolidBrush(Color.FromArgb(50, Color.Blue)))
                {
                    e.Graphics.FillRectangle(brush, cropRectangle);
                }

                // Boyut bilgisini göster
                string sizeText = $"{cropRectangle.Width} x {cropRectangle.Height}";
                SizeF textSize = e.Graphics.MeasureString(sizeText, pb.Font);
                PointF textPos = new PointF(
                    cropRectangle.X + (cropRectangle.Width - textSize.Width) / 2,
                    cropRectangle.Y + (cropRectangle.Height - textSize.Height) / 2
                );
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(200, Color.White)), 
                    textPos.X - 2, textPos.Y - 2, textSize.Width + 4, textSize.Height + 4);
                e.Graphics.DrawString(sizeText, pb.Font, new SolidBrush(Color.Black), textPos);

                // Talimat metni göster
                if (isDrawingCrop || (!isDrawingCrop && cropRectangle.Width > 10))
                {
                    string instructionText = isDrawingCrop ? "Seçimi bırakın..." : "Çift tıklayın veya Enter'a basın";
                    SizeF instructionSize = e.Graphics.MeasureString(instructionText, pb.Font);
                    PointF instructionPos = new PointF(
                        cropRectangle.X + (cropRectangle.Width - instructionSize.Width) / 2,
                        cropRectangle.Y + cropRectangle.Height + 5
                    );
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(220, Color.Yellow)), 
                        instructionPos.X - 3, instructionPos.Y - 2, instructionSize.Width + 6, instructionSize.Height + 4);
                    e.Graphics.DrawString(instructionText, pb.Font, new SolidBrush(Color.Black), instructionPos);
                }
            }
        }

        private void PictureBox_MouseWheel(object? sender, MouseEventArgs e)
        {
            if (sender is not PictureBox pb || pb.Image == null) return;

            // Ctrl + Mouse Wheel ile zoom (sadece önizleme için, orijinal görüntüyü değiştirmez)
            if (Control.ModifierKeys == Keys.Control)
            {
                float zoomFactor = e.Delta > 0 ? 1.1f : 0.9f;
                currentZoom *= zoomFactor;
                currentZoom = Math.Max(0.1f, Math.Min(5.0f, currentZoom));

                // Zoom merkezini ayarla
                zoomCenter = e.Location;

                // Görüntüyü yeniden boyutlandır (sadece önizleme)
                Bitmap? sourceImage = null;
                if (pb == pictureBoxOriginal && originalImage != null)
                {
                    sourceImage = originalImage;
                }
                else if (pb == pictureBoxProcessed)
                {
                    sourceImage = processedImage ?? originalImage;
                }

                if (sourceImage != null)
                {
                    int newWidth = (int)(sourceImage.Width * currentZoom);
                    int newHeight = (int)(sourceImage.Height * currentZoom);
                    Bitmap zoomed = imageProcessor.ResizeToDimensions(sourceImage, newWidth, newHeight);
                    
                    // Eski zoomed görüntüyü dispose et
                    if (pb.Image != null && pb.Image != originalImage && pb.Image != processedImage)
                    {
                        pb.Image.Dispose();
                    }
                    
                    pb.Image = zoomed;
                    lblStatus.Text = $"Zoom: {currentZoom:F2}x (Önizleme - Reset için görüntüyü yeniden yükleyin)";
                }
            }
        }

        private void PictureBox_MouseEnter(object? sender, EventArgs e)
        {
            if (sender is PictureBox pb)
            {
                activePictureBox = pb;
                pb.Focus(); // Mouse wheel event'lerini almak için focus
            }
        }

        private void btnCrop_Click_Old(object sender, EventArgs e)
        {
            if (originalImage == null)
            {
                MessageBox.Show("Lütfen önce bir görüntü yükleyin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kırpma için basit bir dialog
            using (Form cropDialog = new Form())
            {
                cropDialog.Text = "Kırpma Ayarları";
                cropDialog.Size = new Size(400, 250);
                cropDialog.StartPosition = FormStartPosition.CenterParent;
                cropDialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                cropDialog.MaximizeBox = false;
                cropDialog.MinimizeBox = false;

                Label lblX = new Label { Text = "X:", Location = new Point(20, 20), AutoSize = true };
                NumericUpDown nudX = new NumericUpDown
                {
                    Location = new Point(60, 18),
                    Width = 100,
                    Minimum = 0,
                    Maximum = originalImage.Width - 1,
                    Value = originalImage.Width / 4
                };

                Label lblY = new Label { Text = "Y:", Location = new Point(180, 20), AutoSize = true };
                NumericUpDown nudY = new NumericUpDown
                {
                    Location = new Point(220, 18),
                    Width = 100,
                    Minimum = 0,
                    Maximum = originalImage.Height - 1,
                    Value = originalImage.Height / 4
                };

                Label lblWidth = new Label { Text = "Genişlik:", Location = new Point(20, 60), AutoSize = true };
                NumericUpDown nudWidth = new NumericUpDown
                {
                    Location = new Point(90, 58),
                    Width = 100,
                    Minimum = 1,
                    Maximum = originalImage.Width,
                    Value = originalImage.Width / 2
                };

                Label lblHeight = new Label { Text = "Yükseklik:", Location = new Point(200, 60), AutoSize = true };
                NumericUpDown nudHeight = new NumericUpDown
                {
                    Location = new Point(280, 58),
                    Width = 100,
                    Minimum = 1,
                    Maximum = originalImage.Height,
                    Value = originalImage.Height / 2
                };

                Button btnOK = new Button
                {
                    Text = "Tamam",
                    DialogResult = DialogResult.OK,
                    Location = new Point(120, 120),
                    Width = 80
                };

                Button btnCancel = new Button
                {
                    Text = "İptal",
                    DialogResult = DialogResult.Cancel,
                    Location = new Point(210, 120),
                    Width = 80
                };

                // X ve Width değerlerini kontrol et
                nudX.Maximum = originalImage.Width - 1;
                nudWidth.Maximum = originalImage.Width;
                nudX.ValueChanged += (s, args) =>
                {
                    nudWidth.Maximum = originalImage.Width - (int)nudX.Value;
                    if (nudX.Value + nudWidth.Value > originalImage.Width)
                        nudWidth.Value = originalImage.Width - (int)nudX.Value;
                };

                // Y ve Height değerlerini kontrol et
                nudY.Maximum = originalImage.Height - 1;
                nudHeight.Maximum = originalImage.Height;
                nudY.ValueChanged += (s, args) =>
                {
                    nudHeight.Maximum = originalImage.Height - (int)nudY.Value;
                    if (nudY.Value + nudHeight.Value > originalImage.Height)
                        nudHeight.Value = originalImage.Height - (int)nudY.Value;
                };

                cropDialog.Controls.AddRange(new Control[] { lblX, nudX, lblY, nudY, lblWidth, nudWidth, lblHeight, nudHeight, btnOK, btnCancel });
                cropDialog.AcceptButton = btnOK;
                cropDialog.CancelButton = btnCancel;

                if (cropDialog.ShowDialog(this) == DialogResult.OK)
                {
                    Rectangle cropArea = new Rectangle(
                        (int)nudX.Value,
                        (int)nudY.Value,
                        (int)nudWidth.Value,
                        (int)nudHeight.Value
                    );

                    processedImage = imageProcessor.Crop(originalImage, cropArea);
                    pictureBoxProcessed.Image = processedImage;
                    lblStatus.Text = $"Görüntü kırpıldı. Yeni boyut: {processedImage.Width}x{processedImage.Height}";
                }
            }
        }

        // Kırpma seçimini uygula (Enter tuşu veya çift tıklama ile)
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (isCropMode && keyData == Keys.Enter && cropRectangle.Width > 10 && cropRectangle.Height > 10)
            {
                ApplyCropFromSelection();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}

