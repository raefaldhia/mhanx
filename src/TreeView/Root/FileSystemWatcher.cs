namespace Mhanxx
{
    public partial class TreeView
    {
        private partial class Root
        {
            private class FileSystemWatcher : System.IO.FileSystemWatcher
            {
                public FileSystemWatcher(Root root, string filter) : base (root.Name, filter)
                {
                    this.root = root;

                    this.Renamed += OnRenamed;
                    this.Created += OnCreated;
                    this.Deleted += OnDeleted;

                    this.EnableRaisingEvents = true;
                }          

                private void OnRenamed(object sender, System.IO.RenamedEventArgs e)
                {
                    root.TreeView.Invoke((System.Windows.Forms.MethodInvoker)delegate {
                        System.IO.FileAttributes attr = System.IO.File.GetAttributes(e.FullPath);
                        if (attr.HasFlag(System.IO.FileAttributes.Directory))
                        {
                            System.Windows.Forms.TreeNode[] projects = root.Nodes.Find(e.OldFullPath, false);
                            if (projects.Length != 0)
                            {
                                ((Project)projects[0]).Rename(e.FullPath);
                            }
                        }
                    });
                }

                private void OnCreated(object sender, System.IO.FileSystemEventArgs e)
                {
                    root.TreeView.Invoke((System.Windows.Forms.MethodInvoker)delegate {
                        System.IO.FileAttributes attr = System.IO.File.GetAttributes(e.FullPath);
                        if (attr.HasFlag(System.IO.FileAttributes.Directory))
                        {
                            while (true)
                            {
                                if (System.IO.Directory.Exists(e.FullPath))
                                {
                                    Project project = new Project(e.FullPath);
                                    root.Nodes.Add(project);
                                    if (!root.IsExpanded)
                                    {
                                        root.Expand();
                                    }
                                    break;
                                }
                                System.Threading.Thread.Sleep(100);
                            }
                        }
                    });
                }

                private void OnDeleted(object sender, System.IO.FileSystemEventArgs e)
                {
                    root.TreeView.Invoke((System.Windows.Forms.MethodInvoker)delegate {
                        System.Windows.Forms.TreeNode[] projects = root.Nodes.Find(e.FullPath, false);
                        if (projects.Length != 0)
                        {
                            ((Project)projects[0]).Remove();
                        }
                    });
                }

                private Root root;
            }
        }
    }
}