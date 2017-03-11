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


                public void NodeMouseClick(object sender, System.Windows.Forms.TreeNodeMouseClickEventArgs e)
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Right)
                    {
                        ((TreeView)e.Node.TreeView).rootContextMenuStrip.Show(e.Node.TreeView, e.Location);
                    }
                }

                private Root root;
            }
        }
    }
}
