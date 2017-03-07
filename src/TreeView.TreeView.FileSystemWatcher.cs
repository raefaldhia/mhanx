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
                        System.IO.FileAttributes attr = System.IO.File.GetAttributes(e.FullPath);

                        treeviewControl.treeView.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate {
                            System.Windows.Forms.TreeNode node = treeviewControl.treeView.Nodes.Find(System.IO.Directory.GetParent(e.FullPath).FullName, true)[0];
                            if (attr.HasFlag(System.IO.FileAttributes.Directory))
                            {
                                AddFolder(node, e.FullPath);
                            }
                            else
                            {
                                AddFile(node, e.FullPath);
                            }
                            node.Expand();
                            treeviewControl.treeView.Nodes[0].Expand();
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
