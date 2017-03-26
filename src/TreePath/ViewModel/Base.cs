namespace CSMS.TreePath.ViewModel
{
    public abstract class Base : MVVM.ViewModel.Base
    {
        public Base()
        {
            ItemSource = new System.Collections.ObjectModel.ObservableCollection<Kind.Root>();
        }

        public System.Collections.ObjectModel.ObservableCollection<Kind.Root> ItemSource
        {
            get
            {
                return this.ItemSourceProperty;
            }
            set
            {
                this.ItemSourceProperty = value;
                this.OnPropertyChanged("ProjectControlTreePathDataContext.ItemSource");
            }

        }
        private System.Collections.ObjectModel.ObservableCollection<Kind.Root> ItemSourceProperty;
    }
}
