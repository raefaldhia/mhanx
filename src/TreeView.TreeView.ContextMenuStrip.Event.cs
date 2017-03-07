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
                        treeviewControl.existingItemToolStripMenuItem.Click += new System.EventHandler(Folder.AddExistingItem);
                        treeviewControl.newFolderToolStripMenuItem.Click += new System.EventHandler(Folder.AddNew);

                        treeviewControl.deleteToolStripMenuItem.Click += new System.EventHandler(Folder.Delete);


                        treeviewControl.openToolStripMenuItem.Click += new System.EventHandler(File.Open);

                        treeviewControl.deleteToolStripMenuItem1.Click += new System.EventHandler(File.Delete);
                    }

                    static private class Folder
                    {
                        static public void AddExistingItem(object sender, System.EventArgs e)
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

                        static public void AddNew(object sender, System.EventArgs e)
                        {
                            int i = 1;
                            while (System.IO.Directory.Exists(treeviewControl.treeView.SelectedNode.Name + @"\NewFolder" + i.ToString()))
                            {
                                i++;
                            }
                            System.IO.Directory.CreateDirectory(treeviewControl.treeView.SelectedNode.Name + @"\NewFolder" + i.ToString());
                        }

                        static public void Delete(object sender, System.EventArgs e)
                        {
                            try
                            {
                                System.IO.Directory.Delete(treeviewControl.treeView.SelectedNode.Name, true);
                            }
                            catch
                            {

                            }
                        }
                    }

                    static private class File
                    {
                        static public void Open(object sender, System.EventArgs e)
                        {
                            try
                            {
                                System.Diagnostics.Process.Start(treeviewControl.treeView.SelectedNode.Name);
                            }
                            catch
                            {

                            }
                        }

                        static public void Delete(object sender, System.EventArgs e)
                        {
                            try
                            {
                                System.IO.File.Delete(treeviewControl.treeView.SelectedNode.Name);
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
}
