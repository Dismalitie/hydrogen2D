using Lua;

namespace hydrogen2D
{
    public partial class Form1 : Form
    {
        public string[] args;
        public string scenepath;
        public static LuaState state;
        public static Graphics g;

        public Form1(string[] arg)
        {
            InitializeComponent();

            args = arg;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // debug
            args = [".\\test.lua"];

            scenepath = args[0];
            state = LuaState.Create();
            g = canvas.CreateGraphics();

            Managers.HydrogenLibraryManager.IncludeDrawApi(state);
            Managers.HydrogenLibraryManager.IncludeTypeFont(state);
            Managers.HydrogenLibraryManager.IncludeTypeBrush(state);
            Managers.HydrogenLibraryManager.IncludeTypePoint(state);

            state.DoFileAsync(scenepath);
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g.FillRectangle(new SolidBrush(canvas.BackColor), ClientRectangle); // stops frames overlapping

            LuaFunctionExecutionContext lfec = new LuaFunctionExecutionContext
            {
                State = state,
                Thread = state.MainThread,
                FrameBase = 0,
                ArgumentCount = 0,
            };

            if (state.Environment["paint"].TryRead<LuaFunction>(out _))
            {
                state.Environment["paint"].Read<LuaFunction>().InvokeAsync(lfec, new Memory<LuaValue>(Array.Empty<LuaValue>()), CancellationToken.None);
            }
            else
            {
                g.DrawString("/!\\ No scene loaded!", new Font("Cascadia Code", 9), Brushes.Red, new PointF(10, 10));
            }
        }
    }
}