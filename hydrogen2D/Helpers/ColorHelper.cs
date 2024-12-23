using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hydrogen2D.Helpers
{
    internal class ColorHelper
    {
        // helps prevent argument errors when getting inputs from lua side by fitting them to a range
        // the user is unpredictable

        public static Color RangeSafeColor(int red, int green, int blue)
        {
            int r = Math.Max(0, Math.Min(255, red));
            int g = Math.Max(0, Math.Min(255, green));
            int b = Math.Max(0, Math.Min(255, blue));

            return Color.FromArgb(r, g, b);
        }

        public static Color RangeSafeColor(int red, int green, int blue, int alpha)
        {
            int r = Math.Max(0, Math.Min(255, red));
            int g = Math.Max(0, Math.Min(255, green));
            int b = Math.Max(0, Math.Min(255, blue));
            int a = Math.Max(0, Math.Min(255, alpha));

            return Color.FromArgb(a, r, g, b);
        }

        public static Color RangeSafeColor(float red, float green, float blue)
        {
            int r = (int)Math.Max(0, Math.Min(255, red));
            int g = (int)Math.Max(0, Math.Min(255, green));
            int b = (int)Math.Max(0, Math.Min(255, blue));

            return Color.FromArgb(r, g, b);
        }

        public static Color RangeSafeColor(float red, float green, float blue, float alpha)
        {
            int r = (int)Math.Max(0, Math.Min(255, red));
            int g = (int)Math.Max(0, Math.Min(255, green));
            int b = (int)Math.Max(0, Math.Min(255, blue));
            int a = (int)Math.Max(0, Math.Min(255, alpha));

            return Color.FromArgb(a, r, g, b);
        }
    }
}
