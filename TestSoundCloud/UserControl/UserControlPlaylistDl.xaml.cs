using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestSoundCloud
{
    /// <summary>
    /// Logique d'interaction pour UserControlPlaylistDl.xaml
    /// </summary>
    public partial class UserControlPlaylistDl : UserControl
    {
        public Playlist Playlist;

        public UserControlPlaylistDl(Playlist playlist)
        {
            InitializeComponent();

            Playlist = playlist;
            labelTitle.Content = playlist.title;
            labelAuthor.Content = playlist.user.username;

            TimeSpan t = TimeSpan.FromMilliseconds((double)playlist.duration);
            if (t.Hours > 0)
                labelDuration.Content = String.Format("{0}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
            else
                labelDuration.Content = String.Format("{0}:{1:D2}", t.Minutes, t.Seconds);

            if (playlist.artwork_url != null)
            {
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.UriSource = new Uri(playlist.artwork_url, UriKind.Absolute);
                img.EndInit();
                image.Source = img;
            }
            else if (playlist.tracks[0] != null && playlist.tracks[0].artwork_url != null)
            {
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.UriSource = new Uri(playlist.tracks[0].artwork_url, UriKind.Absolute);
                img.EndInit();
                image.Source = img;
            }
            SoundCloudClient.Downloader(playlist, "./", progressBar1);
        }
    }
}
