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
    /// Logique d'interaction pour UserControlPlaylist.xaml
    /// </summary>
    public partial class UserControlPlaylist : UserControl
    {
        public Playlist Playlist;

        ListBox listBoxDownload;

        public UserControlPlaylist(Playlist playlist, ListBox listBoxDownload)
        {
            InitializeComponent();

            Playlist = playlist;

            this.listBoxDownload = listBoxDownload;

            labelTitle.MaxLines = 2;
            labelTitle.Text = playlist.title;
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

        }

        private void buttonDownload_Click(object sender, RoutedEventArgs e)
        {
            listBoxDownload.Items.Add(new UserControlPlaylistDl(Playlist));
        }
    }
}
