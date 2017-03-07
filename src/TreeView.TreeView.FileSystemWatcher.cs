namespace Mhanxx
{
    public partial class TreeViewControl : System.Windows.Forms.UserControl
    {
        partial class TreeView
        {
            static public class FileSystemWatcher
            {
                static private System.Collections.Generic.List<string> pool;

                static public void InitializeComponent(string path)
                {
                    System.IO.FileSystemWatcher watcher = new System.IO.FileSystemWatcher();
                    watcher.Path = path;

                    watcher.NotifyFilter = System.IO.NotifyFilters.DirectoryName | System.IO.NotifyFilters.FileName;

                    watcher.Filter = "*";
                    watcher.IncludeSubdirectories = true;

                    //watcher.Renamed += new System.IO.RenamedEventHandler(FileSystemWatcher.Event.Rename);
                    watcher.Created += new System.IO.FileSystemEventHandler(FileSystemWatcher.Event.Created);
                    watcher.Deleted += new System.IO.FileSystemEventHandler(FileSystemWatcher.Event.Deleted);

                    watcher.EnableRaisingEvents = true;

                    pool = new System.Collections.Generic.List<string>();
                }
                static public class Event
                {
                    
                    static private bool indicate_move = false;
                    static private System.Timers.Timer timer;

                    public static void Created(object source, System.IO.FileSystemEventArgs e)
                    {
                        if (indicate_move == true)
                        {
                            pool.Add(e.FullPath);
                            if (timer == null)
                            {
                                timer = new System.Timers.Timer(1000);
                                timer.Elapsed += ProcessQueue;
                                timer.Start();
                            }
                            else
                            {
                                timer.Stop();
                                timer.Start();
                            }
                        }
                        else
                        {
                            AddToTree(e.FullPath, false);
                        }
                    }

                    public static void Deleted(object source, System.IO.FileSystemEventArgs e)
                    {
                        System.Windows.Forms.TreeNode node = treeviewControl.treeView.Nodes.Find(e.FullPath, true)[0];
                        if (node.Nodes.Count != 0)
                        {
                            
                            indicate_move = true;
                        }
                        treeviewControl.treeView.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate {
                            treeviewControl.treeView.Nodes.Remove(node);
                        });
                    }

                    private static void ProcessQueue(object sender, System.Timers.ElapsedEventArgs args)
                    { 
                        if (timer != null)
                        {
                            timer.Stop();
                            timer.Dispose();
                            timer = null;
                        }

                        foreach (string path in pool)
                        {
                            AddToTree(path, true);
                        }
                        pool.Clear();

                        indicate_move = false;
                    }

                    private static void AddToTree(string path, bool populate)
                    {
                        treeviewControl.treeView.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate {
                            System.IO.FileAttributes attr = System.IO.File.GetAttributes(path);
                            System.Windows.Forms.TreeNode node = treeviewControl.treeView.Nodes.Find(System.IO.Directory.GetParent(path).FullName, true)[0];
                            if (attr.HasFlag(System.IO.FileAttributes.Directory))
                            {
                                System.Windows.Forms.TreeNode childnode = AddFolder(node, path);
                                if (populate == true)
                                {
                                    Populate(childnode);
                                }
                            }
                            else
                            {
                                AddFile(node, path);
                            }
                            node.Expand();
                            treeviewControl.treeView.Nodes[0].Expand();
                        });
                    }
                }
            }
        }
    }
}