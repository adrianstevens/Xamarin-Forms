using Xamarin.Forms;

namespace Utilities
{
    public static class XFUtilities
    {
        public static Color GetColorFromInt(int value)
        {
            double r = (byte)(value >> 16);
            double g = (byte)(value >> 8);
            double b = (byte)(value >> 0);

            return new Color(r / 255.0, g / 255.0, b / 255.0);
        }
    }
}
