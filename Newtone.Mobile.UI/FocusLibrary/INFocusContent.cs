namespace Nejman.Xamarin.FocusLibrary
{
    public interface INFocusContent
    {
        INFocusElement TopElement { get; set; }
        INFocusElement BottomElement { get; set; }
    }
}
