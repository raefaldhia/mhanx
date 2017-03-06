namespace Mhanxx
{
    public partial class TreeViewControl : System.Windows.Forms.UserControl
    {
        partial class TreeView
        {
            static public partial class ContextMenuStrip
            {
                static private class Event
                {
                    static public void Register()
                    {
                        treeviewControl.existingItemToolStripMenuItem.Click += new System.EventHandler(AddExistingItem);
                        treeviewControl.newFolderToolStripMenuItem.Click += new System.EventHandler(AddNewFolder);
                    }

                    static private void AddExistingItem(object sender, System.EventArgs e)
                    {
                        System.Windows.Forms.OpenFileDialog fileBrowser = new System.Windows.Forms.OpenFileDialog();

                        fileBrowser.Title = "Add file(s)";
                        fileBrowser.Multiselect = true;
 
                        if (fileBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            foreach (string path in fileBrowser.FileNames)
                            {          
                                try
                                {
                                    System.IO.File.Copy(path, treeviewControl.treeView.SelectedNode.Name + @"\" + System.IO.Path.GetFileName(path), false);
                                }
                                catch
                                {

                                }
                            }
                        }
                    }

                    static private void AddNewFolder(object sender, System.EventArgs e)
                    {

                        int i = 1;
                        while (System.IO.Directory.Exists(treeviewControl.treeView.SelectedNode.Name + @"\NewFolder" + i.ToString()))
                        {
                            i++;
                        }
                        System.IO.Directory.CreateDirectory(treeviewControl.treeView.SelectedNode.Name + @"\NewFolder" + i.ToString());
                    }
                }
            }
        }
    }
}
