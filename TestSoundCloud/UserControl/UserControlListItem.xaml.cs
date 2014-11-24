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
    /// Interaction logic for UserControlListItem.xaml
    /// </summary>
    public partial class UserControlListItem : UserControl
    {
        ListBox listBoxDownload;

        public UserControlListItem()
        {
            InitializeComponent();

        }

        public void Init(String title, ListBox listBoxDownload)
        {
            this.listBoxDownload = listBoxDownload;
            this.labelTitle.Content = title;
        }

        public void Fill(List<Track> tracks)
        {
            this.labelTitle.Content = tracks.Count + " " + this.labelTitle.Content;
            foreach (Track track in tracks)
                listBoxItems.Items.Add(new UserControlTrack(track, listBoxDownload));
        }

        public void Fill(List<Playlist> playlists)
        {
            this.labelTitle.Content = playlists.Count + " " + this.labelTitle.Content;
            foreach (Playlist playlist in playlists)
                listBoxItems.Items.Add(new UserControlPlaylist(playlist, listBoxDownload));
        }

        public void Fill(List<User> followers)
        {
            this.labelTitle.Content = followers.Count + " " + this.labelTitle.Content;
            foreach (User user in followers)
                listBoxItems.Items.Add(new UserControlUser(user, listBoxDownload));
        }
    }
}
