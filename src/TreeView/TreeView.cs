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
            this.Name = System.AppDomain.CurrentDomain.BaseDirectory;

            this.ImageList = this.imageList;
         
            Root localRoot = new Root(Root.Type.Local);
            this.Nodes.Add(localRoot);

            eventHandler = new Event(this);
        }

        private Event eventHandler;

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
