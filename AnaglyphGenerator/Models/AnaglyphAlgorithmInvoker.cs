using AnaglyphGenerator.Models;
using System.Drawing;

namespace AnaglyphGenerator.Models
{
    public class AnaglyphAlgorithmInvoker
    {
        private IAnaglyph algorithm;

        /**
         * FIXME: used DI instead this switch
         */
        public AnaglyphAlgorithmInvoker(string kindOfAlgorithm)
        {
            switch (kindOfAlgorithm)
            {
                case "True Anaglyph":
                    algorithm = new TrueAnaglyph();
                    break;
                case "Gray Anaglyph":
                    algorithm = new GrayAnaglyph();
                    break;
                case "Color Anaglyph":
                    algorithm = new ColorAnaglyph();
                    break;
                case "Half-color Anaglyph":
                    algorithm = new HalfColorAnaglyph();
                    break;
                case "Optimized Anaglyph":
                default:
                    algorithm = new OptimizedAnaglyph();
                    break;
            }
        }

        public Bitmap Apply(Bitmap leftImage, Bitmap rightImage)
        {
            return algorithm.Calc(leftImage, rightImage);
        }

    }
}