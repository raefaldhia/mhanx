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

                private Project project;
            }
        }
    }
}
