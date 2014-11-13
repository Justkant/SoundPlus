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
        static private string ClientId = "6db7be918aec176b9fc591ca1aade517";
        static private string ClientSecret = "b8230bb9c62077357b05bb54440fae52";

        private string curr_q;
        private int curr_offset;
        private int curr_limit;

        private WebClient client;

        public SoundCloudClient()
        {
            client = new WebClient();
            curr_offset = 0;
            curr_limit = 15;
            curr_q = "";
        }

        private List<Track> CurrentSearch()
        {
            string uri = "https://api.soundcloud.com/tracks.json?client_id=" + ClientId +
                    "&q=" + curr_q +
                    "&limit=" + curr_limit +
                    "&offset=" + curr_offset;
            string res = client.DownloadString(uri);
            return (JsonConvert.DeserializeObject<List<Track>>(res));
        }

        public List<Track> SearchTrack(string q, int limit = 15, int offset = 0)
        {
            curr_q = q;
            curr_offset = offset;
            curr_limit = limit;
            return (CurrentSearch());
        }

        public List<Track> NextPage()
        {
            curr_offset += curr_limit;
            return (CurrentSearch());
        }

        public List<Track> PrevPage()
        {
            curr_offset -= curr_limit;
            if (curr_offset < 0)
                curr_offset = 0;
            return (CurrentSearch());
        }
    }
}
