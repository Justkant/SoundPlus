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
    /// Logique d'interaction pour UserControlPages.xaml
    /// </summary>
    public partial class UserControlPages : UserControl
    {

        public MainWindow parent;

        public UserControlPages()
        {
            InitializeComponent();
        }

        private void buttonFirst_Click(object sender, RoutedEventArgs e)
        {
            parent.SearchEngine(0);
        }

        private void buttonPrev_Click(object sender, RoutedEventArgs e)
        {
            parent.SearchEngine(-1);
        }

        private void buttonLast_Click(object sender, RoutedEventArgs e)
        {
            parent.SearchEngine(1);
        }
    }
}
