using Lua;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hydrogen2D.Libraries
{
    internal class TypePoint
    {
        public static LuaFunction Constructor()
        {
            return new LuaFunction((context, buffer, ct) =>
            {
                float x = context.GetArgument<float>(0);
                float y = context.GetArgument<float>(1);

                LuaTable t = new LuaTable();
                t["type"] = "point";

                t["x"] = x;
                t["y"] = y;

                buffer.Span[0] = t;

                return new(1);
            });
        }

        // note: should probably add some helper functions for adding points or smth
    }
}
