using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSoundCloud
{
    public class User
    {
        public int? id { get; set; }
        public string permalink { get; set; }
        public string username { get; set; }
        public string uri { get; set; }
        public string permaling_url { get; set; }
        public string avatar_url { get; set; }
        public string country { get; set; }
        public string full_name { get; set; }
        public string city { get; set; }
        public string description { get; set; }
        public string website { get; set; }
        public bool online { get; set; }
        public int? track_count { get; set; }
        public int? playlist_count { get; set; }
        public int? followers_count { get; set; }
        public int? followings_count { get; set; }
        public int? public_favorites_count { get; set; }
    }
}
