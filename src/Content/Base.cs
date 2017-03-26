namespace CSMS.Content
{
    public abstract class DataContextBase : MVVM.ViewModel.Base
    {
        public string Name { get; set; }
        public string IconName { get; protected set; }
    }
}
