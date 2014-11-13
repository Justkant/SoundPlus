using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SoundPlus
{
    class Search<T>
    {
        private WebClient client;

        private string ClientId;

        private string api;
        private string curr_q;
        private int curr_offset;
        private int curr_limit;


        public Search(WebClient client, string ClientId, string api)
        {
            this.client = client;
            this.ClientId = ClientId;
            this.api = api;
            curr_offset = 0;
            curr_limit = 15;
            curr_q = "";
        }

        private List<T> CurrentSearch()
        {
            string uri = "https://api.soundcloud.com/" + api + ".json?client_id=" + ClientId +
                    "&q=" + curr_q +
                    "&limit=" + curr_limit +
                    "&offset=" + curr_offset;
            string res = client.DownloadString(uri);
            return (JsonConvert.DeserializeObject<List<T>>(res));
        }

        public List<T> SearchQuery(string q, int limit = 15, int offset = 0)
        {
            curr_q = q;
            curr_offset = offset;
            curr_limit = limit;
            return (CurrentSearch());
        }

        public List<T> NextPage()
        {
            curr_offset += curr_limit;
            return (CurrentSearch());
        }

        public List<T> PrevPage()
        {
            curr_offset -= curr_limit;
            if (curr_offset < 0)
                curr_offset = 0;
            return (CurrentSearch());
        }
    }
}
