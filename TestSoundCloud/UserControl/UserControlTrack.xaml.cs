﻿using System;
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
    /// Logique d'interaction pour UserControlTrack.xaml
    /// </summary>
    public partial class UserControlTrack : UserControl
    {
        public Track Track;

        ListBox listBoxDownload;

        public UserControlTrack(Track track, ListBox listBoxDownload)
        {
            InitializeComponent();

            Track = track;

            this.listBoxDownload = listBoxDownload;

            labelTitle.Content = track.title;
            labelAuthor.Content = track.user.username;

            TimeSpan t = TimeSpan.FromMilliseconds((double)track.duration);
            if (t.Hours > 0)
                labelDuration.Content = String.Format("{0}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
            else
                labelDuration.Content = String.Format("{0}:{1:D2}", t.Minutes, t.Seconds);

            if (track.artwork_url != null)
            {
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.UriSource = new Uri(track.artwork_url, UriKind.Absolute);
                img.EndInit();
                image.Source = img;
            }
        }

        private void buttonDownload_Click(object sender, RoutedEventArgs e)
        {
            ((Button)sender).IsEnabled = false;
            Grid grid = (Grid)((Button)sender).Parent;
            Track track = ((UserControlTrack)grid.Parent).Track;

            listBoxDownload.Items.Add(new UserControlTrackDl(track));
        }

    }
}
