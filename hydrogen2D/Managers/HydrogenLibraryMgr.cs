using Lua;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hydrogen2D.Managers
{
    internal class HydrogenLibraryMgr
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
            state.Environment["font"].Read<LuaTable>()["fromFile"] = Libraries.TypeFont.FromFile();
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

        public static void IncludePopup(LuaState state)
        {
            state.Environment["popup"] = new LuaTable();
            state.Environment["popup"].Read<LuaTable>()["error"] = Libraries.Popup.Error();
            state.Environment["popup"].Read<LuaTable>()["warn"] = Libraries.Popup.Warn();
            state.Environment["popup"].Read<LuaTable>()["info"] = Libraries.Popup.Info();
            state.Environment["popup"].Read<LuaTable>()["message"] = Libraries.Popup.Message();
            state.Environment["popup"].Read<LuaTable>()["confirm"] = Libraries.Popup.Confirm();
        }

        // note: add a hydrogen library for cfg!
    }
}
