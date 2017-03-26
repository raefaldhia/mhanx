using System.Linq;

namespace CSMS.TreePath.Kind
{
    public class Root : ExpandableBase
    {
        public Root(string path) : base(null, path)
        {
            this.FileSystemWatcher = new System.IO.FileSystemWatcher(path, "*");

            this.FileSystemWatcher.Created += FileSystemWatcher_Created;
            this.FileSystemWatcher.Deleted += FileSystemWatcher_Deleted;
            this.FileSystemWatcher.Renamed += FileSystemWatcher_Renamed;
            this.FileSystemWatcher.IncludeSubdirectories = true;
            this.FileSystemWatcher.EnableRaisingEvents = true;
        }

        ~Root()
        {
            this.FileSystemWatcher.Dispose();
        }

        private void FileSystemWatcher_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            string RelativePath = System.IO.Path.GetDirectoryName(e.Name);
            System.IO.FileAttributes FileAttributes = System.IO.File.GetAttributes(e.FullPath);
            App.Current.Dispatcher.Invoke(delegate {
                ExpandableBase parent = this;

                if (!System.String.IsNullOrEmpty(RelativePath))
                {
                    parent = (ExpandableBase)this.Find(RelativePath, true);
                    if (parent == null)
                    {
                        return;
                    }
                }

                if (parent.IsExpanded)
                {
                    if (FileAttributes.HasFlag(System.IO.FileAttributes.Directory))
                    {
                        parent.ItemsSource.Add(new Folder(parent, e.FullPath));
                    }
                    else
                    {
                        parent.ItemsSource.Add(new File(parent, e.FullPath));
                    }
                }
                else
                {
                    parent.ClearItemsSource();
                }
            });
        }

        private void FileSystemWatcher_Deleted(object sender, System.IO.FileSystemEventArgs e)
        {
            string RelativePath = System.IO.Path.GetDirectoryName(e.Name);
            App.Current.Dispatcher.Invoke(delegate {
                ExpandableBase parent = this;
                if (!System.String.IsNullOrEmpty(RelativePath))
                {
                    parent = (ExpandableBase)this.Find(RelativePath, true);
                    if (parent == null)
                    {
                        return;
                    }

                    Dummy item = parent.Find(System.IO.Path.GetFileName(RelativePath), true);
                    if (item != null)
                    {
                        parent.ItemsSource.Remove(item);
                    }
                    if (!parent.ItemsSource.Any())
                    {
                        parent.Parent.IsExpanded = false;
                    }
                }
            });

        }

        private void FileSystemWatcher_Renamed(object sender, System.IO.RenamedEventArgs e)
        {
            App.Current.Dispatcher.Invoke(delegate
            {

            });
        }
        private System.IO.FileSystemWatcher FileSystemWatcher;
    }

    public class File : Base
    {
        public File(ExpandableBase parent, string path) : base(parent, path)
        {

        }
    }

    public class Folder : ExpandableBase
    {
        public Folder(ExpandableBase parent, string path) : base(parent, path)
        {

        }
    }

    public abstract class ExpandableBase : Base
    {
        public ExpandableBase(ExpandableBase parent, string path) : base (parent, path)
        {
            ItemsSourceProperty = new System.Collections.ObjectModel.ObservableCollection<Dummy>();

            this.ClearItemsSource();
        }

        #region ItemSource

        public System.Collections.ObjectModel.ObservableCollection<Dummy> ItemsSource
        {
            get { return this.ItemsSourceProperty; }
            set
            {
                this.ItemsSourceProperty = value;
                this.OnPropertyChanged("TrePath.Kind.ExpandableBase.ItemSource");
            }
        }
        private System.Collections.ObjectModel.ObservableCollection<Dummy> ItemsSourceProperty;

        #endregion
        
        public override bool IsExpanded
        {
            get { return this.IsExpandedProperty; }
            set
            {
                if (this.IsExpandedProperty != value)
                {
                    this.IsExpandedProperty = value;
                    this.OnPropertyChanged("ExpandableBase.Expanded");
                }
                if (this.IsExpandedProperty == true)
                {
                    this.UpdateItemsSource();
                    if (this.ItemsSource.Any() == false)
                    {
                        this.IsExpandedProperty = false;
                        this.OnPropertyChanged("ExpandableBase.Expanded");
                    }
                }
                else if (this.IsExpandedProperty == false)
                {
                    this.ClearItemsSource();
                }
            }
        }

        public void UpdateItemsSource()
        {
            this.ItemsSource.Clear();

            foreach (string path in this.GetDirectories())
            {
                this.ItemsSource.Add(new Folder(this, path));
            }
            foreach (string path in this.GetFiles())
            {
                this.ItemsSource.Add(new File(this, path));
            }
        }

        public void ClearItemsSource()
        {
            this.ItemsSource.Clear();
            if (this.Any())
            {
                Dummy dummy = new Dummy();
                this.ItemsSource.Add(dummy);
            }
        }

        public Dummy Find(string str, bool isPath)
        {
            string temp = str;
            if (isPath)
            {
                int idx = str.IndexOf(@"\");
                if (idx == -1)
                {
                    isPath = false;
                }
                else
                {
                    temp = temp.Substring(0, idx);
                    str = str.Replace(temp + @"\", "");
                }
            }
            foreach (Dummy item in ItemsSource)
            {
                if (item.Header.Equals(temp))
                {
                    if (isPath)
                    {
                        if (item is ExpandableBase)
                        {
                            return ((ExpandableBase)item).Find(str, true);
                        }
                        return null;
                    }
                    else
                    {
                        return item;
                    }
                }
            }
            return null;
        }

        private bool Any()
        {
            return System.IO.Directory.EnumerateFileSystemEntries(this.Path).Any();
        }

        public string[] GetFiles()
        {
            string[] files = System.IO.Directory.GetFiles(this.Path);
            System.Array.Sort(files);
            return files;
        }

        public string[] GetDirectories()
        {
            string[] directories = System.IO.Directory.GetDirectories(this.Path);
            System.Array.Sort(directories);
            return directories;
        }
    }

    public abstract class Base : Dummy
    {
        public Base(ExpandableBase parent, string path)
        {
            this.Path = path;
            this.Header = System.IO.Path.GetFileName(this.Path);
            this.Parent = parent;
        }
        public string Path { get; set; }
        public ExpandableBase Parent { get; set; }
        public virtual bool IsExpanded
        {
            get { return IsExpandedProperty; }
            set
            {
                IsExpandedProperty = false;
                this.OnPropertyChanged("Base.Expanded");
            }
        }
        protected bool IsExpandedProperty;
    }

    public class Dummy : MVVM.ViewModel.Base
    {
        public Dummy()
        {
            this.Header = "dummy";
        }
        public string Header { get; set; }
    }
}
