using Lua;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hydrogen2D.Libraries
{
    internal class TypeBrush
    {
        public static LuaFunction Constructor()
        {
            return new LuaFunction((context, buffer, ct) =>
            {
                LuaTable t = new LuaTable();

                string brushType = context.GetArgument<string>(0);
                if (brushType == "solid")
                {
                    float r = context.GetArgument<float>(1);
                    float g = context.GetArgument<float>(2);
                    float b = context.GetArgument<float>(3);

                    t["type"] = "brush";
                    t["brushType"] = "solid";

                    t["r"] = r;
                    t["g"] = g;
                    t["b"] = b;
                }
                else if (brushType == "gradient")
                {
                    float p1x = context.GetArgument<float>(1);
                    float p1y = context.GetArgument<float>(2);

                    float p2x = context.GetArgument<float>(3);
                    float p2y = context.GetArgument<float>(4);

                    float r1 = context.GetArgument<float>(5);
                    float g1 = context.GetArgument<float>(6);
                    float b1 = context.GetArgument<float>(7);

                    float r2 = context.GetArgument<float>(8);
                    float g2 = context.GetArgument<float>(9);
                    float b2 = context.GetArgument<float>(10);

                    // originally used an array, but that was quite user-inaccessible and also had 11 indexes

                    t["type"] = "brush";
                    t["brushType"] = "gradient";

                    t["point1"] = new LuaTable();
                    t["point1"].Read<LuaTable>()["x"] = p1x;
                    t["point1"].Read<LuaTable>()["y"] = p1y;

                    t["point2"] = new LuaTable();
                    t["point2"].Read<LuaTable>()["x"] = p2x;
                    t["point2"].Read<LuaTable>()["y"] = p2y;

                    t["color1"] = new LuaTable();
                    t["color1"].Read<LuaTable>()["r"] = r1;
                    t["color1"].Read<LuaTable>()["g"] = g1;
                    t["color1"].Read<LuaTable>()["b"] = b1;

                    t["color2"] = new LuaTable();
                    t["color2"].Read<LuaTable>()["r"] = r2;
                    t["color2"].Read<LuaTable>()["g"] = g2;
                    t["color2"].Read<LuaTable>()["b"] = b2;
                }
                else
                {
                    throw new ArgumentException();
                }

                buffer.Span[0] = t;

                return new(1);
            });
        }
    }
}
