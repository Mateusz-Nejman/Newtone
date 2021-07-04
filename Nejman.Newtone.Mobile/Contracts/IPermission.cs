namespace Nejman.Newtone.Mobile.Contracts
{
    public interface IPermission
    {
        bool IsValid();
        void Request();
    }
}
