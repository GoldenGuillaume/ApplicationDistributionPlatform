using DistributionPlatform.Core.Interfaces;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace DistributionPlatform.Startup.Views
{
    /// <summary>
    /// Interaction logic for ImportView.xaml
    /// </summary>
    public partial class ImportView : UserControl
    {
        public event EventHandler DownloadEvent;

        private IApplicationService _service;
        private string _thumbnailFileName = null;
        private string _sourcesDirectoryName = null;
        private string _applicationName = null;

        public ImportView(IApplicationService service)
        {
            this._service = service;
            InitializeComponent();
        }

        void ThumbnailImport_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image files(*.bmp;*.jpg;*.jpeg;*.png)|*.bmp;*.jpg;*.jpeg;*.png";

            if (fileDialog.ShowDialog() == true)
            {
                this._thumbnailFileName = fileDialog.FileName;
                thumbnailFileName.Text = Path.GetFileName(fileDialog.FileName);
            }
        }

        void SourcesImport_Click(object sender, RoutedEventArgs e)
        {
            using (var browserDialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult res = browserDialog.ShowDialog();

                if (res == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(browserDialog.SelectedPath))
                {
                    this._sourcesDirectoryName = browserDialog.SelectedPath;
                    sourcesDirectoryName.Text = new DirectoryInfo(browserDialog.SelectedPath).Name;
                }
            }
        }

        void SaveApp_Click(object sender, RoutedEventArgs e)
        {
            this._applicationName = AppName.Text;
            if (!string.IsNullOrWhiteSpace(this._applicationName) && !string.IsNullOrWhiteSpace(this._sourcesDirectoryName) && !string.IsNullOrWhiteSpace(this._thumbnailFileName))
            {
                this._service.SaveApplication(this._applicationName, this._thumbnailFileName, this._sourcesDirectoryName);
                this.DownloadEvent(this, EventArgs.Empty);
            }
        }
    }
}
