using System.Drawing;

namespace AnaglyphGenerator.Models
{
    interface IAnaglyph
    {
        Bitmap Calc(Bitmap leftImage, Bitmap rightImage);

    }
}
