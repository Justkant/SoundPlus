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
    /// Logique d'interaction pour UserControlPlayList.xaml
    /// </summary>
    public partial class UserControlPlayList : UserControl
    {
        public UserControlPlayList(PlayList playList, ListBox listBoxDownload)
        {
            InitializeComponent();
        }
    }
}
