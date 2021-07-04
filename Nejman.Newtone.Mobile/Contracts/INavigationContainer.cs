namespace Nejman.Newtone.Mobile.Contracts
{
    public interface INavigationContainer
    {
        void Block();
        void Unblock();
        bool IsBlocked();
    }
}
