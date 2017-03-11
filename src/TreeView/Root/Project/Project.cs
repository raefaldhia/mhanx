using System.Linq;

namespace Mhanxx
{
    partial class TreeView
    {
        private partial class Project : System.Windows.Forms.TreeNode
        {
            public Project(string projectPath)
            {
                this.Name = projectPath;
                this.Text = System.IO.Path.GetFileName(this.Name);

                this.ImageKey = "Project";
                this.SelectedImageKey = "Project";
                this.StateImageKey = "Project";

                while (true)
                {
                    try
                    {
                        if (System.IO.Directory.EnumerateFileSystemEntries(this.Name).Any())
                        {
                            this.Nodes.Add(@"<\>");
                        }
                        break;
                    }
                    catch (System.IO.IOException)
                    {
                        System.Threading.Thread.Sleep(100);
                    }
                }
                this.Expand();

                eventHandler = new Event(this);
            }

            ~Project()
            {
                // eventHandler.Dispose();
            }

            public void Populate()
            {
                Content content;
                foreach (string path in System.IO.Directory.GetDirectories(this.Name))
                {
                    if (!path.Contains(".git"))
                    {
                        content = new Content(Content.Type.Folder, path);
                        this.Nodes.Add(content);

                        if (System.IO.Directory.EnumerateFileSystemEntries(path).Any())
                        {
                            content.Nodes.Add(@"<\>");
                        }

                    }
                }
                foreach (string path in System.IO.Directory.GetFiles(this.Name))
                {
                    content = new Content(Content.Type.File, path);
                    this.Nodes.Add(content);
                }
            }

            public void Rename(string newName)
            {
                string oldName = this.Name;

                this.Name = newName;
                this.Text = System.IO.Path.GetFileName(this.Name);

                if (this.IsExpanded)
                {
                    foreach (Content content in this.Nodes)
                    {
                        content.ReplacePath(oldName, newName);
                    }
                }
            }

            public Event eventHandler;
        }
    }
}
