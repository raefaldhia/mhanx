using System.Linq;

namespace Mhanxx
{
    public partial class TreeView
    {
        private partial class Root
        {
            private class FileSystemWatcher : System.IO.FileSystemWatcher
            {
                public FileSystemWatcher(Root root) : base (root.Name, "*")
                {
                    this.root = root;

                    this.Renamed += OnRenamed;
                    this.Created += OnCreated;
                    this.Deleted += OnDeleted;

                    this.IncludeSubdirectories = true;
                    this.EnableRaisingEvents = true;
                }          

                private void OnRenamed(object sender, System.IO.RenamedEventArgs e)
                {
                    root.TreeView.Invoke((System.Windows.Forms.MethodInvoker)delegate {
                        System.Windows.Forms.TreeNode[] node = root.TreeView.Nodes.Find(e.OldFullPath, true);
                        if (node.Length != 0)
                        {
                            if (node[0] is Project)
                            {
                                ((Project)node[0]).Rename(e.FullPath);
                            }
                            else if (node[0] is Project.Content)
                            {
                                ((Project.Content)node[0]).ReplacePath(e.OldFullPath, e.FullPath);
                            }
                        }
                    });
                }

                private void OnCreated(object sender, System.IO.FileSystemEventArgs e)
                {
                    root.TreeView.Invoke((System.Windows.Forms.MethodInvoker)delegate {
                        System.Windows.Forms.TreeNode[] parent = root.TreeView.Nodes.Find(System.IO.Directory.GetParent(e.FullPath).FullName, true);
                        if (parent.Length != 0)
                        {
                            if (parent[0] is Root)
                            {
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
                            }
                            else
                            {
                                if (parent[0].IsExpanded)
                                {
                                    Project.Content content;

                                    System.IO.FileAttributes attr = System.IO.File.GetAttributes(e.FullPath);
                                    if (attr.HasFlag(System.IO.FileAttributes.Directory))
                                    {
                                        content = new Project.Content(Project.Content.Type.Folder, e.FullPath);
                                        while (true)
                                        {
                                            try
                                            {
                                                if (System.IO.Directory.EnumerateFileSystemEntries(content.Name).Any())
                                                {
                                                    content.Nodes.Add(@"<\>");
                                                }
                                                break;
                                            }
                                            catch (System.IO.IOException)
                                            {
                                                System.Threading.Thread.Sleep(100);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        content = new Project.Content(Project.Content.Type.File, e.FullPath);
                                    }
                                    parent[0].Nodes.Add(content);
                                }
                                else
                                {
                                    parent[0].Nodes.Add(@"<\>");
                                }
                            }
                        }
                    });
                }

                private void OnDeleted(object sender, System.IO.FileSystemEventArgs e)
                {
                    root.TreeView.Invoke((System.Windows.Forms.MethodInvoker)delegate {
                        System.Windows.Forms.TreeNode[] node = root.TreeView.Nodes.Find(System.IO.Directory.GetParent(e.FullPath).FullName, true);
                        if (node.Length != 0)
                        {
                            if (node[0].IsExpanded)
                            {
                                node[0].Nodes.RemoveByKey(e.FullPath);
                            }
                            if (!System.IO.Directory.EnumerateFileSystemEntries(node[0].Name).Any())
                            {
                                node[0].Nodes.Clear();
                                node[0].Collapse();
                            }
                        }
                    });
                }

                private Root root;
            }
        }
    }
}