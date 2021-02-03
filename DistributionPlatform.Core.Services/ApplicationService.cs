using DistributionPlatform.Core.Interfaces;
using DistributionPlatform.Infrastructure.Entities;
using DistributionPlatform.Infrastructure.Providers;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;

namespace DistributionPlatform.Core.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationsProvider _provider;

        public ApplicationService(IApplicationsProvider provider)
        {
            this._provider = provider;
        }

        public void SaveApplication(string thumbnailPath, string sourcesDirectoryPath)
        {
            // recover thumbnail file contet
            byte[] thumbnail = File.ReadAllBytes(thumbnailPath);

            // build the target application
            //using var process = new Process()
            //{
            //    // use make to compile c++ program 
            //    StartInfo = new ProcessStartInfo("cmake.exe", "")
            //    {
            //        FileName = "gcc",
            //        UseShellExecute = true,
            //        WorkingDirectory = @sourcesDirectoryPath,
            //        WindowStyle = ProcessWindowStyle.Hidden,
            //        RedirectStandardError = true,
            //    }
            //};
            //process.Start();

            // save compiled sources into zip file and load it in memory
            var tempFilePath = $"{Environment.CurrentDirectory}/tempBinfiles-{Guid.NewGuid()}";
            ZipFile.CreateFromDirectory($"{sourcesDirectoryPath}/bin", tempFilePath);
            byte[] sources = File.ReadAllBytes(tempFilePath);

            Application application = new Application()
            {
                ApplicationName = "test",
                Thumbnail = thumbnail,
                SourceFiles = sources
            };
            this._provider.InsertApplication(application);
            this._provider.SaveContext();
        }
    }
}
