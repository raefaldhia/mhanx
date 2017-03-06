namespace Mhanxx
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [System.STAThread]
        static void Main()
        {
            using (System.Threading.Mutex mutex = new System.Threading.Mutex(false, "Global\\" + "29ebb741-45c6-48fa-88fb-6282c0afcab9"))
            {
                if (!mutex.WaitOne(0, false))
                {
                    System.Windows.Forms.MessageBox.Show("List already running!", "List", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    return;
                }
                System.Windows.Forms.Application.EnableVisualStyles();
                System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                System.Windows.Forms.Application.Run(new MainForm());
            }
        }
    }
}
