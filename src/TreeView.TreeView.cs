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

                    node.Expand();

                    Populate(node);
                    treeviewControl.treeView.Sort();

                    System.IO.FileSystemWatcher watcher = new System.IO.FileSystemWatcher();
                    watcher.Path = node.Name;

                    watcher.NotifyFilter = System.IO.NotifyFilters.FileName | System.IO.NotifyFilters.DirectoryName;
                    watcher.Filter = "*";
                    watcher.IncludeSubdirectories = true;

                    watcher.Created += new System.IO.FileSystemEventHandler(FileSystemWatcher.Event.NewDocument);
                    watcher.Deleted += new System.IO.FileSystemEventHandler(FileSystemWatcher.Event.DeleteDocument);

                    watcher.EnableRaisingEvents = true;
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
                    Populate(AddFolder(node, path));
                }

                foreach (string path in System.IO.Directory.GetFiles(node.Name))
                {
                    AddFile(node, path);
                }
            }
        }
    }
}