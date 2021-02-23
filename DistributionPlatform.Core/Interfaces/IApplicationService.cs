namespace DistributionPlatform.Core.Interfaces
{
    public interface IApplicationService
    {
        void SaveApplication(string applicationName, string thumbnailPath, string sourcesDirectoryPath);
    }
}
