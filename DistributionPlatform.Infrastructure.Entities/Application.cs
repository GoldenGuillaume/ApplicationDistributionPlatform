using System;

namespace DistributionPlatform.Infrastructure.Entities
{
    public class Application
    {
        public Application() { }

        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string ApplicationName { get; set; }
        public byte[] Thumbnail { get; set; }
        public byte[] SourceFiles { get; set; } 
    }
}
