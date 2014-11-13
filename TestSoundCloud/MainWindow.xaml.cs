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
        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            listBoxResult.Items.Clear();
            List<Track> tracks = client.SearchTrack(textBoxSearch.Text);

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
            if (e.Key == Key.Enter)
                buttonSearch_Click(null, null);
        }
    }
}
