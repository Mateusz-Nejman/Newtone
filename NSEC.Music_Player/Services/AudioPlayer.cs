using Android.Media;
using Android.OS;
using NSEC.Music_Player.Logic;
using System;

namespace NSEC.Music_Player.Services
{
    internal class AudioPlayer : AsyncTask<MP3Processing.Container, string, string>
    {
        private MediaPlayer Player { get; set; }
        public AudioPlayer(MediaPlayer player)
        {
            Player = player;
        }

        protected override void OnPreExecute()
        {
            base.OnPreExecute();

        }
        protected override string RunInBackground(params MP3Processing.Container[] @params)
        {
            try
            {
                Player.SetDataSource(@params[0].FilePath);
                Player.Prepare();
            }
            catch (Exception e)
            {
                Console.WriteLine("AudioPlayer.cs -> " + e);
            }

            return "";
        }

        protected override void OnPostExecute(string result)
        {
            base.OnPostExecute(result);
            //File length
        }
    }
}
