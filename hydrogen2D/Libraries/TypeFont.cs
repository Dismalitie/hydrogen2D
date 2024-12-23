using Lua;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace hydrogen2D.Libraries
{
    internal class TypeFont
    {
        public static LuaFunction Constructor()
        {
            return new LuaFunction((context, buffer, ct) =>
            {
                string name = context.GetArgument<string>(0);
                float size = context.GetArgument<float>(1);

                LuaTable t = new LuaTable();
                t["type"] = "font";
                t["fontType"] = "system";

                t["name"] = name;
                t["size"] = size;

                buffer.Span[0] = t;

                return new(1);
            });
        }

        public static LuaTable DefaultFont()
        {
            LuaTable t = new LuaTable();
            t["type"] = "font";
            t["fontType"] = "system";

            t["name"] = Form1. DefaultFont.Name;
            t["size"] = Form1.DefaultFont.Size;

            return t;
        }

        public static LuaFunction FromFile()
        {
            return new LuaFunction((context, buffer, ct) =>
            {
                string path = context.GetArgument<string>(0);
                string size = context.GetArgument<string>(0);

                LuaTable t = new LuaTable();
                t["type"] = "font";
                t["fontType"] = "file";

                t["path"] = path;
                t["size"] = size;
                t["name"] = Helpers.LuaArgsHelper.GetFont(context, t).Name; // should be fine considering the file part of the helper doesnt require the "name" param

                buffer.Span[0] = t;

                return new(1);
            });
        }
    }
}
