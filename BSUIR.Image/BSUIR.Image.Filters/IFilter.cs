using System.Drawing;

namespace BSUIR.Image.Filters
{
    public interface IFilter
    {
        Bitmap Filter(Bitmap image);
    }
}
