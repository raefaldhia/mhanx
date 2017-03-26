namespace CSMS.Content
{
    public class ProjectControlDataContext : DataContextBase
    {
        public ProjectControlDataContext()
        {
            TreeView_ItemsSource = new System.Collections.ObjectModel.ObservableCollection<TreePath.Kind.Root>();
            this.Name = "CSMS";
            this.IconName = "ViewList";
            
            string path = System.AppDomain.CurrentDomain.BaseDirectory + "CSMS";
            System.IO.Directory.CreateDirectory(path);
            TreeView_ItemsSource.Add(new TreePath.Kind.Root(path));
        }

        public System.Collections.ObjectModel.ObservableCollection<TreePath.Kind.Root> TreeView_ItemsSource
        {
            get { return this.TreeView_ItemsSourceProperty; }
            set
            {
                this.TreeView_ItemsSourceProperty = value;
                this.OnPropertyChanged("ProjectControlDataContext.TreeView_ItemsSource");
            }
        }
        private System.Collections.ObjectModel.ObservableCollection<TreePath.Kind.Root> TreeView_ItemsSourceProperty;
    }
}