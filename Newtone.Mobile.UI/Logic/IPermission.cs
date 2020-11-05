namespace Newtone.Mobile.UI.Logic
{
    public interface IPermission
    {
        bool IsValid();
        void Request();
    }
}
