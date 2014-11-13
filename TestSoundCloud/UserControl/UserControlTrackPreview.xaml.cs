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
    /// Logique d'interaction pour UserControlTrackPreview.xaml
    /// </summary>
    public partial class UserControlTrackPreview : UserControl
    {
        public UserControlTrackPreview()
        {
            InitializeComponent();
        }

        public void update(Track track)
        {
            labelTitle.Content = track.title;
            labelAuthor.Content = track.user.username;

            if (track.artwork_url != null)
            {
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.UriSource = new Uri(track.artwork_url, UriKind.Absolute);
                img.EndInit();
                image.Source = img;
            }

            if (track.waveform_url != null)
            {
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.UriSource = new Uri(track.waveform_url, UriKind.Absolute);
                img.EndInit();
                imageSound.Source = img;
            }

            labelStartedOn.Content = track.release;
            labelPlays.Content = track.playback_count;
            labelLikes.Content = track.favoritings_count.ToString();
        }
    }
}
