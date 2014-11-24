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
    /// Logique d'interaction pour UserControlPlayListPreview.xaml
    /// </summary>
    public partial class UserControlPlaylistPreview : UserControl
    {
        MainWindow parent;
        Playlist playlist;

        public UserControlPlaylistPreview(Playlist playlist, MainWindow parent)
        {
            InitializeComponent();

            this.parent = parent;
            this.playlist = playlist;

            if (playlist.artwork_url != null)
            {
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.UriSource = new Uri(playlist.artwork_url, UriKind.Absolute);
                img.EndInit();
                image.Source = img;
            }

            this.labelTitle.Content = playlist.title;
            this.labelUser.Content = playlist.user.username;
            this.labelDuration.Content = playlist.duration_string;
            this.labelTracks.Content = playlist.tracks.Count.ToString();

            listTracks.Init("Tracks", parent.listBoxDownload);
            listTracks.Fill(playlist.tracks);
        }
    }
}
