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
        // note: finish the other functions (warn, info, confirm etc) then bind to env

        public static LuaFunction Error() // this function isnt even bound yet
        {
            return new LuaFunction((context, buffer, ct) =>
            {
                string msg = context.GetArgument<string>(0);
                string? title = context.GetArgument<string>(1); // using a ternary in display probably wont do anything since this line will throw an exception anyway

                MessageBox.Show(msg, title == null ? "Error" : title, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return new(0);
            });
        }
    }
}
