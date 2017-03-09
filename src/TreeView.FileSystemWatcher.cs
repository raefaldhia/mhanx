namespace Mhanxx
{
    public partial class TreeView
    {
        private class FileSystemWatcher : System.IO.FileSystemWatcher
        {
            private System.Windows.Forms.TreeNode Node;

            public FileSystemWatcher(System.Windows.Forms.TreeNode node)
            {
                Node = node;

                this.Path = Node.Name;
                this.Filter = "*";

                this.Renamed += FileSystemWatcher_Renamed;
                this.Created += FileSystemWatcher_Created;
                this.Deleted += FileSystemWatcher_Deleted;
            }

            private void FileSystemWatcher_Renamed(object sender, System.IO.RenamedEventArgs e)
            {
                Node.TreeView.Invoke((System.Windows.Forms.MethodInvoker)delegate {
                    System.IO.FileAttributes attr = System.IO.File.GetAttributes(e.FullPath);
                    if (attr.HasFlag(System.IO.FileAttributes.Directory))
                    {
                        System.Windows.Forms.TreeNode source = Node.Nodes.Find(e.OldFullPath, false)[0];
                        source.Name = e.FullPath;
                        source.Text = System.IO.Path.GetFileName(source.Name);
                        if (source.IsExpanded)
                        {
                            Renamed_DoRecursive(source, e.OldFullPath);
                        }
                    }
                });
            }

            private void FileSystemWatcher_Created(object sender, System.IO.FileSystemEventArgs e)
            {
                Node.TreeView.Invoke((System.Windows.Forms.MethodInvoker)delegate {
                    System.IO.FileAttributes attr = System.IO.File.GetAttributes(e.FullPath);
                    if (attr.HasFlag(System.IO.FileAttributes.Directory))
                    {
                        Project project = new Project(e.FullPath);
                        Node.Nodes.Add(project);
                    }
                    Node.Expand();
                });
            }

            private void FileSystemWatcher_Deleted(object sender, System.IO.FileSystemEventArgs e)
            {
                Node.TreeView.Invoke((System.Windows.Forms.MethodInvoker)delegate
                {
                    Node.Nodes.RemoveByKey(e.FullPath);
                });
            }

            public void Renamed_DoRecursive(System.Windows.Forms.TreeNode node, string oldPath)
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
        }
    }
}
