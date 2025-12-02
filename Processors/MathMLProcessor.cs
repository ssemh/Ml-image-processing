using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Microsoft.ML;
using Microsoft.ML.Data;

namespace MLImageProcessing.Processors
{
    public class MLResult
    {
        public Bitmap? ProcessedImage { get; set; }
        public double AverageBrightness { get; set; }
        public double StandardDeviation { get; set; }
        public double Entropy { get; set; }
        public double ContrastScore { get; set; }
        public string PredictedClass { get; set; } = string.Empty;
    }

    public class ImageFeatures
    {
        [LoadColumn(0)]
        public float AverageBrightness { get; set; }

        [LoadColumn(1)]
        public float StandardDeviation { get; set; }

        [LoadColumn(2)]
        public float Entropy { get; set; }

        [LoadColumn(3)]
        public float ContrastScore { get; set; }

        [LoadColumn(4)]
        public string Label { get; set; } = string.Empty;
    }

    public class ImagePrediction
    {
        [ColumnName("PredictedLabel")]
        public string PredictedClass { get; set; } = string.Empty;

        public float[]? Score { get; set; }
    }

    public class MathMLProcessor
    {
        private MLContext mlContext;
        private ITransformer? model;
        private bool isModelTrained;

        public MathMLProcessor()
        {
            mlContext = new MLContext(seed: 0);
            isModelTrained = false;
        }

        public MLResult ProcessImageWithML(Bitmap image)
        {
            // Görüntü özelliklerini hesapla
            var features = CalculateImageFeatures(image);
            
            // ML modeli ile tahmin yap
            string predictedClass = PredictImageClass(features);
            
            // İşlenmiş görüntü oluştur (özellik vurgulama ile)
            Bitmap processedImage = CreateEnhancedImage(image, features);
            
            return new MLResult
            {
                ProcessedImage = processedImage,
                AverageBrightness = features.AverageBrightness,
                StandardDeviation = features.StandardDeviation,
                Entropy = features.Entropy,
                ContrastScore = features.ContrastScore,
                PredictedClass = predictedClass
            };
        }

        private ImageFeatures CalculateImageFeatures(Bitmap image)
        {
            List<int> brightnessValues = new List<int>();
            Dictionary<int, int> histogram = new Dictionary<int, int>();
            
            // Görüntüyü gri tonlamaya çevir ve histogram oluştur
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixel = image.GetPixel(x, y);
                    int gray = (int)(pixel.R * 0.299 + pixel.G * 0.587 + pixel.B * 0.114);
                    brightnessValues.Add(gray);
                    
                    if (!histogram.ContainsKey(gray))
                        histogram[gray] = 0;
                    histogram[gray]++;
                }
            }
            
            // Ortalama parlaklık
            float avgBrightness = (float)brightnessValues.Average();
            
            // Standart sapma
            float variance = brightnessValues.Sum(b => (float)Math.Pow(b - avgBrightness, 2)) / brightnessValues.Count;
            float stdDev = (float)Math.Sqrt(variance);
            
            // Entropi hesaplama
            float entropy = 0;
            int totalPixels = image.Width * image.Height;
            foreach (var kvp in histogram)
            {
                float probability = (float)kvp.Value / totalPixels;
                if (probability > 0)
                    entropy -= probability * (float)Math.Log2(probability);
            }
            
            // Kontrast skoru (standart sapma tabanlı)
            float contrastScore = stdDev / 255f;
            
            return new ImageFeatures
            {
                AverageBrightness = avgBrightness,
                StandardDeviation = stdDev,
                Entropy = entropy,
                ContrastScore = contrastScore,
                Label = ""
            };
        }

        private string PredictImageClass(ImageFeatures features)
        {
            // Basit bir kural tabanlı sınıflandırma
            // Gerçek bir ML modeli için eğitim verisi gerekir
            
            if (!isModelTrained)
            {
                // Basit kural tabanlı tahmin
                if (features.AverageBrightness < 85)
                    return "Koyu";
                else if (features.AverageBrightness > 170)
                    return "Aydınlık";
                else if (features.ContrastScore > 0.3)
                    return "Yüksek Kontrast";
                else if (features.Entropy > 7)
                    return "Yüksek Detay";
                else
                    return "Normal";
            }
            else
            {
                // Eğitilmiş model kullanılabilir
                var predictionEngine = mlContext.Model.CreatePredictionEngine<ImageFeatures, ImagePrediction>(model);
                var prediction = predictionEngine.Predict(features);
                return prediction.PredictedClass;
            }
        }

        private Bitmap CreateEnhancedImage(Bitmap original, ImageFeatures features)
        {
            Bitmap enhanced = new Bitmap(original.Width, original.Height);
            
            // Özelliklere göre görüntüyü geliştir
            // Kontrast skoruna göre kontrast artır
            float contrastMultiplier = 1.0f + (features.ContrastScore * 0.5f);
            
            for (int x = 0; x < original.Width; x++)
            {
                for (int y = 0; y < original.Height; y++)
                {
                    Color pixel = original.GetPixel(x, y);
                    
                    // Kontrast artırma
                    int r = (int)Math.Min(255, Math.Max(0, (pixel.R - 128) * contrastMultiplier + 128));
                    int g = (int)Math.Min(255, Math.Max(0, (pixel.G - 128) * contrastMultiplier + 128));
                    int b = (int)Math.Min(255, Math.Max(0, (pixel.B - 128) * contrastMultiplier + 128));
                    
                    enhanced.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
            
            return enhanced;
        }

        public void TrainModel(List<ImageFeatures> trainingData)
        {
            if (trainingData == null || trainingData.Count == 0)
                return;
            
            var dataView = mlContext.Data.LoadFromEnumerable(trainingData);
            
            var pipeline = mlContext.Transforms.Conversion.MapValueToKey("Label")
                .Append(mlContext.Transforms.Concatenate("Features", 
                    nameof(ImageFeatures.AverageBrightness),
                    nameof(ImageFeatures.StandardDeviation),
                    nameof(ImageFeatures.Entropy),
                    nameof(ImageFeatures.ContrastScore)))
                .Append(mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy())
                .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));
            
            model = pipeline.Fit(dataView);
            isModelTrained = true;
        }
    }
}

