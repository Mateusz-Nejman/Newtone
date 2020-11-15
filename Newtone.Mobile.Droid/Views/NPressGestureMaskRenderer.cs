using Android.Content;
using Nejman.Xamarin.FocusLibrary;
using Newtone.Mobile.Droid.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using FrameRenderer = Xamarin.Forms.Platform.Android.FastRenderers.FrameRenderer;

[assembly: ExportRenderer(typeof(NPressGestureMask), typeof(NPressGestureMaskRenderer))]
namespace Newtone.Mobile.Droid.Views
{
    public class NPressGestureMaskRenderer : FrameRenderer
    {
        #region Fields
        NPressGestureMask view;
        #endregion
        #region Constructors
        public NPressGestureMaskRenderer(Context context) : base(context)
        {
            this.LongClick += (sender, args) => {
                if (view?.LongCommand?.CanExecute(view?.LongCommandParameter) == true)
                {
                    view.LongCommand.Execute(view.LongCommandParameter);
                }
            };
            this.Click += (sender, args) =>
            {
                if (view?.Command?.CanExecute(view?.CommandParameter) == true)
                {
                    view.Command.Execute(view.CommandParameter);
                }
            };
        }
        #endregion
        #region Protected Methods
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Frame> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                view = e.NewElement as NPressGestureMask;
            }
        }
        #endregion
    }
}