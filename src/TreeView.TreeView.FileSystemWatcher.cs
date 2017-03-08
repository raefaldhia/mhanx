namespace Mhanxx
{
    public partial class TreeViewControl : System.Windows.Forms.UserControl
    {
        partial class TreeView
        {
            static public class FileSystemWatcher
            {
                static public void InitializeComponent(string path)
                {
                    System.IO.FileSystemWatcher watcher = new System.IO.FileSystemWatcher();
                    watcher.Path = path;

                    watcher.NotifyFilter = System.IO.NotifyFilters.FileName | System.IO.NotifyFilters.DirectoryName;

                    watcher.Filter = "*";
                    watcher.IncludeSubdirectories = true;

                    watcher.Created += new System.IO.FileSystemEventHandler(Event.Created);
                    watcher.Deleted += new System.IO.FileSystemEventHandler(Event.Deleted);

                    watcher.EnableRaisingEvents = true;
                }

                static public class Event
                {
                    public static void Created(object source, System.IO.FileSystemEventArgs e)
                    {
                        treeviewControl.treeView.Invoke((System.Windows.Forms.MethodInvoker)delegate {
                            System.Windows.Forms.TreeNode[] parent = treeviewControl.treeView.Nodes.Find(System.IO.Directory.GetParent(e.FullPath).FullName, true);
                            if (parent.Length != 0)
                            {
                                if (parent[0].IsExpanded)
                                {
                                    System.IO.FileAttributes attr = System.IO.File.GetAttributes(e.FullPath);
                                    if (attr.HasFlag(System.IO.FileAttributes.Directory))
                                    {
                                        System.Windows.Forms.TreeNode childNode = AddFolder(parent[0], e.FullPath);

                                        if (System.IO.Directory.GetDirectories(childNode.Name).Length != 0 || System.IO.Directory.GetFiles(childNode.Name).Length != 0)
                                        {
                                            childNode.Nodes.Add("");
                                        }
                                    }
                                    else
                                    {
                                        AddFile(parent[0], e.FullPath);
                                    }
                                }
                                else
                                {
                                    parent[0].Nodes.Add("");
                                }
                            }
                        });
                    }

                    public static void Deleted(object source, System.IO.FileSystemEventArgs e)
                    {
                        treeviewControl.treeView.Invoke((System.Windows.Forms.MethodInvoker)delegate {
                            System.Windows.Forms.TreeNode[] parent = treeviewControl.treeView.Nodes.Find(System.IO.Directory.GetParent(e.FullPath).FullName, true);
                            if (parent.Length != 0)
                            {
                                if (parent[0].IsExpanded)
                                {
                                    parent[0].Nodes.RemoveByKey(e.FullPath);
                                }
                                else
                                {
                                    if (System.IO.Directory.GetDirectories(parent[0].Name).Length == 0 && System.IO.Directory.GetFiles(parent[0].Name).Length == 0)
                                    {
                                        parent[0].Nodes.Clear();
                                    }
                                }
                            }
                        });
                    }
                }
            }
        }
    }
}