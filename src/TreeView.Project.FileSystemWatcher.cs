using System.Linq;

namespace Mhanxx
{
    partial class TreeView
    {
        private partial class Project
        {
            private static class FileSystemWatcher
            {
                private static Project project;

                public static void Register(Project target)
                {
                    project = target;

                    System.IO.FileSystemWatcher watcher = new System.IO.FileSystemWatcher();

                    watcher.Path = project.Name;
                    watcher.Filter = "*";

                    watcher.Renamed += Watcher_Renamed;
                    watcher.Created += Watcher_Created;
                    watcher.Deleted += Watcher_Deleted;

                    watcher.IncludeSubdirectories = true;
                    watcher.EnableRaisingEvents = true;
                }

                private static void Watcher_Renamed(object sender, System.IO.RenamedEventArgs e)
                {
                    project.TreeView.Invoke((System.Windows.Forms.MethodInvoker)delegate {
                        System.Windows.Forms.TreeNode[] content = project.TreeView.Nodes.Find(e.OldFullPath, true);
                        if (content.Length != 0)
                        {
                            ((Project.Content)content[0]).Rename(e.OldFullPath, e.FullPath);
                        }
                        project.TreeView.Sort();
                    });
                }

                private static void Watcher_Created(object sender, System.IO.FileSystemEventArgs e)
                {
                    project.TreeView.Invoke((System.Windows.Forms.MethodInvoker)delegate {
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
          
                                    if (System.IO.Directory.EnumerateFileSystemEntries(content.Name).Any())
                                    {
                                        content.Nodes.Add(@"<\>");
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
                            project.TreeView.Sort();
                        }
                    });
                }

                private static void Watcher_Deleted(object sender, System.IO.FileSystemEventArgs e)
                {
                    project.TreeView.Invoke((System.Windows.Forms.MethodInvoker)delegate {
                        System.Windows.Forms.TreeNode[] parent = project.TreeView.Nodes.Find(System.IO.Directory.GetParent(e.FullPath).FullName, true);
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
                            project.TreeView.Sort();
                        }
                    }); 
                }
            }
        }
    }
}
