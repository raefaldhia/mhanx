namespace Mhanxx
{
    public partial class TreeView
    {
        private partial class Root
        {
            public class Event
            {
                public Event(Root root)
                {
                    this.root = root;
                }

                public void BeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
                {
                    e.Node.Nodes.Clear();

                    ((Root)e.Node).Populate();
                }

                public void BeforeCollapse(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
                {
                    e.Cancel = true;
                }

                private Root root;
            }
        }
    }
}
