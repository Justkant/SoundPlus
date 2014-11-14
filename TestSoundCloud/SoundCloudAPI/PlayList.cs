using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestSoundCloud
{
    public class Playlist
    {
        public int? id { get; set; }
        public string created_at { get; set; }
        public int? user_id { get; set; }
        public User user { get; set; }
        public string title { get; set; }
        public string permalink { get; set; }
        public string permalink_url { get; set; }
        public string uri { get; set; }
        public string sharing { get; set; }
        public string embeddable_by { get; set; }
        public string purchase_url { get; set; }
        public string artwork_url { get; set; }
        public User label { get; set; }
        public int? duration { get; set; }
        public string genre { get; set; }
        public int? shared_to_count { get; set; }
        public string tag_list { get; set; }
        public int? label_id { get; set; }
        public string label_name { get; set; }
        public string release { get; set; }
        public int? release_day { get; set; }
        public int? release_month { get; set; }
        public int? release_year { get; set; }
        public bool? streamable { get; set; }
        public bool? downloadable { get; set; }
        public string ean { get; set; }
        public string playlist_type { get; set; }
        public List<Track> tracks { get; set; }

        public List<String> GetTagList()
        {
            String[] tags = tag_list.Split(' ');
            List<String> tags2 = new List<string>();

            foreach (String tag in tags)
                if (tag.Length > 0)
                {
                    if (tag[0] == '"')
                        tags2.Add(tag.Substring(1, tag.Length - 2));
                    else
                        tags2.Add(tag);
                }

            return tags2;
        }

        public void Download(string path)
        {

        }
    }
}
