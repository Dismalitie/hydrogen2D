using Lua;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hydrogen2D.Libraries
{
    internal class Popup
    {
        public static LuaFunction Error()
        {
            return new LuaFunction((context, buffer, ct) =>
            {
                string msg = context.GetArgument<string>(0);
                string title = "Error";
                if (context.Arguments.Length == 2) title = context.GetArgument<string>(1);

                MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return new(0);
            });
        }

        public static LuaFunction Warn()
        {
            return new LuaFunction((context, buffer, ct) =>
            {
                string msg = context.GetArgument<string>(0);
                string title = "Warn";
                if (context.Arguments.Length == 2) title = context.GetArgument<string>(1);

                MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return new(0);
            });
        }

        public static LuaFunction Info()
        {
            return new LuaFunction((context, buffer, ct) =>
            {
                string msg = context.GetArgument<string>(0);
                string title = "Info";
                if (context.Arguments.Length == 2) title = context.GetArgument<string>(1);

                MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);

                return new(0);
            });
        }

        public static LuaFunction Confirm()
        {
            return new LuaFunction((context, buffer, ct) =>
            {
                string msg = context.GetArgument<string>(0);
                string title = "Confirmation";
                if (context.Arguments.Length == 2) title = context.GetArgument<string>(1);

                buffer.Span[0] = MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString().ToLower();

                return new(1);
            });
        }

        public static LuaFunction Message()
        {
            return new LuaFunction((context, buffer, ct) =>
            {
                string msg = context.GetArgument<string>(0);
                string title = "Message";
                if (context.Arguments.Length == 2) title = context.GetArgument<string>(1);

                MessageBox.Show(msg, title, MessageBoxButtons.OK);

                return new(0);
            });
        }
    }
}
