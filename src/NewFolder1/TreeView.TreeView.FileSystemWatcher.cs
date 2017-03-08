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

                    watcher.Filter = "*";
                    watcher.IncludeSubdirectories = true;

                    watcher.Renamed += new System.IO.RenamedEventHandler(Event.Renamed);
                    watcher.Created += new System.IO.FileSystemEventHandler(Event.Created);
                    watcher.Deleted += new System.IO.FileSystemEventHandler(Event.Deleted);

                    watcher.EnableRaisingEvents = true;
                }

                static public class Event
                {
                    public static void Renamed(object source, System.IO.RenamedEventArgs e)
                    {
                        treeviewControl.treeView.Invoke((System.Windows.Forms.MethodInvoker)delegate {
                            System.Windows.Forms.TreeNode[] node = treeviewControl.treeView.Nodes.Find(e.OldFullPath, true);
                            if (node.Length != 0)
                            {
                                node[0].Name = e.FullPath;
                                System.IO.FileAttributes attr = System.IO.File.GetAttributes(node[0].Name);
                                if (attr.HasFlag(System.IO.FileAttributes.Directory))
                                {
                                    node[0].Text = System.IO.Path.GetFileName(e.Name);
                                    if (node[0].IsExpanded)
                                    {
                                        Renamed_DoRecursive(node[0], e.OldFullPath);
                                    }
                                }
                                else
                                {
                                    node[0].Text = System.IO.Path.GetFileName(e.Name);
                                }
                            }
                        });
                    }

                    public static void Renamed_DoRecursive(System.Windows.Forms.TreeNode node, string oldPath)
                    {
                        foreach (System.Windows.Forms.TreeNode affectedNode in node.Nodes)
                        {
                            string affected_path = affectedNode.Name;
                            affectedNode.Name = affectedNode.Name.Replace(oldPath, node.Name);
                            System.IO.FileAttributes nodeAttr = System.IO.File.GetAttributes(affectedNode.Name);
                            if (nodeAttr.HasFlag(System.IO.FileAttributes.Directory) && affectedNode.IsExpanded)
                            {
                                Renamed_DoRecursive(affectedNode, affected_path);
                            }
                        }
                    }

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
                                try
                                {
                                    if (System.IO.Directory.GetDirectories(parent[0].Name).Length == 0 && System.IO.Directory.GetFiles(parent[0].Name).Length == 0)
                                    {
                                        parent[0].Nodes.Clear();
                                        parent[0].Collapse();
                                    }
                                }
                                catch (System.IO.DirectoryNotFoundException)
                                {
                                    // Instead check if the file or directory exist, catch it. then does nothing.
                                }
                            }
                        });
                    }
                }
            }
        }
    }
}