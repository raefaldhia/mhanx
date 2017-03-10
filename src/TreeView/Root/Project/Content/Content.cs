using System.Linq;

namespace Mhanxx
{
    public partial class TreeView
    {
        private partial class Project
        {
            public partial class Content : System.Windows.Forms.TreeNode
            {
                public Content(Type type, string path)
                {
                    this.type = type;

                    this.Name = path;
                    this.Text = System.IO.Path.GetFileName(this.Name);

                    if (this.type == Type.Folder)
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
                    eventHandler = new Event(this);
                }

                public void Populate()
                {
                    Content content;
                    foreach (string path in System.IO.Directory.GetDirectories(this.Name))
                    {
                        content = new Content(Type.Folder, path);
                        this.Nodes.Add(content);

                        if (System.IO.Directory.EnumerateFileSystemEntries(content.Name).Any())
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

                public void ReplacePath(string oldPath, string newPath)
                {
                    this.Name = this.Name.Replace(oldPath, newPath);
                    this.Text = System.IO.Path.GetFileName(this.Name);

                    if (this.type == Type.Folder && this.IsExpanded)
                    {
                        foreach (Content child in this.Nodes)
                        {
                            child.ReplacePath(oldPath, newPath);
                        }
                    }
                }

                private Type type;
                public Event eventHandler;

                public enum Type { Folder, File };
            }
        }
    }
}