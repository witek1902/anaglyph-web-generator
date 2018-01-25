using System.Drawing;

namespace AnaglyphGenerator.Models
{
    public class GrayAnaglyph : IAnaglyph
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
                    r =
                        (int)
                            (leftImage.GetPixel(x, y).R * 0.299 + leftImage.GetPixel(x, y).G * 0.587 +
                             leftImage.GetPixel(x, y).B * 0.114);
                    g =
                        (int)
                            (rightImage.GetPixel(x, y).R * 0.299 + rightImage.GetPixel(x, y).G * 0.587 +
                             rightImage.GetPixel(x, y).B * 0.114);
                    b = g;

                    Color c = Color.FromArgb(r, g, b);
                    outputImage.SetPixel(x, y, c);
                }
            }

            return outputImage;
        }
    }
}