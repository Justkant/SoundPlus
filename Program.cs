using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SoundPlus
{
    class Program
    {
        static void Main(string[] args)
        {
            //WebClient to communicate via http
            WebClient client = new WebClient();

            //Client id form SoundCloud
            string ClientId = "6db7be918aec176b9fc591ca1aade517";

            //Client secret id from SoundCloud
            //string ClientSecret = "b8230bb9c62077357b05bb54440fae52";

            string res = client.DownloadString("https://api.soundcloud.com/tracks.json?client_id=" + ClientId + "&q=savant&limit=10&offset=10");
            List<Track> tracks = JsonConvert.DeserializeObject<List<Track>>(res);
            foreach (Track track in tracks)
            {
                Console.WriteLine(track.user.username);
                Console.WriteLine(track.title + "\n");
            }
            Console.ReadKey(true);
        }
    }
}
