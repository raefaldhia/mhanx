namespace CSMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new setting();
        }

        private class setting : MVVM.ViewModel.Base
        {
            public setting()
            {
                Content = new content();
            }

            public System.Collections.Generic.List<System.Windows.Controls.UserControl> NavItem
            {
                get
                {
                    return this.Content.NavItem;
                }
                set
                {
                    this.Content.NavItem = value;
                    this.OnPropertyChanged("Content.NavItem");
                }
            }

            private class content
            {
                public content()
                {
                    NavItem = new System.Collections.Generic.List<System.Windows.Controls.UserControl>();

                    NavItem.Add(new Content.Home());
                    NavItem.Add(new Content.ProjectControl());
                }

                public System.Collections.Generic.List<System.Windows.Controls.UserControl> NavItem { get; set; }
            }
            private content Content { get; set; }
        }
    }
}
