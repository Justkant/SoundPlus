using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SoundPlus
{
    
    class SoundCloudClient
    {
        enum SearchMode
        {
            Track,
            User,
            Playlist
        }

        static private string ClientId = "6db7be918aec176b9fc591ca1aade517";
        static private string ClientSecret = "b8230bb9c62077357b05bb54440fae52";

        private WebClient client;

        private Search<Track> trackSearch;
        private Search<User> userSearch;

        public SearchMode searchMode { get; set; }

        public SoundCloudClient()
        {
            client = new WebClient();
            trackSearch = new Search<Track>(client, ClientId, "tracks");
            userSearch = new Search<User>(client, ClientId, "users");
        }

        public List<Track> SearchTrack(string q, int limit = 15, int offset = 0)
        {
            return (trackSearch.SearchQuery(q, limit, offset));
        }

        public List<Track> NextPage()
        {
            return (trackSearch.NextPage());
        }

        public List<Track> PrevPage()
        {
            return (trackSearch.PrevPage());
        }
    }
}
