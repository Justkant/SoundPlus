using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestSoundCloud
{
    public class Track
    {
        public int? id { get; set; }
        public string created_at { get; set; }
        public string user_id { get; set; }
        public User user { get; set; }
        public string title { get; set; }
        public string permalink { get; set; }
        public string uri { get; set; }
        public string sharing { get; set; }
        public string embeddable_url { get; set; }
        public string purchase_url { get; set; }
        public string artwork_url { get; set; }
        public string description { get; set; }
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
        public string state { get; set; }
        public string license { get; set; }
        public string track_type { get; set; }
        public string waveform_url { get; set; }
        public string download_url { get; set; }
        public string stream_url { get; set; }
        public string video_url { get; set; }
        public float? bpm { get; set; }
        public bool commentable { get; set; }
        public string iscr { get; set; }
        public string key_signature { get; set; }
        public int? comment_count { get; set; }
        public int? download_count { get; set; }
        public int? playback_count { get; set; }
        public int? favoritings_count { get; set; }
        public string original_format { get; set; }
        public int? original_content_size { get; set; }
        public bool user_favorite { get; set; }

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

        public void Download(WebClient client, string path)
        {
            string fileName = path + title;

            if (downloadable == true)
                client.DownloadFile(download_url, fileName);
            else
                client.DownloadFile(stream_url, fileName);
        }
    }
}
