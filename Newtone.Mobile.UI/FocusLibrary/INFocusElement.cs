namespace Nejman.Xamarin.FocusLibrary
{
    public interface INFocusElement
    {
        INFocusElement NextFocusLeft { get; set; }
        INFocusElement NextFocusRight { get; set; }
        INFocusElement NextFocusUp { get; set; }
        INFocusElement NextFocusDown { get; set; }
        INFocusElement PrevionsElement { get; set; }
        bool IsNFocused { get; set; }

        void FocusLeft();
        void FocusRight();
        void FocusUp();
        void FocusDown();
        void FocusAction();
    }
}
