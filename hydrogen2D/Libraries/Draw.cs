using Lua;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hydrogen2D.Libraries
{
    internal class Draw
    {
        public static LuaFunction DrawString() // WOW! one function, almost finished the engine!
        {
            return new LuaFunction((context, buffer, ct) =>
            {
                string text = context.GetArgument<string>(0);
                Font font = Helpers.LuaArgsHelper.GetFont(context, 1);
                Brush brush = Helpers.LuaArgsHelper.GetBrush(context, 2);
                PointF location = Helpers.LuaArgsHelper.GetPoint(context, 3);

                Form1.g.DrawString(text, font, brush, location);

                return new(0);
            });
        }
    }
}
