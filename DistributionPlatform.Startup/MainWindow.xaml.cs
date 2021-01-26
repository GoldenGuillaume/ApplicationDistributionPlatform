using DistributionPlatform.Startup.Views;
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
        private ImportView ImportViewElement { get; set; }
        private ApplicationsListView ApplicationsListViewElement { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            buttonHome.IsEnabled = false;
            buttonImport.IsEnabled = true;
            this.ImportViewElement = new ImportView();
            this.ApplicationsListViewElement = new ApplicationsListView();
            view.Content = this.ApplicationsListViewElement;
        }

        void Navigation_Click(object sender, RoutedEventArgs e)
        {
            var tag = (sender as Button).Tag.ToString();
            if (tag == "Home")
            {
                buttonImport.IsEnabled = true;
                buttonHome.IsEnabled = false;
                view.Content = this.ApplicationsListViewElement;
            }
            if (tag == "Import")
            {
                buttonImport.IsEnabled = false;
                buttonHome.IsEnabled = true;
                view.Content = this.ImportViewElement;
            }
        }

        void OpenSettings_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("button pressed");
        }
    }
}
