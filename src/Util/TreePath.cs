namespace CSMS.Util.TreePath
{
    public class Root : System.Windows.Controls.TreeViewItem
    {
        public Root(string name, string path)
        {
            if (!System.IO.Directory.Exists(path))
            {
                throw new System.IO.DirectoryNotFoundException();
            }
            this.Header = name;
            this.Path = path;

            this.Populate();

            filesystemwatcherHandler = new FileSystemWatcher(this);
        }

        ~Root()
        {
            filesystemwatcherHandler.Dispose();
        }

        public void Populate()
        {
            foreach (string path in System.IO.Directory.GetDirectories(this.Name))
            {
                if (this.IsExpanded == false)
                {
                    this.Items.Add(@"<\>");
                    break;
                }
                Folder item = new Folder(path);
                this.Items.Add(item);
            }
        }
        public string Path { get; private set; }

        private class FileSystemWatcher : System.IO.FileSystemWatcher
        {
            public FileSystemWatcher(Root root) : base(root.Name, "*")
            {
                this.root = root;
                
                //this.Renamed += OnRenamed;
                this.Created += OnCreated;
                //this.Deleted += OnDeleted;

                this.IncludeSubdirectories = true;
                this.EnableRaisingEvents = true;
            }

            private void OnCreated(object sender, System.IO.FileSystemEventArgs e)
            {
            //  System.Windows.Application.Current.Dispatcher.Invoke(delegate {
            //  });
            }

            private Root root { get; set; }
        }
        private FileSystemWatcher filesystemwatcherHandler { get; set; }

        public abstract class Item : System.Windows.Controls.TreeViewItem
        {
            public Item(string path)
            {
                this.Path = path;
                this.Header = System.IO.Path.GetFileName(this.Path);
            }

            public string Path { get; set; }
        }
    }



    public class File : Root.Item
    {
        public File(string path) : base (path)
        {

        }
    }

    public class Folder : Root.Item
    {
        public Folder(string path) : base(path)
        {
            this.Header = "a";
        }
    }

    public class TemplateSelector : System.Windows.Controls.DataTemplateSelector
    {
        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            System.Windows.FrameworkElement element = container as System.Windows.FrameworkElement;

            if (element != null && item != null)
            {
                if (item is File)
                {
                    return element.FindResource("file") as System.Windows.DataTemplate;
                }
                else if (item is Folder)
                {
                    return element.FindResource("folder") as System.Windows.DataTemplate;
                }
            }
            return null;
        }
    }
}
