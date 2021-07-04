using Nejman.Newtone.Core;
using Nejman.Newtone.Core.Data;
using Nejman.Newtone.Core.Exceptions;
using Nejman.Newtone.Core.Media;
using Nejman.Newtone.Mobile.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Nejman.Newtone.Mobile.Implementations
{
    public static class SpeechImplementation
    {
        private static ISpeech speech;

        public static ISpeech Current => speech;

        public static void Initialize(ISpeech implementation)
        {
            if(speech != null)
            {
                throw new ImplementationException("Speech");
            }

            speech = implementation;
        }

        public async static Task Process(string rawText)
        {
            string[] playElements = new string[] { "odtwórz", "otwórz", "graj", "włącz", "play", "igraj" };
            string[] trackElements = new string[] { "utwór", "piosenkę", "track", "music", "trek", "pesnyu" };
            string[] playlistElements = new string[] { "playlistę", "plejlistę", "listę", "list", "playlist", "spisok" };
            string[] searchElements = new string[] { "szukaj", "wyszukaj", "znajdź", "search", "find", "poisk", "najti" };

            SpeechAction action = SpeechAction.None;
            SpeechType type = SpeechType.None;
            string query = "";

            string[] elements = rawText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


            if (elements.Length > 0)
            {
                string rawAction = elements[0].ToLowerInvariant();
                if (playElements.Contains(rawAction))
                    action = SpeechAction.Play;
                else if (searchElements.Contains(rawAction))
                    action = SpeechAction.Search;

                if (action != SpeechAction.None && elements.Length > 1)
                {
                    string rawType = elements[1].ToLowerInvariant();
                    string rawQuery = "";
                    int queryStart = 2;

                    if (trackElements.Contains(rawType))
                        type = SpeechType.Track;
                    else if (playlistElements.Contains(rawType))
                        type = SpeechType.Playlist;
                    else
                    {
                        queryStart = 1;
                    }

                    for (int a = queryStart; a < elements.Length; a++)
                    {
                        rawQuery += elements[a] + " ";
                    }

                    if (rawQuery.Length > 0)
                    {
                        query = rawQuery.ToLowerInvariant().Trim();
                    }
                }
            }

            if (action != SpeechAction.None && (type != SpeechType.None || query != ""))
            {
                //search order: playlist, artist, track, search
                if (action == SpeechAction.Search)
                {
                    Current.OpenSearchPage(query);
                }
                else
                {
                    var playlist = PlaylistsAction.GetPlaylistInvariant(query);

                    if(playlist.Count > 0)
                    {
                        await CoreGlobal.MediaPlayer.LoadPlaylist(playlist, 0);
                        return;
                    }

                    var artist = ArtistsAction.GetArtistInvariant(query);

                    if(artist.Count > 0)
                    {
                        await CoreGlobal.MediaPlayer.LoadPlaylist(artist, 0);
                        return;
                    }

                    var source = TracksAction.GetInvariant(query);

                    if(source != null)
                    {
                        await CoreGlobal.MediaPlayer.LoadPlaylist(new List<MediaSource> { source }, 0);
                        return;
                    }

                    Current.OpenSearchPage(query);
                }
            }
            else if (rawText.ToLowerInvariant() == "kto jest najlepszy")
            {
                await TextToSpeech.SpeakAsync("Najlepszy jest Mateusz Nejman, twórca Niuton.");
            }
            else
            {
                await TextToSpeech.SpeakAsync("Nie rozumiem zapytania");
            }
        }

        private enum SpeechAction
        {
            None,
            Play,
            Search
        }

        private enum SpeechType
        {
            None,
            Track,
            Playlist
        }
    }
}
