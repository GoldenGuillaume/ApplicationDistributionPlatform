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
        private readonly ImportView _importView;
        private readonly ApplicationsListView _appListView;

        public MainWindow(ImportView importView, ApplicationsListView appListView)
        {
            InitializeComponent();

            this._importView = importView;
            this._appListView = appListView;

            this._importView.DownloadEvent = new EventHandler(Import_DownloadEvent);

            buttonHome.IsEnabled = false;
            buttonImport.IsEnabled = true;

            view.Content = this._appListView;
        }

        void Navigation_Click(object sender, RoutedEventArgs e)
        {
            var tag = (sender as Button).Tag.ToString();
            if (tag == "Home")
            {
                buttonImport.IsEnabled = true;
                buttonHome.IsEnabled = false;
                view.Content = this._appListView;
            }
            if (tag == "Import")
            {
                buttonImport.IsEnabled = false;
                buttonHome.IsEnabled = true;
                view.Content = this._importView;
            }
        }

        void Import_DownloadEvent(object sender, EventArgs e)
        {
            buttonImport.IsEnabled = true;
            buttonHome.IsEnabled = false;
            view.Content = this._appListView;
        }

        void OpenSettings_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("button pressed");
        }
    }
}
