using Lua;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hydrogen2D.Libraries
{
    internal class TypeBounds
    {
        public static LuaFunction Constructor()
        {
            return new LuaFunction((context, buffer, ct) =>
            {
                float x = context.GetArgument<float>(0);
                float y = context.GetArgument<float>(0);
                float width = context.GetArgument<float>(0);
                float height = context.GetArgument<float>(0);

                LuaTable t = new LuaTable();
                t["type"] = "bounds";

                t["x"] = x;
                t["y"] = y;
                t["width"] = width;
                t["height"] = height;

                buffer.Span[0] = t;

                return new(1);
            });
        }

        public static LuaFunction FromPoints()
        {
            return new LuaFunction((context, buffer, ct) =>
            {
                PointF topLeft = Helpers.LuaArgsHelper.GetPoint(context, 0);
                PointF bottomRight = Helpers.LuaArgsHelper.GetPoint(context, 1);

                LuaTable t = new LuaTable();
                t["type"] = "bounds";

                t["x"] = topLeft.X;
                t["y"] = topLeft.Y;
                t["width"] = bottomRight.X - topLeft.X;
                t["height"] = bottomRight.Y - topLeft.Y;

                buffer.Span[0] = t;

                return new(1);
            });
        }
    }
}
