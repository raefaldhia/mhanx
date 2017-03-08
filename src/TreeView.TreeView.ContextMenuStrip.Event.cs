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

                        treeviewControl.renameToolStripMenuItem1.Click += new System.EventHandler(Rename);
                        treeviewControl.deleteToolStripMenuItem.Click += new System.EventHandler(Folder.Delete);
                        

                        treeviewControl.openFolderInFileExplorerToolStripMenuItem.Click += new System.EventHandler(Open);

                        treeviewControl.openToolStripMenuItem.Click += new System.EventHandler(Open);

                        treeviewControl.renameToolStripMenuItem1.Click += new System.EventHandler(Rename);
                        treeviewControl.deleteToolStripMenuItem1.Click += new System.EventHandler(File.Delete);
                    }

                    static public void Open(object sender, System.EventArgs e)
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(treeviewControl.treeView.SelectedNode.Name);
                        }
                        catch (System.Exception exception)
                        {
                            System.Windows.Forms.MessageBox.Show(exception.Message, "List");
                        }
                    }

                    static public void Rename(object sender, System.EventArgs e)
                    {
                        try
                        {
                            treeviewControl.treeView.LabelEdit = true;
                            treeviewControl.treeView.SelectedNode.BeginEdit();
                        }
                        catch (System.Exception exception)
                        {
                            System.Windows.Forms.MessageBox.Show(exception.Message, "List");
                        }
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
                                        Microsoft.VisualBasic.FileIO.FileSystem.CopyFile(path, treeviewControl.treeView.SelectedNode.Name + @"\" + System.IO.Path.GetFileName(path), Microsoft.VisualBasic.FileIO.UIOption.AllDialogs);
                                    }
                                    catch (System.Exception exception)
                                    {
                                        System.Windows.Forms.MessageBox.Show(exception.Message, "List");
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
                                System.Windows.Forms.DialogResult result = System.Windows.Forms.MessageBox.Show("'" + treeviewControl.treeView.SelectedNode.Text + "' will be deleted permanently.", "List", System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Warning);
                                if (result == System.Windows.Forms.DialogResult.OK)
                                {
                                    System.IO.Directory.Delete(treeviewControl.treeView.SelectedNode.Name, true);
                                }
                            }
                            catch (System.Exception exception)
                            {
                                System.Windows.Forms.MessageBox.Show(exception.Message, "List");
                            }
                        }
                    }

                    static private class File
                    {
                        static public void Delete(object sender, System.EventArgs e)
                        {
                            try
                            {
                                System.Windows.Forms.DialogResult result = System.Windows.Forms.MessageBox.Show("'" + treeviewControl.treeView.SelectedNode.Text + "' will be deleted permanently.", "List", System.Windows.Forms.MessageBoxButtons.OKCancel);
                                if (result == System.Windows.Forms.DialogResult.OK)
                                {
                                    System.IO.File.Delete(treeviewControl.treeView.SelectedNode.Name);
                                }
                            }
                            catch (System.Exception exception)
                            {
                                System.Windows.Forms.MessageBox.Show(exception.Message, "List");
                            }
                        }
                    }
                }
            }
        }
    }
}
