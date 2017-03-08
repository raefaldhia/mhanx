namespace Mhanxx
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var form = new About();
            form.Show();
        }
    }
}
