using System;
using System.Windows;
using System.Windows.Controls;

namespace DistributionPlatform.Startup
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool IsMainPage { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            IsMainPage = false;
        }

        void Navigation_Click(object sender, RoutedEventArgs e)
        {
            var tag = (sender as Button).Tag.ToString();
            if (tag == "Home")
            {

            }
            if (tag == "Import")
            {

            }
        }

        void OpenSettings_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("button pressed");
        }
    }
}
