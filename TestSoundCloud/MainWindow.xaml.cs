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
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int i = 0;
        SoundCloudClient client;

        public MainWindow()
        {
            InitializeComponent();

            trackPreview.Visibility = System.Windows.Visibility.Hidden;

            client = new SoundCloudClient();
            textBoxSearch.Focus();
            radioButtonTracks.IsChecked = true;
        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            listBoxResult.Items.Clear();
            List<Track> tracks = client.trackSearch.SearchQuery(textBoxSearch.Text);

            foreach (Track track in tracks)
                listBoxResult.Items.Add(new UserControlTrack(track, listBoxDownload));
        }

        private void listBoxResult_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ListBox listBoxSender = (ListBox)sender;

            if (sender == listBoxResult)
            {
                if (listBoxResult.SelectedItem == null)
                {
                    trackPreview.Visibility = System.Windows.Visibility.Hidden;
                    return;
                }

                trackPreview.update(((UserControlTrack)listBoxResult.SelectedItem).Track);
                trackPreview.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                if (listBoxDownload.SelectedItem == null)
                {
                    trackPreview.Visibility = System.Windows.Visibility.Hidden;
                    return;
                }

                trackPreview.update(((UserControlTrackDl)listBoxDownload.SelectedItem).Track);
                trackPreview.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;

            listBoxResult.Items.Clear();

            if (radioButtonTracks.IsChecked.Value)
            {
                List<Track> tracks;
                tracks = client.trackSearch.SearchQuery(textBoxSearch.Text);

                foreach (Track track in tracks)
                    listBoxResult.Items.Add(new UserControlTrack(track, listBoxDownload));
            }
            else if (radioButtonPlaylists.IsChecked.Value)
            {
                /* Uncomment when playlists are implemented
                List<Playlist> playlists;
                playlists = client.playlistSearch.SearchQuery(textBoxSearch.Text);

                foreach (Playlist playlist in playlists)
                    listBoxResult.Items.Add(new UserControlPlaylist(playlist, listBoxDownload));
                 */
            }
            else
            {
                List<User> users;
                users = client.userSearch.SearchQuery(textBoxSearch.Text);

                foreach (User user in users)
                    listBoxResult.Items.Add(new UserControlUser(user, listBoxDownload));

            }


        }

        private void stackPanel2_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            foreach (UserControlTrack item in listBoxResult.Items)
            {
                item.labelTitle.Width = item.Width - item.labelTitle.Margin.Left - item.labelTitle.Margin.Right;
            }
        }

    }
}
