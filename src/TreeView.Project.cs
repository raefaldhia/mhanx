namespace Mhanxx
{
    partial class TreeView
    {
        private partial class Project : System.Windows.Forms.TreeNode
        {
            public Project(string projectDir)
            {
                this.Name = projectDir;
                this.Text = System.IO.Path.GetFileName(projectDir);

                this.ImageKey = "Project";
                this.SelectedImageKey = "Project";
                this.StateImageKey = "Project";

                //
                // Check if directory already exist and have content inside it
                //
                if (System.IO.Directory.GetDirectories(this.Name).Length != 0 || System.IO.Directory.GetFiles(this.Name).Length != 0)
                {
                    this.Nodes.Add(@"<\>");
                    this.Expand();
                }
                    
                //
                // Add FileSystemWatcher
                //
                FileSystemWatcher.Register(this);
            }

            public void Populate()
            {
                Content content;
                foreach (string path in System.IO.Directory.GetDirectories(this.Name))
                {
                    content = new Content(Content.Type.Folder, path);
                    this.Nodes.Add(content);

                    if (System.IO.Directory.GetDirectories(path).Length != 0 || System.IO.Directory.GetFiles(path).Length != 0)
                    {
                        content.Nodes.Add(@"<\>");
                    }
                }
                foreach (string path in System.IO.Directory.GetFiles(this.Name))
                {
                    content = new Content(Content.Type.File, path);
                    this.Nodes.Add(content);
                }
            }
            
            public class Content : System.Windows.Forms.TreeNode
            {
                public enum Type {Folder, File};

                public Content(Type type, string path)
                {
                    this.Name = path;
                    this.Text = System.IO.Path.GetFileName(this.Name);

                    if (type == Type.Folder)
                    {
                        this.ImageKey = "localFolder";
                        this.SelectedImageKey = "localFolder";
                        this.StateImageKey = "localFolder";
                    }
                    else
                    {
                        this.ImageKey = "localDocument";
                        this.SelectedImageKey = "localDocument";
                        this.StateImageKey = "localDocument";
                    }
                }

                public void Populate()
                {
                    Content content;
                    foreach (string path in System.IO.Directory.GetDirectories(this.Name))
                    {
                        content = new Content(Content.Type.Folder, path);
                        this.Nodes.Add(content);

                        if (System.IO.Directory.GetDirectories(path).Length != 0 || System.IO.Directory.GetFiles(path).Length != 0)
                        {
                            content.Nodes.Add(@"<\>");
                        }
                    }
                    foreach (string path in System.IO.Directory.GetFiles(this.Name))
                    {
                        content = new Content(Content.Type.File, path);
                        this.Nodes.Add(content);
                    }
                }

                public void Rename(string oldName, string newName)
                {
                    this.Name = this.Name.Replace(oldName, newName);
                    this.Text = this.Name;//System.IO.Path.GetFileName(this.Name);

                    if (this.ImageKey.Contains("Folder") && this.IsExpanded)
                    {
                        foreach (Content child in this.Nodes)
                        {
                            child.Rename(oldName, newName);
                        }
                    }
                }
            }
        }
    }
}
