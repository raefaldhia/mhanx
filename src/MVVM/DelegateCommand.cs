namespace CSMS.MVVM.ViewModel
{
    public class DelegateCommand<T> : System.Windows.Input.ICommand
    {
        public DelegateCommand(System.Action<object, T> action)
        {
            this.Action = action;
        }
        private readonly System.Action<object, T> Action;

        public event System.EventHandler CanExecuteChanged;

        public void Execute(object sender, T e)
        {
            this.Action(sender, e);
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            throw new System.NotImplementedException();
        }
    }
}
