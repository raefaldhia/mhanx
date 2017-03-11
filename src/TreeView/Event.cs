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

                treeView.ItemDrag += ItemDrag;
                treeView.DragEnter += DragEnter;
                treeView.DragOver += DragOver;
                treeView.DragDrop += DragDrop;

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

            private void ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
            {
                treeView.SelectedNode = (System.Windows.Forms.TreeNode)e.Item;

                if (treeView.SelectedNode is Project.Content)
                {
                    ((Project.Content)treeView.SelectedNode).eventHandler.ItemDrag(sender, e);
                }
            }

            private void DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
            {
                treeView.Focus();

                if (e.Data.GetDataPresent(typeof(Project.Content)))
                {
                    Project.Content source = (Project.Content)e.Data.GetData(typeof(Project.Content));
                    source.eventHandler.DragEnter(sender, e);
                }
                else
                {
                    e.Effect = System.Windows.Forms.DragDropEffects.Copy;
                }
            }

            private void DragOver(object sender, System.Windows.Forms.DragEventArgs e)
            {
                System.Drawing.Point point = treeView.PointToClient(new System.Drawing.Point(e.X, e.Y));
                System.Windows.Forms.TreeNode target = treeView.GetNodeAt(point);

                if (target != null)
                {
                    treeView.SelectedNode = target;

                    if (treeView.SelectedNode is Project)
                    {
                        ((Project)treeView.SelectedNode).eventHandler.DragOver(sender, e);
                    }
                    else if (treeView.SelectedNode is Project.Content)
                    {
                        ((Project.Content)treeView.SelectedNode).eventHandler.DragOver(sender, e);
                    }
                    else
                    {
                        e.Effect = System.Windows.Forms.DragDropEffects.None;
                    }
                }
            }

            private void DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
            {
                System.Drawing.Point point = treeView.PointToClient(new System.Drawing.Point(e.X, e.Y));
                System.Windows.Forms.TreeNode target = treeView.GetNodeAt(point);

                if (e.Data.GetDataPresent(typeof(Project.Content)))
                {
                    Project.Content source = (Project.Content)e.Data.GetData(typeof(Project.Content));

                    if (source != target)
                    {
                        if (target is Project.Content && ((Project.Content)target).type == Project.Content.Type.File)
                        {
                            target = target.Parent;
                        }

                        string targetPath = target.Name + @"\" + source.Text;

                        if (source.Name != targetPath)
                        {
                            if (source.type == Project.Content.Type.File)
                            {
                                Microsoft.VisualBasic.FileIO.FileSystem.MoveFile(source.Name, targetPath, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing);
                            }
                            else
                            {

                                Microsoft.VisualBasic.FileIO.FileSystem.MoveDirectory(source.Name, targetPath, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing);
                            }
                        }
                    }
                }
                else
                {

                }
            }

            private TreeView treeView;
            private ContextMenuStrip contextmenustripHandler;

            private class ContextMenuStrip
            {
                public ContextMenuStrip(TreeView treeView)
                {
                    this.treeView = treeView;

                    treeView.projectPaste.Enabled = false;
                    treeView.contentFolderPaste.Enabled = false;

                    treeView.rootAddNewProject.Click += rootAddNewProject;

                    treeView.rootOpenFolderinFileExplorer.Click += OpenFileOrDirectory;
                    
                    treeView.projectAddExistingItem.Click += AddExistingItem;
                    treeView.projectAddNewFolder.Click += AddNewFolder;

                    treeView.projectPaste.Click += Paste;
                    treeView.projectDelete.Click += DeleteDirectory;
                    treeView.projectRename.Click += Rename;

                    treeView.projectOpenFolderinFileExplorer.Click += OpenFileOrDirectory;

                    treeView.contentFolderAddExistingItem.Click += AddExistingItem;
                    treeView.contentFolderAddNewFolder.Click += AddNewFolder;

                    treeView.contentFolderCut.Click += Cut;
                    treeView.contentFolderCopy.Click += Copy;
                    treeView.contentFolderPaste.Click += Paste;
                    treeView.contentFolderDelete.Click += DeleteDirectory;
                    treeView.contentFolderRename.Click += Rename;

                    treeView.contentFolderOpenFolderinFileExplorer.Click += OpenFileOrDirectory;

                    treeView.contentFileOpen.Click += OpenFileOrDirectory;

                    treeView.contentFileCut.Click += Cut;
                    treeView.contentFileCopy.Click += Copy;
                    treeView.contentFileDelete.Click += DeleteFile;
                    treeView.contentFileRename.Click += Rename;
                }

                private void Cut(object sender, System.EventArgs e)
                {
                    treeView.projectPaste.Enabled = true;
                    treeView.contentFolderPaste.Enabled = true;

                    clipboardIsCopy = false;

                    clipboard = (Project.Content)treeView.SelectedNode;
                }

                private void Copy(object sender, System.EventArgs e)
                {
                    treeView.projectPaste.Enabled = true;
                    treeView.contentFolderPaste.Enabled = true;

                    clipboardIsCopy = true;

                    clipboard = (Project.Content)treeView.SelectedNode;
                }

                private void Paste(object sender, System.EventArgs e)
                {
                    if (clipboard != null)
                    {
                        try
                        {
                            string destination = treeView.SelectedNode.Name + @"\" + clipboard.Text;
                            if (clipboardIsCopy && (destination != clipboard.Name))
                            {
                                if (clipboard.type == Project.Content.Type.File)
                                {
                                    Microsoft.VisualBasic.FileIO.FileSystem.CopyFile(clipboard.Name, destination, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing);
                                }
                                else
                                {
                                    Microsoft.VisualBasic.FileIO.FileSystem.CopyDirectory(clipboard.Name, destination, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing);
                                }
                            }
                            else if ((destination != clipboard.Name))
                            {
                                if (clipboard.type == Project.Content.Type.File)
                                {
                                    Microsoft.VisualBasic.FileIO.FileSystem.MoveFile(clipboard.Name, destination, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing);
                                }
                                else
                                {
                                    Microsoft.VisualBasic.FileIO.FileSystem.MoveDirectory(clipboard.Name, destination, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing);
                                }
                            }
                        }
                        catch (System.IO.DirectoryNotFoundException exception)
                        {
                            treeView.projectPaste.Enabled = false;
                            treeView.contentFolderPaste.Enabled = false;

                            clipboard = null;

                            System.Windows.Forms.MessageBox.Show(exception.Message, "List");
                        }
                    }
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
                private bool clipboardIsCopy = false;
                private Project.Content clipboard = null;
            }
        }
    }
}