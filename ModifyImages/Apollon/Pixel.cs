using System;
using System.Drawing;

namespace Apollon
{
    public static class Pixel
    { 
        public static Color Invert(this Color color)
        {
            // 255 - the nb 
            int r = 255 - color.R;
            int g = 255 - color.G;
            int b = 255 - color.B;
            
            Color newColor = Color.FromArgb(r, g, b);
            return newColor;
        }

        public static Color Grayscale(this Color color)
        {
            
            double r = 0.21 * color.R; // r, g and b have to be equal to be gray 
            double g = 0.72 * color.G;
            double b = 0.07 * color.B;
            int res = (int) (r + g + b);
            
            Color newColor = Color.FromArgb(res, res, res);
            return newColor;
        }

        public static Color Binarize(this Color color)
        {
            double r = 0.21 * color.R; 
            double g = 0.72 * color.G;
            double b = 0.07 * color.B;
            int res = (int) (r + g + b);
            Color binarizedColor = Color.Black;
            
            if (res < 128)
                binarizedColor = Color.White;
            
            return binarizedColor;
        }

        public static Color Brightness(this Color color, int delta)
        {
            int r = color.R + delta; // adding delta
            r = Restrict256(r); // checking if the new number is correct, if not choose 0 or 255
            
            int g = color.G + delta;
            g = Restrict256(g);
            
            int b = color.B + delta;
            b = Restrict256(b);
            
            Color newColor = Color.FromArgb(r, g, b);
            return newColor;
        }

        private static int Restrict256(int n)
        {
            if (n > 255)
                return 255;
            else if (n < 0)
                return 0;
            else return n;
        }

        public static int Restrict256(double n)
        {
            if (n > 255)
                return 255;
            else if (n < 0)
                return 0;
            else 
                return (int)n;
        }

        public static Color Contrast(this Color color, int delta)
        {
            int f = ((259 * (delta + 255)) / (255 * (259 - delta)));
            
            int r = f * (color.R - 128) +128; // adding delta
            r = Restrict256(r); // checking if the new number is correct, if not choose 0 or 255
            
            int g = f * (color.G - 128) +128;
            g = Restrict256(g);
            
            int b = f * (color.B - 128) +128;
            b = Restrict256(b);
            
            Color newColor = Color.FromArgb(r, g, b);
            return newColor;
        }


        public static Color Cover(this Color a, Color b, int opacity = 50)
        {
            if (opacity < 0)
                opacity = 0;
            else if (opacity > 100)
                opacity = 100;

            int resR = (a.R * (100 - opacity) + b.R * opacity)/100;
            int resG = (a.G * (100 - opacity) + b.G * opacity)/100;
            int resB = (a.B * (100 - opacity) + b.B * opacity)/100;
        
            Color newColor = Color.FromArgb( resR, resG, resB);
            return newColor;
        }
    }
}