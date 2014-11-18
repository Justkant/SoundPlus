using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Controls;
using System.IO;

namespace TestSoundCloud
{
    
    public class SoundCloudClient
    {
        static private string ClientId = "6db7be918aec176b9fc591ca1aade517";
        static private string ClientSecret = "b8230bb9c62077357b05bb54440fae52";

        public WebClient client { get; private set; }

        public Search<Track> trackSearch;
        public Search<User> userSearch;
        public Search<Playlist> playlistSearch;

        public SoundCloudClient()
        {
            client = new WebClient();
            trackSearch = new Search<Track>(client, ClientId, "tracks");
            userSearch = new Search<User>(client, ClientId, "users");
            playlistSearch = new Search<Playlist>(client, ClientId, "playlists");
        }

        public static void Downloader(Playlist playlist, string path, ProgressBar progressBar)
        {
            string final_path = path + playlist.title + "/";
            Directory.CreateDirectory(final_path);
            foreach (Track track in playlist.tracks)
            {
                Downloader(track, final_path, progressBar);
            }
        }

        public static void Downloader(Track track, string path, ProgressBar progressBar)
        {
            if (track.stream_url == null)
            {
                return;
            }
            WebClient client = new WebClient();
            client.DownloadProgressChanged += (s, e) =>
                {
                    if (progressBar != null)
                        progressBar.Value = e.ProgressPercentage;
                };
            client.DownloadFileCompleted += (s, e) =>
                {
                    // TODO : Button annuler
                };
            string final_path = path + track.title + ".mp3";
            Uri uri = new Uri(track.stream_url + "?client_id=6db7be918aec176b9fc591ca1aade517");
            client.DownloadFileAsync(uri, final_path);
        }
    }
}
