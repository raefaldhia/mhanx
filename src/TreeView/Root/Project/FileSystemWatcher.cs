using System.Linq;

namespace Mhanxx
{
    partial class TreeView
    {
        private partial class Project
        {
            private class FileSystemWatcher : System.IO.FileSystemWatcher
            {
                public FileSystemWatcher(Project project) : base(project.Name, "*")
                {
                    this.project = project;

                    this.Renamed += OnRenamed;
                    this.Created += OnCreated;
                    this.Deleted += OnDeleted;

                    this.IncludeSubdirectories = true;

                    this.EnableRaisingEvents = true;
                    
                }

                private void OnRenamed(object sender, System.IO.RenamedEventArgs e)
                {
                    project.TreeView.Invoke((System.Windows.Forms.MethodInvoker)delegate
                    {
                        System.Windows.Forms.TreeNode[] content = project.TreeView.Nodes.Find(e.OldFullPath, true);
                        if (content.Length != 0)
                        {
                            ((Content)content[0]).ReplacePath(e.OldFullPath, e.FullPath);
                        }
                    });
                }

                private void OnCreated(object sender, System.IO.FileSystemEventArgs e)
                {
                    project.TreeView.Invoke((System.Windows.Forms.MethodInvoker)delegate
                    {
                        System.Windows.Forms.TreeNode[] parent = project.TreeView.Nodes.Find(System.IO.Directory.GetParent(e.FullPath).FullName, true);
                        if (parent.Length != 0)
                        {
                            if (parent[0].IsExpanded)
                            {
                                Content content;

                                System.IO.FileAttributes attr = System.IO.File.GetAttributes(e.FullPath);
                                if (attr.HasFlag(System.IO.FileAttributes.Directory))
                                {
                                    content = new Content(Content.Type.Folder, e.FullPath);
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
                                    content = new Content(Content.Type.File, e.FullPath);
                                }
                                parent[0].Nodes.Add(content);
                            }
                            else
                            {
                                parent[0].Nodes.Add(@"<\>");
                            }
                        }
                    });
                }

                private void OnDeleted(object sender, System.IO.FileSystemEventArgs e)
                {
                    project.TreeView.Invoke((System.Windows.Forms.MethodInvoker)delegate
                    {
                        System.Windows.Forms.TreeNode[] parent = project.TreeView.Nodes.Find(System.IO.Directory.GetParent(e.FullPath).FullName, true);
                        if (parent.Length != 0)
                        {
                            if (parent[0].IsExpanded)
                            {
                                parent[0].Nodes.RemoveByKey(e.FullPath);
                            }
                            if (!System.IO.Directory.EnumerateFileSystemEntries(parent[0].Name).Any())
                            {
                                parent[0].Nodes.Clear();
                                parent[0].Collapse();
                            }
                        }
                    });
                }

                private Project project;
            }
        }
    }
}