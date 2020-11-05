using Android.Content;
using Java.Lang;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace Newtone.Mobile.Droid.Views
{
    public class PopupMenu
    {
        #region Events & Delegates
        public delegate void PopupMenuEventHandler(string item);
        public event PopupMenuEventHandler OnSelect;
        #endregion
        #region Properties
        private Context Context { get; set; }
        private View Anchor { get; set; }
        private string[] Items { get; set; }
        private Android.Widget.PopupMenu Menu { get; set; }
        #endregion
        #region Constructors
        public PopupMenu(Context context, View anchor, params string[] items)
        {
            Context = context;
            Anchor = anchor;
            Items = items;
            Menu = new Android.Widget.PopupMenu(Context, Anchor.GetRenderer().View);

            for (int a = 0; a < Items.Length; a++)
            {
                ICharSequence item = new Java.Lang.String(Items[a]);
                Menu.Menu.Add(item);
            }
            Menu.MenuItemClick += Menu_MenuItemClick;
        }
        #endregion
        #region Private Methods

        private void Menu_MenuItemClick(object sender, Android.Widget.PopupMenu.MenuItemClickEventArgs e)
        {
            OnSelect?.Invoke(e.Item.TitleFormatted.ToString());
        }
        #endregion
        #region Public Methods
        public void Show()
        {
            Menu.Show();
        }

        #endregion
    }
}