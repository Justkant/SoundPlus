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
    /// Logique d'interaction pour UserControlTrackLocal.xaml
    /// </summary>
    public partial class UserControlTrackLocal : UserControl
    {
        public FileInfo Track;
        ListBox listLocal;

        public UserControlTrackLocal(FileInfo track, ListBox listLocal)
        {
            InitializeComponent();
            this.listLocal = listLocal;

            Track = track;

            labelTitle.Content = track.Name;
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            Track.Delete();
            listLocal.Items.Remove(this);
        }
    }
}
