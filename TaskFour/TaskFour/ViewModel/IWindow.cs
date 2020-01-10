namespace ViewModel.Interfaces
{
    public interface IWindow
    {
        void Show();
        void Close();
        void ShowPopup(string message);
    }
}