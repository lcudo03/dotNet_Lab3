using System;
using System.Drawing;

namespace DotNetLab3_ImgFilters
{
    public static class ImageProcessor
    {
        public static Bitmap ToGrayScale(Bitmap source)
        {
            Bitmap result = new Bitmap(source.Width, source.Height);

            for (int y = 0; y < source.Height; y++)
            {
                for (int x = 0; x < source.Width; x++)
                {
                    Color pixel = source.GetPixel(x, y);

                    int gray = (pixel.R + pixel.G + pixel.B) / 3;

                    Color newColor = Color.FromArgb(gray, gray, gray);
                    result.SetPixel(x, y, newColor);
                }
            }

            return result;
        }

        public static Bitmap ToNegative(Bitmap source)
        {
            Bitmap result = new Bitmap(source.Width, source.Height);

            for (int y = 0; y < source.Height; y++)
            {
                for (int x = 0; x < source.Width; x++)
                {
                    Color pixel = source.GetPixel(x, y);

                    int r = 255 - pixel.R;
                    int g = 255 - pixel.G;
                    int b = 255 - pixel.B;

                    Color newColor = Color.FromArgb(r, g, b);
                    result.SetPixel(x, y, newColor);
                }
            }

            return result;
        }

        public static Bitmap Threshold(Bitmap source)
        {
            Bitmap result = new Bitmap(source.Width, source.Height);

            for (int y = 0; y < source.Height; y++)
            {
                for (int x = 0; x < source.Width; x++)
                {
                    Color pixel = source.GetPixel(x, y);

                    int brightness = (pixel.R + pixel.G + pixel.B) / 3;

                    Color newColor;

                    if (brightness > 128)
                        newColor = Color.White;
                    else
                        newColor = Color.Black;

                    result.SetPixel(x, y, newColor);
                }
            }

            return result;
        }

        public static Bitmap Mirror(Bitmap source)
        {
            Bitmap result = new Bitmap(source.Width, source.Height);

            for (int y = 0; y < source.Height; y++)
            {
                for (int x = 0; x < source.Width; x++)
                {
                    Color pixel = source.GetPixel(x, y);

                    int newX = source.Width - 1 - x;

                    result.SetPixel(newX, y, pixel);
                }
            }

            return result;
        }
    }
}   