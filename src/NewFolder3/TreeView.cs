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
            // Create src directory as root of directory
            string dataDir = System.IO.Directory.GetCurrentDirectory() + @"\Project\Default";
            System.IO.Directory.CreateDirectory(dataDir);

            // Root of local repository
            System.Windows.Forms.TreeNode node = new System.Windows.Forms.TreeNode();

            node.Name = dataDir;
            node.Text = "Default Project";

            node.ImageKey = "LocalFolder";
            node.SelectedImageKey = "LocalFolder";
            node.StateImageKey = "LocalFolder";

            node.Nodes.Add("");
            node.Expand();

            this.Nodes.Add(node);

            Project Default = new Project("Default");
            Event.Register(this);
        }
    }
}
