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

        public MainForm()
        {
            InitializeComponent();
            imageProcessor = new ImageProcessor();
            mathMLProcessor = new MathMLProcessor();
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
                        originalImage = new Bitmap(openFileDialog.FileName);
                        pictureBoxOriginal.Image = originalImage;
                        pictureBoxProcessed.Image = null;
                        processedImage = null;
                        lblStatus.Text = "Görüntü yüklendi: " + Path.GetFileName(openFileDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Görüntü yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnGrayscale_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
            {
                MessageBox.Show("Lütfen önce bir görüntü yükleyin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            processedImage = imageProcessor.ConvertToGrayscale(originalImage);
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

            processedImage = imageProcessor.DetectEdges(originalImage);
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

            int blurRadius = (int)nudBlurRadius.Value;
            processedImage = imageProcessor.ApplyBlur(originalImage, blurRadius);
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

            processedImage = imageProcessor.ApplySharpen(originalImage);
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
                decimal brightnessValue = nudBrightness.Value;
                // Değeri Int32 aralığına sınırla
                if (brightnessValue > int.MaxValue)
                    brightnessValue = int.MaxValue;
                else if (brightnessValue < int.MinValue)
                    brightnessValue = int.MinValue;

                int brightness = (int)brightnessValue;
                processedImage = imageProcessor.AdjustBrightness(originalImage, brightness);
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

            float contrast = (float)nudContrast.Value;
            processedImage = imageProcessor.AdjustContrast(originalImage, contrast);
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

                var result = mathMLProcessor.ProcessImageWithML(originalImage);
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
            if (pictureBoxProcessed != null)
                pictureBoxProcessed.Image = null;
            processedImage = null;
            if (txtMLResults != null)
                txtMLResults.Clear();
            lblStatus.Text = "İşlemler sıfırlandı.";
        }
    }
}

