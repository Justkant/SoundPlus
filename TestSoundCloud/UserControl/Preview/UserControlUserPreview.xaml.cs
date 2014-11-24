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
    /// Logique d'interaction pour UserControlUserPreview.xaml
    /// </summary>
    public partial class UserControlUserPreview : UserControl
    {
        MainWindow parent;
        User user;

        public UserControlUserPreview(User user, MainWindow parent)
        {
            InitializeComponent();

            this.parent = parent;
            this.user = user;

            if (user.avatar_url != null)
            {
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.UriSource = new Uri(user.avatar_url, UriKind.Absolute);
                img.EndInit();
                imageAvatar.Source = img;
            }

            labelPseudo.Content = user.username;
            labelLocation.Content = user.country;
            labelFollowers.Content = user.followers_count;
            labelSounds.Content = user.track_count;
            textBlockDescription.Text = user.description;

            UserControlListItem listTracks = new UserControlListItem();
            UserControlListItem listPlaylists = new UserControlListItem();
            UserControlListItem listFollowers = new UserControlListItem();

            listTracks.Init("Tracks", parent.listBoxDownload);
            listPlaylists.Init("Tracks", parent.listBoxDownload);
            listFollowers.Init("Tracks", parent.listBoxDownload);

            //appeler la fct fill pour chaque list

            Grid.SetColumn(listTracks, 0);
            gridContent.Children.Add(listTracks);

            stackPanelContent.Children.Add(listPlaylists);
            stackPanelContent.Children.Add(listFollowers);
        }
    }
}
