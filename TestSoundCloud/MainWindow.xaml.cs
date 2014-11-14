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
        SoundCloudClient client;
        UserControlTrackPreview trackPreview;
        UserControlPlayListPreview playListPreview;
        UserControlUserPreview userPreview;

        public MainWindow()
        {
            InitializeComponent();

            client = new SoundCloudClient();
            textBoxSearch.Text = "savant";
            radioButtonTracks.IsChecked = true;
            SearchEngine();
        }

        private void ClearColumn(int column)
        {
            for (int i = 0; i < stackPanel2.Children.Count; i++)
                if (Grid.GetColumn(stackPanel2.Children[i]) == column)
                    stackPanel2.Children.Remove(stackPanel2.Children[i]);
        }

        private void updatePreview(Track track)
        {
            ClearColumn(2);
            trackPreview = new UserControlTrackPreview(track, this);
            trackPreview.Width = Double.NaN;
            trackPreview.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            Grid.SetColumn(trackPreview, 2);
            stackPanel2.Children.Add(trackPreview);
        }

        private void updatePreview(Playlist playList)
        {
            ClearColumn(2);
            playListPreview = new UserControlPlayListPreview(playList, this);
            playListPreview.Width = Double.NaN;
            playListPreview.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            Grid.SetColumn(playListPreview, 2);
            stackPanel2.Children.Add(playListPreview);
        }

        private void updatePreview(User user)
        {
            ClearColumn(2);
            userPreview = new UserControlUserPreview(user, this);
            userPreview.Width = Double.NaN;
            userPreview.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            Grid.SetColumn(userPreview, 2);
            stackPanel2.Children.Add(userPreview);
        }

        public void SearchEngine()
        {
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
                List<Playlist> playlists;
                playlists = client.playlistSearch.SearchQuery(textBoxSearch.Text);

                foreach (Playlist playlist in playlists)
                    listBoxResult.Items.Add(new UserControlPlaylist(playlist, listBoxDownload));
            }
            else
            {
                List<User> users;
                users = client.userSearch.SearchQuery(textBoxSearch.Text);

                foreach (User user in users)
                    listBoxResult.Items.Add(new UserControlUser(user, listBoxDownload));
            }
        }

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                SearchEngine();
        }

        private void listBoxResult_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ListBox listBoxSender = (ListBox)sender;

            if (sender == listBoxResult)
            {
                if (listBoxResult.SelectedItem == null)
                    return;

                updatePreview(((UserControlTrack)listBoxResult.SelectedItem).Track);
            }
            else
            {
                if (listBoxDownload.SelectedItem == null)
                    return;

                updatePreview(((UserControlTrackDl)listBoxDownload.SelectedItem).Track);
            }
        }
    }
}

