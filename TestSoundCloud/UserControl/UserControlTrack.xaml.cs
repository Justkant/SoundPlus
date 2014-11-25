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
    /// Logique d'interaction pour UserControlTrack.xaml
    /// </summary>
    public partial class UserControlTrack : UserControl
    {
        public Track Track;

        ListBox listBoxDownload;

        public UserControlTrack(Track track, ListBox listBoxDownload)
        {
            InitializeComponent();

            Track = track;

            this.listBoxDownload = listBoxDownload;

            labelTitle.MaxLines = 2;
            labelTitle.Text = track.title;
            labelAuthor.Content = track.user.username;

            labelDuration.Content = track.duration_string;

            if (track.artwork_url != null)
            {
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.UriSource = new Uri(track.artwork_url, UriKind.Absolute);
                img.EndInit();
                image.Source = img;
            }
        }

        private void buttonDownload_Click(object sender, RoutedEventArgs e)
        {
            ((Button)sender).IsEnabled = false;

            listBoxDownload.Items.Add(new UserControlTrackDl(Track));
        }

    }
}
