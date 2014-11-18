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
        UserControlPlaylistPreview playListPreview;
        UserControlUserPreview userPreview;

        public MainWindow()
        {
            InitializeComponent();

            pagesControl.parent = this;

            client = new SoundCloudClient();
            textBoxSearch.Text = "savant";
            radioButtonTracks.IsChecked = true;
            //SearchEngine();
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
            trackPreview.Height = Double.NaN;
            trackPreview.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            Grid.SetColumn(trackPreview, 2);
            stackPanel2.Children.Add(trackPreview);
        }

        private void updatePreview(Playlist playList)
        {
            ClearColumn(2);
            playListPreview = new UserControlPlaylistPreview(playList, this);
            playListPreview.Width = Double.NaN;
            playListPreview.Height = Double.NaN;
            playListPreview.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            Grid.SetColumn(playListPreview, 2);
            stackPanel2.Children.Add(playListPreview);
        }

        private void updatePreview(User user)
        {
            ClearColumn(2);
            userPreview = new UserControlUserPreview(user, this);
            userPreview.Width = Double.NaN;
            trackPreview.Height = Double.NaN;
            userPreview.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            Grid.SetColumn(userPreview, 2);
            stackPanel2.Children.Add(userPreview);
        }

        public void SearchEngine(int i)// 0 for search, 1 next page, -1 prev page
        {
            listBoxResult.Items.Clear();

            if (radioButtonTracks.IsChecked.Value)
            {
                List<Track> tracks;

                if (i == 0)
                    tracks = client.trackSearch.SearchQuery(textBoxSearch.Text);
                else if (i == 1)
                    tracks = client.trackSearch.NextPage();
                else
                    tracks = client.trackSearch.PrevPage();

                foreach (Track track in tracks)
                    listBoxResult.Items.Add(new UserControlTrack(track, listBoxDownload));
            }
            else if (radioButtonPlaylists.IsChecked.Value)
            {
                List<Playlist> playlists; 
                
                if (i == 0)
                    playlists = client.playlistSearch.SearchQuery(textBoxSearch.Text);
                else if (i == 1)
                    playlists = client.playlistSearch.NextPage();
                else
                    playlists = client.playlistSearch.PrevPage();

                foreach (Playlist playlist in playlists)
                    listBoxResult.Items.Add(new UserControlPlaylist(playlist, listBoxDownload));
            }
            else
            {
                List<User> users;

                if (i == 0)
                    users = client.userSearch.SearchQuery(textBoxSearch.Text);
                else if (i == 1)
                    users = client.userSearch.NextPage();
                else
                    users = client.userSearch.PrevPage();

                foreach (User user in users)
                    listBoxResult.Items.Add(new UserControlUser(user, listBoxDownload));
            }
        }

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                SearchEngine(0);
        }

        private void listBoxResult_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ListBox listBoxSender = (ListBox)sender;

            if (sender == listBoxResult)
            {
                if (listBoxResult.SelectedItem == null)
                    return;

                if (radioButtonTracks.IsChecked.Value)
                    updatePreview(((UserControlTrack)listBoxResult.SelectedItem).Track);
                else if (radioButtonPlaylists.IsChecked.Value)
                    updatePreview(((UserControlPlaylist)listBoxResult.SelectedItem).Playlist);
                else 
                    updatePreview(((UserControlUser)listBoxResult.SelectedItem).User);
            }
            else
            {
                if (listBoxDownload.SelectedItem == null)
                    return;

                updatePreview(((UserControlTrackDl)listBoxDownload.SelectedItem).Track);
            }
        }

        private void MenuItemConfigure_Click(object sender, RoutedEventArgs e)
        {
            new WindowConfigue().Show();
        }
    }
}

