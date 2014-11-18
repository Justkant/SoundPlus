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
    /// Logique d'interaction pour UserControlUser.xaml
    /// </summary>
    public partial class UserControlUser : UserControl
    {
        public User User;

        ListBox listBoxDownload;

        public UserControlUser(User user, ListBox listBoxDownload)
        {
            InitializeComponent();

            User = user;

            this.listBoxDownload = listBoxDownload;

            labelTitle.MaxLines = 2;
            labelTitle.Text = user.username;
            labelAuthor.Content = user.full_name;

            labelDuration.Content = user.track_count;

            if (user.avatar_url != null)
            {
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.UriSource = new Uri(user.avatar_url, UriKind.Absolute);
                img.EndInit();
                image.Source = img;
            }

        }
    }
}
