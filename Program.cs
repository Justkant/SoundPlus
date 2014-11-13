using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundPlus
{
    class Program
    {
        static void Main(string[] args)
        {
            SoundCloudClient client = new SoundCloudClient();

            var tracks = client.SearchTrack("savant");
            foreach (var track in tracks)
            {
                Console.WriteLine(track.title + "\n");
            }

            Console.WriteLine("Next Page !!\n");

            tracks = client.NextPage();
            foreach (var track in tracks)
            {
                Console.WriteLine(track.title + "\n");
            }
            Console.ReadKey(true);
        }
    }
}
