using Lua;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hydrogen2D.Helpers
{
    internal class LuaArgsHelper
    {
        // simplifies stuff

        public static Font GetFont(LuaFunctionExecutionContext context, int index)
        {
            var table = context.GetArgument<LuaTable>(index);

            string type = table["type"].Read<string>();
            if (type != "font") throw new ArgumentException();

            string fontName = table["name"].Read<string>();
            float fontSize = table["size"].Read<float>();

            return new Font(fontName, fontSize);
        }

        public static Brush GetBrush(LuaFunctionExecutionContext context, int index)
        {
            var table = context.GetArgument<LuaTable>(index);

            string type = table["type"].Read<string>();
            if (type != "brush") throw new ArgumentException();

            string brushType = table["brushType"].Read<string>();
            if (brushType == "solid")
            {
                float r = table["r"].Read<float>();
                float g = table["g"].Read<float>();
                float b = table["b"].Read<float>();

                Color c = Helpers.ColorHelper.RangeSafeColor(r, g, b);

                return new SolidBrush(c);
            }
            else if (brushType == "gradient")
            {
                float p1x = table["point1"].Read<LuaTable>()["x"].Read<float>();
                float p1y = table["point1"].Read<LuaTable>()["y"].Read<float>();

                float p2x = table["point2"].Read<LuaTable>()["x"].Read<float>();
                float p2y = table["point2"].Read<LuaTable>()["y"].Read<float>();

                float r1 = table["color1"].Read<LuaTable>()["r"].Read<float>();
                float g1 = table["color1"].Read<LuaTable>()["g"].Read<float>();
                float b1 = table["color1"].Read<LuaTable>()["b"].Read<float>();

                float r2 = table["color2"].Read<LuaTable>()["r"].Read<float>();
                float g2 = table["color2"].Read<LuaTable>()["g"].Read<float>();
                float b2 = table["color2"].Read<LuaTable>()["b"].Read<float>();

                return new LinearGradientBrush(new PointF(p1x, p1y), new PointF(p2x, p2y), Helpers.ColorHelper.RangeSafeColor(r1, g1, b1), Helpers.ColorHelper.RangeSafeColor(r2, g2, b2));
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public static PointF GetPoint(LuaFunctionExecutionContext context, int index)
        {
            var table = context.GetArgument<LuaTable>(index);

            string type = table["type"].Read<string>();
            if (type != "point") throw new ArgumentException();

            float x = table["x"].Read<float>();
            float y = table["y"].Read<float>();

            return new PointF(x, y);
        }

        public static Color GetColor(LuaFunctionExecutionContext context, int index)
        {
            var table = context.GetArgument<LuaTable>(index);

            string type = table["type"].Read<string>();
            if (type != "color") throw new ArgumentException();

            float r = table["r"].Read<float>();
            float g = table["g"].Read<float>();
            float b = table["b"].Read<float>();

            return Helpers.ColorHelper.RangeSafeColor(r, g, b);
        }
    }
}
