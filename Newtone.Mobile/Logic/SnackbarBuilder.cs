using Android.Widget;

namespace Newtone.Mobile.Logic
{
    public class SnackbarBuilder
    {
        #region Public Methods
        public static void Show(string text)
        {
            MainActivity.Instance.RunOnUiThread(() => Toast.MakeText(MainActivity.Instance, text, ToastLength.Short).Show());
        }
        #endregion
    }
}