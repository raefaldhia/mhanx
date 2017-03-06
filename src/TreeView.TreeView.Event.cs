namespace Mhanxx
{
    public partial class TreeViewControl : System.Windows.Forms.UserControl
    {
        static private partial class TreeView
        {
            static private class Event
            {
                static public void Register()
                {
                    treeviewControl.treeView.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(Event.BeforeCollapse);
                    treeviewControl.treeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(Event.BeforeExpand);
                    treeviewControl.treeView.MouseClick += new System.Windows.Forms.MouseEventHandler(Event.MouseClick);
                    treeviewControl.treeView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(Event.MouseDoubleClick);
                }

                static public void BeforeCollapse(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
                {
                    if (e.Node == treeviewControl.treeView.Nodes[0])
                    {
                        e.Cancel = true;

                        return;
                    }
                    if (e.Node.ImageKey.Contains("Folder"))
                    {
                        e.Node.ImageKey = "localFolder.png";
                        e.Node.SelectedImageKey = "localFolder.png";
                        e.Node.StateImageKey = "localFolder.png";
                    }
                }

                static public void BeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
                {
                    if (e.Node.ImageKey.Contains("Folder"))
                    {
                        e.Node.ImageKey = "localFolder_Open.png";
                        e.Node.SelectedImageKey = "localFolder_Open.png";
                        e.Node.StateImageKey = "localFolder_Open.png";
                    }
                }

                static public void MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
                {
                    treeviewControl.treeView.SelectedNode = treeviewControl.treeView.GetNodeAt(e.X, e.Y);
                    if (e.Button == System.Windows.Forms.MouseButtons.Right)
                    {
                        if (!treeviewControl.treeView.SelectedNode.ImageKey.Contains("Document"))
                        {
                            treeviewControl.folderContextMenuStrip.Show(treeviewControl.treeView, e.X, e.Y);
                        }
                        else
                        {
                            treeviewControl.fileContextMenuStrip.Show(treeviewControl.treeView, e.X, e.Y);
                        }
                    }
                }

                static public void MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
                {
                    if (((System.Windows.Forms.TreeView)sender).SelectedNode.ImageKey.Contains("Document"))
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(((System.Windows.Forms.TreeView)sender).SelectedNode.Name);
                        }
                        catch
                        {

                        }
                    }
                }
            }
        }
    }
}