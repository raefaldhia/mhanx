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

                    private Content content;
                }
            }
        }
    }
}