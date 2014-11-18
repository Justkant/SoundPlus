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
        MainWindow parent;
        Track track;

        public UserControlTrackPreview(Track track, MainWindow parent)
        {
            InitializeComponent();

            this.parent = parent;
            this.track = track;

            stackPanelTags.Children.Clear();

            labelTitle.Content = track.title;
            labelAuthor.Content = track.user.username;
            labelDuration.Content = track.duration_string;

            if (track.user.avatar_url != null)
            {
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.UriSource = new Uri(track.user.avatar_url, UriKind.Absolute);
                img.EndInit();
                imageAuthor.Source = img;
            }

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

            foreach (String tag in track.GetTagList())
            {
                Button button = new Button();
                button.Content = "#" + tag;
                button.BorderThickness = new Thickness(0);
                button.Padding = new Thickness(5, 2, 5, 2);
                button.Margin = new Thickness(0, 3, 10, 3);
                button.Click += new RoutedEventHandler(buttonTag_Click);
                stackPanelTags.Children.Add(button);
            }

            textBlockDescription.Text = track.description;
        }

        private void buttonTag_Click(object sender, RoutedEventArgs e)
        {
            Button tagSender = (Button)sender;
            parent.textBoxSearch.Text = tagSender.Content.ToString().Remove(0, 1);

            parent.radioButtonTracks.IsChecked = true;
            
            parent.SearchEngine(0);
        }

        private void buttonUser_Click(object sender, RoutedEventArgs e)
        {
            Button userSender = (Button)sender;
            parent.textBoxSearch.Text = userSender.Content.ToString();

            parent.radioButtonUsers.IsChecked = true;

            parent.SearchEngine(0);
        }

        private void buttonDownload_Click(object sender, RoutedEventArgs e)
        {
            parent.listBoxDownload.Items.Add(new UserControlTrackDl(track));
            buttonDownload.IsEnabled = false;
        }
    }
}
