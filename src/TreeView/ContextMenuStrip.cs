namespace Mhanxx
{
    partial class TreeView
    {
        static class ContextMenuStrip
        {
            private static TreeView treeView;
            private static bool RequestIsCopy = false;
            private static Project.Content clipboard = null;

            public static void Register(TreeView view)
            {
                treeView = view;

                treeView.folderAddExistingItem.Click += Folder.AddExistingItem;
                treeView.folderAddNewFolder.Click += Folder.AddNewFolder;
                
                treeView.folderPaste.Click += Folder.Paste;
                treeView.folderDelete.Click += Folder.Delete;
                treeView.folderRename.Click += Rename;

                treeView.OpenFolderinFileExplorer.Click += Open;

                treeView.fileOpen.Click += Open;

                treeView.fileCopy.Click += File.Copy;
                treeView.fileDelete.Click += File.Delete;
                treeView.fileRename.Click += Rename;
            }

            private static void Open(object sender, System.EventArgs e)
            {
                try
                {
                    System.Diagnostics.Process.Start(treeView.SelectedNode.Name);
                }
                catch (System.Exception exception)
                {
                    System.Windows.Forms.MessageBox.Show(exception.Message, "List");
                }
            }

            private static void Rename(object sender, System.EventArgs e)
            {
                try
                {
                    treeView.LabelEdit = true;
                    treeView.SelectedNode.BeginEdit();
                }
                catch (System.Exception exception)
                {
                    System.Windows.Forms.MessageBox.Show(exception.Message, "List");
                }
            }

            static class File
            {
                public static void Copy(object sender, System.EventArgs e)
                {
                    clipboard = (Project.Content)treeView.SelectedNode;
                    treeView.folderPaste.Enabled = true;
                    RequestIsCopy = true;
                }

                public static void Delete(object sender, System.EventArgs e)
                {
                    try
                    {
                        System.Windows.Forms.DialogResult result = System.Windows.Forms.MessageBox.Show("'" + treeView.SelectedNode.Text + "' will be deleted permanently.", "List", System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Warning);
                        if (result == System.Windows.Forms.DialogResult.OK)
                        {
                            Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(treeView.SelectedNode.Name, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);
                        }
                    }
                    catch (System.Exception exception)
                    {
                        System.Windows.Forms.MessageBox.Show(exception.Message, "List");
                    }
                }
            }

            static class Folder
            {
                public static void AddExistingItem(object sender, System.EventArgs e)
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
                                Microsoft.VisualBasic.FileIO.FileSystem.CopyFile(path, treeView.SelectedNode.Name + @"\" + System.IO.Path.GetFileName(path), Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing);
                            }
                            catch (System.Exception exception)
                            {
                                System.Windows.Forms.MessageBox.Show(exception.Message, "List");
                            }
                        }
                    }
                }

                public static void AddNewFolder(object sender, System.EventArgs e)
                {
                    int i = 1;
                    while (System.IO.Directory.Exists(treeView.SelectedNode.Name + @"\NewFolder" + i.ToString()))
                    {
                        i++;
                    }
                    System.IO.Directory.CreateDirectory(treeView.SelectedNode.Name + @"\NewFolder" + i.ToString());
                }

                public static void Paste(object sender, System.EventArgs e)
                {
                    string destination = treeView.SelectedNode.Name + @"\" + clipboard.Text;
                    if (RequestIsCopy)
                    {
                        Microsoft.VisualBasic.FileIO.FileSystem.CopyFile(clipboard.Name, destination, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing);
                    }
                    else
                    {
                        Microsoft.VisualBasic.FileIO.FileSystem.MoveFile(clipboard.Name, destination, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing);
                    }
                }

                public static void Delete(object sender, System.EventArgs e)
                {
                    try
                    {
                        System.Windows.Forms.DialogResult result = System.Windows.Forms.MessageBox.Show("'" + treeView.SelectedNode.Text + "' will be deleted permanently.", "List", System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Warning);
                        if (result == System.Windows.Forms.DialogResult.OK)
                        {
                            Microsoft.VisualBasic.FileIO.FileSystem.DeleteDirectory(treeView.SelectedNode.Name, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);
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
