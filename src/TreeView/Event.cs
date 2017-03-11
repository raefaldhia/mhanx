namespace Mhanxx
{
    partial class TreeView
    {
        private class Event
        {
            public Event(TreeView view)
            {
                treeView = view;

                treeView.BeforeExpand += BeforeExpand;
                treeView.BeforeCollapse += BeforeCollapse;

                treeView.AfterLabelEdit += AfterLabelEdit;

                treeView.NodeMouseClick += NodeMouseClick;

                contextmenustripHandler = new ContextMenuStrip(this.treeView);
            }

            private static void BeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
            {
                if (e.Node is Root)
                {
                    ((Root)e.Node).eventHandler.BeforeExpand(sender, e);
                }
                else if (e.Node is Project)
                {
                    ((Project)e.Node).eventHandler.BeforeExpand(sender, e);
                }
                else if (e.Node is Project.Content)
                {
                    ((Project.Content)e.Node).eventHandler.BeforeExpand(sender, e);
                }
            }

            private static void BeforeCollapse(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
            {
                if (e.Node is Root)
                {
                    ((Root)e.Node).eventHandler.BeforeCollapse(sender, e);
                }
                else if (e.Node is Project)
                {
                    ((Project)e.Node).eventHandler.BeforeCollapse(sender, e);
                }
                else if (e.Node is Project.Content)
                {
                    ((Project.Content)e.Node).eventHandler.BeforeCollapse(sender, e);
                }
            }

            private void AfterLabelEdit(object sender, System.Windows.Forms.NodeLabelEditEventArgs e)
            {
                if (e.Node is Project)
                {
                    ((Project)e.Node).eventHandler.AfterLabelEdit(sender, e);
                }
                else if (e.Node is Project.Content)
                {
                    ((Project.Content)e.Node).eventHandler.AfterLabelEdit(sender, e);
                }
            }

            private void NodeMouseClick(object sender, System.Windows.Forms.TreeNodeMouseClickEventArgs e)
            {
                treeView.SelectedNode = e.Node;

                if (e.Node is Root)
                {
                    ((Root)e.Node).eventHandler.NodeMouseClick(sender, e);
                }
                else if (e.Node is Project)
                {
                    ((Project)e.Node).eventHandler.NodeMouseClick(sender, e);
                }
                else if (e.Node is Project.Content)
                {
                    ((Project.Content)e.Node).eventHandler.NodeMouseClick(sender, e);
                }
            }

            private TreeView treeView;
            private ContextMenuStrip contextmenustripHandler;

            private class ContextMenuStrip
            {
                public ContextMenuStrip(TreeView treeView)
                {
                    this.treeView = treeView;

                    treeView.rootAddNewProject.Click += rootAddNewProject;

                    treeView.rootOpenFolderinFileExplorer.Click += OpenFileOrDirectory;
                    

                    treeView.projectAddExistingItem.Click += AddExistingItem;
                    treeView.projectAddNewFolder.Click += AddNewFolder;

                    treeView.projectDelete.Click += DeleteDirectory;
                    treeView.projectRename.Click += Rename;

                    treeView.projectOpenFolderinFileExplorer.Click += OpenFileOrDirectory;

                    treeView.contentFolderAddExistingItem.Click += AddExistingItem;
                    treeView.contentFolderAddNewFolder.Click += AddNewFolder;

                    treeView.contentFolderDelete.Click += DeleteDirectory;
                    treeView.contentFolderRename.Click += Rename;

                    treeView.contentFolderOpenFolderinFileExplorer.Click += OpenFileOrDirectory;

                    treeView.contentFileOpen.Click += OpenFileOrDirectory;

                    treeView.contentFileDelete.Click += DeleteFile;
                    treeView.contentFileRename.Click += Rename;
                }

                private void Rename(object sender, System.EventArgs e)
                {
                    treeView.LabelEdit = true;
                    treeView.SelectedNode.BeginEdit();
                }

                private void AddExistingItem(object sender, System.EventArgs e)
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

                private void AddNewFolder(object sender, System.EventArgs e)
                {
                    int i = 1;
                    string path = treeView.SelectedNode.Name + @"\NewFolder";
                    while (System.IO.Directory.Exists(path + i.ToString()))
                    {
                        i++;
                    }
                    path += i.ToString();
                    System.IO.Directory.CreateDirectory(path);
                }

                private void DeleteDirectory(object sender, System.EventArgs e)
                {
                    System.Windows.Forms.DialogResult result = System.Windows.Forms.MessageBox.Show("'" + treeView.SelectedNode.Text + "' will be deleted permanently.", "List", System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Warning);
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        Microsoft.VisualBasic.FileIO.FileSystem.DeleteDirectory(treeView.SelectedNode.Name, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing);
                    }
                }

                private void DeleteFile(object sender, System.EventArgs e)
                {
                    System.Windows.Forms.DialogResult result = System.Windows.Forms.MessageBox.Show("'" + treeView.SelectedNode.Text + "' will be deleted permanently.", "List", System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Warning);
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(treeView.SelectedNode.Name, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing);
                    }
                }

                private void OpenFileOrDirectory(object sender, System.EventArgs e)
                {
                    try
                    {
                        System.Diagnostics.Process.Start(treeView.SelectedNode.Name);
                    }
                    catch (System.Exception exception)
                    {
                        System.Windows.Forms.MessageBox.Show("Couldn't exec: " + exception.Message, "List", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    }
                }

                private void rootAddNewProject(object sender, System.EventArgs e)
                {
                    int i = 1;
                    string path = treeView.SelectedNode.Name + @"\NewProject";
                    while (System.IO.Directory.Exists(path + i.ToString()))
                    {
                        i++;
                    }
                    path += i.ToString();
                    System.IO.Directory.CreateDirectory(path);

                    LibGit2Sharp.Repository.Init(path);
                }

                private TreeView treeView;
            }
        }
    }
}