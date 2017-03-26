namespace CSMS.MVVM.ViewModel
{
    public abstract class Base : System.ComponentModel.INotifyPropertyChanged
    {
        protected void OnPropertyChanged(string propertyName)
        {
            this.OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged(System.ComponentModel.PropertyChangedEventArgs e)
        {
            // var handler = this.PropertyChanged; if (handler != null) { handler(this, e); }
            this.PropertyChanged?.Invoke(this, e);
        }
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    }
}
