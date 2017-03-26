namespace CSMS.TreePath.Controls
{
    /// <summary>
    /// Interaction logic for Item.xaml
    /// </summary>
    public partial class Item : System.Windows.Controls.TreeViewItem
    {
        public Item()
        {
            InitializeComponent();

            this.DataContextChanged += OnDataContextChanged;

            this.Collapsed += OnCollapsed;
            this.Expanded += OnExpanded;
        }

        private void OnDataContextChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            if (this.DataContext is Kind.Folder)
            {/*
                this.ItemsSource = ((Kind.Folder)this.DataContext).ItemSource;
                if (((Kind.Folder)this.DataContext).RequestDummyCommand.CanExecute(null) == true)
                {
                    ((Kind.Folder)this.DataContext).RequestDummyCommand.Execute(null);
                }*/
            }
        }

        private void OnExpanded(object sender, System.Windows.RoutedEventArgs e)
        {
            
        //    Item item = e.Source as Item;

         //   if (item != null)
           // {
                System.Windows.MessageBox.Show(e.Source.ToString());
        //    }
            //Item item = e.Source as Item;
            //
            //if ((item.DataContext != null) || (item.DataContext is Kind.Folder))
            //{
            //    if (((Kind.Folder)item.DataContext).RequestItemSourceUpdateCommand.CanExecute(null) == true)
            //    {
            //        ((Kind.Folder)item.DataContext).RequestItemSourceUpdateCommand.Execute(null);
            //    }
            //}
        }
        private void OnCollapsed(object sender, System.Windows.RoutedEventArgs e)
        {/*
            Item item = e.Source as Item;
            
            if ((item.DataContext != null) || item.DataContext is Kind.Folder)
            {
                if (((Kind.Folder)item.DataContext).RequestDummyCommand.CanExecute(null) == true)
                {
                    ((Kind.Folder)item.DataContext).RequestDummyCommand.Execute(null);
                }
            }*/
        }
        #region TreeViewItem Override

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
