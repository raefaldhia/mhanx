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
        }
    }
}
