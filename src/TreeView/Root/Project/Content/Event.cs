using System.Linq;

namespace Mhanxx
{
    public partial class TreeView
    {
        private partial class Project
        {
            public partial class Content
            {
                public class Event
                {
                    public Event(Content content)
                    {
                        this.content = content;
                    }

                    public void BeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
                    {
                        e.Node.Nodes.Clear();
                        ((Content)e.Node).Populate();

                        if (((Content)e.Node).type == Type.Folder)
                        {
                            e.Node.ImageKey = "localFolderOpen";
                            e.Node.SelectedImageKey = "localFolderOpen";
                            e.Node.StateImageKey = "localFolderOpen";
                        }
                    }

                    public void BeforeCollapse(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
                    {
                        e.Node.Nodes.Clear();
                        if (System.IO.Directory.EnumerateFileSystemEntries(e.Node.Name).Any())
                        {
                            e.Node.Nodes.Add(@"<\>");
                        }
                        if (((Content)e.Node).type == Type.Folder)
                        {

                            e.Node.ImageKey = "localFolder";
                            e.Node.SelectedImageKey = "localFolder";
                            e.Node.StateImageKey = "localFolder";
                        }
                    }

                    public void AfterLabelEdit(object sender, System.Windows.Forms.NodeLabelEditEventArgs e)
                    {
                        try
                        {
                            if (content.type == Type.Folder)
                            { 
                                Microsoft.VisualBasic.FileIO.FileSystem.RenameDirectory(e.Node.Name, e.Label);
                            }
                            else
                            {
                                Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(e.Node.Name, e.Label);
                            }
                            e.Node.EndEdit(false);
                            e.Node.TreeView.LabelEdit = false;
                        }
                        catch (System.Exception exception)
                        {
                            System.Windows.Forms.MessageBox.Show(exception.Message, "List");
                            e.CancelEdit = true;
                            e.Node.BeginEdit();
                        }
                    }

                    public void NodeMouseClick(object sender, System.Windows.Forms.TreeNodeMouseClickEventArgs e)
                    {
                        if (e.Button == System.Windows.Forms.MouseButtons.Right)
                        {
                            
                            if (((Content)e.Node).type == Type.Folder)
                            {
                                ((TreeView)e.Node.TreeView).contentFolderContextMenuStrip.Show(e.Node.TreeView, e.Location);
                            }
                            else
                            {
                                ((TreeView)e.Node.TreeView).contentFileContextMenuStrip.Show(e.Node.TreeView, e.Location);
                            }
                        }
                    }
                    private Content content;
                }
            }
        }
    }
}