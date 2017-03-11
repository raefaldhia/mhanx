using System.Linq;

namespace Mhanxx
{
    partial class TreeView
    {
        private partial class Project
        {
            public class Event
            {
                public Event(Project project)
                {
                    this.project = project;
                }

                public void BeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
                {
                    e.Node.Nodes.Clear();
                    ((Project)e.Node).Populate();
                }

                public void BeforeCollapse(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
                {
                    e.Node.Nodes.Clear();

                    if (System.IO.Directory.EnumerateFileSystemEntries(e.Node.Name).Any())
                    {
                            e.Node.Nodes.Add(@"<\>");
                    }
                }

                public void AfterLabelEdit(object sender, System.Windows.Forms.NodeLabelEditEventArgs e)
                {
                    try
                    {
                        Microsoft.VisualBasic.FileIO.FileSystem.RenameDirectory(e.Node.Name, e.Label);
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
                        ((TreeView)e.Node.TreeView).projectContextMenuStrip.Show(e.Node.TreeView, e.Location);
                    }
                }

                private Project project;
            }
        }
    }
}
