namespace Mhanxx
{
    public partial class TreeView
    {
        private partial class Root : System.Windows.Forms.TreeNode
        {
            public Root(Type type)
            {
                if (type == Type.Remote)
                {
                    throw new System.NotImplementedException();
                }
                this.type = type;

                this.Name = System.AppDomain.CurrentDomain.BaseDirectory + "Project";
                this.Text = "Local Server";

                this.ImageKey = "localServer";
                this.SelectedImageKey = "localServer";
                this.StateImageKey = "localServer";

                // Create directory if not exist
                System.IO.Directory.CreateDirectory(this.Name);

                foreach (string path in System.IO.Directory.GetDirectories(this.Name))
                {
                    this.Nodes.Add(@"<\>");
                }
                this.Expand();
                eventHandler = new Event(this);
                filesystemwatcherHandler = new FileSystemWatcher(this);
            }

            ~Root()
            {
                // eventHandler.Dispose();
                filesystemwatcherHandler.Dispose();
            }

            private void Populate()
            {
                foreach (string path in System.IO.Directory.GetDirectories(this.Name))
                {
                    Project project = new Project(path);
                    this.Nodes.Add(project);
                }
            }

            public enum Type { Local, Remote };
            private Type type;

            public Event eventHandler;
            private FileSystemWatcher filesystemwatcherHandler;
        }
    }
}
