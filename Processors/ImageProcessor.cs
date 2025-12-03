using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace MLImageProcessing.Processors
{
    public class ImageProcessor
    {
        public Bitmap ConvertToGrayscale(Bitmap original)
        {
            Bitmap grayscale = new Bitmap(original.Width, original.Height);
            
            for (int x = 0; x < original.Width; x++)
            {
                for (int y = 0; y < original.Height; y++)
                {
                    Color pixel = original.GetPixel(x, y);
                    int gray = (int)(pixel.R * 0.299 + pixel.G * 0.587 + pixel.B * 0.114);
                    grayscale.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            }
            
            return grayscale;
        }

        public Bitmap DetectEdges(Bitmap original)
        {
            Bitmap grayscale = ConvertToGrayscale(original);
            Bitmap edges = new Bitmap(grayscale.Width, grayscale.Height);
            
            // Sobel operatörü kullanarak kenar tespiti
            int[,] sobelX = { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
            int[,] sobelY = { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };
            
            for (int x = 1; x < grayscale.Width - 1; x++)
            {
                for (int y = 1; y < grayscale.Height - 1; y++)
                {
                    int gx = 0, gy = 0;
                    
                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            Color pixel = grayscale.GetPixel(x + i, y + j);
                            int gray = pixel.R;
                            gx += gray * sobelX[i + 1, j + 1];
                            gy += gray * sobelY[i + 1, j + 1];
                        }
                    }
                    
                    int magnitude = (int)Math.Sqrt(gx * gx + gy * gy);
                    magnitude = Math.Min(255, Math.Max(0, magnitude));
                    edges.SetPixel(x, y, Color.FromArgb(magnitude, magnitude, magnitude));
                }
            }
            
            return edges;
        }

        public Bitmap ApplyBlur(Bitmap original, int radius)
        {
            if (radius < 1) radius = 1;
            if (radius > 20) radius = 20;
            
            Bitmap blurred = new Bitmap(original.Width, original.Height);
            
            // LockBits kullanarak daha hızlı piksel erişimi
            Rectangle rect = new Rectangle(0, 0, original.Width, original.Height);
            BitmapData originalData = original.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData blurredData = blurred.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            
            unsafe
            {
                byte* originalPtr = (byte*)originalData.Scan0;
                byte* blurredPtr = (byte*)blurredData.Scan0;
                int stride = originalData.Stride;
                
                for (int y = 0; y < original.Height; y++)
                {
                    for (int x = 0; x < original.Width; x++)
                    {
                        long r = 0, g = 0, b = 0;
                        int count = 0;
                        
                        // Box blur - komşu piksellerin ortalamasını al
                        for (int i = -radius; i <= radius; i++)
                        {
                            for (int j = -radius; j <= radius; j++)
                            {
                                int nx = x + i;
                                int ny = y + j;
                                
                                if (nx >= 0 && nx < original.Width && ny >= 0 && ny < original.Height)
                                {
                                    byte* pixelPtr = originalPtr + (ny * stride) + (nx * 4);
                                    b += pixelPtr[0]; // B
                                    g += pixelPtr[1]; // G
                                    r += pixelPtr[2]; // R
                                    count++;
                                }
                            }
                        }
                        
                        if (count > 0)
                        {
                            byte* outputPtr = blurredPtr + (y * stride) + (x * 4);
                            outputPtr[0] = (byte)(b / count); // B
                            outputPtr[1] = (byte)(g / count); // G
                            outputPtr[2] = (byte)(r / count); // R
                            outputPtr[3] = 255; // A
                        }
                    }
                }
            }
            
            original.UnlockBits(originalData);
            blurred.UnlockBits(blurredData);
            
            return blurred;
        }

        public Bitmap ApplySharpen(Bitmap original)
        {
            Bitmap sharpened = new Bitmap(original.Width, original.Height);
            
            // Keskinleştirme kernel'i
            int[,] kernel = { { 0, -1, 0 }, { -1, 5, -1 }, { 0, -1, 0 } };
            
            for (int x = 1; x < original.Width - 1; x++)
            {
                for (int y = 1; y < original.Height - 1; y++)
                {
                    int r = 0, g = 0, b = 0;
                    
                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            Color pixel = original.GetPixel(x + i, y + j);
                            int weight = kernel[i + 1, j + 1];
                            r += pixel.R * weight;
                            g += pixel.G * weight;
                            b += pixel.B * weight;
                        }
                    }
                    
                    r = Math.Min(255, Math.Max(0, r));
                    g = Math.Min(255, Math.Max(0, g));
                    b = Math.Min(255, Math.Max(0, b));
                    
                    sharpened.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
            
            // Kenarları kopyala
            for (int x = 0; x < original.Width; x++)
            {
                sharpened.SetPixel(x, 0, original.GetPixel(x, 0));
                sharpened.SetPixel(x, original.Height - 1, original.GetPixel(x, original.Height - 1));
            }
            for (int y = 0; y < original.Height; y++)
            {
                sharpened.SetPixel(0, y, original.GetPixel(0, y));
                sharpened.SetPixel(original.Width - 1, y, original.GetPixel(original.Width - 1, y));
            }
            
            return sharpened;
        }

        public Bitmap AdjustBrightness(Bitmap original, int brightness)
        {
            Bitmap adjusted = new Bitmap(original.Width, original.Height);
            
            for (int x = 0; x < original.Width; x++)
            {
                for (int y = 0; y < original.Height; y++)
                {
                    Color pixel = original.GetPixel(x, y);
                    int r = Math.Min(255, Math.Max(0, pixel.R + brightness));
                    int g = Math.Min(255, Math.Max(0, pixel.G + brightness));
                    int b = Math.Min(255, Math.Max(0, pixel.B + brightness));
                    adjusted.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
            
            return adjusted;
        }

        public Bitmap AdjustContrast(Bitmap original, float contrast)
        {
            Bitmap adjusted = new Bitmap(original.Width, original.Height);
            float factor = (259f * (contrast + 1f)) / (259f - contrast);
            
            for (int x = 0; x < original.Width; x++)
            {
                for (int y = 0; y < original.Height; y++)
                {
                    Color pixel = original.GetPixel(x, y);
                    int r = (int)Math.Min(255, Math.Max(0, factor * (pixel.R - 128) + 128));
                    int g = (int)Math.Min(255, Math.Max(0, factor * (pixel.G - 128) + 128));
                    int b = (int)Math.Min(255, Math.Max(0, factor * (pixel.B - 128) + 128));
                    adjusted.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
            
            return adjusted;
        }
    }
}


