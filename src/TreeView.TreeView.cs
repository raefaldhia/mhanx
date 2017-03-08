namespace Mhanxx
{
    public partial class TreeViewControl : System.Windows.Forms.UserControl
    {
        static private partial class TreeView
        {
            static private TreeViewControl treeviewControl;

            static public void InitializeComponent(TreeViewControl control)
            {
                try
                {
                    treeviewControl = control;
                    
                    // ContextMenuStrip initialization
                    ContextMenuStrip.InitializeComponent();

                    // Register event
                    Event.Register();

                    // Create src directory as root of directory
                    string dataDir = System.IO.Directory.GetCurrentDirectory() + @"\Project\Default";
                    System.IO.Directory.CreateDirectory(dataDir);

                    // Create default node for root directory
                    System.Windows.Forms.TreeNode node = new System.Windows.Forms.TreeNode();
                    treeviewControl.treeView.Nodes.Add(node);

                    node.Name = dataDir;
                    node.Text = "Default Project";

                    node.ImageKey = "root_Local.png";
                    node.SelectedImageKey = "root_Local.png";
                    node.StateImageKey = "root_Local.png";

                    node.Nodes.Add("");

                    node.Expand();

                    FileSystemWatcher.InitializeComponent(node.Name);

                    treeviewControl.treeView.AllowDrop = true;
                }
                catch
                {

                }
            }

            static private System.Windows.Forms.TreeNode AddFolder(System.Windows.Forms.TreeNode node, string path)
            {
                System.Windows.Forms.TreeNode childNode = new System.Windows.Forms.TreeNode();

                childNode.Name = path;
                childNode.Text = System.IO.Path.GetFileName(childNode.Name);

                childNode.ImageKey = "localFolder.png";
                childNode.SelectedImageKey = "localFolder.png";
                childNode.StateImageKey = "localFolder.png";

                node.Nodes.Add(childNode);

                return childNode;
            }

            static private System.Windows.Forms.TreeNode AddFile(System.Windows.Forms.TreeNode node, string path)
            {
                System.Windows.Forms.TreeNode childNode = new System.Windows.Forms.TreeNode();

                childNode.Name = path;
                childNode.Text = System.IO.Path.GetFileName(childNode.Name);

                childNode.ImageKey = "localDocument.png";
                childNode.SelectedImageKey = "localDocument.png";
                childNode.StateImageKey = "localDocument.png";

                node.Nodes.Add(childNode);

                return childNode;
            }

            static private void Populate(System.Windows.Forms.TreeNode node)
            {
                foreach (string path in System.IO.Directory.GetDirectories(node.Name))
                {
                    System.Windows.Forms.TreeNode childNode = AddFolder(node, path);
                    if (System.IO.Directory.GetDirectories(path).Length != 0 || System.IO.Directory.GetFiles(path).Length !=0)
                    {
                        childNode.Nodes.Add("");
                    }
                }
                foreach (string path in System.IO.Directory.GetFiles(node.Name))
                {
                    AddFile(node, path);
                }
            }
        }
    }
}