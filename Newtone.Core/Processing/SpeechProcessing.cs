using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newtone.Core.Processing
{
    public static class SpeechProcessing
    {
        public async static Task Process(string rawText)
        {
            string[] playElements = new string[] { "odtwórz","otwórz","graj","włącz","play","igraj"};
            string[] trackElements = new string[] { "utwór", "piosenkę","track","music","trek","pesnyu" };
            string[] playlistElements = new string[] { "playlistę", "plejlistę", "listę", "list", "playlist", "spisok" };
            string[] searchElements = new string[] { "szukaj", "wyszukaj", "znajdź","search","find","poisk","najti" };

            SpeechAction action = SpeechAction.None;
            SpeechType type = SpeechType.None;
            string query = "";

            string[] elements = rawText.Split(' ', StringSplitOptions.RemoveEmptyEntries);


            if(elements.Length > 0)
            {
                string rawAction = elements[0].ToLowerInvariant();
                if (playElements.Contains(rawAction))
                    action = SpeechAction.Play;
                else if (searchElements.Contains(rawAction))
                    action = SpeechAction.Search; 

                if (action != SpeechAction.None)
                {
                    if(elements.Length > 1)
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

                        for(int a = queryStart; a < elements.Length; a++)
                        {
                            rawQuery += elements[a] + " ";
                        }

                        if(rawQuery.Length > 0)
                        {
                            query = rawQuery.ToLowerInvariant().Trim();
                        }
                    }
                }
            }

            if(action != SpeechAction.None && (type != SpeechType.None || query != ""))
            {
                //search order: playlist, artist, track, search

                bool searched = false;

                if(action == SpeechAction.Search)
                {
                    await GlobalData.Current.SpeechBase.OpenSearchPageAsync(query);
                }
                else
                {
                    foreach (string playlistName in GlobalData.Current.Playlists.Keys)
                    {
                        if (playlistName.ToLowerInvariant().Contains(query))
                        {
                            GlobalData.Current.MediaPlayer.LoadPlaylist(GlobalData.Current.Playlists[playlistName], 0, true, true);
                            searched = true;
                            break;
                        }
                    }

                    if (!searched)
                    {
                        foreach (string artistName in GlobalData.Current.Artists.Keys)
                        {
                            if (artistName.ToLowerInvariant().Contains(query))
                            {
                                GlobalData.Current.MediaPlayer.LoadPlaylist(GlobalData.Current.Artists[artistName], 0, true, true);
                                searched = true;
                                break;
                            }
                        }
                    }

                    if (!searched)
                    {
                        foreach (var trackPath in GlobalData.Current.Audios.Keys)
                        {
                            var mediaSource = GlobalData.Current.Audios[trackPath];

                            string trackName = mediaSource.Artist + " " + mediaSource.Title;

                            if (trackName.ToLowerInvariant().Contains(query))
                            {
                                GlobalData.Current.MediaPlayer.LoadPlaylist(new List<string> { trackPath }, 0, true, true);
                                searched = true;
                                break;
                            }
                        }
                    }

                    if (!searched)
                    {
                        await GlobalData.Current.SpeechBase.OpenSearchPageAsync(query);
                    }
                }
            }
            else if(rawText.ToLowerInvariant() == "kto jest najlepszy")
            {
                await GlobalData.Current.TalkBase.TalkAsync("Najlepszy jest Mateusz Nejman, twórca Niuton.");
            }
            else
            {
                await GlobalData.Current.TalkBase.TalkAsync("Nie rozumiem zapytania");
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
