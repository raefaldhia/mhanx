namespace Mhanxx
{
    public partial class TreeView
    {
        private class Event
        {
            private TreeView treeView;

            public Event(TreeView src)
            {
                treeView = src;

          //      treeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(NodeMouseDoubleClick);
                /*
                treeviewControl.treeView.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(BeforeSelect);
                treeviewControl.treeView.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(BeforeCollapse);
                treeviewControl.treeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(BeforeExpand);



                treeviewControl.treeView.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(AfterLabelEdit);

                treeviewControl.treeView.ItemDrag += TreeView_ItemDrag;
                treeviewControl.treeView.DragEnter += TreeView_DragEnter;
                treeviewControl.treeView.DragOver += TreeView_DragOver;
                treeviewControl.treeView.DragDrop += TreeView_DragDrop;
                */
            }
            /*
                           private static void TreeView_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
                            {
                                System.Drawing.Point target = treeviewControl.treeView.PointToClient(new System.Drawing.Point(e.X, e.Y));
                                treeviewControl.treeView.SelectedNode = treeviewControl.treeView.GetNodeAt(target);

                                System.IO.FileAttributes attr = System.IO.File.GetAttributes(treeviewControl.treeView.SelectedNode.Name);
                                if (!attr.HasFlag(System.IO.FileAttributes.Directory))
                                {
                                    treeviewControl.treeView.SelectedNode = treeviewControl.treeView.SelectedNode.Parent;
                                }

                                System.Windows.Forms.TreeNode draggedNode = (System.Windows.Forms.TreeNode)e.Data.GetData(typeof(System.Windows.Forms.TreeNode));

                                attr = System.IO.File.GetAttributes(draggedNode.Name);
                                if (attr.HasFlag(System.IO.FileAttributes.Directory) && !draggedNode.Name.Equals(treeviewControl.treeView.SelectedNode.Name))
                                {
                                    try
                                    {
                                        Microsoft.VisualBasic.FileIO.FileSystem.MoveDirectory(draggedNode.Name, treeviewControl.treeView.SelectedNode.Name + @"\" + draggedNode.Text, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs);
                                    }
                                    catch (System.IO.IOException)
                                    {
                                        System.Windows.Forms.MessageBox.Show("Cannot move '" + draggedNode.Text + "' the destination folder is the same as the source folder", "List", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    Microsoft.VisualBasic.FileIO.FileSystem.MoveFile(draggedNode.Name, treeviewControl.treeView.SelectedNode.Name + @"\" + draggedNode.Text, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing);
                                }
                            }

                            private static void TreeView_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
                            {
                                System.Drawing.Point target = treeviewControl.treeView.PointToClient(new System.Drawing.Point(e.X, e.Y));
                                treeviewControl.treeView.SelectedNode = treeviewControl.treeView.GetNodeAt(target);
                            }

                            private static void TreeView_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
                            {
                                e.Effect = e.AllowedEffect;
                            }

                            private static void TreeView_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
                            {
                                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                                {
                                    treeviewControl.treeView.DoDragDrop(e.Item, System.Windows.Forms.DragDropEffects.Move);
                                }
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

                            static private void AfterLabelEdit(object sender, System.Windows.Forms.NodeLabelEditEventArgs e)
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
                                    treeviewControl.treeView.LabelEdit = false;
                                }
                                catch (System.Exception exception)
                                {
                                    System.Windows.Forms.MessageBox.Show(exception.Message, "List");
                                    e.CancelEdit = true;
                                    e.Node.BeginEdit();
                                }
                            }
             */
        }
    }
}