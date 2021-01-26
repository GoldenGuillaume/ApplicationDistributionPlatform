using Microsoft.Win32;
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
        private string ThumbnailFileName { get; set; } = null;
        private string SourcesDirectoryName { get; set; } = null;

        public ImportView()
        {
            InitializeComponent();
        }

        void ThumbnailImport_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image files(*.bmp;*.jpg;*.jpeg;*.png)|*.bmp;*.jpg;*.jpeg;*.png";

            if (fileDialog.ShowDialog() == true)
            {
                this.ThumbnailFileName = fileDialog.FileName;
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
                    this.SourcesDirectoryName = browserDialog.SelectedPath;
                    sourcesDirectoryName.Text = new DirectoryInfo(browserDialog.SelectedPath).Name;
                }
            }
        }

        void SaveApp_Click(object sender, RoutedEventArgs e)
        {
            // get thumbnail and sources then save into database
        }
    }
}
