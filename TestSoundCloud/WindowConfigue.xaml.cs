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
using System.Windows.Shapes;

namespace TestSoundCloud
{
    /// <summary>
    /// Logique d'interaction pour WindowConfigue.xaml
    /// </summary>
    public partial class WindowConfigue : Window
    {
        Preferences pref;

        public WindowConfigue()
        {
            InitializeComponent();
        }

        public void Init(Preferences pref)
        {
            this.pref = pref;

            textBoxPath.Text = pref.SavePath;
        }

        private void buttonBrowse_Click(object sender, RoutedEventArgs e)
        {
            // TODO
        }

        private void Save()
        {
            pref.SavePath = textBoxPath.Text;

            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(Preferences));

            System.IO.StreamWriter file = new System.IO.StreamWriter("config.xml");
            writer.Serialize(file, pref);
            file.Close();
        }

        private void MenuItemSave_Click(object sender, RoutedEventArgs e)
        {
            Save();
        }
    }
}
