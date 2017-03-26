namespace CSMS.TreePath.Controls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class Tree : System.Windows.Controls.TreeView
    {
        public Tree()
        {
            InitializeComponent();

            this.DataContextChanged += OnDataContextChanged;
        }

        private void OnDataContextChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            if (this.DataContext is ViewModel.Base)
            {
                this.ItemsSource = ((ViewModel.Base)this.DataContext).ItemSource;
            }
        }

        #region TreeView Override

        #region TreeViewItem

        protected override System.Windows.DependencyObject GetContainerForItemOverride()
        {
            return new Item();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is Item;
        }

        #endregion

        #endregion
    }
}
