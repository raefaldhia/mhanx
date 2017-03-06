namespace Mhanxx
{
    public partial class TreeViewControl : System.Windows.Forms.UserControl
    {
        partial class TreeView
        {
            static public class FileSystemWatcher
            {
                static public class Event
                {
                    public static void NewDocument(object source, System.IO.FileSystemEventArgs e)
                    {
                        treeviewControl.treeView.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate {
                            System.IO.FileAttributes attr = System.IO.File.GetAttributes(e.FullPath);

                            if (attr.HasFlag(System.IO.FileAttributes.Directory))
                            {
                                System.Windows.Forms.TreeNode node = AddFolder(treeviewControl.treeView.Nodes.Find(System.IO.Directory.GetParent(e.FullPath).FullName, true)[0], e.FullPath);
                                Populate(node);
                            }
                            else
                            {
                                AddFile(treeviewControl.treeView.Nodes.Find(System.IO.Directory.GetParent(e.FullPath).FullName, true)[0], e.FullPath);
                            }
                        });
                    }

                    public static void DeleteDocument(object source, System.IO.FileSystemEventArgs e)
                    {
                        treeviewControl.treeView.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate {
                            treeviewControl.treeView.Nodes.Remove(treeviewControl.treeView.Nodes.Find(e.FullPath, true)[0]);
                        });
                    }
                }
            }
        }
    }
}
