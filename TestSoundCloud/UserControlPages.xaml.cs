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

        public void Reset()
        {
            labelPage.Content = "0";
        }

        private void changePage(int n)
        {
            int current = Convert.ToInt32(labelPage.Content);

            if (current == 1 && n == -1)
                return;

            parent.SearchEngine(n);
            labelPage.Content = (current + n).ToString();
        }

        private void buttonFirst_Click(object sender, RoutedEventArgs e)
        {
            changePage(0);
        }

        private void buttonPrev_Click(object sender, RoutedEventArgs e)
        {
            changePage(-1);
        }

        private void buttonLast_Click(object sender, RoutedEventArgs e)
        {
            changePage(1);
        }
    }
}
