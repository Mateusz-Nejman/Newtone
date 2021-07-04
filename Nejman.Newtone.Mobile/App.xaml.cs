using Nejman.Newtone.Core;
using Nejman.Newtone.Core.Contracts;
using Nejman.Newtone.Core.Implementations;
using Nejman.Newtone.Mobile;
using Nejman.Newtone.Mobile.Contracts;
using Nejman.Newtone.Mobile.Implementations;
using Nejman.Newtone.Mobile.Views;
using System.IO;
using Xamarin.Forms;

namespace Nejman.Newtone
{
    public partial class App : Application
    {
        public App(IMediaPlayer mediaPlayer, INotification notification, ISnackbar snackbar, IImageProcessing imageProcessing, IContextMenuBuilder contextMenuBuilder, IApplication application, ISpeech speech)
        {
            InitializeComponent();

            if (Global.Permissions?.IsValid() == true && File.Exists(CoreGlobal.DataPath + "/newtone.nsec2"))
            {
                if (Global.TV)
                {
                    //TODO MainPage = new Views.TV.NormalPage();
                }
                else
                {
                    MainPage = new AppShell();
                }
            }
            else
            {
                if (Global.TV)
                {
                    //TODO MainPage = new Views.TV.LanguageSelectPage();
                }
                else
                {
                    MainPage = new LanguageSelectPage();
                }
            }
            Initialize(mediaPlayer, notification, snackbar, imageProcessing, contextMenuBuilder, application, speech);
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private void Initialize(IMediaPlayer mediaPlayer, INotification notification, ISnackbar snackbar, IImageProcessing imageProcessing, IContextMenuBuilder contextMenuBuilder, IApplication application, ISpeech speech)
        {
            try
            {
                Core.Implementations.MessageImplementation.Initialize(new Mobile.Implementations.MessageImplementation());
                MediaPlayerImplementation.Initialize(mediaPlayer);
                NotificationImplementation.Initialize(notification);
                SnackbarImplementation.Initialize(snackbar);
                ImageProcessingImplementation.Initialize(imageProcessing);
                ContextMenuBuilderImplementation.Initialize(contextMenuBuilder);
                ApplicationImplementation.Initialize(application);
                SpeechImplementation.Initialize(speech);
            }
            catch
            {
                //Ignore man :)
            }
        }
    }
}
