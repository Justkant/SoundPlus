using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Sound__test
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

            string url = "https://soundcloud.com/dillonfrancis/dillon-francis-dj-snake-get";
            string resolveStr = "https://api.soundcloud.com/resolve.json?client_id=" + ClientId + "&url=" + url;
            string res = client.DownloadString("https://api.soundcloud.com/tracks.json?client_id=" + ClientId + "&q=savant");
            List<Tracks> tracks = JsonConvert.DeserializeObject<List<Tracks>>(res);
            foreach (Tracks track in tracks)
            {
                Console.WriteLine(track.stream_url);
                Console.WriteLine(track.title);
            }
            //Print the Data
            //Console.WriteLine(buff);
            Console.ReadKey(true);
        }
    }
}
