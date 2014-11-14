using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TestSoundCloud
{
    
    public class SoundCloudClient
    {
        static private string ClientId = "6db7be918aec176b9fc591ca1aade517";
        static private string ClientSecret = "b8230bb9c62077357b05bb54440fae52";

        private WebClient client;

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
    }
}
