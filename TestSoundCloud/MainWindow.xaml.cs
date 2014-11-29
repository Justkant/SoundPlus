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
using System.IO;

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

        public static Preferences Preferences;

        public MainWindow()
        {
            InitializeComponent();

            LoadPreferences();

            pagesControl.parent = this;
            pagesControl.Visibility = System.Windows.Visibility.Hidden;

            WalkDirectoryTree(Directory.GetParent(Preferences.SavePath));

            client = new SoundCloudClient();
            textBoxSearch.Text = "savant";
            radioButtonTracks.IsChecked = true;
        }
        
        private void WalkDirectoryTree(System.IO.DirectoryInfo root)
        {
            System.IO.FileInfo[] files = null;
            System.IO.DirectoryInfo[] subDirs = null;

            try
            {
                files = root.GetFiles("*.*");
            }
            catch (UnauthorizedAccessException e) { Console.WriteLine(e.Message ); }
            catch (System.IO.DirectoryNotFoundException e) { Console.WriteLine(e.Message); }
            
            if (files != null)
            {
                foreach (System.IO.FileInfo fi in files)
                {
                    listBoxLocal.Items.Add(new UserControlTrackLocal(fi, listBoxLocal));
                    Console.WriteLine(fi.FullName);
                }

                foreach (System.IO.DirectoryInfo dirInfo in root.GetDirectories())
                    WalkDirectoryTree(dirInfo);
            }
        }

        private void LoadPreferences()
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Preferences));

            try
            {
                using (FileStream fileStream = new FileStream("config.xml", FileMode.Open))
                    Preferences = (Preferences)serializer.Deserialize(fileStream);
            }
            catch
            {
                Preferences = new Preferences();
            }
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
            trackPreview.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
            Grid.SetColumn(trackPreview, 2);
            stackPanel2.Children.Add(trackPreview);
        }

        private void updatePreview(Playlist playList)
        {
            ClearColumn(2);
            playListPreview = new UserControlPlaylistPreview(playList, this);
            playListPreview.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
            Grid.SetColumn(playListPreview, 2);
            stackPanel2.Children.Add(playListPreview);
        }

        private void updatePreview(User user)
        {
            ClearColumn(2);
            userPreview = new UserControlUserPreview(user, this);
            userPreview.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
            Grid.SetColumn(userPreview, 2);
            stackPanel2.Children.Add(userPreview);
        }

        public void SearchEngine(int i)// 0 for search, 1 next page, -1 prev page
        {
            listBoxResult.Items.Clear();
            pagesControl.Reset();

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

            pagesControl.Visibility = System.Windows.Visibility.Visible;
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

                try
                {
                    updatePreview(((UserControlTrackDl)listBoxDownload.SelectedItem).Track);
                }
                catch
                {
                    updatePreview(((UserControlPlaylistDl)listBoxDownload.SelectedItem).Playlist);
                }
            }
        }

        private void MenuItemConfigure_Click(object sender, RoutedEventArgs e)
        {
            WindowConfigue w = new WindowConfigue();
            w.Init(Preferences);
            w.Show();
        }

        private void radioButton_Checked(object sender, RoutedEventArgs e)
        {
            SearchEngine(0);
        }
    }
}

