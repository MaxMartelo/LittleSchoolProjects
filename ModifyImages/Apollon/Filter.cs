using System;
using System.Drawing;

namespace Apollon
{
    public static class Filter
    {
        public static void ForEachPixel(this Bitmap image, Func<Color, Color> modify)
        {
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Color c = image.GetPixel(i, j);
                    image.SetPixel(i, j,modify(c));
                }
            }
        }
        
        public static void Invert(this Bitmap image)
        {
            ForEachPixel(image,Pixel.Invert);
        }

        public static void Grayscale(this Bitmap image)
        { 
            ForEachPixel(image, Pixel.Grayscale);
        }
        
        public static void Binarize(this Bitmap image)
        {
            ForEachPixel(image, Pixel.Binarize);
        }

        public static void Brightness(this Bitmap image, int delta)
        {
            Func<Color, Color> d = (color => Pixel.Brightness(color, delta));
            ForEachPixel(image, d);
        }

        public static void Contrast(this Bitmap image, int delta)
        {
            Func<Color, Color> d = (color => Pixel.Contrast(color, delta));
            ForEachPixel(image, d);
        }

        public static void RotateRight(this Bitmap image)
        {
            //Create a new empty bitmap to hold rotated image.
            //Bitmap newImage = new Bitmap(image.Width, image.Height);
            
            //Make a graphics object from the empty bitmap.
            // image.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            // Graphics g = Graphics.FromImage(image);
            
            //move rotation point to center of image.
            //g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            // g.TranslateTransform((float)image.Width / 2, (float)image.Height / 2);
            
            //Rotate.        
            // g.RotateTransform(90);
            
            //Move image back.
            // g.TranslateTransform(-(float)image.Width / 2, -(float)image.Height / 2);
            
            // g.DrawImage(image, 0,0,image.Width, image.Height);
            //g.DrawImage(image, new Point(0, 0));
            
            image.RotateFlip(RotateFlipType.Rotate90FlipNone);
        }
        
        public static void RotateLeft(this Bitmap image)
        {
            image.RotateFlip(RotateFlipType.Rotate270FlipNone);
        }
        
        public static void SymmetryX(this Bitmap image)
        {
            image.RotateFlip(RotateFlipType.RotateNoneFlipX);
        }
        
        public static void SymmetryY(this Bitmap image)
        {
            image.RotateFlip(RotateFlipType.RotateNoneFlipY);
        }

        public static void Cover(this Bitmap a, Bitmap b, int opacity = 50)
        {
            if(a.Width!=b.Width||a.Height!=b.Height)
                throw new NotImplementedException("a and b have to be of a same size");
            else
            {
                for (int i = 0; i < b.Width; i++)
                {
                    for (int j = 0; j < b.Height; j++)
                    {
                        Color c1 = a.GetPixel(i, j);
                         Color c2 = b.GetPixel(i, j);
                         a.SetPixel(i, j,Pixel.Cover(c1,c2));
                    }
                }
            }
        }
        
    }
}