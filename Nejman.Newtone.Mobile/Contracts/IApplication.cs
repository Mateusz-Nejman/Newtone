namespace Nejman.Newtone.Mobile.Contracts
{
    public interface IApplication
    {
        string GetVersion();
        bool HasInternet();
        void AddFolderToScan();
    }
}
