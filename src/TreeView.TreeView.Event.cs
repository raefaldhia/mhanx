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
                    treeviewControl.treeView.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(BeforeSelect);
                    treeviewControl.treeView.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(BeforeCollapse);
                    treeviewControl.treeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(BeforeExpand);

                    treeviewControl.treeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(NodeMouseClick);
                    treeviewControl.treeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(NodeMouseDoubleClick);
                }

                static private void BeforeSelect(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
                {
                    if (e.Node.Name == "")
                    {
                        e.Cancel = true;
                    }
                }

                static private void NodeMouseClick(object sender, System.Windows.Forms.TreeNodeMouseClickEventArgs e)
                {
                    treeviewControl.treeView.SelectedNode = e.Node;
                    
                    if (e.Button == System.Windows.Forms.MouseButtons.Right)
                    {
                        if (!treeviewControl.treeView.SelectedNode.ImageKey.Contains("Document"))
                        {
                            treeviewControl.folderContextMenuStrip.Show(treeviewControl.treeView, e.Location);
                        }
                        else
                        {
                            treeviewControl.fileContextMenuStrip.Show(treeviewControl.treeView, e.Location);
                        }
                    }
                }

                static private void NodeMouseDoubleClick(object sender, System.Windows.Forms.TreeNodeMouseClickEventArgs e)
                {
                    if (e.Node.ImageKey.Contains("Document"))
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(e.Node.Name);
                        }
                        catch(System.Exception exception)
                        {
                            System.Windows.Forms.MessageBox.Show(exception.Message, "List");
                        }
                    }
                }

                static public void BeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
                {
                    e.Node.Nodes.Clear();           
                    Populate(e.Node);
                    
                    if (e.Node.ImageKey.Contains("Folder"))
                    {                        
                        e.Node.ImageKey = "localFolder_Open.png";
                        e.Node.SelectedImageKey = "localFolder_Open.png";
                        e.Node.StateImageKey = "localFolder_Open.png";
                    }
                }

                static public void BeforeCollapse(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
                {
                    e.Node.Nodes.Clear();

                    if (System.IO.Directory.GetDirectories(e.Node.Name).Length != 0 || System.IO.Directory.GetFiles(e.Node.Name).Length != 0)
                    {
                        e.Node.Nodes.Add("");
                    }
                    
                    if (e.Node.ImageKey.Contains("Folder"))
                    {
                        e.Node.ImageKey = "localFolder.png";
                        e.Node.SelectedImageKey = "localFolder.png";
                        e.Node.StateImageKey = "localFolder.png";
                    }
                }
            }
        }
    }
}