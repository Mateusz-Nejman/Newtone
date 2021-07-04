using Android.App;
using Android.Graphics;
using Android.Support.V4.Media.Session;
using AndroidX.Core.App;
using AndroidX.Media.Session;
using Nejman.Newtone.Core;
using Nejman.Newtone.Core.Contracts;
using Nejman.Newtone.Core.Media;
using Nejman.Newtone.Droid.Media;
using static AndroidX.Media.App.NotificationCompat;

namespace Nejman.Newtone.Droid.Implementations
{
    public class NotificationImplementation : INotification
    {
        public void Show(MediaSource mediaSource, bool isPlaying)
        {
            var notification = GetNotification(mediaSource, isPlaying);

            if(notification != null)
            {
                MediaPlayerService.Instance.StartForeground(0, notification);
                DroidGlobal.NotificationManager?.Notify(0, notification);
            }
            else
            {
                DroidGlobal.NotificationManager?.Cancel(0);
            }
        }

        private Notification GetNotification(MediaSource source, bool isPlaying)
        {
            if (DroidGlobal.MediaSession == null || DroidGlobal.MediaSession.Controller == null || source == null || CoreGlobal.MediaPlayer == null)
            {
                return null;
            }

            MediaControllerCompat controller = DroidGlobal.MediaSession.Controller;

            NotificationCompat.Builder builder = new NotificationCompat.Builder(MediaPlayerService.Instance.BaseContext, "newtone");

            Bitmap bitmap;

            if (source.Image == null || source.Image.Length == 0)
                bitmap = BitmapFactory.DecodeStream(DroidGlobal.AssetManager.Open("EmptyTrack.png"));
            else
                bitmap = BitmapFactory.DecodeByteArray(source.Image, 0, source.Image.Length);
            builder
                .SetContentTitle(source.Title)
                .SetContentText(source.Artist)

                .SetContentIntent(controller.SessionActivity)
                .SetDeleteIntent(MediaButtonReceiver.BuildMediaButtonPendingIntent(MediaPlayerService.Instance.BaseContext, PlaybackStateCompat.ActionStop))
                .SetVisibility(NotificationCompat.VisibilityPublic)
                .SetSmallIcon(Resource.Drawable.PlayIconNotification)
                .SetOngoing(true)
                .SetLargeIcon(bitmap)
                .AddAction(new NotificationCompat.Action(Resource.Drawable.PrevIconNotification, "prev", MediaButtonReceiver.BuildMediaButtonPendingIntent(MediaPlayerService.Instance.BaseContext, PlaybackStateCompat.ActionSkipToPrevious)))
                .AddAction(new NotificationCompat.Action(isPlaying ? Resource.Drawable.PauseIconNotification : Resource.Drawable.PlayIconNotification, "pause", MediaButtonReceiver.BuildMediaButtonPendingIntent(MediaPlayerService.Instance.BaseContext, isPlaying ? PlaybackStateCompat.ActionPause : PlaybackStateCompat.ActionPlay)))
                .AddAction(new NotificationCompat.Action(Resource.Drawable.NextIconNotification, "next", MediaButtonReceiver.BuildMediaButtonPendingIntent(MediaPlayerService.Instance.BaseContext, PlaybackStateCompat.ActionSkipToNext)))
                .SetStyle(new MediaStyle()
                .SetMediaSession(DroidGlobal.MediaSession.SessionToken)
                .SetShowActionsInCompactView(0, 1, 2)
                .SetShowCancelButton(true)
                .SetCancelButtonIntent(MediaButtonReceiver.BuildMediaButtonPendingIntent(MediaPlayerService.Instance.BaseContext, PlaybackStateCompat.ActionStop)));

            DroidGlobal.MediaSession.SetMetadata(CoreGlobal.CurrentSource?.ToMetadata());
            DroidGlobal.StateBuilder.SetState(isPlaying ? PlaybackStateCompat.StatePlaying : PlaybackStateCompat.StatePaused, (long)(CoreGlobal.MediaPlayer.CurrentPosition * 1000.0), 1.0f);
            DroidGlobal.MediaSession.SetPlaybackState(DroidGlobal.StateBuilder.Build());
            return builder.Build();
        }
    }
}