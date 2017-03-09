namespace Mhanxx
{
    public partial class TreeView : System.Windows.Forms.TreeView
    {
        public TreeView()
        {
            InitializeComponent();
            InitializeObject();
        }

        public TreeView(System.ComponentModel.IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            InitializeObject();
        }

        private void InitializeObject()
        {
            //
            // Add ImageList
            //
            this.ImageList = this.imageList;

            //
            // Create directory if not exist
            //
            string dataDir = System.IO.Directory.GetCurrentDirectory() + @"\Project";
            System.IO.Directory.CreateDirectory(dataDir);

            //
            // Root of local repository
            //
            System.Windows.Forms.TreeNode node = new System.Windows.Forms.TreeNode();

            node.Name = dataDir;
            node.Text = "Local Project";

            node.ImageKey = "localServer";
            node.SelectedImageKey = "localServer";
            node.StateImageKey = "localServer";

            this.Nodes.Add(node);

            //
            // Register event
            //
            Event.Register(this);

            //
            // Add project if exist
            //
            foreach (string path in System.IO.Directory.GetDirectories(node.Name))
            {
                node.Nodes.Add(@"<\>");
                node.Expand();
            }

            //
            // Watch for project
            //
            FileSystemWatcher watcher = new FileSystemWatcher(node);
            watcher.EnableRaisingEvents = true;
        }

        protected override void OnHandleCreated(System.EventArgs e)
        {
            const int TVM_SETEXTENDEDSTYLE = 0x1100 + 44;
            const int TVS_EX_DOUBLEBUFFER = 0x0004;

            SendMessage(this.Handle, TVM_SETEXTENDEDSTYLE, (System.IntPtr)TVS_EX_DOUBLEBUFFER, (System.IntPtr)TVS_EX_DOUBLEBUFFER);
            base.OnHandleCreated(e);
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern System.IntPtr SendMessage(System.IntPtr hWnd, int msg, System.IntPtr wp, System.IntPtr lp);
    }
}
