using System.Drawing;

namespace AnaglyphGenerator.Models
{
    public class HalfColorAnaglyph : IAnaglyph
    {
        public Bitmap Calc(Bitmap leftImage, Bitmap rightImage)
        {
            int width = leftImage.Width;
            int height = leftImage.Height;

            int r, g, b;

            Bitmap outputImage = new Bitmap(width, height);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    r = (int) (leftImage.GetPixel(x, y).G * 0.7 + leftImage.GetPixel(x, y).B * 0.3);
                    g = rightImage.GetPixel(x, y).G;
                    b = rightImage.GetPixel(x, y).B;

                    Color c = Color.FromArgb(r, g, b);
                    outputImage.SetPixel(x, y, c);
                }
            }
            return outputImage;
        }
    }
}