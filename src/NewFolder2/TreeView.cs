namespace Mhanxx
{
    public partial class TreeView : System.Windows.Forms.TreeView
    {
        public TreeView()
        {
            InitializeComponent();

            // Create src directory as root of directory
            string dataDir = System.IO.Directory.GetCurrentDirectory() + @"\Project";
            System.IO.Directory.CreateDirectory(dataDir);

            // Root of local repository
            System.Windows.Forms.TreeNode node = new System.Windows.Forms.TreeNode();

            node.Name = dataDir;
            node.Text = "Local Project";

            node.ImageKey = "LocalFolder";
            node.SelectedImageKey = "LocalFolder";
            node.StateImageKey = "LocalFolder";

            node.Nodes.Add("");
            node.Expand();

            this.Nodes.Add(node);

            Project Default = new Project("Default");

            Event.Register(this);
        }

        /// <summary>
        ///     Disable flickering, please don't touch the code below
        ///     http://stackoverflow.com/a/10364283/5303710
        /// </summary>
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern System.IntPtr SendMessage(System.IntPtr hWnd, int msg, System.IntPtr wp, System.IntPtr lp);
        private const int TVM_SETEXTENDEDSTYLE = 0x1100 + 44;
        private const int TVM_GETEXTENDEDSTYLE = 0x1100 + 45;
        private const int TVS_EX_DOUBLEBUFFER = 0x0004;
        protected override void OnHandleCreated(System.EventArgs e)
        {
            SendMessage(this.Handle, TVM_SETEXTENDEDSTYLE, (System.IntPtr)TVS_EX_DOUBLEBUFFER, (System.IntPtr)TVS_EX_DOUBLEBUFFER);
            base.OnHandleCreated(e);
        }
    }
}
