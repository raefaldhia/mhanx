namespace Mhanxx
{
    public partial class treeViewControl : System.Windows.Forms.UserControl
    {
        public treeViewControl()
        {
            InitializeComponent();

            TreeView.InitializeComponent(this.treeView);
        }
    }
}