namespace Newtone.Mobile.UI.Logic
{
    public interface IApplication
    {
        string GetVersion();
        bool HasInternet();
        void ShowSnackbar(string message);
        void AddFolderToScan();
    }
}
