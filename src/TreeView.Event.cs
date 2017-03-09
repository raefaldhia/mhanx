namespace Mhanxx
{
    partial class TreeView
    {
        private static class Event
        {
            private static TreeView treeView;

            public static void Register(TreeView view)
            {
                treeView = view;

                treeView.BeforeCollapse += BeforeCollapse;
                treeView.BeforeExpand +=  BeforeExpand;

                treeView.NodeMouseClick += TreeView_NodeMouseClick;
                treeView.NodeMouseDoubleClick += TreeView_NodeMouseDoubleClick;

                treeView.ItemDrag += ItemDrag;
                treeView.DragEnter += DragEnter;
                treeView.DragOver += DragOver;
                treeView.DragDrop += DragDrop;

                treeView.AfterLabelEdit += AfterLabelEdit;
            }

            private static void AfterLabelEdit(object sender, System.Windows.Forms.NodeLabelEditEventArgs e)
            {
                try
                {
                    System.IO.FileAttributes attr = System.IO.File.GetAttributes(e.Node.Name);

                    if (attr.HasFlag(System.IO.FileAttributes.Directory))
                    {
                        Microsoft.VisualBasic.FileIO.FileSystem.RenameDirectory(e.Node.Name, e.Label);
                    }
                    else
                    {
                        Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(e.Node.Name, e.Label);
                    }
                    e.Node.EndEdit(false);
                    treeView.LabelEdit = false;
                }
                catch (System.Exception exception)
                {
                    System.Windows.Forms.MessageBox.Show(exception.Message, "List");
                    e.CancelEdit = true;
                    e.Node.BeginEdit();
                }
            }

            private static void BeforeCollapse(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
            {
                if (e.Node.ImageKey.Contains("Server"))
                {
                    e.Cancel = true;
                }
                else
                {
                    e.Node.Nodes.Clear();
                    if (System.IO.Directory.GetDirectories(e.Node.Name).Length != 0 || System.IO.Directory.GetFiles(e.Node.Name).Length != 0)
                    {
                        e.Node.Nodes.Add(@"<\>");
                    }

                    if (e.Node.ImageKey.Contains("Folder"))
                    {
                        e.Node.ImageKey = "localFolder";
                        e.Node.SelectedImageKey = "localFolder";
                        e.Node.StateImageKey = "localFolder";
                    }
                }
            }

            private static void BeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
            {
                e.Node.Nodes.Clear();

                if (e.Node.ImageKey.Contains("Server"))
                {
                    foreach (string path in System.IO.Directory.GetDirectories(e.Node.Name))
                    {
                        Project project = new Project(path);
                        e.Node.Nodes.Add(project);
                    }
                }
                else if (e.Node.ImageKey.Contains("Project"))
                {
                    ((Project)e.Node).Populate();
                }
                else
                {
                    ((Project.Content)e.Node).Populate();

                    if (e.Node.ImageKey.Contains("Folder"))
                    {
                        e.Node.ImageKey = "localFolderOpen";
                        e.Node.SelectedImageKey = "localFolderOpen";
                        e.Node.StateImageKey = "localFolderOpen";
                    }
                }
            }

            private static void TreeView_NodeMouseClick(object sender, System.Windows.Forms.TreeNodeMouseClickEventArgs e)
            {
                treeView.SelectedNode = e.Node;
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    if (treeView.SelectedNode.ImageKey.Contains("Folder"))
                    {
                        treeView.folderContextMenuStrip.Show(treeView, e.Location);
                    }
                    else
                    {
                        treeView.fileContextMenuStrip.Show(treeView, e.Location);
                    }
                }
            }

            private static void TreeView_NodeMouseDoubleClick(object sender, System.Windows.Forms.TreeNodeMouseClickEventArgs e)
            {
                if (e.Node.ImageKey.Contains("Document"))
                {
                    try
                    {
                        System.Diagnostics.Process.Start(e.Node.Name);
                    }
                    catch (System.Exception exception)
                    {
                        System.Windows.Forms.MessageBox.Show("Couldn't exec: " + exception.Message, "List", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    }
                }
            }

            private static void ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
            {
                treeView.SelectedNode = (System.Windows.Forms.TreeNode)e.Item;
                
                if (e.Item is Project.Content)
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        treeView.DoDragDrop(e.Item, System.Windows.Forms.DragDropEffects.Move);
                    }
                }
            }

            private static void DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
            {
                treeView.Focus();

                if (e.Data.GetDataPresent(typeof(Project.Content)))
                {
                    e.Effect = System.Windows.Forms.DragDropEffects.Move;
                }
                else
                {
                    e.Effect = System.Windows.Forms.DragDropEffects.Copy;
                }
            }

            private static void DragOver(object sender, System.Windows.Forms.DragEventArgs e)
            {
                System.Drawing.Point point = treeView.PointToClient(new System.Drawing.Point(e.X, e.Y));
                System.Windows.Forms.TreeNode target = treeView.GetNodeAt(point);
                
                if (target != null)
                {
                    treeView.SelectedNode = target;
                    if (target.ImageKey.Contains("Server"))
                    {
                        e.Effect = System.Windows.Forms.DragDropEffects.None;
                    }
                    else
                    {
                        if (e.Data.GetDataPresent(typeof(Project.Content)))
                        {
                            e.Effect = System.Windows.Forms.DragDropEffects.Move;
                        }
                        else
                        {
                            e.Effect = System.Windows.Forms.DragDropEffects.Copy;
                        }
                    }
                }
            }

            private static void DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
            {
                System.Drawing.Point point = treeView.PointToClient(new System.Drawing.Point(e.X, e.Y));
                System.Windows.Forms.TreeNode target = treeView.GetNodeAt(point);

                if (e.Data.GetDataPresent(typeof(Project.Content)))
                {
                    Project.Content source = (Project.Content)e.Data.GetData(typeof(Project.Content));
                    if (source != target)
                    {
                        if (target.ImageKey.Contains("Document"))
                        {
                            target = target.Parent;
                        }

                        if (source.Name != target.Name + @"\" + source.Text)
                        {
                            if (source.ImageKey.Contains("Folder"))
                            {
                                Microsoft.VisualBasic.FileIO.FileSystem.MoveDirectory(source.Name, target.Name + @"\" + source.Text, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing);
                            }
                            else
                            {
                                Microsoft.VisualBasic.FileIO.FileSystem.MoveFile(source.Name, target.Name + @"\" + source.Text, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing);
                            }
                        }
                    }
                }
                else
                {
                    
                }


                
            }
        }
    }
}
