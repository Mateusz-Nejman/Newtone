namespace Newtone.Core.Logic
{
    public interface INavigationContainer
    {
        void Block();
        void Unblock();
        bool IsBlocked();
    }
}
