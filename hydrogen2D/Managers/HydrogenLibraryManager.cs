using Lua;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hydrogen2D.Managers
{
    internal class HydrogenLibraryManager
    {
        // simplifies stuff so much when injecting libs in env

        public static void IncludeDrawApi(LuaState state)
        {
            state.Environment["draw"] = new LuaTable();
            state.Environment["draw"].Read<LuaTable>()["drawText"] = Libraries.Draw.DrawString();
        }

        public static void IncludeTypeFont(LuaState state)
        {
            state.Environment["font"] = new LuaTable();
            state.Environment["font"].Read<LuaTable>()["new"] = Libraries.TypeFont.Constructor();
            state.Environment["font"].Read<LuaTable>()["defaultFont"] = Libraries.TypeFont.DefaultFont();
        }

        public static void IncludeTypeBrush(LuaState state)
        {
            state.Environment["brush"] = new LuaTable();
            state.Environment["brush"].Read<LuaTable>()["new"] = Libraries.TypeBrush.Constructor();
        }

        public static void IncludeTypePoint(LuaState state)
        {
            state.Environment["point"] = new LuaTable();
            state.Environment["point"].Read<LuaTable>()["new"] = Libraries.TypePoint.Constructor();
        }

        public static void IncludeTypeBounds(LuaState state)
        {
            state.Environment["bounds"] = new LuaTable();
            state.Environment["bounds"].Read<LuaTable>()["new"] = Libraries.TypeBounds.Constructor();
            state.Environment["bounds"].Read<LuaTable>()["fromPoints"] = Libraries.TypeBounds.FromPoints();
        }

        // note: add a hydrogen library for cfg!
    }
}
